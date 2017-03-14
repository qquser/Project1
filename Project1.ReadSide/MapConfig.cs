using System.Linq;
using AutoMapper;

namespace Project1.ReadSide
{
    internal static class MapConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(c =>
            {

            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}