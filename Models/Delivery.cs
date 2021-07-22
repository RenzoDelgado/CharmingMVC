using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Charming.Models
{
    public class Delivery
    {
        public int IDEnvio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DireccionEnvio { get; set; }
        public string Referencia { get; set; }
        public string Telefono { get; set; }
        public Distrito distrito { get; set; }



    }
}