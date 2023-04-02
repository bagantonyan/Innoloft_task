using AutoMapper;
using EventManager.API.Models.Events;
using EventManager.API.Models.Invitations;
using EventManager.API.Models.Users;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.DTOs.Invitations;
using EventManager.BLL.DTOs.Users;

namespace EventManager.API.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateEventRequestModel, CreateEventRequestDTO>()
                .ForMember(dest => dest.Mode, src => src.MapFrom(e => e.Mode.ToString()));
            CreateMap<UserResponseDTO, UserResponseModel>();
            CreateMap<EventResponseDTO, EventResponseModel>();
            CreateMap<SendInvitationRequestModel, SendInvitationRequestDTO>();
            CreateMap<InvitationResponseDTO, InvitationResponseModel>();
        }
    }
}