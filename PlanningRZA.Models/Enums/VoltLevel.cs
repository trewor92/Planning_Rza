using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Enums
{
    public enum VoltLevel
    {
        [Description("Не задан")]
        none,
        [Description("10 кВ")]
        _10kV,
        [Description("35 кВ")]
        _35kV,
        [Description("110 кВ")]
        _110kV,
        [Description("220 кВ")]
        _220kV,
        [Description("330 кВ")]
        _330kV
    }
}
