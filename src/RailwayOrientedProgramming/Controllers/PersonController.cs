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
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create() => View(new PersonModel());


        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            var result = PersonContext.Add(model.ToPerson());
            var view = result.Either(
                            (msgs, p) => View(),
                            (msgs) =>
                            {
                                model.Messages = msgs.ToList();
                                return View(model);
                            }
                            );

            return view;
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
