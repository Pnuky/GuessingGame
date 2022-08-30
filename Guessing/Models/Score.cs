using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing.Models
{
    public class Score
    {
        public Score(Guid sessionId)
        { 
            SessionId = sessionId;
            GameStart = DateTime.Now;
        }

        public Guid SessionId { get; set; }
        public int GuessingTimes { get; set; }
        public DateTime GameStart { get; set; } 

        public double GameTimeCalc()
        {
            var calctime = (DateTime.Now - GameStart).TotalSeconds;

            return calctime;
        }

    }
}
