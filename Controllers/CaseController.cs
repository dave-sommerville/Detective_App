using Microsoft.AspNetCore.Mvc;
using Detective_App.Models;


using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Policy;

namespace Detective_App.Controllers
{
    public class CaseController : Controller
    {
        private static List<Case> _case = new List<Case>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_case);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Case caseFile)
        {
            if (ModelState.IsValid)
            {
                caseFile.CaseId = _nextId++;
                _case.Add(caseFile);
                return RedirectToAction("Index");
            }
            return View(caseFile);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Case caseFile = _case.FirstOrDefault(e => e.CaseId == id);
            if (caseFile == null)
            {
                return NotFound(); // This is just for if there is no case at all
            }
            return View(caseFile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Case updatedCase)
        {
            if (ModelState.IsValid)
            {
                Case existingCase = _case.FirstOrDefault(e => e.CaseId == id);
                if (existingCase == null)
                {
                    return NotFound();
                }
                existingCase.Status = updatedCase.Status;
                existingCase.DateFileOpened = updatedCase.DateFileOpened;
                existingCase.CrimeSceneLocation = updatedCase.CrimeSceneLocation;
                existingCase.Notes = updatedCase.Notes;
                existingCase.Suspects = updatedCase.Suspects;
                existingCase.Evidence = updatedCase.Evidence;


                return RedirectToAction("Index");
            }
            return View(updatedCase);
        }
        public IActionResult Delete(int id)
        {
            Case ca = _case.FirstOrDefault(d => d.CaseId == id);
            if (ca != null)
            {
                _case.Remove(ca);
            }
            return RedirectToAction("Index");
        }
    }
}
