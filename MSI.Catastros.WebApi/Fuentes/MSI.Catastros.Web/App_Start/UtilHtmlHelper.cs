using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.Web
{
    public static class UtilHtmlHelper
    {
        public static MvcHtmlString HelperMenu3(this HtmlHelper helper, List<SEG_OPCION> listaOpcion,
           string nombreLista)
        {

            var principal = new TagBuilder("ul");
            principal.AddCssClass("nav in");
            //principal.Attributes.Add("data-children", ".nav-item");
            //principal.AddCssClass("nav nav-pills nav-stacked");
            //principal.Attributes.Add("id", nombreLista);
            principal.Attributes.Add("id", "side-menu");

            if (listaOpcion == null || listaOpcion.Count() == 0)
            {
                return new MvcHtmlString(principal.ToString());
            }
            foreach (SEG_OPCION item in (from x in listaOpcion
                                         where x.eIdGrupoOpcion == "" && x.cEsVisible
                                         select x).OrderBy(t => t.eNroOrden).ToList())
            {
                var itemLista = new TagBuilder("li");
                itemLista.AddCssClass("sidebar-nav");
                TagBuilder link = new TagBuilder("a");
                //link.AddCssClass("nav-link ripple ");
                TagBuilder i = new TagBuilder("i");
                i.AddCssClass(item.Imagen);
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("fa arrow");
                //span.InnerHtml = item.uNombreOpcion;
                link.InnerHtml = i + item.uNombreOpcion + span.ToString();
                if ((from x in listaOpcion
                     where x.eIdGrupoOpcion == item.PK_eIdOpcion && x.cEsVisible
                     select x).OrderBy(t => t.eNroOrden).Count() > 0)
                {
                    link.AddCssClass("nav-link dropdown-toggle");
                    //link.Attributes.Add("data-toggle", "collapse");
                    link.Attributes.Add("data-target", "#" + item.PK_eIdOpcion.ToString());
                    //link.Attributes.Add("aria-expanded", "false");
                    //link.Attributes.Add("aria-controls", item.uNombreOpcion);
                    //link.Attributes.Add("title", item.uNombreOpcion);
                }


                UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                if (!string.IsNullOrEmpty(item.uDireccionOpcion) && item.uDireccionOpcion != "#")
                {
                    string[] ruta = item.uDireccionOpcion.Split('/');
                    switch (ruta.Count())
                    {
                        case 1:
                            link.Attributes["href"] = urlHelper.Action("Index", ruta[0]);
                            break;
                        case 2:
                            if (ruta[1].Split('?').Count() > 1)
                            {
                                link.Attributes["href"] = urlHelper.Action(ruta[1].Split('?')[0], ruta[0], RetornaObjetoParametros(ruta[1].Split('?')[1]));
                            }
                            else
                            {
                                link.Attributes["href"] = urlHelper.Action(ruta[1], ruta[0]);
                            }

                            break;
                        case 3:
                            if (ruta[2].Split('?').Count() > 1)
                            {
                                link.Attributes["href"] = urlHelper.Action(ruta[2].Split('?')[0], ruta[0] + "/" + ruta[1], RetornaObjetoParametros(ruta[2].Split('?')[1]));
                            }
                            else
                            {
                                link.Attributes["href"] = urlHelper.Action(ruta[2], ruta[0] + "/" + ruta[1]);
                            }

                            break;
                        default:
                            link.Attributes["href"] = item.uDireccionOpcion;
                            break;
                    }
                }
                else
                {
                    link.Attributes["href"] = "#";
                }
                itemLista.InnerHtml = link.ToString();

                LlenarOpcionMenu2(itemLista, item, listaOpcion, urlHelper);

                principal.InnerHtml += itemLista.ToString();
            }

            return new MvcHtmlString(principal.ToString());
        }
        private static void LlenarOpcionMenu2(TagBuilder itemLista, SEG_OPCION itemOpcion, List<SEG_OPCION> listaOpcion, UrlHelper urlHelper)
        {
            if ((from x in listaOpcion
                 where x.eIdGrupoOpcion == itemOpcion.PK_eIdOpcion && x.cEsVisible
                 select x).Count() > 0)
            {
                //itemLista.AddCssClass("dropdown-submenu");
                TagBuilder divSubMenu = new TagBuilder("ul");
                divSubMenu.Attributes.Add("id", itemOpcion.PK_eIdOpcion.ToString());
                divSubMenu.AddCssClass("nav nav-second-level collapse");
                //divSubMenu.Attributes.Add("role", "tabpanel");
                //divSubMenu.Attributes.Add("data-children", ".nav-item");
                /*
                TagBuilder divContentSubMenu = new TagBuilder("div");
                divContentSubMenu.AddCssClass("contentSubMenu");

                TagBuilder secundario = new TagBuilder("ul");
                secundario.AddCssClass("menuSecondary");
                */
                #region Llenado de SubMenus

                foreach (SEG_OPCION item in (from x in listaOpcion
                                             where x.eIdGrupoOpcion == itemOpcion.PK_eIdOpcion && x.cEsVisible
                                             orderby x.eNroOrden
                                             select x).ToList())
                {
                    var itemDetalle = new TagBuilder("li");
                    itemDetalle.AddCssClass("nav-item");
                    TagBuilder link = new TagBuilder("a");
                    TagBuilder span = new TagBuilder("span");
                    TagBuilder i = new TagBuilder("i");
                    span.InnerHtml = item.uNombreOpcion;
                    i.AddCssClass(item.Imagen);
                    link.InnerHtml = i + span.ToString();

                    link.AddCssClass("nav-link ripple ");
                    //link.InnerHtml = item.uNombreOpcion;

                    if ((from x in listaOpcion
                         where x.eIdGrupoOpcion == item.PK_eIdOpcion
                          && x.cEsVisible
                         select x).Count() > 0)
                    {
                        TagBuilder right = new TagBuilder("b");
                        right.AddCssClass("caret");
                        link.InnerHtml += " " + right.ToString();

                        link.AddCssClass("with-arrow collapsed");
                        itemDetalle.Attributes.Add("role", "tab");

                    }


                    if (!string.IsNullOrEmpty(item.uDireccionOpcion) && item.uDireccionOpcion != "#")
                    {
                        string[] ruta = item.uDireccionOpcion.Split('/');
                        switch (ruta.Count())
                        {
                            case 1:
                                link.Attributes["href"] = urlHelper.Action("Index", ruta[0]);
                                break;
                            case 2:
                                if (ruta[1].Split('?').Count() > 1)
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[1].Split('?')[0], ruta[0], RetornaObjetoParametros(ruta[1].Split('?')[1]));
                                }
                                else
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[1], ruta[0]);
                                }

                                break;
                            case 3:
                                if (ruta[2].Split('?').Count() > 1)
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[2].Split('?')[0], ruta[0] + "/" + ruta[1], RetornaObjetoParametros(ruta[2].Split('?')[1]));
                                }
                                else
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[2], ruta[0] + "/" + ruta[1]);
                                }
                                break;
                            default:
                                link.Attributes["href"] = item.uDireccionOpcion;
                                break;
                        }
                    }
                    else
                    {
                        link.Attributes["href"] = "#";
                    }
                    itemDetalle.InnerHtml += link.ToString();

                    LlenarOpcionMenu(itemDetalle, item, listaOpcion, urlHelper);

                    divSubMenu.InnerHtml += itemDetalle.ToString();
                    //                    secundario.InnerHtml += itemDetalle.ToString();
                }

                #endregion

                //              divContentSubMenu.InnerHtml += secundario.ToString();
                //            divSubMenu.InnerHtml += divContentSubMenu;
                itemLista.InnerHtml += divSubMenu.ToString();
            }
        }
        private static void LlenarOpcionMenu(TagBuilder itemLista, SEG_OPCION itemOpcion,
    List<SEG_OPCION> listaOpcion, UrlHelper urlHelper)
        {
            if ((from x in listaOpcion
                 where x.eIdGrupoOpcion == itemOpcion.PK_eIdOpcion && x.cEsVisible
                 select x).Count() > 0)
            {
                //itemLista.AddCssClass("dropdown-submenu");
                TagBuilder divSubMenu = new TagBuilder("ul");
                divSubMenu.AddCssClass("subMenuDHH");
                /*
                TagBuilder divContentSubMenu = new TagBuilder("div");
                divContentSubMenu.AddCssClass("contentSubMenu");

                TagBuilder secundario = new TagBuilder("ul");
                secundario.AddCssClass("menuSecondary");
                */
                #region Llenado de SubMenus

                foreach (SEG_OPCION item in (from x in listaOpcion
                                                where x.eIdGrupoOpcion == itemOpcion.PK_eIdOpcion && x.cEsVisible
                                                orderby x.eNroOrden
                                                select x).ToList())
                {
                    var itemDetalle = new TagBuilder("li");
                    TagBuilder link = new TagBuilder("a");
                    link.InnerHtml = item.uNombreOpcion;
                    if ((from x in listaOpcion
                         where x.eIdGrupoOpcion == item.PK_eIdOpcion
                          && x.cEsVisible
                         select x).Count() > 0)
                    {
                        TagBuilder right = new TagBuilder("i");
                        right.AddCssClass("fa fa-chevron-right floatRight");
                        link.InnerHtml += " " + right.ToString();
                    }


                    if (!string.IsNullOrEmpty(item.uDireccionOpcion) && item.uDireccionOpcion != "#")
                    {
                        string[] ruta = item.uDireccionOpcion.Split('/');
                        switch (ruta.Count())
                        {
                            case 1:
                                link.Attributes["href"] = urlHelper.Action("Index", ruta[0]);
                                break;
                            case 2:
                                if (ruta[1].Split('?').Count() > 1)
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[1].Split('?')[0], ruta[0], RetornaObjetoParametros(ruta[1].Split('?')[1]));
                                }
                                else
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[1], ruta[0]);
                                }

                                break;
                            case 3:
                                if (ruta[2].Split('?').Count() > 1)
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[2].Split('?')[0], ruta[0] + "/" + ruta[1], RetornaObjetoParametros(ruta[2].Split('?')[1]));
                                }
                                else
                                {
                                    link.Attributes["href"] = urlHelper.Action(ruta[2], ruta[0] + "/" + ruta[1]);
                                }
                                break;
                            default:
                                link.Attributes["href"] = item.uDireccionOpcion;
                                break;
                        }
                    }
                    else
                    {
                        link.Attributes["href"] = "#";
                    }
                    itemDetalle.InnerHtml += link.ToString();

                    LlenarOpcionMenu(itemDetalle, item, listaOpcion, urlHelper);

                    divSubMenu.InnerHtml += itemDetalle.ToString();
                }
                #endregion
                itemLista.InnerHtml += divSubMenu.ToString();
            }
        }
        private static RouteValueDictionary RetornaObjetoParametros(string parametro)
        {
            RouteValueDictionary rvd = new RouteValueDictionary();

            string[] parametros = parametro.Split('&');
            Dictionary<string, string> lista = new Dictionary<string, string>();
            foreach (string item in parametros)
            {
                rvd.Add(item.Split('=')[0], item.Split('=')[1]);            }
            return rvd;
        }
    }
}