using AutoMapper;
using EventManager.BLL.DTOs.Events;
using EventManager.DAL.Entities;

namespace EventManager.BLL.Mappings
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<CreateEventRequestDTO, Event>();
            CreateMap<Event, EventResponseDTO>();
        }
    }
}
