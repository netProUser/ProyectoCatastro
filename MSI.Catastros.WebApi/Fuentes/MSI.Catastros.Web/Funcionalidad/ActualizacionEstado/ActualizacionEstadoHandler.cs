using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;


namespace MSI.Catastros.Web.Funcionalidad.ActualizacionEstado
{
    public class ActualizacionEstadoHandler
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

        public List<UnidadCatastralViewModel> RecargarTablaUnidad(FiltrarUnidadCatastralViewModel FiltrarUnidad)
        {

            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD() { 
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarUnidad.FiltrarCodigoSector,
                CODMANZANA = FiltrarUnidad.FiltrarCodigoManzana,
                CODLOTE = FiltrarUnidad.FiltrarCodigoLote,
                CODEDIFICACION = FiltrarUnidad.FiltrarEd,
                CODENTRADA = FiltrarUnidad.FiltrarEntrada,
                CODPISO = FiltrarUnidad.FiltrarPiso,
                CODUNIDAD = FiltrarUnidad.FiltrarUnidad
            };
            ICollection<BE.SIC_UNIDAD> lisQuery = new BL.SIC_UNIDAD().BuscarEstado(entQuery);
            var lisDataQuery = new List<UnidadCatastralViewModel>();
            
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new UnidadCatastralViewModel
                {
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entrada = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Unidad = item.CODUNIDAD,
                    CodigoCatastral = item.CODDISTRITO + "-" + item.CODSECTOR + "-" + item.CODMANZANA + "-" + item.CODLOTE + "-" + item.CODEDIFICACION + "-" + item.CODENTRADA + "-" + item.CODPISO + "-" + item.CODUNIDAD,
                    Ubicacion = item.TXTUBICACION,
                    CodigoUnico = item.CODUNI.ToString(),
                    Referencia = item.CODREFANT,
                    Version = item.NVERSION,
                    Usuario = item.CODUSUARIOMODIF,
                    FechaGeneracion = (item.FECMODIF != null) ? item.FECMODIF.Value.ToString("dd-MM-yyyy") : "",
                    EstadoUnidad = item.ESTADOUNIDAD

                });
            }
            return lisDataQuery;
        }
        public List<UnidadCatastralViewModel> ListarGridSinPag(DataTableAjaxPostModel model, FiltrarUnidadCatastralViewModel FiltroConsultas, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito,
                CODSECTOR = FiltroConsultas.FiltrarCodigoSector,
                CODMANZANA = FiltroConsultas.FiltrarCodigoManzana,
                CODLOTE = FiltroConsultas.FiltrarCodigoLote,
                CODEDIFICACION = FiltroConsultas.FiltrarEd,
                CODENTRADA = FiltroConsultas.FiltrarEntrada,
                CODPISO = FiltroConsultas.FiltrarPiso,
                CODUNIDAD = FiltroConsultas.FiltrarUnidad
            };
            var srcQueryLote = new BL.SIC_UNIDAD().BuscarEstadoLote(entQuery);
            var srcQuery = new BL.SIC_UNIDAD().BuscarEstadoSimple(entQuery);
            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();

            if (srcQuery.Count == 0) { srcQuery = new List<BE.SIC_UNIDAD>(); }
            var lisDataQuery = new List<UnidadCatastralViewModel>();
            string tempSector = "", tempManza = "", tempLote = "";
            foreach (var itemLote in srcQueryLote)
            {
                tempSector = itemLote.CODSECTOR;
                tempManza = itemLote.CODMANZANA;
                tempLote = itemLote.CODLOTE;
                lisDataQuery.Add(new UnidadCatastralViewModel
                {
                    CodigoDistrito = itemLote.CODDISTRITO,CodigoSector = itemLote.CODSECTOR,CodigoManzana = itemLote.CODMANZANA,CodigoLote = itemLote.CODLOTE,
                    Ed = itemLote.CODEDIFICACION,Entrada = itemLote.CODENTRADA,Piso = itemLote.CODPISO, Unidad = itemLote.CODUNIDAD,
                    CodigoCatastral = "LOTE: " +itemLote.CODDISTRITO + "-" + itemLote.CODSECTOR + "-" + itemLote.CODMANZANA + "-" + itemLote.CODLOTE,
                    Ubicacion = "",
                    CodigoUnico = "",
                    Referencia = "",
                    Version = itemLote.NVERSION,
                    Usuario = itemLote.CODUSUARIO,
                    FechaGeneracion = (itemLote.FECREG != null) ? itemLote.FECREG.Value.ToString("dd-MM-yyyy") : "",
                    EstadoUnidad = itemLote.ESTADOUNIDAD,
                    Estado = itemLote.ESTADO

                });
                foreach (var item in srcQuery)
                {
                    if (tempSector == item.CODSECTOR && tempManza == item.CODMANZANA && tempLote == item.CODLOTE)
                    {
                        lisDataQuery.Add(new UnidadCatastralViewModel
                        {
                            CodigoDistrito = item.CODDISTRITO,
                            CodigoSector = item.CODSECTOR,
                            CodigoManzana = item.CODMANZANA,
                            CodigoLote = item.CODLOTE,
                            Ed = item.CODEDIFICACION,
                            Entrada = item.CODENTRADA,
                            Piso = item.CODPISO,
                            Unidad = item.CODUNIDAD,
                            CodigoCatastral = item.CODDISTRITO + "-" + item.CODSECTOR + "-" + item.CODMANZANA + "-" + item.CODLOTE + "-" + item.CODEDIFICACION + "-" + item.CODENTRADA + "-" + item.CODPISO + "-" + item.CODUNIDAD,
                            Ubicacion = item.TXTUBICACION,
                            CodigoUnico = item.CODUNI.ToString(),
                            Referencia = item.CODREFANT,
                            Version = item.NVERSION,
                            Usuario = item.CODUSUARIO,
                            Estado = item.ESTADO,
                            FechaGeneracion = (item.FECREG != null) ? item.FECREG.Value.ToString("dd-MM-yyyy") : "",
                            EstadoUnidad = item.ESTADOUNIDAD ?? "H"
                        });
                    }
                }
            }
            return lisDataQuery;
        }
        public List<UnidadCatastralViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarUnidadCatastralViewModel FiltrarUnidad)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = null;
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltrarUnidad);
            var resultado = new List<UnidadCatastralViewModel>(listQuery.Count);
            foreach (var item in listQuery)
            {
                resultado.Add(new UnidadCatastralViewModel
                {
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entrada = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Unidad = item.CODUNIDAD,
                    CodigoCatastral = item.CODDISTRITO + "-" + item.CODSECTOR + "-" + item.CODMANZANA + "-" + item.CODLOTE + "-" + item.CODEDIFICACION + "-" + item.CODENTRADA + "-" + item.CODPISO + "-" + item.CODUNIDAD,
                    Ubicacion = item.TXTUBICACION,
                    CodigoUnico = item.CODUNI.ToString(),
                    Referencia = item.CODREFANT,
                    Version = item.NVERSION,
                    Usuario = item.CODUSUARIO,
                    Estado = item.ESTADO,
                    FechaGeneracion = (item.FECREG != null) ? item.FECREG.Value.ToString("dd-MM-yyyy") : "",
                    EstadoUnidad = item.ESTADOUNIDAD ?? "H"
                });
            }
            return (resultado == null) ? new List<UnidadCatastralViewModel>() : resultado;
        }

        public ICollection<BE.SIC_UNIDAD> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarUnidadCatastralViewModel FiltroConsultas)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;

            entQuery = new BL.SIC_UNIDAD().BuscarEstadoInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;

            var srcQuery = new BL.SIC_UNIDAD().BuscarEstado(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);

            return srcQuery;
        }

        public BE.SIC_RETORNO HabilitacionUnidad(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0, 2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                CODEDIFICACION = Unidad.CodigoCatastral.Substring(14, 2),
                CODENTRADA = Unidad.CodigoCatastral.Substring(17, 2),
                CODPISO = Unidad.CodigoCatastral.Substring(20, 2),
                CODUNIDAD = Unidad.CodigoCatastral.Substring(23, 3),
                CODUNI = Convert.ToInt32(Unidad.CodigoUnico),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_UNIDAD entSICTEMP = new BL.SIC_UNIDAD().RecuperarTemporal(entQuery);
            entQuery.ESTATICO = true;
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            if (entSICTEMP != null)
            {
                entQuery.CODUNI = entSICTEMP.CODUNI;
                BE.SIC_UNIDAD entSOL = new BL.SIC_UNIDAD().RecuperarSolicitud(entQuery);
                entSIC_RETORNO.MENSAJE = "Código se esta trabajando en la(s) solicitud(es) N°" + entSOL.TXTNOMDOCU;
                entSIC_RETORNO.Ok = false;
            }
            else
            {
                entQuery.ESTADOUNIDAD = "H";
                entSIC_RETORNO = new BL.SIC_UNIDAD().HabilitarUnidad(entQuery);
                entSIC_RETORNO.Ok = true;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO DeshabilitacionUnidad(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0, 2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                CODEDIFICACION = Unidad.CodigoCatastral.Substring(14, 2),
                CODENTRADA = Unidad.CodigoCatastral.Substring(17, 2),
                CODPISO = Unidad.CodigoCatastral.Substring(20, 2),
                CODUNIDAD = Unidad.CodigoCatastral.Substring(23, 3),
                CODUNI = Convert.ToInt32(Unidad.CodigoUnico),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_UNIDAD entSICTEMP = new BL.SIC_UNIDAD().RecuperarTemporal(entQuery);
            entQuery.ESTATICO = true;
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            if (entSICTEMP != null)
            {
                entQuery.CODUNI = entSICTEMP.CODUNI;
                BE.SIC_UNIDAD entSOL = new BL.SIC_UNIDAD().RecuperarSolicitud(entQuery);
                entSIC_RETORNO.MENSAJE = "Código se esta trabajando en la(s) solicitud(es) N°" + entSOL.TXTNOMDOCU;
                entSIC_RETORNO.Ok = false;
            }
            else
            {
                entQuery.ESTADOUNIDAD = "T";
                entSIC_RETORNO = new BL.SIC_UNIDAD().HabilitarUnidad(entQuery);
                entSIC_RETORNO.Ok = true;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActivacionLote(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0, 2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                ESTADO = "1",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarLoteUnidad(entQuery);
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO AnulacionLote(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0, 2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                ESTADO = "0",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarLoteUnidad(entQuery);
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActivacionUnidad(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0, 2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                CODEDIFICACION = Unidad.CodigoCatastral.Substring(14, 2),
                CODENTRADA = Unidad.CodigoCatastral.Substring(17, 2),
                CODPISO = Unidad.CodigoCatastral.Substring(20, 2),
                CODUNIDAD = Unidad.CodigoCatastral.Substring(23, 3),
                CODUNI = Convert.ToInt32(Unidad.CodigoUnico),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                ESTADO = "1",
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarUnidad(entQuery);
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO AnulacionUnidad(FiltrarUnidadCatastralViewModel Unidad)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Unidad.CodigoCatastral.Substring(0,2),
                CODSECTOR = Unidad.CodigoCatastral.Substring(3, 2),
                CODMANZANA = Unidad.CodigoCatastral.Substring(6, 3),
                CODLOTE = Unidad.CodigoCatastral.Substring(10, 3),
                CODEDIFICACION = Unidad.CodigoCatastral.Substring(14, 2),
                CODENTRADA = Unidad.CodigoCatastral.Substring(17, 2),
                CODPISO = Unidad.CodigoCatastral.Substring(20, 2),
                CODUNIDAD = Unidad.CodigoCatastral.Substring(23, 3),
                CODUNI = Convert.ToInt32(Unidad.CodigoUnico),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_UNIDAD entSICBCOMUN = new BL.SIC_UNIDAD().ValidacionEliminar(entQuery);
            BE.SIC_UNIDAD entSICTEMP = new BL.SIC_UNIDAD().RecuperarTemporal(entQuery);

            var cont = 0;
            //if (entQuery.CODLOTE.ToUpper().Contains("X") || entQuery.CODEDIFICACION.ToUpper().Contains("X") || entQuery.CODENTRADA.ToUpper().Contains("X"))
            //{
                //cont++;
            //}

            entQuery.ESTATICO = true;
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            if (entSICBCOMUN.BCOMUN != null && cont == 0) {
                entQuery.CODUNI = Convert.ToInt32(entSICBCOMUN.BCOMUN);
                BE.SIC_UNIDAD entBCOUM = new BL.SIC_UNIDAD().Recuperar(entQuery);
                if (entBCOUM.CODUNIDAD.ToUpper().Contains("X"))
                {
                    entSIC_RETORNO.MENSAJE = "Código Pertenece al Bien Común " + entBCOUM.CODDISTRITO + "-" + entBCOUM.CODSECTOR + "-" + entBCOUM.CODMANZANA + "-" + entBCOUM.CODLOTE
                        + "-" + entBCOUM.CODEDIFICACION + "-" + entBCOUM.CODENTRADA + "-" + entBCOUM.CODPISO + "-" + entBCOUM.CODUNIDAD + ", es necesario desasignar esta unidad en el módulo de Bien Común";
                }
                else {
                    entSIC_RETORNO.MENSAJE = "No se puede eliminar un bien común si tiene una o más unidades asignadas." ;
                }
                entSIC_RETORNO.Ok = false;
            }
            else if (entSICTEMP != null && entSICTEMP.ESTADO_UNIDAD =="TEMPORAL")
            {
                entQuery.CODUNI = entSICTEMP.CODUNI;
                BE.SIC_UNIDAD entSOL = new BL.SIC_UNIDAD().RecuperarSolicitud(entQuery);
                entSIC_RETORNO.MENSAJE = "Código se esta trabajando en la(s) solicitud(es) N°" + entSOL.TXTNOMDOCU;
                entSIC_RETORNO.Ok = false;
            }
            else
            {
                entQuery.ESTADO = "0";
                entSIC_RETORNO = new BL.SIC_UNIDAD().ActualizarUnidad(entQuery);
                entSIC_RETORNO.Ok = true;
            }
            return entSIC_RETORNO;
        }

        //------------------Nuevo

        public BE.SIC_RETORNO ProcesarMigracionEstaticoTemporal(FiltrarUnidadCatastralViewModel Unidad)
        {

            BE.SIC_UNIDAD tempQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = Convert.ToInt32(Unidad.CodigoUnico)
            };
            BE.SIC_RETORNO entSIC_RETORNO;
            entSIC_RETORNO = new BL.SIC_UNIDAD().MigrarEstaticoTemporal(tempQuery);

            return entSIC_RETORNO;
        }


    }
}