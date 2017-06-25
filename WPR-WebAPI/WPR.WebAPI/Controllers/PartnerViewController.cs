using PartnerView.Entities;
using PartnerView.Repository.Interface;
using PartnerView.WebAPI.Models;
using PartnerViewAuthenticationWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace PartnerView.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PartnerViewController : BaseController
    {
        private readonly IPartnerViewRepository _pvRepository = null;
        public PartnerViewController(IPartnerViewRepository pvRepository, IClientMatterRepository cmRepository):base(cmRepository)
        {
            _pvRepository = pvRepository;
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public HttpResponseMessage GetPagedMatterCustodianSummary(string userName, int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber == 0) { pageNumber = 1; }

                var skip = (pageNumber - 1) * pageSize;

                var matters = base.GetMatters(userName);
                var matterCustodians = _pvRepository.GetMatters();

                var summary = (from mc in matterCustodians.ToList()
                               join m in matters.ToList() on mc.MatterId equals m.Id
                               select new {
                                    matterId = m.Id,
                                    matterName = m.Name,
                                    custodianCount = mc.TotalCustodians,
                                    collectedCount = mc.CollectedCustodians,
                                    ingestedCount = mc.IngestedCustodians,
                                    processedCount = mc.ProcessedCustodians,
                                    reviewedCount = mc.ReviewedCustodians,
                                    producedCount = mc.ProducedCustodians
                               });

                var total = summary.Count();
                var data = summary
                    .OrderBy(s => s.matterId)
                    .Skip(skip)
                    .Take(pageSize);


                return Request.CreateResponse(HttpStatusCode.OK, 
                    new
                    {
                        data = data,
                        pageNumber = pageNumber,
                        pageSize = pageSize,
                        totalCount = total
                    }, 
                    Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.InnerException.Message);
            }
        }

        //[HttpGet]
        //[AuthorizationRequired]
        //[AllowCrossSiteJsonAttribute]
        //public HttpResponseMessage GetPagedMatterCustodianSummary2(string userName, int pageNumber, int pageSize)
        //{
        //    try
        //    {
        //        if (pageNumber == 0) { pageNumber = 1; }

        //        var skip = (pageNumber - 1) * pageSize;

        //        var matters = base.GetMatters(userName);
        //        var matterCustodians = _pvRepository
        //            .GetDatasets()
        //            .Select(d => new { MatterId = d.MatterId, CustodianId = d.CustodianId })
        //            .Distinct()
        //            .GroupBy(mc => mc.MatterId)
        //            .Select(mc => new { MatterId = mc.Key, CustodianCount = mc.Count() });
        //        var summary = (from mc in matterCustodians.ToList()
        //                       join m in matters.ToList() on mc.MatterId equals m.Id
        //                       select new
        //                       {
        //                           matterId = m.Id,
        //                           matterName = m.Name,
        //                           custodianCount = mc.CustodianCount
        //                       });

        //        var total = summary.Count();
        //        var data = summary
        //            .OrderBy(s => s.matterId)
        //            .Skip(skip)
        //            .Take(pageSize);


        //        return Request.CreateResponse(HttpStatusCode.OK,
        //            new
        //            {
        //                data = data,
        //                pageNumber = pageNumber,
        //                pageSize = pageSize,
        //                totalCount = total
        //            },
        //            Configuration.Formatters.JsonFormatter);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.InnerException.Message);
        //    }
        //}

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public HttpResponseMessage GetMatterCustodianSummary(string parm)
        {
            try
            {
                var matters = base.GetMatters(parm);

                var custodians = _pvRepository.GetCustodians().ToList();
                var summary = (from M in matters
                               join CU in custodians on M.ClientId equals CU.ClientId
                               group M.Id by new { M.Id, M.Name }
                                   into grp
                                   select new
                                   {
                                       matterId = grp.Key.Id,
                                       matterName = grp.Key.Name,
                                       custodianCount = grp.Count()
                                   }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, summary, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException.InnerException.Message);
            }
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetDataVolumeSummary(string userName, string matterId = null)
        {
            var matters = base.GetMatters(userName)
                .Where(m => m.Id == (matterId == null ? m.Id: matterId)).ToList();

            if(!matters.Any())
            {
                return Content(HttpStatusCode.InternalServerError, string.Format("User {0} does not have access to view matter {1}", userName, matterId));

            }

            var matterSummary = _pvRepository.GetMatters();

            var dataVolumeSummary = matters.Join(
                    matterSummary,
                    m => m.Id,
                    md => md.MatterId,
                    (x, y) => new
                    {
                        Collected = y.CollectedSize,
                        Ingested = y.IngestedSize,
                        Processed = y.ProcessedSize,
                        Reviewed = y.ReviewedSize,
                        Produced = y.ProducedSize,
                    })
                    .GroupBy(x => 1)
                    .Select(x => new
                    {
                        Collected = x.Sum(d => d.Collected),
                        Ingested = x.Sum(d => d.Ingested),
                        Processed = x.Sum(d => d.Processed),
                        Reviewed = x.Sum(d => d.Reviewed),
                        Produced = x.Sum(d => d.Produced)
                    }).SingleOrDefault();

            return Content(HttpStatusCode.OK, dataVolumeSummary, Configuration.Formatters.JsonFormatter);

        }

        [HttpPost]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetMatterDatasetDetail(MatterDatasetParms parms)
        {
            var matter = base.GetMatters(parms.UserName)
                .Where(m => m.Id == parms.MatterId).SingleOrDefault();

            if (matter == null)
            {
                return Content(HttpStatusCode.InternalServerError, 
                    string.Format("User {0} does not have access to view matter {1}", parms.UserName, parms.MatterId));

            }

            var data = _pvRepository.GetMatterDatasets()
                .Where(md => md.MatterId == parms.MatterId)
                .Where(md => parms.CustodianIds.Contains(md.Dataset.CustodianId ?? 0))
                .Select(md => new
                {
                    matterId = md.MatterId,
                    custodianId = md.Dataset.CustodianId,
                    custodianName = md.Dataset.Custodian.Name,
                    datasetType = md.Dataset.Type.Name,
                    collectedItems = md.Dataset.CollectionItems ?? 0,
                    collectedSize = md.Dataset.CollectionSize ?? 0,
                    ingestedItems = md.Dataset.IntakeItems ?? 0,
                    ingestedSize = md.Dataset.IntakeSize ?? 0,
                    processedItems = md.Dataset.ProcessingItems ?? 0,
                    processedSize = md.Dataset.ProcessingSize ?? 0,
                    reviewedItems = md.Dataset.ReviewItems ?? 0,
                    reviewedSize = md.Dataset.ReviewSize ?? 0,
                    producedItems = md.Dataset.ProductionItems ?? 0,
                    producedSize = md.Dataset.ProductionSize ?? 0
                })
                .ToList();

            return Content(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public new HttpResponseMessage GetMatters(string parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            var matters = base.GetMatters(parm);
            var summary = (from M in matters
                           select new
                           {
                               matterId = M.Id,
                               matterName = M.Name
                           }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, summary, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public HttpResponseMessage GetMatterProductionSummary(string parm)
        {
            var token = System.Web.HttpContext.Current.User.Identity.Name;
            var matters = base.GetMatters(parm);
            var productions = _pvRepository.GetProductions().ToList();

            var summary = (from M in matters
                           join P in productions on M.Id equals P.MatterId
                           group P by M.Name
                               into grp
                               select new
                               {
                                   matterName = grp.Key,
                                   sizeGB = Convert.ToDecimal(grp.Sum(Pt => Convert.ToDouble(Pt.Size) / 1073741824))
                               }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, summary, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [AuthorizationRequired]
        [AllowCrossSiteJsonAttribute]
        public IHttpActionResult GetCustodianSummary(string userName, string matterId)
        {
            try
            {
                var matter = base.GetMatters(userName).Where(m => m.Id == matterId).SingleOrDefault();
                if (matter == null) { return Content(HttpStatusCode.NoContent, string.Format("User {0} may not have access to matter{1}", userName, matterId)); }

                var custodians = _pvRepository.GetMatterCustodians()
                    .Where(mc => mc.MatterId == matterId)
                    .Select(mc => new
                    {
                        custodianId = mc.CustodianId,
                        custodianName = mc.Custodian.Name,
                        collected = (mc.CollectedSize ?? 0) != 0,
                        ingested = (mc.IngestedSize ?? 0) != 0,
                        processed = (mc.ProcessedSize ?? 0) != 0,
                        reviewed = (mc.ReviewedSize ?? 0) != 0,
                        produced = (mc.ProducedSize ?? 0) != 0,
                        selected = false
                    }).ToList();


                return Content(HttpStatusCode.OK, custodians, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}