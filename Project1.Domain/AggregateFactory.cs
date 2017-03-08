using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Persistence;
using Project1.Common;

namespace Project1.Domain
{
    public class AggregateFactory : IConstructAggregates
    {
        public IAggregate Build(Type type, Guid id, IMemento snapshot)
        {
            ConstructorInfo constructor = type.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(NonEmptyIdentity) }, null);

            return constructor.Invoke(new object[] { new NonEmptyIdentity(id) }) as IAggregate;
        }
    }
}
