using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class RecogerModel
    {

        public Usuario BuscarUsuarioxID(int id)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_BUSCAR_USUARIOID";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();

            SqlDataReader rd = command.ExecuteReader();

            rd.Read();

            Usuario objUsuario = new Usuario();

            objUsuario.NombreU = rd[1].ToString();
            objUsuario.Apellido = rd[2].ToString();
            objUsuario.Dni = rd[4].ToString();
            objUsuario.Celular = rd[7].ToString();

            return objUsuario;
        }


        public Producto BuscarxId(int id)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_BUSCAR_IDPRODUCTO";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();
            Producto producto = new Producto();

            try
            {
                while (rd.Read())
                {
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Descripcion = rd[4].ToString();
                    producto.Stock = Convert.ToInt32(rd[5]);
                    producto.Precio = Convert.ToDouble(rd[6]);

                }
                rd.Close();
                cn.Close();

                return producto;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar TALLAS" + ex.Message);
            }

            return null;

        }



    }
}