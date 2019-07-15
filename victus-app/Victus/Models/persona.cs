using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Capa_Logica;

namespace Victus.Models
{
    public class Persona
    {
        readonly Acceso_Logica logica = new Acceso_Logica();
        public string correo { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public bool? genero { get; set; }
        public string clave { get; set; }

        public int CrearUsuario(string correo, string cedula,string nombre,string apellido1,string apellido2,Boolean genero, string contraseña) {
            int i;
            i = logica.CrearUsuario(correo,cedula, nombre, apellido1,apellido2, Convert.ToString(genero),contraseña);
            return i;

        }
        public DataTable BuscarUsuario(string correo) {
            DataTable table;
            table = logica.BuscarUsuario(correo);
            return table;

        }
        public Boolean VerificarCredenciales(string correo, string password) {
            DataTable usser;
            usser = BuscarUsuario(correo);
            if (usser.Rows.Count > 0 && correo.ToLower() == usser.Rows[0][0].ToString().ToLower() && password == usser.Rows[0][1].ToString())
            {
                System.Diagnostics.Debug.WriteLine("Retornando True" + correo.ToString() + usser.Rows[0][0].ToString() + password.ToString() + usser.Rows[0][1].ToString());
                LlenarModeloPersona(correo);
                return true;
            }
            else
                System.Diagnostics.Debug.WriteLine("Retornando False");
            return false;
        }

        public void LlenarModeloPersona(string _correo) {
            DataTable modelo;
            modelo = logica.BuscarUsuarioTodo(_correo);

            correo = modelo.Rows[0][0].ToString();
            nombre = modelo.Rows[0][1].ToString();
            cedula = modelo.Rows[0][2].ToString();
            apellido1 = modelo.Rows[0][3].ToString();
            apellido2 = modelo.Rows[0][4].ToString();
            genero = Convert.ToBoolean(modelo.Rows[0][5]);
            clave = modelo.Rows[0][6].ToString();

        }



    }
}