using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class WDItemsController : Controller
    {
		private readonly IUserRepository userRepository;
		private readonly IWDItemRepository wditemRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public WDItemsController() : this(new UserRepository(), new WDItemRepository())
        {
        }

        public WDItemsController(IUserRepository userRepository, IWDItemRepository wditemRepository)
        {
			this.userRepository = userRepository;
			this.wditemRepository = wditemRepository;
        }

        //
        // GET: /WDItems/

        public ViewResult Index()
        {
            return View(wditemRepository.AllIncluding(wditem => wditem.User));
        }

        //
        // GET: /WDItems/Details/5

        public ViewResult Details(int id)
        {
            return View(wditemRepository.Find(id));
        }

        //
        // GET: /WDItems/Create

        public ActionResult Create()
        {
			ViewBag.PossibleUsers = userRepository.All;
            return View();
        } 

        //
        // POST: /WDItems/Create

        [HttpPost]
        public ActionResult Create(WDItem wditem)
        {
            if (ModelState.IsValid) {
                wditemRepository.InsertOrUpdate(wditem);
                wditemRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleUsers = userRepository.All;
				return View();
			}
        }
        
        //
        // GET: /WDItems/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleUsers = userRepository.All;
             return View(wditemRepository.Find(id));
        }

        //
        // POST: /WDItems/Edit/5

        [HttpPost]
        public ActionResult Edit(WDItem wditem)
        {
            if (ModelState.IsValid) {
                wditemRepository.InsertOrUpdate(wditem);
                wditemRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleUsers = userRepository.All;
				return View();
			}
        }

        //
        // GET: /WDItems/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(wditemRepository.Find(id));
        }

        //
        // POST: /WDItems/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            wditemRepository.Delete(id);
            wditemRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                userRepository.Dispose();
                wditemRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

