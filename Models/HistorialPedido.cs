using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class HistorialPedido
    {
        public int IDVenta { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string NombreProducto { get; set; }
        public string talla { get; set; }
        public double Total { get; set; }
        public string Tipo { get; set; }
    }
}