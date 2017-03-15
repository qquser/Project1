using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Interfaces
{
    internal interface IModelConfiguration<TEntity> where TEntity : BaseModel
    {
        void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
