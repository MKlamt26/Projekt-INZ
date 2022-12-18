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
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
