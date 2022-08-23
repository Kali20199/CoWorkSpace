using AutoMapper;
using CoWorkSpace.Application.Dtos;
using CoWorkSpace.Auth;
using CoWorkSpace.Databse;
using CoWorkSpace.Interfaces;
using CoWorkSpace.Model;
using CoWorkSpace.Model.CoworkSpace;

using CoWorkSpace.Model.OwnerModel.OwnerModel;

namespace CoWorkSpace.Mapping
{
    public class Mapper : Profile
    {
        public  Mapper ()
        {
            CreateMap<RegisterModel, Appuser>()
            .ForMember(x => x.Phone, o => o.MapFrom(u => u.Phone))
            .ReverseMap();


            CreateMap<CoworkSpaceDto, CoworkSpace>().ForMember(o => o.CoworkSpaceId, u => u.Ignore())
            .ReverseMap();

            CreateMap<ImageDto, Image>().ReverseMap();

            CreateMap<CoworkSpace, Create_Cowork_Model>().ForMember(o => o.location, u => u.Ignore())
          .ReverseMap();

            CreateMap< CoworkSpace,SpaceCardModel>()
            .ForMember(x => x.Id, o => o.MapFrom(u => u.CoworkSpaceId))
            .ForMember(x => x.Name, o => o.MapFrom(u => u.name))
             .ForMember(x => x.MainImage, o => o.MapFrom(u => u.Images.FirstOrDefault(x=>x.IsMain)!.Url))
            .ForMember(x => x.TimeClosed, o => o.MapFrom(u => u.TimeClosed))
            .ReverseMap();

         

         


            //  CreateMap<CoworkSpaceDto,CoworkGeoLocation>().ForMember(o=>o.CoWork,u=>u.Ignore()).ReverseMap();



        }
    }
}