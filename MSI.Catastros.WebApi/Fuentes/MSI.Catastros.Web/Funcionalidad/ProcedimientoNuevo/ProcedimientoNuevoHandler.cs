using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
//using DA = MSI.Catastros.DataAccess;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion;
using MSI.Catastros.Web.Funcionalidad.ProcedimientoInicial;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;
using System.Configuration;
using System.IO;


namespace MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo
{
    public class ProcedimientoNuevoHandler
    {
        /// <summary>
        /// Retornar listado de Tipo de solicitud
        /// </summary>
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
        public List<SelectListItem> ListadoTipoProcedimiento(String estado)
        {
            BE.SIC_TABPROCE entQuery = new BE.SIC_TABPROCE()
            {
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODESTATENCIONE = estado
            };
            
            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();  
            var temp = "";
            foreach (var item in lisQuery)
            {
                if (temp != item.TXTDESCPRO)
                {
                    lisDataQuery.Add(new SelectListItem
                    {
                        Value = item.CODTIPPROC,
                        Text = item.TXTDESCPRO
                    });
                }
                temp = item.TXTDESCPRO;
            }
            return lisDataQuery;
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
        public List<SelectListItem> ListadoResponsable(String estado)
        {
            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(new BE.SIC_TABPROCE() { CODCARCAT = VariablesWeb.CodigoPerfil, CODESTATENCIONE = estado });
            var lisDataQuery = new List<SelectListItem>();
            lisDataQuery.Add(new SelectListItem
            {
                Value = "",
                Text = ""
            });
            //foreach (var item in lisQuery)
            //{
            //    lisDataQuery.Add(new SelectListItem
            //    {
            //        Value = item.CODUSUARIO,
            //        Text = item.TXTNOMBRES
            //    });
            //}
            return lisDataQuery;
        }
        public List<SelectListItem> ListaTipoError(string tipoerror)
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoError(tipoerror);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                }); ;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListaTipoErrorDigitacion()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoErrorDigitacion();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODPARAMETRO,
                    Text = item.TXTDESCRIPCION
                }); ;
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ObtenerResponsables(string Estado, string TipoProcedimiento, string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo)
        {
            BE.SIC_TABPROCE entQueryTab = new BE.SIC_TABPROCE()
            {
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODTIPPROC = TipoProcedimiento,
                CODESTATENCIONE = Estado
            };

            BE.SIC_PROGINSPEC entQueryProg = new BE.SIC_PROGINSPEC()
            {
                CODNUMESOLI = NumeroSolicitud,
                CODTIPOSOLI = CodigoTipoSolicitud,
                CODANOSOLI = CodigoPeriodo
            };
            BE.SIC_PROGINSPEC srcQueryProg = null;
            if(TipoProcedimiento == "05") {
                srcQueryProg = new BL.SIC_PROGINSPEC().ListarInspectores(entQueryProg);
            }

            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(entQueryTab);
            string codTemp = "";
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                if (codTemp != item.TXTNOMBRES) {
                    lisDataQuery.Add(new SelectListItem
                    {
                        Value = item.CODUSUARIO,
                        Text = item.TXTNOMBRES,
                    });
                    if (srcQueryProg != null) {
                        lisDataQuery.Last().Selected = (srcQueryProg.CODUSUASIS == lisDataQuery.Last().Value) ? true : false;
                    }


                }
                codTemp = item.TXTNOMBRES;
            }
            return lisDataQuery;
        }

        public EstadoActualViewModel ObtenerEstado(string Estado, string Usuario, string Tipproced)
        {
            string Cargo;
            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODUSUARIO = Usuario;
            BE.SIC_TABPROCE entQuery = new BL.SIC_TABPROCE().Recuperar(TABPROCE);
            Cargo = (entQuery == null) ? null : entQuery.TXTDECCARG;

            BE.SIC_TABPROCE entQueryTab = new BE.SIC_TABPROCE()
            {
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODTIPPROC = Tipproced,
                CODESTATENCIONE = Estado
            };

            IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(entQueryTab);
            var lisDataQuery = new EstadoActualViewModel();
            var temp = "";
            foreach (var item in lisQuery)
            {
                if (temp != item.CODESTACTUAL)
                {
                    lisDataQuery.CodigoCargo = item.CODCARCATE;
                    lisDataQuery.CodigoEstado = item.CODESTACTUAL;
                    lisDataQuery.NombreEstado = item.TXTESTACTUAL;
                    lisDataQuery.NombreCargo = Cargo;
                }
                temp = item.TXTDESCPRO;
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
        public List<InspeccionesViewModel> RecargarTablaInspecciones(DataTableAjaxPostModel model, InspeccionesViewModel FiltrarSolUnidad, out int totalResultado)
        {
            totalResultado = 0;
            #region Obtener datos
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };

            ICollection<BE.SIC_PROGINSPEC> srcQuery = new BL.SIC_PROGINSPEC().Listar(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_PROGINSPEC>();
            }
            var lisDataQuery = new List<InspeccionesViewModel>();
            foreach (var item in srcQuery)
            {
                IEnumerable<BE.SIC_MOVINSPEC> lisQueryDetalle = new BL.SIC_MOVINSPEC().Listar(new BE.SIC_MOVINSPEC()
                {
                    CODANOSOLI = System.DateTime.Now.Year.ToString(),
                    CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                    CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                    CODNROINSPEC = item.CODNROINSPEC
                });
                IEnumerable<BE.SIC_UNIDADINSPECCION> lisQueryUniInspec = new BL.SIC_UNIDADINSPECCION().Listar(new BE.SIC_UNIDADINSPECCION()
                {
                    CODANOSOLI = System.DateTime.Now.Year.ToString(),
                    CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                    CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                    CODNROINSPEC = item.CODNROINSPEC
                });
                var inspectores = new List<SelectListItem>();
                string temInspectores = string.Empty;
                var responsable = new List<SelectListItem>();
                string temResponsable = string.Empty;
                int contador = 0;
                List<CodigoCatastralAsignado> lisCodCatas = new List<CodigoCatastralAsignado>();
                foreach (var Unidad in lisQueryUniInspec)
                {
                    lisCodCatas.Add(new CodigoCatastralAsignado()
                    {
                        Distrito = Unidad.CODDISTRITO,
                        Sec = Unidad.CODSECTOR,
                        Manzana = Unidad.CODMANZANA,
                        Lote = Unidad.CODLOTE,
                        Ed = Unidad.CODEDIFICACION,
                        Entr = Unidad.CODENTRADA,
                        Piso = Unidad.CODPISO,
                        Unidad = Unidad.CODUNIDAD
                    });
                }
                //
                foreach (var itemInspectores in lisQueryDetalle)
                {
                    inspectores.Add(new SelectListItem()
                    {
                        Value = itemInspectores.CODUSUASIS,
                        Text = itemInspectores.TXTNOMBRE,
                    });
                    if (contador == 0)
                    {
                        temInspectores = itemInspectores.TXTNOMBRE;
                        contador++;
                    }
                    else
                    {
                        temInspectores += " <br/><hr/>" + itemInspectores.TXTNOMBRE;
                    }
                    
                    if (itemInspectores.FLAGRESPONSABLE == "1")
                    {
                        responsable.Add(new SelectListItem()
                        {
                            Value = itemInspectores.CODUSUASIS,
                            Text = itemInspectores.TXTNOMBRE,
                        });
                        //temResponsable += itemInspectores.TXTNOMBRE + " <br/><hr/>";
                    }
                }
                lisDataQuery.Add(new InspeccionesViewModel
                {
                    NumeroInspeccion = item.CODNROINSPEC,
                    NumeroInspeccionSolicitud = item.NROINSPECCION,
                    NumeroSolicitud = item.CODNUMESOLI,
                    FechaInspeccion = (item.FECINSPE != null) ?item.FECINSPE.Value.ToString("dd/MM/yyyy") : "",
                    HoraInspeccion = item.TXTHORAINSP,
                    Inspector = temInspectores,
                    Responsable = responsable.ToArray()[0].Text,
                    CodigoCatastral = item.TXTCODCATASTRAL,
                    EstadoInspeccion = item.TXTESTADOINSPEC,
                    Observaciones = item.TXTOBSERVACION,
                    ListunidadCatastral = lisCodCatas  
                });
            }
            return lisDataQuery;
        }
        public List<RegistroErroresViewModel> RecargarTablaRegistroErrores(DataTableAjaxPostModel model, FiltrarRegistroErroresViewModel FiltrarRegistro, out int totalResultado)
        {
            totalResultado = 0;
            #region Obtener datos
            BE.SIC_CONTROLCALIDAD entQuery = new BE.SIC_CONTROLCALIDAD()
            {
                CODTIPOSOLI = FiltrarRegistro.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarRegistro.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarRegistro.FiltrarCodigoPeriodo,
            };

            ICollection<BE.SIC_CONTROLCALIDAD> srcQuery = new BL.SIC_CONTROLCALIDAD().Listar(entQuery);
            #endregion

            totalResultado = srcQuery.Count();

            ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CONTROLCALIDAD>();
            }
            var lisDataQuery = new List<RegistroErroresViewModel>();
            int index = 1;
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new RegistroErroresViewModel
                {
                    Item = index,
                    CodigoPeriodo = item.CODANOSOLI,
                    CodigoNumeroSolicitud = item.CODNUMESOLI,
                    CodigoTipoSolicitud = item.CODTIPOSOLI,
                    CodigoCorrelativo = item.CODCORRCONCALI,
                    CodigoErrorCalidad = item.CODERRORCALIDAD,
                    NombreErrorCalidad = item.TXTERRORCALIDAD,
                    NombreTipoError = item.TXTDESCRIPCION,
                    CodigoTipoError = item.CODTIPOERROR,
                    CodigoSolicitante = item.CODUSUARESP,
                    NombreSolicitante = item.TXTNOMBRESOLICITANTE,
                    NombreResponsable = item.TXTNOMBRERECEPCION,
                    Detalle = item.TXTDETALLE,
                    FechaRevision = (item.FECREVISION != null) ?item.FECREVISION.Value.ToString("dd/MM/yyyy") : "",
                });
                index++;
            }
            return lisDataQuery;
        }
        public string CargarTipoLlenado(SolicitudUnidadViewModel solunidad) {
            BE.SIC_SOLICITUD entQuerySol = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = solunidad.CodigoTipoSolicitud,
                CODNUMESOLI = solunidad.CodigoNumeroSolicitud,
                CODANOSOLI = solunidad.CodigoPeriodo,
            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySol);
            return srcQuerySol.CODTIPOLLENA;

        }

        public List<ProcedimientoNuevoViewModel> RecargarTablaProcedimientoInicial(DataTableAjaxPostModel model, FiltrarProcedimientoInicialViewModel FiltrarProcedimientoInicial, out int totalResultado)
        {
            totalResultado = 0;
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarProcedimientoInicial.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoInicial.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarProcedimientoInicial.FiltrarCodigoPeriodo,
            };
            ICollection<BE.SIC_SOLISEGUI> srcQuery = new BL.SIC_SOLISEGUI().InicialLis(entQuery);
            BE.SIC_SOLICITUD entQuerySol = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarProcedimientoInicial.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoInicial.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarProcedimientoInicial.FiltrarCodigoPeriodo,
            };
            if (FiltrarProcedimientoInicial.FiltrarCodigoTipoDocumento != null) {
                entQuerySol.CODTIPODOC = FiltrarProcedimientoInicial.FiltrarCodigoTipoDocumento;
            }
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySol);

            #endregion

            totalResultado = srcQuery.Count();

            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0 || (FiltrarProcedimientoInicial.FiltrarCodigoTipoSolicitud == "" && FiltrarProcedimientoInicial.FiltrarNumeroSolicitud == ""))
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
                srcQuerySol = new BE.SIC_SOLICITUD();
            }
            var lisDataQuery = new List<ProcedimientoNuevoViewModel>();
            var i = 1;
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new ProcedimientoNuevoViewModel
                {
                    CodigoTipoProcedimiento = item.TXTNOMBREPROCEDIMIENTO,
                    CodigoTipoRequerimiento = item.TXTNOMBREREQUERIMIENTO,
                    CodigoTipoLlenado = srcQuerySol == null ? "" : srcQuerySol.CODTIPOLLENA,
                    ResponsableActual = item.TXTNOMBRERECEPCION,
                    CodigoCorrelativo = item.CODCORRSEG,
                    EstadoPrevio = "",
                    CodigoEstadoAtencion = item.TXTATENCIONACTUAL,
                    FechaLimite = item.FECHALIMITE,
                    FechaLimiteProgInspec = (item.FECPROGAINSPE != null) ? item.FECPROGAINSPE.Value.ToString("dd/MM/yyyy") : "",
                    FechaLimiteInspec = item.FECHALIMITEINSPECCION,
                    FechaLimiteInfor = item.FECHALIMITEINFORME,
                    
                    FechaModificacion = (item.FECMODIF != null) ? item.FECMODIF.Value.ToString("dd/MM/yyyy") : "",
                    FechaLimiteActual = item.FECHALIMITEACTUALIZACION,
                    NombreEstadoPrevio = item.TXTATENCIONACTUAL,
                    EFechaRecepcion = (item.FECRECEPCION != null) ? item.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "",
                    EFechaSolicitud = (item.FECENVIO != null) ? item.FECENVIO.Value.ToString("dd/MM/yyyy") : "",
                    Item = i
                });
                i++;
            }
            return lisDataQuery;
        }

        public List<ProcedimientoNuevoViewModel> RecargarTablaProcedimientoNuevo(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevo, out int totalResultado) 
        {
            totalResultado = 0;
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarProcedimientoNuevo.FiltrarCodigoPeriodo,
                CODTIPPROC = "'01','02','03'"
            };
            ICollection<BE.SIC_SOLISEGUI> srcQuery;
            if (FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud == "" && FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud == "")
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
                totalResultado = 0;
            }
            else 
            {
                srcQuery = new BL.SIC_SOLISEGUI().NuevoLis(entQuery);
                totalResultado = srcQuery.Count();
            }
            #endregion

            var lisDataQuery = new List<ProcedimientoNuevoViewModel>();
            var i = 1;
            int total = srcQuery.Count;
            if (FiltrarProcedimientoNuevo.CodigoActividad == "0")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }            
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new ProcedimientoNuevoViewModel
                {
                    CodigoTipoProcedimiento = item.TXTNOMBREPROCEDIMIENTO,
                    CodigoCorrelativo = item.CODCORRSEG,
                    ResponsableActual = item.TXTNOMBRERECEPCION,
                    CodigoEstadoAtencion = item.TXTATENCIONPREVIA,
                    NombreEstadoPrevio = item.TXTATENCIONACTUAL,
                    EFechaRecepcion = (item.FECRECEPCION != null) ? item.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "",
                    EFechaSolicitud = (item.FECENVIO != null) ? item.FECENVIO.Value.ToString("dd/MM/yyyy") : "",
                    Item = total
                });
                total--;
                i++;
            }
            return lisDataQuery;
        }
        public List<ProcedimientoNuevoViewModel> RecargarTablaProcedimientoNuevoSegui(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevo, out int totalResultado)
        {
            totalResultado = 0;
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarProcedimientoNuevo.FiltrarCodigoPeriodo,
                CODTIPPROC = "'01','02','03'"
            };
            ICollection<BE.SIC_SOLISEGUI> srcQuery;
            if (FiltrarProcedimientoNuevo.FiltrarCodigoTipoSolicitud == "" && FiltrarProcedimientoNuevo.FiltrarNumeroSolicitud == "")
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
                totalResultado = 0;
            }
            else
            {
                srcQuery = new BL.SIC_SOLISEGUI().NuevoSegui(entQuery);
                totalResultado = srcQuery.Count();
            }
            #endregion

            var lisDataQuery = new List<ProcedimientoNuevoViewModel>();
            var i = 1;
            int total = srcQuery.Count;
            if (FiltrarProcedimientoNuevo.CodigoActividad == "0")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new ProcedimientoNuevoViewModel
                {
                    CodigoTipoProcedimiento = item.TXTNOMBREPROCEDIMIENTO,
                    CodigoCorrelativo = item.CODCORRSEG,
                    ResponsableActual = item.TXTNOMBRERECEPCION,
                    CodigoEstadoAtencion = item.TXTATENCIONPREVIA,
                    NombreEstadoPrevio = item.TXTATENCIONACTUAL,
                    EFechaRecepcion = (item.FECRECEPCION != null) ? item.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "",
                    EFechaSolicitud = (item.FECENVIO != null) ? item.FECENVIO.Value.ToString("dd/MM/yyyy") : "",
                    Item = total
                });
                total--;
                i++;
            }
            return lisDataQuery;
        }

        public List<SolicitudUnidadViewModel> RecargarTablaSolUnidad(DataTableAjaxPostModel model, FiltrarProcedimientoNuevoViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.FiltrarCodigoPeriodo,
                
            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
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
            foreach (var item in data)
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
                    Ubicacion = ""
                });
            }
            return lisDataQuery;
        }

        //public List<SolicitudUnidadViewModel> RecargarTablaSolUnidad(DataTableAjaxPostModel model, FiltrarSolicitudUnidadViewModel FiltrarSolUnidad, out int totalResul)
        //{
        //    var length = (model.length == 0) ? 1 : model.length;
        //    var skip = model.start;
        //    string ordenar = "CODDISTRITO";
        //    var listQuery = BuscarDBSolicitudUnidad(length, skip, ordenar, out totalResul, FiltrarSolUnidad);
        //    var resultado = new List<UnidadCatastralViewModel>(listQuery.Count);
        //    foreach (var s in listQuery)
        //    {
        //        resultado.Add(new UnidadCatastralViewModel
        //        {
        //            CodigoDistrito = s.CODDISTRITO,
        //            CodigoSector = s.CODSECTOR,
        //            CodigoManzana = s.CODMANZANA,
        //            CodigoLote = s.CODLOTE,
        //            Ed = s.CODEDIFICACION,
        //            Entrada = s.CODENTRADA,
        //            Piso = s.CODPISO,
        //            Unidad = s.CODUNIDAD,
        //        });
        //    }
        //    return (resultado == null) ? new List<SolicitudUnidadViewModel>() : resultado;
        //}
        //public ICollection<BE.SIC_SOLUNIDAD> BuscarDBSolicitudUnidad(int length, int skip, string ordenar, out int totalResul, FiltrarSolicitudUnidadViewModel FiltrarSolUnidad)
        //{
        //    BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD();
        //    entQuery.
        //    entQuery.PAGINANUMERO = 1;
        //    entQuery.PAGINAREGISTROS = length;
        //    entQuery.CODDISTRITO = FiltrarSolUnidad.FiltrarCodigoDistrito;
        //    entQuery.CODSECTOR = FiltrarSolUnidad.FiltrarCodigoSector;
        //    // entQuery = new BL.SIC_UNIDAD().BuscarInt(entQuery);
        //    entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
        //    entQuery.PAGINAREGISTROS = length;
        //    entQuery.ORDEN = ordenar;
        //    ICollection<BE.SIC_UNIDAD> srcQuery = new List<BE.SIC_UNIDAD>();
        //    if (entQuery.CODSECTOR != "" && entQuery.CODMANZANA != "")
        //    {
        //        srcQuery = new BL.SIC_UNIDAD().Buscar(entQuery);
        //    }
        //    //totalResul = entQuery.TOTALREGISTROS ?? default(int);
        //    totalResul = 2;
        //    return srcQuery;
        //}

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
                    Indice = i
                });
                i++;
            }
            return (resultado == null) ? new List<UnidadCatastralViewModel>() : resultado;
        }
        public ICollection<BE.SIC_UNIDAD> BuscarDBUnidadCatastral(int length, int skip, string ordenar, out int totalResul, FiltrarUnidadCatastralViewModel FiltrarUnidad)
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
            ICollection<BE.SIC_UNIDAD> srcQuery = new List<BE.SIC_UNIDAD>();
            if (entQuery.CODSECTOR != "" && entQuery.CODMANZANA != "")
            {
                srcQuery = new BL.SIC_UNIDAD().Buscar(entQuery);
            }
            //totalResul = entQuery.TOTALREGISTROS ?? default(int);
            totalResul = 2;
            return srcQuery;
        }

        public ProcedimientoNuevoViewModel BuscarSolicitudProcedimiento(FiltrarProcedimientoNuevoViewModel FiltrarProcedimientoNuevoBuscar)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = FiltrarProcedimientoNuevoBuscar.FiltrarCodigoTipoSolicitud;
            entQuery.CODNUMESOLI = FiltrarProcedimientoNuevoBuscar.FiltrarNumeroSolicitud;
            entQuery.CODTIPODOC = FiltrarProcedimientoNuevoBuscar.FiltrarCodigoTipoDocumentoReg;
            entQuery.CODRESPRECIBE = VariablesWeb.Usuario.CODUSUARIO;
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            entQuery.CODCORRSEG = "0";
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);
            var dataQuery = new ProcedimientoNuevoViewModel();
            if (query == null)
            {
                query = new BE.SIC_SOLISEGUI();
            }
            else if (query.CODTIPPROC == null || query.CODTIPPROC == "01" || query.CODTIPPROC == "02")
            {
                query = new BE.SIC_SOLISEGUI();
            }
            else if(query.CODTIPPROC == "10")
            {
                query = new BE.SIC_SOLISEGUI();
                dataQuery.Cerrada = true;
            }
            else if (query.FECRECEPCION == null)
            {
                query = new BE.SIC_SOLISEGUI();
                dataQuery.SolicitudSinRecepcionar = true;
            }
            else 
            {
                dataQuery.DatosEncontrados = true;
            }
            #endregion
            #region Asignar al ViewModel
            dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
            dataQuery.NumeroSolicitud = query.CODNUMESOLI;
            dataQuery.CodigoTipoDocumento = query.CODTIPODOC;
            dataQuery.ResponsableActual = query.CODRESPRECIBE;
            dataQuery.EstadoPrevio = query.CODESTATENCION;
            dataQuery.Periodo = query.CODANOSOLI;
            dataQuery.Folios = query.NUMFOLIOS;
            dataQuery.CodigoResponsable = query.CODCARCATE;
            dataQuery.NombreEstadoPrevio = query.TXTESTADOATENCION;
            dataQuery.CodigoActividad = query.CODACTIVIDAD;
            dataQuery.CodigoTipoRequerimiento = query.CODTIPOREQ;
            
            if (query.CODNUMESOLI != null)
            {
                dataQuery.SolFechaRecepcion = (query.FECRECEPCION != null ) ? query.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "";
                dataQuery.SolFechaEnvio = (query.FECENVIO !=null ) ? query.FECENVIO.Value.ToString("dd/MM/yyyy") : "";
            }
            dataQuery.ObservacionPrevia = query.TXTOBSERVACION;
            dataQuery.FechaRecepcion = query.FECRECEPCION;
            dataQuery.Asunto = query.TXTASUNTO;
            

            #endregion
            return dataQuery;
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
        public Nullable<bool> ProcesarInpeccionActualizacion(SoliInspeActViewModel SoliInspeAct)
        {
            #region Asignar a la Entidad
            BE.SIC_SOLINSPEACT entQuery = new BE.SIC_SOLINSPEACT()
            {
                CODNUMESOLI = SoliInspeAct.CodigoNumeroSolicitud,
                CODANOSOLI = SoliInspeAct.anoSolicitud,
                CTIPODOCUMENTO = SoliInspeAct.codigoTipoDocumento,
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
                CODANOSOLI = SolUnidad.CodigoPeriodo,
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
                CTIPODOCUMENTO = SolUnidad.CodigoTipoDocumento,
                CODPISO = SolUnidad.Piso,
                CODUNIDAD = SolUnidad.Unidad,
                CODUNI = SolUnidad.CodigoUni,
                CODCONTRIBUYENTE = SolUnidad.CodigoTitular,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                TXTIPREG = ""
            };
            #endregion
            BE.SIC_UNIDAD entQueryUnidad = new BE.SIC_UNIDAD()
            {
                CODUNI = SolUnidad.CodigoUni,
            };
            BE.SIC_UNIDAD srcQueryUnidad = new BL.SIC_UNIDAD().Recuperar(entQueryUnidad);
            //if (srcQueryUnidad == null) {
            //    BE.SIC_RETORNO entSIC_RETORNO_UNI = new BL.SIC_UNIDAD().MigrarEstaticoTemporal(entQueryUnidad);
            //}

            #region Grabar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLUNIDAD().Grabar(entQuery);
            #endregion
            return entSIC_RETORNO;
        }
        public BE.SIC_SOLISEGUI ObtenerUsuarioResponsable(RegistroErroresViewModel RegistroError)
        {
            BE.SIC_SOLISEGUI entQuerySoli = new BE.SIC_SOLISEGUI()
            {
                CODANOSOLI = RegistroError.CodigoPeriodo,
                CODTIPOSOLI = RegistroError.CodigoTipoSolicitud,
                CODNUMESOLI = RegistroError.CodigoNumeroSolicitud,
                CODCORRSEG = "0",
            };
            BE.SIC_SOLISEGUI srcQuery = new BL.SIC_SOLISEGUI().Regerror(entQuerySoli);
            return srcQuery;
        }

        public Nullable<bool> AgregarRegistroErrores(RegistroErroresViewModel[] RegistroErrorList)
        {
            #region Asignar a la Entidad
            int contador = 0;
            foreach (RegistroErroresViewModel RegistroError in RegistroErrorList)
            {
                BE.SIC_SOLISEGUI srcQuery = ObtenerUsuarioResponsable(RegistroError);

                BE.SIC_CONTROLCALIDAD entQuery = new BE.SIC_CONTROLCALIDAD()
                {
                    CODCORRCONCALI = RegistroError.CodigoCorrelativo,
                    CODANOSOLI = RegistroError.CodigoPeriodo,
                    CODTIPOSOLI = RegistroError.CodigoTipoSolicitud,
                    CODNUMESOLI = RegistroError.CodigoNumeroSolicitud,
                    CODTIPOERROR = RegistroError.CodigoTipoError,
                    CODERRORCALIDAD = RegistroError.CodigoErrorCalidad,
                    CODUSUARESP = RegistroError.CodigoSolicitante,
                    CODUSUASIS = srcQuery.CODRESPRECIBE,
                    CODCART = srcQuery.CODCARCATE,
                    TXTDETALLE = RegistroError.Detalle,
                    TXTNROINSPECREF = RegistroError.NumeroInspecRef,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    FECREVISION = System.DateTime.Now,
                    TXTIPREG = ""
                };
                #endregion
                #region Grabar, Actualizar, Eliminar
                BE.SIC_RETORNO entSIC_RETORNO;
                entSIC_RETORNO = new BL.SIC_CONTROLCALIDAD().Grabar(entQuery);
                if (entSIC_RETORNO.Ok == false)
                {
                    contador++;
                }
                #endregion
            }
            return (contador == 0) ? true : false;
        }
        public Nullable<bool> EditarRegistroErrores(RegistroErroresViewModel RegistroError)
        {
            #region Asignar a la Entidad
            BE.SIC_CONTROLCALIDAD entQuery = new BE.SIC_CONTROLCALIDAD()
            {
                CODCORRCONCALI = RegistroError.CodigoCorrelativo,
                CODANOSOLI = RegistroError.CodigoPeriodo,
                CODTIPOSOLI = RegistroError.CodigoTipoSolicitud,
                CODNUMESOLI = RegistroError.CodigoNumeroSolicitud,
                CODTIPOERROR = RegistroError.CodigoTipoError,
                CODERRORCALIDAD = RegistroError.CodigoErrorCalidad,
                TXTDETALLE = RegistroError.Detalle,
                TXTNROINSPECREF = RegistroError.NumeroInspecRef,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                FECREVISION = System.DateTime.Now,
                TXTIPREG = ""
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_CONTROLCALIDAD().Actualizar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public FiltrarSolicitarProcedimientoViewModel BuscarProcedimientoNuevo(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string CodigoCorrelativo)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuerySoli = new BE.SIC_SOLISEGUI();
            entQuerySoli.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuerySoli.CODNUMESOLI = NumeroSolicitud;
            entQuerySoli.CODANOSOLI = CodigoPeriodo;
            entQuerySoli.CODCORRSEG = CodigoCorrelativo;
            BE.SIC_SOLISEGUI querySoli = new BL.SIC_SOLISEGUI().Filtrar(entQuerySoli);

            var CodAnt = (Int32.Parse(CodigoCorrelativo) - 1).ToString().PadLeft(4, '0');
            entQuerySoli.CODCORRSEG = CodAnt;
            BE.SIC_SOLISEGUI querySoliAnt = new BL.SIC_SOLISEGUI().Filtrar(entQuerySoli);

            BE.SIC_SOLICITUD entQuery = new BE.SIC_SOLICITUD();
            entQuery.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuery.CODNUMESOLI = NumeroSolicitud;
            entQuery.CODANOSOLI = CodigoPeriodo;
            BE.SIC_SOLICITUD query = new BL.SIC_SOLICITUD().Recuperar(entQuery);
            #endregion
            string id = querySoli.CODESTATENCIONE;
            #region Asignar al ViewModel
            var dataQuery = new FiltrarSolicitarProcedimientoViewModel()
            {
                ListTipoProcedimiento = new ProcedimientoNuevoHandler().ListadoTipoProcedimientoFijo(querySoli.CODCARCAT, id),
                ListTipoRequerimiento = new ProcedimientoNuevoHandler().ListadoTipoRequerimiento(),
                ListAsignarResponsable = new ProcedimientoNuevoHandler().ListadoAsignarResponsableFijo(querySoli.CODTIPPROC, querySoli.CODCARCAT, id),
                ListTipoLlenado = new ProcedimientoNuevoHandler().ListadoTipoLlenado(),
                ListAccion = new ProcedimientoNuevoHandler().ListadoAcciones(),
                CodigoTipoProcedimiento = querySoli.CODTIPPROC,
                CodigoTipoRequerimiento = querySoli.CODTIPOREQ,
                CodigoTipoLlenado = query.CODTIPOLLENA,
                CodigoAccion = querySoli.CODACCION,
                CodigoAsignarResponsable = querySoli.CODRESPRECIBE,
                ModoApertura = "Ver",
                CodigoNumeroSolicitud = querySoli.CODNUMESOLI,
                Responsable = querySoli.TXTNOMBREREMITENTE,
                PuestoResponsable = querySoli.TXTPUESTOREMITENTE,
                EstadoAtencionPrevia = querySoli.TXTATENCIONPREVIA,
                FechaDerivacionPrevia = (querySoli.FECENVIO != null) ? querySoli.FECENVIO.Value.ToString("dd/MM/yyyy") : "",
                FechaRecepcion = (querySoli.FECRECEPCION != null) ? querySoli.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "",
                AsuntoProcedimiento = querySoli.TXTASUNTO,
                ObservacionRemitente = querySoliAnt.TXTOBSERVACION,
                ObservacionRecepcion = querySoli.TXTOBSERVACION

            };

            #endregion
            return dataQuery;
        }
        public RegistrarInspeccion BuscarInspeciones(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string NumeroInspec)
        {
            #region Obtener datos
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC();
            entQuery.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuery.CODNUMESOLI = NumeroSolicitud;
            entQuery.CODANOSOLI = CodigoPeriodo;
            entQuery.CODNROINSPEC = NumeroInspec;
            BE.SIC_PROGINSPEC query = new BL.SIC_PROGINSPEC().Recuperar(entQuery);

            IEnumerable<BE.SIC_TABPROCE> lisQueryInspec = new BL.SIC_TABPROCE().Listar(new BE.SIC_TABPROCE() { CODCARCAT = "03", CODTIPPROC = "05" });
            var lisDataQueryInspec = new List<SelectListItem>();
            foreach (var item in lisQueryInspec) { lisDataQueryInspec.Add(new SelectListItem { Value = item.CODUSUARIO, Text = item.TXTNOMBRES }); }

            IEnumerable<BE.SIC_MOVINSPEC> lisQueryDetalle = new BL.SIC_MOVINSPEC().Listar(new BE.SIC_MOVINSPEC()
            {
                CODANOSOLI = CodigoPeriodo,
                CODTIPOSOLI = CodigoTipoSolicitud,
                CODNUMESOLI = NumeroSolicitud,
                CODNROINSPEC = NumeroInspec
            });
            var inspectores = new List<SelectListItem>(); string temInspectores = string.Empty;
            var responsable = new List<SelectListItem>(); string temResponsable = string.Empty;
            string codigoResponsable = "";
            foreach (var itemInspectores in lisQueryDetalle)
            {
                inspectores.Add(new SelectListItem() { Value = itemInspectores.CODUSUASIS, Text = itemInspectores.TXTNOMBRE });
                if (itemInspectores.FLAGRESPONSABLE == "1")
                {
                    codigoResponsable = itemInspectores.CODUSUASIS;
                    responsable.Add(new SelectListItem() { Value = itemInspectores.CODUSUASIS, Text = itemInspectores.TXTNOMBRE });
                }
            }
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistrarInspeccion();
            dataQuery.NroInspeccion = query.CODNROINSPEC;
            dataQuery.FechaInspeccion = query.FECINSPE.ToString();
            dataQuery.HoraInspeccion = query.TXTHORAINSP;
            dataQuery.codInspectores = inspectores;
            dataQuery.codResponsable = inspectores;
            dataQuery.Responsable = codigoResponsable;
            dataQuery.FechaCitacion = query.FECCITACION.ToString();
            dataQuery.FechaAvisoInspeccion = query.FECAVIINSPEC.ToString();
            dataQuery.Observacion = query.TXTOBSERVACION;

            #endregion
            return dataQuery;
        }

        public List<SelectListItem> ListadoTipoProcedimientoFijo(string cargo, string estadoe)
        {
            
            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            if (cargo == "")
            {
                TABPROCE.CODCARCAT = "02";
                TABPROCE.CODESTATENCIONE = "01";
            }
            else
            {
                TABPROCE.CODCARCAT = cargo;
                TABPROCE.CODESTATENCIONE = estadoe;

            }
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
        public List<SelectListItem> ListadoAsignarResponsableFijo(string idProc, string cargo, string estadoe)
        {

            BE.SIC_TABPROCE TABPROCE = new BE.SIC_TABPROCE();
            TABPROCE.CODTIPPROC = idProc;
            if (cargo == "")
            {
                TABPROCE.CODCARCAT = "02";
                TABPROCE.CODESTATENCIONE = "01";
            }
            else
            {
                TABPROCE.CODCARCAT = cargo;
                TABPROCE.CODESTATENCIONE = estadoe;
            }
            
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


        public ProcedimientoInicialViewModel BuscarProcedimientoInicial(string CodigoTipoSolicitud, string NumeroSolicitud, string CodigoPeriodo, string CodigoCorrelativo)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuery.CODNUMESOLI = NumeroSolicitud;
            entQuery.CODANOSOLI = CodigoPeriodo;
            entQuery.CODCORRSEG = CodigoCorrelativo;
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Filtrar(entQuery);

            var CodAnt = (Int32.Parse(CodigoCorrelativo) - 1).ToString().PadLeft(4, '0');
            entQuery.CODCORRSEG = CodAnt;
            BE.SIC_SOLISEGUI querySoli = new BL.SIC_SOLISEGUI().Filtrar(entQuery);
            #endregion

            #region Obtener datos
            BE.SIC_SOLICITUD entQuerySol = new BE.SIC_SOLICITUD();
            entQuerySol.CODTIPOSOLI = CodigoTipoSolicitud;
            entQuerySol.CODNUMESOLI = NumeroSolicitud;
            entQuerySol.CODANOSOLI = CodigoPeriodo;
            BE.SIC_SOLICITUD querySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySol);
            if (querySol == null)
            {
                querySol = new BE.SIC_SOLICITUD();
            }
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new ProcedimientoInicialViewModel()
            {
                NumeroSolicitud = query.CODNUMESOLI,
                ListTipoRequerimiento = new ProcedimientoInicialHandler().ListadoTipoRequerimiento(),
                ListTipoProcedimiento = ListadoTipoProcedimientoFijo("", ""),
                ListAsignarReponsable = new List<SelectListItem>(),
                ListTipoLlenado = new ProcedimientoInicialHandler().ListadoTipoLlenado(),
                ListTipoAccion = new ProcedimientoInicialHandler().ListadoTipoAccion(),
                Asunto = query.TXTASUNTO,
                ResponsablePrevio = query.TXTNOMBREREMITENTE,
                EstadoSolicitudPrevio = query.TXTATENCIONPREVIA,
                CodigoEstadoPrevio = query.CODESTATENCION,
                cadfecharecepcion = query.FECRECEPCION.HasValue ? query.FECRECEPCION.Value.ToString("dd/MM/yyyy") : "",
                cadfechaenvio = query.FECENVIO.HasValue ?query.FECENVIO.Value.ToString("dd/MM/yyyy") : "",
                cadfechasolicitud = query.FECSOLICITUD.HasValue ? query.FECSOLICITUD.Value.ToString("dd/MM/yyyy") : string.Empty,
                ObservacionRecepcion = query.TXTOBSERVACION,
                ObservacionRemitente = querySoli.TXTOBSERVACION,
                CodigoTipoSolicitud = query.CODTIPOSOLI,
                Folio = query.NUMFOLIOS,
                anosolicitud = query.CODANOSOLI,
                CodigoCargoAnterior = query.CODCARCAT,
                CodigoTipoProcedimiento = query.CODTIPPROC,
                CodigoTipoRequerimiento = query.CODTIPOREQ,
                CodigoAsignarReponsable = query.CODRESPRECIBE,
                CodigoTipoLlenado = querySol.CODTIPOLLENA,
                CodigoCorrelativo = query.CODCORRSEG,
                CodigoTipoAccion = query.CODACCION
            };
            if (query.CODTIPOSOLI == "010003")
                {
                    dataQuery.NombreTipoSolicitud = "CATASTRAL";
                    dataQuery.CodigoTipoDocumento = "001";
                    dataQuery.NombreTipoDocumento = "REQUERIMIENTO INTERNO";
                    dataQuery.CodigoAreaSolicitante = @ConfigurationManager.AppSettings["CODAREA"];
                    dataQuery.NombreAreaSolicitante = "SUB GERENCIA DE CATASTRO";
                }
            dataQuery.NumeroSolicitud = query.CODNUMESOLI;
            #endregion
            return dataQuery;
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

            //MIGRAR ESTATICO ELIMINAR

            //MIGRAR ESTATICO ELIMINAR

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_SOLUNIDAD().Eliminar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> EliminarRegistroError(FiltrarRegistroErroresViewModel Registro)
        {
            #region Asignar a la Entidad
            BE.SIC_CONTROLCALIDAD entQuery = new BE.SIC_CONTROLCALIDAD()
            {
                CODCORRCONCALI = Registro.FiltrarCodigoCorrelativo,
                CODANOSOLI = Registro.FiltrarCodigoPeriodo,
                CODTIPOSOLI = Registro.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = Registro.FiltrarNumeroSolicitud,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                TXTIPREG = ""
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_CONTROLCALIDAD().Eliminar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> ProcesarProcedimientoInicial(ProcedimientoInicialViewModel ProcedimientoInicial)
        {
            BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = ProcedimientoInicial.anosolicitud,
                CODNUMESOLI = ProcedimientoInicial.NumeroSolicitud,
                CODTIPOSOLI = ProcedimientoInicial.CodigoTipoSolicitud
            };
            BE.SIC_SOLICITUD srcTempQuery = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
            srcTempQuery.CODTIPOLLENA = ProcedimientoInicial.CodigoTipoLlenado;
            BE.SIC_RETORNO entSIC_RETORNO_SOL = new BL.SIC_SOLICITUD().Actualizar(srcTempQuery);

            BE.SIC_SOLISEGUI tempQuerySoli = new BE.SIC_SOLISEGUI()
            {
                CODANOSOLI = ProcedimientoInicial.anosolicitud,
                CODNUMESOLI = ProcedimientoInicial.NumeroSolicitud,
                CODTIPOSOLI = ProcedimientoInicial.CodigoTipoSolicitud,
                CODCORRSEG = ProcedimientoInicial.CodigoCorrelativo
            };
            #region Asignar a la Entidad
            BE.SIC_SOLISEGUI srcTempQuerySoli = new BL.SIC_SOLISEGUI().Filtrar(tempQuerySoli);
            srcTempQuerySoli.TXTOBSERVACION = ProcedimientoInicial.ObservacionRecepcion;
            srcTempQuerySoli.CODTIPPROC = ProcedimientoInicial.CodigoTipoProcedimiento;
            srcTempQuerySoli.CODTIPOREQ = ProcedimientoInicial.CodigoTipoRequerimiento;
            srcTempQuerySoli.CODACCION = ProcedimientoInicial.CodigoTipoAccion;
            srcTempQuerySoli.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            srcTempQuerySoli.CODRESPRECIBE = ProcedimientoInicial.CodigoAsignarReponsable;
            #endregion

            #region Grabar
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLISEGUI().Actualizar(srcTempQuerySoli);
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> ProcesarProcedimientoNuevo(ProcedimientoNuevoViewModel ProcedimientoNuevo, out string CodigoCorrelativo)
        {
            BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = ProcedimientoNuevo.Periodo,
                CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                CODTIPODOC = ProcedimientoNuevo.CodigoTipoDocumento 
            };
            BE.SIC_SOLICITUD srcTempQuery = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
            srcTempQuery.CODTIPOLLENA = (ProcedimientoNuevo.CodigoTipoLlenado == null) ? "" : ProcedimientoNuevo.CodigoTipoLlenado;
            BE.SIC_RETORNO entSIC_RETORNO_SOL = new BL.SIC_SOLICITUD().Actualizar(srcTempQuery);
            if (ProcedimientoNuevo.CodigoTipoSolicitud == "010001")
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
                    VPERREC = ProcedimientoNuevo.CodigoResponsable,
                    VOBSERV = ProcedimientoNuevo.Observaciones,
                    VFECING = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VFOLIOS = "0",
                    VCODACT2 = ProcedimientoNuevo.CodigoActividad,
                    VCODACC2 = ProcedimientoNuevo.CodigoAccion
                };
                BE.SIC_RETORNO entSIC_RETORNO_EXT = new BL.PGD_TRAMITE_EXT().Grabar(entQueryExt);
            }
            if (ProcedimientoNuevo.CodigoTipoSolicitud == "010002")
            {
                BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                {
                    VTIPO = 0,
                    VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VID = srcTempQuery.ID_REF,
                    VTIPO_DOCUMENTO = ProcedimientoNuevo.CodigoTipoDocumento,
                    VOBSERVACION = ProcedimientoNuevo.Observaciones,
                    VUSUARIO = VariablesWeb.IdUsuarioIntento,
                    VUSUARIO_AREA = @ConfigurationManager.AppSettings["CODAREA"],          //AREA QUE REMITE
                    VCONTRIBUYENTE = "",
                    VPAGINAS = 0,
                    VREQRPTA = 0,
                    VFECLIMRPTA = null,
                    VNRODOC = ProcedimientoNuevo.NumeroSolicitud,
                    VCOD_ACTIVIDAD = ProcedimientoNuevo.CodigoActividad,
                };
                BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().Grabar(entQueryExt);
            }

            

            
            #region Asignar a la Entidad
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                CODANOSOLI = ProcedimientoNuevo.Periodo,
                CTIPODOCUMENTO = ProcedimientoNuevo.CodigoTipoDocumento,
                CODRESPENVIA = VariablesWeb.IdUsuarioIntento,
                CODRESPRECIBE = ProcedimientoNuevo.CodigoResponsable,
                FECENVIO = System.DateTime.Now,
                TXTOBSERVACION = ProcedimientoNuevo.Observaciones,
                CODACCION = ProcedimientoNuevo.CodigoAccion,
                CODACTIVIDAD = ProcedimientoNuevo.CodigoActividad,
                NUMFOLIOS = ProcedimientoNuevo.Folios,
                CODTIPPROC = ProcedimientoNuevo.CodigoTipoProcedimiento,
                CODTIPOREQ = ProcedimientoNuevo.CodigoTipoRequerimiento,
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODCARCATE = ProcedimientoNuevo.CargoResponsable,
                CODESTATENCION = ProcedimientoNuevo.CodigoEstadoAtencion,
                CODESTATENCIONE = ProcedimientoNuevo.EstadoPrevio,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar
            if (entQuery.CODTIPPROC == "10") {
                BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
                {
                    CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                    CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                    CODANOSOLI = ProcedimientoNuevo.Periodo,
                    CODTIPODOC = ProcedimientoNuevo.CodigoTipoDocumento
                };
                BE.SIC_SOLICITUD srcQuerySoli = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
                srcQuerySoli.CODESTADOFINAL = ProcedimientoNuevo.CodigoEstadoAtencion;
                DateTime fechaCierre = DateTime.Now;
                srcQuerySoli.FECFINSOLICITUD = fechaCierre;
                BE.SIC_RETORNO entSIC_RETORNOSOLI = new BL.SIC_SOLICITUD().Actualizar(srcQuerySoli);

                BE.SIC_SOLUNIDAD entQuerySoliUnidad;
                if (ProcedimientoNuevo.CodigoTipoSolicitud == "010003")
                {
                    entQuerySoliUnidad = new BE.SIC_SOLUNIDAD()
                    {
                        CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                        CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                        CODANOSOLI = ProcedimientoNuevo.Periodo
                    };
                }
                else
                {
                    entQuerySoliUnidad = new BE.SIC_SOLUNIDAD()
                    {
                        CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                        CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                        CODANOSOLI = ProcedimientoNuevo.Periodo,
                        CTIPODOCUMENTO = ProcedimientoNuevo.CodigoTipoDocumento
                    };
                }


                ICollection<BE.SIC_SOLUNIDAD> ListaSolUnidad = new BL.SIC_SOLUNIDAD().ParaMigrar(entQuerySoliUnidad);

                var cont = 0; DateTime? fechaTemp = null;
                foreach(BE.SIC_SOLUNIDAD AgregarSolUnidadCatastral in ListaSolUnidad) {

                    BE.SIC_UNIDAD entUnidadTemp = new BL.SIC_UNIDAD().Recuperar(new BE.SIC_UNIDAD() { CODUNI = AgregarSolUnidadCatastral.CODUNI, ESTATICO = false });

                    //if (entUnidadTemp != null)
                    //{
                        if (cont == 0)
                        {
                            fechaTemp = DateTime.Now;
                        }
                        BE.SIC_UNIDAD tempQueryUni = new BE.SIC_UNIDAD(){
                            CODUNI = AgregarSolUnidadCatastral.CODUNI,
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                            FECACT = fechaTemp
                        };
                        
                        //BE.SIC_RETORNO entSIC_RETORNO_UC = new UnidadCatastralHandler().ProcesarMigracionTemporalEstatico(tempQueryUni);
                        BE.SIC_RETORNO entSIC_RETORNO_UC = new BL.SIC_UNIDAD().MigrarTemporalEstatico(tempQueryUni);

                        BE.SIC_UNIDAD entUnidad = new BL.SIC_UNIDAD().Recuperar(new BE.SIC_UNIDAD() { CODUNI = AgregarSolUnidadCatastral.CODUNI, ESTATICO = true });
                        if (entUnidad != null)
                        {

                            if (srcQuerySoli.CODTIPOLLENA != null && entUnidad.CODTIPOLLENA == null)
                            {
                                entUnidad.CODTIPOLLENA = srcQuerySoli.CODTIPOLLENA;
                            }
                            entUnidad.FECFINSOLICITUD = fechaCierre;
                            entUnidad.ESTATICO = true;
                            BE.SIC_RETORNO entSIC_RET_UNIDAD = new BL.SIC_UNIDAD().Actualizar(entUnidad);
                        }
                    //}
                        cont++;
                }
            }

            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLISEGUI().Grabar(entQuery);
            CodigoCorrelativo = entSIC_RETORNO.CODIGO;
            #endregion
            return entSIC_RETORNO.Ok;

        }

        public Nullable<bool> ProcesarUnidadHistoricoPDF(ProcedimientoNuevoViewModel ProcedimientoNuevo, out List<UnidadHistoricaViewModel> ListaUnidadHistorica)
        {
            BE.SIC_SOLICITUD tempQuery = new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = ProcedimientoNuevo.Periodo,
                CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                CODTIPODOC = ProcedimientoNuevo.CodigoTipoDocumento
            };
            BE.SIC_SOLICITUD srcTempQuery = new BL.SIC_SOLICITUD().Recuperar(tempQuery);
            srcTempQuery.CODTIPOLLENA = (ProcedimientoNuevo.CodigoTipoLlenado == null) ? "" : ProcedimientoNuevo.CodigoTipoLlenado;
            BE.SIC_RETORNO entSIC_RETORNO_SOL = new BL.SIC_SOLICITUD().Actualizar(srcTempQuery);
            
            #region Asignar a la Entidad
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                CODANOSOLI = ProcedimientoNuevo.Periodo,
                CTIPODOCUMENTO = ProcedimientoNuevo.CodigoTipoDocumento,
                CODRESPENVIA = VariablesWeb.IdUsuarioIntento,
                CODRESPRECIBE = ProcedimientoNuevo.CodigoResponsable,
                FECENVIO = System.DateTime.Now,
                TXTOBSERVACION = ProcedimientoNuevo.Observaciones,
                CODACCION = ProcedimientoNuevo.CodigoAccion,
                CODACTIVIDAD = ProcedimientoNuevo.CodigoActividad,
                NUMFOLIOS = ProcedimientoNuevo.Folios,
                CODTIPPROC = ProcedimientoNuevo.CodigoTipoProcedimiento,
                CODTIPOREQ = ProcedimientoNuevo.CodigoTipoRequerimiento,
                CODCARCAT = VariablesWeb.CodigoPerfil,
                CODCARCATE = ProcedimientoNuevo.CargoResponsable,
                CODESTATENCION = ProcedimientoNuevo.CodigoEstadoAtencion,
                CODESTATENCIONE = ProcedimientoNuevo.EstadoPrevio,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            List<UnidadHistoricaViewModel> ListaUnidad = new List<UnidadHistoricaViewModel>();

            #region Grabar
            if (entQuery.CODTIPPROC == "10")
            {
                BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
                {
                    CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                    CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                    CODANOSOLI = ProcedimientoNuevo.Periodo,
                    CODTIPODOC = ProcedimientoNuevo.CodigoTipoDocumento
                };
                BE.SIC_SOLICITUD srcQuerySoli = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);

                BE.SIC_SOLUNIDAD entQuerySoliUnidad;
                if (ProcedimientoNuevo.CodigoTipoSolicitud == "010003")
                {
                    entQuerySoliUnidad = new BE.SIC_SOLUNIDAD()
                    {
                        CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                        CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                        CODANOSOLI = ProcedimientoNuevo.Periodo
                    };
                }
                else
                {
                    entQuerySoliUnidad = new BE.SIC_SOLUNIDAD()
                    {
                        CODTIPOSOLI = ProcedimientoNuevo.CodigoTipoSolicitud,
                        CODNUMESOLI = ProcedimientoNuevo.NumeroSolicitud,
                        CODANOSOLI = ProcedimientoNuevo.Periodo,
                        CTIPODOCUMENTO = ProcedimientoNuevo.CodigoTipoDocumento
                    };
                }


                ICollection<BE.SIC_SOLUNIDAD> ListaSolUnidad = new BL.SIC_SOLUNIDAD().ParaMigrar(entQuerySoliUnidad);
                ICollection<BE.SIC_SOLUNIDAD> ListaSolUnidadLote = new BL.SIC_SOLUNIDAD().ParaMigrarLote(entQuerySoliUnidad);

                foreach (BE.SIC_SOLUNIDAD AgregarSolUnidadLote in ListaSolUnidadLote)
                {
                    RegistrarArchivos registrarArchivos = new RegistrarArchivos()
                    {
                        CodigoDepartamento = AgregarSolUnidadLote.CODDEPARTAMENTO,
                        CodigoProvincia = AgregarSolUnidadLote.CODPROVINCIA,
                        CodigoDistrito = AgregarSolUnidadLote.CODDISTRITO,
                        CodigoSector = AgregarSolUnidadLote.CODSECTOR,
                        CodigoManzana = AgregarSolUnidadLote.CODMANZANA,
                        CodigoLote = AgregarSolUnidadLote.CODLOTE,
                        FiltrarVersion = (AgregarSolUnidadLote.NUMVERSION != null) ? AgregarSolUnidadLote.NUMVERSION : "1"
                    };

                    string tipo = "03"; //Lote
                    string rut = "";
                    var local = GrabarLoteServer(registrarArchivos, out rut);

                    UnidadHistoricaViewModel UnidadHistorica = new UnidadHistoricaViewModel()
                    {

                        CodigoDepartamento = AgregarSolUnidadLote.CODDEPARTAMENTO,
                        CodigoProvincia = AgregarSolUnidadLote.CODPROVINCIA,
                        CodigoDistrito = AgregarSolUnidadLote.CODDISTRITO,
                        CodigoSector = AgregarSolUnidadLote.CODSECTOR,
                        CodigoManzana = AgregarSolUnidadLote.CODMANZANA,
                        CodigoLote = AgregarSolUnidadLote.CODLOTE,
                        Ruta = rut.Substring(0, rut.Length - 4),
                        TipoFicha = tipo
                    };
                    ListaUnidad.Add(UnidadHistorica);
                }
                

                foreach (BE.SIC_SOLUNIDAD AgregarSolUnidadCatastral in ListaSolUnidad)
                {

                    BE.SIC_UNIDAD entUnidadTemp = new BL.SIC_UNIDAD().Recuperar(new BE.SIC_UNIDAD() { CODUNI = AgregarSolUnidadCatastral.CODUNI, ESTATICO = false });
                    BE.SIC_UNIDAD entUnidadEsta = new BL.SIC_UNIDAD().Recuperar(new BE.SIC_UNIDAD() { CODUNI = AgregarSolUnidadCatastral.CODUNI, ESTATICO = true });

                    if (entUnidadTemp != null && entUnidadEsta != null)
                    {
                        if (entUnidadTemp.FECMODIF != null)
                        {
                            RegistrarArchivos registrarArchivos = new RegistrarArchivos()
                            {
                                FiltrarCodigoUnidad = entUnidadTemp.CODUNI,
                                FiltrarVersion = entUnidadEsta.NVERSION
                            };

                            string tipo = "";

                            if (entUnidadTemp.CODEDIFICACION.Equals("XX") || entUnidadTemp.CODPISO.Equals("XX") || 
                                entUnidadTemp.CODENTRADA.Equals("XX") || entUnidadTemp.CODUNIDAD.Equals("XXX"))
                            {
                                tipo = "02"; //Bien Comun
                            } else {
                                tipo = "01"; //Unidad Catastral
                            }

                            string rut = "";
                            var local = GrabarUnidadServer(registrarArchivos, out rut);

                            UnidadHistoricaViewModel UnidadHistorica = new UnidadHistoricaViewModel()
                            {
                                CodigoUnico = entUnidadTemp.CODUNI,
                                Ruta = rut.Substring(0, rut.Length-4),
                                TipoFicha = tipo
                            };
                            ListaUnidad.Add(UnidadHistorica);
                        } 
                        
                    }
                                   
                }
            }

            //BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLISEGUI().Grabar(entQuery);
            ListaUnidadHistorica = ListaUnidad;
            //CodigoCorrelativo = entSIC_RETORNO.CODIGO;
            #endregion
            return true;

        }

        public Nullable<bool> GrabarUnidadServer(RegistrarArchivos Informe, out string Ruta)
        {
            #region Subir archivo
            string repo = "DOCUMENTOS"; string tiporepo = "UNIDAD\\HISTORICO";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                _Ext = "pdf";
                string tempCodigo = Informe.FiltrarCodigoUnidad + Informe.FiltrarVersion;
                string tempCodigo1 = Informe.FiltrarCodigoUnidad + "," + Informe.FiltrarVersion;
                string aleatorio = Guid.NewGuid().ToString();
                string _FN = tempCodigo + "_" + "UNIDAD_DOC" + aleatorio + "." + _Ext;
                _Codigo = tempCodigo + "_" + "UNIDAD_DOC" + aleatorio;

                _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                {
                    TXTNOMTABLA = "SIC_HST_UNIDAD",
                    CODPKTABLA = tempCodigo1,
                    TXTPKTABLANOM = "CODUNI,NVERSION",
                    TXTEXTENSION = _Ext,
                    TXTRUTA = _Ruta,
                    FLGPRINCIPAL = "1",
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };
                BE.SIC_RETORNO entSIC_RETORNO_DETA;
                entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Grabar(entQueryDeta);
                
                subida = true;
            
            #endregion
            Ruta = _Ruta;
            return subida;
        }

        public Nullable<bool> GrabarLoteServer(RegistrarArchivos Informe, out string Ruta)
        {
            #region Subir archivo
            string repo = "DOCUMENTOS"; string tiporepo = "LOTE\\HISTORICO";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;

            _Ext = "pdf";
            string tempCodigo = Informe.CodigoDepartamento + Informe.CodigoProvincia + Informe.CodigoDistrito + Informe.CodigoSector + Informe.CodigoManzana + Informe.CodigoLote +  Informe.FiltrarVersion;
            string tempCodigo1 = Informe.CodigoDepartamento + "," + Informe.CodigoProvincia + "," + Informe.CodigoDistrito +  "," + Informe.CodigoSector + "," + Informe.CodigoManzana + "," + Informe.CodigoLote + "," + Informe.FiltrarVersion;
            string aleatorio = Guid.NewGuid().ToString();
            string _FN = tempCodigo + "_" + "LOTE_DOC" + aleatorio + "." + _Ext;
            _Codigo = tempCodigo + "_" + "LOTE_DOC" + aleatorio;

            _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
            BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
            {
                TXTNOMTABLA = "SIC_HST_LOTE",
                CODPKTABLA = tempCodigo1,
                TXTPKTABLANOM = "CODDEPARTAMENTO, CODPROVINCIA, CODSECTOR, CODMANZANA, CODLOTE, NUMVERSION",
                TXTEXTENSION = _Ext,
                TXTRUTA = _Ruta,
                FLGPRINCIPAL = "1",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO_DETA;
            entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Grabar(entQueryDeta);

            subida = true;

            #endregion
            Ruta = _Ruta;
            return subida;
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