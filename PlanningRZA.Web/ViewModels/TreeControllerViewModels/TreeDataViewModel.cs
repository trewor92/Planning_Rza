using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Web.ViewModels.TreeControllerViewModels
{
    public class TreeDataViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ChildMethod { get; set; }
        public bool IsFolder { get; set; } = false;
        public bool IsRoot { get; set; } = false;
    }
}
