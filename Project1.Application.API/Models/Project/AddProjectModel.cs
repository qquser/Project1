using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Application.API.Models.Project
{
    public class AddProjectModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }
}