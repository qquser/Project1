using Project1.ReadSide.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Helpers
{
    internal class ContextConfiguration
    {
        [ImportMany(typeof(IModelConfiguration<>))]
        public IEnumerable<IModelConfiguration<BaseModel>> Configurations  { get; set; }
    }
}
