using Microsoft.AspNetCore.Mvc;

namespace BoardGame.Controllers //change name
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index() 
    {
      return View();
    }
  }
}