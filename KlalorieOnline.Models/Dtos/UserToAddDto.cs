using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlalorieOnline.Models.Dtos
{
    public class UserAddDto
    {

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Login must be between 3 and 10 characters")]

        public string? UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 10 characters")]
        public string? UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
