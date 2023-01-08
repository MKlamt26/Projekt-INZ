using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlalorieOnline.Models.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
