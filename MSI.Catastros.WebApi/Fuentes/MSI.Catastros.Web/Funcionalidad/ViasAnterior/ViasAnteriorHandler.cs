using MSI.Catastros.Web.Funcionalidad.Vias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Globalization;

namespace MSI.Catastros.Web.Funcionalidad.ViasAnterior
{
    public class ViasAnteriorHandler
    {
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

        public BE.SIC_RETORNO ProcesarViaAnterior(RegistroViaAnteriorViewModel RegistroVias)
        {
            #region Asignar a la Entidad
            BE.SIC_VIASANTE entQuery = new BE.SIC_VIASANTE()
            {
                CODVIAANTE = RegistroVias.CodigoVia,
                CODVIA = RegistroVias.CodigoVia,
                TXTTIPOVIAANTE = RegistroVias.DesTipoViaAnterior,
                TXTVIAANTE = RegistroVias.DesViaAnterior,
                TXTNORMATIVA = RegistroVias.Normativa,
                FECINICIO = RegistroVias.FechaInicio,
                FECFIN= RegistroVias.FechaFinal,
                CODCORVIA = RegistroVias.CodigoCorrViaAnte,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            BE.SIC_RETORNO entSIC_RETORNO_VAL;

            

            switch (RegistroVias.Estado)
            {
                case 1: entSIC_RETORNO_VAL = new BL.SIC_VIASANTE().ValidarFechas(entQuery);
                    if (entSIC_RETORNO_VAL.NoMENSAJE != -20008)
                    {
                        entSIC_RETORNO = new BL.SIC_VIASANTE().Grabar(entQuery);
                    }
                    else {
                        entSIC_RETORNO = new BE.SIC_RETORNO();    
                        entSIC_RETORNO.Ok = false;
                        entSIC_RETORNO.MENSAJE = "Verificar fechas, periodos ya registrados";
                    } break;
                case 2: entSIC_RETORNO_VAL = new BL.SIC_VIASANTE().ValidarFechasActualizar(entQuery);
                    if (entSIC_RETORNO_VAL.NoMENSAJE != -20008) 
                    { 
                        entSIC_RETORNO = new BL.SIC_VIASANTE().Actualizar(entQuery);
                    } else {
                        entSIC_RETORNO = new BE.SIC_RETORNO();    
                        entSIC_RETORNO.Ok = false;
                        entSIC_RETORNO.MENSAJE = "Verificar fechas, periodos ya registrados";
                    }
                    //entSIC_RETORNO = new BL.SIC_VIASANTE().Actualizar(entQuery);
                    break;
                default: entSIC_RETORNO = new BL.SIC_VIASANTE().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO;

        }

        public List<ViaAnteriorViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarViasAnteriorViewModel FiltroDetalleVias)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            //string ordenar = "CODVIA, NUMCUADRA";
            string ordenar = "";
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroDetalleVias);
            var resultado = new List<ViaAnteriorViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new ViaAnteriorViewModel
                {
                    CodigoCorrViaAnte = s.CODCORVIA,
                    CodigoVia = s.CODVIA,
                    DescVia = s.TXTVIA,
                    DesTipoViaAnterior = s.TXTTIPOVIAANTE,
                    DesViaAnterior= s.TXTVIAANTE,
                    Normativa = s.TXTNORMATIVA,
                    txtFechaInicio =  s.FECINICIO.HasValue ? s.FECINICIO.Value.ToString("dd/MM/yyyy") : string.Empty,
                    txtFechaFinal = s.FECFIN.HasValue ? s.FECFIN.Value.ToString("dd/MM/yyyy") : string.Empty,
                });
            }
            return (resultado == null) ? new List<ViaAnteriorViewModel>() : resultado;
        }

        public ICollection<BE.SIC_VIASANTE> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarViasAnteriorViewModel FiltarDetalleVia)
        {
            BE.SIC_VIASANTE entQuery = new BE.SIC_VIASANTE();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            /*if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);*/
            entQuery = new BL.SIC_VIASANTE().BuscarInt(entQuery);
            entQuery.CODVIA = FiltarDetalleVia.ParamSelectVia;
            /*if (FiltarDetalleVia.ParamCuadra != null)
                entQuery.NUMCUADRA = Convert.ToInt32(FiltarDetalleVia.ParamCuadra);*/
            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            // entQuery.TXTSECTOR = FiltroSectores.NombreSector;
            entQuery.ORDEN = ordenar;
            var srcQuery = new BL.SIC_VIASANTE().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }

        public RegistroViaAnteriorViewModel BuscarViaAnterior(string idCorViaAnte, string idVia)
        {
            #region Obtener datos
            BE.SIC_VIASANTE entQuery = new BE.SIC_VIASANTE();
            entQuery.CODCORVIA = idCorViaAnte;
            entQuery.CODVIA = idVia;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
            BE.SIC_VIASANTE query = new BL.SIC_VIASANTE().Recuperar(entQuery);

            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroViaAnteriorViewModel();
            dataQuery.CodigoCorrViaAnte = query.CODCORVIA;
            dataQuery.CodigoVia = query.CODVIA;
            dataQuery.DesTipoViaAnterior = query.TXTTIPOVIAANTE;
            dataQuery.DesViaAnterior = query.TXTVIAANTE;
            dataQuery.Normativa = query.TXTNORMATIVA;
            dataQuery.FechaInicio = query.FECINICIO;
            dataQuery.FechaFinal = query.FECFIN;
            // dataQuery.TipoHabilitacion = lisTipoHabilitacion;
            #endregion
            return dataQuery;
        }

    }
}