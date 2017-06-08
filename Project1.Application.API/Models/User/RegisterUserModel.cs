using Project1.Application.API.Bus;
using Project1.Application.API.Controllers;
using Project1.Common.Queries.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models.User
{
    public class RegisterUserModel : IEmailShouldNotExistModel, IConfirmPasswordCheckModel, IAllowedForEveryoneModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
