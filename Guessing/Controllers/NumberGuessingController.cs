using Guessing.Dtos;
using Guessing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guessing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberGuessingController : ControllerBase
    {

        private static readonly List<Score> _games = new();
        public static int _number;

        public NumberGuessingController()
        {
          
        }

        [HttpGet,Route("start")]
        public Guid Start()
        {
            var sessionId = Guid.NewGuid();
            _number = new Random().Next(1,100);
            _games.Add(new Score(sessionId));
            return sessionId;
        }

        [HttpPost, Route("guess")]
        public ActionResult<GuessResponseDto> Guess([FromBody] GuessDto guess)
        {
            var game = _games.SingleOrDefault(a => a.SessionId == guess.SessionId);

            game.GuessingTimes++;

            var result = guess.Number > _number ? "za duża" : guess.Number < _number ? "za mała" : "trafiona";

            return Ok(new GuessResponseDto
            {
                GuessingTimes = game.GuessingTimes,
                Result = result,
                SessionId = guess.SessionId

            });
        }

        public IEnumerable<ScoreDto> HighScore()
        {
            return _games.OrderByDescending(a => a.GuessingTimes)
                .Take(10)
                .Select(a => new ScoreDto
                {
                    GuessingTimes = a.GuessingTimes,
                    SessionId = a.SessionId,
                    PlayTime = a.GameTimeCalc()

                });
        }
    }
}
