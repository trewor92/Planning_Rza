using AutoMapper;
using PlanningRZA.Business.Interfaces;
using PlanningRZA.Business.Models;
using PlanningRZA.DBRepository.Interfaces;
using PlanningRZA.Models.Equipments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningRZA.Business.Services
{
    public class SubstationService:ISubstationService
    {
        private ISubstationRepository _substationRepository;
        private IMapper _mapper;

        public SubstationService(ISubstationRepository substationRepository, IMapper mapper)
        {
            _substationRepository = substationRepository;
            _mapper = mapper;
        }

        public async Task<List<EquipmentData>> GetSubstationData(int substationId)
        {
            var deepSubstation = await _substationRepository.GetSubstation(substationId, true);
            var equipments = deepSubstation.Equipments;

            var substationData = _mapper.Map<List<EquipmentData>>(equipments);

            return substationData;
        }

        public async Task<string> GetSubstationName(int substationId)
        {
            var substation = await _substationRepository.GetSubstation(substationId);
            return substation.Name;
        }
    }
}
