using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlSystem.Api.Infrastructors.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(MapperConfigurationExpression config);
        void CreateMappings(Action<Action<IMapperConfigurationExpression>> initialize);
    }
}
