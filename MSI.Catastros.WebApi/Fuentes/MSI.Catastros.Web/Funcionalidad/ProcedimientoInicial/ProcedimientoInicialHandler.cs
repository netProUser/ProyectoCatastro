using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using System.Configuration;

namespace MSI.Catastros.Web.Funcionalidad.ProcedimientoInicial 
{
    public class ProcedimientoInicialHandler
    {
        /// <summary>
        /// Reotnar listado de Tipo de solicitante
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoTipoProcedimiento()
        {
            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODCARCAT = VariablesWeb.CodigoPerfil;
            TABPROCE.CODESTATENCIONE = "01";

            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(TABPROCE);
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

        public List<SelectListItem> ListadoTipoRequerimiento()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoRequerimiento();
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

        public List<SelectListItem> ListadoTipoProcedimiento(string idEstAteAnte)
        {
            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODCARCAT = VariablesWeb.CodigoPerfil;
            TABPROCE.CODESTATENCIONE = idEstAteAnte;

            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(TABPROCE);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPPROC,
                    Text = item.TXTDESCPRO
                });
            }

            var distinctList = lisDataQuery.GroupBy(x => x.Value)
                         .Select(g => g.First())
                         .ToList();

            return distinctList;
        }

        public List<SelectListItem> ListadoAsignarResponsable(string idProc, string idEstAteAnte)
        {

            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODCARCAT = VariablesWeb.CodigoPerfil;
            TABPROCE.CODTIPPROC = idProc;
            TABPROCE.CODESTATENCIONE = idEstAteAnte;
            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(TABPROCE);
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

        public Nullable<bool> EliminarSolUnidadCatastral(SolicitudUnidadViewModel SolUnidad)
        {
            #region Asignar a la Entidad
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CORRELUNIDAD = SolUnidad.CodigoCorrelativo,
                CODANOSOLI = SolUnidad.CodigoPeriodo,
                CODTIPOSOLI = SolUnidad.CodigoTipoSolicitud,
                CODNUMESOLI = SolUnidad.CodigoNumeroSolicitud,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                TXTIPREG = ""
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLUNIDAD().Eliminar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public List<SelectListItem> ListadoTipoLlenado()
        {
            IEnumerable<BE.SIC_TIPOLLENA> lisQuery = new BL.SIC_TIPOLLENA().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPOLLENA,
                    Text = item.CODTIPOLLENA + " - " + item.TXTTIPOLLENADO
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoTipoAccion()
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

        public List<BE.SIC_TIPOPROCINSPACT> ListadoTipoInsAct(string codigo)
        {
            BE.SIC_TIPOPROCINSPACT TIPOPROCINSPACT = new BE.SIC_TIPOPROCINSPACT();
            TIPOPROCINSPACT.CODTIPOINSP = codigo;
            IEnumerable<BE.SIC_TIPOPROCINSPACT> lisQuery = new BL.SIC_TIPOPROCINSPACT().Listar(TIPOPROCINSPACT);
            var lisDataQuery = new List<BE.SIC_TIPOPROCINSPACT>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new BE.SIC_TIPOPROCINSPACT
                {
                    CODTIPOINSP = item.CODTIPOINSP,
                    CODTIPINSP = item.CODTIPINSP,
                    TXTDETALINSP = item.TXTDETALINSP
                });
            }
            return lisDataQuery;
        }

        public BE.SIC_TABPROCE ObtenerCargo(string Usuario)
        {

            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODUSUARIO = Usuario;
            BE.SIC_TABPROCE entQuery = new BL.SIC_TABPROCE().Recuperar(TABPROCE);

            return entQuery;
        }

        public BE.SIC_TIPOLLENA ObtenerTipoLlenadoDias(string idLlena)
        {

            BE.SIC_TIPOLLENA TIPOLLENA = new BE.SIC_TIPOLLENA();
            TIPOLLENA.CODTIPOLLENA = idLlena;
            BE.SIC_TIPOLLENA entQuery = new BL.SIC_TIPOLLENA().Recuperar(TIPOLLENA);
            return entQuery;
        }

        public string ObtenerFechaLimite(DateTime FechaInicio, int Dias)
        {

            BE.SIC_TIPOLLENA TIPOLLENA = new BE.SIC_TIPOLLENA();
            BE.SIC_TIPOLLENA entQuery = new BL.SIC_TIPOLLENA().ObtenerDiasHabiles(FechaInicio, Dias);
            return entQuery.FECHALIMITE;
        }

        /*public List<SelectListItem> ListadoTipoRequerimiento()
        {
            return new List<SelectListItem> { 
                new SelectListItem { Value = "1", Text="Acumulación" },
                new SelectListItem { Value = "2", Text="Sub-División" },
                new SelectListItem { Value = "3", Text="Inmatriculación" },
                new SelectListItem { Value = "4", Text="Emisión de Plano Catastral por Acumulación" },
                new SelectListItem { Value = "5", Text="Emisión de Plano Catastral por Sub-División o Inmatriculación" },
                new SelectListItem { Value = "6", Text="Certificado de Nomenclatura de Vía" },
                new SelectListItem { Value = "7", Text="Certificado de Numeración Municipal" },
                new SelectListItem { Value = "8", Text="Visación de Planos y Memoria Descriptiva" }
            };
        }*/

        public List<SelectListItem> ListadoAcciones()
        {
            return new List<SelectListItem> { };
        }

        public ProcedimientoInicialViewModel BuscarPrimeraAsignacion(FiltrarProcedimientoInicialViewModel FiltrarProcedimientoInicialBuscar)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = FiltrarProcedimientoInicialBuscar.FiltrarCodigoTipoSolicitud;
            entQuery.CODNUMESOLI = FiltrarProcedimientoInicialBuscar.FiltrarNumeroSolicitud;
            entQuery.CODTIPODOC = FiltrarProcedimientoInicialBuscar.FiltrarCodigoTipoDocumentoReg;
            entQuery.CODRESPRECIBE = VariablesWeb.Usuario.CODUSUARIO;
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            entQuery.CODCORRSEG = "0";
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);
            var dataQuery = new ProcedimientoInicialViewModel();
            if (query == null)
            {
                query = new BE.SIC_SOLISEGUI();
            }
            else if (query.FECRECEPCION == null && (query.CODESTATENCION == "01" || query.CODESTATENCION == "02"))
            {
                query = new BE.SIC_SOLISEGUI();
                dataQuery.SolicitudSinRecepcionar = true;
            }
            #endregion

            #region Asignar al ViewModel
            

            if (query.FECRECEPCION != null && (query.CODESTATENCION == "01" || query.CODESTATENCION == "02"))
            {
            //dataQuery.Folio = query.NUMFOLIOS;
            dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
            dataQuery.NumeroSolicitud = query.CODNUMESOLI;
            dataQuery.FechaRecepcion = query.FECRECEPCION;
            dataQuery.Asunto = query.TXTASUNTO;
            dataQuery.ResponsablePrevio = query.TXTNOMBREREMITENTE;
            dataQuery.EstadoSolicitudPrevio = query.TXTESTADOATENCION;
            dataQuery.CodigoEstadoPrevio = query.CODESTATENCION;
            dataQuery.cadfecharecepcion = (query.FECRECEPCION != null) ? query.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "";
            dataQuery.cadfechaenvio = (query.FECENVIO != null) ? query.FECENVIO.Value.ToString("dd/MM/yyyy") : "";
            dataQuery.cadfechasolicitud = query.FECSOLICITUD.HasValue ? query.FECSOLICITUD.Value.ToString("dd/MM/yyyy") : string.Empty;
            dataQuery.ObservacionRemitente = query.TXTOBSERVACION;
            dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
            dataQuery.Folio = query.NUMFOLIOS;
            dataQuery.anosolicitud = query.CODANOSOLI;
            dataQuery.CodigoCargoAnterior = query.CODCARCAT;
            dataQuery.CodigoTipoDocumento = query.CODTIPODOC;
            dataQuery.CodigoActividad = query.CODACTIVIDAD;
            //dataQuery.CodigoTipoDocumento = query.cod


                if (query.CODTIPOSOLI == "010003")
                {
                    dataQuery.NombreTipoSolicitud = "CATASTRAL";
                    // dataQuery.CodigoTipoDocumento = "001";
                    // dataQuery.NombreTipoDocumento = "REQUERIMIENTO INTERNO";
                    dataQuery.CodigoAreaSolicitante = @ConfigurationManager.AppSettings["CODAREA"];
                    dataQuery.NombreAreaSolicitante = "SUB GERENCIA DE CATASTRO";
                } 
                else if (query.CODTIPOSOLI == "010001")
                {
                    BE.PGD_TRAMITE_EXT entQueryEx = new BE.PGD_TRAMITE_EXT() { TXTTIPODOC = FiltrarProcedimientoInicialBuscar.FiltrarCodigoTipoDocumentoReg, TXTNRODOC = FiltrarProcedimientoInicialBuscar.FiltrarNumeroSolicitud };
                    BE.PGD_TRAMITE_EXT srcQueryEx = new BL.PGD_TRAMITE_EXT().Consulta(entQueryEx);
                    //dataQuery.Folio = Convert.ToInt32(srcQueryEx.TXTFOLIO);
                    dataQuery.Folio = 0;
                    
                }
                else if (query.CODTIPOSOLI == "010002")
                {
                    BE.PGD_TRAMITE_INT entQueryInt = new BE.PGD_TRAMITE_INT() { VTIPO_DOCUMENTO = FiltrarProcedimientoInicialBuscar.FiltrarCodigoTipoDocumentoReg, VNRODOC = FiltrarProcedimientoInicialBuscar.FiltrarNumeroSolicitud };
                    BE.PGD_TRAMITE_INT srcQueryInt = new BL.PGD_TRAMITE_INT().Consulta(entQueryInt);
                    //dataQuery.Folio = srcQueryInt.NUMFOLIO;
                    dataQuery.Folio = 0;
                } 
            }

            #endregion
            return dataQuery;
        }

        public BE.SIC_RETORNO ProcesarProcedimientoInicial(ProcedimientoInicialViewModel ProcedimientoInicial)
        {

            if (ProcedimientoInicial.CodigoTipoSolicitud == "010003")
            {
                ProcedimientoInicial.CodigoTipoDocumento = "REQI";
            }
                                    
            BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = ProcedimientoInicial.anosolicitud,
                CODNUMESOLI = ProcedimientoInicial.NumeroSolicitud,
                CODTIPOSOLI = ProcedimientoInicial.CodigoTipoSolicitud,
                CODTIPODOC = ProcedimientoInicial.CodigoTipoDocumento
            };
            BE.SIC_SOLICITUD srcTempQuery = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
            srcTempQuery.CODTIPOLLENA = ProcedimientoInicial.CodigoTipoLlenado;
            srcTempQuery.NUMCALVER = ProcedimientoInicial.NumeroVerificacion;
            srcTempQuery.TXTANOCALVER = ProcedimientoInicial.AnoVerificacion;
            srcTempQuery.ESTADO = ProcedimientoInicial.CodigoTipoLlenado == "A1" ? "1" : null;
            BE.SIC_RETORNO entSIC_RETORNO_SOL = new BL.SIC_SOLICITUD().Actualizar(srcTempQuery);

            if (ProcedimientoInicial.CodigoTipoSolicitud == "010001")
            {
                BE.PGD_TRAMITE_EXT entQueryExt = new BE.PGD_TRAMITE_EXT()
                {
                    VTIPO = 0,
                    VTIPODESTINO = 0,
                    VID_REF = srcTempQuery.ID_REF,
                    VREMITE = @ConfigurationManager.AppSettings["CODAREA"],
                    VPERREM = VariablesWeb.IdUsuarioIntento,
                    VRECIBE = @ConfigurationManager.AppSettings["CODAREA"],
                    VTIPREC = "1",
                    //VPERREC = "",
                    VOBSERV = ProcedimientoInicial.ObservacionRecepcion,
                    VFECING = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VFOLIOS = "0",//PrimeraAsignacion.Folio.ToString(),
                    //VCODACT2 = "0038",
                    //VCODACC2 = "",
                    VCODACC2 = ProcedimientoInicial.CodigoTipoAccion,
                    VPERREC = ProcedimientoInicial.CodigoAsignarReponsable,
                    VCODACT2 = ProcedimientoInicial.CodigoActividad, 
                };
                BE.SIC_RETORNO entSIC_RETORNO_EXT = new BL.PGD_TRAMITE_EXT().Grabar(entQueryExt);
            }
            if (ProcedimientoInicial.CodigoTipoSolicitud == "010002")
            {
                BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                {
                    VTIPO = 0,
                    VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VID = srcTempQuery.ID_REF,
                    VTIPO_DOCUMENTO = ProcedimientoInicial.CodigoTipoDocumento,
                    VOBSERVACION = ProcedimientoInicial.ObservacionRecepcion,
                    VUSUARIO = VariablesWeb.IdUsuarioIntento,
                    VUSUARIO_AREA = "12.2.0.",          //AREA QUE REMITE
                    VCONTRIBUYENTE = "",
                    VPAGINAS = 0, //PrimeraAsignacion.Folio,
                    VREQRPTA = 0,
                    VFECLIMRPTA = null,
                    VNRODOC = ProcedimientoInicial.NumeroSolicitud,
                    VCOD_ACTIVIDAD = ProcedimientoInicial.CodigoActividad,

                };
                BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().Grabar(entQueryExt);
            }



            BE.SIC_SOLICITUD srcTempQueryTerminado = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
            
            #region Asignar a la Entidad
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODNUMESOLI = ProcedimientoInicial.NumeroSolicitud,
                CODANOSOLI = ProcedimientoInicial.anosolicitud,
                CODTIPOSOLI = ProcedimientoInicial.CodigoTipoSolicitud,
                CTIPODOCUMENTO = ProcedimientoInicial.CodigoTipoDocumento,
                NUMFOLIOS = ProcedimientoInicial.Folio,
                TXTOBSERVACION = ProcedimientoInicial.ObservacionRecepcion,
                CODRESPENVIA = VariablesWeb.IdUsuarioIntento,
                CODRESPRECIBE = ProcedimientoInicial.CodigoAsignarReponsable,
                FECENVIO = System.DateTime.Now,
                CODTIPPROC = ProcedimientoInicial.CodigoTipoProcedimiento,
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODACCION = ProcedimientoInicial.CodigoTipoAccion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODESTATENCION = ProcedimientoInicial.CodigoEstadoActual,
                FECLIMITE = ProcedimientoInicial.fechaLimite,
                FECPROGAINSPE = ProcedimientoInicial.fechaProgIns,
                FECLIMITEI = ProcedimientoInicial.fechaProcIns,
                FECLIMIACT = ProcedimientoInicial.fechaProcAct,
                FECLIMIANA = ProcedimientoInicial.fechaAnalista,
                CODTIPOREQ = ProcedimientoInicial.CodigoTipoRequerimiento,
                CODESTATENCIONE = ProcedimientoInicial.CodigoEstadoPrevio,
                CODCARCATE = ProcedimientoInicial.CodigoCargoResponsable,
                CODACTIVIDAD = ProcedimientoInicial.CodigoActividad,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ProcedimientoInicial.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_SOLISEGUI().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_SOLISEGUI().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_SOLISEGUI().Actualizar(entQuery); break;
            }
            #endregion
            entSIC_RETORNO.CODIGO = srcTempQueryTerminado.NUMCALVER.ToString().PadLeft(3, '0') + "-" + srcTempQueryTerminado.CODANOSOLI.ToString();
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ProcesarMigracionEstaticoTemporal(int?  UnidadCatastral)
        {

            BE.SIC_UNIDAD tempQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = UnidadCatastral
            };
            BE.SIC_UNIDAD srcQueryUnidad = new BL.SIC_UNIDAD().RecuperarTemporal(tempQuery);
            BE.SIC_RETORNO entSIC_RETORNO;
            if (srcQueryUnidad == null)
            {
                entSIC_RETORNO = new BL.SIC_UNIDAD().MigrarEstaticoTemporal(tempQuery);
            }
            else 
            {
                entSIC_RETORNO = new BE.SIC_RETORNO() { Ok = true };
            }
            return entSIC_RETORNO;
        }

        public Nullable<bool> ProcesarInpeccionActualizacion(SoliInspeActViewModel SoliInspeAct)
        {
            #region Asignar a la Entidad
            BE.SIC_SOLINSPEACT entQuery = new BE.SIC_SOLINSPEACT()
            {
                CODNUMESOLI = SoliInspeAct.CodigoNumeroSolicitud,
                CTIPODOCUMENTO = SoliInspeAct.codigoTipoDocumento,
                CODANOSOLI = SoliInspeAct.anoSolicitud,
                CODTIPOSOLI = SoliInspeAct.codigoTipoSolicitud,
                CODINDDET = SoliInspeAct.codIndDet,
                CODTIPOINSP = SoliInspeAct.codTipoInsp,
                TXTDETALLE = SoliInspeAct.textoDetalle,
                TXTDETTIPINS = SoliInspeAct.textDetTipIns,
                CODTIPINSP = SoliInspeAct.CodTipInspe,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODCORRSEG = SoliInspeAct.CodCorrSeguimiento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLINSPEACT().Grabar(entQuery); 
            
            #endregion
            return entSIC_RETORNO.Ok;

        }

        public List<SolicitudUnidadViewModel> RecargarTablaSolUnidad(DataTableAjaxPostModel model, FiltrarProcedimientoInicialViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.CodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.NumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarSolUnidad.CodigoTipoDocumento != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.CodigoTipoDocumento;
            }

            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarSolicitud(entQuery);
            #endregion

            totalResultado = srcQuery.Count();

            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new SolicitudUnidadViewModel
                {
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entrada = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Unidad = item.CODUNIDAD,
                    CodigoUni = item.CODUNI,
                    CodigoCorrelativo = item.CORRELUNIDAD,
                    CodigoPeriodo = item.CODANOSOLI,
                    CodigoTipoSolicitud = item.CODTIPOSOLI,
                    CodigoNumeroSolicitud = item.CODNUMESOLI,
                    Titular = item.TXTTITULARES,
                    Ubicacion = item.TXTDIRECCION,
                    Referencia = item.CODREFANT,
                    EstadoUnidad = item.ESTADOUNIDAD ?? "H",
                    flagTrabajo = item.FLG_TRABAJO
                });
            }
            return lisDataQuery;
        }
        public BE.SIC_RETORNO AgregarSolUnidadCatastral(SolicitudUnidadViewModel SolUnidad)
        {
            #region Asignar a la Entidad

            if (SolUnidad.CodigoTipoSolicitud == "010003")
            {
                SolUnidad.CodigoTipoDocumento = "REQI";
            } 


            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CORRELUNIDAD = SolUnidad.CodigoCorrelativo,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODTIPOSOLI = SolUnidad.CodigoTipoSolicitud,
                CODNUMESOLI = SolUnidad.CodigoNumeroSolicitud,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = SolUnidad.CodigoDistrito,
                CODSECTOR = SolUnidad.CodigoSector,
                CODMANZANA = SolUnidad.CodigoManzana,
                CODLOTE = SolUnidad.CodigoLote,
                CODEDIFICACION = SolUnidad.Ed,
                CODENTRADA = SolUnidad.Entrada,
                CODPISO = SolUnidad.Piso,
                CODUNIDAD = SolUnidad.Unidad,
                CODUNI = SolUnidad.CodigoUni,
                CTIPODOCUMENTO = SolUnidad.CodigoTipoDocumento,
                CODCONTRIBUYENTE = SolUnidad.CodigoTitular,
                ESTADOUNIDAD = SolUnidad.EstadoUnidad,

                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                TXTIPREG = ""
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLUNIDAD().Grabar(entQuery);
            #endregion
            return entSIC_RETORNO;
        }

        public List<UnidadCatastralViewModel> RecargarTablaUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidad, out int totalResul)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = null;
            var listQuery = BuscarDBUnidadCatastral(length, skip, ordenar, out totalResul, FiltrarUnidad);
            var resultado = new List<UnidadCatastralViewModel>(listQuery.Count);
            int i = 0;
            foreach (var s in listQuery)
            {
                resultado.Add(new UnidadCatastralViewModel
                {
                    CodigoDistrito = s.CODDISTRITO,
                    CodigoSector = s.CODSECTOR,
                    CodigoManzana = s.CODMANZANA,
                    CodigoLote = s.CODLOTE,
                    Ed = s.CODEDIFICACION,
                    Entrada = s.CODENTRADA,
                    Piso = s.CODPISO,
                    Unidad = s.CODUNIDAD,
                    Titular = s.TXTRAZONSOCIAL,
                    CodigoTitular = s.CODCONTRIBUYENTE,
                    //Titular = "",
                    Ubicacion = s.TXTUBICACION,
                    CodigoUni = s.CODUNI,
                    Indice = i, 
                    EstadoUnidad = s.ESTADOUNIDAD
                });
                i++;
            }
            return (resultado == null) ? new List<UnidadCatastralViewModel>() : resultado;
        }
        public List<UnidadCatastralViewModel> RecargarTablaUnidadBC(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidad, out int totalResul)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = null;
            var listQuery = BuscarDBUnidadCatastralBC(length, skip, ordenar, out totalResul, FiltrarUnidad);
            var resultado = new List<UnidadCatastralViewModel>(listQuery.Count);
            int i = 0;
            foreach (var s in listQuery)
            {
                if (s.CODBIENCOMUN == null) { 
                    resultado.Add(new UnidadCatastralViewModel
                    {
                        CodigoDistrito = s.CODDISTRITO,
                        CodigoSector = s.CODSECTOR,
                        CodigoManzana = s.CODMANZANA,
                        CodigoLote = s.CODLOTE,
                        Ed = s.CODEDIFICACION,
                        Entrada = s.CODENTRADA,
                        Piso = s.CODPISO,
                        Unidad = s.CODUNIDAD,
                        Titular = s.TXTRAZONSOCIAL,
                        CodigoTitular = s.CODCONTRIBUYENTE,
                        //CodigoBienComun = s.CODBIENCOMUN,
                        //Titular = "",
                        Ubicacion = s.TXTUBICACION,
                        CodigoUni = s.CODUNI,
                        Indice = i,
                        EstadoUnidad = s.ESTADOUNIDAD
                    });
                    i++;
                }
            }
            return (resultado == null) ? new List<UnidadCatastralViewModel>() : resultado;
        }

        public ICollection<BE.SIC_UNIDAD> BuscarDBUnidadCatastral(int length, int skip, string ordenar, out int totalResul, FiltrarUnidadCatastralViewModel FiltrarUnidad)
        {
            ICollection<BE.SIC_UNIDAD> srcQuery = new List<BE.SIC_UNIDAD>();
            if (FiltrarUnidad.FiltrarTipoBusqueda.Equals("1"))
            {
                BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI();
                entQuery.CODVIA = FiltrarUnidad.FiltrarCodigoVia;
                entQuery.NUMCUADRA = FiltrarUnidad.FiltrarNumeroCuadra;
                entQuery.TXTNUMERO = FiltrarUnidad.FiltrarNumeroPuerta;
                srcQuery = new BL.SIC_UNIDAD().BuscarPorUbicacion(entQuery);
            }
            else
            {
                BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
                entQuery.PAGINANUMERO = 1;
                entQuery.PAGINAREGISTROS = length;
                entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
                entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
                entQuery.CODDISTRITO = FiltrarUnidad.FiltrarCodigoDistrito;
                entQuery.CODSECTOR = FiltrarUnidad.FiltrarCodigoSector;
                entQuery.CODMANZANA = FiltrarUnidad.FiltrarCodigoManzana;
                entQuery.CODLOTE = FiltrarUnidad.FiltrarCodigoLote;
                entQuery.CODEDIFICACION = FiltrarUnidad.FiltrarEd;
                entQuery.CODENTRADA = FiltrarUnidad.FiltrarEntrada;
                entQuery.CODPISO = FiltrarUnidad.FiltrarPiso;
                entQuery.CODUNIDAD = FiltrarUnidad.FiltrarUnidad;
                // entQuery = new BL.SIC_UNIDAD().BuscarInt(entQuery);
                entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
                entQuery.PAGINAREGISTROS = length;
                entQuery.ORDEN = ordenar;

                
                if (entQuery.CODSECTOR != "" && entQuery.CODMANZANA != "")
                {
                    srcQuery = new BL.SIC_UNIDAD().Buscar(entQuery);
                }
                //totalResul = entQuery.TOTALREGISTROS ?? default(int);
                totalResul = 2;
            }
            
            
            //totalResul = entQuery.TOTALREGISTROS ?? default(int);
            totalResul = 2;
            return srcQuery;
        }
        public ICollection<BE.SIC_UNIDAD> BuscarDBUnidadCatastralBC(int length, int skip, string ordenar, out int totalResul, FiltrarUnidadCatastralViewModel FiltrarUnidad)
        {
            ICollection<BE.SIC_UNIDAD> srcQuery = new List<BE.SIC_UNIDAD>();
                BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
                entQuery.PAGINANUMERO = 1;
                entQuery.PAGINAREGISTROS = length;
                entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
                entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
                entQuery.CODDISTRITO = FiltrarUnidad.FiltrarCodigoDistrito;
                entQuery.CODSECTOR = FiltrarUnidad.FiltrarCodigoSector;
                entQuery.CODMANZANA = FiltrarUnidad.FiltrarCodigoManzana;
                entQuery.CODLOTE = FiltrarUnidad.FiltrarCodigoLote;
                entQuery.CODEDIFICACION = FiltrarUnidad.FiltrarEd;
                entQuery.CODENTRADA = FiltrarUnidad.FiltrarEntrada;
                entQuery.CODPISO = FiltrarUnidad.FiltrarPiso;
                entQuery.CODUNIDAD = FiltrarUnidad.FiltrarUnidad;
                entQuery.CODUNI = FiltrarUnidad.CodigoUnico;
                entQuery.ESTATICO = (FiltrarUnidad.FiltrarTipoBusqueda == "1") ? false : true;
                // entQuery = new BL.SIC_UNIDAD().BuscarInt(entQuery);
                entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
                entQuery.PAGINAREGISTROS = length;
                entQuery.ORDEN = ordenar;


                if (entQuery.CODSECTOR != "" && entQuery.CODMANZANA != "")
                {
                    srcQuery = new BL.SIC_UNIDAD().BuscarBC(entQuery);
                }

            totalResul = 2;
            return srcQuery;
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

        public List<SelectListItem> ParametroCuadra(string id)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var collection = new DetalleViasHandler().ListarDetalleViasCombo(id);
            if (collection.Count == 0)
            {
                result.Add(new SelectListItem { Text = "", Value = "" });
            }
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Text = item.NumCuadra.ToString(),
                    Value = item.NumCuadra.ToString()
                });
            }

            return result;
        }

        

    }
}