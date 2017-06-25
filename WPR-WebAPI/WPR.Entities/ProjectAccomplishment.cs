namespace WPR.Entities.Models
{
    using System;
    
    public class ProjectAccomplishment
    {
        public int ProjectAccomplishmentId { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public string Accomplishment { get; set; }
        public string Remarks { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual User User { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
