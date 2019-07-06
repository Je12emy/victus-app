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
     

        public DataTable BuscarUsuarioTodo()
        {
            acceso_datos datos = new acceso_datos();
            DataTable table;
            table = datos.BuscarUsuarioTodo();
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
    }
}
