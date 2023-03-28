using AutoMapper;
using EventManager.API.Models.Events;
using EventManager.BLL.DTOs.Events;

namespace EventManager.API.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateEventRequestModel, CreateEventRequestDTO>();
            CreateMap<EventResponseDTO, EventResponseModel>();
        }
    }
}