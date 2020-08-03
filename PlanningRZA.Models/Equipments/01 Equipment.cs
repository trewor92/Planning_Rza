using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Equipments
{
    public class Equipment:BaseEntity
    {
        public int YearOfProduction { get; set; }
        public VoltLevel PrimaryVoltage { get; set; }
    }
}
