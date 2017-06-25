namespace WPR.Entities.Models
{
    using System;
    public class Risk
    {
        public int RiskId { get; set; }
        public string RiskDescription { get; set; }
        public string MitigationPlan { get; set; }
        public DateTime? PlannedMitigationPlanDate { get; set; }
        public DateTime? ActualMitigationPlanDate { get; set; }
        public int? RiskStatusId { get; set; }
        public DateTime? StatusLastUpdated { get; set; }
        public string ConfigurationPlan { get; set; }
        public DateTime? ActualConfigurationDate { get; set; }
        public string Remarks { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
