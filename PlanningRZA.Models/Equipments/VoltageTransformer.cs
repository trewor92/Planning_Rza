using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Equipments
{    
    public class VoltageTransformer : Equipment
    { 
        public int CountOfSecondaryWinding { get; set; }
        public bool HasOpenedTriangle { get; set; }

        public override string ToString()
        {
            return $"Voltage transformer {base.ToString()}";
        }
    }
}