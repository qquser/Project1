using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common
{
    public class NonEmptyIdentity : ValueObject<Guid>
    {
        public NonEmptyIdentity(Guid id) : base(id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }
        }
    }
}
