using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportBarca.Models;

namespace SportBarca.Controllers
{
    public class DeporteController : Controller
    {
        // GET: DeporteController
        public ActionResult Index()
        {
            return View(new Deporte().GetDeportes());
        }

        // GET: DeporteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeporteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeporteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Deporte person)
        {
            try
            {
                person.AddDeporte(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeporteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Deporte().GetDeporteById(id));
        }

        // POST: DeporteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Deporte person)
        {
            try
            {
                person.EditDeporte(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeporteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Deporte().GetDeporteById(id));
        }

        // POST: DeporteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new Deporte().EliminarDeporte(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
