using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SportBarca.Models;

namespace SportBarca.Controllers
{
    public class InscripcionController : Controller
    {
        // GET: InscripcionController
        public ActionResult Index()
        {
            return View(new Inscripcion().GetInscripciones());
        }

        // GET: InscripcionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InscripcionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InscripcionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Inscripcion person)
        {
            try
            {
                person.AddInscripcion(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscripcionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Inscripcion().GetInscripcionById(id));
        }

        // POST: InscripcionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Inscripcion person)
        {
            try
            {
                person.EditInscripcion(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscripcionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Inscripcion().GetInscripcionById(id));
        }

        // POST: InscripcionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new Inscripcion().EliminarInscripcion(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
