using Microsoft.EntityFrameworkCore;

namespace ReactWorkshop.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<GameModel> Games { get; set; }
    }
}
