using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Victus.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Landing Page
        public ActionResult Index()
        {
            return View();
        }
        // Login Page
        public ActionResult Login() {
            return View();
        }
        // Registrarion Page
        [HttpGet]
        public ActionResult Register() {
            return View();
        }

        // Submit Info Page
        public ActionResult TestInfo() {
            return View();

        }

    }
}