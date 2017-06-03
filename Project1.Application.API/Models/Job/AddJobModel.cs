using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models.Job
{
    public class AddJobModel
    {
        public Guid CommandId { get; set; }
        [Required]
        public Guid JobId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid WorkshopId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
