using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class ProductoModel
    {

        public List<Producto> Listar()
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_LISTAR_PRODUCTOS";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();

            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Descripcion = rd[4].ToString();
                    producto.Stock = Convert.ToInt32(rd[5]);
                    producto.Precio = Convert.ToDouble(rd[6]);
                    producto.Genero = rd[7].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Cate = rd[8].ToString();
                    producto.cate = categoria;


                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar" + ex.Message);

            }

            return lista;

        }

        public List<Producto> ListarAleatorio()
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_LISTAR_PRODUCTOS_ALEATORIOS";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();

            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Descripcion = rd[4].ToString();
                    producto.Stock = Convert.ToInt32(rd[5]);
                    producto.Precio = Convert.ToDouble(rd[6]);
                    producto.Genero = rd[7].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Cate = rd[8].ToString();
                    producto.cate = categoria;


                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar" + ex.Message);

            }

            return lista;

        }

        public Producto Buscar(String codigo)
        {

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_BUSCAR_PROD_COD";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = codigo;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();
            Producto producto = null;
            Categoria categoria = null;

            try
            {
                if (rd.Read())
                {
                    producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Descripcion = rd[4].ToString();
                    producto.Stock = Convert.ToInt32(rd[5]);
                    producto.Precio = Convert.ToDouble(rd[6]);
                    producto.Genero = rd[7].ToString();


                    categoria = new Categoria();
                    categoria.idCategoria = Convert.ToInt32(rd[8]);
                    producto.cate = categoria;
                }
                rd.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Buscar Producto" + ex.Message);
            }

            return producto;

        }

        public List<Producto> FiltroHombre(string genero)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_FILTRADO_H";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@GENERO", SqlDbType.VarChar).Value = genero;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();

            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Descripcion = rd[4].ToString();
                    producto.Stock = Convert.ToInt32(rd[5]);
                    producto.Precio = Convert.ToDouble(rd[6]);
                    producto.Genero = rd[7].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Cate = rd[8].ToString();
                    producto.cate = categoria;


                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar" + ex.Message);

            }

            return lista;

        }

        public List<Producto> FiltroTallas(string tallas)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_FILTRADO_TALLAS";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@IDTALLA", SqlDbType.Int).Value = tallas;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();

            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Stock = Convert.ToInt32(rd[4]);
                    producto.Precio = Convert.ToDouble(rd[5]);
                    producto.Genero = rd[6].ToString();



                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar TALLAS" + ex.Message);

            }

            return lista;

        }

        public List<Producto> FiltroCategorias(string idcategoria)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_FILTRADO_CATEGORIAS";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@IDCATE", SqlDbType.Int).Value = idcategoria;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();

            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Stock = Convert.ToInt32(rd[4]);
                    producto.Precio = Convert.ToDouble(rd[5]);
                    producto.Genero = rd[6].ToString();



                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar TALLAS" + ex.Message);

            }

            return lista;

        }

        public List<Producto> Dinamic(string idtalla, string idcategoria, string idprecio)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_FILTRO_DINAMIC";
            SqlCommand command = new SqlCommand(sql, cn);
            command.Parameters.Add("@TALLAS", SqlDbType.Int).Value = idtalla;
            command.Parameters.Add("@CATEGORIA", SqlDbType.Int).Value = idcategoria;
            command.Parameters.Add("@PRECIO", SqlDbType.Int).Value = idprecio;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();
            List<Producto> lista = new List<Producto>();

            try
            {
                while (rd.Read())
                {
                    Producto producto = new Producto();
                    producto.IDProducto = Convert.ToInt32(rd[0]);
                    producto.CodProduct = rd[1].ToString();
                    producto.ImagenProducto = rd[2].ToString();
                    producto.NombreProducto = rd[3].ToString();
                    producto.Precio = Convert.ToDouble(rd[4]);
                    lista.Add(producto);

                }
                rd.Close();
                cn.Close();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception Listar Dinamic" + ex.Message);

            }

            return lista;

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