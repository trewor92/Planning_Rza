using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlanningRZA.Business.Models;
using PlanningRZA.Models;
using PlanningRZA.Models.Enums;
using PlanningRZA.Models.Extensions;
using PlanningRZA.Web.Controllers;
using PlanningRZA.Web.ViewModels.TableControllerViewModels;
using PlanningRZA.Web.ViewModels.TreeControllerViewModels;

namespace PlanningRZA.Web.Infrastructure
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<Branch, TreeDataViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"/branch/{src.Id}"))
                .ForMember(dest => dest.ChildMethod, opt => opt.MapFrom(src=>nameof(TreeController.GetVoltLevels)))
                .ForMember(dest => dest.IsFolder, opt => opt.MapFrom(src=>true))
                .ForMember(dest => dest.IsRoot, opt => opt.MapFrom(src=>true));

            CreateMap<BranchVoltLevel, TreeDataViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"/branch/{src.BranchId}/voltLevel/{(int)src.VoltLevel}"))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VoltLevel.GetDescription()))
                .ForMember(dest => dest.ChildMethod, opt => opt.MapFrom(src => nameof(TreeController.GetSubstations)))
                .ForMember(dest => dest.IsFolder, opt => opt.MapFrom(src => true));

            CreateMap<Substation, TreeDataViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"/substation/{src.Id}"));

            CreateMap<BranchData, BranchDataViewModel>();
            CreateMap<BranchVoltLevelData, BranchVoltLevelDataViewModel>();

            CreateMap<EquipmentData, EquipmentDataViewModel>()
                .ForMember(dest => dest.PrimaryVoltage, opt => opt.MapFrom(src => src.PrimaryVoltage.GetDescription()));
             
        }
    }
}
