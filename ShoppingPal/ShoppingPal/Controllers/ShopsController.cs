using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class ShopsController : Controller
    {
		private readonly ICityRepository cityRepository;
		private readonly IPORepository poRepository;
		private readonly IShopRepository shopRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ShopsController() : this(new CityRepository(), new PORepository(), new ShopRepository())
        {
        }

        public ShopsController(ICityRepository cityRepository, IPORepository poRepository, IShopRepository shopRepository)
        {
			this.cityRepository = cityRepository;
			this.poRepository = poRepository;
			this.shopRepository = shopRepository;
        }

        //
        // GET: /Shops/

        public ViewResult Index()
        {
            return View(shopRepository.AllIncluding(shop => shop.Styles, shop => shop.Items));
        }

        //
        // GET: /Shops/Details/5

        public ViewResult Details(long id)
        {
            return View(shopRepository.Find(id));
        }

        //
        // GET: /Shops/Create

        public ActionResult Create()
        {
			ViewBag.PossibleCities = cityRepository.All;
			ViewBag.PossiblePOes = poRepository.All;
            return View();
        } 

        //
        // POST: /Shops/Create

        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            if (ModelState.IsValid) {
                shopRepository.InsertOrUpdate(shop);
                shopRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCities = cityRepository.All;
				ViewBag.PossiblePOes = poRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Shops/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleCities = cityRepository.All;
			ViewBag.PossiblePOes = poRepository.All;
             return View(shopRepository.Find(id));
        }

        //
        // POST: /Shops/Edit/5

        [HttpPost]
        public ActionResult Edit(Shop shop)
        {
            if (ModelState.IsValid) {
                shopRepository.InsertOrUpdate(shop);
                shopRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleCities = cityRepository.All;
				ViewBag.PossiblePOes = poRepository.All;
				return View();
			}
        }

        //
        // GET: /Shops/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(shopRepository.Find(id));
        }

        //
        // POST: /Shops/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            shopRepository.Delete(id);
            shopRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                cityRepository.Dispose();
                poRepository.Dispose();
                shopRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

