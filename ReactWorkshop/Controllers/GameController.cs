using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactWorkshop.Models;

namespace ReactWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public GameController(ApplicationContext context)
        {
            _context = context;
        }

        // POST: api/game
        [HttpPost]
        public CreateGameViewModel Post() { 
            var publicId = Guid.NewGuid().ToString();
            var answer = new Random().Next(10);
            _context.Add(new GameModel() { PublicId = publicId, Answer = answer });
            _context.SaveChanges();
            return new CreateGameViewModel() { GameId = publicId };
        }
    }
}
