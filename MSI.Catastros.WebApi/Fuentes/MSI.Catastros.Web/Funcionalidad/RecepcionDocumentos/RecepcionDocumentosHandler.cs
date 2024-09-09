using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos
{
    public class RecepcionDocumentosHandler
    {

        public List<RecepcionDocumentosViewModel> CargarGrillaCatastral(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroRecepcionDocumentos)
        {
            BE.SIC_SOLICITUD entSOLISEG = new BE.SIC_SOLICITUD()
            {
                ESTADO  = FiltroRecepcionDocumentos.EstadoRecepcion,
                CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitudReg,
                CODTIPODOC = FiltroRecepcionDocumentos.CodigoTipoDocumentoReg,
                CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitud,
                FECINICIO = FiltroRecepcionDocumentos.FechaInicio,
                FECFIN = FiltroRecepcionDocumentos.FechaFin,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };

                ICollection<BE.SIC_SOLICITUD> srcQuery = new BL.SIC_SOLICITUD().CargarGrillaCatastral(entSOLISEG);

                var lisDataQuery = new List<RecepcionDocumentosViewModel>();
                foreach (var item in srcQuery.ToList())
                {
                    lisDataQuery.Add(new RecepcionDocumentosViewModel
                    {
                        CodigoTipoSolicitud = item.CODTIPOSOLI,
                        NombreTipoSolicitud = item.TXTTIPOSOLI,
                        NumeroSolicitud = item.CODNUMESOLI,
                        NombreTipoDocumento = item.TXTTIPODOC,
                        NombreAreaSolicitante = "SUB GERENCIA DE CATASTRO",
                        PuestoRemitente = "SUB GERENCIA DE CATASTRO",
                        FecRecepcion = item.FECRECEPCION,
                        Asunto = item.TXTASUNTO,
                        Folios = item.NUMFOLSOL,
                        nro = item.NRO,
                        PuestoRecepcion = item.TXTNOMBRERECEPCION,
                        UsuarioRecepcion = item.USUARIORECEPCION,
                        FechaIngreso = item.FECREG,
                        CodigoAreaSolicitante = "12.2.0",
                        CodigoPeriodoSolicitud = item.CODANOSOLI,
                        fecsolicitud = item.FECSOLICITUD,
                        PrimeraRecepcion = item.PRIMERAASIGNACION,
                        CodigoTipoDocumento = item.CODTIPODOC,
                        CorrelativoMaximo = item.CORMAXSOLI,
                    });
                }
                return lisDataQuery;
        }

        public List<RecepcionDocumentosViewModel> CargarGrillaCatastralInternaPendiente(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroRecepcionDocumentos)
        {
            BE.SIC_SOLICITUD entSOLISEG = new BE.SIC_SOLICITUD()
            {
                ESTADO = FiltroRecepcionDocumentos.EstadoRecepcion,
                CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitudReg,
                CODTIPODOC = FiltroRecepcionDocumentos.CodigoTipoDocumentoReg,
                CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitud,
                FECINICIO = FiltroRecepcionDocumentos.FechaInicio,
                FECFIN = FiltroRecepcionDocumentos.FechaFin,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };

            ICollection<BE.SIC_SOLICITUD> srcQuery = new BL.SIC_SOLICITUD().CargarGrillaCatastralInternaPendiente(entSOLISEG);

            var lisDataQuery = new List<RecepcionDocumentosViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new RecepcionDocumentosViewModel
                {
                    CodigoTipoSolicitud = item.CODTIPOSOLI,
                    CodigoPeriodoSolicitud = item.CODANOSOLI,
                    NombreAreaSolicitante = item.TXTAREASOLICITANTE,
                    CodigoAreaSolicitante = item.CODAREASOLI,
                    NombreTipoDocumento = item.CODTIPODOC,
                    CodigoTipoDocumento = item.CODTIPODOC,
                    NumeroSolicitud = item.CODNUMESOLI,
                    NombreTipoSolicitud = item.TXTTIPOSOLI,
                    Asunto = item.TXTASUNTO,
                    Folios = item.NUMFOLSOL,
                    CodigoContribuyente = item.CODIGO_CONTRIBUYENTE,
                    nro = item.NRO,
                    IdRef = item.ID_REF,
                    PrimeraRecepcion = item.PRIMERAASIGNACION,
                    FecRecepcion = item.FECRECEPCION,
                    UsuarioRecepcion = item.USUARIORECEPCION,
                    PuestoRecepcion = item.TXTNOMBRERECEPCION,
                    FechaIngreso = item.FECREG,
                    fecsolicitud = item.FECREG,
                    PuestoRemitente = "SUBGERENCIA DE CATASTRO",
                    CorrelativoMaximo = item.CORMAXSOLI,
                    //  COD_ACTIVIDAD = item.COD_ACTIVIDAD,
                    //  COD_ACCION
                });
            }
            return lisDataQuery;
        }
        public List<RecepcionDocumentosViewModel> CargarGrillaCatastralExternaPendiente(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroRecepcionDocumentos)
        {

            BE.SIC_SOLICITUD entSOLISEG = new BE.SIC_SOLICITUD()
            {
                ESTADO = FiltroRecepcionDocumentos.EstadoRecepcion,
                CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitudReg,
                CODTIPODOC = FiltroRecepcionDocumentos.CodigoTipoDocumentoReg,
                CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitud,
                FECINICIO = FiltroRecepcionDocumentos.FechaInicio,
                FECFIN = FiltroRecepcionDocumentos.FechaFin,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };

            ICollection<BE.SIC_SOLICITUD> srcQuery = new BL.SIC_SOLICITUD().CargarGrillaCatastralExternaPendiente(entSOLISEG);

            var lisDataQuery = new List<RecepcionDocumentosViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new RecepcionDocumentosViewModel
                {
                    CodigoPeriodoSolicitud = item.CODANOSOLI,
                    CodigoTipoSolicitud = item.CODTIPOSOLI,
                    NombreTipoSolicitud = item.TXTTIPOSOLI,
                    NumeroSolicitud = item.CODNUMESOLI,
                    NombreTipoDocumento = item.CODTIPODOC,
                    CodigoTipoDocumento = item.CODTIPODOC,
                    NombreAreaSolicitante = item.CODAREASOLI,
                    PuestoRemitente = "SUB GERENCIA DE CATASTRO",
                    FecRecepcion = item.FECRECEPCION,
                    Asunto = item.TXTASUNTO,
                    Folios = item.NUMFOLSOL,
                    nro = item.NRO,
                    PuestoRecepcion = item.TXTPUESTOREMITENTE,
                    UsuarioRecepcion = item.USUARIORECEPCION,
                    PrimeraRecepcion= item.PRIMERAASIGNACION,
                    IdRef = item.ID_REF ,

                    CodigoContribuyente  = item.CODIGO_CONTRIBUYENTE,
                    CodigoRecurrente = item.COD_RECURRENTE ,
                    Solicitante = item.TXTSOLICITANTE ,
                    TipoDocRec = item.TXTDESC_TIPODOCREC,
                    IdRecurrente = item.TXTDOCIDRECURRENTE ,
                    RepresentanteEl = item.TXTREPRESENTANTEL ,
                    CodTipoDocRec = item.TXTCODTIPODOCUMENTOREC ,
                    TipoDocRepl =item.TXTDES_TIPODOCREPL,
                    CodTipoDocRepl= item.TXTCODTIPODOCREPLEGAL ,
                    IdRepresentante = item.TXTDOCIDEREPRESENTANTEL,
                    CorrelativoMaximo = item.CORMAXSOLI,
                });
            }
            return lisDataQuery;
        }
        public List<RecepcionDocumentosViewModel> ListarGrid(DataTableAjaxPostModel model, FiltrarRecepcionDocumentosViewModel FiltroRecepcionDocumentos, out int totalResul)
        {
            #region Declaracion de variables
            bool PrimeraRecepcion = false;
            string CodigoCorrelativo;
            List<RecepcionDocumentosViewModel> listado = new List<RecepcionDocumentosViewModel>();
            #endregion

            var listQuery = BuscarDB(FiltroRecepcionDocumentos, out totalResul, out PrimeraRecepcion, out CodigoCorrelativo);
            if (totalResul != 0)
            {
                var resultado = new RecepcionDocumentosViewModel()
                {
                    CodigoPeriodoSolicitud = listQuery.CODANOSOLI,
                    CodigoTipoSolicitud = listQuery.CODTIPOSOLI,
                    NumeroSolicitud = listQuery.CODNUMESOLI,
                    Asunto = listQuery.TXTASUNTO,
                    Folios = listQuery.NUMFOLSOL,
                    Usuario = FiltroRecepcionDocumentos.Usuario,
                    Indice = 1,
                    PrimeraRecepcion = PrimeraRecepcion.ToString()
                };
                if (listQuery.CODTIPOSOLI == "010001")
                {
                    resultado.CodigoContribuyente = listQuery.CODIGO_CONTRIBUYENTE;
                    resultado.CodigoRecurrente = listQuery.COD_RECURRENTE;
                    resultado.Solicitante = listQuery.TXTSOLICITANTE;
                    resultado.TipoDocRec = listQuery.TXTDESC_TIPODOCREC;
                    resultado.IdRecurrente = listQuery.TXTDOCIDRECURRENTE;
                    resultado.RepresentanteEl = listQuery.TXTREPRESENTANTEL;
                    resultado.CodTipoDocRec = listQuery.TXTCODTIPODOCUMENTOREC;
                    resultado.TipoDocRepl = listQuery.TXTDES_TIPODOCREPL;
                    resultado.FechaIngreso = listQuery.FECINGRESO;
                    resultado.CodTipoDocRepl = listQuery.TXTCODTIPODOCREPLEGAL;
                    resultado.IdRepresentante = listQuery.TXTDOCIDEREPRESENTANTEL;
                    resultado.CodigoAccion = listQuery.COD_ACCION;
                    resultado.CodigoActividad = listQuery.COD_ACTIVIDAD;
                }
                if (listQuery.CODTIPOSOLI == "010003")
                {
                    resultado.NombreTipoSolicitud = "CATASTRAL";
                    resultado.CodigoTipoDocumento = "010003";
                    resultado.NombreTipoDocumento = "REQUERIMIENTO INTERNO";
                    resultado.PuestoRemitente = (PrimeraRecepcion == true) ? "SUB GERENCIA DE CATASTRO" : listQuery.TXTPUESTOREMITENTE;
                    resultado.NombreAreaSolicitante = "SUB GERENCIA DE CATASTRO";
                }
                else 
                { 
                    resultado.NombreTipoSolicitud = FiltroRecepcionDocumentos.NombreTipoSolicitudReg;
                    resultado.CodigoTipoDocumento = FiltroRecepcionDocumentos.CodigoTipoDocumentoReg;
                    resultado.NombreTipoDocumento = FiltroRecepcionDocumentos.NombreTipoDocumentoReg;
                    resultado.PuestoRemitente = listQuery.TXTPUESTOREMITENTE;
                    //resultado.NombreAreaSolicitante = listQuery.TXTAREASOLICITANTE;
                    resultado.NombreAreaSolicitante = "SUB GERENCIA DE CATASTRO";
                }
                resultado.CodigoAreaSolicitante = listQuery.CODAREASOLI;
                resultado.CodigoCorrelativo = CodigoCorrelativo;
                resultado.IdRef = listQuery.ID_REF;
                
                resultado.PuestoRecepcion = (PrimeraRecepcion == true) ? "COORDINADOR ANALISTA" : listQuery.TXTPUESTORECEPCION;
                listado.Add(resultado);
            }
            return  listado;
        }
        public BE.SIC_SOLICITUD BuscarDB(FiltrarRecepcionDocumentosViewModel FiltroRecepcion, out int totalResul, out bool PrimeraRecepcion, out string CodigoCorrelativo)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entSOLISEG= new BE.SIC_SOLISEGUI(){
                CODANOSOLI = FiltroRecepcion.Periodo,
                CODNUMESOLI = FiltroRecepcion.NumeroSolicitud,
                CODTIPOSOLI = FiltroRecepcion.CodigoTipoSolicitudReg
            };
            entSOLISEG.CODTIPODOC = (FiltroRecepcion.CodigoTipoSolicitudReg != "010003") ? FiltroRecepcion.CodigoTipoDocumentoReg : String.Empty;
            BE.SIC_SOLISEGUI srcQuerySegui = new BL.SIC_SOLISEGUI().Recuperar(entSOLISEG);
            PrimeraRecepcion = (srcQuerySegui == null) ? true : false;
            #endregion
            
            #region Asignar valores si es la primera recepción traer datos de SIC_SOLICITUD en caso contrario de SIC_SOLISEGUI
            CodigoCorrelativo = "0";totalResul = 0;
            BE.SIC_SOLICITUD entQuery = new BE.SIC_SOLICITUD() {
                CODNUMESOLI = FiltroRecepcion.NumeroSolicitudReg,
                CODTIPOSOLI = FiltroRecepcion.CodigoTipoSolicitudReg,
                CODANOSOLI = FiltroRecepcion.Periodo
            };
            entQuery.CODTIPODOC = (FiltroRecepcion.CodigoTipoSolicitudReg != "010003") ?  FiltroRecepcion.CodigoTipoDocumentoReg : String.Empty;
            
            BE.SIC_SOLICITUD srcQuery = new BE.SIC_SOLICITUD();
            if (PrimeraRecepcion == true)
            {
                if (FiltroRecepcion.CodigoTipoSolicitudReg == "010003") {
                    entQuery.CODTIPODOC = "REQI";
                    if (VariablesWeb.CodigoPerfil == "01")
                    {
                        srcQuery = new BL.SIC_SOLICITUD().Recuperar(entQuery); 
                    }else {
                        srcQuery = null;
                    }
                } else {
                    if (FiltroRecepcion.CodigoTipoSolicitudReg == "010001") {
                        BE.PGD_TRAMITE_EXT entQueryTram = new BE.PGD_TRAMITE_EXT() { TXTTIPODOC = FiltroRecepcion.CodigoTipoDocumentoReg, TXTNRODOC = FiltroRecepcion.NumeroSolicitudReg };
                        BE.PGD_TRAMITE_EXT srcQueryTram = new BL.PGD_TRAMITE_EXT().Consulta(entQueryTram);
                        if (srcQueryTram != null && VariablesWeb.CodigoPerfil == "01")
                        {
                            
                            srcQuery.TXTNOMBRETITULAR = srcQueryTram.VREMITE;
                            srcQuery.TXTASUNTO = srcQueryTram.TXTASUNTO;
                            srcQuery.FECINGRESO = srcQueryTram.FECHA_INGRESO;
                            srcQuery.FECLIMITE = srcQueryTram.FECVENCE;
                            srcQuery.TXTAREASOLICITANTE = srcQueryTram.TXTAREASOLICITANTE;
                            srcQuery.CODAREASOLI = srcQueryTram.CODAREASOLICITANTE;
                            srcQuery.ID_REF = srcQueryTram.VID_REF;
                            srcQuery.CODNUMESOLI = srcQueryTram.NRODOC;
                            srcQuery.CODTIPOSOLI = srcQueryTram.TIPO_DOCUMENTO;
                            srcQuery.CODTIPOSOLI = FiltroRecepcion.CodigoTipoSolicitudReg;
                            srcQuery.TXTPUESTOREMITENTE = "JEFE DE AREA";
                            srcQuery.NUMFOLSOL = Convert.ToInt32(srcQueryTram.FOLIO);

                            srcQuery.CODIGO_CONTRIBUYENTE = srcQueryTram.CODIGO_CONTRIBUYENTE;
                            srcQuery.COD_RECURRENTE = srcQueryTram.COD_RECURRENTE;
                            srcQuery.TXTSOLICITANTE = srcQueryTram.SOLICITANTE;
                            srcQuery.TXTDESC_TIPODOCREC = srcQueryTram.DES_TIPODOCREC;
                            srcQuery.TXTDOCIDRECURRENTE = srcQueryTram.DOCIDRECURRENTE;
                            srcQuery.TXTREPRESENTANTEL = srcQueryTram.REPRESENTANTEL;
                            srcQuery.TXTCODTIPODOCUMENTOREC = srcQueryTram.CODTIPODOCUMENTOREC;
                            srcQuery.TXTDES_TIPODOCREPL = srcQueryTram.DES_TIPODOCREPL;
                            srcQuery.TXTCODTIPODOCREPLEGAL = srcQueryTram.CODTIPODOCREPLEGAL;
                            srcQuery.TXTDOCIDEREPRESENTANTEL = srcQueryTram.DOCIDREPRESENTANTEL;

                            srcQuery.COD_ACCION = srcQueryTram.COD_ACCION;
                            srcQuery.COD_ACTIVIDAD = srcQueryTram.COD_ACTIVIDAD;


                        }
                        else {
                            srcQuery = null;
                        }

                    } else if(FiltroRecepcion.CodigoTipoSolicitudReg == "010002") {
                        BE.PGD_TRAMITE_INT entQueryTram = new BE.PGD_TRAMITE_INT() { VTIPO_DOCUMENTO = FiltroRecepcion.CodigoTipoDocumentoReg, 
                            //VNRODOC = FiltroRecepcion.NumeroSolicitudReg + "-" + System.DateTime.Now.Year.ToString() + "-" + "1220"
                            VNRODOC = FiltroRecepcion.NumeroSolicitudReg
                        };
                        BE.PGD_TRAMITE_INT srcQueryTram = new BL.PGD_TRAMITE_INT().Consulta(entQueryTram);
                        if (srcQueryTram != null && VariablesWeb.CodigoPerfil == "01")
                        {
                            srcQuery.CODNUMESOLI = srcQueryTram.VNRODOC;
                            srcQuery.CODTIPOSOLI = FiltroRecepcion.CodigoTipoSolicitudReg;
                            srcQuery.TXTPUESTOREMITENTE = "JEFE DE AREA";
                            srcQuery.TXTNOMBRETITULAR = "";
                            srcQuery.TXTASUNTO = srcQueryTram.TXTASUNTO;
                            srcQuery.NUMFOLSOL = Convert.ToInt32(srcQueryTram.NUMFOLIO);
                            srcQuery.TXTAREASOLICITANTE = srcQueryTram.TXTAREASOLICITANTE;
                            srcQuery.CODAREASOLI = srcQueryTram.CODAREASOLICITANTE;
                            srcQuery.ID_REF = srcQueryTram.VID;
                        }
                        else {
                            srcQuery = null;
                        }
                    }
                }
                totalResul = (srcQuery == null) ? 0 : 1;
            }
            else if (PrimeraRecepcion == false && (srcQuerySegui.FECRECEPCION == null && srcQuerySegui.CODRESPRECIBE == VariablesWeb.IdUsuarioIntento))
            {
                srcQuery = new BL.SIC_SOLICITUD().Recuperar(entQuery);
                srcQuery.TXTPUESTORECEPCION = srcQuerySegui.TXTPUESTORECEPCION;
                srcQuery.TXTPUESTOREMITENTE = srcQuerySegui.TXTPUESTOREMITENTE;
                srcQuery.FECSOLICITUD = srcQuery.FECSOLICITUD;
                CodigoCorrelativo = srcQuerySegui.CODCORRSEG;
                totalResul = 1;
                if (srcQuerySegui.CODRESPENVIA == srcQuerySegui.CODRESPRECIBE && VariablesWeb.CodigoPerfil != "02")
                {
                    srcQuery = new BE.SIC_SOLICITUD();
                    totalResul = 0;
                }
            }
            #endregion
            return srcQuery;
        }

        public Nullable<bool> ProcesarRecepcionDocumento(RecepcionDocumentosViewModel Recepcion)
        {
            string TipoSol = Recepcion.CodigoTipoSolicitud;
            string Primera = Recepcion.PrimeraRecepcion;
            BE.SIC_SOLICITUD entQuery;
            if (TipoSol == "010003")
            {
                //Variables de Búqueda
                BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD(){
                    CODANOSOLI = Recepcion.CodigoPeriodoSolicitud,
                    CODNUMESOLI = Recepcion.NumeroSolicitud,CODTIPOSOLI = TipoSol
                };
                //Variable temporal srcTempQuery => SIC_SOLICITUD
                BE.SIC_SOLICITUD srcTempQuery = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
                entQuery = new BE.SIC_SOLICITUD()
                {
                    CODANOSOLI = Recepcion.CodigoPeriodoSolicitud,
                    CODNUMESOLI = Recepcion.NumeroSolicitud,
                    CODTIPOSOLI = TipoSol,
                    CODAREASOLI = Recepcion.CodigoAreaSolicitante,
                    NUMFOLSOL = Recepcion.Folios,
                    TXTASUNTO = Recepcion.Asunto,
                    FECRECEP = System.DateTime.Now,
                    TXTAREASOLICITANTE = Recepcion.NombreAreaSolicitante,
                    TXTPUESTORECEPCION = Recepcion.PuestoRecepcion,
                    TXTPUESTOREMITENTE = Recepcion.PuestoRemitente,
                    FECSOLICITUD = srcTempQuery.FECSOLICITUD,
                    CODTIPOLLENA = srcTempQuery.CODTIPOLLENA,
                    CODTIPODOC = srcTempQuery.CODTIPODOC,
                };

            }
            else {

                BE.PGD_TRAMITE_EXT entQueryTram1 = new BE.PGD_TRAMITE_EXT()
                {
                    TXTTIPODOC = Recepcion.CodigoTipoDocumento,
                    TXTNRODOC = Recepcion.NumeroSolicitud
                };
                BE.PGD_TRAMITE_EXT srcQueryTram1 = new BL.PGD_TRAMITE_EXT().Consulta(entQueryTram1);
                entQuery = new BE.SIC_SOLICITUD()
                {
                    CODANOSOLI = System.DateTime.Now.Year.ToString(), CODNUMESOLI = Recepcion.NumeroSolicitud,
                    CODTIPOSOLI = TipoSol,
                    CODTIPODOC = Recepcion.CodigoTipoDocumento,
                    CODAREASOLI = Recepcion.CodigoAreaSolicitante,
                    NUMFOLSOL = Recepcion.Folios,
                    TXTASUNTO = Recepcion.Asunto,
                    FECRECEP = System.DateTime.Now,
                    TXTAREASOLICITANTE = Recepcion.NombreAreaSolicitante,
                    TXTPUESTORECEPCION = Recepcion.PuestoRecepcion,
                    TXTPUESTOREMITENTE = Recepcion.PuestoRemitente,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    ID_REF = Recepcion.IdRef,
                    CODIGO_CONTRIBUYENTE = Recepcion.CodigoContribuyente,
                    COD_RECURRENTE = Recepcion.CodigoRecurrente,
                    TXTSOLICITANTE = Recepcion.Solicitante,
                    TXTDESC_TIPODOCREC = Recepcion.TipoDocRec,
                    TXTDOCIDRECURRENTE = Recepcion.IdRecurrente,
                    TXTREPRESENTANTEL = Recepcion.RepresentanteEl,
                    TXTCODTIPODOCUMENTOREC = Recepcion.CodTipoDocRec,
                    TXTDES_TIPODOCREPL = Recepcion.TipoDocRepl,
                    TXTCODTIPODOCREPLEGAL = Recepcion.CodTipoDocRepl,
                    TXTDOCIDEREPRESENTANTEL = Recepcion.IdRepresentante,
                    FECSOLICITUD = (Recepcion.CodigoTipoSolicitud == "010001")? ((srcQueryTram1 != null) ? srcQueryTram1.FECHA_INGRESO : null)  : null,
                    //CODTIPOLLENA = srcTempQuery.CODTIPOLLENA

                    

                };
            }
            


            

            #region Asignar a la Entidad            
            BE.SIC_SOLISEGUI entQuerySoliSeg;
            if (Primera == "True")
            {
                entQuerySoliSeg = new BE.SIC_SOLISEGUI()
                {
                    CODANOSOLI = entQuery.CODANOSOLI, CODNUMESOLI = entQuery.CODNUMESOLI, CODTIPOSOLI = entQuery.CODTIPOSOLI, CODCORRSEG = Recepcion.CodigoCorrelativo,
                    FECRECEPCION = System.DateTime.Now, NUMFOLIOS = entQuery.NUMFOLSOL, CODRESPENVIA = "", CODRESPRECIBE = VariablesWeb.IdUsuarioIntento,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    CODTIPPROC = "00",
                    CTIPODOCUMENTO = entQuery.CODTIPODOC,
                    TXTOBSERVACION = Recepcion.Asunto,
                    CODACCION = Recepcion.CodigoAccion,
                    CODACTIVIDAD = Recepcion.CodigoActividad
                };
                entQuerySoliSeg.CODTIPPROC = "00";
                entQuerySoliSeg.CODESTATENCION = "00";
                entQuerySoliSeg.CODESTATENCIONE = "00";
                entQuerySoliSeg.CODCARCAT = "01";
                entQuerySoliSeg.CODCARCATE = "01";
            }
            else
            {
                if (TipoSol == "010003") {
                    Recepcion.CodigoTipoDocumento = "REQI";
                }
                entQuerySoliSeg = new BL.SIC_SOLISEGUI().Recuperar(new BE.SIC_SOLISEGUI()
                {
                    CODANOSOLI = entQuery.CODANOSOLI, CODNUMESOLI = entQuery.CODNUMESOLI, CODTIPOSOLI = entQuery.CODTIPOSOLI, CODRESPRECIBE = VariablesWeb.IdUsuarioIntento,
                    CODCORRSEG = Recepcion.CodigoCorrelativo,
                    CODTIPODOC = Recepcion.CodigoTipoDocumento
                });
                entQuerySoliSeg.CTIPODOCUMENTO = entQuerySoliSeg.CODTIPODOC;
                
                entQuerySoliSeg.FECRECEPCION = System.DateTime.Now;
            }
            #endregion
            
            #region Grabar, Actualizar
            BE.SIC_RETORNO entSIC_RETORNO;
            if (TipoSol == "010003") {
                entSIC_RETORNO = new BL.SIC_SOLICITUD().Actualizar(entQuery);
            } else {
                BE.SIC_SOLICITUD tempQueryEx = new BE.SIC_SOLICITUD() { CODANOSOLI = Recepcion.CodigoPeriodoSolicitud, CODNUMESOLI = Recepcion.NumeroSolicitud,
                    CODTIPOSOLI = TipoSol,CODTIPODOC = Recepcion.CodigoTipoDocumento };
                BE.SIC_SOLICITUD srcTempQueryEx = new BL.SIC_SOLICITUD().Recuperar(tempQueryEx);
                entSIC_RETORNO = (srcTempQueryEx == null) ? new BL.SIC_SOLICITUD().Grabar(entQuery) : new BL.SIC_SOLICITUD().Actualizar(entQuery);
            }
            BE.SIC_RETORNO entSIC_RETORNO_SOLISE = (Primera == "True") ? new BL.SIC_SOLISEGUI().Grabar(entQuerySoliSeg) : new BL.SIC_SOLISEGUI().Actualizar(entQuerySoliSeg);
            #endregion

            return entSIC_RETORNO_SOLISE.Ok;
        }

        /// <summary>
        /// Retornar listado de Tipo de solicitud
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
            lisDataQuery.Add(new SelectListItem{Value = "DS",Text = "DOCUMENTO SIMPLE" });
            lisDataQuery.Add(new SelectListItem { Value = "EX", Text = "EXPEDIENTE" });
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoTipoDocumentoInt()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDocumentoInt();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                });
            }
            //lisDataQuery.Add(new SelectListItem { Value = "DS", Text = "DOCUMENTO SIMPLE" });
            //lisDataQuery.Add(new SelectListItem { Value = "EX", Text = "EXPEDIENTE" });
            return lisDataQuery;
        }
        public RecepcionDocumentosViewModel RecuperarDatosSolicitud(string CodigoPeriodoSolicitud, string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoTipoDocumento, out bool resul)
        {
            BE.SIC_SOLICITUD entQuery = new BE.SIC_SOLICITUD();
            entQuery.CODANOSOLI = CodigoPeriodoSolicitud;
            entQuery.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuery.CODNUMESOLI = NumeroSolicitud;
            entQuery.CODTIPODOC = CodigoTipoDocumento;


            BE.SIC_SOLICITUD query = new BL.SIC_SOLICITUD().RecuperarDatosSolicitud(entQuery);


            RecepcionDocumentosViewModel dataQuery;

            dataQuery = new RecepcionDocumentosViewModel()
            {
                CodigoPeriodoSolicitud = query.CODANOSOLI,
                NumeroSolicitud = query.CODNUMESOLI,
                CodigoTipoSolicitud = query.CODTIPOSOLI,
                CodigoTipoDocumento = query.CODTIPODOC,
                PrimeraRecepcion= query.PRIMERAASIGNACION,
            };
            resul = true;

            return dataQuery;


        }
        public Nullable<bool> RechazaraDocumentos(RecepcionDocumentosViewModel Recepcion)
        {

                BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD()
                {
                    CODANOSOLI = Recepcion.CodigoPeriodoSolicitud,
                    CODNUMESOLI = Recepcion.NumeroSolicitud,
                    CODTIPOSOLI = Recepcion.CodigoTipoSolicitud,
                    CODTIPODOC = Recepcion.CodigoTipoDocumento,
                    CORMAXSOLI = Recepcion.CorrelativoMaximo,
                };
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLICITUD().RechazaraDocumentos(tempQuery);

            return entSIC_RETORNO.Ok;
        }
    }

    
}