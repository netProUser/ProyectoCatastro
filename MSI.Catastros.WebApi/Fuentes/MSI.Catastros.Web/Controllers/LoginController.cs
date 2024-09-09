using MSI.Catastros.Web.Filters;
using MSI.Catastros.Web.Funcionalidad.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP = MSI.Catastros.Helpers;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;
using System.Web.Security;
using System.Configuration;

namespace MSI.Catastros.Web.Controllers
{
    [LogActionAttribute]
    [LogExceptionAttribute]
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        //[HttpPost]
        public ActionResult Index(string ReturnUrl)
        {
            FormsAuthentication.SignOut();
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                ViewBag.ReturnUrl = "";
            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
            }
            return View(new FilterLoginViewModel());
        }
        public ActionResult Autenticate(FilterLoginViewModel request, string ReturnUrl)
        {
            //try
            //{
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                ReturnUrl = FormsAuthentication.DefaultUrl;
            }
            if (!ModelState.IsValid)
            {
                //return View("Index", request);
                request.Password = string.Empty;
                ViewBag.ReturnUrl = ReturnUrl;
                return View("Index", request);
            }

            //request.Password = "e10adc3949ba59abbe56e057f20f883e";// Crypto.GetMd5(request.Password);
            request.Password = Crypto.GetMd5(request.Password);
            //request.Password = Crypto.EncriptarDato(request.Password);
            //request.Password = "e10adc3949ba59abbe56e057f20f883e";
            string URLAnterior = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["redireccionar"];
            if (URLAnterior != null)
            {
                ReturnUrl = URLAnterior;
            }
            BE.SEG_USUARIO entQuery = new BE.SEG_USUARIO()
            {
                CODUSUARIO = request.UserName,
                TXTPASSWORD = request.Password,
                CODSISTEMA = ConfigurationManager.AppSettings["CODSISTEMA"]
            };

            BE.SEG_USUARIO entSEG_RETORNO = new BL.SEG_USUARIO().ValidarAcceso(entQuery);
            //BE.SEG_USUARIO entSEG_RETORNO = new BE.SEG_USUARIO() { CODUSUARIO = "NCUPE", CODPERSONA = "00001285" };
            if (entSEG_RETORNO != null)
            {
                VariablesWeb.ListaOpciones = new BL.SEG_USUARIO().CargarOpciones(entQuery).ToList();
                VariablesWeb.Usuario = entSEG_RETORNO;
                VariablesWeb.IdUsuarioIntento = entSEG_RETORNO.CODUSUARIO;
                VariablesWeb.NombrePerfil = entSEG_RETORNO.NombrePerfil;
                VariablesWeb.CodigoPerfil = entSEG_RETORNO.CodigoPerfil;
                VariablesWeb.NombrePersona = entSEG_RETORNO.NombrePersona;
                VariablesWeb.CodAreaUsuario = entSEG_RETORNO.CodAreaUsuario;
                //foreach (var item in VariablesWeb.ListaOpciones)
                //{
                //    VariablesWeb.Usuario = entSEG_RETORNO;
                //    VariablesWeb.IdUsuarioIntento = entSEG_RETORNO.CODUSUARIO;
                //    VariablesWeb.NombrePerfil = item.NombrePerfil;
                //    VariablesWeb.CodigoPerfil = item.CodigoPerfil;
                //    VariablesWeb.NombrePersona = item.NombrePersona;
                //    break;
                //}
                FormsAuthentication.SetAuthCookie(entSEG_RETORNO.CODUSUARIO.ToString(), true);
                //FormsAuthentication.(entQuery.CODUSUARIO, entQuery.TXTPASSWORD);
                return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario y/o Contraseña incorrecta.");
                request.Password = string.Empty;
                ViewBag.ReturnUrl = ReturnUrl;
                return View("Index", request);
            }
            //}
            //catch (Exception e)
            //{
            //    string mensajeError;
            //    mensajeError = e.Message;
            //    ModelState.AddModelError(string.Empty, mensajeError);
            //    return View("Index", request);
            //}
        }
        public ActionResult CambiarContrasena(FilterLoginViewModel model)
        {
            BE.SEG_USUARIO entQueryContraseña = new BE.SEG_USUARIO()
            {
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                TXTPASSWORD = Crypto.GetMd5(model.Password),
                TXTPASSWORDNUEVA = Crypto.GetMd5(model.PasswordNueva)
            };

            BE.SEG_USUARIO  entSIC_RETORNO_COLINDANTE = new BL.SEG_USUARIO().CambiarContraseña(entQueryContraseña);

            if(entSIC_RETORNO_COLINDANTE != null)
            {
                return Json(new { success = true, responseText = "Cambio de Contraseña Exitoso" });
            }
            else
            {
                return Json(new { success = true, responseText = "Contraseña Invalida" });
            }
           
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return View("Index");
        }
    }
}