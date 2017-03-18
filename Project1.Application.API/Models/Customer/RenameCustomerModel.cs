using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Application.API.Models.Customer
{
    public class RenameCustomerModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}