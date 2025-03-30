using Microsoft.AspNetCore.Mvc;
using Grades.Models;

namespace Grades.Controllers
{
    public class SubjectsController : Controller
    {
        // Usamos la lista DefaultSubjects del modelo Subject
        private static List<Subject> _subjects => Subject.DefaultSubjects;

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View(); // Devuelve la vista para crear un nuevo subject
        }

        // POST: Subjects/Create
        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                // Encuentra el próximo ID disponible
                int nextId = 1;
                while (_subjects.Any(s => s.Id == nextId))
                {
                    nextId++;
                }

                // Asigna el próximo ID disponible
                subject.Id = nextId;

                // Agrega el subject a la lista _subjects (que es DefaultSubjects)
                _subjects.Add(subject);

                return RedirectToAction("Index", "Home"); // Redirige al Index de Home
            }
            return View(subject); // Si el modelo no es válido, muestra la vista de nuevo con errores
        }

        // GET: Subjects/Edit
        public IActionResult Edit(int id)
        {
            var subject = _subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra el subject
            }
            return View(subject); // Devuelve la vista para editar el subject
        }

        // POST: Subjects/Edit
        [HttpPost]
        public IActionResult Edit(int id, Subject updatedSubject)
        {
            var subject = _subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra el subject
            }

            if (ModelState.IsValid)
            {
                // Actualiza el nombre del subject en la lista _subjects (que es DefaultSubjects)
                subject.Name = updatedSubject.Name;

                return RedirectToAction("Index", "Home"); // Redirige al Index de Home
            }
            return View(updatedSubject); // Si el modelo no es válido, muestra la vista de nuevo con errores
        }

        // GET: Subjects/Delete
        public IActionResult Delete(int id)
        {
            var subject = _subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra el subject
            }
            return View(subject); // Devuelve la vista para confirmar la eliminación
        }

        // POST: Subjects/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var subject = _subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null)
            {
                // Elimina el subject de la lista _subjects (que es DefaultSubjects)
                _subjects.Remove(subject);
            }
            return RedirectToAction("Index", "Home"); // Redirige al Index de Home
        }
    }
}