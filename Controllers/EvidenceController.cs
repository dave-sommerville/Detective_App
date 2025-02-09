using Microsoft.AspNetCore.Mvc;
using Detective_App.Models;

namespace Detective_App.Controllers
{
    public class EvidenceController : Controller
    {
            private static List<Evidence> _evidence = new List<Evidence>();
            private static int _nextId = 1;
            public IActionResult Index()
            {
                return View(_evidence);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Evidence evidence)
            {
                if (ModelState.IsValid)
                {
                    evidence.EvidenceID = _nextId++;
                    _evidence.Add(evidence);
                    return RedirectToAction("Index");
                }
                return View(evidence);
            }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Evidence evidence = _evidence.FirstOrDefault(e => e.EvidenceID == id);
            if (evidence == null)
            {
                return NotFound(); // This is just for if there is no evidence at all
            }
            return View(evidence);
        }

        // POST: Evidence/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Evidence updatedEvidence)
        {
            if (ModelState.IsValid)
            {
                Evidence existingEvidence = _evidence.FirstOrDefault(e => e.EvidenceID == id);
                if (existingEvidence == null)
                {
                    return NotFound(); 
                }
                existingEvidence.Description = updatedEvidence.Description;
                existingEvidence.DateFound = updatedEvidence.DateFound;
                return RedirectToAction("Index"); 
            }
            return View(updatedEvidence);
        }
        [HttpDelete]
            public IActionResult Delete(int id)
            {
                Evidence evi = _evidence.FirstOrDefault(d => d.EvidenceID == id);
                if (evi != null)
                {
                    _evidence.Remove(evi);
                }
                return RedirectToAction("Index");
            }

        }
    }
