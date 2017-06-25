namespace WPR.Entities.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public Project()
        {
            ProjectTeamMembers = new HashSet<ProjectTeamMember>();
            WeeklyProjectReports = new HashSet<WeeklyProjectReport>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? UserId { get; set; }
        public string ProjectCode { get; set; }
        public int? CustomerId { get; set; }
        public int? TeamSize { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }
        public virtual ICollection<WeeklyProjectReport> WeeklyProjectReports { get; set; }
    }
}
