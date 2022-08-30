using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing.Dtos
{
    public class GuessDto
    {
        public Guid SessionId { get; set; }
        public int Number { get; set; }
        

    }

}
