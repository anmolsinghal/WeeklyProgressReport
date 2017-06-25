using System.Data.Entity;
using WPR.Entities.Models;

namespace WPR.DAL.EntityFramework
{
    public class WPRContext : DbContext
    {
        static WPRContext()
        {
            Database.SetInitializer<WPRContext>(null);
        }

        public WPRContext()
            : base("Name=WPRContext")
        {
            // this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }
        //static WPRContext()
        //{
        //    Database.SetInitializer<WPRContext>(null);
        //}
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ConfigurationValue> ConfigurationValues { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<LeavePlan> LeavePlans { get; set; }
        public virtual DbSet<NextWeekPlan> NextWeekPlans { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectAccomplishment> ProjectAccomplishments { get; set; }
        public virtual DbSet<ProjectMilestone> ProjectMilestones { get; set; }
        public virtual DbSet<ProjectTeamMember> ProjectTeamMembers { get; set; }
        public virtual DbSet<Risk> Risks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeeklyProjectReport> WeeklyProjectReports { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
