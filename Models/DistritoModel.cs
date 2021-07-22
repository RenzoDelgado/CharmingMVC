using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class DistritoModel
    {


        public List<Distrito> ListarDistrito()
        {

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_LISTAR_DISTRITO";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();
            List<Distrito> lista = new List<Distrito>();

            try
            {
                while (rd.Read())
                {
                    Distrito dist = new Distrito();
                    dist.idDistrito = Convert.ToInt32(rd[0]);
                    dist.Distritos = rd[1].ToString();
                    lista.Add(dist);

                }
                rd.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al listar los distritos (Model)" + ex.Message);
            }

            return lista;

        }


    }
}