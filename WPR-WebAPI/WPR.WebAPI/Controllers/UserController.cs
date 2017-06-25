//using CodeFirst.Models;
using PartnerView.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Security;
using PartnerView.DAL.EntityFramework;
using System.Text;
using Ninject;
using System.Reflection;
using PartnerView.WebAPI.App_Start;
using System.Web;
using System.Configuration;
using System.IO;
using System.Collections;
using PartnerView.Entities;
using System.Net.Http.Headers;



namespace PartnerView.WebAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public UserController() { }


        [HttpPost]
        public AccountDetail LoginUser(UserCredentials userCredentials)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.PostAsJsonAsync("api/User/LoginUser", userCredentials).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    return userResponse.Content.ReadAsAsync<AccountDetail>().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public string AddUser(AccountDetail accountDetail)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.PostAsJsonAsync("api/User/AddUser", accountDetail).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result.ToString();
                    return result.Replace("\"", "");
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public AccountDetail GetUser(Guid parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.GetAsync("api/User/GetUser/" + parm).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    return userResponse.Content.ReadAsAsync<AccountDetail>().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public AccountDetail GetUser(string userName, string applicationName)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.GetAsync(string.Format("api/User/GetUser?userName={0}&applicationName={1}", userName.ToString(), applicationName)).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    return userResponse.Content.ReadAsAsync<AccountDetail>().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetUsers()
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.GetAsync("api/User/GetUsers?applicationName=PartnerView").Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var usersList = userResponse.Content.ReadAsAsync<IEnumerable<AccountDetail>>().Result;
                    return Content(HttpStatusCode.OK, usersList, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "Failed to retrieve user information.");
                }
            }
        }

        [HttpGet]
        public string SetPasswordToken(string parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.GetAsync("api/User/SetPasswordToken/" + parm).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPut]
        [AuthorizationRequired]
        public string ModifyUser(AccountDetail accountDetail)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.PutAsJsonAsync("api/User/ModifyUser", accountDetail).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result;
                    return result.Replace("\"", "");
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage SetUpProfile(AccountDetail accountDetail)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.PutAsJsonAsync("api/User/SetUpProfile", accountDetail).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var userProfile = userResponse.Content.ReadAsAsync<AccountDetail>().Result;
                    return Request.CreateResponse<AccountDetail>(HttpStatusCode.OK, userProfile, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage AuthenticateLoginToken(string parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.GetAsync("api/User/AuthenticateLoginToken/" + parm).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var userProfile = userResponse.Content.ReadAsAsync<AccountDetail>().Result;
                    return Request.CreateResponse<AccountDetail>(HttpStatusCode.OK, userProfile, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpDelete]
        [AuthorizationRequired]
        public string DeleteUser(Guid parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userResponse = client.DeleteAsync("api/User/DeleteUser/" + parm).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result;
                    return result.Replace("\"", "");
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        public string AuthenticateToken(string parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.GetAsync("api/User/AuthenticateToken/" + parm).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result;
                    return result.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        [AllowCrossSiteJsonAttribute]
        public string ChangePassword(AccountDetail accountDetail)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["AuthenticationAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userResponse = client.PostAsJsonAsync("api/User/ChangePassword", accountDetail).Result;
                if (userResponse.IsSuccessStatusCode)
                {
                    var result = userResponse.Content.ReadAsStringAsync().Result.ToString();
                    return result.Replace("\"", "");
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
