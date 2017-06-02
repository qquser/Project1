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
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserId { get; set; }
        public UserModel UserModel { get; set; }
    }
}
