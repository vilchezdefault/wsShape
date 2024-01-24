using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;//SIN ESTO DA ERROR PORQUE NO TIENE ACCESO AL CONEXION STRING

namespace wsEmpresa_HH.Connection
{
    public class clConexion
    {
        public string CadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["DB"].ConnectionString.ToString();

        }
    }
}