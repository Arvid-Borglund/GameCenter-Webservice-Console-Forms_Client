using System;
using System.Collections.Generic;

namespace WebApplicationGameCenter.Models
{
    public partial class EmployeeSchedule
    {
        public string EmployeeId { get; set; } = null;

        public DateTime ShiftDate { get; set; }

        public string Name { get; set; } = null;

        public string ShiftResponsibilities { get; set; } = null;

        public virtual Employee Employee { get; set; } = null;
    }
}