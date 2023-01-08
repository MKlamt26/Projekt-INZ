using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlalorieOnline.Models.Dtos
{
    public class TreningCartItemDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ExerciseId { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        
    }
}
