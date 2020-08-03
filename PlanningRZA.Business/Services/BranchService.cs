using PlanningRZA.DBRepository.Interfaces;
using PlanningRZA.Models;
using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System.Linq;
using PlanningRZA.Business.Models;
using PlanningRZA.Business.Interfaces;
using PlanningRZA.Models.Extensions;

namespace PlanningRZA.Business.Services
{
    public class BranchService:IBranchService
    {
        private IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<Branch>> GetBranches()
        {
            return await _branchRepository.GetAllBranches();
        }

        public async Task<List<BranchVoltLevel>> GetVoltLevels(int branchId)
        {
            var deepBranch = await _branchRepository.GetBranch(branchId, true);

            return deepBranch.Substations
                .GroupBy(x => x.VoltageLevel)
                .OrderBy(x => x.Key)
                .Select(x => x.Key)
                .Distinct()
                .Select(x => new BranchVoltLevel { VoltLevel = x, BranchId = branchId })
                .ToList();
        }

        public async Task<List<Substation>> GetSubstationsLevels(int branchId, int voltLevel)
        {
            var deepBranch = await _branchRepository.GetBranch(branchId, true);

            return deepBranch.Substations
                .Where(x => x.VoltageLevel == (VoltLevel)voltLevel)
                .ToList();
        }

        public async Task<List<BranchData>> GetBranchData(int branchId)
        {
            var deepBranch = await _branchRepository.GetBranch(branchId, true);

            return deepBranch
                .Substations
                .GroupBy(x => x.VoltageLevel)
                .OrderBy(x => x.Key)
                .Select(x => new BranchData
                {
                    Id = (int)x.Key,
                    Name = x.Key.GetDescription(),
                    Count = x.Count()
                })
                .ToList();
        }

        public async Task<string> GetBranchName(int branchId)
        {
            var branch = await _branchRepository.GetBranch(branchId);
            return branch.Name;
        }
    }
}
