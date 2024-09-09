using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.Login
{
    public class FilterLoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su usuario")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su contraseña")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string PasswordNueva { get; set; }
        public string PasswordNuevaRepetida { get; set; }
    }
}