using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class SettingsController : Controller
    {
		private readonly ICityRepository cityRepository;
		private readonly IPORepository poRepository;
		private readonly ISettingsRepository settingsRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public SettingsController() : this(new CityRepository(), new PORepository(), new SettingsRepository())
        {
        }

        public SettingsController(ICityRepository cityRepository, IPORepository poRepository, ISettingsRepository settingsRepository)
        {
			this.cityRepository = cityRepository;
			this.poRepository = poRepository;
			this.settingsRepository = settingsRepository;
        }

        //
        // GET: /Settings/

        public ViewResult Index()
        {
            return View(settingsRepository.All);
        }

        //
        // GET: /Settings/Details/5

        public ViewResult Details(long id)
        {
            return View(settingsRepository.Find(id));
        }

        //
        // GET: /Settings/Create

        public ActionResult Create()
        {
			ViewBag.PossibleCities = cityRepository.All;
			ViewBag.PossiblePOes = poRepository.All;
            return View();
        } 

        //
        // POST: /Settings/Create

        [HttpPost]
        public ActionResult Create(Settings settings)
        {
            if (ModelState.IsValid) {
                settingsRepository.InsertOrUpdate(settings);
                settingsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCities = cityRepository.All;
				ViewBag.PossiblePOes = poRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Settings/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleCities = cityRepository.All;
			ViewBag.PossiblePOes = poRepository.All;
             return View(settingsRepository.Find(id));
        }

        //
        // POST: /Settings/Edit/5

        [HttpPost]
        public ActionResult Edit(Settings settings)
        {
            if (ModelState.IsValid) {
                settingsRepository.InsertOrUpdate(settings);
                settingsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCities = cityRepository.All;
				ViewBag.PossiblePOes = poRepository.All;
				return View();
			}
        }

        //
        // GET: /Settings/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(settingsRepository.Find(id));
        }

        //
        // POST: /Settings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            settingsRepository.Delete(id);
            settingsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                cityRepository.Dispose();
                poRepository.Dispose();
                settingsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

