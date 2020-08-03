using PlanningRZA.Models.Enums;
using PlanningRZA.Models.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models
{
    public class Substation : BaseEntity
    {
        public Substation()
        {
            Equipments = new List<Equipment>();
        }
        public VoltLevel VoltageLevel { get; set; }
        public string Area { get; set; }
        public List<Equipment> Equipments { get; set; }
    }
}
