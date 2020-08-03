using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models
{
    public class Branch:BaseEntity
    {
        public BranchDirection Direction { get; set; }
        public List<Substation> Substations { get; set; }

        public Branch()
        {
            Substations = new List<Substation>();
        }
    }
}
