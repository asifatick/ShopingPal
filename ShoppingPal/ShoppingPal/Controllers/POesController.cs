using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class POesController : Controller
    {
		private readonly IPORepository poRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public POesController() : this(new PORepository())
        {
        }

        public POesController(IPORepository poRepository)
        {
			this.poRepository = poRepository;
        }

        //
        // GET: /POes/

        public ViewResult Index()
        {
            return View(poRepository.All);
        }

        //
        // GET: /POes/Details/5

        public ViewResult Details(int id)
        {
            return View(poRepository.Find(id));
        }

        //
        // GET: /POes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /POes/Create

        [HttpPost]
        public ActionResult Create(PO po)
        {
            if (ModelState.IsValid) {
                poRepository.InsertOrUpdate(po);
                poRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /POes/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(poRepository.Find(id));
        }

        //
        // POST: /POes/Edit/5

        [HttpPost]
        public ActionResult Edit(PO po)
        {
            if (ModelState.IsValid) {
                poRepository.InsertOrUpdate(po);
                poRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /POes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(poRepository.Find(id));
        }

        //
        // POST: /POes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            poRepository.Delete(id);
            poRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                poRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

