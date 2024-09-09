using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.ProcedimientoNuevo;
using Newtonsoft.Json;
using System.Configuration;
using MSI.Catastros.Helpers;

namespace MSI.Catastros.Web.Funcionalidad.Cotitularidad
{
    public class CotitularidadHandler
    {
        public List<SolicitudUnidadViewModel> BuscarUnidades(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarUnidadBuscar, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;


            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = (FiltrarUnidadBuscar.FiltrarCodigoSector != null ? FiltrarUnidadBuscar.FiltrarCodigoSector : ""),
                CODMANZANA = (FiltrarUnidadBuscar.FiltrarCodigoManzana != null ? FiltrarUnidadBuscar.FiltrarCodigoManzana : ""),
                CODLOTE = (FiltrarUnidadBuscar.FiltrarCodigoLote != null ? FiltrarUnidadBuscar.FiltrarCodigoLote : ""),
                CODEDIFICACION = (FiltrarUnidadBuscar.FiltrarEd != null ? FiltrarUnidadBuscar.FiltrarEd : ""),
                CODENTRADA = (FiltrarUnidadBuscar.FiltrarEntrada != null ? FiltrarUnidadBuscar.FiltrarEntrada : ""),
                CODPISO = (FiltrarUnidadBuscar.FiltrarPiso != null ? FiltrarUnidadBuscar.FiltrarPiso : ""),
                CODUNIDAD = (FiltrarUnidadBuscar.FiltrarUnidad != null ? FiltrarUnidadBuscar.FiltrarUnidad : ""),
                ESTATICO = FiltrarUnidadBuscar.Estatico
            };
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().RecuperarxCCU(entQuery);
            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();

            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new SolicitudUnidadViewModel
                {
                    CodigoCatastral = item.CODDISTRITO + "-" + item.CODSECTOR + "-" + item.CODMANZANA + "-" + item.CODLOTE + "-" + item.CODEDIFICACION + "-" + item.CODENTRADA + "-" + item.CODPISO + "-" + item.CODUNIDAD,
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entrada = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Ubicacion = item.UBICPRINCIPAL,
                    Unidad = item.CODUNIDAD,
                    TipoLlenado = item.CODTIPOLLENA,
                    UsoPredio = item.CODUSOESPE,
                    FechaActual = Fx.Fecha(item.FECMODIF),
                    Version = item.NVERSION.ToString(),
                    CUC = item.TXTCUC,
                    NumeroInterior = item.TXTNUMERO,
                    TipoInterior = item.CODTIPOINTE,
                    Inscripcion = item.TXTINSCCATA,
                    CodigoUni = item.CODUNI,
                    EstadoUnidad = item.ESTADOUNIDAD,
                    Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : ""
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
        public UnidadSolicitudViewModel BuscarUnidadSolicitud(FiltrarUnidadCatastralViewModel FiltrarLotesBuscar)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = Convert.ToInt32(FiltrarLotesBuscar.CodigoUnico),
                ESTATICO = FiltrarLotesBuscar.Estatico
            };

            BE.SIC_UNIDAD lisQuery = new BL.SIC_UNIDAD().RecuperarSolicitud(entQuery);
            var lisDataQuery = new UnidadSolicitudViewModel();
            lisDataQuery.CodigoNumeroSolicitud = lisQuery.TXTNOMDOCU;
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

        public ProcedimientoNuevoViewModel BuscarSolicitudes(FiltrarUnidadCatastralViewModel FiltrarLotesBuscar)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = FiltrarLotesBuscar.FiltrarCodigoTipoSolicitud;
            entQuery.CODNUMESOLI = FiltrarLotesBuscar.FiltrarNumeroSolicitud;
            entQuery.CODTIPODOC = FiltrarLotesBuscar.FiltrarCodigoTipoDocumento;
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);

            BE.SIC_SOLICITUD entQuerySolicitud = new BE.SIC_SOLICITUD();
            entQuerySolicitud.CODTIPOSOLI = FiltrarLotesBuscar.FiltrarCodigoTipoSolicitud;
            entQuerySolicitud.CODNUMESOLI = FiltrarLotesBuscar.FiltrarNumeroSolicitud;
            entQuerySolicitud.CODTIPODOC = FiltrarLotesBuscar.FiltrarCodigoTipoDocumento;
            entQuerySolicitud.CODANOSOLI = System.DateTime.Now.Year.ToString();
            BE.SIC_SOLICITUD querySolicitud = new BL.SIC_SOLICITUD().Recuperar(entQuerySolicitud);

            var dataQuery = new ProcedimientoNuevoViewModel();
            if (query == null)
            {
                query = new BE.SIC_SOLISEGUI();
            }
            if (querySolicitud == null)
            {
                querySolicitud = new BE.SIC_SOLICITUD();
            }
            #endregion
            #region Asignar al ViewModel
            dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
            dataQuery.NumeroSolicitud = query.CODNUMESOLI;
            dataQuery.Periodo = query.CODANOSOLI;
            dataQuery.Requerimiento = query.TXTNOMBREREQUERIMIENTO;
            dataQuery.TipoLlenado = querySolicitud.CODTIPOLLENA;
            #endregion
            return dataQuery;
        }

        public List<SelectListItem> ListadoEstadoConstruccion()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().EstadoDeConstruccion();
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

        public List<SelectListItem> ListarCodigoInscripcion()
        {
            BE.SIC_INSCRIPCION SIC_INSCRIPCION = new BE.SIC_INSCRIPCION();
            SIC_INSCRIPCION.TXTORDEN = "CODINSCCATA";
            IEnumerable<BE.SIC_INSCRIPCION> lisQuery = new BL.SIC_INSCRIPCION().Listar(SIC_INSCRIPCION);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODINSCCATA,
                    Text = item.CODINSCCATA
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarInscripcionCatastral()
        {
            BE.SIC_INSCRIPCION SIC_INSCRIPCION = new BE.SIC_INSCRIPCION();
            IEnumerable<BE.SIC_INSCRIPCION> lisQuery = new BL.SIC_INSCRIPCION().Listar(SIC_INSCRIPCION);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODINSCCATA,
                    Text = item.TXTINSCRIPCION
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarClasificacionPredio()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoClasificacionPredio();
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

        public List<SelectListItem> ListarTipoDepartamentoPredio()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDepartamentoPredio();
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


        public List<SelectListItem> ListarEstadoConservacion()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().EstadoDeConservacion();
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

        public List<SelectListItem> ListarEstadoDeInterior()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().EstadoDeInterior();
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

        public List<SelectListItem> ListadoFuenteInscripcionCatastral()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().FuentesInscripcionCatastral();
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

        public List<SelectListItem> ListadoMaterialEstructural()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().MaterialEstructural();
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




        public List<SelectListItem> ListadoUnidadMedida()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().UnidadMedida();
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

        public List<SelectListItem> EstadoInterior()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().EstadoInterior();
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

        public List<SelectListItem> EstadoInteriorAsignacion(string Asignacion, string Opcion)
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().EstadoInterior();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                if (Asignacion.Equals("010001"))
                {

                    if (Opcion == "1")
                    {
                        if (item.CODPARAMETRO.Equals("010001"))
                        {
                            lisDataQuery.Add(new SelectListItem
                            {
                                Value = item.CODPARAMETRO,
                                Text = item.TXTDESCRIPCION
                            });
                        }
                    }
                    else if (Opcion == "2")
                    {
                        if (item.CODPARAMETRO.Equals("010003") || item.CODPARAMETRO.Equals("010001") || item.CODPARAMETRO.Equals("010004"))
                        {
                            lisDataQuery.Add(new SelectListItem
                            {
                                Value = item.CODPARAMETRO,
                                Text = item.TXTDESCRIPCION
                            });
                        }
                    }



                }
                else
                {
                    if (item.CODPARAMETRO.Equals("010002"))
                    {
                        lisDataQuery.Add(new SelectListItem
                        {
                            Value = item.CODPARAMETRO,
                            Text = item.TXTDESCRIPCION
                        });
                    }
                }

            }
            return lisDataQuery;
        }

        public List<SelectListItem> TipoInterior()
        {
            IEnumerable<BE.SIC_TIPOINTERIOR> lisQuery = new BL.SIC_TIPOINTERIOR().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPOINTE,
                    Text = item.TXTDESCRIPCION
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoTipoSiNo()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoSiNo();
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

        public List<SelectListItem> ListadoTipoDocumentoIdentidad()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDocumentoIdentidad();
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
        public List<SelectListItem> ListadoTipoAnuncio()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoAnuncio();
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

        public List<SelectListItem> ListadoTipoDireccion()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDireccion();
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

        public List<SelectListItem> ListarUsoPredio()
        {
            IEnumerable<BE.SIC_USOESPE> lisQuery = new BL.SIC_USOESPE().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODUSOESPE,
                    Text = item.CODUSOESPE + " - " + item.TXTUSOESPE
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarCodigoUsoPredio()
        {
            IEnumerable<BE.SIC_USOESPE> lisQuery = new BL.SIC_USOESPE().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODUSOESPE,
                    Text = item.CODUSOESPE
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarOtrasInstalaciones(string anio)
        {

            BE.SAT_OTRAINSTALACION entQuery = new BE.SAT_OTRAINSTALACION()
            {
                CODANIOINSTALACION = anio
            };

            IEnumerable<BE.SAT_OTRAINSTALACION> lisQuery = new BL.SAT_OTRAINSTALACION().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODOTRAINSTALACION,
                    Text = item.TXTNOMBRE
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarCodigoOtrasInstalaciones()
        {
            IEnumerable<BE.SAT_OTRAINSTALACION> lisQuery = new BL.SAT_OTRAINSTALACION().ListarAnioActual();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODOTRAINSTALACION,
                    Text = item.CODOTRAINSTALACION
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoOtrasInstalaciones()
        {
            IEnumerable<BE.SAT_OTRAINSTALACION> lisQuery = new BL.SAT_OTRAINSTALACION().ListarAnioActual();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODOTRAINSTALACION + "_" + item.CODUNIDADMEDIDA,
                    Text = item.CODOTRAINSTALACION + "-" + item.TXTNOMBRE
                });
            }
            return lisDataQuery;
        }


        /*public List<SelectListItem> ListarCodigoOtrasInstalaciones()
        {
            DateTime fechaActual = DateTime.Today;
            int year = fechaActual.Year;

            BE.SAT_OTRAINSTALACION entQuery = new BE.SAT_OTRAINSTALACION()
            {
                CODANIOINSTALACION = year.ToString()
            };

            IEnumerable<BE.SAT_OTRAINSTALACION> lisQuery = new BL.SAT_OTRAINSTALACION().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODOTRAINSTALACION,
                    Text = item.CODOTRAINSTALACION
                });
            }
            return lisDataQuery;
        }*/

        public List<SelectListItem> ListadoMes()
        {
            //IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().MaterialEstructural();
            var lisDataQuery = new List<SelectListItem>();
            lisDataQuery.Add(new SelectListItem() { Value = "01", Text = "ENERO" });
            lisDataQuery.Add(new SelectListItem() { Value = "02", Text = "FEBRERO" });
            lisDataQuery.Add(new SelectListItem() { Value = "03", Text = "MARZO" });
            lisDataQuery.Add(new SelectListItem() { Value = "04", Text = "ABRIL" });
            lisDataQuery.Add(new SelectListItem() { Value = "05", Text = "MAYO" });
            lisDataQuery.Add(new SelectListItem() { Value = "06", Text = "JUNIO" });
            lisDataQuery.Add(new SelectListItem() { Value = "07", Text = "JULIO" });
            lisDataQuery.Add(new SelectListItem() { Value = "08", Text = "AGOSTO" });
            lisDataQuery.Add(new SelectListItem() { Value = "09", Text = "SEPTIEMBRE" });
            lisDataQuery.Add(new SelectListItem() { Value = "10", Text = "OCTUBRE" });
            lisDataQuery.Add(new SelectListItem() { Value = "11", Text = "NOVIEMBRE" });
            lisDataQuery.Add(new SelectListItem() { Value = "12", Text = "DICIEMBRE" });
            return lisDataQuery;
        }


        public List<SolicitudUnidadViewModel> RecargarTablaSolUnidad(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            BE.SIC_SOLICITUD entQuerySolicitud = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString()
            };
            BE.SIC_SOLICITUD querySolicitud = new BL.SIC_SOLICITUD().Recuperar(entQuerySolicitud);

            #region Obtener datos
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumento,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };

            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().Buscar2(entQuery);
            #endregion

            totalResultado = srcQuery.Count();

            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            var referencia = 0;
            foreach (var item in srcQuery)
            {
                if (item.CODREFANT != null)
                {
                    referencia++;
                }
            }
            foreach (var item in srcQuery)
            {
                if (FiltrarSolUnidad.FiltrarReferencia == "1")
                {
                    if (item.FLG_TRABAJO == "R")
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
                            Bloqueado = querySolicitud.CODESTADOFINAL,
                            CodigoCorrelativo = item.CORRELUNIDAD,
                            CodigoPeriodo = item.CODANOSOLI,
                            CodigoTipoSolicitud = item.CODTIPOSOLI,
                            CodigoNumeroSolicitud = item.CODNUMESOLI,
                            EstadoUnidad = item.ESTADOUNIDAD,
                            Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : "",
                            FlagUsuario = item.FLG_USUARIO,

                            Titular = "",
                            Ubicacion = ""
                            //TipoLlenado = item.CODTIPOLLENA
                        });
                    }

                }
                else
                {
                    if (item.FLG_TRABAJO == "T")
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
                            Bloqueado = querySolicitud.CODESTADOFINAL,
                            CodigoCorrelativo = item.CORRELUNIDAD,
                            CodigoPeriodo = item.CODANOSOLI,
                            CodigoTipoSolicitud = item.CODTIPOSOLI,
                            CodigoNumeroSolicitud = item.CODNUMESOLI,
                            EstadoUnidad = item.ESTADOUNIDAD,
                            Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : "",
                            flagTrabajo = item.FLG_TRABAJO,
                            Titular = "",
                            Ubicacion = "",
                            FlagUsuario = item.FLG_USUARIO
                            //TipoLlenado = item.CODTIPOLLENA
                        });
                    }
                }


            }
            return lisDataQuery;
        }


        public BE.SIC_RETORNO ProcesarUnidadCatastral(CotitularidadViewModel UnidadCatastral)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = UnidadCatastral.CodigoUnidadCatastral,
                CODDISTRITO = UnidadCatastral.CodigoDistrito,
                CODSECTOR = UnidadCatastral.CodigoSector,
                CODMANZANA = UnidadCatastral.CodigoManzana,
                CODLOTE = UnidadCatastral.CodigoLote,
                CODEDIFICACION = UnidadCatastral.CodigoEdificacion,
                CODENTRADA = UnidadCatastral.CodigoEntrada,
                CODPISO = UnidadCatastral.CodigoPiso,
                CODUNIDAD = UnidadCatastral.CodigoUnidad,
                TXTCUC = UnidadCatastral.Cuc,
                CODINSCCATA = UnidadCatastral.CodigoInscripcionCatastral,
                CODFUENINSCCATA = UnidadCatastral.CodigoFuenteInscripcionCatastral,
                TXTDENOMINACION = UnidadCatastral.Denominacion,
                CODESTACONST = UnidadCatastral.CodigoEstadoConstruccion,
                CODCLASIFICA = UnidadCatastral.CodigoClasificacionPredio,
                CODTIPODPTO = UnidadCatastral.CodigoDepartamentoPredio,
                CODCARREG = UnidadCatastral.CodigoCargaRegistral,
                TXTCODIPREDRENT = UnidadCatastral.CodigoPredial,
                CODUSOESPE = UnidadCatastral.CodgiUsoPredio,



                NUMAREATERRVERI = UnidadCatastral.AreaTerrenoVerificada,
                NUMAREATERRCOMU = UnidadCatastral.AreaTerrenoComun,
                NUMAREATERRTOTA = UnidadCatastral.AreaTerrenoTotal,
                NUMAREACONSDECLTOTA = UnidadCatastral.AreaConstruidaTotalDeclarada,
                NUMAREAOCUP = UnidadCatastral.AreaOcupada,
                NUMPORCBIENCOMUOFIC = UnidadCatastral.AreaComunesOficial,
                NUMPORESTACONT = UnidadCatastral.AvanceConstruccion,

                NUMAREATERRDECLA = UnidadCatastral.AreaTerrenoDeclarada,
                NUMAREATERRSUBVAL = UnidadCatastral.AreaTerrenoSubValuada,
                NUMAREATERRSOBVAL = UnidadCatastral.AreaTerrenoSobreValuada,
                NUMAREACONSSUBVAL = UnidadCatastral.AreaConstruidaSubValuada,
                NUMAREACONSSOBVAL = UnidadCatastral.AreaConstruidaSobreValuada,
                //CODTIPOLLENA = UnidadCatastral.TipoLlenado,
                CODTIPOLLENA = UnidadCatastral.CodigoTipoLlenado,
                FLGINDEP = UnidadCatastral.FlgIndependiente,

                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                ESTATICO = UnidadCatastral.Estatico
            };
            #endregion

            if (UnidadCatastral.FechaUltimaInspeccion != null) entQuery.FECINSPEC = DateTime.Parse(UnidadCatastral.FechaUltimaInspeccion);
            if (UnidadCatastral.FechaActualizacion != null) entQuery.FECACT = DateTime.Parse(UnidadCatastral.FechaActualizacion);

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadCatastral.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDAD().Grabar(entQuery); break;
                case 2:
                    entSIC_RETORNO = new BL.SIC_UNIDAD().Actualizar(entQuery);
                    if (UnidadCatastral.Estatico != true) { entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarUnical(entQuery); }
                    break;
                default: entSIC_RETORNO = new BL.SIC_UNIDAD().Eliminar(entQuery); break;
            }
            #endregion
            //entSIC_RETORNO.CODIGO = srcTempQueryTerminado.NUMCALVER.ToString().PadLeft(3, '0') + "-" + srcTempQueryTerminado.CODANOSOLI.ToString();
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ProcesarNumeracionPredio(NumeracionPredioViewModel NumeracionPredio)
        {

            String[] substrings = NumeracionPredio.CodigoVia.Split('-');

            #region Asignar a la Entidad
            BE.SIC_UNIDADDIRECCONINTERIOR entQuery = new BE.SIC_UNIDADDIRECCONINTERIOR()
            {

                CODUNI = NumeracionPredio.CodigoUni,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = NumeracionPredio.CodigoDistrito,
                CODSECTOR = NumeracionPredio.CodigoSector,
                CODMANZANA = NumeracionPredio.CodigoManzana,
                CODLOTE = NumeracionPredio.CodigoLote,
                CODVIA = substrings[0],
                CODCORRMANZVIA = substrings[1],
                CODCORRUNIDDIREMUNI = substrings[2],
                CODESTAINTE = NumeracionPredio.EstadoInterior,
                CODTIPOINTE = NumeracionPredio.TipoInterior,
                CODINSCATINT = NumeracionPredio.TipoInscripcion,
                TXTNUMERO = NumeracionPredio.NumeroInterior,
                TXTLETRA = NumeracionPredio.LetraInterior,
                CODTIPOASIG = NumeracionPredio.Asignacion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORRUNIDDIREINTE = NumeracionPredio.CodigoCorrDirecUnidad,
                NUMAREATEMPI = NumeracionPredio.Area,
                FLAGINDIREC = NumeracionPredio.Opcion,
                ESTATICO = NumeracionPredio.Estatico.ToString().ToLower()
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (NumeracionPredio.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADDIRECCONINTERIOR().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADDIRECCONINTERIOR().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADDIRECCONINTERIOR().Eliminar(entQuery); break;
            }
            #endregion
            //entSIC_RETORNO.CODIGO = srcTempQueryTerminado.NUMCALVER.ToString().PadLeft(3, '0') + "-" + srcTempQueryTerminado.CODANOSOLI.ToString();
            return entSIC_RETORNO;
        }

        public Nullable<bool> GrabarUnidadImagen(CotitularidadViewModel UnidasCatastral)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = UnidasCatastral.CodigoUnidadCatastral,
            };
            BE.SIC_UNIDAD srcQuery = new BL.SIC_UNIDAD().Recuperar(entQuery);

            #region Subir archivo
            var archivo = UnidasCatastral.archivo;
            string repo = "REPOSIC"; string anio = DateTime.Now.Year.ToString(); string mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string carpeta = "\\" + repo + "\\" + anio + "\\" + mes;
            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + carpeta);
            bool subida;

            if (archivo != null)
            {
                string _NombreArchivo = Path.GetFileName(archivo.FileName);
                string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                string _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                _Ext = _Ext.Substring(1);
                string _FN = string.Format("{0}{1}.{2}", _Nombre, _Date, _Ext);

                string _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_ARCHIVOS"] + carpeta, _FN);
                srcQuery.TXTNOMDOCU = _NombreArchivo;
                srcQuery.TXTNOMDOCUINT = _Ruta;
                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDAD().Actualizar(srcQuery);
                archivo.SaveAs(_Ruta);
            }
            subida = true;

            #endregion
            return subida;

        }
        public CotitularidadViewModel RecuperarUnidad(int? Coduni)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = Coduni,
            };
            BE.SIC_UNIDAD query = new BL.SIC_UNIDAD().Recuperar(entQuery);
            CotitularidadViewModel dataQuery;
            if (query != null)
            {

                dataQuery = new CotitularidadViewModel()
                {
                    Cuc = query.TXTCUC,
                    CodigoUnico = query.CODUNI.ToString(),
                    CodigoInscripcionCatastral = query.CODINSCCATA,
                    CodigoCodInscripcionCatastral = query.CODINSCCATA,
                    CodigoFuenteInscripcionCatastral = query.CODFUENINSCCATA,
                    Denominacion = query.TXTDENOMINACION,
                    CodigoEstadoConstruccion = query.CODESTACONST,
                    CodigoClasificacionPredio = query.CODCLASIFICA,
                    CodigoDepartamentoPredio = query.CODTIPODPTO,
                    CodigoCargaRegistral = query.CODCARREG,
                    CodigoPredial = query.TXTCODIPREDRENT,
                    CodgiUsoPredio = query.CODUSOESPE,
                    AreaTerrenoVerificada = query.NUMAREATERRVERI,
                    AreaTerrenoComun = query.NUMAREATERRCOMU,
                    AreaTerrenoTotal = query.NUMAREATERRTOTA,
                    AreaConstruidaTotalDeclarada = query.NUMAREACONSDECLTOTA,
                    AreaOcupada = query.NUMAREAOCUP,
                    AreaComunesOficial = query.NUMPORCBIENCOMUOFIC,
                    AvanceConstruccion = query.NUMPORESTACONT,
                    AreaTerrenoDeclarada = query.NUMAREATERRDECLA,
                    AreaComunesCalculado = query.NUMPORCBIENCOMUCAL,
                    codigollenado = query.CODTIPOLLENA,
                    FlgIndependiente = query.FLGINDEP,
                    FechaUltimaInspeccion = (query.FECINSPEC != null) ? query.FECINSPEC.Value.ToString("dd/MM/yyyy") : "",
                    FechaActualizacion = (query.FECACT != null) ? query.FECACT.Value.ToString("dd/MM/yyyy") : ""
                };
            }
            else
            {
                dataQuery = new CotitularidadViewModel();
            }
            return dataQuery;

        }
        //UNID
        public string RecuperarLoteImagen(CotitularidadViewModel UnidadCatras)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = UnidadCatras.CodigoUnidadCatastral,
                ESTATICO = UnidadCatras.Estatico
            };

            BE.SIC_UNIDAD srcQuery = new BL.SIC_UNIDAD().Recuperar(entQuery);

            byte[] archivo = null;
            if (srcQuery != null)
            {
                if (srcQuery.NROEDIFICACIONES > 1)
                {
                    srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                    srcQuery.CODEDIFICACIONCATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE + srcQuery.CODEDIFICACION;

                    BE.SIC_UNIDAD srcQueryFotoEdi = new BL.SIC_UNIDAD().RecuperarFotoEdificacion(srcQuery);
                    if (srcQueryFotoEdi != null)
                    {
                        var path = srcQueryFotoEdi.TXTRUTAFOTO == null ? "" : srcQueryFotoEdi.TXTRUTAFOTO;
                        return @ConfigurationManager.AppSettings["RUTA_FOTOS"] + path.Substring(2, path.Length - 2);
                    }

                    if (srcQueryFotoEdi == null)
                    {
                        srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;


                        BE.SIC_UNIDAD srcQueryFoto = new BL.SIC_UNIDAD().RecuperarFoto(srcQuery);
                        if (srcQueryFoto != null)
                        {
                            var path = @srcQueryFoto.TXTRUTAFOTO == null ? "" : @srcQueryFoto.TXTRUTAFOTO;
                            return @ConfigurationManager.AppSettings["RUTA_FOTOS"] + path.Substring(2, path.Length - 2);


                        }
                    }

                }
                else
                {
                    srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                    srcQuery.CODEDIFICACIONCATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE + srcQuery.CODEDIFICACION;


                    BE.SIC_UNIDAD srcQueryFoto = new BL.SIC_UNIDAD().RecuperarFoto(srcQuery);
                    if (srcQueryFoto != null)
                    {
                        var path = @srcQueryFoto.TXTRUTAFOTO == null ? "" : @srcQueryFoto.TXTRUTAFOTO;
                        return @ConfigurationManager.AppSettings["RUTA_FOTOS"] + path.Substring(2, path.Length - 2);


                    }
                }


            }

            return "";
        }

        public Nullable<bool> EliminarMunicipalDirec(NumeracionPredioViewModel Direc)
        {
            BE.SIC_UNIDADDIRECCONINTERIOR entQuery = new BE.SIC_UNIDADDIRECCONINTERIOR()
            {
                CODUNI = Direc.CodigoUni,
                CODCORRUNIDDIREINTE = Direc.CodigoCorrDirecUnidad,
                ESTATICO = Direc.Estatico.ToString().ToLower()
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDADDIRECCONINTERIOR().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> EliminarTitular(UnidadTitularViewModel Direc)
        {
            BE.SIC_UNIDADTITULAR entQuery = new BE.SIC_UNIDADTITULAR()
            {
                CODUNI = Direc.CodigoUni,
                CODCONTRIBUYENTE = Direc.CodigoContribuyente,
                ESTATICO = Direc.Estatico
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDADTITULAR().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> EliminarDocRRPP(UnidadDocumentosRRPPViewModel Documento)
        {
            BE.SIC_UNIDADRRPP entQuery = new BE.SIC_UNIDADRRPP()
            {
                CODUNI = Documento.CodigoUni,
                CODCORRUNIDRRPP = Documento.CodigoCorrelativo,
                CODCORRLOTERRPP = Documento.CodigoCorrelativoLote,
                CODDEPARTAMENTO = Documento.CodigoDepartamento,
                CODPROVINCIA = Documento.CodigoProvincia,
                CODDISTRITO = Documento.CodigoDistrito,
                CODSECTOR = Documento.CodigoSector,
                CODMANZANA = Documento.CodigoManzana,
                CODLOTE = Documento.CodigoLote,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                ESTATICO = Documento.Estatico
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDADRRPP().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }

        public List<QuintaLinderosViewModel> BuscarLoteLinderos(QuintaLinderosViewModel FiltrarSolUnidad)
        {
            BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO();
            entQuery.CODUNI = FiltrarSolUnidad.codUniCat;
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;

            ICollection<BE.SIC_QUINTALINDERO> lisQuery = new BL.SIC_QUINTALINDERO().Buscar(entQuery);
            var lisDataQuery = new List<QuintaLinderosViewModel>();
            int indice = 1;
            int contF = 0, contI = 0, contD = 0, contA = 0;
            foreach (var item in lisQuery)
            {

                #region BuscarLoteColindantes

                var ListaColindanteLotes = new List<SelectListItem>();
                string temColindanteLotes = string.Empty;



                BE.SIC_QUINTALINDERO entQueryLinderoLote = new BE.SIC_QUINTALINDERO()
                {
                    CODUNI = FiltrarSolUnidad.codUniCat,
                    CODLADO = item.CODLADO,
                    CORRELLINDE = item.CORRELLINDE,
                    ESTATICO = FiltrarSolUnidad.Estatico
                };

                ICollection<BE.SIC_QUINTALINDERO> lisQueryColVia = new BL.SIC_QUINTALINDERO().BuscarLinderosUnidad(entQueryLinderoLote);

                foreach (var itemLinderoDetalle in lisQueryColVia)
                {
                    ListaColindanteLotes.Add(new SelectListItem()
                    {
                        Value = itemLinderoDetalle.TXTCOLINDANTE,
                        Text = itemLinderoDetalle.TXTCOLINDANTE,
                    });
                }

                string correlativoLado = "";

                switch (item.CODLADO)
                {
                    case "03": contF++; correlativoLado = contF.ToString().PadLeft(4, '0'); break;
                    case "04": contI++; correlativoLado = contI.ToString().PadLeft(4, '0'); break;
                    case "05": contA++; correlativoLado = contA.ToString().PadLeft(4, '0'); break;
                    case "06": contD++; correlativoLado = contD.ToString().PadLeft(4, '0'); break;
                };
                #endregion
                lisDataQuery.Add(new QuintaLinderosViewModel
                {

                    NombreLado = item.TXTPARIDAD,
                    NumeroLado = correlativoLado,
                    MedidaLadoCam = item.NUMMEDICAMP,
                    MedidaLadoOfi = item.NUMMEDIOFIC,
                    CodigoLado = item.CODLADO,
                    Codigo = item.CORRELLINDE,
                    CodigoColindante = "",
                    ListaUnidadesColindantes = ListaColindanteLotes,
                    ListaColindantes = ListaColindanteLotes,

                });

                indice++;

            }
            return lisDataQuery;
        }

        public BE.SIC_RETORNO ProcesarLineasConstructivas(LineasContructivasViewModel LineasConstruc)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADCONSTRUCCION entQuery = new BE.SIC_UNIDADCONSTRUCCION()
            {

                CODUNI = LineasConstruc.CodigoUnidadCatastral,
                TXTPISO = LineasConstruc.txtPiso,
                TXTMES = LineasConstruc.Mes,
                TXTANO = LineasConstruc.Ano,
                CODMATEESTR = LineasConstruc.Material,
                CODESTACONSE = LineasConstruc.EstadoConst,
                CODCATEMURO = LineasConstruc.Muro,
                CODCATETECH = LineasConstruc.Techo,
                CODCATEPISO = LineasConstruc.Piso,
                CODCATEPUERVENT = LineasConstruc.Puerta,
                CODCATEREVE = LineasConstruc.Revest,
                CODCATEBANO = LineasConstruc.Bano,
                CODCATEINSTELEC = LineasConstruc.Electricas,
                NUMAREADECL = LineasConstruc.Declarada,
                NUMAREAVERI = LineasConstruc.Verificada,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORRUNIDCONS = LineasConstruc.CodigoCorrelativo,
                ESTATICO = LineasConstruc.Estatico

            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (LineasConstruc.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADCONSTRUCCION().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADCONSTRUCCION().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADCONSTRUCCION().Eliminar(entQuery); break;
            }
            #endregion
            //entSIC_RETORNO.CODIGO = srcTempQueryTerminado.NUMCALVER.ToString().PadLeft(3, '0') + "-" + srcTempQueryTerminado.CODANOSOLI.ToString();
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ProcesarOtrasInstalaciones(OtrasInstalacionesViewModel OtrasInstalaciones)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDINSTALACION entQuery = new BE.SIC_UNIDINSTALACION()
            {

                CODUNI = OtrasInstalaciones.CodigoUnidadCatastral,
                CODINSTALACION = OtrasInstalaciones.CodigoTipoInstalacion,
                TXTMES = OtrasInstalaciones.Mes,
                TXTANO = OtrasInstalaciones.Ano,
                CODESTACONSE = OtrasInstalaciones.EstadoConserva,
                CODUNIDAD = OtrasInstalaciones.CodigoUnidad,
                NUMCAPACIDAD = OtrasInstalaciones.Capacidad,
                NUMCANTIDAD = OtrasInstalaciones.Cantidad,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORRUNIDINST = OtrasInstalaciones.CodigoCorrelativo,
                ESTATICO = OtrasInstalaciones.Estatico

            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (OtrasInstalaciones.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDINSTALACION().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDINSTALACION().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDINSTALACION().Eliminar(entQuery); break;
            }
            #endregion
            //entSIC_RETORNO.CODIGO = srcTempQueryTerminado.NUMCALVER.ToString().PadLeft(3, '0') + "-" + srcTempQueryTerminado.CODANOSOLI.ToString();
            return entSIC_RETORNO;
        }



        public BE.SIC_RETORNO ProcesarActividadEconomica(ActividadEconomicaViewModel ActividadEconomica)
        {
            #region Asignar a la Entidad
            BE.SIC_UNIDADACTIVIDAD entQuery = new BE.SIC_UNIDADACTIVIDAD()
            {

                CODUNI = ActividadEconomica.CodigoUnidadCatastral,
                CODUSOESPE = ActividadEconomica.CodigoUso,
                NUMMETROS = ActividadEconomica.Metro,
                CODUSORETIRO = ActividadEconomica.Retiro,
                CODOPCIONANUN = ActividadEconomica.Anuncio,
                CODANUNCIO = ActividadEconomica.TipoAnuncio,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORRELACTI = ActividadEconomica.CodigoCorrelativo,
                ESTATICO = ActividadEconomica.Estatico

            };

            if (ActividadEconomica.Fecha != null) entQuery.FECACTI = DateTime.Parse(ActividadEconomica.Fecha);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ActividadEconomica.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADACTIVIDAD().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADACTIVIDAD().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADACTIVIDAD().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO;
        }


        public BE.SIC_RETORNO ProcesarObservaciones(ObservacionViewModel Observacion)
        {
            #region Asignar a la Entidad
            BE.SIC_UNIDADOBSERVACION entQuery = new BE.SIC_UNIDADOBSERVACION()
            {

                CODUNI = Observacion.CodigoUnidadCatastral,
                TXTOBSERVACION = Observacion.Observacion,
                TIPOBSERVA = Observacion.TipoObservacion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORROBSE = Observacion.CodigoCorrelativo,
                ESTATICO = Observacion.Estatico
            };
            if (Observacion.Fecha != null) entQuery.FECOBSERVACION = DateTime.Parse(Observacion.Fecha);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (Observacion.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADOBSERVACION().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADOBSERVACION().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADOBSERVACION().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO;
        }


        public CotitularidadViewModel RecuperarUnidadCatastral(int CodigoUniCat, out bool resul)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
            entQuery.CODUNI = CodigoUniCat;

            BE.SIC_UNIDAD query = new BL.SIC_UNIDAD().RecuperarTemporal(entQuery);

            CotitularidadViewModel dataQuery;

            if (query == null)
            {
                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDAD().Grabar(entQuery);
                query = new BL.SIC_UNIDAD().RecuperarTemporal(entQuery);
                dataQuery = new CotitularidadViewModel();
                resul = false;
            }
            else
            {
                dataQuery = new CotitularidadViewModel()
                {
                    Cuc = query.TXTCUC,
                    CodigoUnico = query.CODUNI.ToString(),
                    CodigoInscripcionCatastral = query.CODINSCCATA,
                    CodigoCodInscripcionCatastral = query.CODINSCCATA,
                    CodigoFuenteInscripcionCatastral = query.CODFUENINSCCATA,
                    Denominacion = query.TXTDENOMINACION,
                    CodigoEstadoConstruccion = query.CODESTACONST,
                    CodigoClasificacionPredio = query.CODCLASIFICA,
                    CodigoDepartamentoPredio = query.CODTIPODPTO,
                    CodigoCargaRegistral = query.CODCARREG,
                    CodigoPredial = query.TXTCODIPREDRENT,
                    CodgiUsoPredio = query.CODUSOESPE,
                    AreaTerrenoVerificada = query.NUMAREATERRVERI,
                    AreaTerrenoComun = query.NUMAREATERRCOMU,
                    AreaTerrenoTotal = query.NUMAREATERRTOTA,
                    AreaConstruidaTotalDeclarada = query.NUMAREACONSDECLTOTA,
                    AreaOcupada = query.NUMAREAOCUP,
                    AreaComunesOficial = query.NUMPORCBIENCOMUOFIC,
                    AvanceConstruccion = query.NUMPORESTACONT,
                    AreaTerrenoDeclarada = query.NUMAREATERRDECLA,
                    AreaComunesCalculado = query.NUMPORCBIENCOMUCAL,
                    codigollenado = query.CODTIPOLLENA,
                    FlgIndependiente = query.FLGINDEP,
                    FechaUltimaInspeccion = (query.FECINSPEC != null) ? query.FECINSPEC.Value.ToString("dd/MM/yyyy") : "",
                    FechaActualizacion = (query.FECACT != null) ? query.FECACT.Value.ToString("dd/MM/yyyy") : ""

                };
                resul = true;
            }

            return dataQuery;
        }

        public CotitularidadViewModel RecuperarUnidadCatastralEST(int CodigoUniCat, bool Estatico, out bool resul)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.ESTATICO = Estatico;
            BE.SIC_UNIDAD query = new BL.SIC_UNIDAD().Recuperar(entQuery);

            CotitularidadViewModel dataQuery;

            dataQuery = new CotitularidadViewModel()
            {
                Cuc = query.TXTCUC,
                CodigoUnico = query.CODUNI.ToString(),
                CodigoInscripcionCatastral = query.CODINSCCATA,
                CodigoCodInscripcionCatastral = query.CODINSCCATA,
                CodigoFuenteInscripcionCatastral = query.CODFUENINSCCATA,
                Denominacion = query.TXTDENOMINACION,
                CodigoEstadoConstruccion = query.CODESTACONST,
                CodigoClasificacionPredio = query.CODCLASIFICA,
                CodigoDepartamentoPredio = query.CODTIPODPTO,
                CodigoCargaRegistral = query.CODCARREG,
                CodigoPredial = query.TXTCODIPREDRENT,
                CodgiUsoPredio = query.CODUSOESPE,
                AreaTerrenoVerificada = query.NUMAREATERRVERI,
                AreaTerrenoComun = query.NUMAREATERRCOMU,
                AreaTerrenoTotal = query.NUMAREATERRTOTA,
                AreaConstruidaTotalDeclarada = query.NUMAREACONSDECLTOTA,
                AreaOcupada = query.NUMAREAOCUP,
                AreaComunesOficial = query.NUMPORCBIENCOMUOFIC,
                AvanceConstruccion = query.NUMPORESTACONT,
                AreaTerrenoDeclarada = query.NUMAREATERRDECLA,
                AreaComunesCalculado = query.NUMPORCBIENCOMUCAL,
                codigollenado = query.CODTIPOLLENA,
                FlgIndependiente = query.FLGINDEP,
                FechaUltimaInspeccion = (query.FECINSPEC != null) ? query.FECINSPEC.Value.ToString("dd/MM/yyyy") : "",
                FechaActualizacion = (query.FECACT != null) ? query.FECACT.Value.ToString("dd/MM/yyyy") : ""

            };
            resul = true;

            return dataQuery;
        }

        public string ObtenerDescripcionInstalacion(string Codigo)
        {
            BE.SIC_UNIDINSTALACION entQuery = new BE.SIC_UNIDINSTALACION();
            entQuery.CODINSTALACION = Codigo;

            string Descripcion = new BL.SIC_UNIDINSTALACION().ObtenerDescripcionUnidad(entQuery);
            return Descripcion;
        }

        public List<BE.SIC_RETORNO> GrabarUnidadNuevo(List<SolicitudUnidadViewModel> UnidadCatastral, int contProceso = 0)
        {
            //string tempDistrito = "", tempSector = "", tempManzana = "", tempLote = "";
            //string tempTipoDoc = "", tempCodigoSoli = "", tempTipoSoli = "", tempCodigoAno = "";
            //string tempReferencia = "", tempTipoLote = ""; int tempNumero = 0;

            BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BE.SIC_RETORNO();
            List<BE.SIC_RETORNO> ListSIC_RETORNO = new List<BE.SIC_RETORNO>();
            foreach (SolicitudUnidadViewModel ItemUnidad in UnidadCatastral)
            {
                BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = ItemUnidad.CodigoDistrito,
                    CODSECTOR = ItemUnidad.CodigoSector,
                    CODMANZANA = ItemUnidad.CodigoManzana,
                    CODLOTE = ItemUnidad.CodigoLote,
                    CODEDIFICACION = ItemUnidad.Ed,
                    CODENTRADA = ItemUnidad.Entrada,
                    CODPISO = ItemUnidad.Piso,
                    CODUNIDAD = ItemUnidad.Unidad,
                    CODNUMESOLI = ItemUnidad.CodigoNumeroSolicitud,
                    CODTIPOSOLI = ItemUnidad.CodigoTipoSolicitud,
                    CODANOSOLI = DateTime.Now.Year.ToString(),
                    CTIPODOCUMENTO = ItemUnidad.CodigoTipoDocumento,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };

                entSIC_RETORNO_NUEVO = new BL.SIC_UNIDAD().GrabarTempSolUnidad(entQuery);


                switch (entSIC_RETORNO_NUEVO.NoMENSAJE)
                {
                    case 0:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                           entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  Grabo Correctamente";
                        entSIC_RETORNO_NUEVO.Ok = true; break;
                    case -20001:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                     entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no existe";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    case -20002:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                     entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no se encuentra habilitado";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    case -20003:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                 entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  La unidad ya se encuentra registrada.";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    default:
                        entSIC_RETORNO_NUEVO.MENSAJE = "Se detecto un problema en el registro"; entSIC_RETORNO_NUEVO.Ok = false; break;
                }
                ListSIC_RETORNO.Add(entSIC_RETORNO_NUEVO);

            }
            return ListSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarUnidadNuevo(SolicitudUnidadViewModel UnidadCatastral, int contProceso = 0)
        {
            //string tempDistrito = "", tempSector = "", tempManzana = "", tempLote = "";
            //string tempTipoDoc = "", tempCodigoSoli = "", tempTipoSoli = "", tempCodigoAno = "";
            //string tempReferencia = "", tempTipoLote = ""; int tempNumero = 0;

            BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BE.SIC_RETORNO();
            List<BE.SIC_RETORNO> ListSIC_RETORNO = new List<BE.SIC_RETORNO>();

            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = UnidadCatastral.CodigoDistrito,
                CODSECTOR = UnidadCatastral.CodigoSector,
                CODMANZANA = UnidadCatastral.CodigoManzana,
                CODLOTE = UnidadCatastral.CodigoLote,
                CODEDIFICACION = UnidadCatastral.Ed,
                CODENTRADA = UnidadCatastral.Entrada,
                CODPISO = UnidadCatastral.Piso,
                CODUNIDAD = UnidadCatastral.Unidad,
                CODNUMESOLI = UnidadCatastral.CodigoNumeroSolicitud,
                CODTIPOSOLI = UnidadCatastral.CodigoTipoSolicitud,
                CODANOSOLI = DateTime.Now.Year.ToString(),
                CTIPODOCUMENTO = UnidadCatastral.CodigoTipoDocumento,
            };

            entSIC_RETORNO_NUEVO = new BL.SIC_UNIDAD().ValidarTempSolUnidad(entQuery);

            switch (entSIC_RETORNO_NUEVO.NoMENSAJE)
            {
                case 0:
                    entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                       entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  Grabo Correctamente";
                    entSIC_RETORNO_NUEVO.Ok = true; break;
                case -20001:
                    entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                 entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no existe";
                    entSIC_RETORNO_NUEVO.Ok = false; break;
                case -20002:
                    entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                 entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no se encuentra habilitado";
                    entSIC_RETORNO_NUEVO.Ok = false; break;
                case -20003:
                    entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
             entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  La unidad ya se encuentra registrada.";
                    entSIC_RETORNO_NUEVO.Ok = false; break;


            }


            return entSIC_RETORNO_NUEVO;
        }

        public List<BE.SIC_RETORNO> GrabarUnidadAcum(List<SolicitudUnidadViewModel> UnidadCatastral, int contProceso = 0)
        {
            //string tempDistrito = "", tempSector = "", tempManzana = "", tempLote = "";
            //string tempTipoDoc = "", tempCodigoSoli = "", tempTipoSoli = "", tempCodigoAno = "";
            //string tempReferencia = "", tempTipoLote = ""; int tempNumero = 0;

            BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BE.SIC_RETORNO();
            List<BE.SIC_RETORNO> ListSIC_RETORNO = new List<BE.SIC_RETORNO>();
            foreach (SolicitudUnidadViewModel ItemUnidad in UnidadCatastral)
            {
                BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = ItemUnidad.CodigoDistrito,
                    CODSECTOR = ItemUnidad.CodigoSector,
                    CODMANZANA = ItemUnidad.CodigoManzana,
                    CODLOTE = ItemUnidad.CodigoLote,
                    CODEDIFICACION = ItemUnidad.Ed,
                    CODENTRADA = ItemUnidad.Entrada,
                    CODPISO = ItemUnidad.Piso,
                    CODUNIDAD = ItemUnidad.Unidad,
                    CODNUMESOLI = ItemUnidad.CodigoNumeroSolicitud,
                    CODTIPOSOLI = ItemUnidad.CodigoTipoSolicitud,
                    CODANOSOLI = DateTime.Now.Year.ToString(),
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    CTIPODOCUMENTO = (ItemUnidad.CodigoTipoSolicitud == "010003") ? "REQI" : ItemUnidad.CodigoTipoDocumento
                };

                entSIC_RETORNO_NUEVO = new BL.SIC_UNIDAD().GrabarTempSolUnidadAcum(entQuery);

                switch (entSIC_RETORNO_NUEVO.NoMENSAJE)
                {
                    case 0:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                           entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  Grabo Correctamente";
                        entSIC_RETORNO_NUEVO.Ok = true; break;
                    case -20001:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                     entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no existe";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    case -20002:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                     entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  El lote no se encuentra habilitado";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    case -20003:
                        entSIC_RETORNO_NUEVO.MENSAJE = entQuery.CODDISTRITO + "-" + entQuery.CODSECTOR + "-" + entQuery.CODMANZANA + "-" +
                 entQuery.CODLOTE + "-" + entQuery.CODEDIFICACION + "-" + entQuery.CODENTRADA + "-" + entQuery.CODPISO + "-" + entQuery.CODUNIDAD + "  La unidad ya se encuentra registrada.";
                        entSIC_RETORNO_NUEVO.Ok = false; break;
                    default:
                        entSIC_RETORNO_NUEVO.MENSAJE = "Se detecto un problema en el registro"; entSIC_RETORNO_NUEVO.Ok = false; break;
                }

                ListSIC_RETORNO.Add(entSIC_RETORNO_NUEVO);

            }
            return ListSIC_RETORNO;
        }




        public Nullable<bool> GrabarLoteNuevo(List<SolicitudUnidadViewModel> Lote, int contProceso = 0)
        {
            string tempDistrito = "", tempSector = "", tempManzana = "", tempLote = "";
            string tempEdificacion = "", tempEntrada = "", tempPiso = "", tempUnidad = "";
            string tempTipoDoc = "", tempCodigoSoli = "", tempTipoSoli = "", tempCodigoAno = "";
            string tempReferencia = "", tempTipoLote = ""; int tempNumero = 0;
            foreach (SolicitudUnidadViewModel ItemUnidad in Lote)
            {
                BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = ItemUnidad.CodigoDistrito,
                    CODSECTOR = ItemUnidad.CodigoSector,
                    CODMANZANA = ItemUnidad.CodigoManzana,
                    CODLOTE = ItemUnidad.CodigoLote,
                    CODEDIFICACION = ItemUnidad.Ed,
                    CODENTRADA = ItemUnidad.Entrada,
                    CODPISO = ItemUnidad.Piso,
                    CODUNIDAD = ItemUnidad.Unidad
                };
                tempDistrito = ItemUnidad.CodigoDistrito; tempSector = ItemUnidad.CodigoSector; tempManzana = ItemUnidad.CodigoManzana; tempLote = ItemUnidad.CodigoLote;
                tempEdificacion = ItemUnidad.Ed; tempEntrada = ItemUnidad.Entrada; tempPiso = ItemUnidad.Piso; tempUnidad = ItemUnidad.Unidad;
                tempCodigoSoli = ItemUnidad.CodigoNumeroSolicitud; tempTipoSoli = ItemUnidad.CodigoTipoSolicitud;
                tempReferencia = tempReferencia + "|" + ItemUnidad.CodigoDistrito + ItemUnidad.CodigoSector + ItemUnidad.CodigoManzana + ItemUnidad.CodigoLote + ItemUnidad.Ed + ItemUnidad.Entrada + ItemUnidad.Unidad;
                tempTipoDoc = ItemUnidad.CodigoTipoDocumento; tempCodigoAno = ItemUnidad.CodigoPeriodo;
                BE.SIC_UNIDAD srcQuery = new BL.SIC_UNIDAD().Recuperar(entQuery);
                if (srcQuery == null) { srcQuery = entQuery; }
                srcQuery.ESTADO = "T";
                //BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTE().Actualizar(srcQuery);
                //if (entSIC_RETORNO.Ok == false) contProceso++;
            }
            BE.SIC_SOLUNIDAD entQueryNuevo = new BE.SIC_SOLUNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = tempDistrito,
                CODSECTOR = tempSector,
                CODMANZANA = tempManzana,
                CODLOTE = tempLote,
                CODEDIFICACION = "0A",
                CODENTRADA = "01",
                CODPISO = "01",
                CODUNIDAD = "001",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODTIPOSOLI = tempTipoSoli,
                CODNUMESOLI = tempCodigoSoli,
                CODANOSOLI = DateTime.Now.Year.ToString(),
                CTIPODOCUMENTO = tempTipoDoc,
                CODREFANT = tempReferencia.Substring(1)
            };

            if (tempTipoLote == "1")
            {
                BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
            }
            else if (tempTipoLote == "2")
            {
                for (int i = 0; i < tempNumero; i++)
                {
                    BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
                }
            }
            else if (tempTipoLote == "3")
            {
                entQueryNuevo.CODEDIFICACION = tempEdificacion; entQueryNuevo.CODENTRADA = tempEntrada;
                entQueryNuevo.CODPISO = tempPiso; entQueryNuevo.CODUNIDAD = tempUnidad;
                entQueryNuevo.CODREFANT = "-";
                for (int i = 0; i < tempNumero; i++)
                {
                    BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
                }
            }

            return (contProceso == 0) ? true : false;
        }

        public List<NumeracionPredioViewModel> CargarDirecUnidad(string CodigoUniCat, int flgindirec, bool Estatico)
        {

            BE.SIC_UNIDADDIRECCONINTERIOR entQuery = new BE.SIC_UNIDADDIRECCONINTERIOR();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.FLAGINDIREC = flgindirec;
            entQuery.ESTATICO = Estatico.ToString().ToLower();

            ICollection<BE.SIC_UNIDADDIRECCONINTERIOR> listsrcQuery = new BL.SIC_UNIDADDIRECCONINTERIOR().Listar(entQuery);
            var lisDataQuery = new List<NumeracionPredioViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new NumeracionPredioViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Asignacion = item.CODTIPOASIG,
                    NombreVia = item.TXTTIPODEVIA + ". " + item.TXTVIA,
                    NumeroCuadra = Convert.ToString(item.NUMCUADRA),
                    NombreLado = item.TXTLADO,
                    NombreTipoEdificacion = item.TXTEDIFICACION + " " + item.TXTNUMEDIF,
                    NumTipoEdificacion = item.TXTNUMEDIF,
                    NombreInscripcion = item.TXTINSCRIPCION,
                    NombreTipoPuerta = item.TXTTIPOPUERTA,
                    NumeroPuerta = item.TXTTIPOPUERTA + " - " + item.TXTNUMEROPUERTA + " - " + item.TXTLETRAPUERTA,
                    LetraPuerta = item.TXTLETRAPUERTA,
                    CodigoCorrLoteDirecc = item.CODCORRUNIDDIREMUNI,
                    CodigoCorrManzVia = item.CODCORRMANZVIA,
                    CodigoVia = item.CODVIA,
                    CodigoLado = item.CODLADO,
                    TipoInterior = item.CODTIPOINTE,
                    EstadoInterior = item.CODESTAINTE,
                    NombreEstadoInterior = item.TXTESTADOINTERIOR,
                    NombreTipoInterior = item.TXTTIPOINTERIOR,
                    NumeroInterior = item.TXTNUMERO,
                    LetraInterior = item.TXTLETRA,
                    NombreAsignacion = item.TXTTIPOASIGNACION,
                    CodigoCorrDirecUnidad = item.CODCORRUNIDDIREINTE,
                    //txtArea = Decimal4(item.NUMAREATEMPI.ToString()),
                    txtArea = item.CODESTAINTE == "010003" ? Decimal4(item.NUMAREATEMPI.ToString()) : "",

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<LoteDocumentosRRPPViewModel> CargarDocumentosRRPPLote(string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            BE.SIC_LOTERRPP entQuery = new BE.SIC_LOTERRPP();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = CodigoDistrito;
            entQuery.CODSECTOR = CodigoSector;
            entQuery.CODMANZANA = CodigoManzana;
            entQuery.CODLOTE = CodigoLote;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_LOTERRPP> listsrcQuery = new BL.SIC_LOTERRPP().Buscar(entQuery);
            var lisDataQuery = new List<LoteDocumentosRRPPViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new LoteDocumentosRRPPViewModel
                {
                    Item = Convert.ToString(indice),
                    Detalle = item.TXTASIENTO,
                    Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("yyyy-MM-dd") : "",
                    CodigoDocumento = item.CODTIPODOCU,
                    PartidaElectronica = item.TXTPARTELEC,
                    TomoFicha = item.TXTTOMOFICH,
                    Folio = item.TXTFOLIO,
                    Asiento = item.TXTASIENTO,
                    CodigoCorrelativoLote = item.CODCORRLOTERRPP,
                    Ruta = item.TXTNOMDOCUINT,
                    TipoDocumento = item.TXTTIPODOCU

                });
                indice++;
            }
            return lisDataQuery;
        }


        public List<TitularRentasViewModel> CargarTitularRentas(string CodigoContribuyente, string CodigoTipoDocumentoIdentidad, string NumeroDocumento, string RazonSocial, string CodigoCatastrlalRentas)
        {

            BE.SIC_UNIDADTITULAR entQuery = new BE.SIC_UNIDADTITULAR();
            entQuery.CODCONTRIBUYENTE = CodigoContribuyente;
            entQuery.CODTIPODOCIDENTIDAD = CodigoTipoDocumentoIdentidad;
            entQuery.TXTDOCIDENTIDAD = NumeroDocumento;
            entQuery.TXTRAZONSOCIAL = RazonSocial;
            entQuery.CODCATASTRAL = CodigoCatastrlalRentas;

            ICollection<BE.SIC_UNIDADTITULAR> listsrcQuery = new BL.SIC_UNIDADTITULAR().ListarRentas(entQuery);
            var lisDataQuery = new List<TitularRentasViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new TitularRentasViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoContribuyente = item.CODCONTRIBUYENTE,
                    RazonSocial = item.TXTRAZONSOCIAL,
                    CodigoTipoDocumentoIdentidad = item.CODTIPODOCIDENTIDAD,
                    TipoDocumentoIdentidad = item.TIPODOCIDENTIDAD,
                    NumeroDocumentoIdentidad = item.TXTDOCIDENTIDAD,
                    CodigoTipoPropietario = item.CODPERSONA,
                    TipoPropietario = item.TIPOPERSONA

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<LicenciaFuncViewModel> CargarLicenciaFuncLote(string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            BE.SIC_LOTEAUTOLICE entQuery = new BE.SIC_LOTEAUTOLICE();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = CodigoDistrito;
            entQuery.CODSECTOR = CodigoSector;
            entQuery.CODMANZANA = CodigoManzana;
            entQuery.CODLOTE = CodigoLote;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_LOTEAUTOLICE> listsrcQuery = new BL.SIC_LOTEAUTOLICE().Buscar(entQuery);
            var lisDataQuery = new List<LicenciaFuncViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new LicenciaFuncViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.TXTBENEFICIARIO,
                    Solicitante = item.TXTSOLICITANTE,
                    TipoLicencia = item.TXTTIPOLICENCIA,
                    NumeroLicencia = item.TXTNUMLICENCIA,
                    Giros = item.TXTGIRO,
                    CodGiro = item.CODGIRO,
                    FechaLicencia = (item.FECLICENCIA != null) ? item.FECLICENCIA.Value.ToString("dd/MM/yyyy") : "",
                    //CodigoCatastral = item.CODIGO_CATASTRAL,
                    //Observaciones = item.OBSERVACIONES,
                    Codigo = item.TXTCODUNICO,
                    CodigoCorrelativoLote = item.CODCORRLOTEAUTOLICE,

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<ObrasPublicasViewModel> CargarObrasPublicasLote(string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            BE.SIC_LOTEAUTOEDIF entQuery = new BE.SIC_LOTEAUTOEDIF();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = CodigoDistrito;
            entQuery.CODSECTOR = CodigoSector;
            entQuery.CODMANZANA = CodigoManzana;
            entQuery.CODLOTE = CodigoLote;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_LOTEAUTOEDIF> listsrcQuery = new BL.SIC_LOTEAUTOEDIF().Buscar(entQuery);
            var lisDataQuery = new List<ObrasPublicasViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new ObrasPublicasViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.TXTBENEFICIARIO,
                    Solicitante = item.TXTSOLICITANTE,
                    TipoObra = item.TXTTIPOOBRA,
                    NumeroLicencia = item.TXTNUMLICENCIA,
                    FechaLicencia = (item.FECLICENCIA != null) ? item.FECLICENCIA.Value.ToString("dd/MM/yyyy") : "",
                    //CodigoCatastral = item.CODIGO_CATASTRAL,
                    //Observaciones = item.OBSERVACIONES,
                    Codigo = item.TXTCODUNICO,
                    CodigoCorrelativoLote = item.CODCORRLOTEAUTOEDIF,

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<LoteExpedienteDocViewModel> CargarExpedienteDocLote(string CodigoDistrito, string CodigoDepartamento, string CodigoSector, string CodigoManzana, string CodigoLote, bool Estatico)
        {

            BE.SIC_LOTEEXPEDOCU entQuery = new BE.SIC_LOTEEXPEDOCU();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = CodigoDistrito;
            entQuery.CODSECTOR = CodigoSector;
            entQuery.CODMANZANA = CodigoManzana;
            entQuery.CODLOTE = CodigoLote;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_LOTEEXPEDOCU> listsrcQuery = new BL.SIC_LOTEEXPEDOCU().Buscar(entQuery);
            var lisDataQuery = new List<LoteExpedienteDocViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new LoteExpedienteDocViewModel
                {
                    Item = Convert.ToString(indice),
                    Solicitante = item.TXTSOLICITANTE,
                    Documento = item.CODTIPODOCU,
                    Numero = item.TXTNUMERO,
                    Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("dd-MM-yyyy") : "",
                    Detalle = (item.TXTOBSERVACION != null) ? item.TXTOBSERVACION : "",
                    CodigoCorrelativoLote = item.CODCORRLOTEEXPEDOCU,

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<UnidadDocumentosRRPPViewModel> CargarUnidadRRPP(string CodigoUniCat, bool Estatico)
        {

            BE.SIC_UNIDADRRPP entQuery = new BE.SIC_UNIDADRRPP();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADRRPP> listsrcQuery = new BL.SIC_UNIDADRRPP().Listar(entQuery);
            var lisDataQuery = new List<UnidadDocumentosRRPPViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadDocumentosRRPPViewModel
                {
                    Item = Convert.ToString(indice),
                    Detalle = item.TXTASIENTO,
                    Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("yyyy-MM-dd") : "",
                    PartidaElectronica = item.TXTPARTELEC,
                    TomoFicha = item.TXTTOMOFICH,
                    Folio = item.TXTFOLIO,
                    Asiento = item.TXTASIENTO,
                    CodigoCorrelativo = item.CODCORRUNIDRRPP,
                    CodigoCorrelativoLote = item.CODCORRLOTERRPP,
                    Ruta = item.TXTNOMDOCUINT,
                    TipoDocumento = item.TXTTIPODOCU,
                    CodigoDepartamento = item.CODDEPARTAMENTO,
                    CodigoProvincia = item.CODPROVINCIA,
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<UnidadExpedienteDocViewModel> CargarUnidadExpedienteDoc(string CodigoUniCat, bool Estatico)
        {

            BE.SIC_UNIDADEXPEDOCU entQuery = new BE.SIC_UNIDADEXPEDOCU();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADEXPEDOCU> listsrcQuery = new BL.SIC_UNIDADEXPEDOCU().Listar(entQuery);
            var lisDataQuery = new List<UnidadExpedienteDocViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadExpedienteDocViewModel
                {
                    Item = Convert.ToString(indice),
                    Solicitante = item.TXTSOLICITANTE,
                    Documento = item.CODTIPODOCU,
                    Numero = item.TXTNUMERO,
                    Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("dd-MM-yyyy") : "",
                    Detalle = (item.TXTOBSERVACION != null) ? item.TXTOBSERVACION : "",
                    CodigoCorrelativo = item.CODCORRUNIDEXPEDOCU,
                    CodigoCorrelativoLote = item.CODCORRLOTEEXPEDOCU,



                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<UnidadLicenciaFuncViewModel> CargarUnidadLicenciaFunc(string CodigoUniCat, bool Estatico)
        {

            BE.SIC_UNIDADAUTOLICE entQuery = new BE.SIC_UNIDADAUTOLICE();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.ESTATICO = Estatico;


            ICollection<BE.SIC_UNIDADAUTOLICE> listsrcQuery = new BL.SIC_UNIDADAUTOLICE().Listar(entQuery);
            var lisDataQuery = new List<UnidadLicenciaFuncViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadLicenciaFuncViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.TXTBENEFICIARIO,
                    Solicitante = item.TXTSOLICITANTE,
                    TipoLicencia = item.TXTTIPOLICENCIA,
                    NumeroLicencia = item.TXTNUMLICENCIA,
                    Giros = item.TXTGIRO,
                    FechaLicencia = (item.FECLICENCIA != null) ? item.FECLICENCIA.Value.ToString("dd/MM/yyyy") : "",
                    CodigoCorrelativo = item.CODCORRAUTOLICE,
                    CodigoCorrelativoLote = item.CODCORRLOTEAUTOLICE,
                    Codigo = item.TXTCODUNICO

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<UnidadObrasPrivadasViewModel> CargarUnidadObrasPrivadas(string CodigoUniCat, bool Estatico)
        {

            BE.SIC_UNIDADAUTOEDIF entQuery = new BE.SIC_UNIDADAUTOEDIF();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADAUTOEDIF> listsrcQuery = new BL.SIC_UNIDADAUTOEDIF().Listar(entQuery);
            var lisDataQuery = new List<UnidadObrasPrivadasViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadObrasPrivadasViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.TXTBENEFICIARIO,
                    Solicitante = item.TXTSOLICITANTE,
                    TipoObra = item.TXTTIPOOBRA,
                    NumeroLicencia = item.TXTNUMLICENCIA,
                    FechaLicencia = (item.FECLICENCIA != null) ? item.FECLICENCIA.Value.ToString("dd/MM/yyyy") : "",
                    CodigoCorrelativo = item.CODCORRUNIDAE,
                    CodigoCorrelativoLote = item.CODCORRLOTEAUTOEDIF,
                    Codigo = item.TXTCODUNICO

                });
                indice++;
            }
            return lisDataQuery;
        }

        public bool? ProcesarUnidadTitular(UnidadTitularViewModel UnidadTitular)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADTITULAR entQuery = new BE.SIC_UNIDADTITULAR()
            {

                CODUNI = UnidadTitular.CodigoUni,
                CODCONTRIBUYENTE = UnidadTitular.CodigoContribuyente,
                NUMPORCTITU = UnidadTitular.PorcentajeTitularidad,
                CODCONDTITU = UnidadTitular.CondicionPropiedad,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                //CODCORRLOTERRPP = UnidadTitular.CodigoCorrelativoLote
                ESTATICO = UnidadTitular.Estatico

            };
            BE.SIC_UNIDADTITULAR srcUNITITU = new BL.SIC_UNIDADTITULAR().Recuperar(entQuery);

            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadTitular.Estado)
            {
                case 1: if (srcUNITITU == null) { entSIC_RETORNO = new BL.SIC_UNIDADTITULAR().Grabar(entQuery); } else { entSIC_RETORNO = new BL.SIC_UNIDADTITULAR().Actualizar(entQuery); } break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADTITULAR().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADTITULAR().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public bool? ProcesarUnidadRRPP(UnidadDocumentosRRPPViewModel UnidadRRPP)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADRRPP entQuery = new BE.SIC_UNIDADRRPP()
            {

                CODUNI = UnidadRRPP.CodigoUni,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = UnidadRRPP.CodigoDistrito,
                CODSECTOR = UnidadRRPP.CodigoSector,
                CODMANZANA = UnidadRRPP.CodigoManzana,
                CODLOTE = UnidadRRPP.CodigoLote,


                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                CODCORRLOTERRPP = UnidadRRPP.CodigoCorrelativoLote,
                ESTATICO = UnidadRRPP.Estatico

            };


            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadRRPP.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADRRPP().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADRRPP().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADRRPP().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public bool? ProcesarUnidadExpedienteDoc(UnidadExpedienteDocViewModel UnidadExpeDoc)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADEXPEDOCU entQuery = new BE.SIC_UNIDADEXPEDOCU()
            {

                CODUNI = UnidadExpeDoc.CodigoUni,
                TXTSOLICITANTE = UnidadExpeDoc.Solicitante,
                CODTIPODOCU = UnidadExpeDoc.Documento,
                TXTNUMERO = UnidadExpeDoc.Numero,
                TXTOBSERVACION = UnidadExpeDoc.Detalle,
                CODCORRLOTEEXPEDOCU = UnidadExpeDoc.CodigoCorrelativoLote,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                ESTATICO = UnidadExpeDoc.Estatico
            };

            if (UnidadExpeDoc.Fecha != null) entQuery.FECDOCUMENTO = DateTime.Parse(UnidadExpeDoc.Fecha);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadExpeDoc.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADEXPEDOCU().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADEXPEDOCU().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADEXPEDOCU().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public bool? ProcesarUnidadLicenciaFunc(UnidadLicenciaFuncViewModel UnidadLicenciaFunc)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADAUTOLICE entQuery = new BE.SIC_UNIDADAUTOLICE()
            {
                CODUNI = UnidadLicenciaFunc.CodigoUni,
                TXTBENEFICIARIO = UnidadLicenciaFunc.Beneficiario,
                TXTSOLICITANTE = UnidadLicenciaFunc.Solicitante,
                TXTTIPOLICENCIA = UnidadLicenciaFunc.TipoLicencia,
                TXTNUMLICENCIA = UnidadLicenciaFunc.NumeroLicencia,
                TXTGIRO = UnidadLicenciaFunc.Giros,
                CODGIRO = UnidadLicenciaFunc.CodGiro,
                CODCORRLOTEAUTOLICE = UnidadLicenciaFunc.CodigoCorrelativoLote,
                TXTCODUNICO = UnidadLicenciaFunc.Codigo,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                ESTATICO = UnidadLicenciaFunc.Estatico
            };

            if (UnidadLicenciaFunc.FechaLicencia != null) entQuery.FECLICENCIA = DateTime.Parse(UnidadLicenciaFunc.FechaLicencia);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadLicenciaFunc.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADAUTOLICE().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADAUTOLICE().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADAUTOLICE().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public bool? ProcesarUnidadObrasPrivadas(UnidadObrasPrivadasViewModel UnidadObrasPrivadas)
        {

            #region Asignar a la Entidad
            BE.SIC_UNIDADAUTOEDIF entQuery = new BE.SIC_UNIDADAUTOEDIF()
            {
                CODUNI = UnidadObrasPrivadas.CodigoUni,
                TXTBENEFICIARIO = UnidadObrasPrivadas.Beneficiario,
                TXTSOLICITANTE = UnidadObrasPrivadas.Solicitante,
                TXTTIPOOBRA = UnidadObrasPrivadas.TipoObra,
                TXTNUMLICENCIA = UnidadObrasPrivadas.NumeroLicencia,
                CODCORRLOTEAUTOEDIF = UnidadObrasPrivadas.CodigoCorrelativoLote,
                TXTCODUNICO = UnidadObrasPrivadas.Codigo,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODUSUARIOMODIF = VariablesWeb.IdUsuarioIntento,
                ESTATICO = UnidadObrasPrivadas.Estatico
            };

            if (UnidadObrasPrivadas.FechaLicencia != null) entQuery.FECLICENCIA = DateTime.Parse(UnidadObrasPrivadas.FechaLicencia);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (UnidadObrasPrivadas.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_UNIDADAUTOEDIF().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_UNIDADAUTOEDIF().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_UNIDADAUTOEDIF().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public List<UnidadTitularViewModel> CargarUnidadTitular(string CodigoUniCat, bool Estatico)
        {

            BE.SIC_UNIDADTITULAR entQuery = new BE.SIC_UNIDADTITULAR();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADTITULAR> listsrcQuery = new BL.SIC_UNIDADTITULAR().Listar(entQuery);
            var lisDataQuery = new List<UnidadTitularViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadTitularViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoContribuyente = item.CODCONTRIBUYENTE,
                    RasonSocial = item.TXTRAZONSOCIAL,
                    NumeroDocumento = item.TXTDOCIDENTIDAD,
                    PorcentajeTitularidad = item.NUMPORCTITU,
                    CondicionPropiedad = item.TXTCONDTITU,
                    TipoDocumento = item.TXTTIPODOCIDENTIDAD,
                    TipoPropietario = item.TXTTIPOPROPIETARIO,
                    Procedencia = item.TXTPROCEDENCIA
                });
                indice++;
            }
            return lisDataQuery;
        }

        public NumeracionPredioViewModel RecuperarMunicipalDirec(NumeracionPredioViewModel Direc)
        {
            BE.SIC_UNIDADDIRECCONINTERIOR entQuery = new BE.SIC_UNIDADDIRECCONINTERIOR()
            {

                CODUNI = Direc.CodigoUni,
                CODVIA = Direc.CodigoVia,
                CODCORRMANZVIA = Direc.CodigoCorrManzVia,
                CODCORRUNIDDIREMUNI = Direc.CodigoCorrLoteDirecc,
                CODCORRUNIDDIREINTE = Direc.CodigoCorrDirecUnidad,
                ESTATICO = Direc.Estatico.ToString().ToLower()
            };
            BE.SIC_UNIDADDIRECCONINTERIOR srcQuery = new BL.SIC_UNIDADDIRECCONINTERIOR().Recuperar(entQuery);
            NumeracionPredioViewModel lisDataQuery = new NumeracionPredioViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                CodigoCorrDirecUnidad = srcQuery.CODCORRUNIDDIREINTE,
                NumeroCuadra = Convert.ToString(srcQuery.NUMCUADRA),
                NumTipoEdificacion = srcQuery.TXTNUMEDIF,
                Asignacion = srcQuery.CODTIPOASIG,
                //CodigoTipoPuerta = srcQuery.CODTIPOPUER,
                NumeroInterior = srcQuery.TXTNUMERO,
                LetraInterior = srcQuery.TXTLETRA,
                TipoInterior = srcQuery.CODTIPOINTE,
                EstadoInterior = srcQuery.CODESTAINTE,
                TipoInscripcion = srcQuery.CODINSCATINT,
                Area = srcQuery.NUMAREATEMPI,
                CodigoVia = srcQuery.CODVIA + "-" + srcQuery.CODCORRMANZVIA + "-" + srcQuery.CODCORRUNIDDIREMUNI,

            };
            return lisDataQuery;
        }

        public List<LineasContructivasViewModel> RecuperarUnidadListaConstruccion(int CodigoUniCat, bool Estatico)
        {
            BE.SIC_UNIDADCONSTRUCCION entQuery = new BE.SIC_UNIDADCONSTRUCCION();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADCONSTRUCCION> srcQuery = new BL.SIC_UNIDADCONSTRUCCION().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADCONSTRUCCION>();
            }
            var lisDataQuery = new List<LineasContructivasViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new LineasContructivasViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    txtPiso = item.TXTPISO,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    Material = item.CODMATEESTR,
                    EstadoConst = item.CODESTACONSE,
                    Muro = item.CODCATEMURO,
                    Techo = item.CODCATETECH,
                    Piso = item.CODCATEPISO,
                    Puerta = item.CODCATEPUERVENT,
                    Revest = item.CODCATEREVE,
                    Bano = item.CODCATEBANO,
                    Electricas = item.CODCATEINSTELEC,
                    Declarada = item.NUMAREADECL,
                    Verificada = item.NUMAREAVERI,
                    CodigoCorrelativo = item.CODCORRUNIDCONS,
                });
            }
            return lisDataQuery;
        }


        public List<OtrasInstalacionesViewModel> RecuperarUnidadListaInstalaciones(int CodigoUniCat, bool Estatico)
        {
            BE.SIC_UNIDINSTALACION entQuery = new BE.SIC_UNIDINSTALACION();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDINSTALACION> srcQuery = new BL.SIC_UNIDINSTALACION().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDINSTALACION>();
            }
            var lisDataQuery = new List<OtrasInstalacionesViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new OtrasInstalacionesViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    EstadoConserva = item.CODESTACONSE,
                    CodigoUnidad = item.CODUNIDAD,
                    CodigoTipoInstalacion = item.CODINSTALACION,
                    Cantidad = item.NUMCANTIDAD,
                    Capacidad = item.NUMCAPACIDAD,
                    CodigoCorrelativo = item.CODCORRUNIDINST,
                });
            }
            return lisDataQuery;
        }

        public List<ActividadEconomicaViewModel> RecuperarUnidadListaActividad(int CodigoUniCat, bool Estatico)
        {
            BE.SIC_UNIDADACTIVIDAD entQuery = new BE.SIC_UNIDADACTIVIDAD();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADACTIVIDAD> srcQuery = new BL.SIC_UNIDADACTIVIDAD().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADACTIVIDAD>();
            }
            var lisDataQuery = new List<ActividadEconomicaViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new ActividadEconomicaViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    CodigoUso = item.CODUSOESPE,
                    Metro = item.NUMMETROS,
                    Fecha = (item.FECACTI != null) ? item.FECACTI.Value.ToString("yyyy-MM-dd") : "",
                    Retiro = item.CODUSORETIRO,
                    Anuncio = item.CODOPCIONANUN,
                    TipoAnuncio = item.CODANUNCIO,
                    CodigoCorrelativo = item.CODCORRELACTI,
                });
            }
            return lisDataQuery;
        }

        public List<ObservacionViewModel> RecuperarObservacion(int CodigoUniCat, string tipObs, bool Estatico)
        {
            BE.SIC_UNIDADOBSERVACION entQuery = new BE.SIC_UNIDADOBSERVACION();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.TIPOBSERVA = tipObs;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADOBSERVACION> srcQuery = new BL.SIC_UNIDADOBSERVACION().Listar(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADOBSERVACION>();
            }
            var lisDataQuery = new List<ObservacionViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new ObservacionViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    Fecha = (item.FECOBSERVACION != null) ? item.FECOBSERVACION.Value.ToString("dd/MM/yyyy") : "",
                    Observacion = item.TXTOBSERVACION,
                    TipoObservacion = item.TIPOBSERVA,
                    CodigoCorrelativo = item.CODCORROBSE,
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoLoteVia(CotitularidadViewModel Unidad, string Asignacion)
        {

            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoDistrito,
                CODSECTOR = Unidad.CodigoSector,
                CODMANZANA = Unidad.CodigoManzana,
                CODLOTE = Unidad.CodigoLote,
                CODTIPOASIG = Asignacion
            };
            entQuery.ESTATICO = Unidad.Estatico;

            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().ListarParaUc(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODVIA + "-" + item.CODCORRMANZVIA + "-" + item.CODCORRUNIDDIREMUNI, // + "-" + item.NUMCUADRA + "-" + item.CODLADO,
                    Text = item.TXTTIPODEVIA + ". " + item.TXTVIA + " - " + "CUADRA " + item.NUMCUADRA + " - " + "LADO " + item.TXTPARIDAD + " - " +
                    item.TXTEDIFICACION + " " + item.TXTNUMEDIF + " - " + "PUERTA " + item.TXTTIPOPUERTA + " - " + " N° " + item.TXTNUMERO + item.TXTLETRA
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoCuadra(CotitularidadViewModel Unidad, string concodvia)
        {

            String[] substrings = concodvia.Split('-');

            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoDistrito,
                CODSECTOR = Unidad.CodigoSector,
                CODMANZANA = Unidad.CodigoManzana,
                CODLOTE = Unidad.CodigoLote,
                CODVIA = substrings[0],
                CODCORRMANZVIA = substrings[1],
                CODCORRUNIDDIREMUNI = substrings[2]
            };



            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.NUMCUADRA.ToString(),
                    Text = item.NUMCUADRA.ToString()
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoLado(CotitularidadViewModel Unidad, string concodvia, int cuadra)
        {
            String[] substrings = concodvia.Split('-');

            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoDistrito,
                CODSECTOR = Unidad.CodigoSector,
                CODMANZANA = Unidad.CodigoManzana,
                CODLOTE = Unidad.CodigoLote,
                CODVIA = substrings[0],
                CODCORRMANZVIA = substrings[1],
                CODCORRUNIDDIREMUNI = substrings[2],
                NUMCUADRA = cuadra
            };

            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODLADO,
                    Text = item.TXTPARIDAD
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoEdificacion(CotitularidadViewModel Unidad, string concodvia, int cuadra, string lado)
        {
            String[] substrings = concodvia.Split('-');

            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoDistrito,
                CODSECTOR = Unidad.CodigoSector,
                CODMANZANA = Unidad.CodigoManzana,
                CODLOTE = Unidad.CodigoLote,
                CODVIA = substrings[0],
                CODCORRMANZVIA = substrings[1],
                CODCORRUNIDDIREMUNI = substrings[2],
                NUMCUADRA = cuadra,
                CODLADO = lado
            };

            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPOEDIF,
                    Text = item.TXTEDIFICACION
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListadoPuerta(CotitularidadViewModel Unidad, string concodvia, int cuadra, string lado, string edificacion)
        {
            String[] substrings = concodvia.Split('-');

            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoDistrito,
                CODSECTOR = Unidad.CodigoSector,
                CODMANZANA = Unidad.CodigoManzana,
                CODLOTE = Unidad.CodigoLote,
                CODVIA = substrings[0],
                CODCORRMANZVIA = substrings[1],
                CODCORRUNIDDIREMUNI = substrings[2],
                NUMCUADRA = cuadra,
                CODLADO = lado,
                CODTIPOEDIF = edificacion
            };

            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPOPUER,
                    Text = item.TXTTIPOPUERTA
                });
            }
            return lisDataQuery;
        }

        public Nullable<bool> EliminarUnidadTemporal(SolicitudUnidadViewModel Unidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {

                CODNUMESOLI = Unidad.CodigoNumeroSolicitud,
                CTIPODOCUMENTO = Unidad.CodigoTipoDocumento,
                CODUNI = Unidad.CodigoUni,
                CODTIPOSOLI = Unidad.CodigoTipoSolicitud,
                CODANOSOLI = DateTime.Now.Year.ToString(),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLUNIDAD().EliminarNuevoUnidad(entQuery);
            return entSIC_RETORNO.Ok;
        }


        public BE.SIC_RETORNO ValidarTemporal(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = CodUniCat,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODNUMESOLI = numsol,
                CODTIPOSOLI = tiposol,
                CTIPODOCUMENTO = docsol
            };

            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().ValidarTemporal(entQuery);
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarYaTemporal(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = CodUniCat,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODNUMESOLI = numsol,
                CODTIPOSOLI = tiposol,
                CTIPODOCUMENTO = docsol
            };

            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().ValidarYaTemporal(entQuery);
            return entSIC_RETORNO;
        }


        public BE.SIC_RETORNO ActualizarFlgTemporal(int CodUniCat, string aniosol, string numsol, string tiposol, string docsol, string Acttemp)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = CodUniCat,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODNUMESOLI = numsol,
                CODTIPOSOLI = tiposol,
                CTIPODOCUMENTO = docsol,
                FLGTEMP = Acttemp
            };

            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarFlgTemporal(entQuery);
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarFlgTemporalNull(int CodUniCat)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = CodUniCat
            };

            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarFlgTemporalNull(entQuery);
            return entSIC_RETORNO;
        }



        public BE.SIC_RETORNO EliminarTemporal(int CodUniCat)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {

                CODUNI = CodUniCat
            };

            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().EliminarTemporal(entQuery);
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ProcesarMigracionEstaticoTemporal(int? UnidadCatastral)
        {

            BE.SIC_UNIDAD tempQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = UnidadCatastral
            };
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().MigrarEstaticoTemporal(tempQuery);

            return entSIC_RETORNO;
        }

        //public BE.SIC_RETORNO ProcesarMigracionTemporalEstatico(int? UnidadCatastral)
        public BE.SIC_RETORNO ProcesarMigracionTemporalEstatico(BE.SIC_UNIDAD tempQuery)
        {

            //BE.SIC_UNIDAD tempQuery = new BE.SIC_UNIDAD()
            //{
            //    CODUNI = UnidadCatastral
            //};
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().MigrarTemporalEstatico(tempQuery);
            return entSIC_RETORNO;
        }

        public List<InspeccionesViewModel> RecuperarInspecciones(string CodigoUniCat, string aniosol, string numsol, string tiposol)
        {
            BE.SIC_UNIDADINSPECCION entQuery = new BE.SIC_UNIDADINSPECCION();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            entQuery.CODNUMESOLI = numsol;
            entQuery.CODTIPOSOLI = tiposol;

            ICollection<BE.SIC_UNIDADINSPECCION> srcQuery = new BL.SIC_UNIDAD().ListarUnidadInspeccion(entQuery);
            int orden = 0;
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADINSPECCION>();
            }
            var lisDataQuery = new List<InspeccionesViewModel>();
            foreach (var item in srcQuery.ToList())
            {

                lisDataQuery.Add(new InspeccionesViewModel
                {
                    Item = orden + 1,
                    NroDocumento = item.INFORME,
                    TipoDocumento = item.TIPO_INFORME,
                    FechaInspeccion = item.FECINSPE,
                    Inspector = item.INSPECTORES,
                    TipoLlenado = item.TXTTIPOLLENADO
                });
                orden = orden + 1;
            }
            return lisDataQuery;
        }

        public List<CartasInformesViewModel> RecuperarCartasInformes(string CodigoUniCat, string aniosol, string numsol, string tiposol, bool Estatico)
        {
            BE.SIC_UNIDADINSPECCION entQuery = new BE.SIC_UNIDADINSPECCION();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            entQuery.CODNUMESOLI = numsol;
            entQuery.CODTIPOSOLI = tiposol;
            entQuery.ESTATICO = Estatico;

            ICollection<BE.SIC_UNIDADINSPECCION> srcQuery = new BL.SIC_UNIDAD().ListarUnidadCartasInformes(entQuery);
            int orden = 0;
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADINSPECCION>();
            }
            var lisDataQuery = new List<CartasInformesViewModel>();
            foreach (var item in srcQuery.ToList())
            {

                lisDataQuery.Add(new CartasInformesViewModel
                {
                    Item = orden + 1,
                    NroDocumento = item.INFORME,
                    TipoDocumento = item.TIPO_DOCUMENTO,
                    Fecha = item.FECHA,
                    Responsable = item.RESPONSABLE
                });
                orden = orden + 1;
            }
            return lisDataQuery;
        }

        public List<SelectListItem> CondicionPropiedad()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().CondicionPropiertario();
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

        public string Decimal4(string numero)
        {
            if (numero == null)
            {
                numero = "0.0000";
            }

            if (!numero.Equals(""))
            {
                if (numero.Contains("."))
                {
                    int index = numero.IndexOf(".");
                    string cad;

                    if (index == 2)
                    {
                        cad = numero.Substring(numero.IndexOf("."), numero.Length - 2);
                    }
                    else
                    {
                        cad = numero.Substring(numero.IndexOf("."));
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
                }
                else
                {
                    return numero + ".0000";
                }

            }
            else
            {
                return "";
            }

        }

        public Nullable<bool> GrabarLoteLinderos(List<QuintaLinderosViewModel> Lote, int contProceso = 0)
        {
            foreach (QuintaLinderosViewModel ItemLote in Lote)
            {
                #region Asignar la entidad
                BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO();
                entQuery = JsonConvert.DeserializeObject<BE.SIC_QUINTALINDERO>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                entQuery.CORRELLINDE = ItemLote.Codigo;
                entQuery.CODLADO = ItemLote.CodigoLado;
                entQuery.NUMMEDIOFIC = ItemLote.MedidaLadoOfi;
                entQuery.NUMMEDICAMP = ItemLote.MedidaLadoCam;
                entQuery.CODTIPOCOLI = ItemLote.CodigoTipoColind;
                entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                entQuery.CODUNI = ItemLote.CODUNI;
                entQuery.ESTATICO = ItemLote.Estatico;
                //Edificacion
                if (ItemLote.CodigoTipoColind == "010004")
                {
                    entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                    entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                    entQuery.CODLOTECOLI = ItemLote.CodigoColindante.Substring(5, 3);
                    entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
                }

                //Unidad
                if (ItemLote.CodigoTipoColind == "010005")
                {
                    entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                    entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                    entQuery.CODLOTECOLI = ItemLote.CodigoColindante.Substring(5, 3);
                    entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
                    entQuery.CODENTRACOLI = ItemLote.CodigoColindante.Substring(10, 2);
                    entQuery.CODPISOCOL = ItemLote.CodigoColindante.Substring(12, 2);
                    entQuery.CODUNIDADCOLI = ItemLote.CodigoColindante.Substring(14, 3);
                }

                //Lote
                if (ItemLote.CodigoTipoColind == "010002")
                {
                    //entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                    //entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                    entQuery.CODLOTECOLI = ItemLote.CodigoColindante;
                    // entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
                }

                //Via o Parque
                if (ItemLote.CodigoTipoColind == "010001" || ItemLote.CodigoTipoColind == "010003")
                {
                    //entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                    //entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                    entQuery.CODCORMANZVIA = ItemLote.CodigoColindante.Substring(0, 4);
                    entQuery.CODVIA = ItemLote.CodigoColindante.Substring(5, 4);

                    // entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
                }

                #endregion
                //Si el estado es igual 1 se Eliminar, Si se encuentran datos se Actualiza, sino se Graba la información
                BE.SIC_RETORNO entSIC_RETORNO;
                var eliminar = false;


                switch (ItemLote.Estado)
                {
                    case "1":
                        entSIC_RETORNO = new BL.SIC_QUINTALINDERO().Grabar(entQuery);
                        ItemLote.Codigo = entSIC_RETORNO.CODIGO; break;
                    case "2": entSIC_RETORNO = new BL.SIC_QUINTALINDERO().Actualizar(entQuery); break;
                    default: entSIC_RETORNO = new BL.SIC_QUINTALINDERO().Eliminar(entQuery); eliminar = true; break;
                }
                if (entQuery.CORRELLINDE != null && ItemLote.Estado == "2")
                {
                    if (ItemLote.CodigoTipoColind == null && ItemLote.CodigoColindante == null)
                    {
                        entSIC_RETORNO = new BL.SIC_QUINTALINDERO().Eliminar(entQuery);
                    }
                }
                #region GRABAR LINDERO COLINDANTE
                if (ItemLote.CodigoColindante != null)
                {
                    //GrabarLoteLinderosAColindantes(ItemLote, eliminar);
                }
                #endregion
                if (entSIC_RETORNO.Ok == false) contProceso++;
            }
            return (contProceso == 0) ? true : false;
        }

        private Object LlenarEntidad(QuintaLinderosViewModel ItemLote, bool lote)
        {
            DATOS_LOTES entidad = new DATOS_LOTES();
            entidad.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entidad.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entidad.CODDISTRITO = ItemLote.CodigoDistrito;
            entidad.CODSECTOR = ItemLote.CodigoSector;
            entidad.CODMANZANA = ItemLote.CodigoManzana;
            if (lote == true)
            {
                entidad.CODLOTE = ItemLote.CodigoLote;
            }
            return entidad;
        }
        public Nullable<bool> EliminarLinderoUnidad(QuintaLinderosViewModel ItemLote)
        {

            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_QUINTALINDERO entQueryLindero = new BE.SIC_QUINTALINDERO();

            entQueryLindero = JsonConvert.DeserializeObject<BE.SIC_QUINTALINDERO>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQueryLindero.CODUNILINDERO = ItemLote.CodigoUnidadColidante;

            entQueryLindero.CODLADO = ItemLote.CodigoLado;
            entQueryLindero.CORRELLINDE = ItemLote.Codigo;
            entQueryLindero.ESTATICO = ItemLote.Estatico;
            entQueryLindero.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_QUINTALINDERO().EliminarLinderoUnidad(entQueryLindero);


            return entSIC_RETORNO_COLINDANTE.Ok;

        }
        public class DATOS_LOTES
        {
            public string CODDEPARTAMENTO { get; set; }
            public string CODPROVINCIA { get; set; }
            public string CODDISTRITO { get; set; }
            public string CODSECTOR { get; set; }
            public string CODMANZANA { get; set; }
            public string CODLOTE { get; set; }
            public string CODEDIFICACION { get; set; }
            public string CODENTRADA { get; set; }
            public string CODPISO { get; set; }
            public string CODUNIDAD { get; set; }
        }
        public List<SelectListItem> ListarLadoLinderoSelect()
        {
            IEnumerable<BE.SIC_LADO> lisQuery = new BL.SIC_LADO().Linderos(new BE.SIC_LADO());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLADO, Text = item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoColindanteSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoColindante();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                if (item.CODPARAMETRO == "010001" || item.CODPARAMETRO == "010002" || item.CODPARAMETRO == "010003" || item.CODPARAMETRO == "010004" || item.CODPARAMETRO == "010005")
                {
                    lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION });
                }
            }
            return lisDataQuery;
        }

        public QuintaLinderosViewModel RecuperarUnidadLinderoDetalle(QuintaLinderosViewModel Lote)
        {
            BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO()
            {
                CODUNILINDERO = Lote.CodigoUnidadColidante,
                CODLADO = Lote.CodigoLado,
                CORRELLINDE = Lote.Codigo,
                ESTATICO = Lote.Estatico
            };

            BE.SIC_QUINTALINDERO srcQuery = new BL.SIC_QUINTALINDERO().BuscarLinderoDetalle(entQuery);


            QuintaLinderosViewModel lisDataQuery = new QuintaLinderosViewModel()
            {
                codUniCat = srcQuery.CODUNI,
                MedidaLadoCam = srcQuery.NUMMEDICAMP,
                MedidaLadoOfi = srcQuery.NUMMEDIOFIC,
                ListLado = new CotitularidadHandler().ListarLadoLinderoSelect(),
                ListTipoColindante = new CotitularidadHandler().ListarTipoColindanteSelect(),
                Codigo = srcQuery.CORRELLINDE,
                CodigoLado = srcQuery.CODLADO,
                NumeroLado = Lote.NumeroLado,
            };
            return lisDataQuery;
        }
        public List<QuintaLinderosViewModel> CargarDetalleColindante(QuintaLinderosViewModel FiltrarSolUnidad)
        {
            var lisDataQuery = new List<QuintaLinderosViewModel>();
            int CodigoUnico;

            BE.SIC_QUINTALINDERO entQueryLinderoLote = new BE.SIC_QUINTALINDERO()
            {
                CODUNI = Convert.ToInt32(FiltrarSolUnidad.CodigoUnidadColidante),
                CODLADO = FiltrarSolUnidad.CodigoLado,
                CORRELLINDE = FiltrarSolUnidad.Codigo,
                ESTATICO = FiltrarSolUnidad.Estatico
            };
            ICollection<BE.SIC_QUINTALINDERO> lisQueryColVia = new BL.SIC_QUINTALINDERO().BuscarLinderosUnidad(entQueryLinderoLote);


            foreach (var item in lisQueryColVia)
            {
                lisDataQuery.Add(new QuintaLinderosViewModel
                {
                    NombreTipoColindante = item.TXTTIPOCOLINDANTE,
                    NombreColindante = item.TXTCOLINDANTE,
                    Correlativo = item.CORRELATIVO,
                    CodigoLado = item.CODLADO,
                    CodigoCorrelativo = item.CORRELLINDE,
                    CodigoTipoColind = item.CODTIPOCOLI
                });
            }
            return lisDataQuery;
        }
        public Nullable<bool> EliminarDetalleLindero(QuintaLinderosViewModel Lote)
        {
            int indice = 1;
            string codcorman = "";
            string codvia = "";

            BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_QUINTALINDERO>(JsonConvert.SerializeObject(LlenarEntidad(Lote, true)));
            entQuery.ESTATICO = Lote.Estatico;
            entQuery.CORRELATIVO = Lote.Correlativo;
            entQuery.CODLADO = Lote.CodigoLado;
            entQuery.CORRELLINDE = Lote.Codigo;
            entQuery.CODUNI = Convert.ToInt32(Lote.CodigoUnidadColidante);
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;



            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_QUINTALINDERO().EliminarDetalleLindero(entQuery);

            return entSIC_RETORNO.Ok;
        }
        public BE.SIC_RETORNO GrabarUnidadLinderoDetalle(QuintaLinderosViewModel ItemLote)
        {
            BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_QUINTALINDERO>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQuery.ESTATICO = ItemLote.Estatico;
            entQuery.CODUNILINDERO = ItemLote.CodigoUnidadColidante;
            entQuery.CODLADO = ItemLote.CodigoLado;
            entQuery.CORRELLINDE = ItemLote.Codigo;
            entQuery.NUMMEDIOFIC = ItemLote.MedidaLadoOfi;
            entQuery.NUMMEDICAMP = ItemLote.MedidaLadoCam;
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entQuery.CODTIPOCOLI = ItemLote.CodigoTipoColind;
            if (ItemLote.CodigoTipoColind == "" || ItemLote.CodigoTipoColind == null)
            {
                entQuery.ESTADO = "0";
            }
            else
            {
                entQuery.ESTADO = "1";
            }
            if (ItemLote.CodigoTipoColind == "010004")
            {
                entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                entQuery.CODLOTECOLI = ItemLote.CodigoColindante.Substring(5, 3);
                entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
            }

            //Unidad
            if (ItemLote.CodigoTipoColind == "010005")
            {
                entQuery.CODSECTCOLI = ItemLote.CodigoColindante.Substring(0, 2);
                entQuery.CODMANZCOLI = ItemLote.CodigoColindante.Substring(2, 3);
                entQuery.CODLOTECOLI = ItemLote.CodigoColindante.Substring(5, 3);
                entQuery.CODEDIFICCOLI = ItemLote.CodigoColindante.Substring(8, 2);
                entQuery.CODENTRACOLI = ItemLote.CodigoColindante.Substring(10, 2);
                entQuery.CODPISOCOL = ItemLote.CodigoColindante.Substring(12, 2);
                entQuery.CODUNIDADCOLI = ItemLote.CodigoColindante.Substring(14, 3);
            }

            if (ItemLote.CodigoTipoColind == "010002")
            {
                entQuery.CODLOTECOLI = ItemLote.CodigoColindante;
            }

            if (ItemLote.CodigoTipoColind == "010001" || ItemLote.CodigoTipoColind == "010003")
            {
                entQuery.CODCORMANZVIA = ItemLote.CodigoColindante.Substring(0, 4);
                entQuery.CODVIA = ItemLote.CodigoColindante.Substring(5, 4);
            }

            BE.SIC_RETORNO entSIC_RETORNO;

            entSIC_RETORNO = new BL.SIC_QUINTALINDERO().GrabarUnidadLinderoDetalle(entQuery);
            ItemLote.Codigo = entSIC_RETORNO.CODIGO;

            return entSIC_RETORNO;
        }
    }
}