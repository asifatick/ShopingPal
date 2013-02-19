using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingPal.Models;

namespace ShoppingPal.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buyers(int itemID)
        {
            List<User> buyerList, friendInBuyer;

            using (UnitsOW  unit = new UnitsOW( new ShoppingPalContext()))
            {
                buyerList = unit.ItemRepository.GetWardDroppedItems(itemID).Select(w => w.User).ToList();

                List<User> friends = unit.FriendRepository.Friends(HttpContext.User.Identity.Name).Select(f=> f.Friend).ToList();
               
                
                friendInBuyer = buyerList.Intersect<User>(friends).ToList();
               

            }

            return PartialView(friendInBuyer.Union(buyerList).Distinct());        
        }


        //
        // GET: /Item/Subscribe/5
        public ActionResult Subscribe(long id)
        {
            using (UnitsOW  unit = new UnitsOW( new ShoppingPalContext()))
            {
            }
            return View();
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Item/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
