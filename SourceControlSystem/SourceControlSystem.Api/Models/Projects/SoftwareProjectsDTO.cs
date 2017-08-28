using SourceControlSystem.Api.Infrastructors.Mapping;
using SourceControlSystem.Models;
using System;
using AutoMapper.Configuration;
using AutoMapper;

namespace SourceControlSystem.Api.Models.Projects
{
    public class SoftwareProjectsDTO : IMapFrom<SoftwareProject>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }

        public void CreateMappings(MapperConfigurationExpression config)
        {
            config.CreateMap<SoftwareProject, SoftwareProjectsDTO>()
                .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count));
        }

        public void CreateMappings(Action<Action<IMapperConfigurationExpression>> initialize)
        {
            initialize(cfg=>cfg.CreateMap<SoftwareProject,SoftwareProjectsDTO>()
                .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count)));
        }
    }
}