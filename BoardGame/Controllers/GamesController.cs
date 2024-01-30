using Microsoft.AspNetCore.Mvc;
using BoardGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame.Controllers
{
  public class GamesController : Controller
  {
    private readonly BoardGameContext _db;

    public GamesController(BoardGameContext db)
    {
      _db = db;
    }

    public ActionResult Index()  //shows game list at /games
    {
      List<Game> model = _db.Games.ToList();
      return View(model);
    }
  }
}