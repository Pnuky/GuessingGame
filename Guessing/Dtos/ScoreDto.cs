using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing.Dtos
{
    public class ScoreDto
    {   
        public Guid SessionId { get; set; }
        public int GuessingTimes { get; set; }
        public double PlayTime { get; set; }

    }
}
