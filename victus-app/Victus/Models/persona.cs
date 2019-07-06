using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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



    }
}