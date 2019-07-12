using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Capa_Logica;

namespace Victus.Models
{
    public class HarrisBen
    {
        public string NivelActividad { get; set; }
        public float TMB { get; set; }
        public float TotalCalorias { get; set; }

        public DataTable BuscarUltimoRegistroHarris(string correo)
        {
            Acceso_Logica datos = new Acceso_Logica();
            DataTable table;
            table = datos.BuscarUltimoRegistroHarris(correo);
            return table;
        }
        public DataTable BuscarRegistroHarris(string correo, string fecha)
        {
            Acceso_Logica datos = new Acceso_Logica();
            DataTable table;
            table = datos.BuscarRegistroHarris(correo, fecha);
            return table;
        }
        public int AgregarRegistroHarris(string FactorActividad, string TMB, string NivelCalorico, string fecha, string correo)
        {
            Acceso_Logica datos = new Acceso_Logica();
            int i;
            i = datos.AgregarRegistroHarris(FactorActividad, TMB, NivelCalorico, fecha, correo);
            return i;
        }
    }
}