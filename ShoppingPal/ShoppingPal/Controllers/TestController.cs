using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingPal.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }
        [Authorize (Roles ="Admin")]
        public ActionResult UnRealTest()
        {
            return View();
        }


    }
}
