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

        #region Dashboard        
        // DashBoard
        [HttpGet]
        public ActionResult Dashboard()
        {
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
                // Variables de TempData provenientes del login.
                _Usuario = TempData["Usuario"].ToString();
                _Genero = TempData["Genero"].ToString();
                TempData.Keep();

                ultimo_registro = c.ObtenerUltimoRegistro(_Usuario);
                if (ultimo_registro.Rows.Count > 0)
                {
                    
                    FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();
                    System.Diagnostics.Debug.WriteLine("Ultimo Registro del Cliente en: " + FechaUltimoRegistro);
                    Registro = c.ObtenerDatosUsuario(_Usuario, FechaUltimoRegistro);
                    if (Registro.Rows.Count > 0)
                    {                       
                        TempData["IMC"] = Registro.Rows[0][5].ToString();
                        TempData["Agua"] = Registro.Rows[0][6].ToString();


                        System.Diagnostics.Debug.WriteLine("Datos Basicos: " + TempData["IMC"].ToString() + " de IMC|" + TempData["Agua"].ToString() + " vasos de agua");

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
                            ViewBag.Calorias_nueva = TempData["Calorias_nueva"];
                        }

                        ultimo_registro = HB.BuscarUltimoRegistroHarris(_Usuario);
                        if (ultimo_registro.Rows.Count > 0)
                        {                          
                            FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();
                            System.Diagnostics.Debug.WriteLine("Ultimo Registro del Harris en: " + FechaUltimoRegistro);
                            Registro = HB.BuscarRegistroHarris(_Usuario, FechaUltimoRegistro);
                            if (Registro.Rows.Count > 0)
                            {
                                TempData["Calorias"] = Registro.Rows[0][3].ToString();
                                ViewBag.Calorias_nueva = TempData["Calorias"];
                                TempData.Keep();

                                ViewBag.Usuario = _Usuario;
                                ViewBag.Calorias = TempData["Calorias"];
                                
                                // ViewData para mostrar la Dieta.
                                string CodigoDieta;
                                List<string> ListaAlimentos = new List<string>();
                                List<string> ListaCalorias = new List<string>();

                                Registro = d.ObtenerUltimaDieta(_Usuario);
                                if (Registro.Rows.Count > 0)
                                {
                                    FechaUltimoRegistro = Registro.Rows[0][0].ToString();
                                    Registro = d.ObtenerDieta(_Usuario, FechaUltimoRegistro);
                                    if (Registro.Rows.Count > 0)
                                    {
                                        CodigoDieta = Registro.Rows[0][0].ToString();
                                        Registro = d.ObtenerDietaCompleta(_Usuario, CodigoDieta);
                                        if (Registro.Rows.Count > 0)
                                        {
                                            // Ciclo para llenar las listas con las partes de la dieta.
                                            for (int i = 0; i < Registro.Rows.Count; i++)
                                            {
                                                System.Diagnostics.Debug.WriteLine(Registro.Rows[i][0].ToString());
                                                ListaAlimentos.Add(Registro.Rows[i][0].ToString());
                                                ListaCalorias.Add(Registro.Rows[i][1].ToString());
                                            }
                                            ViewData["ListaAlimentos"] = ListaAlimentos;
                                            ViewData["ListaCalorias"] = ListaCalorias;

                                            // ViewData para mostrar la Medidas.
                                            Medidas m = new Medidas();

                                            string CodigoMedida;
                                            List<string> ListaMedida = new List<string>();
                                            List<string> ListaConcepto = new List<string>();

                                            Registro = m.ObtenerUltimaMedida(_Usuario);
                                            if (Registro.Rows.Count > 0)
                                            {
                                                System.Diagnostics.Debug.WriteLine("Fecha Ultima Medida: " + Registro.Rows[0][0].ToString());
                                                FechaUltimoRegistro = Registro.Rows[0][0].ToString();
                                                Registro = m.ObtenerMedida(_Usuario, FechaUltimoRegistro);
                                                if (Registro.Rows.Count > 0)
                                                {
                                                    System.Diagnostics.Debug.WriteLine("Codigo de Medicion: " + Registro.Rows[0][0].ToString());
                                                    // Capturar el codigo de medida.
                                                    CodigoMedida = Registro.Rows[0][0].ToString();
                                                    Registro = m.ObtenerMedicionCompleta(CodigoMedida);
                                                    if (Registro.Rows.Count > 0)
                                                    {

                                                        // Ciclo para llenar la lista de medidas.
                                                        // Detalle
                                                        for (int i = 0; i < Registro.Columns.Count; i++)
                                                        {
                                                            ListaConcepto.Add(Registro.Columns[i].ToString());
                                                            ListaMedida.Add(Registro.Rows[0][i].ToString());
                                                        }

                                                        ViewData["ListaMedidas"] = ListaMedida;
                                                        ViewData["ListaConcepto"] = ListaConcepto;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        #endregion

        #region Datos de Usuario
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
            // Variables para los metodos SQL.
            DataTable ultimo_registro;
            DataTable Registro;
            String FechaUltimoRegistro;
            int i;
            DateTime today = DateTime.Now;
            // Capturar los datos
            string Correo = TempData["Usuario"].ToString();
            string Peso = c.Peso.ToString();
            string Edad = c.Edad.ToString();
            string Altura = c.Altura.ToString();

            // Formulas

            // Peso / Altura^2
            string IMC = Convert.ToString(Math.Round((c.Peso / (c.Altura * 2)), 2));
            // Peso en KG/7 y redondeo a Entero
            string Agua = Convert.ToString(Math.Round((c.Peso / 7),0));

            string fecha = today.ToString();

            // Refrescar el TempDada[], puede ser redundante!
            TempData["Usuario"] = Correo;
            TempData.Keep();
            
            i = c.AgregarDatosUsuario(Correo, Peso,Altura,Edad, IMC, Agua, fecha);

            if (i > 0)
            {
                // Obtener el ultimo registro para mostrar el progreso en el dashboard, solo aca hago esta implementacion.
                // el resto se hace en el dashboard.
                ultimo_registro = c.ObtenerUltimoRegistro(Correo);
                FechaUltimoRegistro = ultimo_registro.Rows[0][0].ToString();

                Registro = c.ObtenerDatosUsuario(Correo, FechaUltimoRegistro);

                TempData["IMC_nueva"] = Registro.Rows[0][5].ToString();
                TempData["Agua_nueva"] = Registro.Rows[0][6].ToString();
                return RedirectToAction("Dashboard");
            }
            else {
                return View();
            }
            
        }
        #endregion

        #region IMC y Agua
        // Nivel Calorico para la dieta.
        [HttpGet]
        public ActionResult Factor_de_Actividad() {
            //string _Usuario;
            //string _Genero;
            //Obtenemos los dos datos para crear el registro mediante TempData.
            if (TempData.ContainsKey("Usuario") || TempData.ContainsKey("Genero"))
            {
                //_Usuario = TempData["Usuario"].ToString();
                //_Genero = TempData["Genero"].ToString();
                // Hacemos un Keep para que dure un redireccionamiento mas.
                TempData.Keep();
                //ViewBag.Usuario = _Usuario;
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
            // Variables para los registros de SQL
            DataTable DataCliente;
            String FechaUltimoRegistro;
            int i;
            string Correo = TempData["Usuario"].ToString();
            // Variables para la captura de datos
            double FactorActividad = 0;
            double tmb;
            double peso;
            int altura;
            int edad;
            double TotalCalorias;
            string Genero;
            DateTime today = DateTime.Now;
            string Seleccion;

            if (ModelState.IsValid)
            {
                // Creamos una instancia del modelo de Cliente para obtener los Datos necesarios para calcular los datos.
                Cliente c = new Cliente();
                // Pido la fecha del ultimo registro.
                DataCliente = c.ObtenerUltimoRegistro(Correo);
                if (DataCliente.Rows.Count > 0)
                {
                    FechaUltimoRegistro = DataCliente.Rows[0][0].ToString();
                    // Solicito el registro mas reciente.
                    DataCliente = c.ObtenerDatosUsuario(Correo, FechaUltimoRegistro);
                    if (DataCliente.Rows.Count > 0)
                    {
                        peso = Convert.ToDouble(DataCliente.Rows[0][2].ToString());
                        altura = Convert.ToInt16(DataCliente.Rows[0][3].ToString());
                        edad = Convert.ToInt16(DataCliente.Rows[0][4].ToString());
                        Genero = TempData["Genero"].ToString();
                        // Capturo el valor seleccionado de los radio buttons.
                        Seleccion = HB.NivelActividad.ToString();

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

                        i = HB.AgregarRegistroHarris(Convert.ToString(FactorActividad), Convert.ToString(tmb), Convert.ToString(TotalCalorias), Convert.ToString(today), Correo);
                        if (i > 0)
                        {
                            // Si se hace la insercion con exito.
                            TempData["Usuario"] = Correo;
                            TempData["Calorias_nueva"] = TotalCalorias.ToString();
                            TempData.Keep();
                            return RedirectToAction("Dashboard");
                        }
                    }
                }
            }
            return View();
        }
        #endregion

        #region Dieta     
        // Mi Dieta
        [HttpGet]
        public ActionResult MiDieta() {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult MiDieta(Dieta d)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(d.objetivo.ToString());
                // Variables capturadas
                string seleccion = d.objetivo.ToString();
                // Variables para el registro SQL
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
                if (Tabla.Rows.Count > 0)
                {
                    // Capturar la fecha del ultimo registro.
                    Fecha = Tabla.Rows[0][0].ToString();

                    Tabla = Calorias.BuscarRegistroHarris(Usuario, Fecha);
                    if (Tabla.Rows.Count > 0)
                    {
                        // Capturar los Datos para relacionar,
                        CaloriasTotales = Tabla.Rows[0][3].ToString();
                        CodigoHarrisBen = Tabla.Rows[0][0].ToString();

                        // Datos para insertar el registro.
                        Fecha = FechaActual.ToString();
                        Resultado = d.AgregarDieta(Usuario, Fecha, CodigoHarrisBen, seleccion);
                        if (Resultado > 0)
                        {
                            // Obtener la dieta mas reciente
                            string CodigoDieta;
                            Tabla = d.ObtenerUltimaDieta(Usuario);
                            if (Tabla.Rows.Count > 0)
                            {
                                Fecha = Tabla.Rows[0][0].ToString();
                                Tabla = d.ObtenerDieta(Usuario, Fecha);
                                if (Tabla.Rows.Count > 0)
                                {
                                    CodigoDieta = Tabla.Rows[0][0].ToString();
                                    TempData["CodigoDieta"] = CodigoDieta;

                                    // Ajustar el nivel calorico
                                    if (seleccion.Equals("bajar"))
                                    {
                                        CaloriasTotales = Convert.ToString(Convert.ToDouble(CaloriasTotales) - 500);
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
                            }
                        }
                    }
                }
                return View();
            }
            else
                return View();
        }
        #endregion

        #region Medidas      
        // Medidas
        [HttpGet]
        public ActionResult Medidas() {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult Medidas(Medidas m) {
            if (ModelState.IsValid)
            {
                // Variables para SQL
                DateTime FechaActual = DateTime.Now;
                string Usuario;
                string Fecha;
                DataTable Tabla;
                int resultado;

                Fecha = FechaActual.ToString();
                Usuario = TempData["Usuario"].ToString();
                resultado = m.AgregarMedidas(Fecha,Usuario,m.BicepIzquierdo.ToString(), m.BicepDerecho.ToString(), m.Abdomen.ToString(), m.CuadricepIzquierdo.ToString(), m.BicepDerecho.ToString(), m.PantorrillaIzquierda.ToString(), m.PantorrillaDerecha.ToString());
                if (resultado > 0)
                {
                    return RedirectToAction("Dashboard");
                } else
                    return View();              
            }
            else
                return View();
        }
        #endregion

    }
}
