using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
            .ForMember(dest => dest.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));
            CreateMap<ActivityAttendee, Profiles.Profile>()
            .ForMember(dest => dest.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(dest => dest.UserName, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(dest => dest.Bio, o => o.MapFrom(s => s.AppUser.Bio));
        }
    }
}