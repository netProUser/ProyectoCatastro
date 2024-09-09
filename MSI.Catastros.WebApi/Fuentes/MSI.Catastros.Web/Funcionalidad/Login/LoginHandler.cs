using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Sockets;
using System.Configuration;


namespace MSI.Catastros.Web.Funcionalidad.Login
{
    public class LoginHandler
    {
        //public Nullable<bool> CambiarContraseña(FilterLoginViewModel itemLogin)
        //{
        //    BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
        //    entSIC_RETORNO_COLINDANTE.Ok = false;



        //    BE.SEG_USUARIO entQueryContraseña = new BE.SEG_USUARIO();

        //    entQueryContraseña.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
        //    entQueryContraseña.TXTPASSWORD = Crypto.GetMd5(itemLogin.Password);
        //    entQueryContraseña.TXTPASSWORDNUEVA = Crypto.GetMd5(itemLogin.PasswordNueva);
        //    entSIC_RETORNO_COLINDANTE = new BL.SEG_USUARIO().CambiarContraseña(entQueryContraseña);
        //    return entSIC_RETORNO_COLINDANTE.;
        //}
    }
}