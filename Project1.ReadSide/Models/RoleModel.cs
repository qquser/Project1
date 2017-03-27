using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class RoleModel : BaseModel
    {
        private RoleModel()
        {
        }
        public RoleModel(Guid id) : base(id)
        {
        }
        public string Name { get; set; }
        public string RolePermission { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
