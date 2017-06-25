//using ProspectUpdates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using PartnerView.WebAPI.App_Start;

namespace PartnerView.WebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Class for Token based authentication
            GlobalConfiguration.Configuration.EnsureInitialized();
           // GlobalConfiguration.Configuration.MessageHandlers.Add(new ApplicationAuthenticationHandler());
            //AreaRegistration.RegisterAllAreas();
           // IocConfig.RegisterIoc(GlobalConfiguration.Configuration);
            //NinjectWebCommon.Register(GlobalConfiguration.Configuration);
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            RedirectToSSL();
        }
        /// <summary>
        /// Method to redirect any webform coming from http to https
        /// </summary>
        /// There should be a key in web.config file for this to work, 
        /// Key = EnableSSL , value = true
        private void RedirectToSSL()
        {
            if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EnableSSL"]) == "true")
            {
                if (Request.Url.Scheme.ToLower() == "http")
                {

                    string newUrl = "https://" + Request.Url.Authority + Request.Url.AbsolutePath;
                    Response.Redirect(newUrl, false);
                }
            }
        }
    }
}