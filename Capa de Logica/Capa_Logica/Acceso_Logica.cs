using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;


namespace Capa_Logica
{
    public class Acceso_Logica
    {
        #region Entidad Persona

        public DataTable BuscarUsuario(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUsuario(Correo);
            return table;
        }
     

        public DataTable BuscarUsuarioTodo(string correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUsuarioTodo(correo);
            return table;
         
        }

        public int CrearUsuario(string Correo, string cedula, string nombre, string apellido1, string apellido2, string genero, string Contraseña)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            int bitgenero;

            if (genero == "True")
            {
                bitgenero = 1;

            }
            else
                bitgenero = 0;

            i = datos.CrearUsuario(Correo,cedula,nombre,apellido1,apellido2,Convert.ToString(bitgenero),Contraseña);
            return i;
        }

        public int CambiarContraseña(string Correo, string Contraseña)
        {
            acceso_datos datos = new acceso_datos(); 
            int i;
            i = datos.CambiarContraseña(Correo,Contraseña);
           
            return i;
        }

        public int EliminarUsuario(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            i = EliminarUsuario(Correo);
            return i;


        }

        #endregion

        #region Entidad Cliente
        public DataTable BuscarUltimoRegistro(string Correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUltimoRegistro(Correo);
            return table;
        }


        public DataTable BuscarCliente(string Correo, string Fecha) {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarCliente(Correo, Fecha);
            return table;
        }
        public int CrearDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha) {
            acceso_datos datos = new acceso_datos();
            int i;

            i = datos.AgregarDatosCliente(Correo, Peso, Altura, Edad, IMC, Agua,Fecha);
            return i;
        }
        public int ModificarDatosCliente(string Correo, string Peso, string Altura, string Edad, string IMC, string Agua, string Fecha)
        {
            acceso_datos datos = new acceso_datos();
            int i;

            i = datos.ActualizarDatosCliente(Correo, Peso, Altura, Edad, IMC, Agua, Fecha);
            return i;
        }


        #endregion

        #region Entidad HarrisBen
        public DataTable BuscarUltimoRegistroHarris(string correo)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUltimoRegistroHarris(correo);
            return table;
        }
        public DataTable BuscarRegistroHarris(string correo, string fecha)
        {
            acceso_datos datos = new acceso_datos();     
            DataTable table;
            table = datos.BuscarRegistroHarris(correo,fecha);
            return table;
        }
        public int AgregarRegistroHarris(string FactorActividad, string TMB, string NivelCalorico, string fecha, string correo)
        {
            acceso_datos datos = new acceso_datos();
            int i;
            i = datos.AgregarRegistroHarris(FactorActividad,TMB,NivelCalorico,fecha,correo);
            return i;
        }
        #endregion

        #region Entidad Dieta
        public int AgregarDieta(string CorreoCliente, string FechaDieta, string CodigoHarris, string Objetivo)
        {
            
            int i;
            acceso_datos datos = new acceso_datos();



            i = datos.AgregarDieta(CorreoCliente, FechaDieta, CodigoHarris, Objetivo);
            return i;
        }
        public DataTable ObtenerUltimaDieta(string CorreoCliente)
        {
            acceso_datos datos = new acceso_datos();
          
            DataTable table;
            table = datos.ObtenerUltimaDieta(CorreoCliente);
            return table;
        }
        public DataTable ObtenerDieta(string CorreoCliente, string FechaDieta)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
          


            table = datos.ObtenerDieta(CorreoCliente, FechaDieta);
            return table;
        }

        #endregion

        #region Entidad-DietaRelacion
        public int AgregarRelacion(string CodigoDieta, string CodigoAlimento)
        {
            
            int i;
            acceso_datos datos = new acceso_datos();


            i = datos.AgregarRelacion(CodigoDieta, CodigoAlimento);
            return i;
        }
        #endregion

        #region Entidad Catalogo Alimentos
        public DataTable ObtenerCatalogoAlimentos()
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;


            table = datos.ObtenerCatalogoAlimentos();
            return table;
        }
        public DataTable ObtenerDietaCompleta(string CorreoCliente, string CodigoDieta)
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;

            table = datos.ObtenerDietaCompleta(CorreoCliente, CodigoDieta);
            return table;
        }
        #endregion
        #region Medidas

        public int AgregarMedidas(string FechaMedida, string CorreoCliente, string BicepIzquierdo, string BicepDerecho, string Abdomen, string CuadricepIzquierdo, string CuadricepDerecho, string PantorrillaIzquierda, string PantorrillaDerecha)
        {
            acceso_datos Datos = new acceso_datos();
            int i;


            i = Datos.AgregarMedidas(FechaMedida, CorreoCliente, BicepIzquierdo, BicepDerecho, Abdomen, CuadricepIzquierdo, CuadricepDerecho, PantorrillaIzquierda, PantorrillaDerecha);
            return i;
        }
        public DataTable ObtenerUltimaMedida(string CorreoCliente)
        {
            acceso_datos Datos = new acceso_datos();            
            DataTable table;

            table = Datos.ObtenerUltimaMedida(CorreoCliente);
            return table;
        }
        public DataTable ObtenerMedida(string CorreoCliente, string FechaDieta)
        {
            acceso_datos Datos = new acceso_datos();
            DataTable table;
           
            table = Datos.ObtenerMedida(CorreoCliente, FechaDieta);
            return table;
        }
        public DataTable ObtenerMedicionCompleta(string CodigoMedida)
        {
            acceso_datos Datos = new acceso_datos();
            DataTable table;


            table = Datos.ObtenerMedicionCompleta(CodigoMedida);
            return table;
        }

        #endregion
    }
}
