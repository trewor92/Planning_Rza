using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Web.ViewModels.TableControllerViewModels
{
    public class EquipmentDataViewModel
    {
        public int Id { get; set; }
        [Description("Наименование оборудования")]
        public string Name { get; set; }
        [Description("Номинальное высшее напряжение")]
        public string PrimaryVoltage { get; set; }
        [Description("Год выпуска")]
        public int YearOfProduction { get; set; }
    }
}
