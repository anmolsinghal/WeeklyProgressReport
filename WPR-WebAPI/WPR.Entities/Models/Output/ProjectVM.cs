using System;

namespace WPR.Entities.Models.Output
{
    public class ProjectVM
    {
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public int? TeamSize { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
