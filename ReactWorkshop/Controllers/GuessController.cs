using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactWorkshop.Models;

namespace ReactWorkshop.Controllers
{
    [Route("api/[controller]/{gameId}/{guess}")]
    [ApiController]
    public class GuessController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public GuessController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public GuessViewModel Get(string gameId, int guess)
        {
            var game = _context.Games.Where(g => g.PublicId == gameId).FirstOrDefault();

            if (game == null)
            {
                return new GuessViewModel() { Correct = false };
            }

            return new GuessViewModel() { Correct = game.Answer == guess };
        }
    }
}
