using WPR.Repository.Interface;
using System.Linq;
using WPR.DAL.EntityFramework;
using System.Collections.Generic;
using WPR.Entities.Models.Output;

namespace WPR.Reporting.BLL
{
    public class ProjectRepository : IProjectRepository
    {
        List<ProjectVM> IProjectRepository.GetProjects()
        {
            using (var context = new WPRContext())
            {
                var projects = context.Projects.Select(d => new ProjectVM { ProjectName = d.ProjectName, ProjectCode = d.ProjectCode, CreatedDate = d.CreatedDate, TeamSize = d.TeamSize }).ToList();
                return projects;
            }
        }
    }
}
