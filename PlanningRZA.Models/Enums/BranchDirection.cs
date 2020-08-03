using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Enums
{
    [Flags]
    public enum BranchDirection
    {
        Electical = 1,
        Heat = 2
    }
}
