using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlalorieOnline.Models.Dtos
{
    public class UserDataDto
    {
        
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Activity { get; set; }
        public string Goal { get; set; }

    }

 
}
