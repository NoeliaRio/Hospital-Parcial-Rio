using Hospital_Parcial_Rio.Data;
using Hospital_Parcial_Rio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Parcial_Rio.Controllers
{
    public class PacientesController : Controller
    {
        public BaseDatos _DB = new BaseDatos();
        // GET: PacientesController
        public ActionResult Index()
        {
            var pacientes = _DB.ObtenerPacientes(0);

            if (pacientes == null || pacientes.Count == 0)
            {
                return View("NoPacientes");
            }

            return View(pacientes);
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            ViewBag.Obras_Sociales = _DB.ObtenerObras_Sociales(0);
            ViewBag.Sintomas = _DB.ObtenerSintomas(0);
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            string result = _DB.GuardarPaciente(paciente);

            if (string.IsNullOrEmpty(result))
                return RedirectToAction("Index");
            else
                return View("Error", result);
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
