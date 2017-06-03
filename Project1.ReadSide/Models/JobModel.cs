using Project1.Common.Enums;
using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class JobModel : BaseModel
    {
        private JobModel()
        {
        }

        public JobModel(Guid id) : base(id)
        {
        }
        
        public string Description { get; set; }

        public string UserId { get; set; }
        public UserModel UserModel { get; set; }

        public string CityId { get; set; }
        public CityModel CityModel { get; set; }

        public string WorkshopId { get; set; }
        public WorkshopModel WorkshopModel { get; set; }

        public JobStatus Status { get; set; }
    }
}
