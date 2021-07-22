using MVC_Charming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            ProductoModel prodmodel = new ProductoModel();

            List<Producto> lstProductos = prodmodel.Listar();

            ViewBag.Loquequiera = lstProductos;



            UsuarioModel usus = new UsuarioModel();
            int ID = Convert.ToInt32(Session["Usuario"]);
            ViewBag.Usu = usus.BuscarUID(ID);


            return View();
        }

        public ActionResult BuscarProducto()
        {
            Producto producto = new Producto();
            ProductoModel model = new ProductoModel();

            int idProducto = Convert.ToInt32(Request.Form.Get("id"));
            producto = model.BuscarxId(idProducto);


            return Json(producto);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}