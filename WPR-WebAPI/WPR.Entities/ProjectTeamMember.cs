namespace WPR.Entities.Models
{

    public class ProjectTeamMember
    {
        public int ProjectTeamMemberId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
