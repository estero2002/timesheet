namespace Timesheet.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class TimesheetContext : IdentityDbContext<ApplicationUser>
    {
        public TimesheetContext() : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<WorkItem> Tasks { get; set; }
    }
}