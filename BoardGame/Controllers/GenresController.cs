using Microsoft.AspNetCore.Mvc;
using BoardGame.Models; 
using System.Collections.Generic;
using System.Linq;

namespace BoardGame.Controllers
{
  public class GenresController : Controller
  {
    private readonly BoardGameContext _db;

    public GenresController(BoardGameContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Genre> model = _db.Genres.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Genre genre)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }
    [HttpPost]
    public ActionResult Edit(Genre genre)
    {
      _db.Genres.Update(genre);
      _db.SaveChanges();
      return RedirectToAction ("Index");
    }
    public ActionResult Delete(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      _db.Genres.Remove(thisGenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}