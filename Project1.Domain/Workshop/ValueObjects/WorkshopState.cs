using Project1.Common;
using Project1.Common.Enums;
using Project1.Domain.City.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Domain.Workshop.ValueObjects
{
    internal class WorkshopState
    {
        public NonEmptyIdentity Id { get; set; }
        public NonEmptyIdentity CityId { get; set; }
        public WorkshopStatus Status { get; set; }
        public WorkshopName Name { get; set; }
        public CityState CityState { get; set; }
    }
}
