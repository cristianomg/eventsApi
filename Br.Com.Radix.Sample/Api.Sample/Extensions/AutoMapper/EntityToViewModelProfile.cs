using Api.Sample.Dtos;
using AutoMapper;
using Domain.Core.Entities;

namespace Api.Sample.Extensions.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<Event, DtoEvent>();
        }
    }
}
