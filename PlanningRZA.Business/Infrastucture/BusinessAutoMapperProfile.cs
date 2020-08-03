using AutoMapper;
using PlanningRZA.Business.Models;
using PlanningRZA.Models.Equipments;


namespace PlanningRZA.Web.Infrastructure
{
    public class BusinessAutoMapperProfile : Profile
    {
        public BusinessAutoMapperProfile()
        {
            CreateMap<Equipment, EquipmentData>();
        }
    }
}
