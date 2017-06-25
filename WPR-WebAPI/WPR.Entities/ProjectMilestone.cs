namespace WPR.Entities.Models
{
    using System;

    public class ProjectMilestone
    {
        public int Id { get; set; }
        public string Milestone { get; set; }
        public int? StatusId { get; set; }
        public int? WeeklyProjectReportId { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? ActualCompleteDate { get; set; }
        public virtual WeeklyProjectReport WeeklyProjectReport { get; set; }
    }
}
