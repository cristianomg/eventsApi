using Api.Sample.Dtos;
using AutoMapper;
using Domain.Core.Entities;

namespace Api.Sample.Extensions.AutoMapper
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<DtoInsertEvent, Event>()
                .ForMember(x => x.Country, y => y.MapFrom(src => src.GetItemFromTag(0)))
                .ForMember(x => x.Region, y => y.MapFrom(src => src.GetItemFromTag(1)))
                .ForMember(x=>x.SensorName, y=>y.MapFrom(src=> src.GetItemFromTag(2)));
        }
    }
}
