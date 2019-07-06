using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Victus.Models;

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
        [HttpPost]
        public ActionResult Register(Persona p)
        {
            int i;
            i = p.CrearUsuario(p.correo, p.cedula, p.nombre, p.apellido1,p.apellido2, p.genero.Value, p.clave);
            if (ModelState.IsValid && i > 0)
            {
                return View("login",p);
            }
            else
                return View();
        }

        // Submit Info Page
        public ActionResult TestInfo() {
            return View();

        }

    }
}