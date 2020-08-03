using PlanningRZA.Business.Models;
using PlanningRZA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.Business.Interfaces
{
    public interface IBranchService
    {
        public Task<List<Branch>> GetBranches();
        public Task<List<BranchVoltLevel>> GetVoltLevels(int branchId);

        public Task<List<BranchData>> GetBranchData(int branchId);

        public Task<string> GetBranchName(int branchId);

    }
}
