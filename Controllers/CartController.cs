using MVC_Charming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class CartController : Controller
    {
        ProductoModel productoModelo = new ProductoModel();
        // GET: Cart
        public ActionResult ShoppingCart()
        {
            UsuarioModel usus = new UsuarioModel();
            int ID = Convert.ToInt32(Session["Usuario"]);
            ViewBag.Usu = usus.BuscarUID(ID);


            Dictionary<int, int[]> listaCarrito = new Dictionary<int, int[]>();
            listaCarrito = (Dictionary<int, int[]>)Session["ListaCarrito"];

            List<Producto> listaProductos = new List<Producto>();

            if (listaCarrito == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (listaCarrito != null)
            {
                foreach (var lstc in listaCarrito)
                {
                    Producto producto = new Producto();
                    producto = productoModelo.BuscarxId(lstc.Key);
                    listaProductos.Add(producto);
                }

                ViewBag.ListaProductos = listaProductos;
                return View();

            }

            return View();
        }

        public ActionResult AgregarCarrito()
        {
            if (Session["Usuario"] == null)
             {

            }
            else if (Session["Usuario"] != null)
            {
                int[] datos = new int[2];

                int idproducto = Convert.ToInt32(Request.Form.Get("idproducto"));
                int cantidad = Convert.ToInt32(Request.Form.Get("cantidad"));
                int idtalla = Convert.ToInt32(Request.Form.Get("idtalla"));

                Dictionary<int, int[]> listaCarrito = new Dictionary<int, int[]>();
                listaCarrito = (Dictionary<int, int[]>)Session["ListaCarrito"];

                datos[0] = cantidad;
                datos[1] = idtalla;

                try
                {
                    listaCarrito.Add(idproducto, datos);
                }
                catch (Exception)
                {
                    return Json(false);
                }
           
                Session["ListaCarrito"] = listaCarrito;
            }

            return Json(true);
        }

        public ActionResult EliminarProducto()
        {
            int idproducto = Convert.ToInt32(Request.Form.Get("idproducto"));

            Dictionary<int, int[]> listaCarrito = new Dictionary<int, int[]>();
            listaCarrito = (Dictionary<int, int[]>)Session["ListaCarrito"];
            listaCarrito.Remove(idproducto);

            Session["ListaCarrito"] = listaCarrito;

            return RedirectToAction("ShoppingCart","Cart");

        }

    }
}

