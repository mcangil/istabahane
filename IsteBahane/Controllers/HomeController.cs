using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsteBahane.Data;
using IsteBahane.Data.DB;
using IsteBahane.Manager;

namespace IsteBahane.Controllers
{
    public class HomeController : Controller
    {
        readonly CacheManager _cacheManager = new CacheManager();

        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RemoveCache()
        {
            const string cacheKey = "excuse";
            _cacheManager.Remove(cacheKey);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
    }
}