using System.Linq;
using System.Web.Mvc;
using Chessie.ErrorHandling.CSharp;
using RailwayOrientedProgramming.DAL;
using RailwayOrientedProgramming.Models;

namespace RailwayOrientedProgramming.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var model = PersonContext.People.Select(p => new PersonModel { Email = p.Email, FirstName = p.FirstName, LastName = p.LastName });
            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create() => View(new PersonModel());

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            var result = PersonContext.Add(model.ToPerson());
            // Pattern Matching!!!
            return result.Either(
                            (msgs, p) => RedirectToAction("Index"),
                            (msgs) =>
                            {
                                model.Messages = msgs.ToList();
                                return (ActionResult)View(model);
                            }
                            );
        }

        // GET: Person/Create
        public ActionResult CreateImperative() => View(new PersonModel());

        [HttpPost]
        public ActionResult CreateImperative(PersonModel model)
        {
            var result = ImperativePersonContext.Add(model.ToPerson());
            if (result.Successful)
            {
                return RedirectToAction("Index");
            }
            model.Messages.AddRange(result.Messages);
            return View(model);
        }

    }
}
