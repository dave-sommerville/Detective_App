using Microsoft.AspNetCore.Mvc;
using Detective_App.Models;

namespace Detective_App.Controllers
{
    public class SuspectController : Controller
    {
        private static List<Suspect> _suspect = new List<Suspect>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_suspect);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Suspect suspect)
        {
            if (ModelState.IsValid)
            {
                suspect.SuspectID = _nextId++;
                _suspect.Add(suspect);
                return RedirectToAction("Index");
            }
            return View(suspect);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Suspect suspect = _suspect.FirstOrDefault(s => s.SuspectID == id);
            if (suspect == null)
            {
                return NotFound(); // This is just for if there is no suspect at all
            }
            return View(suspect);
        }

        [HttpPost]
        public IActionResult Edit(int id, Suspect updatedSuspect)
        {
            if (ModelState.IsValid)
            {
                Suspect existingSuspect = _suspect.FirstOrDefault(s => s.SuspectID == id);
                if (existingSuspect == null)
                {
                    return NotFound();
                }
                existingSuspect.SuspectFirstName = updatedSuspect.SuspectFirstName;
                existingSuspect.SuspectLastName = updatedSuspect.SuspectLastName;
                existingSuspect.KnownAliases = updatedSuspect.KnownAliases;
                existingSuspect.PhysicalDescription = updatedSuspect.PhysicalDescription;
                existingSuspect.Motive = updatedSuspect.Motive;
                existingSuspect.Alibi = updatedSuspect.Alibi;

                return RedirectToAction("Index");
            }
            return View(updatedSuspect);
        }
        public IActionResult Delete(int id)
        {
            Suspect sus = _suspect.FirstOrDefault(s => s.SuspectID == id);
            if (sus != null)
            {
                _suspect.Remove(sus);
            }
            return RedirectToAction("Index");
        }

    }
}
