using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class CitiesController : Controller
    {
		private readonly ICityRepository cityRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CitiesController() : this(new CityRepository())
        {
        }

        public CitiesController(ICityRepository cityRepository)
        {
			this.cityRepository = cityRepository;
        }

        //
        // GET: /Cities/

        public ViewResult Index()
        {
            return View(cityRepository.All);
        }

        //
        // GET: /Cities/Details/5

        public ViewResult Details(int id)
        {
            return View(cityRepository.Find(id));
        }

        //
        // GET: /Cities/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cities/Create

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid) {
                cityRepository.InsertOrUpdate(city);
                cityRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Cities/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(cityRepository.Find(id));
        }

        //
        // POST: /Cities/Edit/5

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid) {
                cityRepository.InsertOrUpdate(city);
                cityRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Cities/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(cityRepository.Find(id));
        }

        //
        // POST: /Cities/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            cityRepository.Delete(id);
            cityRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                cityRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

