using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.City.Service
{
    public interface ICityService : IDomainService
    {
        void Add(Guid id, string name);
        void Rename(Guid id, string newName);
        void MakeInActive(Guid id);
    }
}
