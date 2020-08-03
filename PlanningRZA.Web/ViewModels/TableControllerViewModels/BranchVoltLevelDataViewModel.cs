using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Web.ViewModels.TableControllerViewModels
{
    public class BranchVoltLevelDataViewModel
    {
        public int Id { get; set; }
        [Description("Наименование подстанции")]
        public string Name { get; set; }
        [Description("Количество оборудования")]
        public int Count { get; set; }
    }
}
