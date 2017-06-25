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
using PartnerView.Entities;
using model = PartnerView.WebAPI.Models;
using System.Net.Http.Headers;
using PartnerView.Repository.Interface;

namespace PartnerView.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientController : BaseController
    {
        //private readonly IClientMatterRepository _clientMatterRepository = null;

        public ClientController(IClientMatterRepository repository) : base(repository) { }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetClients(string parm)
        {
            try
            {
                var clients = GetMatters(parm).Select(m => m.Client).Distinct();
                if (clients.Any())
                {
                    return Content(HttpStatusCode.OK,
                        clients.Select(m => new
                        {
                            Id = m.Id,
                            Name = m.Name
                        }),
                        Configuration.Formatters.JsonFormatter);
                }

                return Content(HttpStatusCode.NoContent, string.Format("User {0} has no access to any matters", parm));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Content(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult Get(ClientSearchParms parms)
        {
            try
            {
                var client = GetMatters(parms.userName).Where(m => m.ClientId == parms.clientId).Select(m => m.Client).Distinct().SingleOrDefault();
                if (client == null) return Content(HttpStatusCode.NoContent,
                    string.Format("Client {0} not found. User {1} may not have access.", parms.clientId, parms.userName));

                return Content(HttpStatusCode.OK,
                    new
                    {
                        id = client.Id,
                        name = client.Name,
                    },
                    Configuration.Formatters.JsonFormatter);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Content(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
