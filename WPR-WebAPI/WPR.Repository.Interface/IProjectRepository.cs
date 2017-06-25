using System.Collections.Generic;
using WPR.Entities.Models.Output;

namespace WPR.Repository.Interface
{
    public interface IProjectRepository
    {
        List<ProjectVM> GetProjects();
    }
}
