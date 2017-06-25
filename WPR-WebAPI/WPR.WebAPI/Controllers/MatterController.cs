using ent = PartnerView.Entities;
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
using System.Net.Http.Headers;
using PartnerView.Repository.Interface;
using PartnerView.WebAPI.Controllers;

namespace PartnerViewAuthenticationWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MatterController : BaseController
    {
        public MatterController(IClientMatterRepository repository) : base(repository) { }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetPagedMatters(string userName,int pageNumber, int pageSize)
        {
            try
            {

                if(pageNumber < 1) { pageNumber = 1; } //added to avoid error if negative value passed.
                var skip = (pageNumber - 1) * pageSize;

                var matters = base.GetMatters(userName);
                var total = matters.Count();
                var data = matters
                    .OrderBy(m => m.Id)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(m => new
                    {
                        Name = m.Name,
                        MatterId = m.Id,
                        ClientId = m.Client.Id,
                        ClientName = m.Client.Name
                    });
                return Content(HttpStatusCode.OK,
                    new {
                        data = data,
                        pageNumber = pageNumber,
                        pageSize = pageSize,
                        totalCount = total
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

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public new IHttpActionResult GetMatters(string parm)
        {
            try
            {
                var matters = base.GetMatters(parm);
                if (matters.Any())
                {
                    return Content(HttpStatusCode.OK,
                        matters.Select(m => new
                        {
                            Name = m.Name,
                            MatterId = m.Id,
                            ClientId = m.Client.Id,
                            ClientName = m.Client.Name
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
        public IHttpActionResult Get(MatterSearchParms parms)
        {
            try
            {
                var matter = base.GetMatters(parms.userName).Where(m => m.Id == parms.matterId).SingleOrDefault();
                if (matter == null) return Content(HttpStatusCode.NoContent, 
                    string.Format("Matter {0} not found. User {1} may not have access to view the matter.", parms.matterId, parms.userName));
                return Content(HttpStatusCode.OK, 
                    new
                    {
                        id = matter.Id,
                        name = matter.Name,
                        clientId = matter.ClientId,
                        clientName = matter.Client.Name
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
