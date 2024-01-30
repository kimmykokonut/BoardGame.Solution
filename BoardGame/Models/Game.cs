namespace BoardGame.Models 
{
  public class Game
  {
    public int GameId { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; } //reference navigation property
  }
}