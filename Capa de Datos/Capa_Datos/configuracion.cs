using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    class configuracion
    {
        // Class for returning the connection string for the datebase
        public static string connection_string = "Data Source=.;Initial Catalog=Victus;Integrated Security=True";

        public string GetConnectionString()
        {
            return connection_string;
        }
    }
}
