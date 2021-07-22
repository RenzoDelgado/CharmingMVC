using MVC_Charming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        DeliveryModel DeliveryModel = new DeliveryModel();
        public ActionResult Envio()
        {
            DeliveryModel modal = new DeliveryModel();
            UsuarioModel usus = new UsuarioModel();
            int ID = Convert.ToInt32(Session["Usuario"]);
            ViewBag.Usu = usus.BuscarUID(ID);

            DistritoModel distmo = new DistritoModel();
            List<Distrito> lstDistrito = distmo.ListarDistrito();
            ViewBag.ListaDist = lstDistrito;

            List<Producto> listaResumen = new List<Producto>();
            Dictionary<int, int[]> listaCarrito = (Dictionary<int, int[]>)Session["ListaCarrito"];

            foreach (var producto in listaCarrito)
            {
                Producto objProducto = new Producto();
                objProducto = modal.BuscarxId(producto.Key);
                listaResumen.Add(objProducto);
            }

            ViewBag.listaResumen = listaResumen;

            return View();
        }


        public ActionResult GuardarDelivery()
        {
 
            return RedirectToAction("Pagos", "Pay");
        }

        public JsonResult TraerUsuarioDatos()
        {
            int idUsuario = Convert.ToInt32(Request.Form.Get("idUsuario"));
            Usuario objUsuario = DeliveryModel.BuscarUsuarioxID(idUsuario);
            return Json(new { nombre = objUsuario.NombreU, apellido = objUsuario.Apellido, direccion = objUsuario.Direccion, telefono = objUsuario.Celular, distritos=objUsuario.distrito.idDistrito});
        }
    }
}