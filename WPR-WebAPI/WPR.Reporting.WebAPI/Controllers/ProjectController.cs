using WPR.Repository.Interface;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Core.Reporting.WebAPI.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        private readonly IProjectRepository _projectRepository = null;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #region
        [HttpGet]
        public IHttpActionResult GetProjects()
        {
            try
            {
                var projects = _projectRepository.GetProjects();
                return Content(HttpStatusCode.OK, projects, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
