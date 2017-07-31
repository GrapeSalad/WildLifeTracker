using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WildLifeTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WildLifeTracker.Controllers
{

    public class HomeController : Controller
    {
        private WildlifeTrackerContext db = new WildlifeTrackerContext();
        // GET: /<controller>/
        public IActionResult Index()
        { 
            return View(db.Sightings.Include(sighting => sighting.Species).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisSighting = db.Sightings.FirstOrDefault(sighting => sighting.sightingId == id);
            //var thisSighting = db.Sightings.FirstOrDefault(sighting => sighting.speciesId = id);
            return View(thisSighting);
        }
        public IActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "speciesId", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Species species)
        {
            db.Species.Add(species);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisSightings = db.Sightings.FirstOrDefault(sightings => sightings.sightingId == id);
            ViewBag.SpeciesId = new SelectList(db.Species, "speciesId", "name");
            return View(thisSightings);
        }

        [HttpPost]
        public IActionResult Edit(Sighting sightings)
        {
            db.Entry(sightings).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisSightings = db.Sightings.FirstOrDefault(sightings => sightings.sightingId == id);
            return View(thisSightings);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisSightings = db.Sightings.FirstOrDefault(sightings => sightings.sightingId == id);
            db.Sightings.Remove(thisSightings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
