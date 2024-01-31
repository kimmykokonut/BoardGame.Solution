using Microsoft.AspNetCore.Mvc;
using BoardGame.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoardGame.Controllers
{
  public class GamesController : Controller
  {
    private readonly BoardGameContext _db;

    public GamesController(BoardGameContext db)
    {
      _db = db;
    }

    // public ActionResult Index()
    // {
    //   List<Game> model = _db.Games
    //                         .Include(game => game.Genre)
    //                         .ToList();
    //   return View(model);
    // }

    public async Task<IActionResult> Index(string searchString)
    {
      IQueryable<Game> model = from m in _db.Games
                              .Include(game => game.Genre)
                               select m;

      if (!String.IsNullOrEmpty(searchString))
      {
        model = model.Where(s => s.Name!.Contains(searchString));
      }
      return View(await model.ToListAsync());
    }


    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game)
    {
      if (game.GenreId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Games.Add(game);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Game thisGame = _db.Games
                          .Include(game => game.Genre)
                          .FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    public ActionResult Edit(int id)
    {
      Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game)
    {
      _db.Games.Update(game);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      _db.Games.Remove(thisGame);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}