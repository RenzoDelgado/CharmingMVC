using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class CategoriaModel
    {
        public List<Categoria> Listar()
        {

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.getConexión();
            String sql = "SP_LISTAR_CATEGORIA";
            SqlCommand command = new SqlCommand(sql, cn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = command.ExecuteReader();
            List<Categoria> lista = new List<Categoria>();

            try
            {
                while (rd.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.idCategoria = Convert.ToInt32(rd[0]);
                    categoria.Cate = rd[1].ToString();
                    lista.Add(categoria);

                }
                rd.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al listar las categorias (Model)" + ex.Message);
            }

            return lista;
        }
    }


}