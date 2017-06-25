namespace WPR.Entities.Models
{
    using System;

    public class Issue
    {
        public int IssueId { get; set; }
        public string Description { get; set; }
        public int? IssueTypeId { get; set; }
        public int? IssueSeverityId { get; set; }
        public DateTime? IssueRaisedDate { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? PlannedClosureDate { get; set; }
        public DateTime? ActualClosureDate { get; set; }
        public int? IssueStatus { get; set; }
        public string Remarks { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
