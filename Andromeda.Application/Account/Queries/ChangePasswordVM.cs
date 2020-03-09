using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andromeda.Application.Account.Queries
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Old password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "Confirm password not match")]
        public string ConfirmPassword { get; set; }
    }
}
