using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using MSI.Catastros.Web.Funcionalidad.Parametros;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.Vias;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Web.Mvc;


namespace MSI.Catastros.Web.Funcionalidad.DetalleVias
{
    public class DetalleViasHandler
    {
        public List<DetalleViaViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarDetalleViasViewModel FiltroDetalleVias)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = "CODVIA, NUMCUADRA";
            FiltroDetalleVias.ParamCuadra = FiltroDetalleVias.ParamCuadra == "0" ? null : FiltroDetalleVias.ParamCuadra;
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroDetalleVias);
            var resultado = new List<DetalleViaViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new DetalleViaViewModel
                {
                    CodigoVia = s.CODVIA,
                    DescVia = s.TXTVIA,
                    NumCuadra = s.NUMCUADRA,
                    CodigoDetalleVia = s.CODCORRVIADETA,
                    txtMedidaViaNormativa = Decimal4(s.NUMANCHVIA.ToString()),
                    txtMedidaVia = s.CODANCHVIA == "010001" ? Decimal4(s.NUMMEDINI.ToString()) : Decimal4(s.NUMMEDINI.ToString()) + " - " + Decimal4(s.NUMMEDFIN.ToString()),
                    AnchoVia = s.TXTANCHOVIA
                });
            }
            return (resultado == null) ? new List<DetalleViaViewModel>() : resultado;
        }
        public ICollection<BE.SIC_VIADETALLE> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarDetalleViasViewModel FiltarDetalleVia)
        {
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);
            entQuery = new BL.SIC_VIADETALLE().BuscarInt(entQuery);
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);
            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            // entQuery.TXTSECTOR = FiltroSectores.NombreSector;
            entQuery.ORDEN = ordenar;
            var srcQuery = new BL.SIC_VIADETALLE().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }



        public ICollection<BE.SIC_VIADETALLE> ListarGrid1(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount, FiltrarDetalleViasViewModel FiltarDetalleVia)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            // search the dbase taking into consideration table sorting and paging
            var result = BuscarDB1(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount, FiltarDetalleVia);
            if (result == null)
            {
                // empty collection...
                return new List<BE.SIC_VIADETALLE>();
            }
            return result;
        }

        public ICollection<BE.SIC_VIADETALLE> BuscarDB1(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount, FiltrarDetalleViasViewModel FiltarDetalleVia)
        {
            // the example datatable used is not supporting multi column ordering
            // so we only need get the column order from the first column passed to us.        

            if (String.IsNullOrEmpty(searchBy))
            {
                // if we have an empty search then just order the results by Id ascending
                sortBy = "Id";
                sortDir = true;
            }
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = 5;
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);
            entQuery = new BL.SIC_VIADETALLE().BuscarInt(entQuery);

            entQuery.ORDEN = "CODVIA";
            if (take == 0)
            {
                take = 1;
            }
            entQuery.PAGINANUMERO = (skip / take == 0) ? 1 : (skip / take) + 1;
            entQuery.PAGINAREGISTROS = 5;
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);
            var srcQuery = new BL.SIC_VIADETALLE().Buscar(entQuery);

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            filteredResultsCount = entQuery.TOTALREGISTROS ?? default(int);
            totalResultsCount = entQuery.TOTALREGISTROS ?? default(int);

            return srcQuery;
        }

        public List<DetalleViaViewModel> BuscarDetalleVias(FiltrarDetalleViasViewModel FilterDetalleVia)
        {
            #region Obtener datos
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE();
            // entQuery.CODVIA = FilterDetalleVia.ParamCodigoVia;
            entQuery.NUMCUADRA = Convert.ToInt16(FilterDetalleVia.ParamCuadra);
            entQuery.CODVIA = FilterDetalleVia.ParamSelectVia;
            IEnumerable<BE.SIC_VIADETALLE> lisQuery = new BL.SIC_VIADETALLE().Buscar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<DetalleViaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new DetalleViaViewModel
                {
                    CodigoDetalleVia = item.CODCORRVIADETA,
                    CodigoVia = item.CODVIA,
                    DescVia = item.TXTVIA,
                    NumCuadra = item.NUMCUADRA,
                    MedidaViaNormativa = item.NUMANCHVIA
                });
            }
            #endregion

            return lisDataQuery;
        }

        public List<ParametrosViewModel> ListarParametosVias()
        {
            //ACA SE VA A CONSUMIR LOS SERVICIOS REST
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDeVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,
                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }

        public List<ParametrosViewModel> ListarParametosClaseVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().ClasificacionVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,
                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }

        public List<SelectListItem> ListarVias()
        {
            #region Obtener datos
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            // entQuery.CODVIA = id;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');

            IEnumerable<BE.SIC_VIA> lisQuery = new BL.SIC_VIA().Listar(entQuery);
            #endregion

            #region Asignar al ViewModel
            List<SelectListItem> lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODVIA,
                    Text = item.TXTTIPODEVIA + " - " + item.TXTVIA
                });
            }
            #endregion
            return lisDataQuery;
        }

        public Nullable<bool> ProcesarDetalleVias(RegistroDetalleViaViewModel RegistroVias)
        {
            #region Asignar a la Entidad
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE()
            {
                CODCORRVIADETA = RegistroVias.CodigoDetalleVia,
                CODVIA = RegistroVias.CodigoVia,
                NUMCUADRA = RegistroVias.NumCuadra,
                CODANCHVIA = RegistroVias.CodAnchoVia,
                NUMANCHVIA = RegistroVias.MedidaViaNormativa,
                NUMMEDINI = RegistroVias.MedidaInicial,
                NUMMEDFIN = RegistroVias.MedidaFinal,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (RegistroVias.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_VIADETALLE().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_VIADETALLE().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_VIADETALLE().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;

        }

        public List<DetalleViaViewModel> ListarDetalleViasCombo(string datos)
        {
            #region Obtener datos
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE();
            entQuery.CODVIA = datos;
            entQuery.ORDEN = "NUMCUADRA";
            IEnumerable<BE.SIC_VIADETALLE> lisQuery = new BL.SIC_VIADETALLE().Listar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<DetalleViaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new DetalleViaViewModel
                {
                    CodigoDetalleVia = item.CODCORRVIADETA,
                    NumCuadra = item.NUMCUADRA,
                    CodigoVia = item.CODVIA,
                    CodAnchoVia = item.CODANCHVIA,
                    MedidaViaNormativa = item.NUMANCHVIA,
                });
            }
            #endregion
            return lisDataQuery;
        }

        public RegistroDetalleViaViewModel BuscarDetalleVia(string idDetalle, string idVia)
        {
            #region Obtener datos
            BE.SIC_VIADETALLE entQuery = new BE.SIC_VIADETALLE();
            entQuery.CODCORRVIADETA = idDetalle;
            entQuery.CODVIA = idVia;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
            BE.SIC_VIADETALLE query = new BL.SIC_VIADETALLE().Recuperar(entQuery);

            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroDetalleViaViewModel();
            dataQuery.CodigoDetalleVia = query.CODCORRVIADETA;
            dataQuery.NumCuadra = query.NUMCUADRA;
            dataQuery.CodigoVia = query.CODVIA;
            dataQuery.CodAnchoVia = query.CODANCHVIA;
            dataQuery.MedidaViaNormativa = query.NUMANCHVIA;
            dataQuery.MedidaInicial = query.NUMMEDINI;
            dataQuery.MedidaFinal = query.NUMMEDFIN;
            // dataQuery.TipoHabilitacion = lisTipoHabilitacion;
            #endregion
            return dataQuery;
        }

        public string Decimal4(string numero)
        {
            if (numero.Contains("."))
            {
                int index = numero.IndexOf(".");
                string cad;

                if (index == 2)
                {
                    cad =  numero.Substring(numero.IndexOf("."), numero.Length - 2);
                } else
                {
                    cad = numero.Substring(numero.IndexOf("."), numero.Length - 1);
                }
                
                int falta = cad.Trim().Length;
                if (falta == 1)
                {
                    return numero + "0000";
                }
                else if (falta == 2)
                {
                    return numero + "000";
                }
                else if (falta == 3)
                {
                    return numero + "00";
                }
                else
                {
                    return numero;
                }
            } else {
                return numero + ".0000";
            }
        }
    }
}