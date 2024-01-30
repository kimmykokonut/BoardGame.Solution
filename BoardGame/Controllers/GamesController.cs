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

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game)
    {
      _db.Games.Add(game);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    public ActionResult Edit(int id)
    {
      Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game)
    {
      _db.Games.Update(game);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}