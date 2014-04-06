namespace Timesheet.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WorkItem
    {
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime From { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime To { get; set; }

        public string Summary { get; set; }

        public double IncomePerHour { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}