using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;

namespace MeetupAPI.Profiles
{
    public class MeetupProfile : Profile
    {
        public MeetupProfile()
        {
            CreateMap<MeetupModel, Meetup>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Plan, opt => opt.MapFrom(src => src.Plan))
                .ForMember(dst => dst.Organizer, opt => opt.MapFrom(src => src.Organizer))
                .ForMember(dst => dst.Speaker, opt => opt.MapFrom(src => src.Speaker))
                .ForMember(dst => dst.Time, opt => opt.MapFrom(src => src.Time));
        }
    }
}
