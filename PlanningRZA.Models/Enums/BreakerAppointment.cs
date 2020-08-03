using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Enums
{
    [Flags]
    public enum BreakerAppointment
    {
        Coupling = 1,
        Bypass = 2,
        BusCoupling = 4,
        Line = 8,
        Transformer = 16
    }
}
