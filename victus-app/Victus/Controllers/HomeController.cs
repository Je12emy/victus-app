using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Victus.Models;
using System.Data;

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

            ModeloDatos _ClientePersona = new ModeloDatos();

            if (p.VerificarCredenciales(p.correo, p.clave))
            {
                System.Diagnostics.Debug.WriteLine("Credenciales Correctas");

                if (ModelState.IsValid)
                {
                    // Enviar atravez de TempData el Usuario.
                    TempData["Usuario"] = p.correo.ToString();


                    _ClientePersona.DatosPersona.correo = p.correo.ToString();
                    _ClientePersona.DatosPersona.nombre = p.nombre.ToString();
                    _ClientePersona.DatosPersona.apellido1 = p.apellido1;
                    _ClientePersona.DatosPersona.apellido2 = p.apellido2;
                    _ClientePersona.DatosPersona.cedula = p.cedula;
                    _ClientePersona.DatosPersona.genero = p.genero;

                    System.Diagnostics.Debug.WriteLine(p.correo + "|" + _ClientePersona.DatosPersona.nombre );

                    return RedirectToAction("Dashboard");
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
                return RedirectToAction("Dashboard");
            }
            else
                return View();
        }

        // DashBoard
        [HttpGet]
        public ActionResult Dashboard() {
            Cliente c = new Cliente();
            string _Usuario;
            DataTable ultimo_registro;
            DataTable Registro;
            String FechaUltimoRegistro;


            if (TempData.ContainsKey("Usuario"))
            {
                _Usuario = TempData["Usuario"].ToString();

                ultimo_registro = c.ObtenerUltimoRegistro(_Usuario);
                FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();

                Registro = c.ObtenerDatosUsuario(_Usuario, FechaUltimoRegistro);

                TempData["IMC"] = Registro.Rows[0][5].ToString();
                TempData["Agua"] = Registro.Rows[0][6].ToString();

                

                TempData.Keep();

                ViewBag.Usuario = _Usuario;

                ViewBag.Agua = TempData["Agua"];
                ViewBag.IMC = TempData["IMC"];

                // Si tengo TempData de Agua y IMC nuevas.
                if (TempData.ContainsKey("Agua_nueva") && TempData.ContainsKey("IMC_nueva"))
                {
                    // Creo ViewBags para allas.
                    ViewBag.Agua_nueva = TempData["Agua_nueva"];
                    ViewBag.IMC_nueva = TempData["IMC_nueva"];

                }
                return View();
            }
            else{
                return RedirectToAction("Login");
            }
            

        }
       


        // Datos de Usuario
        [HttpGet]
        public ActionResult MisDatos() {
            string _Usuario;
            // Aun debo de tener el correo del usuario gracias al TempData
            if (TempData.ContainsKey("Usuario"))
            {
                _Usuario = TempData["Usuario"].ToString();
                TempData.Keep();
                ViewBag.Usuario = _Usuario;
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public ActionResult MisDatos(Cliente c) {
            System.Diagnostics.Debug.WriteLine("INSERTANDO DATOS DE CLIENTE.");
            DataTable ultimo_registro;
            DataTable Registro;
            String FechaUltimoRegistro;

            int i;
            DateTime today = DateTime.Now;
            string Correo = TempData["Usuario"].ToString();
            string Peso = c.Peso.ToString();
            string Edad = c.Edad.ToString();
            string Altura = c.Altura.ToString();

            // Peso / Altura^2
            string IMC = Convert.ToString(Math.Round((c.Peso / (c.Altura * 2)), 2));
            System.Diagnostics.Debug.WriteLine(IMC.ToString());
            // Peso en KG/7 y redondeo a Entero
            string Agua = Convert.ToString(Math.Round((c.Peso / 7),0));
            System.Diagnostics.Debug.WriteLine(Agua.ToString());

            string fecha = today.ToString();

            i = c.AgregarDatosUsuario(Correo, Peso,Altura,Edad, IMC, Agua, fecha);

            TempData["Usuario"] = Correo;
            TempData.Keep();

            ultimo_registro = c.ObtenerUltimoRegistro(Correo);
            FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();

            Registro = c.ObtenerDatosUsuario(Correo,FechaUltimoRegistro);

            TempData["IMC_nueva"] = Registro.Rows[0][5].ToString();
            TempData["Agua_nueva"] = Registro.Rows[0][6].ToString();

            System.Diagnostics.Debug.WriteLine(TempData["IMC"] + "|" + TempData["Agua"] );

            return RedirectToAction("Dashboard");
        }
        // Submit Info Page
        public ActionResult TestInfo() {
            return View();

        }

    }
}