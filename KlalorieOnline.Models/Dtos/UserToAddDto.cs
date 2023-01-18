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
       
        [StringLength(10, MinimumLength = 3)]
        [Required(ErrorMessage = "Login must be at least 3 characters in length")]
      
        public string UserName { get; set; }
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
