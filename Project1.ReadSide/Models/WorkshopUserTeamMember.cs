using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class WorkshopUserTeamMember : BaseModel
    {
        private WorkshopUserTeamMember()
        {
        }
        public WorkshopUserTeamMember(Guid id) : base(id)
        {

        }

        public string UserId { get; set; }
        public UserModel UserModel { get; set; }

        public string WorkshopId { get; set; }
        public WorkshopModel WorkshopModel { get; set; }

        public string RoleId { get; set; }
        public RoleModel RoleModel { get; set; }

    }
}
