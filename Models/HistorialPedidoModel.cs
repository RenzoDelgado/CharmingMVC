using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class HistorialPedidoModel
    {

        public List<HistorialPedido> HistorialxUsuario(int IDUsuario)
        {

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_HISTORIAL_PEDIDO";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = IDUsuario;
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader rd = command.ExecuteReader();


            List<HistorialPedido> lista = new List<HistorialPedido>();

            try
            {
                while (rd.Read())
                {
                    HistorialPedido HP = new HistorialPedido();
                    HP.IDVenta = Convert.ToInt32(rd[0]);
                    HP.Fecha = rd[1].ToString();
                    HP.Nombre = rd[2].ToString();
                    HP.NombreProducto = rd[3].ToString();
                    HP.talla = rd[4].ToString();
                    HP.Total = Convert.ToDouble(rd[5]);
                    HP.Tipo = rd[6].ToString();
                    lista.Add(HP);
                }
                rd.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Buscar Producto" + ex.Message);
            }

            return lista;

        }
    }
}