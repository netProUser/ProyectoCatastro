using MSI.Catastros.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSI.Catastros.Web
{
    public static class VariablesWeb
    {
        /// <summary>
        /// codigo de usuario
        /// </summary>
        public static string IdUsuarioIntento
        {
            get
            {
                if (HttpContext.Current.Session["idUsuarioIntento"] != null)
                {
                    return HttpContext.Current.Session["idUsuarioIntento"].ToString();
                }
                return string.Empty;
            }

            set
            {
                HttpContext.Current.Session["idUsuarioIntento"] = value;
            }
        }
        /// <summary>
        /// entidad usuario
        /// </summary>
        public static SEG_USUARIO Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    return (SEG_USUARIO)HttpContext.Current.Session["Usuario"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }
        public static List<SEG_OPCION> ListaOpciones
        {
            get
            {
                if (HttpContext.Current.Session["oListaOpciones"] != null)
                {
                    return (List<SEG_OPCION>)HttpContext.Current.Session["oListaOpciones"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["oListaOpciones"] = value;
            }
        }
        /// <summary>
        /// codigo de perfil autenticado
        /// </summary>
        public static string CodigoPerfil
        {
            get
            {
                if (HttpContext.Current.Session["CodigoPerfil"] != null)
                {
                    return HttpContext.Current.Session["CodigoPerfil"].ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["CodigoPerfil"] = value;
            }
        }
        /// <summary>
        /// nombre de perfil autenticado
        /// </summary>
        public static string NombrePerfil
        {
            get
            {
                if (HttpContext.Current.Session["NombrePerfil"] != null)
                {
                    return HttpContext.Current.Session["NombrePerfil"].ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["NombrePerfil"] = value;
            }
        }
        public static string NombrePersona
        {
            get
            {
                if (HttpContext.Current.Session["NombrePersona"] != null)
                {
                    return HttpContext.Current.Session["NombrePersona"].ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["NombrePersona"] = value;
            }
        }


        public static string Estatico
        {
            get
            {
                if (HttpContext.Current.Session["Estatico"] != null)
                {
                    return HttpContext.Current.Session["Estatico"].ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["Estatico"] = value;
            }
        }
        /// <summary>
        /// contador de session
        /// </summary>
        public static int ContadorSesiones
        {
            get
            {
                if (HttpContext.Current.Session["SesionesErradas"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["SesionesErradas"].ToString());
                }
                return 0;
            }
            set
            {
                HttpContext.Current.Session["SesionesErradas"] = value;
            }
        }
        public static string CodAreaUsuario
        {
            get
            {
                if (HttpContext.Current.Session["CodAreaUsuario"] != null)
                {
                    return HttpContext.Current.Session["CodAreaUsuario"].ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["CodAreaUsuario"] = value;
            }
        }
    }
}