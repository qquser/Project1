using System.Linq;
using AutoMapper;
using Project1.ReadSide.Models;
using Project1.Common.DTO;

namespace Project1.ReadSide
{
    internal static class MapConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerModel, CustomerDTO>()
                   .ForMember(s => s.ProjectIds, opt => opt.MapFrom(src => src.Projects.Select(x => x.AggregateId)))
                   .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId));
                c.CreateMap<ProjectModel, ProjectDTO>()
                    .ForMember(s => s.CustomerId, opt => opt.MapFrom(src => src.CustomerModel.AggregateId))
                    //.ForMember(s => s.AssignedUsersIds,
                    //    opt => opt.MapFrom(src => src.AssignedUsers.Select(x => x.AggregateId)))
                    .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId));

                c.CreateMap<UserModel, UserDTO>()
                    .ForMember(s => s.RoleId, opt => opt.MapFrom(src => src.RoleModel.AggregateId))
                    .ForMember(s => s.RoleName, opt => opt.MapFrom(src => src.RoleModel.Name))
                    .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId));

                c.CreateMap<CityModel, CityDTO>()
                  .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId));

                c.CreateMap<WorkshopModel, WorkshopDTO>()
                   .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId))
                   .ForMember(s => s.JobIds,
                       opt => opt.MapFrom(src => src.Jobs.Select(x => x.AggregateId)))
                   .ForMember(s => s.CityId, opt => opt.MapFrom(src => src.CityModel.AggregateId));

                c.CreateMap<JobModel, JobDTO>()
                   .ForMember(s => s.Id, opt => opt.MapFrom(src => src.AggregateId))
                   .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Description))
                   .ForMember(s => s.WorkshopId, opt => opt.MapFrom(src => src.WorkshopModel.AggregateId))
                   .ForMember(s => s.UserId, opt => opt.MapFrom(src => src.UserModel.AggregateId));

            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}