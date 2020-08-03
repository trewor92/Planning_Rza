using PlanningRZA.Business.Models;
using PlanningRZA.Models.Equipments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.Business.Interfaces
{
    public interface ISubstationService
    {
        public Task<List<EquipmentData>> GetSubstationData(int substationId);
        public Task<string> GetSubstationName(int substationId);
    }
}
