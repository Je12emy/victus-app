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
                    TempData["Genero"] = p.genero.ToString();

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
            HarrisBen HB = new HarrisBen();
            Dieta d = new Dieta();
            string _Usuario;
            string _Genero;
            DataTable ultimo_registro;
            DataTable Registro;
            String FechaUltimoRegistro;

            // Informacion Inicial.
            if (TempData.ContainsKey("Usuario") || TempData.ContainsKey("Genero"))
            {
                

                _Usuario = TempData["Usuario"].ToString();
                _Genero = TempData["Genero"].ToString();

                ultimo_registro = c.ObtenerUltimoRegistro(_Usuario);
                FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();

                Registro = c.ObtenerDatosUsuario(_Usuario, FechaUltimoRegistro);

                TempData["IMC"] = Registro.Rows[0][5].ToString();
                TempData["Agua"] = Registro.Rows[0][6].ToString();

                ultimo_registro = HB.BuscarUltimoRegistroHarris(_Usuario);
                FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();

                Registro = HB.BuscarRegistroHarris(_Usuario,FechaUltimoRegistro);

                System.Diagnostics.Debug.WriteLine(Registro.Rows[0][0].ToString());

                TempData["Calorias"] = Registro.Rows[0][3].ToString();

                ViewBag.Calorias = TempData["Calorias"];

                TempData.Keep();

                ViewBag.Usuario = _Usuario;

                ViewBag.IMC = TempData["Calorias"];
                ViewBag.Agua = TempData["Agua"];
                ViewBag.IMC = TempData["IMC"];

                // Si tengo TempData de Agua y IMC nuevas.
                if (TempData.ContainsKey("Agua_nueva") && TempData.ContainsKey("IMC_nueva"))
                {
                    // Creo ViewBags para allas.
                    ViewBag.Agua_nueva = TempData["Agua_nueva"];
                    ViewBag.IMC_nueva = TempData["IMC_nueva"];
                }
                if (TempData.ContainsKey("Calorias"))
                {
                    ViewBag.IMC_nueva = TempData["Calorias_nueva"];
                }

                string CodigoDieta;
                List<string> ListaAlimentos = new List<string>();
                List<string> ListaCalorias = new List<string>();

                Registro = d.ObtenerUltimaDieta(_Usuario);
                FechaUltimoRegistro = Registro.Rows[0][0].ToString();

                Registro = d.ObtenerDieta(_Usuario,FechaUltimoRegistro);
                CodigoDieta = Registro.Rows[0][0].ToString();

                Registro = d.ObtenerDietaCompleta(_Usuario,CodigoDieta);

                for (int i = 0; i < Registro.Rows.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine(Registro.Rows[i][0].ToString());
                    ListaAlimentos.Add(Registro.Rows[i][0].ToString());
                    ListaCalorias.Add(Registro.Rows[i][1].ToString());
                }
                ViewData["ListaAlimentos"] = ListaAlimentos;
                ViewData["ListaCalorias"] = ListaCalorias;
                


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
            string _Genero;
            // Aun debo de tener el correo del usuario gracias al TempData
            if (TempData.ContainsKey("Usuario") || TempData.ContainsKey("Genero"))
            {
                _Usuario = TempData["Usuario"].ToString();
                _Genero = TempData["Genero"].ToString();
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

        // Nivel Calorico para la dieta.
        [HttpGet]
        public ActionResult Factor_de_Actividad() {
            string _Usuario;
            string _Genero;
            // Aun debo de tener el correo del usuario gracias al TempData
            if (TempData.ContainsKey("Usuario") || TempData.ContainsKey("Genero"))
            {
                _Usuario = TempData["Usuario"].ToString();
                _Genero = TempData["Genero"].ToString();
                TempData.Keep();
                ViewBag.Usuario = _Usuario;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }
        [HttpPost]
        public ActionResult Factor_de_Actividad(HarrisBen HB)
        {

            System.Diagnostics.Debug.WriteLine("Insertando Formula HarrisBen");

            double FactorActividad = 0;
            double tmb;
            double peso;
            int altura;
            int edad;
            double TotalCalorias;

            DataTable ultimo_registro;
            DataTable Registro;
            String FechaUltimoRegistro;
            string Correo = TempData["Usuario"].ToString();
            // Ocupo el Genero de este cliente y su Peso, Edad y Altura
            Cliente c = new Cliente();
            DataTable DataCliente = c.ObtenerUltimoRegistro(Correo);
            FechaUltimoRegistro = DataCliente.Rows[0][0].ToString();
            // Aca ya tengo los datos necesarios.
            DataCliente = c.ObtenerDatosUsuario(Correo,FechaUltimoRegistro);
            // Capturar los datos del ultimo registro del cliente.

            peso = Convert.ToDouble(DataCliente.Rows[0][2].ToString());
            altura = Convert.ToInt16(DataCliente.Rows[0][3].ToString());
            edad = Convert.ToInt16(DataCliente.Rows[0][4].ToString());


            string Genero = TempData["Genero"].ToString();
            int i;
            DateTime today = DateTime.Now;
           
            string Seleccion = HB.NivelActividad.ToString();

            // Comprar el factor de Actividad
            if (Seleccion == "sedentario")
            {
                FactorActividad = 1.2;
            }
            else if (Seleccion == "ligero")
            {
                FactorActividad = 1.375;
            }
            else if (Seleccion == "moderado")
            {
                FactorActividad = 1.55;
            }
            else if (Seleccion == "intenso")
            {
                FactorActividad = 1.725;
            }
            else if (Seleccion == "muy_intenso")
            {
                FactorActividad = 1.9;
            }

            // Formula para cada genero
            if (Convert.ToBoolean(Genero))
            {
                // True = Masculino
                tmb = 66 + (13.7 * peso) + (5 * altura) - (6.8 * edad);              
            }
            else
                // False = Femenino
                tmb = 655 + (9.6 * peso) + (1.8 * altura) - (4.7 * edad);

            // Calorias Totales

            TotalCalorias = FactorActividad * tmb;

            i = HB.AgregarRegistroHarris(Convert.ToString(FactorActividad), Convert.ToString(tmb),Convert.ToString(TotalCalorias),Convert.ToString(today),Correo);
            

            TempData["Usuario"] = Correo;
            TempData["Calorias_nueva"] = TotalCalorias.ToString();
            TempData.Keep();
            return RedirectToAction("Dashboard");
        }
        // Mi Dieta
        [HttpGet]
        public ActionResult MiDieta() {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult MiDieta(Dieta d) {
            if (ModelState.IsValid)
            {
                string seleccion = d.objetivo.ToString();
                HarrisBen Calorias = new HarrisBen();
                DateTime FechaActual = DateTime.Now;
                string Usuario;
                string Fecha;                
                DataTable Tabla;
                string CaloriasTotales;
                string CodigoHarrisBen;
                int Resultado;

                Usuario = TempData["Usuario"].ToString();
                Tabla = Calorias.BuscarUltimoRegistroHarris(Usuario);
                Fecha = Tabla.Rows[0][0].ToString();
                Tabla = Calorias.BuscarRegistroHarris(Usuario,Fecha);

                // Capturar los Datos para relacionar,
                CaloriasTotales = Tabla.Rows[0][3].ToString();
                CodigoHarrisBen = Tabla.Rows[0][0].ToString();

                // Datos para insertar el registro.
                Fecha = FechaActual.ToString();
                Resultado = d.AgregarDieta(Usuario, Fecha, CodigoHarrisBen,seleccion );

                // Obtener la dieta mas reciente
                string CodigoDieta;
                Tabla = d.ObtenerUltimaDieta(Usuario);
                Fecha = Tabla.Rows[0][0].ToString();
                Tabla = d.ObtenerDieta(Usuario, Fecha);
                CodigoDieta = Tabla.Rows[0][0].ToString();
                TempData["CodigoDieta"] = CodigoDieta;

                // Ajustar el nivel calorica
                if (seleccion.Equals("bajar"))
                {
                    CaloriasTotales = Convert.ToString(Convert.ToDouble(CaloriasTotales) - 500);
                }
                if (seleccion.Equals("mantener"))
                {
                    
                }
                if (seleccion.Equals("subir"))
                {
                    CaloriasTotales = Convert.ToString(Convert.ToDouble(CaloriasTotales) + 500);
                }

                // Obtener el catalogo de alimentos.
                Tabla = d.ObtenerCatalogoAlimentos();
                double ContadorCalorias = 0;
                string CodigoAlimento;
                // Ciclo para empezar a asociar las comidas a la dieta.
                Random r = new Random();
                int Indice;


                while (ContadorCalorias < Convert.ToDouble(CaloriasTotales))
                {
                    ContadorCalorias = ContadorCalorias + Convert.ToDouble(Tabla.Rows[0][2]);
                    Indice = r.Next(0, Tabla.Rows.Count);
                    CodigoAlimento = Tabla.Rows[Indice][0].ToString();
                    d.AgregarRelacion(CodigoDieta, CodigoAlimento);
                }
                
                return RedirectToAction("Dashboard");
            }
            else
                return View();


        }
           
        }

    }
