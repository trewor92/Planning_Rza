using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Equipments
{ 
    public class CurrentTransformer : Equipment
    {
        public int CountOfSecondaryWinding { get; set; }
        public int CountOfPoles { get; set; }
        public int PrimaryCurrent { get; set; }
        public int SecondaryCurrent { get; set; }
        public override string ToString()
        {
            return $"Current transformer {base.ToString()}";
        }
    }
}
