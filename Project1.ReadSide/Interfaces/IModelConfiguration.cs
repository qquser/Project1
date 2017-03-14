using System.Data.Entity.ModelConfiguration.Configuration;

namespace Project1.ReadSide.Interfaces
{
    internal interface IModelConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}