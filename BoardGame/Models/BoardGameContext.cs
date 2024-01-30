using Microsoft.EntityFrameworkCore;

namespace BoardGame.Models
{
  public class BoardGameContext : DbContext
  {
    public DbSet<Game> Games { get; set; }

    public BoardGameContext(DbContextOptions options) : base(options) { }
  }
}