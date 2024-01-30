using Microsoft.EntityFrameworkCore;

namespace BoardGame.Models
{
  public class BoardGameContext : DbContext
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Game> Games { get; set; }

    public BoardGameContext(DbContextOptions options) : base(options) { }
  }
}