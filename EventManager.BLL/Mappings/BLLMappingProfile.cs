using AutoMapper;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.DTOs.Invitations;
using EventManager.BLL.DTOs.Users;
using EventManager.DAL.Entities;

namespace EventManager.BLL.Mappings
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<CreateEventRequestDTO, Event>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<Event, EventResponseDTO>();
            CreateMap<Invitation, InvitationResponseDTO>()
                .ForMember(dest => dest.SenderName, src => src.MapFrom(i => i.Sender.Name))
                .ForMember(dest => dest.SenderCompany, src => src.MapFrom(i => i.Sender.CompanyName))
                .ForMember(dest => dest.ReceiverName, src => src.MapFrom(i => i.Receiver.Name))
                .ForMember(dest => dest.ReceiverCompany, src => src.MapFrom(i => i.Receiver.CompanyName))
                .ForMember(dest => dest.EventTitle, src => src.MapFrom(i => i.Event.Title));
        }
    }
}
