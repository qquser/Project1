using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models.Workshop
{
    public class RenameWorkshopModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}
