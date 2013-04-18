using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    using TestWeb.Models;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Icons()
        {
            return this.View();
        }

        public ActionResult Buttons()
        {
            return this.View();
        }

        public ActionResult TextBox()
        {
            var model = new Contact() { Id = 1 };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult TextBox(Contact model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TextBox");
            }
            return View(model);
        }

    }
}
