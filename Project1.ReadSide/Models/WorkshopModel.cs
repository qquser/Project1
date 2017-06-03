using Project1.Common.Enums;
using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class WorkshopModel : BaseModel
    {
        private WorkshopModel()
        {
        }
        public WorkshopModel(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        public string CityId { get; set; }
        public CityModel CityModel { get; set; }

        public WorkshopStatus Status { get; set; }

        public ICollection<JobModel> Jobs { get; set; }
    }
}
