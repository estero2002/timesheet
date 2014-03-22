namespace Timesheet.Models
{
    using System;

    public class WorkItem
    {
        public Guid Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Summary { get; set; }

        public double IncomePerHour { get; set; }

        public virtual Project Project { get; set; }
    }
}