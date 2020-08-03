using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanningRZA.Business.Interfaces;
using PlanningRZA.Business.Models;
using PlanningRZA.Models.Enums;
using PlanningRZA.Models.Extensions;
using PlanningRZA.Web.Extensions;
using PlanningRZA.Web.ViewModels.TableControllerViewModels;

namespace PlanningRZA.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        IMapper _mapper;
        IBranchService _branchService;
        ISubstationService _substationService;
        IVoltLevelService _voltLevelService;

        public TableController(IMapper mapper, IBranchService branchService, ISubstationService substationService, IVoltLevelService voltLevelService)
        {
            _mapper = mapper;
            _branchService = branchService;
            _voltLevelService = voltLevelService;
            _substationService = substationService;
        }

        [HttpGet("branch/{branchId}")] //Table/branch/1
        public async Task<IActionResult> GetBranchesData(int branchId)
        {
            var branchesData = await _branchService.GetBranchData(branchId);
            var branchesDataViewModel = _mapper.Map<List<BranchDataViewModel>>(branchesData);
            var branchName = await _branchService.GetBranchName(branchId);
            var toReturn = new TableDataViewModel<BranchDataViewModel>()
            {
                Header = typeof(BranchDataViewModel).GetPropertiesDescription().ToDictionary(x => x.Key, x => x.Value),
                Data = branchesDataViewModel,
                Name = $"Классы напряжений филиала {branchName}"
            };
           
            return Ok(toReturn);
        }

        [HttpGet("branch/{branchId}/voltLevel/{voltLevelId}")] //Table/branch/1/voltLevel/3
        public async Task<IActionResult> GetBranchesData(int branchId, int voltLevelId)
        {
            var branchVoltLevelData = await _voltLevelService.GetVoltLevelData(branchId, voltLevelId);
            var branchesVoltLevelDataViewModel = _mapper.Map<List<BranchVoltLevelDataViewModel>>(branchVoltLevelData);
            var branchName = await _branchService.GetBranchName(branchId);
            var voltLevelName = ((VoltLevel)voltLevelId).GetDescription();
            var toReturn = new TableDataViewModel<BranchVoltLevelDataViewModel>()
            {
                Header = typeof(BranchVoltLevelDataViewModel).GetPropertiesDescription().ToDictionary(x => x.Key, x => x.Value),
                Data = branchesVoltLevelDataViewModel,
                Name = $"Список подстанций {voltLevelName} филиала {branchName}"
            };
            return Ok(toReturn);
        }

        [HttpGet("substation/{substationId}")] //substation/1
        public async Task<IActionResult> GetSubstationData(int substationId)
        {
            var substationData = await _substationService.GetSubstationData(substationId);
            var substationDataViewModel = _mapper.Map<List<EquipmentDataViewModel>>(substationData);
            var substationName = await _substationService.GetSubstationName(substationId);
            var toReturn = new TableDataViewModel<EquipmentDataViewModel>()
            {
                Header = typeof(EquipmentDataViewModel).GetPropertiesDescription().ToDictionary(x => x.Key, x => x.Value),
                Data = substationDataViewModel,
                Name = $"Перечень оборудования {substationName}"
            };

            return Ok(toReturn);
        }
    }
}