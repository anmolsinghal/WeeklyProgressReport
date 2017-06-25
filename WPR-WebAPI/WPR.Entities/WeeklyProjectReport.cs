namespace WPR.Entities.Models
{
    using System;
    public class WeeklyProjectReport
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? ProjectCurrentPhaseId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? ProjectHealthByScheduleStatusId { get; set; }
        public string ScheduleRemarks { get; set; }
        public int? ProjectHealthByEffortStatusId { get; set; }
        public string EffortRemarks { get; set; }
        public int? ProjectHealthByQualityStatusId { get; set; }
        public string QualityRemarks { get; set; }
        public string ProjectProgressUpdate { get; set; }
        public string ProjectImpedimentDetails { get; set; }
        public string ExecuteSummary { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
