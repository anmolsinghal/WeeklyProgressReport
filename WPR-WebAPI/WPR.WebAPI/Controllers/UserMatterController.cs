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

namespace PartnerViewAuthenticationWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserMatterController : ApiController
    {
        public UserMatterController() { }

        [HttpPost]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public string AssignMatters(IEnumerable<MatterSearchParms> matters)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            using (var client = new HttpClient())
            {
                string URI = ConfigurationManager.AppSettings["ClientMatterAPI"];
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userMatterResponse = client.PostAsJsonAsync("api/UserMatter/AssignMatters", matters).Result;
                if (userMatterResponse.IsSuccessStatusCode)
                {
                    var result = userMatterResponse.Content.ReadAsStringAsync().Result.ToString();
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
