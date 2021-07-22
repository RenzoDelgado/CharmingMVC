using MVC_Charming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class LookController : Controller
    {
        // GET: Look
        public ActionResult ObservarProducto()
        {
            ProductoModel prodmodel = new ProductoModel();
            List<Producto> lstProductos = prodmodel.ListarAleatorio();
            ViewBag.Loquequiera = lstProductos;


            // Capturar el valor del codigo
            string codigo = Request.Params.Get("CODPROD");
            Producto Objproducto = prodmodel.Buscar(codigo);
            ViewBag.producto = Objproducto;



            UsuarioModel usus = new UsuarioModel();
            int ID = Convert.ToInt32(Session["Usuario"]);
            ViewBag.Usu = usus.BuscarUID(ID);


            return View();
        }


        public ActionResult BuscarTallaStock()
        {
            int stock = 0;
            TallasModel tallaModel = new TallasModel();
            int idTalla = Convert.ToInt32(Request.Form.Get("idtalla"));
            int idProducto = Convert.ToInt32(Request.Form.Get("idproducto"));

            stock = tallaModel.BuscarStock(idTalla,idProducto);

            return Json(stock);
        }

    }
}