using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanningRZA.Business.Interfaces;
using PlanningRZA.Models;
using PlanningRZA.Web.ViewModels.TreeControllerViewModels;

namespace PlanningRZA.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeController : ControllerBase
    {
        IMapper _mapper;
        IBranchService _branchService;
        ISubstationService _substationService;
        IVoltLevelService _voltLevelService;
        public TreeController(IMapper mapper, 
            IBranchService branchService, 
            ISubstationService substationService, 
            IVoltLevelService voltLevelService)
        {
            _mapper = mapper;
            _branchService = branchService;
            _voltLevelService = voltLevelService;
            _substationService = substationService;
        }

        [HttpGet("[action]")] //Tree/GetBranches
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _branchService.GetBranches();
            var toReturn = _mapper.Map<List<TreeDataViewModel>>(branches);
            return Ok(toReturn);
        }

        [HttpGet("[action]/branch/{branchId}")] //Tree/GetVoltLevels/branch/1
        public async Task<IActionResult> GetVoltLevels(int branchId)
        {
            var voltLevels = await _branchService.GetVoltLevels(branchId);
            var toReturn = _mapper.Map<List<TreeDataViewModel>>(voltLevels);
            return Ok(toReturn);
        }

        [HttpGet("[action]/branch/{branchId}/voltLevel/{voltLevel}")] //tree/GetSubstations/branch/1/voltLevel/1
        public async Task<IActionResult> GetSubstations(int branchId, int voltLevel)
        {
            var substations = await _voltLevelService.GetVoltLevels(branchId,voltLevel);
            var toReturn = _mapper.Map<List<TreeDataViewModel>>(substations);
            return Ok(toReturn);
        }
    }
}
