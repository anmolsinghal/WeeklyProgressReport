namespace WPR.Entities.Models
{
    using System;
    
    public class NextWeekPlan
    {
        public int NextWeekPlanId { get; set; }
        public string Task { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
