using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlalorieOnline.Models.Dtos.TreningDtos
{
    public class TreningCartUpdateDto
    {
        public int TreningCartItemId { get; set; }
        public int Wight { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }

    }
}
