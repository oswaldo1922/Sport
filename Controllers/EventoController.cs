using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportBarca.Models;

namespace SportBarca.Controllers
{
    public class EventoController : Controller
    {
        // GET: EventoController
        public ActionResult Index()
        {
            return View(new Evento().GetEventos());
        }

        // GET: EventoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Evento person)
        {
            try
            {
                person.AddEvento(person);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Ocurrio un error" + e.Message;
                return View();
            }
        }

        // GET: EventoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new Evento().GetEventoById(id));
        }

        // POST: EventoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Evento person)
        {
            try
            {
                person.EditEvento(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new Evento().GetEventoById(id));
        }

        // POST: EventoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new Evento().EliminarEvento(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
