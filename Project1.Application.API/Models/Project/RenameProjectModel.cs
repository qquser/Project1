using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Application.API.Models.Project
{
    public class RenameProjectModel : IModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}