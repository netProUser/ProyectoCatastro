using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;

namespace MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion
{
    public class ProgramarInspeccionHandler
    {
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
        public FiltrarProgramarInspeccionViewModel BuscarSolicitud(FiltrarProgramarInspeccionViewModel FiltrarProcedimientoNuevoBuscar)
        {
            var dataQuery = new FiltrarProgramarInspeccionViewModel();
            BE.SIC_SOLUNIDAD entQuerySolUni = new BE.SIC_SOLUNIDAD()
            {
                    CODTIPOSOLI = FiltrarProcedimientoNuevoBuscar.codTipoSolicitud,
                    CODNUMESOLI = FiltrarProcedimientoNuevoBuscar.nroSolicitud,
                    CODANOSOLI = System.DateTime.Now.Year.ToString()
            };
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarProcedimientoNuevoBuscar.codTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoNuevoBuscar.nroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODCORRSEG = "0",
                CTIPODOCUMENTO = ""
            };
            BE.SIC_SOLISEGUI entQueryIni = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarProcedimientoNuevoBuscar.codTipoSolicitud,
                CODNUMESOLI = FiltrarProcedimientoNuevoBuscar.nroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODCORRSEG = "0",
                CTIPODOCUMENTO = ""
            };
            if (FiltrarProcedimientoNuevoBuscar.CodigoTipoDocumentoReg != "REQI")
            {
                entQuerySolUni.CTIPODOCUMENTO = FiltrarProcedimientoNuevoBuscar.CodigoTipoDocumentoReg;
                entQuery.CODTIPODOC = FiltrarProcedimientoNuevoBuscar.CodigoTipoDocumentoReg;
                entQueryIni.CODTIPODOC = FiltrarProcedimientoNuevoBuscar.CodigoTipoDocumentoReg;
            }
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);
            IEnumerable<BE.SIC_SOLISEGUI> querys = new BL.SIC_SOLISEGUI().InicialLis(entQueryIni);
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarSolMasivo(entQuerySolUni);
            List<CodigoCatastralAsignado> listaCatastral = new List<CodigoCatastralAsignado>();
            int i = 0;
            foreach (var data in srcQuery)
            {
                if (query == null)
                {
                    query = new BE.SIC_SOLISEGUI();
                    dataQuery.DatosEncontrados = false;
                }
                else
                {
                    dataQuery.DatosEncontrados = true;
                }
               
                foreach (var item in querys)
                {
                    dataQuery.FechaLimite = item.FECHALIMITE != null ? Convert.ToDateTime(item.FECHALIMITE).ToString("dd/MM/yyyy") : "";
                    dataQuery.FechaLimiteInspeccion = item.FECHALIMITEINSPECCION != null ? Convert.ToDateTime(item.FECHALIMITEINSPECCION).ToString("dd/MM/yyyy") : "";
                    dataQuery.TipoLlenado = item.TXTNOMBRELLENADO;
                    dataQuery.FechaLimiProgInspec = item.FECPROGAINSPE.HasValue ? item.FECPROGAINSPE.Value.ToString("dd/MM/yyyy") : "";
                }

                dataQuery.codTipoSolicitud = data.CODTIPOSOLI;
                dataQuery.nroSolicitud = data.CODNUMESOLI;
                dataQuery.AniSolcitud = data.CODANOSOLI;
                dataQuery.CodigoTipoDocumentoReg = data.CTIPODOCUMENTO;
                /*representante*/
                dataQuery.TipoDocumentoRepresentante = query.TXTDES_TIPODOCREPL;
                dataQuery.Representante = query.TXTREPRESENTANTEL;
                dataQuery.Solicitante = query.TXTSOLICITANTE;
                dataQuery.TelefonoInspeccion = query.TXTTELEFONO;
                dataQuery.Ubicacion = query.TXTUBICACION;
                /*cambiar por los datos reales*/


              // FECLIMITE , FECPROGAINSPE , FECLIMITEI


                dataQuery.FechaLimite = query.FECLIMITE.HasValue ? query.FECLIMITE.Value.ToString("dd/MM/yyyy") : "";
                dataQuery.FechaLimiProgInspec = query.FECLIMITEI.HasValue ? query.FECLIMITEI.Value.ToString("dd/MM/yyyy") : "";
                dataQuery.FechaLimiteInspeccion = query.FECPROGAINSPE.HasValue ? query.FECPROGAINSPE.Value.ToString("dd/MM/yyyy") : "";


                dataQuery.TipoLlenado = query.CODTIPOLLENA;
                dataQuery.Asunto = query.TXTASUNTO;
            /*Obtenemos los datos de codgio catastral asginado*/

                listaCatastral.Add(new CodigoCatastralAsignado
                {
                    CODANOSOLI = data.CODANOSOLI,
                    CODTIPOSOLI = data.CODTIPOSOLI,
                    CODNUMESOLI = data.CODNUMESOLI,
                    CODUNI = data.CODUNI.ToString(),
                    CORRELUNIDAD = data.CORRELUNIDAD,
                    Distrito = data.CODDISTRITO,
                    Sec = data.CODSECTOR,
                    Manzana = data.CODMANZANA,
                    Lote = data.CODLOTE,
                    Ed = data.CODEDIFICACION,
                    Entr = data.CODENTRADA,
                    Piso = data.CODPISO,
                    Unidad = data.CODUNIDAD,
                    UbicacionPredio = data.TXTDIRECCION,
                    Titular = data.TXTTITULARES,
                    TipoTrabajo = data.FLG_TRABAJO,
                    EstadoUnidad = data.ESTADOUNIDAD,
                    Referencia = (data.CODREFANT != null) ? data.CODREFANT.Replace("|", "<br>") : "",
                    Indice = (i++)
                });
                //}
            }
            dataQuery.ListCatastral = listaCatastral;
            return dataQuery;
        }
        public List<RegistrarInspeccion> ListadoInsecciones(FiltrarProgramarInspeccionViewModel entInspeccion)
        {
            IEnumerable<BE.SIC_PROGINSPEC> lisQueryCabecera = new BL.SIC_PROGINSPEC().Listar(new BE.SIC_PROGINSPEC()
            {
                CODANOSOLI = entInspeccion.AniSolcitud,
                CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                CODNUMESOLI = entInspeccion.nroSolicitud
            });

            var lisDataQuery = new List<RegistrarInspeccion>();
            foreach (var item in lisQueryCabecera)
            {

                IEnumerable<BE.SIC_MOVINSPEC> lisQueryDetalle = new BL.SIC_MOVINSPEC().Listar(new BE.SIC_MOVINSPEC()
                {
                    CODANOSOLI = entInspeccion.AniSolcitud,
                    CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                    CODNUMESOLI = entInspeccion.nroSolicitud,
                    CODNROINSPEC = item.CODNROINSPEC
                });
                var inspectores = new List<SelectListItem>();
                string temInspectores = string.Empty;
                var responsable = new List<SelectListItem>();
                string temResponsable = string.Empty;
                foreach (var itemInspectores in lisQueryDetalle)
                {
                    inspectores.Add(new SelectListItem()
                    {
                        Value = itemInspectores.CODUSUASIS,
                        Text = itemInspectores.TXTNOMBRE,
                    });
                    //temInspectores += itemInspectores.TXTNOMBRE + " <br/><hr/>";
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
                //Listados de Unidades catastrales por inspeccion
                IEnumerable<BE.SIC_UNIDADINSPECCION> lisQueryUniInspec = new BL.SIC_UNIDADINSPECCION().Listar(new BE.SIC_UNIDADINSPECCION()
                {
                    CODANOSOLI = entInspeccion.AniSolcitud,
                    CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                    CODNUMESOLI = entInspeccion.nroSolicitud,
                    CODNROINSPEC = item.CODNROINSPEC
                });
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
                lisDataQuery.Add(new RegistrarInspeccion
                {
                    NroInspeccion = item.CODNROINSPEC,
                    NumInspeccion = item.NROINSPECCION,
                    FechaInspeccion = item.FECINSPE.HasValue ? item.FECINSPE.Value.ToString("dd/MM/yyyy") : "",
                    HoraInspeccion = item.TXTHORAINSP,
                    codInspectores = inspectores,
                    codResponsable = responsable,
                    Inspectores = temInspectores,
                    Responsable = temResponsable,
                    Observacion = item.TXTOBSERVACION,
                    EstadoInspeccion = item.TXTESTADOINSPEC,
                    ListunidadCatastral = lisCodCatas
                });

            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoInspectores(string fecha)
        {
            /* IEnumerable<BE.SIC_TABPROCE> lisQuery = new BL.SIC_TABPROCE().Listar(new BE.SIC_TABPROCE()
             {
                 CODCARCAT = "03",//VariablesWeb.CodigoPerfil,
                 CODTIPPROC = "05"
             });
             */
            IEnumerable<BE.SIC_MOVINSPEC> lisQuery = new BL.SIC_MOVINSPEC().Inspectores(new BE.SIC_MOVINSPEC()
            {
                CODCARCAT = "04",//VariablesWeb.CodigoPerfil,
                FECINSPE = fecha
            });
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODUSUASIS,
                    Text = item.TXTNOMBRE
                });
            }
            return lisDataQuery;
        }

        public Nullable<bool> ProcesarInspeccion(FiltrarProgramarInspeccionViewModel entInspeccion, List<RegistrarInspeccion> entInspector)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            entSIC_RETORNO.Ok = false;

            new BL.SIC_SOLICITUD().ActualizarInspecciones(new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = DateTime.Now.Year.ToString(),
                CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                CODNUMESOLI = entInspeccion.nroSolicitud,
                CODTIPODOC = entInspeccion.CodigoTipoDocumentoReg,
                TXTREPRESENTANTEL = entInspeccion.Representante,
                TXTSOLICITANTE = entInspeccion.Solicitante,
                TXTFECLIMITE = entInspeccion.FechaLimite,
                TXTFECLIMITEPROGINSP = entInspeccion.FechaLimiProgInspec,
                TXTFECLIMITEINSPECCION = entInspeccion.FechaLimiteInspeccion,
                TXTTELEFONO = entInspeccion.TelefonoInspeccion,
                TXTUBICACION = entInspeccion.Ubicacion,



            });

            foreach (var itemInspeccion in entInspector)
            {
                if (itemInspeccion.NroInspeccion.Length > 10)
                {
                    #region Grabar Maestro Inspecciones
                    BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
                    {
                        CODNROINSPEC = itemInspeccion.temCodInspeccion,
                        CODANOSOLI = entInspeccion.AniSolcitud,
                        CODNUMESOLI = entInspeccion.nroSolicitud,
                        CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                        CTIPODOCUMENTO = entInspeccion.CodigoTipoDocumentoReg,

                        CODESTATENCION = "010001",//PROGRAMADA 106 CODGRUPO
                        FECINSPE = Convert.ToDateTime(itemInspeccion.FechaInspeccion),
                        TXTHORAINSP = itemInspeccion.HoraInspeccion,
                        FECCITACION = Convert.ToDateTime(itemInspeccion.FechaCitacion),
                        FECAVIINSPEC = Convert.ToDateTime(itemInspeccion.FechaAvisoInspeccion),
                        TXTOBSERVACION = itemInspeccion.Observacion,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                        TXTFTXTFECLIMITE = itemInspeccion.FechaLimiteM,
                        TXTFECLIMITEPROGINSP = itemInspeccion.FechaLimiProgInspecM,
                        TXTFECLIMITEINSPECCION = itemInspeccion.FechaLimiteInspeccionM,
                        TXTUBICACION = itemInspeccion.Ubicacion,
                        TXTTELEFONO = itemInspeccion.TelefonoInspeccion,
                    };

                    entSIC_RETORNO = new BL.SIC_PROGINSPEC().Grabar(entQuery);
                    #endregion
                    foreach (var item in itemInspeccion.codInspectores)
                    {
                        #region Grabar Maestro Inspectores por Inspeccion
                        BE.SIC_MOVINSPEC entQueryInspec = new BE.SIC_MOVINSPEC()
                        {
                            CODANOSOLI = entInspeccion.AniSolcitud,
                            CODNUMESOLI = entInspeccion.nroSolicitud,
                            CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                            CTIPODOCUMENTO = entInspeccion.CodigoTipoDocumentoReg,

                            CODNROINSPEC = entSIC_RETORNO.CODIGO,
                            CODUSUASIS = item.Value,
                            CODCARCAT = "04",//VariablesWeb.CodigoPerfil,
                            FLAGRESPONSABLE = item.Value == itemInspeccion.codResponsable[0].Value ? "1" : null,
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                        };

                        BE.SIC_RETORNO entSIC_RETORNOInspector = new BL.SIC_MOVINSPEC().Grabar(entQueryInspec);
                        #endregion
                    }
                    foreach (var item in itemInspeccion.ListunidadCatastral)
                    {
                        #region Grabar Maestro Inspectores por Inspeccion
                        var UnidadInspeccion = new BE.SIC_UNIDADINSPECCION()
                        {
                            CODANOSOLI = entInspeccion.AniSolcitud,
                            CODNUMESOLI = entInspeccion.nroSolicitud,
                            CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                            CTIPODOCUMENTO = entInspeccion.CodigoTipoDocumentoReg,

                            CODNROINSPEC = entSIC_RETORNO.CODIGO,
                            CODDEPARTAMENTO = "15",
                            CODPROVINCIA = "01",
                            CODDISTRITO = item.Distrito,
                            CODSECTOR = item.Sec,
                            CODMANZANA = item.Manzana,
                            CODLOTE = item.Lote,
                            CODEDIFICACION = item.Ed,
                            CODENTRADA = item.Entr,
                            CODPISO = item.Piso,
                            CODUNIDAD = item.Unidad,
                            CODUNI = Convert.ToInt32(item.CODUNI),
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento
                        };

                        BE.SIC_RETORNO entSIC_RETORNOInspector = new BL.SIC_UNIDADINSPECCION().Grabar(UnidadInspeccion);
                        #endregion
                    }
                    //en caso exista una reprogramacion
                    if (!string.IsNullOrEmpty(itemInspeccion.temCodInspeccion))
                    {
                        ProcesoAtencion(new FiltrarProgramarInspeccionViewModel
                        {
                            AniSolcitud = entInspeccion.AniSolcitud,
                            nroSolicitud = entInspeccion.nroSolicitud,
                            codTipoSolicitud = entInspeccion.codTipoSolicitud,
                            CodigoTipoDocumentoReg= entInspeccion.CodigoTipoDocumentoReg,
                            NroInspeccion = itemInspeccion.temCodInspeccion,
                            EstadoAtencion = "010002"
                        });
                    }
                }
                else
                {
                    entSIC_RETORNO.Ok = true;
                }
            }

            return entSIC_RETORNO.Ok;

        }

        public Nullable<bool> ProcesoAtencion(FiltrarProgramarInspeccionViewModel entInspeccion)
        {
            BE.SIC_RETORNO entSIC_RETORNO;

            #region Asignar a la Entidad
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODANOSOLI = entInspeccion.AniSolcitud,
                CODNUMESOLI = entInspeccion.nroSolicitud,
                CODTIPOSOLI = entInspeccion.codTipoSolicitud,
                CTIPODOCUMENTO = entInspeccion.CodigoTipoDocumentoReg,

                CODNROINSPEC = entInspeccion.NroInspeccion,
                CODESTATENCION = entInspeccion.EstadoAtencion,//PROGRAMADA 106 CODGRUPO
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento
            };
            #endregion
            entSIC_RETORNO = new BL.SIC_PROGINSPEC().Actualizar(entQuery);

            return entSIC_RETORNO.Ok;
        }
    }
}