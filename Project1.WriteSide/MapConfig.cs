using AutoMapper;
using Project1.Common.DTO;
using Project1.Common.Enums;
using Project1.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.WriteSide
{
    internal static class MapConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserState, UserDTO>()
                    .ForMember(s => s.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id.ToString())))
                    .ForMember(s => s.RoleId, opt => opt.MapFrom(src => Guid.Empty))
                    .ForMember(s => s.Status, opt => opt.MapFrom(src => src.Status))
                    .ForMember(s => s.PasswordHash, opt => opt.MapFrom(src => src.UserName.PasswordHash))
                    .ForMember(s => s.Email, opt => opt.MapFrom(src => src.UserName.Email));
            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
