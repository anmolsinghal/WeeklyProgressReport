namespace WPR.Entities.Models
{
    using System;
    public class LeavePlan
    {
        public int LeavePlanId { get; set; }
        public int? UserId { get; set; }
        public string LeavePurpose { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual User User { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
