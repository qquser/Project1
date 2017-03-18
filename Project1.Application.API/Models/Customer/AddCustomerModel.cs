using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Application.API.Models.Customer
{
    public class AddCustomerModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}