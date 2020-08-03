using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Web.ViewModels.TableControllerViewModels
{
    public class BranchDataViewModel
    {
        public int Id { get; set; }
        [Description("Класс напряжения")]
        public string Name { get; set; }
        [Description("Кол-во подстанций")]
        public int Count { get; set; }
    }
}
