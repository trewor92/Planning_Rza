using PlanningRZA.Business.Models;
using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.Business.Interfaces
{
    public interface IVoltLevelService
    {
        public Task<List<Substation>> GetVoltLevels(int branchId, int voltLevel);
        public Task<List<BranchVoltLevelData>> GetVoltLevelData(int branchId, int voltLevel);
    }
}
