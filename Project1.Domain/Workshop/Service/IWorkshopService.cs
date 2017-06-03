using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Workshop.Service
{
    public interface IWorkshopService : IDomainService
    {
        void AddWorkshop(Guid workshopId, string name, Guid cityId);
        void MakeInActive(Guid workshopId);
        void Rename(Guid workshopId, string newName);
    }
}
