using System.Collections.Generic;
using System.ComponentModel.Composition;
using Project1.ReadSide.Interfaces;

namespace Project1.ReadSide.Helpers
{
    internal class ContextConfiguration
    {
        [ImportMany(typeof(IModelConfiguration))]
        public IEnumerable<IModelConfiguration> Configurations { get; set; }
    }
}