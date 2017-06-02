using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class CityModel : BaseModel
    {
        private CityModel()
        {
        }
        public CityModel(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        //public UserRole Role { get; set; }
    }
}
