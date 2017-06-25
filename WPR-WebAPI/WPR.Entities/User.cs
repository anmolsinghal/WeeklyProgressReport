namespace WPR.Entities.Models
{
    using System;
    using System.Collections.Generic;
    
    public class User
    {
        public User()
        {
            LeavePlans = new HashSet<LeavePlan>();
            Projects = new HashSet<Project>();
            ProjectAccomplishments = new HashSet<ProjectAccomplishment>();
            ProjectTeamMembers = new HashSet<ProjectTeamMember>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<LeavePlan> LeavePlans { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectAccomplishment> ProjectAccomplishments { get; set; }
        public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }
        public virtual Role Role { get; set; }
    }
}
