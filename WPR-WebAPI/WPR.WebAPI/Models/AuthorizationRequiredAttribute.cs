using Ninject;
using PartnerView.DAL.EntityFramework;
using PartnerView.Entities;
using PartnerView.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PartnerView.WebAPI.Models
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            Boolean IsValidToken = false;
            var tokenValue = Convert.ToString(filterContext.Request.Headers.Authorization);
            if (tokenValue != "null")
            {
                //IKernel kernel = new StandardKernel();
                //IEntityRepository<UserDetail, int> userRepository = kernel.Get<UserDetailRepository>();
                using (var client = new HttpClient())
                {
                    string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                    client.BaseAddress = new Uri(URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    var response = client.GetAsync("api/user/LoginTokenAuthentication/" + tokenValue).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var account = response.Content.ReadAsStringAsync().Result.ToString();
                        if (account.Length > 0)
                        {
                            IsValidToken = true;
                        }
                        else
                        {
                            IsValidToken = false;
                        }
                    }
                    else
                    {
                        IsValidToken = false;
                    }
                }
                //if (userRepository.GetAll().Where(s => s.loginToken == tokenValue).Any())
                //{
                //    IsValidToken = true;
                //}
                if (IsValidToken)
                {
                    var userNameClaim = new Claim(ClaimTypes.Name, tokenValue);
                    var identity = new ClaimsIdentity(new[] { userNameClaim }, "AuthorizationApiKey");
                    var principal = new ClaimsPrincipal(identity);
                    Thread.CurrentPrincipal = principal;
                    if (System.Web.HttpContext.Current != null)
                    {
                        System.Web.HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}