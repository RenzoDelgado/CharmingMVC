using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class DeliveryModel
    {

        public void RegistrarVenta(int idusuario, double totalVenta, int tipo, Recoger objRecoger, Delivery objdelivery, Dictionary<int, int[]> listaCarrito)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_REGISTRAR_VENTA";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = idusuario;
            command.Parameters.Add("@TOTALVENTA", SqlDbType.Decimal).Value = totalVenta;
            command.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;

            command.ExecuteNonQuery();

            int idventa = ObtenerIdVenta();

            foreach (var producto in listaCarrito)
            {
                GuardarDetalleVenta(producto.Key,idventa,listaCarrito[producto.Key][0],listaCarrito[producto.Key][1]);
            }

            if (tipo == 1)
            {
                GuardarDelivery(objdelivery,idventa);
            }
            if(tipo == 0)
            {
                GuardarRecoger(objRecoger, idventa);
            }
        }

        public void GuardarDelivery(Delivery deli, int IDVenta)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_DELIVERY";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.Add("@idventa", SqlDbType.Int).Value = IDVenta;
                command.Parameters.Add("@nombres", SqlDbType.VarChar).Value = deli.Nombre;
                command.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = deli.Apellido;
                command.Parameters.Add("@direccionEnvio", SqlDbType.VarChar).Value = deli.DireccionEnvio;
                command.Parameters.Add("@referencia", SqlDbType.VarChar).Value = deli.Referencia;
                command.Parameters.Add("@telefono", SqlDbType.VarChar).Value = deli.Telefono;
                command.Parameters.Add("@iddistrito", SqlDbType.Int).Value = deli.distrito.idDistrito;
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Guardar:" + ex.Message);
            }
        }

        public void GuardarRecoger(Recoger pickup, int IDVenta)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_RECOGER";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Parameters.Add("@idventa", SqlDbType.Int).Value = IDVenta;
                command.Parameters.Add("@nombres", SqlDbType.VarChar).Value = pickup.Nombres;
                command.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = pickup.Apellidos;
                command.Parameters.Add("@dni", SqlDbType.VarChar).Value = pickup.DNI;
                command.Parameters.Add("@telefono", SqlDbType.VarChar).Value = pickup.Telefono;
                command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = pickup.Fecharecojo;
                command.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("ENTRO -- GUARDAR RECOGER");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR EN GUARDAR RECOGER : " + e.Message);
            }
        }



        public void GuardarDetalleVenta(int idproducto, int idventa, int cantidad, int idtalla)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_REGISTRAR_DETALLEVENTA";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@IDPRODUCTO", SqlDbType.Int).Value = idproducto;
            command.Parameters.Add("@IDVENTA", SqlDbType.Int).Value = idventa;
            command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = cantidad;
            command.Parameters.Add("@IDTALLA", SqlDbType.Int).Value = idtalla;
            command.ExecuteNonQuery();
        }

        public int ObtenerIdVenta()
        {
            int idventa = 0;
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "OBTENER_ULTIMAVENTA";
            SqlCommand command = new SqlCommand(sql, cn);



            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader rd = command.ExecuteReader();

            rd.Read();

            idventa = Convert.ToInt32(rd[0]);

            return idventa;
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
            objUsuario.Direccion = rd[5].ToString();
            objUsuario.Celular = rd[7].ToString();
            Distrito distrito = new Distrito();
            distrito.idDistrito = Convert.ToInt32(rd[6]);
            objUsuario.distrito = distrito;


            return objUsuario;
        }


    }
}