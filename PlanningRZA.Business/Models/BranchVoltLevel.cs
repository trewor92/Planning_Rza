using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningRZA.Business.Models
{
    public class BranchVoltLevel
    {
        public int BranchId { get; set; }

        public VoltLevel VoltLevel { get; set; }
    }
}
