using AutoMapper;
using SourceControlSystem.Api.Infrastructors.Mapping;
using SourceControlSystem.Api.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SourceControlSystem.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(params Assembly[] assemblies)
        {

            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetExportedTypes());
            }

            LoadStandardMappings(types);
            LoadCustomMappings(types);

        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                .Where(
                    type =>
                        type.i.IsGenericType && type.i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.t.IsAbstract
                        && !type.t.IsInterface)
                .Select(type => new { Source = type.i.GetGenericArguments()[0], Destination = type.t });

            foreach (var map in maps)
            {
                Mapper.Initialize(cfg => cfg.CreateMap(map.Source, map.Destination));
                Mapper.Initialize(cfg => cfg.CreateMap(map.Destination, map.Source));
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps =
                types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                    .Where(
                        type =>
                            typeof(IHaveCustomMappings).IsAssignableFrom(type.t) && !type.t.IsAbstract &&
                            !type.t.IsInterface)
                    .Select(type => (IHaveCustomMappings)Activator.CreateInstance(type.t));

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Initialize);
            }
        }
    }
}