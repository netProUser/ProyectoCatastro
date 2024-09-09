using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.SeguimientoSolicitud
{
    public class SeguimentoSolicitudHandler
    {
        public List<ReporteSeguimiento> ListadoSeguimiento(Int16 entTipoBusqueda, string tipoSolicitud, string entNroSolicitud, DateTime? FechaInicio, DateTime? FechaFin, string entAsunto, string entNombreTitular)
        {
            IEnumerable<BE.SIC_SOLICITUD> lisQuerys = new BL.SIC_SOLICITUD().Seguimiento(new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = tipoSolicitud,
                CODNUMESOLI = entNroSolicitud,
                FECSOLICITUD = FechaInicio,
                FECFINSOLICITUD = FechaFin,
                TXTASUNTO = entAsunto,
                TXTNOMBRETITULAR = entNombreTitular,
                //ORDEN = "4",
                PAGINANUMERO = 1,
                PAGINAREGISTROS = 10000,
            });
            var lisDataQuerys = new List<ReporteSeguimiento>();
            foreach (var item in lisQuerys)
            {

                var entidad = new ReporteSeguimiento();
                entidad.NroSolicitud = item.CODNUMESOLI;
                entidad.Asunto = item.TXTASUNTO;
                entidad.Titular = (item.TXTNOMBRETITULAR != null) ? item.TXTNOMBRETITULAR.Replace(";", " ") : "";
                entidad.TipoLlenado = item.TXTTIPOLLENADO;
                entidad.FechaRecepOriginal = item.FECSOLICITUD.HasValue ? item.FECSOLICITUD.Value.ToString("dd/MM/yyyy") : "";
                entidad.FechaLimite = item.FECLIMITE.HasValue ? item.FECLIMITE.Value.ToString("dd/MM/yyyy") : "";
                entidad.EstadoAtencion = item.TXTATENCIONACTUAL;
                //try
                //{
                IEnumerable<BE.SIC_SOLUNIDAD> queryResult = new BL.SIC_SOLUNIDAD().Buscar(new BE.SIC_SOLUNIDAD()
                {
                    CODTIPOSOLI = item.CODTIPOSOLI,
                    CODNUMESOLI = item.CODNUMESOLI,
                    CODANOSOLI = System.DateTime.Now.Year.ToString()
                });
                foreach (var items in queryResult)
                {
                    entidad.CodCatastral += items.CODDISTRITO + "" + items.CODSECTOR + "" + items.CODMANZANA + "" + items.CODLOTE + "" + items.CODEDIFICACION + "" + items.CODENTRADA + "" + items.CODPISO + "" + items.CODUNIDAD + "<br/>";
                }

                if (queryResult.Count() < 1)
                {
                    entidad.CodCatastral = "NO TIENE CODIGOS CATASTRALES ASIGNADOS";
                }
                //}
                //catch (Exception)
                //{
                //}

                //IEnumerable<BE.SIC_SOLISEGUI> entQuery = new BL.SIC_SOLISEGUI().Seguimiento(new BE.SIC_SOLISEGUI()
                //{
                //    CODNUMESOLI = item.CODNUMESOLI,
                //    CODANOSOLI = item.CODANOSOLI,
                //    CODTIPOSOLI = item.CODTIPOSOLI
                //});
                var estado = new List<string>();
                /*foreach (var itemss in entQuery)
                {

                }*/
                estado.Add(item.CODPARETA);
                entidad.Seguimiento = estado;
                lisDataQuerys.Add(entidad);
            }
            //////
            //var lisDataQuery = new List<ReporteSeguimiento>();
            //IEnumerable<BE.SIC_SOLISEGUI> entQuery = new BL.SIC_SOLISEGUI().Seguimiento(new BE.SIC_SOLISEGUI()
            //{
            //    CODNUMESOLI = entNroSolicitud,
            //    CODANOSOLI = DateTime.Now.Year.ToString()
            //    // CODTIPOSOLI= 
            //});
            //foreach (var item in entQuery)
            //{
            //    IEnumerable<BE.SIC_SOLICITUD> lisQuery = new BL.SIC_SOLICITUD().Seguimiento(new BE.SIC_SOLICITUD()
            //        {
            //            CODTIPOSOLI = item.CODTIPOSOLI,
            //            CODNUMESOLI = item.CODNUMESOLI,
            //            FECSOLICITUD = null,
            //            FECFINSOLICITUD = null,
            //            ORDEN = "1",
            //            PAGINANUMERO = 1,
            //            PAGINAREGISTROS = 1000,
            //        });
            //    var entidad = new ReporteSeguimiento();
            //    entidad.NroSolicitud = item.CODNUMESOLI;
            //    entidad.Asunto = item.TXTASUNTO;
            //    entidad.EstadoAtencion = item.TXTATENCIONACTUAL;
            //    var estado = new List<string>();
            //    foreach (var itemdet in lisQuery)
            //    {
            //        /*entidad.TipoLlenado = itemdet.CODTIPOLLENA;
            //        entidad.Titular = itemdet.TXTNOMBRETITULAR;
            //        entidad.FechaRecepOriginal = item.FECHALIMITE;
            //        entidad.FechaLimite = item.FECHALIMITE;*/
            //        estado.Add(itemdet.CODPARETA);
            //        //entidad.CodCatastral = itemdet.               
            //    }
            //    entidad.Seguimiento = estado;
            //    lisDataQuery.Add(entidad);
            //}


            return lisDataQuerys;
        }
        public List<DetalleSeguimientoViewModel> DetalleSeguimiento(string entNroSolicitud)
        {
            IEnumerable<BE.SIC_SOLICITUD> lisQuerys = new BL.SIC_SOLICITUD().Seguimiento(new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = null,
                CODNUMESOLI = entNroSolicitud,
                //FECSOLICITUD = FechaInicio,
                //FECFINSOLICITUD = FechaFin,
                ORDEN = "1",
                PAGINANUMERO = 1,
                PAGINAREGISTROS = 10000,
            });
            var lisDataQuerys = new List<DetalleSeguimientoViewModel>();
            foreach (var item in lisQuerys)
            {



                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new BL.SIC_SOLISEGUI().Seguimiento(new BE.SIC_SOLISEGUI()
                {
                    CODNUMESOLI = item.CODNUMESOLI,
                    CODANOSOLI = item.CODANOSOLI,
                    CODTIPOSOLI = item.CODTIPOSOLI
                });
                foreach (var det in entQuery)
                {
                    var entidad = new DetalleSeguimientoViewModel();
                    entidad.TipoSolicitud = det.TXTTIPOSOLICITUD;
                    entidad.TipoDocumento = det.TXTTIPODOCUMENTO;
                    entidad.AreaSolicitante = det.TXTAREASOLICITANTE;
                    entidad.FormularioProcedimiento = det.TXTNOMBREPROCEDIMIENTO;
                    //entidad.fechaAntecionAnterior= det.fecha
                    entidad.FechaRecepcion = det.FECRECEPCION.HasValue ? det.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "";
                    entidad.PuestoResponsable = det.TXTPUESTORECEPCION;
                    entidad.Responsable = det.TXTNOMBRERECEPCION;
                    entidad.TipoProcedimiento = det.TXTNOMBREPROCEDIMIENTO;
                    entidad.FechaLimiteInformeAnalista = det.FECLIMIANA.HasValue ? det.FECLIMIANA.Value.ToString("dd/MM/yyyy") : "";
                    entidad.FechaLimiteInspeccion = det.FECLIMITEI.HasValue ? det.FECLIMITEI.Value.ToString("dd/MM/yyyy") : "";
                    entidad.FechaLimiteActualizacion = det.FECLIMIACT.HasValue ? det.FECLIMIACT.Value.ToString("dd/MM/yyyy") : "";
                    entidad.NumeroInpesccion = det.TXTNROINSPECCION;
                    entidad.EstadoSeguimiento = det.CODPARETA;
                    lisDataQuerys.Add(entidad);
                }

            }
            return lisDataQuerys;
        }
    }
}