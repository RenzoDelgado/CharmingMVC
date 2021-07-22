using MVC_Charming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Charming.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        UsuarioModel modelo = new UsuarioModel();
        public ActionResult Login()
        {


            UsuarioModel usm = new UsuarioModel();

            Usuario usuario = new Usuario();
            usuario.NombreU = Request.Form["Nombre"];
            usuario.Apellido = Request.Form["Apellido"];
            usuario.FechaNaci = Convert.ToDateTime(Request.Form["Fecha"]);
            usuario.Dni = Request.Form["DNI"];
            usuario.Direccion = Request.Form["Direccion"];

            Distrito dist = new Distrito();
            dist.idDistrito = Convert.ToInt32(Request.Form["Distrito"]);
            usuario.distrito = dist;

            usuario.Celular = Request.Form["Celular"];
            usuario.Correo = Request.Form["Correo"];
            usuario.Contrasena = Request.Form["Contrasena"];

            String pass1 = usuario.Contrasena = Request.Form["Contrasena"];
            String pass2 = usuario.Contrasena = Request.Form["ContrasenaRepit"];

            if (pass1 == pass2)
            {
                usm.Guardar(usuario);

            }


            return View();
        }
        public ActionResult Autenticacion()
        {
            Usuario usu = new Usuario();
            UsuarioModel usum = new UsuarioModel();
            string correo = null;
            string password = null;
            correo = Request.Form["correo"];
            password = Request.Form["pass"];

            if (correo.Length > 0 && password.Length > 0)
            {
                var ValidLogin = modelo.Login(correo, password);
                if (ValidLogin == true)
                {
                    usu = usum.BuscarEmail(correo);
                    Session["Usuario"] = usu.IdUsuario;

                    Dictionary<int,int[]> listaCarrito = new Dictionary<int,int[]>();
                    Session["ListaCarrito"] = listaCarrito;

                    ViewBag.logeado = "Autenticación Correcta";
                    return RedirectToAction("UsersSection", "User");
                }
                else
                {
                    ViewBag.error = "Autenticación Incorrecta";
                }
            }

            return View("Login");
        }


    }
}
