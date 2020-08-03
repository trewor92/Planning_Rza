using PlanningRZA.Business.Interfaces;
using PlanningRZA.Business.Models;
using PlanningRZA.DBRepository.Interfaces;
using PlanningRZA.Models;
using PlanningRZA.Models.Enums;
using PlanningRZA.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.Business.Services
{
    public class VoltLevelService : IVoltLevelService
    {
        private IBranchRepository _branchRepository;
        private ISubstationRepository _substationRepository;

        public VoltLevelService(IBranchRepository branchRepository, ISubstationRepository substationRepository)
        {
            _branchRepository = branchRepository;
            _substationRepository = substationRepository;
        }

        public async Task<List<Substation>> GetVoltLevels(int branchId, int voltLevel)
        {
            var deepBranch = await _branchRepository.GetBranch(branchId, true);

            return deepBranch.Substations
                .Where(x => x.VoltageLevel == (VoltLevel)voltLevel)
                .ToList();
        }

        public async Task<List<BranchVoltLevelData>> GetVoltLevelData(int branchId, int voltLevel)
        {
            var deepBranch = await _branchRepository.GetBranch(branchId, true);

            var voltLevelSubstations = deepBranch
                 .Substations
                 .Where(x => x.VoltageLevel == (VoltLevel)voltLevel);

            var deepSubstations = await _substationRepository.GetAllSubstations(true);

            return voltLevelSubstations
                .GroupJoin(deepSubstations,x=>x.Id,y=>y.Id, (x,y)=>new BranchVoltLevelData
                {
                     Id = x.Id,
                     Name = x.Name,
                     Count = y.FirstOrDefault().Equipments.Count()
                 })
                .ToList();
        }
    }
}
