using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Common.Commands.Workshop
{
    public interface IAddWorkshop : ICommand
    {
        Guid Id { get; }

        string Name { get; }

        Guid CityId { get; }
    }
}
