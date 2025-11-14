using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models.db
{
    public class Conexion
    {
        //cadena de conexion
        private string cadena = "Data Source=NOMBREMOTORDB; Initial Catalog=bdciberelectrikws2025; Integrated Security=True; TrustServerCertificate=true;";

        private SqlConnection xcon;

        public SqlConnection Conectar()
        {
            xcon = new SqlConnection(cadena);
            xcon.Open();
            return xcon;
        }

        public void CerrarConexion()
        {
            xcon.Close();
            xcon.Dispose();
        }

    }
}
