using System.Web.Mvc;
using Chessie.ErrorHandling.CSharp;
using RailwayOrientedProgramming.DAL;

namespace RailwayOrientedProgramming.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var person = new Person();
            var result = PersonContext.Validate(person); // Error "Too old!"

            var view = result.Either(
                (msgs, p) => View(),
                (msgs) =>
                {
                    ViewBag.Issues = msgs.ToString();
                    return View();
                }
                );

            return view;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}