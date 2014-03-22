namespace Timesheet.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Client { get; set; }

        public string Description { get; set; }

        public double IncomePerHour { get; set; }

        public bool IsClosed { get; set; }

        public virtual ICollection<WorkItem> Tasks { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}