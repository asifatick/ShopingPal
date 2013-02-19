using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{   
    public class ShopItemsController : Controller
    {
		private readonly IStyleCollectionRepository stylecollectionRepository;
		private readonly IShopRepository shopRepository;
		private readonly IShopItemsRepository shopitemsRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ShopItemsController() : this(new StyleCollectionRepository(), new ShopRepository(), new ShopItemsRepository())
        {
        }

        public ShopItemsController(IStyleCollectionRepository stylecollectionRepository, IShopRepository shopRepository, IShopItemsRepository shopitemsRepository)
        {
			this.stylecollectionRepository = stylecollectionRepository;
			this.shopRepository = shopRepository;
			this.shopitemsRepository = shopitemsRepository;
        }

        //
        // GET: /ShopItems/

        public ViewResult Index()
        {
            return View(shopitemsRepository.AllIncluding(shopitems => shopitems.Shop));
        }

        //
        // GET: /ShopItems/Details/5

        public ViewResult Details(long id)
        {
            return View(shopitemsRepository.Find(id));
        }

        //
        // GET: /ShopItems/Create

        public ActionResult Create()
        {
			ViewBag.PossibleStyleCollections = stylecollectionRepository.All;
			ViewBag.PossibleShops = shopRepository.All;
            return View();
        } 

        //
        // POST: /ShopItems/Create

        [HttpPost]
        public ActionResult Create(ShopItems shopitems)
        {
            if (ModelState.IsValid) {
                shopitemsRepository.InsertOrUpdate(shopitems);
                shopitemsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleStyleCollections = stylecollectionRepository.All;
				ViewBag.PossibleShops = shopRepository.All;
				return View();
			}
        }
        
        //
        // GET: /ShopItems/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleStyleCollections = stylecollectionRepository.All;
			ViewBag.PossibleShops = shopRepository.All;
             return View(shopitemsRepository.Find(id));
        }

        public ActionResult MultiShop()
        {
            List<City> shops = new List<City>();
            shops.Add(new City() { Id = 12,  Name = "" });
            shops.Add(new City() { Id = 13,  Name = "" });
            shops.Add(new City() { Id = 14,  Name = "" });

            return View(shops);

        }

        [HttpPost]
        public ActionResult MultiShop(List<City> shops)
        {
            
            return View(shops);

        }

        //
        // POST: /ShopItems/Edit/5

        [HttpPost]
        public ActionResult Edit(ShopItems shopitems)
        {
            if (ModelState.IsValid) {
                shopitemsRepository.InsertOrUpdate(shopitems);
                shopitemsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleStyleCollections = stylecollectionRepository.All;
				ViewBag.PossibleShops = shopRepository.All;
				return View();
			}
        }

        //
        // GET: /ShopItems/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(shopitemsRepository.Find(id));
        }

        //
        // POST: /ShopItems/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            shopitemsRepository.Delete(id);
            shopitemsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                stylecollectionRepository.Dispose();
                shopRepository.Dispose();
                shopitemsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

