using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Equipments
{
    public class Transformer : Equipment
    {
        public VoltLevel SecondaryVoltage { get; set; }
        public VoltLevel TertiaryVoltage { get; set; }
        public VoltLevel QuarternaryVoltage { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return $"Transformer {base.ToString()}";
        }
    }
}
