using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningRZA.Business.Models
{
    public class EquipmentData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VoltLevel PrimaryVoltage { get; set; }
        public int YearOfProduction { get; set; }
    }
}
