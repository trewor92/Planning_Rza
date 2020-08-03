using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Web.ViewModels.TableControllerViewModels
{
    public class TableDataViewModel<T>
    {
        public string Name { get; set; }
        public Dictionary<string,string> Header { get; set; }
        public List<T> Data { get; set; }
    }
}
