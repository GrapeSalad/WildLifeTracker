using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WildLifeTracker.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WildLifeTracker.Controllers
{

    public class HomeController : Controller
    {
        private WildlifeTrackerContext db = new WildlifeTrackerContext();
        // GET: /<controller>/
        public IActionResult Index()
        { 
            return View(db.Species.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.speciesId == id);
            return View(thisSpecies);
        }
        public IActionResult Create()
        {
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
            var thisSpecies = db.Species.FirstOrDefault(species => species.speciesId == id);
            return View(thisSpecies);
        }

        [HttpPost]
        public IActionResult Edit(Species species)
        {
            db.Entry(species).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.speciesId == id);
            return View(thisSpecies);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisSpecies = db.Species.FirstOrDefault(species => species.speciesId == id);
            db.Species.Remove(thisSpecies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
