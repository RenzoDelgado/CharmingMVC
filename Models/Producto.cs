using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class Producto
    {

        public int IDProducto { get; set; }
        public String CodProduct { get; set; }
        public String ImagenProducto { get; set; }
        public String NombreProducto { get; set; }
        public String Descripcion { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public String Genero { get; set; }
        public Categoria cate { get; set; }




    }
}