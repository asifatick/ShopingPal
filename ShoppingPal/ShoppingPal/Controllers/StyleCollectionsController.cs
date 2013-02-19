using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class StyleCollectionsController : Controller
    {
		private readonly IStyleCollectionRepository stylecollectionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public StyleCollectionsController() : this(new StyleCollectionRepository())
        {
        }

        public StyleCollectionsController(IStyleCollectionRepository stylecollectionRepository)
        {
			this.stylecollectionRepository = stylecollectionRepository;
        }

        //
        // GET: /StyleCollections/

        public ViewResult Index()
        {
            return View(stylecollectionRepository.All);
        }

        //
        // GET: /StyleCollections/Details/5

        public ViewResult Details(int id)
        {
            return View(stylecollectionRepository.Find(id));
        }

        //
        // GET: /StyleCollections/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /StyleCollections/Create

        [HttpPost]
        public ActionResult Create(StyleCollection stylecollection)
        {
            if (ModelState.IsValid) {
                stylecollectionRepository.InsertOrUpdate(stylecollection);
                stylecollectionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /StyleCollections/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(stylecollectionRepository.Find(id));
        }

        //
        // POST: /StyleCollections/Edit/5

        [HttpPost]
        public ActionResult Edit(StyleCollection stylecollection)
        {
            if (ModelState.IsValid) {
                stylecollectionRepository.InsertOrUpdate(stylecollection);
                stylecollectionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /StyleCollections/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(stylecollectionRepository.Find(id));
        }

        //
        // POST: /StyleCollections/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            stylecollectionRepository.Delete(id);
            stylecollectionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                stylecollectionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

