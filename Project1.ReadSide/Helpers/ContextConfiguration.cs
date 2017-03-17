using Project1.ReadSide.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Helpers
{
    internal class ContextConfiguration<TEntity> where TEntity: BaseModel
    {
        [ImportMany(typeof(IModelConfiguration<>))]
        public IEnumerable<IModelConfiguration<TEntity>> Configurations  { get; set; }  
    }
}
