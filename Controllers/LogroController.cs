using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportBarca.Models;

namespace SportBarca.Controllers
{
    public class LogroController : Controller
    {
        // GET: LogroController
        public ActionResult Index()
        {
            return View(new Logro().GetLogros());
        }

        // GET: LogroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Logro person)
        {
            try
            {
                person.AddLogro(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Logro().GetLogroById(id));
        }

        // POST: LogroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Logro person)
        {
            try
            {
                person.EditLogro(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LogroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Logro().GetLogroById(id));
        }

        // POST: LogroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new Logro().EliminarLogro(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
