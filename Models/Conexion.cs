using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class Conexion
    {

        SqlConnection cn;
        public SqlConnection getConexión()
        {

            cn = new SqlConnection("Data Source = localhost;Initial Catalog = CharmingBD ;User ID =sa ; Password= 123");

            try
            {
                cn.Open();
                System.Diagnostics.Debug.WriteLine("Conexión de BD Exitosa");
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Error de Conexión SQL" + ex.Message);
            }

            return cn;

        }

    }
}