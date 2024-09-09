using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSI.Catastros.Utiles;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Configuration;

namespace MSI.Catastros.Web.Funcionalidad.PrimeraAsignacion
{
    public class PrimeraAsignacionHandler
    {
        /// <summary>
        /// Reotnar listado de Tipo de solicitante
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoTipoSolicitud()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoSolicitud();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoTipoDocumento()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDocumento();
            var lisDataQuery = new List<SelectListItem>();
            //foreach (var item in lisQuery)
            //{
            //    lisDataQuery.Add(new SelectListItem
            //    {
            //        Value = item.CODPARAMETRO,
            //        Text = item.TXTDESCRIPCION
            //    });
            //}
            lisDataQuery.Add(new SelectListItem { Value = "DS", Text = "DOCUMENTO SIMPLE" });
            lisDataQuery.Add(new SelectListItem { Value = "EX", Text = "EXPEDIENTE" });
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoTipoProcedimientoAsig()
        {
            var lisDataQuery = new List<SelectListItem>();
            //PROCEDIMIENTOS DISPONIBLES EN PRIMERA ASIGNACIÓN: 01, 02
            BE.SIC_TIPPROCED query1 = new BL.SIC_TIPPROCED().Recuperar(new BE.SIC_TIPPROCED() { CODTIPPROC = "01" });
            BE.SIC_TIPPROCED query2 = new BL.SIC_TIPPROCED().Recuperar(new BE.SIC_TIPPROCED() { CODTIPPROC = "02" });

            lisDataQuery.Add(new SelectListItem { Value = query1.CODTIPPROC, Text = query1.TXTDESCPRO });
            lisDataQuery.Add(new SelectListItem { Value = query2.CODTIPPROC, Text = query2.TXTDESCPRO });
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoTipoProcedimiento()
        {
            #region Obtener datos
            BE.SIC_TIPPROCED entQuery = new BE.SIC_TIPPROCED();
            
            IEnumerable<BE.SIC_TIPPROCED> lisQuery = new BL.SIC_TIPPROCED().Buscar(entQuery);
            #endregion

            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPPROC,
                    Text = item.TXTDESCPRO
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoAreaSolicitante()
        {
            return new List<SelectListItem> { };
        }

        public List<SelectListItem> ListadoActividad()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoActividad();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoResponsable()
        {
            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(new BE.SIC_TABPROCE() {CODCARCAT = VariablesWeb.CodigoPerfil, CODTIPPROC = "01" });
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODUSUARIO,
                    Text = item.TXTNOMBRES
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoAcciones()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoAccion();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                });
            }
            return lisDataQuery;
        }

        public PrimeraAsignacionViewModel BuscarPrimeraAsignacion(PrimeraAsignacionViewModel PrimeraAsignacionBuscar)
        {
            BE.SIC_SOLICITUD entQuerySol = new BE.SIC_SOLICITUD() { CODNUMESOLI = PrimeraAsignacionBuscar.NumeroSolicitud, CODTIPOSOLI = PrimeraAsignacionBuscar.CodigoTipoSolicitud, CODANOSOLI = System.DateTime.Now.Year.ToString(), CODTIPODOC = PrimeraAsignacionBuscar.CodigoTipoDocumento };
            BE.SIC_SOLICITUD querySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySol);

            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = PrimeraAsignacionBuscar.CodigoTipoSolicitud;
            entQuery.CODNUMESOLI = PrimeraAsignacionBuscar.NumeroSolicitud;
            entQuery.CODRESPRECIBE = VariablesWeb.Usuario.CODUSUARIO;
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            entQuery.CODTIPODOC = PrimeraAsignacionBuscar.CodigoTipoDocumento;
            entQuery.CODCORRSEG = "0";
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);
            if (query == null )
            {
                query = new BE.SIC_SOLISEGUI();
                querySol = new BE.SIC_SOLICITUD();
                if(query.CODNUMESOLI == null) {
                    query.CODRESPENVIA = "A";
                }
                
            }
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new PrimeraAsignacionViewModel();
            if (query.CODRESPENVIA == null)
            {
                if (PrimeraAsignacionBuscar.CodigoTipoSolicitud == "010001")
                {
                    BE.PGD_TRAMITE_EXT entQueryEx = new BE.PGD_TRAMITE_EXT() { TXTTIPODOC = PrimeraAsignacionBuscar.CodigoTipoDocumento, TXTNRODOC = PrimeraAsignacionBuscar.NumeroSolicitud };
                    BE.PGD_TRAMITE_EXT srcQueryEx = new BL.PGD_TRAMITE_EXT().Consulta(entQueryEx);
                    if (srcQueryEx != null)
                    {
                        if (srcQueryEx.FOLIO != null) dataQuery.Folio = Convert.ToInt32(srcQueryEx.FOLIO);
                    }
                }
                else if (PrimeraAsignacionBuscar.CodigoTipoSolicitud == "010002") 
                {
                    BE.PGD_TRAMITE_INT entQueryInt = new BE.PGD_TRAMITE_INT() { VTIPO_DOCUMENTO = PrimeraAsignacionBuscar.CodigoTipoDocumento, VNRODOC = PrimeraAsignacionBuscar.NumeroSolicitud + "-" + System.DateTime.Now.Year.ToString() + "-" + "1220" };
                    BE.PGD_TRAMITE_INT srcQueryInt = new BL.PGD_TRAMITE_INT().Consulta(entQueryInt);
                    if (srcQueryInt != null) {
                        if (srcQueryInt.NUMFOLIO != null) dataQuery.Folio = srcQueryInt.NUMFOLIO;
                    }
                } 
                else 
                {
                    dataQuery.Folio = query.NUMFOLIOS;
                }

                if (query.CODANOSOLI != null) {
                    dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
                    dataQuery.NumeroSolicitud = query.CODNUMESOLI;
                    dataQuery.FechaRecepcion = query.FECRECEPCION;
                    dataQuery.Periodo = query.CODANOSOLI;
                    dataQuery.Correlativo = query.CODCORRSEG;
                    dataQuery.CodigoAccion = query.CODACCION;
                    dataQuery.CodigoActividad = query.CODACTIVIDAD;
                    dataQuery.CodigoAreaSolicitante = querySol.CODAREASOLI;
                    dataQuery.IdRef = querySol.ID_REF;
                    dataQuery.NombreTipoDocumento = (querySol.CODTIPODOC == "REQI") ? "REQUERIMIENTO INTERNO" : PrimeraAsignacionBuscar.NombreTipoDocumento;
                    dataQuery.CodigoTD = querySol.CODTIPODOC;
                    dataQuery.NombreTipoSolicitud = "CATASTRAL";
                    dataQuery.NombreAreaSolicitante = "SUB GERENCIA DE PLANEAMIENTO URBANO Y CATASTRO";
                }
            }
            dataQuery.ListTipoSolicitud = new PrimeraAsignacionHandler().ListadoTipoSolicitud();
            dataQuery.ListTipoProcedimiento = new PrimeraAsignacionHandler().ListadoTipoProcedimiento();
            dataQuery.ListActividad = new PrimeraAsignacionHandler().ListadoActividad();
            dataQuery.ListAccion = new PrimeraAsignacionHandler().ListadoAcciones();
            dataQuery.ListAsignarResponsable = new PrimeraAsignacionHandler().ListadoResponsable();
            
            #endregion
            return dataQuery;
        }

        public Nullable<bool> ProcesarAsignacion(PrimeraAsignacionViewModel PrimeraAsignacion)
        {
            #region Asignar a la Entidad
            if(PrimeraAsignacion.CodigoTipoSolicitud == "010001")
            {
                BE.PGD_TRAMITE_EXT entQueryExt = new BE.PGD_TRAMITE_EXT()
                {
                    VTIPO = 0,
                    VTIPODESTINO = 0,
                    VID_REF = PrimeraAsignacion.IdRef,
                    VREMITE = @ConfigurationManager.AppSettings["CODAREA"],
                    VPERREM = VariablesWeb.IdUsuarioIntento,
                    VRECIBE = @ConfigurationManager.AppSettings["CODAREA"],
                    VTIPREC = "1",
                    VPERREC = PrimeraAsignacion.CodigoResponsable,
                    VOBSERV = PrimeraAsignacion.Observaciones,
                    VFECING = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VFOLIOS = "0",
                    VCODACT2 = PrimeraAsignacion.CodigoActividad,
                    VCODACC2 = PrimeraAsignacion.CodigoAccion
                };
             //   BE.SIC_RETORNO entSIC_RETORNO_EXT = new BL.PGD_TRAMITE_EXT().Grabar(entQueryExt);
            }
            if (PrimeraAsignacion.CodigoTipoSolicitud == "010002")
            {
                BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                {
                    VTIPO = 0,
                    VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VID = PrimeraAsignacion.IdRef,
                    VTIPO_DOCUMENTO = PrimeraAsignacion.CodigoTD,
                    VUSUARIO = VariablesWeb.IdUsuarioIntento,
                    VOBSERVACION = PrimeraAsignacion.Observaciones,
                    VUSUARIO_AREA = @ConfigurationManager.AppSettings["CODAREA"],          //AREA QUE REMITE
                    VCONTRIBUYENTE = "",
                    VPAGINAS = PrimeraAsignacion.Folio,
                    VREQRPTA = 0,
                    VFECLIMRPTA = null,
                    VNRODOC = PrimeraAsignacion.NumeroSolicitud,
                    VCOD_ACTIVIDAD = PrimeraAsignacion.CodigoActividad,
                };
                BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().Grabar(entQueryExt);
            }
            if (PrimeraAsignacion.CodigoTipoSolicitud == "010003") 
            {
                PrimeraAsignacion.CodigoTipoDocumento = "REQI";
            }
            

            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = PrimeraAsignacion.CodigoTipoSolicitud,
                CODNUMESOLI = PrimeraAsignacion.NumeroSolicitud,
                CODANOSOLI = PrimeraAsignacion.Periodo,
                CTIPODOCUMENTO = PrimeraAsignacion.CodigoTD,
                CODRESPENVIA = VariablesWeb.IdUsuarioIntento,
                CODRESPRECIBE = PrimeraAsignacion.CodigoResponsable,

                FECENVIO = System.DateTime.Now,
                TXTOBSERVACION = PrimeraAsignacion.Observaciones,
                TXTPUESTORECEPCION = PrimeraAsignacion.PuestoResponsable,
                TXTAREASOLICITANTE = PrimeraAsignacion.NombreAreaSolicitante,
                CODACCION = PrimeraAsignacion.CodigoAccion,
                CODACTIVIDAD = PrimeraAsignacion.CodigoActividad,
                NUMFOLIOS = PrimeraAsignacion.Folio,
                CODTIPPROC = PrimeraAsignacion.CodigoTipoProcedimiento,
               
                // Los tipos de proc en Primera Asignacion son PRIMASIG-01 Y ANALISATEN-02
                // Y los estados correspondientes comparten el mismo codigo.
                CODESTATENCION = PrimeraAsignacion.CodigoTipoProcedimiento,
                CODCARCAT = VariablesWeb.CodigoPerfil,
                // CARGO 02 - ANALISTA
                CODCARCATE = "02",
                CODESTATENCIONE = "00",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLISEGUI().Grabar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;

        }
    }
}