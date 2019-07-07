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
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Persona p) {
            // Login Exitoso.

            Cliente_Persona _ClientePersona = new Cliente_Persona();

            if (p.VerificarCredenciales(p.correo, p.clave))
            {
                System.Diagnostics.Debug.WriteLine("Credenciales Correctas");

                if (ModelState.IsValid)
                {
                    

                    _ClientePersona.DatosPersona.correo = p.correo.ToString();
                    _ClientePersona.DatosPersona.nombre = p.nombre.ToString();
                    _ClientePersona.DatosPersona.apellido1 = p.apellido1;
                    _ClientePersona.DatosPersona.apellido2 = p.apellido2;
                    _ClientePersona.DatosPersona.cedula = p.cedula;
                    _ClientePersona.DatosPersona.genero = p.genero;

                    System.Diagnostics.Debug.WriteLine(p.correo + "|"+ _ClientePersona.DatosPersona.nombre );
                    return View("Dashboard", _ClientePersona);
                }
                else

                    return View();
            }
            else {
                System.Diagnostics.Debug.WriteLine("Credenciales InCorrectas");
                return View();
            }

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
        // Datos de Usuario
        public ActionResult MisDatos(Persona p) {
        
            return View();
        }


        // Submit Info Page
        public ActionResult TestInfo() {
            return View();

        }

    }
}