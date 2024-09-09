using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Sockets;
using System.Configuration;

namespace MSI.Catastros.Web.Funcionalidad.Lotes
{
    public class LotesHandler
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        
        #region RECUPERAR TABLAS
        public SolicitudUnidadViewModel RecuperarGrabarLote(SolicitudUnidadViewModel FiltrarSolUnidad, out bool resul)
        {

            BE.SIC_LOTE entQuery = new BE.SIC_LOTE();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);
            SolicitudUnidadViewModel lisDataQuery;
            if (srcQuery == null) {
                //Crear Lote inicial
                //BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTE().Grabar(entQuery);
                BE.SIC_RETORNO entSIC_RETORNO_LOTE = new BL.SIC_LOTE().MigrarEstaticoTemporal(entQuery);
                srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);
                if (entSIC_RETORNO_LOTE.NoMENSAJE != 0)
                {
                    lisDataQuery = new SolicitudUnidadViewModel();
                    resul = false;
                }
                else {
                    lisDataQuery = new SolicitudUnidadViewModel()
                    {
                        CodigoDistrito = srcQuery.CODDISTRITO,
                        CodigoSector = srcQuery.CODSECTOR,
                        CodigoManzana = srcQuery.CODMANZANA,
                        CodigoLote = srcQuery.CODLOTE,
                        Titular = "",
                        Ubicacion = ""
                    }; resul = true;
                }
            }
            else {
                lisDataQuery = new SolicitudUnidadViewModel() {
                    CodigoDistrito = srcQuery.CODDISTRITO,CodigoSector = srcQuery.CODSECTOR, CodigoManzana = srcQuery.CODMANZANA, CodigoLote = srcQuery.CODLOTE, Titular = "", Ubicacion = ""
                };resul = true;
            }
            return lisDataQuery;
        }
        public RegistrarLoteViewModel RecuperarLote(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            
            BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);
            RegistrarLoteViewModel lisDataQuery = new RegistrarLoteViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                Denominacion = srcQuery.TXTDENOMINACION,
                Cuc = srcQuery.TXTCUC,
                LoteUrbano = srcQuery.TXTLOTEURBA,
                SubLoteUrbano = srcQuery.TXTSUBLOTEURBA,
                LoteEsquina = srcQuery.FLGLOTEESQU,
                TipoLote = srcQuery.CODTIPOLOTE,
                MonumentoHistorico = srcQuery.FLGMONUHIST,
                AreaTerrenoCampo = srcQuery.NUMAREATERRCAMP,
                AreaTerrenoOficial = srcQuery.NUMAREATERROFIC,
                AreaConstruidaTotal = srcQuery.NUMAREACONSTOTAL,
                CodigoFuente = srcQuery.CODFUENTE,
                SectorPlaneamiento = srcQuery.TXTSECTPLAN,
                SectorSeguridad = srcQuery.TXTSECTSEGU,
                SectorVecinal = srcQuery.TXTSECTVECI,
                SubSectorPlaneamiento = srcQuery.TXTSUBSECTPLAN,
                SubSectorSeguridad = srcQuery.TXTSUBSECTSEGU,
                SubSectorVecinal = srcQuery.TXTSUBSECTVECI,
                AlturaEdificacion = srcQuery.TXTALTURAEDIF,
                UsoPredio = srcQuery.TXTUSOPREDO,
                NumeroResolucion = srcQuery.TXTRESONUM,
                FechaResolucion = srcQuery.FECRESOLUC == null ? "" : srcQuery.FECRESOLUC.Value.ToString("dd/MM/yyyy"),
            };
            return lisDataQuery;
        }
        public bool RecuperarUnidadNueva(SolicitudUnidadViewModel FiltrarSolUnidad, out string mensaje)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD(); entQuery = JsonConvert.DeserializeObject<BE.SIC_UNIDAD>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.CODEDIFICACION = FiltrarSolUnidad.Ed; entQuery.CODENTRADA = FiltrarSolUnidad.Entrada;
            entQuery.CODPISO = FiltrarSolUnidad.Piso; entQuery.CODUNIDAD = FiltrarSolUnidad.Unidad;
            List<BE.SIC_UNIDAD> srcQuery = new BL.SIC_UNIDAD().Buscar(entQuery).ToList();

            BE.SIC_SECTOR entQuerySector = new BE.SIC_SECTOR(); entQuerySector = JsonConvert.DeserializeObject<BE.SIC_SECTOR>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, false)));
            BE.SIC_MANZANA entQueryManzana = new BE.SIC_MANZANA(); entQueryManzana = JsonConvert.DeserializeObject<BE.SIC_MANZANA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, false)));

            BE.SIC_SECTOR srcQuerySector = new BL.SIC_SECTOR().Recuperar(entQuerySector);
            BE.SIC_MANZANA srcQueryManzana = new BL.SIC_MANZANA().Recuperar(entQueryManzana);

            BE.SIC_LOTE entQueryLote = new BE.SIC_LOTE(); entQueryLote = JsonConvert.DeserializeObject<BE.SIC_LOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            BE.SIC_LOTE srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);
            if (srcQuerySector == null ) {
                mensaje = "No se puede generar nuevo código, revisar si el sector existe";
                return false;
            }
            if(srcQueryManzana == null){
                mensaje = "No se puede generar nuevo código, revisar si la manzana existe";
                return false;
            }
            if(srcQueryLote != null)
            {
                mensaje = "No se puede generar nuevo código, el lote ya existe";
                return false;
            }
            if(srcQuery.Count != 0)
            {
                mensaje = "No se puede generar nuevo código, la unidad ya existe";
                return false;
            }
            mensaje ="Datos Correctos";
            return true;
        }
        public RegistrarHabilitacionViewModel RecuperarHabilitacionUrbana(RegistrarHabilitacionViewModel Lote)
        {
            BE.SIC_LOTEHABIURBA entQuery = new BE.SIC_LOTEHABIURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODHABURBA = Lote.CodigoHabilitacionUrbana,
                CODMANZURB = Lote.CodigoManzanaUrbana,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTEHABIURBA srcQuery = new BL.SIC_LOTEHABIURBA().Recuperar(entQuery);

            RegistrarHabilitacionViewModel lisDataQuery = new RegistrarHabilitacionViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                ListHabilitacionUrbana = new List<SelectListItem>(),
                ListManzanaUrbana = new List<SelectListItem>(),
                CodigoHabilitacionUrbana = srcQuery.CODHABURBA,
                CodigoManzanaUrbana = srcQuery.CODMANZURB,
                CodigoTipoHabilitacion = srcQuery.CODTIPOHABURB,
                NombreTipoHabilitacion = srcQuery.CODTIPOHABURB
            };
            return lisDataQuery;
        }

        public LoteLinderosViewModel RecuperarLoteLindero(LoteLinderosViewModel Lote)
        {
            BE.SIC_LOTELINDERO entQuery = new BE.SIC_LOTELINDERO()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODLADO = Lote.CodigoLado,
                CODCORRLADO = Lote.Codigo,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTELINDERO srcQuery = new BL.SIC_LOTELINDERO().Recuperar(entQuery);

            var srcSolUnidad = new SolicitudUnidadViewModel()
            {
                CodigoDistrito = Lote.CodigoDistrito,
                CodigoLote = Lote.CodigoLote,
                CodigoSector = Lote.CodigoSector,
                CodigoManzana = Lote.CodigoManzana
            };

          
            LoteLinderosViewModel lisDataQuery = new LoteLinderosViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                MedidaLadoCam = srcQuery.NUMMEDICAMP,
                MedidaLadoOfi = srcQuery.NUMMEDIOFIC,
                ListLado = new LotesHandler().ListarLadoLinderoSelect(),
                ListFuente = new LotesHandler().ListarFuentesColinSelect(),
                ListTipoColindante = new LotesHandler().ListarTipoColindanteSelect(),
                ListAlturaVia = new LotesHandler().ListarParamAlturaVia(),
                Codigo = srcQuery.CODCORRLADO,
                CodigoLado = srcQuery.CODLADO,
                NumeroLado = Lote.NumeroLado,
                CodigoFuenteCol = srcQuery.CODFTELIN,
                CodigoColindante = "",
                CodigoAlturaVia = srcQuery.CODALTVIAFOR
            };
            return lisDataQuery;
        }
        public LoteOtrosDocumentosViewModel AgregarOtrosDocumentoAsignado(LoteOtrosDocumentosViewModel ItemLote)
        {
            BE.SIC_LOTEOTRODOC entQuery = new BE.SIC_LOTEOTRODOC()
            {
                CODDISTRITO = ItemLote.CodigoDistrito,
                CODSECTOR = ItemLote.CodigoSector,
                CODMANZANA = ItemLote.CodigoManzana,
                CODLOTE = ItemLote.CodigoLote,
                CORRELATIVO = ItemLote.Correlativo,
                ESTATICO = ItemLote.Estatico
            };
            BE.SIC_LOTEOTRODOC srcQuery = new BL.SIC_LOTEOTRODOC().DescargarOtrosDocumento(entQuery);

            LoteOtrosDocumentosViewModel lisDataQuery = new LoteOtrosDocumentosViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                NroItem = ItemLote.NroItem,
                TipoDocumento = srcQuery.CODDOCUMENTO,
                NroDocumento = srcQuery.TXTNRODOCUMENTO,
                FechaDocumento = srcQuery.FECDOCUMENTO == null ? "" : srcQuery.FECDOCUMENTO.Value.ToString("dd/MM/yyyy"),
                Observacion = srcQuery.TXTOBSERVACION,
                Correlativo = srcQuery.CORRELATIVO,
                ListTipoDocumento = new LotesHandler().ListarTipoOtrosDocumentos(), 
            };
            return lisDataQuery;
        }
        public RegistrarDirecMunicipalViewModel RecuperarMunicipalDirec(RegistrarDirecMunicipalViewModel Lote)
        {
            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito, CODSECTOR = Lote.CodigoSector, CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote, CODVIA = Lote.CodigoVia,
                CODCORRMANZVIA = Lote.CodigoManzanaVia,
                CODCORRUNIDDIREMUNI = Lote.Codigo,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTEDIRECMUNI srcQuery = new BL.SIC_LOTEDIRECMUNI().Recuperar(entQuery);
            RegistrarDirecMunicipalViewModel lisDataQuery = new RegistrarDirecMunicipalViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                Codigo = srcQuery.CODCORRUNIDDIREMUNI,
                TipoEdificacion = srcQuery.CODTIPOEDIF,
                NumeroCuadra = Convert.ToString(srcQuery.NUMCUADRA),
                NumTipoEdificacion = srcQuery.TXTNUMEDIF,
                CodigoAsignacion = srcQuery.CODTIPOASIG,
                CodigoTipoPuerta = srcQuery.CODTIPOPUER,
                NumeroPuerta = srcQuery.TXTNUMERO,
                LetraPuerta = srcQuery.TXTLETRA,
                CodigoVia = srcQuery.CODCORRMANZVIA + "-" + srcQuery.CODVIA + "_" + srcQuery.NUMCUADRA + "|" + srcQuery.CODLADO

            };
            return lisDataQuery;
        }
        public RegistrarRetiroMunicipalViewModel RecuperarRetiro(RegistrarRetiroMunicipalViewModel Lote)
        {
            BE.SIC_LOTERETIRO entQuery = new BE.SIC_LOTERETIRO()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito, CODSECTOR = Lote.CodigoSector, CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote, CODVIA = Lote.CodigoVia,
                CODCORRMANZVIA = Lote.CodigoManzanaVia,
                CODCORRLOTERETI = Lote.Codigo,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTERETIRO srcQuery = new BL.SIC_LOTERETIRO().Recuperar(entQuery);
            RegistrarRetiroMunicipalViewModel lisDataQuery = new RegistrarRetiroMunicipalViewModel()
            {
                CodigoDistrito = srcQuery.CODDISTRITO,
                CodigoSector = srcQuery.CODSECTOR,
                CodigoManzana = srcQuery.CODMANZANA,
                CodigoLote = srcQuery.CODLOTE,
                Codigo = srcQuery.CODCORRLOTERETI,
                OcupacionRetiro = srcQuery.FLGOCUPRETI,
                OcupacionJardin = srcQuery.FLGOCUPJARD,
                DescripcionRetiro = srcQuery.CODDESCRETI,
                DescripcionJardin = srcQuery.CODDESCJARD,
                JardinAislamOfi = srcQuery.NUMJARDAISL,
                RetiroCampo = srcQuery.NUMRETIMUNI,
                CodigoVia = srcQuery.CODCORRMANZVIA + "-" + srcQuery.CODVIA + "_" + srcQuery.NUMCUADRA
            };
            return lisDataQuery;
        }
        #endregion

        #region BUSCAR TABLAS
        public ProcedimientoNuevoViewModel BuscarSolicitudes(FiltrarLotesViewModel FiltrarLotesBuscar)
        {
            #region Obtener datos
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.CODTIPOSOLI = FiltrarLotesBuscar.FiltrarCodigoTipoSolicitud;
            entQuery.CODNUMESOLI = FiltrarLotesBuscar.FiltrarNumeroSolicitud;
            entQuery.CODTIPODOC = FiltrarLotesBuscar.FiltrarCodigoTipoDocumentoReg;
           // entQuery.CODANOSOLI = System.DateTime.Now.Year.ToString();
            BE.SIC_SOLISEGUI query = new BL.SIC_SOLISEGUI().Recuperar(entQuery);
            var dataQuery = new ProcedimientoNuevoViewModel();
            if (query == null)
            {
                query = new BE.SIC_SOLISEGUI();
            }
            #endregion
            #region Asignar al ViewModel
            dataQuery.CodigoTipoSolicitud = query.CODTIPOSOLI;
            dataQuery.NumeroSolicitud = query.CODNUMESOLI;
            dataQuery.Periodo = query.CODANOSOLI;
            #endregion
            return dataQuery;
        }
        public List<LoteSolicitudViewModel> BuscarLoteSolicitud(FiltrarLotesViewModel FiltrarLotesBuscar)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarLotesBuscar.FiltrarCodigoSector,
                CODMANZANA = FiltrarLotesBuscar.FiltrarCodigoManzana,
                CODLOTE = FiltrarLotesBuscar.FiltrarCodigoLote,
                ESTATICO = FiltrarLotesBuscar.Estatico
            };

            ICollection<BE.SIC_LOTE> lisQuery = new BL.SIC_LOTE().RecuperarSolicitud(entQuery);
            var lisDataQuery = new List<LoteSolicitudViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LoteSolicitudViewModel
                {
                    CodigoLote = item.CODLOTE,
                    CodigoManzana = item.CODMANZANA,
                    CodigoSector = item.CODSECTOR,
                    CodigoNumeroSolicitud = item.CODNUMESOLI
                });
            }
            return lisDataQuery;
        }
        public FiltrarLotes BuscarLotes(FiltrarLotesViewModel FiltrarLotesBuscar)
        {
            #region Obtener datos
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE(){
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarLotesBuscar.FiltrarCodigoSector,
                CODMANZANA = FiltrarLotesBuscar.FiltrarCodigoManzana,
                CODLOTE = FiltrarLotesBuscar.FiltrarCodigoLote,
                ESTATICO = FiltrarLotesBuscar.Estatico
            };
            BE.SIC_LOTE query = new BL.SIC_LOTE().Recuperar(entQuery);
            var dataQuery = new FiltrarLotes();
            if (query == null)
            {
                query = new BE.SIC_LOTE();
            }
            #endregion
            #region Asignar al ViewModel
            dataQuery.CodigoDistrito = query.CODDISTRITO;
            dataQuery.CodigoSector = query.CODSECTOR;
            dataQuery.CodigoManzana = query.CODMANZANA;
            dataQuery.CodigoLote = query.CODLOTE;
            #endregion
            return dataQuery;
        }
        public List<LoteLinderosViewModel> BuscarLoteLinderos(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTELINDERO entQuery = new BE.SIC_LOTELINDERO(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERO>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTELINDERO> lisQuery = new BL.SIC_LOTELINDERO().Buscar(entQuery);
            var lisDataQuery = new List<LoteLinderosViewModel>();
            foreach (var item in lisQuery)
            {
                #region BuscarLoteColindantes
                string CodigoColin = "";
                if (item.CODTIPOCOLI != "010002")
                {
                    BE.SIC_LOTELINDEROVIADET entQueryColVia = new BE.SIC_LOTELINDEROVIADET()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = FiltrarSolUnidad.CodigoDistrito, CODSECTOR = FiltrarSolUnidad.CodigoSector, CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                        CODLOTE = FiltrarSolUnidad.CodigoLote, CODLADO = item.CODLADO, CODCORRLADO = item.CODCORRLADO, ESTATICO = FiltrarSolUnidad.Estatico
                    };
                    ICollection<BE.SIC_LOTELINDEROVIADET> lisQueryColVia = new BL.SIC_LOTELINDEROVIADET().Buscar(entQueryColVia);
                    foreach (var itemColVia in lisQueryColVia)
                    {
                        CodigoColin = itemColVia.CODCORRMANZVIA + "-" + itemColVia.CODVIA;
                    }
                }
                else {
                    BE.SIC_LOTELINDERODET entQueryColVia = new BE.SIC_LOTELINDERODET()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = FiltrarSolUnidad.CodigoDistrito, CODSECTOR = FiltrarSolUnidad.CodigoSector, CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                        CODLOTE = FiltrarSolUnidad.CodigoLote,
                        CODLADO = item.CODLADO,
                        CODCORRLADO = item.CODCORRLADO,
                        ESTATICO = FiltrarSolUnidad.Estatico
                    };
                    BE.SIC_LOTELINDERODET lisQueryColVia = new BL.SIC_LOTELINDERODET().Recuperar(entQueryColVia);
                    if (lisQueryColVia != null) {
                        CodigoColin = lisQueryColVia.CODLOTECOLI;
                    }
                    
                }
                #endregion
                lisDataQuery.Add(new LoteLinderosViewModel
                {
                    MedidaLadoCam = item.NUMMEDICAMP,
                    MedidaLadoOfi = item.NUMMEDIOFIC,
                    CodigoTipoColind = item.CODTIPOCOLI,
                    CodigoLado = item.CODLADO,
                    NumeroLado = item.CODCORRLADO,
                    CodigoFuenteCol = item.CODFTELIN,
                    Codigo = item.CODCORRLADO,
                    CodigoColindante = CodigoColin
                });
            }
            return lisDataQuery;
        }
        public List<ZonifLoteViewModel> BuscarLoteZonificacion(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_ZONIFLOTE entQuery = new BE.SIC_ZONIFLOTE(); entQuery = JsonConvert.DeserializeObject<BE.SIC_ZONIFLOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_ZONIFLOTE> lisQuery = new BL.SIC_ZONIFLOTE().Buscar(entQuery);
            var lisDataQuery = new List<ZonifLoteViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ZonifLoteViewModel
                {
                    Codigo = item.CODZONIFICACION,
                });
            }
            return lisDataQuery;
        }
        public List<LoteObservacionViewModel> BuscarLoteObservacion(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTEOBSERVACION entQuery = new BE.SIC_LOTEOBSERVACION(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEOBSERVACION>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            
            ICollection<BE.SIC_LOTEOBSERVACION> lisQuery = new BL.SIC_LOTEOBSERVACION().Listar(entQuery);
            var lisDataQuery = new List<LoteObservacionViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LoteObservacionViewModel
                {
                    Detalle = (item.TXTOBSERVACION != null) ? item.TXTOBSERVACION : "" ,
                    Fecha = (item.FECOBSERVACION != null) ? item.FECOBSERVACION.Value.ToString("dd/MM/yyyy") : "",
                    Codigo = item.CODCORROBSE
                });
            }
            return lisDataQuery;
        }
        public List<LoteDocumentosRRPPViewModel> BuscarLoteDocumentosRRPP(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTERRPP entQuery = new BE.SIC_LOTERRPP(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTERRPP>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTERRPP> lisQuery = new BL.SIC_LOTERRPP().Buscar(entQuery);
            var lisDataQuery = new List<LoteDocumentosRRPPViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LoteDocumentosRRPPViewModel
                {
                    Detalle = item.TXTASIENTO,
                    Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("dd/MM/yyyy") : "",
                    CodigoDocumento = item.CODTIPODOCU,
                    PartidaElectronica = (item.TXTPARTELEC != null) ? item.TXTPARTELEC : "",
                    TomoFicha = (item.TXTTOMOFICH != null) ? item.TXTTOMOFICH : "",
                    Folio = (item.TXTFOLIO != null) ? item.TXTFOLIO : "",
                    Asiento = (item.TXTASIENTO != null) ? item.TXTASIENTO : "",
                    Codigo = (item.CODCORRLOTERRPP != null) ? item.CODCORRLOTERRPP : "",
                    Ruta = (item.TXTNOMDOCUINT != null) ? item.TXTNOMDOCUINT : ""
                });
            }
            return lisDataQuery;
        }
        
        public List<LoteDocumentosViewModel> BuscarLoteDocumentos(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTE entQueryLote = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                ESTATICO = FiltrarSolUnidad.Estatico
            };
            string codcat = "";
            string CodTemp = "";

            BE.SIC_LOTE srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);

            BE.SIC_LOTE entQuery = new BE.SIC_LOTE();
            if (FiltrarSolUnidad != null)
            {
                codcat = srcQueryLote.CODDISTRITO + srcQueryLote.CODSECTOR + srcQueryLote.CODMANZANA + srcQueryLote.CODLOTE;
            }
            else {
                entQuery.CODIGO_CATASTRAL = "";codcat = "";
            }

            entQuery.CODIGO_CATASTRAL = codcat;
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTE> lisQuery = new BL.SIC_LOTE().ListarDocum(entQuery);
            var lisDataQuery = new List<LoteDocumentosViewModel>();
            var tempString = "";
            foreach (var item in lisQuery)
            {
                if (tempString != item.TXTSOLICITANTE + item.TXTDOCUMENTO + item.TXTNUMERO + item.TXTIDTRAMITE) { 
                    lisDataQuery.Add(new LoteDocumentosViewModel
                    {
                        Detalle = (item.TXTOBSERVACION != null && item.CODLOTE == FiltrarSolUnidad.CodigoLote) ? item.TXTOBSERVACION : "",
                        Fecha = (item.FECHA != null) ? item.FECHA.Value.ToString("yyyy-MM-dd") : "",
                        Solicitante = item.TXTSOLICITANTE,
                        Documento = item.TXTDOCUMENTO,
                        Numero = item.TXTNUMERO,
                        Codigo = item.TXTIDTRAMITE,
                        Flag = item.FLAG,
                        CodSoli = (item.COD_RECURRENTE != null) ? item.COD_RECURRENTE : "",
                        Correlativo = (item.CODCORRLOTEEXPEDOCU != null && item.CODLOTE == FiltrarSolUnidad.CodigoLote) ? item.CODCORRLOTEEXPEDOCU : "",
                    });
                }
                tempString = item.TXTSOLICITANTE + item.TXTDOCUMENTO + item.TXTNUMERO + item.TXTIDTRAMITE;

            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarParamAltura(BE.SIC_MANZANAVIA entQuery)
        {
            BE.SIC_MANZANAVIA lisQuery = new BL.SIC_MANZANAVIA().Recuperar(entQuery);
            if (lisQuery == null) {
                lisQuery = new BE.SIC_MANZANAVIA();
            }
            var ParamAltura = ListarParamAlturaVia();
            var ListAltura = (lisQuery.TXTALTURA != null) ? lisQuery.TXTALTURA.Split(',') : new string[0];
            var lisDataQuery = new List<SelectListItem>();
            for (var i = 0; i < ListAltura.Length; i++) {
                var nombre = "";
                foreach (var item in ParamAltura) {
                    if (item.Value == ListAltura[i]) {
                        nombre = item.Text;
                    }
                }
                lisDataQuery.Add(new SelectListItem { Value = ListAltura[i], Text = nombre });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarParamZonificacion(BE.SIC_ZONIFMANZAVIA entQuery)
        {
            IEnumerable<BE.SIC_ZONIFMANZAVIA> lisQuery = new BL.SIC_ZONIFMANZAVIA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODZONIFICACION, Text = item.TXTABREVIACION + "-" + item.TXTZONIFICACION }); }
            return lisDataQuery;
        }
        public List<LoteNormaUrbanaViewModel> BuscarNormaUrbana(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTENORMAURBANA entQuery = new BE.SIC_LOTENORMAURBANA(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTENORMAURBANA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            IEnumerable<BE.SIC_LOTENORMAURBANA> lisQuery = new BL.SIC_LOTENORMAURBANA().Buscar(entQuery);
            var lisDataQuery = new List<LoteNormaUrbanaViewModel>();
            foreach (var item in lisQuery)
            {
                var entQueryZonif = new BE.SIC_ZONIFMANZAVIA() {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                    CODSECTOR = FiltrarSolUnidad.CodigoSector,
                    CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                    CODVIA = item.CODVIA,
                    CODCORRMANZVIA = item.CODCORRMANZVIA
                };
                var entQueryManzaVia = new BE.SIC_MANZANAVIA() {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                    CODSECTOR = FiltrarSolUnidad.CodigoSector,
                    CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                    CODVIA = item.CODVIA,
                    CODCORRMANZVIA = item.CODCORRMANZVIA
                };
                lisDataQuery.Add(new LoteNormaUrbanaViewModel
                {
                    Altura = item.NUMALTURA,
                    Observacion = item.TXTOBSERVACION,
                    Via = item.TXTVIA,
                    CodVia = item.CODVIA,
                    CodManzanaVia = item.CODCORRMANZVIA,
                    AlturaVia = item.TXTALTURA,
                    ZonificacionVia = item.TXTZONIFICACION,
                    ListZonificacion = ListarParamZonificacion(entQueryZonif),
                    ListAltura = ListarParamAltura(entQueryManzaVia)
                });
            }
            return lisDataQuery;
        }
        #endregion


        #region CARGAR DATATABLES
        public List<RegistrarHabilitacionViewModel> CargarHabilitacion(SolicitudUnidadViewModel Habilitacion)
        {
            BE.SIC_LOTEHABIURBA entQuery = new BE.SIC_LOTEHABIURBA(); 
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEHABIURBA>(JsonConvert.SerializeObject(LlenarEntidadSol(Habilitacion, true)));
            entQuery.ESTATICO = Habilitacion.Estatico;

            List<BE.SIC_LOTEHABIURBA> srcQuery = (Habilitacion.CodigoDistrito == "" && Habilitacion.CodigoSector == "" && Habilitacion.CodigoManzana == "") ? new List<BE.SIC_LOTEHABIURBA>() : new BL.SIC_LOTEHABIURBA().Buscar(entQuery);
            var lisDataQuery = new List<RegistrarHabilitacionViewModel>();
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new RegistrarHabilitacionViewModel
                {
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    CodigoTipoHabilitacion = item.CODTIPOHABURB,
                    CodigoHabilitacionUrbana = item.CODHABURBA,
                    CodigoManzanaUrbana = item.CODMANZURB,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                    NombreManzanaUrbana = item.TXTMANZAURB,
                    NombreHabilitacion = item.TXTURBANIZACION
                });
            }
            return lisDataQuery;
        }
        
        public List<LoteLinderosViewModel> CargarDetalleColindante(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            var lisDataQuery = new List<LoteLinderosViewModel>();

            BE.SIC_LOTELINDEROVIADET entQueryLinderoLote = new BE.SIC_LOTELINDEROVIADET()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = FiltrarSolUnidad.CodigoDistrito,
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODLADO = FiltrarSolUnidad.CodigoLado,
                CODCORRLADO = FiltrarSolUnidad.CodigoCorrelativo,
                ESTATICO = FiltrarSolUnidad.Estatico
            };

            ICollection<BE.SIC_LOTELINDEROVIADET> lisQueryColVia = new BL.SIC_LOTELINDERODETALLE().BuscarLinderosLote(entQueryLinderoLote);

            foreach (var item in lisQueryColVia)
            {
                lisDataQuery.Add(new LoteLinderosViewModel
                {
                    NombreTipoColindante = item.TXTTIPOCOLINDANTE,
                    NombreColindante = item.TXTCOLINDANTE,
                    Correlativo = item.CORRELATIVO,
                    CodigoLado=item.CODLADO,
                    CodigoCorrelativo = item.CODCORRLADO,
                    CodigoVia = item.CODVIA ,
                    CodigoCorManzana = item. CODCORRMANZVIA,
                    CodigoTipoColind = item.CODTIPOCOLI
                });
            }
                return lisDataQuery;
        }
        #endregion
        public List<SolicitudUnidadViewModel> DocumentosLote (string draw, string start, string length, int pageSize, int skip, DataTableAjaxPostModel model, SolicitudUnidadViewModel FiltrarDocumentos, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (model.search != null) ? model.search.value : null;



            BE.SIC_LOTEEXPEDOCU entSOLISEG = new BE.SIC_LOTEEXPEDOCU()
            {
                TXTCODIGOCATASTRAL = FiltrarDocumentos.CodigoCatastral,
                ESTATICO = FiltrarDocumentos.Estatico

            };

            ICollection<BE.SIC_LOTEEXPEDOCU> srcQuery = new BL.SIC_LOTEEXPEDOCU().DocumentosLote(entSOLISEG);
            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();

            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new SolicitudUnidadViewModel
                {
                    CodigoTipoDocumento = item.CODTIPODOCU,
                    CodigoNumeroSolicitud = item.TXTNUMERO,
                    Solicitante = item.TXTSOLICITANTE,
                    FechaDocumento = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("dd/MM/yyyy") : "",
                    Observacion = item.TXTOBSERVACION,
                    CodigoTramite = item.TXTIDTRAMITE,
                    CodigoSolicitante = item.COD_RECURRENTE,
                    Habilitado = item.HABILITADO,
                    Asunto = item.TXTASUNTO
                    //CodigoDocumento = item.CODTIPODOC,
                    //Nro = item.NRO


                });
            }
            return lisDataQuery;
        }

        #region NUEVO REGISTRO Y LECTURA DE LOS COLIDANTES
        public List<LoteLinderosViewModel> CargarLinderos(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTELINDERO entQuery = new BE.SIC_LOTELINDERO();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERO>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTELINDERO> srcQuery = new BL.SIC_LOTELINDERO().Buscar(entQuery);
            var lisDataQuery = new List<LoteLinderosViewModel>();
            int indice = 1;
            int contF = 0, contI = 0, contD = 0, contA = 0;
            foreach (var item in srcQuery)
            {
                #region BuscarLoteColindantes

                var ListaColindanteLotes = new List<SelectListItem>();
                string temColindanteLotes = string.Empty;
                string CodigoLindVia = "";


                BE.SIC_LOTELINDEROVIADET entQueryLinderoLote = new BE.SIC_LOTELINDEROVIADET()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = FiltrarSolUnidad.CodigoDistrito,
                    CODSECTOR = FiltrarSolUnidad.CodigoSector,
                    CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                    CODLOTE = FiltrarSolUnidad.CodigoLote,
                    CODLADO = item.CODLADO,
                    CODCORRLADO = item.CODCORRLADO,
                    ESTATICO = FiltrarSolUnidad.Estatico
                };

                ICollection<BE.SIC_LOTELINDEROVIADET> lisQueryColVia = new BL.SIC_LOTELINDERODETALLE().BuscarLinderosLote(entQueryLinderoLote);
                foreach (var itemLinderoDetalle in lisQueryColVia)
                {
                    ListaColindanteLotes.Add(new SelectListItem()
                    {
                        Value = itemLinderoDetalle.TXTCOLINDANTE,
                        Text = itemLinderoDetalle.TXTCOLINDANTE,
                    });
                    CodigoLindVia = itemLinderoDetalle.CODCORRMANZVIA + "-" + itemLinderoDetalle.CODVIA;
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
                lisDataQuery.Add(new LoteLinderosViewModel
                {
                    NombreLado = item.TXTPARIDAD,
                    NumeroLado = correlativoLado,
                    MedidaLadoCam = item.NUMMEDICAMP,
                    MedidaLadoOfi = item.NUMMEDIOFIC,
                    NombreFuente = item.TXTFUENTE,
                    ListaColindantes = ListaColindanteLotes,
                    ListaLoteColindantes = temColindanteLotes,
                    CodigoAlturaVia = item.TXTALTVIAFOR,
                    CodigoCorrelativo = item.CODCORRLADO,
                    CodigoLado = item.CODLADO,
                    CodigoColindante = CodigoLindVia,
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                });

                indice++;
            }
            return lisDataQuery;
        }
        #endregion


        public List<RegistrarDirecMunicipalViewModel> CargarDirecMunicipal(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEDIRECMUNI>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTEDIRECMUNI> srcQuery = new BL.SIC_LOTEDIRECMUNI().Buscar(entQuery);
            var lisDataQuery = new List<RegistrarDirecMunicipalViewModel>();
            int indice = 1;
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new RegistrarDirecMunicipalViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    CodigoAsignacion = item.CODTIPOASIG,
                    NombreVia = item.TXTVIA,
                    NumeroCuadra = Convert.ToString(item.NUMCUADRA),
                    NombreLado = item.TXTPARIDAD,
                    NombreTipoEdificacion = item.TXTEDIFICACION,
                    NumTipoEdificacion = item.TXTNUMEDIF,
                    NombreTipoPuerta = item.TXTTIPOPUERTA,
                    NumeroPuerta = item.TXTNUMERO,
                    LetraPuerta = item.TXTLETRA,
                    Codigo = item.CODCORRUNIDDIREMUNI,
                    CodigoManzanaVia = item.CODCORRMANZVIA,
                    CodigoVia = item.CODVIA,
                    NombreAsignacion = item.TXTASIGNACION
                });
                indice++;
            }
            return lisDataQuery;
        }
        public List<RegistrarRetiroMunicipalViewModel> CargarRetiroMunicipal(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTERETIRO entQuery = new BE.SIC_LOTERETIRO(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTERETIRO>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTERETIRO> srcQuery = new BL.SIC_LOTERETIRO().Buscar(entQuery);
            var lisDataQuery = new List<RegistrarRetiroMunicipalViewModel>();
            int indice = 1;
            foreach (var item in srcQuery)
            {
                lisDataQuery.Add(new RegistrarRetiroMunicipalViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    NumeroCuadra = Convert.ToString(item.NUMCUADRA),
                    NombreLado = item.TXTPARIDAD,
                    OcupacionRetiro = item.FLGOCUPRETI,
                    OcupacionJardin = item.FLGOCUPJARD,
                    DescripcionRetiro = item.CODDESCRETI,
                    DescripcionJardin = item.CODDESCJARD,
                    JardinAislamOfi = item.NUMJARDAISL,
                    JardinOficial = item.NUMJARDIN,
                    RetiroCampo = item.NUMRETIMUNI,
                    RetiroOficial = item.NUMRETIRO,
                    NombreVia = item.TXTVIA,
                    Codigo = item.CODCORRLOTERETI,
                    CodigoManzanaVia = item.CODCORRMANZVIA,
                    CodigoVia = item.CODVIA,
                });
                indice++;
            }
            return lisDataQuery;
        }
        public List<LicenciaEdificacionViewModel> BuscarLoteDocumentosObras(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.DDU_LICENCIAEDIFICACION entQuery = new BE.DDU_LICENCIAEDIFICACION();
            BE.SIC_LOTE entQueryLote = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                ESTATICO = FiltrarSolUnidad.Estatico
            };
            string CodigoCatastralNuevo = "";
            string CodigoCatastralAntiguo = "";
            string CodTemp = "";
            BE.SIC_LOTE srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);

            if (srcQueryLote != null)
            {
                CodigoCatastralNuevo = srcQueryLote.CODLOTECATASTRAL;
                CodigoCatastralAntiguo = srcQueryLote.LOTECODCATANT;
            }
            else {
                CodigoCatastralNuevo = "";
                CodigoCatastralAntiguo = "";
            }

            entQuery.CODIGO_CATASTRAL = CodigoCatastralNuevo;
            entQuery.CODIGO_CATASTRAL_ANTIGUO = CodigoCatastralAntiguo;

            ICollection<BE.DDU_LICENCIAEDIFICACION> lisQuery = new BL.DDU_LICENCIAEDIFICACION().Consulta(entQuery);
            var lisDataQuery = new List<LicenciaEdificacionViewModel>();
            int indice = 1;
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LicenciaEdificacionViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.BENEFICIARIO,
                    Solicitante = item.SOLICITANTE,
                    TipoObra = item.TIPO_OBRA,
                    NumeroLicencia = item.NUMERO_LICENCIA,
                    FechaLicencia = (item.FECHA_LICENCIA != null) ? item.FECHA_LICENCIA.Value.ToString("dd/MM/yyyy"): "",
                    CodigoCatastral = item.CODIGO_CATASTRAL,
                    Observaciones = item.OBSERVACIONES,
                    Codigo = item.CODUNICO
                });
                indice++;
            }
            return lisDataQuery;
        }
        
        public List<LicenciaEdificacionViewModel> CargarLoteOtrosDocumentos(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTERRPP entQueryLote = new BE.SIC_LOTERRPP()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                ESTATICO = FiltrarSolUnidad.Estatico
            };


            ICollection<BE.SIC_LOTERRPP> lisQuery = new BL.SIC_LOTERRPP().CargarLoteOtrosDocumentos(entQueryLote);
            var lisDataQuery = new List<LicenciaEdificacionViewModel>();
            int indice = 1;
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LicenciaEdificacionViewModel
                {
                    Item = Convert.ToString(indice),
                    TipoDocumento   = item.TXTTIPODOCU,
                    NroDocumenro    = item.TXTNRODOCUMENTO,
                    FechaDocumento  = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("dd/MM/yyyy") : "",
                    Correlativo     = item.CORRELATIVO,
                    Observaciones   = item.TXTOBSERVACION,
                    PdfHabilitado   = item.PDFHABILITADO
                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<LicenciaViewModel> BuscarLoteDocumentosLicencias(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.DDU_LICENCIA entQuery = new BE.DDU_LICENCIA();
            BE.SIC_LOTE entQueryLote = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                ESTATICO = FiltrarSolUnidad.Estatico
            };
            string codcat = ""; string CodTemp = "";
            BE.SIC_LOTE srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);

            if (srcQueryLote != null)
            {
                string CodManz = (FiltrarSolUnidad.CodigoManzana.Substring(0, 1) != "0") ? FiltrarSolUnidad.CodigoManzana : FiltrarSolUnidad.CodigoManzana.Substring(1);
                string CodLote = (FiltrarSolUnidad.CodigoLote.Substring(0, 1) != "0") ? FiltrarSolUnidad.CodigoLote : FiltrarSolUnidad.CodigoLote.Substring(1);
                if (srcQueryLote.CODREFANT != null)
                {
                    String[] ArrayCodigoCatastral = srcQueryLote.CODREFANT.Split('|');
                    foreach (String CodCatastral in ArrayCodigoCatastral)
                    {
                        String[] ArrayCodigo = CodCatastral.Split('-'); string CodTempManz = ArrayCodigo[2]; string CodTempLote = ArrayCodigo[3];
                        CodManz = (CodTempManz.Substring(0, 1) != "0") ? CodTempManz : CodTempManz.Substring(1);
                        CodLote = (CodTempLote.Substring(0, 1) != "0") ? CodTempLote : CodTempLote.Substring(1);
                        CodTemp = CodTemp + "," + FiltrarSolUnidad.CodigoDistrito + FiltrarSolUnidad.CodigoSector + CodManz + CodLote;
                    }
                    codcat = CodTemp.Substring(1);
                }
                else { codcat = FiltrarSolUnidad.CodigoDistrito + FiltrarSolUnidad.CodigoSector + CodManz + CodLote; }
            }
            else { entQuery.CODIGO_CATASTRAL = ""; codcat = ""; }
            entQuery.CODIGO_CATASTRAL = codcat;
            ICollection<BE.DDU_LICENCIA> lisQuery = new BL.DDU_LICENCIA().Consulta(entQuery);
            var lisDataQuery = new List<LicenciaViewModel>();
            int indice = 1;
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new LicenciaViewModel
                {
                    Item = Convert.ToString(indice),
                    Beneficiario = item.BENEFICIARIO,
                    Solicitante = item.SOLICITANTE,
                    TipoLicencia = item.TIPO_LICENCIA,
                    NumeroLicencia = item.NUMERO_LICENCIA,
                    Giros = item.GIROS,
                    CodGiro = item.USO,
                    FechaLicencia = (item.FECHA_LICENCIA != null) ? item.FECHA_LICENCIA.Value.ToString("dd/MM/yyyy") : "",
                    CodigoCatastral = item.CODIGO_CATASTRAL,
                    Observaciones = item.OBSERVACIONES,
                    Codigo = item.CODIGO_UNICO
                });
                indice++;
            }
            return lisDataQuery;
        }
        public List<InspeccionesViewModel> BuscarLoteDocumentosInspecciones(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = FiltrarSolUnidad.CodigoDistrito,
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
            };
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTE> lisQuery = new BL.SIC_LOTE().ListarInspec(entQuery);
            var lisDataQuery = new List<InspeccionesViewModel>();
            int indice = 1;
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new InspeccionesViewModel
                {
                    Item = Convert.ToString(indice),
                    FechaInspeccion = (item.FECINSPE != null) ? item.FECINSPE.Value.ToString("dd/MM/yyyy") : "",
                    CodigoUnidad = item.CODIGOUNIDAD,
                    Inspectores = item.TXTINSPECTORES,
                    InspectorResponsable = item.TXTRESPONSABLE,
                    Observacion = item.TXTOBSERVACION,
                    Codigo = item.CODNROINSPEC,
                });
                indice++;
            }
            return lisDataQuery;
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
        public List<SolicitudUnidadViewModel> RecargarTablaSolUnidad(DataTableAjaxPostModel model, FiltrarLotesViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 50;
            var skip = model.start;

            BE.SIC_SOLICITUD entQuerySolicitud = new BE.SIC_SOLICITUD();
            entQuerySolicitud.CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud;
            entQuerySolicitud.CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud;
            entQuerySolicitud.CODTIPODOC = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            entQuerySolicitud.CODANOSOLI = System.DateTime.Now.Year.ToString();
            BE.SIC_SOLICITUD querySolicitud = new BL.SIC_SOLICITUD().Recuperar(entQuerySolicitud);

            #region Obtener datos
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.FiltrarCodigoPeriodo,
                CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento


            };
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarUnique(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            var referencia = 0;
            foreach (var item in data) {
                if (item.FLG_TRABAJO != "R") {
                    referencia++;
                }
            }

            foreach (var item in data)
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
                            CodigoCorrelativo = item.CORRELUNIDAD,
                            CodigoPeriodo = item.CODANOSOLI,
                            Bloqueado = querySolicitud.CODESTADOFINAL,
                            CodigoTipoSolicitud = item.CODTIPOSOLI,
                            FlagTrabajo = item.FLG_TRABAJO,
                            FlagUsuario = item.FLG_USUARIO,
                            CodigoNumeroSolicitud = item.CODNUMESOLI,

                            Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : "",
                            Titular = "",
                            Ubicacion = ""
                        });
                        if (item.TXTESTADOHAB == item.TXTESTADOTOT)
                        {
                            lisDataQuery.Last().EstadoUnidad = "H";
                        }
                        else if (item.TXTESTADOTEMP == item.TXTESTADOTOT)
                        {
                            lisDataQuery.Last().EstadoUnidad = "T";
                        }
                        else if (Convert.ToInt32(item.TXTESTADOTEMP) > 0)
                        {
                            lisDataQuery.Last().EstadoUnidad = "T (Algunas U.C.)";
                        }
                    }
                }
                else if (item.FLG_TRABAJO == "T")
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
                        FlagTrabajo = item.FLG_TRABAJO,
                        FlagUsuario = item.FLG_USUARIO,
                        CodigoCorrelativo = item.CORRELUNIDAD,
                        CodigoPeriodo = item.CODANOSOLI,
                        CodigoTipoSolicitud = item.CODTIPOSOLI,
                        CodigoNumeroSolicitud = item.CODNUMESOLI,
                        Referencia = (item.CODREFANT != null)? item.CODREFANT.Replace("|", "<br>") : "",
                        Titular = "",
                        Ubicacion = ""
                    });
                    if(item.TXTESTADOHAB  == item.TXTESTADOTOT) {
                        lisDataQuery.Last().EstadoUnidad = "H";
                    } else if (item.TXTESTADOTEMP == item.TXTESTADOTOT){
                        lisDataQuery.Last().EstadoUnidad = "T";
                    } else if (Convert.ToInt32(item.TXTESTADOTEMP) > 0 ){
                        lisDataQuery.Last().EstadoUnidad = "T (Algunas U.C.)";
                    }
                }
                
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecargarTablaLote(DataTableAjaxPostModel model, FiltrarLotesViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.FiltrarCodigoSector,
                CODMANZANA = FiltrarSolUnidad.FiltrarCodigoManzana,
                CODLOTE = FiltrarSolUnidad.FiltrarCodigoLote
            };
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            ICollection<BE.SIC_LOTE> srcQuery = new BL.SIC_LOTE().ListarEstaticoIgual(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_LOTE>();
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
                    FlagTrabajo = item.FLGHABILITADO,
                    Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : "",
                    EstadoUnidad = "H",
                    Titular = "",
                    Ubicacion = ""
                });
            }
            return lisDataQuery;
        }
       

        #region GRABAR, ACTUALIZAR Y ELIMINAR TABLAS

        public Nullable<bool> GrabarLote(RegistrarLoteViewModel Lote)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);

            srcQuery.TXTLOTEURBA = Lote.LoteUrbano;
            srcQuery.TXTSUBLOTEURBA = Lote.SubLoteUrbano;
            srcQuery.TXTDENOMINACION = Lote.Denominacion;
            srcQuery.FLGLOTEESQU = Lote.LoteEsquina;
            srcQuery.CODTIPOLOTE = Lote.TipoLote;
            srcQuery.TXTSECTPLAN = Lote.UsoPredio;
            srcQuery.FLGMONUHIST = Lote.MonumentoHistorico;
            srcQuery.NUMAREATERRCAMP = Lote.AreaTerrenoCampo;
            srcQuery.NUMAREATERROFIC = Lote.AreaTerrenoOficial;
            srcQuery.CODFUENTE = Lote.CodigoFuente;
            srcQuery.NUMAREACONSTOTAL = Lote.AreaConstruidaTotal;
            srcQuery.NUMALTULOTE = Lote.AlturaEdificacion;
            if (Lote.UsoPredio != null) { 
                int indice = Lote.UsoPredio.IndexOf("-");
                srcQuery.CODUSOCLAS = Lote.UsoPredio.Substring(0, indice-1);
            }

            srcQuery.TXTSECTPLAN = Lote.SectorPlaneamiento;
            srcQuery.TXTSECTSEGU = Lote.SectorSeguridad;
            srcQuery.TXTSECTVECI = Lote.SectorVecinal;
            srcQuery.TXTSUBSECTPLAN = Lote.SubSectorPlaneamiento;
            srcQuery.TXTSUBSECTSEGU = Lote.SubSectorSeguridad;
            srcQuery.TXTSUBSECTVECI = Lote.SubSectorVecinal;
            srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            srcQuery.TXTRESONUM = Lote.NumeroResolucion;
            if (Lote.FechaResolucion != null) { 
                srcQuery.FECRESOLUC = Convert.ToDateTime(Lote.FechaResolucion);
            }
            srcQuery.ESTATICO = Lote.Estatico;
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTE().Actualizar(srcQuery);
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> GrabarLoteImagen(RegistrarLoteViewModel Lote)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);

            #region Subir archivo
            var archivo = Lote.archivo;
            //string repo = "REPOSIC"; string anio = DateTime.Now.Year.ToString(); string mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            //string carpeta = "\\" + repo + "\\" + anio + "\\" + mes;
            string repo = "IMAGENES"; string tiporepo = "INTERIOR\\SECTOR\\MANZANA\\LOTE";
            string carpeta = "\\" + repo + "\\" + tiporepo;
            
            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                if (archivo != null)
                {
                     string _NombreArchivo = Path.GetFileName(archivo.FileName);
                     string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                     string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                     string _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                     _Ext = _Ext.Substring(1);
                     string tempCodigo = entQuery.CODDEPARTAMENTO + entQuery.CODPROVINCIA + entQuery.CODDISTRITO + entQuery.CODSECTOR + entQuery.CODMANZANA + entQuery.CODLOTE;
                     string _FN = tempCodigo + "_" + "LOTE" + Guid.NewGuid().ToString() + "." + _Ext;
                     //string _FN = string.Format("{0}{1}.{2}", _Nombre, _Date, _Ext);
                     

                     string _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                     srcQuery.TXTNOMDOCU = _NombreArchivo;
                     srcQuery.TXTNOMDOCUINT = _Ruta;
                     BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                     {
                         TXTNOMTABLA = "SIC_LOTE",
                         CODPKTABLA = tempCodigo,
                         TXTPKTABLANOM = "LOTE",
                         TXTEXTENSION = _Ext,
                         TXTRUTA = _Ruta,
                         FLGPRINCIPAL = "1",
                         CODUSUARIO = VariablesWeb.IdUsuarioIntento
                     };
                     BE.SIC_RETORNO entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Grabar(entQueryDeta);
                     srcQuery.ESTATICO = Lote.Estatico;
                     BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTE().Actualizar(srcQuery);
                     archivo.SaveAs(_Ruta);
                }
                subida = true;
            
            #endregion
            return subida;
        }
        public Nullable<bool> GrabarLoteNuevo(List<SolicitudUnidadViewModel> Lote, int contProceso = 0)
        {
            string tempDistrito = "", tempSector = "", tempManzana = "", tempLote = "";
            string tempEdificacion = "", tempEntrada = "", tempPiso = "", tempUnidad = "";
            string tempTipoDoc = "", tempCodigoSoli = "", tempTipoSoli = "", tempCodigoAno = "";
            string tempReferencia = "", tempTipoLote = "";int tempNumero = 0;
            foreach (SolicitudUnidadViewModel ItemLote in Lote)
            {
                BE.SIC_LOTE entQuery = new BE.SIC_LOTE(){
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                    CODSECTOR = ItemLote.CodigoSector,
                    CODMANZANA = ItemLote.CodigoManzana,
                    CODLOTE = ItemLote.CodigoLote,
                };
                
                
                tempTipoLote = ItemLote.TipoLote;tempNumero = Convert.ToInt32(ItemLote.NumeroLote);
                tempDistrito = ItemLote.CodigoDistrito; tempSector = ItemLote.CodigoSector; tempManzana = ItemLote.CodigoManzana; tempLote = ItemLote.CodigoLote;
                tempEdificacion = ItemLote.Ed; tempEntrada = ItemLote.Entrada; tempPiso = ItemLote.Piso; tempUnidad = ItemLote.Unidad;
                tempCodigoSoli = ItemLote.CodigoNumeroSolicitud; tempTipoSoli = ItemLote.CodigoTipoSolicitud;
                tempReferencia = tempReferencia + "|" + ItemLote.CodigoDistrito + "-" + ItemLote.CodigoSector + "-" + ItemLote.CodigoManzana + "-" + ItemLote.CodigoLote;
                tempTipoDoc = ItemLote.CodigoTipoDocumento;
                tempCodigoAno = ItemLote.CodigoPeriodo;
                BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);
                if (srcQuery == null) { srcQuery = entQuery; }
                srcQuery.ESTADO = "T";
                //BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTE().Actualizar(srcQuery);
                //if (entSIC_RETORNO.Ok == false) contProceso++;
            }
            BE.SIC_SOLUNIDAD entSolUnidad = new BE.SIC_SOLUNIDAD()
            {
                CODNUMESOLI = tempCodigoSoli,
                CODTIPOSOLI = tempTipoSoli,
                CODANOSOLI = tempCodigoAno,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                FLG_TRABAJO = "R"
            };
            if (tempTipoLote != "3") { 
                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLUNIDAD().ActualizarFlag(entSolUnidad);
            }

            BE.SIC_SOLUNIDAD entQueryNuevo = new BE.SIC_SOLUNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = tempSector,
                CODMANZANA = tempManzana,
                CODLOTE = tempLote,
                CODEDIFICACION = "0A", CODENTRADA = "01", CODPISO = "01", CODUNIDAD = "001",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODTIPOSOLI = tempTipoSoli,
                CODNUMESOLI = tempCodigoSoli,
                CODANOSOLI = tempCodigoAno,
                CTIPODOCUMENTO = (tempTipoSoli == "010003") ? "REQI" : tempTipoDoc,
                FLG_TRABAJO = "R",
                CODREFANT = tempReferencia.Substring(1),
            };

            if (tempTipoLote == "1")
            {
                BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
                string path = Path.Combine(@ConfigurationManager.AppSettings["RUTA_CARPETALOTE"], entSIC_RETORNO_NUEVO.CODLOTECATASTRAL);
                Directory.CreateDirectory(path);

            }
            else if (tempTipoLote == "2")
            {
                for (int i = 0; i < tempNumero; i++)
                {
                    BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
                    string path = Path.Combine(@ConfigurationManager.AppSettings["RUTA_CARPETALOTE"], entSIC_RETORNO_NUEVO.CODLOTECATASTRAL);
                    Directory.CreateDirectory(path);

                }
            } else if(tempTipoLote == "3") {
                entQueryNuevo.CODREFANT = "-";
                for (int i = 0; i < tempNumero; i++)
                {
                    BE.SIC_RETORNO entSIC_RETORNO_NUEVO = new BL.SIC_SOLUNIDAD().GrabarNuevo(entQueryNuevo);
                    string path = Path.Combine(@ConfigurationManager.AppSettings["RUTA_CARPETALOTE"], entSIC_RETORNO_NUEVO.CODLOTECATASTRAL);
                    Directory.CreateDirectory(path);
                }
            }

            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> EliminarLoteTemporal(SolicitudUnidadViewModel Lote)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODTIPOSOLI = Lote.CodigoTipoSolicitud,
                CODNUMESOLI = Lote.CodigoNumeroSolicitud,
                CODANOSOLI = DateTime.Now.Year.ToString(),
                CTIPODOCUMENTO = Lote.CodigoTipoDocumento,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_SOLUNIDAD().EliminarNuevo(entQuery);

            if (Convert.ToInt32(Lote.TotalFilas) == 1) {
                BE.SIC_SOLUNIDAD entSolUnidad = new BE.SIC_SOLUNIDAD()
                {
                    CODNUMESOLI = Lote.CodigoNumeroSolicitud,
                    CODTIPOSOLI = Lote.CodigoTipoSolicitud,
                    CODANOSOLI = DateTime.Now.Year.ToString(),
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    FLG_TRABAJO = "T"
                };
                BE.SIC_RETORNO entSIC_RETORNO_FLAG = new BL.SIC_SOLUNIDAD().ActualizarFlag(entSolUnidad);
            }

            return entSIC_RETORNO.Ok;
        }
        //public Nullable<bool> GrabarLoteLinderos(List<LoteLinderosViewModel> Lote, int contProceso = 0)
        //{
        //    foreach (LoteLinderosViewModel ItemLote in Lote)
        //    {
        //        #region Asignar la entidad
        //        BE.SIC_LOTELINDERO entQuery = new BE.SIC_LOTELINDERO();
        //        entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERO>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
        //        entQuery.ESTATICO = ItemLote.Estatico;
        //        entQuery.CODCORRLADO = ItemLote.Codigo;entQuery.CODLADO = ItemLote.CodigoLado;
        //        entQuery.NUMMEDIOFIC = ItemLote.MedidaLadoOfi; entQuery.NUMMEDICAMP = ItemLote.MedidaLadoCam; entQuery.CODTIPOCOLI = ItemLote.CodigoTipoColind;
        //        entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento; entQuery.CODFTELIN = ItemLote.CodigoFuenteCol;
        //        #endregion
        //        //Si el estado es igual 1 se Eliminar, Si se encuentran datos se Actualiza, sino se Graba la información
        //        BE.SIC_RETORNO entSIC_RETORNO;
        //        var eliminar = false;
        //        switch(ItemLote.Estado) {
        //            case "1": entSIC_RETORNO = new BL.SIC_LOTELINDERO().Grabar(entQuery); ItemLote.Codigo = entSIC_RETORNO.CODIGO; break;
        //            case "2": entSIC_RETORNO = new BL.SIC_LOTELINDERO().Actualizar(entQuery); break;
        //            default: entSIC_RETORNO = new BL.SIC_LOTELINDERO().Eliminar(entQuery);eliminar = true; break;
        //        }
        //        #region GRABAR LINDERO COLINDANTE
        //        if (ItemLote.CodigoColindante != null) {
        //            GrabarLoteLinderosColindantes(ItemLote, eliminar);
        //        }
	       //     #endregion
        //        if (entSIC_RETORNO.Ok == false) contProceso++;
        //    }
        //    return (contProceso == 0) ? true : false;
        //}
        public Nullable<bool> GrabarLoteNormaUrbana(List<LoteNormaUrbanaViewModel> Lote, int contProceso = 0)
        {
            foreach (LoteNormaUrbanaViewModel ItemLote in Lote)
            {
                #region Asignar la entidad
                var datosEncontrados = true;
                BE.SIC_LOTENORMAURBANA entQuery = new BE.SIC_LOTENORMAURBANA();
                entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
                entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
                entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
                entQuery.CODSECTOR = ItemLote.CodigoSector; entQuery.CODMANZANA = ItemLote.CodigoManzana; entQuery.CODLOTE = ItemLote.CodigoLote;
                entQuery.ESTATICO = ItemLote.Estatico;
                entQuery.CODCORRMANZVIA = ItemLote.CodManzanaVia; entQuery.CODVIA = ItemLote.CodVia;
                BE.SIC_LOTENORMAURBANA srcQuery = new BL.SIC_LOTENORMAURBANA().Recuperar(entQuery);
                if (srcQuery == null)
                {
                    srcQuery = entQuery;
                    datosEncontrados = false;
                }
                srcQuery.ESTATICO = ItemLote.Estatico;
                srcQuery.TXTALTURA = ItemLote.AlturaVia; srcQuery.TXTZONIFICACION = ItemLote.ZonificacionVia;
                srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                #endregion
                //Si el estado es igual 1 se Eliminar, Si se encuentran datos se Actualiza, sino se Graba la información
                BE.SIC_RETORNO entSIC_RETORNO;
                entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_LOTENORMAURBANA().Actualizar(srcQuery) : new BL.SIC_LOTENORMAURBANA().Grabar(srcQuery);
                if (entSIC_RETORNO.Ok == false)
                {
                    contProceso++;
                }
            }
            return (contProceso == 0) ? true : false;
        }


        public Nullable<bool> GrabarLoteLinderoDetalle(LoteLinderosViewModel ItemLote)
        {
            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            int indice = 1;
            string codcorman = "";
            string codvia = "";


            BE.SIC_LOTELINDEROVIADET entQueryLindero = new BE.SIC_LOTELINDEROVIADET();

            entQueryLindero = JsonConvert.DeserializeObject<BE.SIC_LOTELINDEROVIADET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQueryLindero.CODDEPARTAMENTO = ItemLote.CodigoDepartamento;
            entQueryLindero.CODPROVINCIA = ItemLote.CodigoProvincia;
            entQueryLindero.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryLindero.CODSECTOR = ItemLote.CodigoSector;
            entQueryLindero.CODMANZANA = ItemLote.CodigoManzana;
            entQueryLindero.CODLOTE = ItemLote.CodigoLote;
            entQueryLindero.CODLADO = ItemLote.CodigoLado;
            entQueryLindero.CODCORRLADO = ItemLote.Codigo;
            entQueryLindero.CODTIPOCOLI = ItemLote.CodigoTipoColind;

            if (ItemLote.CodigoTipoColind  == "010002")
            {
                entQueryLindero.CODVIA = null;
                entQueryLindero.CODCORRMANZVIA = null;
                entQueryLindero.CODSECTCOLI = ItemLote.CodigoSector;
                entQueryLindero.CODMANZCOLI = ItemLote.CodigoManzana;
                entQueryLindero.CODLOTECOLI = ItemLote.CodigoVia;                
            }
            else
            {
                var colindante = ItemLote.CodigoVia;

                indice = colindante.IndexOf("-");
                codcorman = colindante.Substring(0, indice);
                codvia = colindante.Substring(indice + 1);

                entQueryLindero.CODCORRMANZVIA = codcorman;
                entQueryLindero.CODVIA = codvia;
                entQueryLindero.CODSECTCOLI = null;
                entQueryLindero.CODMANZCOLI = null;
                entQueryLindero.CODLOTECOLI = null;

            }
            entQueryLindero.ESTATICO = ItemLote.Estatico;
            entQueryLindero.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTELINDERODETALLE().GrabarLoteLinderoDetalle(entQueryLindero);
            return entSIC_RETORNO_COLINDANTE.Ok;
        }

        public BE.SIC_RETORNO GrabarLoteLindero(LoteLinderosViewModel Lote, int contProceso = 0)
        {
            #region Asignar la entidad
            
            BE.SIC_LOTELINDERO entQuery = new BE.SIC_LOTELINDERO();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERO>(JsonConvert.SerializeObject(LlenarEntidad(Lote, true)));
            entQuery.ESTATICO = Lote.Estatico;
            entQuery.CODCORRLADO = Lote.Codigo;
            entQuery.CODLADO = Lote.CodigoLado;
            entQuery.NUMMEDIOFIC = Lote.MedidaLadoOfi;
            entQuery.NUMMEDICAMP = Lote.MedidaLadoCam;
            entQuery.CODALTVIAFOR = Lote.CodigoAlturaVia;
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            entQuery.CODFTELIN = Lote.CodigoFuenteCol;
            #endregion

            //Si el estado es igual 1 se Eliminar, Si se encuentran datos se Actualiza, sino se Graba la información
            BE.SIC_RETORNO entSIC_RETORNO;

            if (Lote.Codigo == "" || Lote.Codigo == null )
            {
                entSIC_RETORNO = new BL.SIC_LOTELINDERODETALLE().GrabarColidante(entQuery);
                Lote.Codigo = entSIC_RETORNO.CODIGO;
            }
            else
            {
                entSIC_RETORNO = new BL.SIC_LOTELINDERODETALLE().ActualizarColidante(entQuery);
                Lote.Codigo = entSIC_RETORNO.CODIGO;
            }

            return entSIC_RETORNO;
        }
        
        public BE.SIC_RETORNO GrabarLoteOtrosDocumentos(LoteOtrosDocumentosViewModel Lote, int contProceso = 0)
        {
            #region Asignar la entidad

            BE.SIC_LOTEOTRODOC entQuery = new BE.SIC_LOTEOTRODOC();
            entQuery.ESTATICO = Lote.Estatico;
            entQuery.CODDISTRITO = Lote.CodigoDistrito;
            entQuery.CODSECTOR = Lote.CodigoSector;
            entQuery.CODMANZANA = Lote.CodigoManzana;
            entQuery.CODLOTE = Lote.CodigoLote;
            entQuery.CODDOCUMENTO = Lote.TipoDocumento;
            entQuery.TXTNRODOCUMENTO = Lote.NroDocumento;
            entQuery.FECDOCUMENTO = Convert.ToDateTime(Lote.FechaDocumento);
            entQuery.TXTOBSERVACION = Lote.Observacion;
            entQuery.CORRELATIVO = Lote.Correlativo;
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;          


            #endregion

            //Si el estado es igual 1 se Eliminar, Si se encuentran datos se Actualiza, sino se Graba la información
            BE.SIC_RETORNO entSIC_RETORNO;

            if (Lote.Correlativo == "" || Lote.Correlativo == null)
            {
                entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().GrabarOtrosDocumentos(entQuery);
                Lote.Correlativo = entSIC_RETORNO.CODIGO;
            }
            else
            {
                entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().ActualizarOtrosDocumentos(entQuery);
                Lote.Correlativo = entSIC_RETORNO.CODIGO;
            }

            return entSIC_RETORNO;
        }
        private Nullable<bool> EliminarLoteLinderosColindantes(LoteLinderosViewModel ItemLote, bool eliminar)
        {
            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_LOTELINDEROVIADET entQueryLindero = new BE.SIC_LOTELINDEROVIADET();
            
            entQueryLindero = JsonConvert.DeserializeObject<BE.SIC_LOTELINDEROVIADET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQueryLindero.CODDEPARTAMENTO = ItemLote.CodigoDepartamento;
            entQueryLindero.CODPROVINCIA = ItemLote.CodigoProvincia;
            entQueryLindero.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryLindero.CODSECTOR = ItemLote.CodigoSector;
            entQueryLindero.CODMANZANA = ItemLote.CodigoManzana;
            entQueryLindero.CODLOTE = ItemLote.CodigoLote;
            entQueryLindero.CODLADO = ItemLote.CodigoLado;
            entQueryLindero.CODCORRLADO = ItemLote.Codigo;
            entQueryLindero.ESTATICO = ItemLote.Estatico;
            entQueryLindero.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTELINDEROVIADET().EliminarColindante(entQueryLindero);


            return entSIC_RETORNO_COLINDANTE.Ok;
        }

        public Nullable<bool> GrabarLoteLinderosColindantes(LoteLinderosViewModel ItemLote, bool Eliminar)
        {
            //BE.SIC_RETORNO entSIC_RETORNO_VIA;

            BE.SIC_RETORNO entSIC_RETORNO_VIA = new BE.SIC_RETORNO();
            entSIC_RETORNO_VIA.Ok = false;



            bool nuevoLinderoVia = false;
            bool nuevoLoteVia = false;
            bool nuevaNorma = false;
            int indice = 1;
            string codcorman = "";
            string codvia = "";

            if (ItemLote.CodigoTipoColind != "010002")
            {
                foreach (var item in ItemLote.ListaCodigoColindante)
                {
                    indice = item.Value.IndexOf("-");
                    codcorman = item.Value.Substring(0, indice);
                    codvia = item.Value.Substring(indice + 1);

                    BE.SIC_VIA srcQueryViaEntidad = new BL.SIC_VIA().Recuperar(new BE.SIC_VIA()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = ItemLote.CodigoDistrito,
                        CODVIA = codvia
                    });

                    #region Asignar la entidad LinderoVia
                    BE.SIC_LOTELINDEROVIADET entQueryVia = new BE.SIC_LOTELINDEROVIADET();
                    entQueryVia = JsonConvert.DeserializeObject<BE.SIC_LOTELINDEROVIADET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                    entQueryVia.ESTATICO = ItemLote.Estatico;
                    entQueryVia.CODLADO = ItemLote.CodigoLado;
                    entQueryVia.CODCORRLADO = ItemLote.Codigo;
                    entQueryVia.CODCORRMANZVIA = codcorman;
                    entQueryVia.CODVIA = codvia;
                    #endregion

                    BE.SIC_LOTELINDEROVIADET srcQueryVia = new BL.SIC_LOTELINDEROVIADET().Recuperar(entQueryVia);
                    #region Recuperar ManzanaVia
                    BE.SIC_MANZANAVIA entQueryManzanaVia = new BE.SIC_MANZANAVIA();
                    entQueryManzanaVia = JsonConvert.DeserializeObject<BE.SIC_MANZANAVIA>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, false)));
                    entQueryManzanaVia.CODVIA = codvia;
                    entQueryManzanaVia.CODCORRMANZVIA = codcorman;
                    BE.SIC_MANZANAVIA srcQueryMzVia = new BL.SIC_MANZANAVIA().Recuperar(entQueryManzanaVia);
                    #endregion

                    #region RecuperarLoteVia
                    BE.SIC_LOTEVIA entQueryLoteVia = new BE.SIC_LOTEVIA();
                    entQueryLoteVia = JsonConvert.DeserializeObject<BE.SIC_LOTEVIA>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                    entQueryLoteVia.ESTATICO = ItemLote.Estatico;
                    entQueryLoteVia.CODCORRMANZVIA = codcorman;
                    entQueryLoteVia.CODVIA = codvia;
                    BE.SIC_LOTEVIA srcQueryLoteVia = new BL.SIC_LOTEVIA().Recuperar(entQueryLoteVia);
                    #endregion

                    #region RecuperarNormaUrbana
                    BE.SIC_LOTENORMAURBANA entQueryNorma = new BE.SIC_LOTENORMAURBANA();
                    entQueryNorma = JsonConvert.DeserializeObject<BE.SIC_LOTENORMAURBANA>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                    entQueryNorma.CODVIA = codvia; entQueryNorma.CODCORRMANZVIA = codcorman;
                    entQueryNorma.ESTATICO = ItemLote.Estatico;
                    BE.SIC_LOTENORMAURBANA srcQueryNorma = new BL.SIC_LOTENORMAURBANA().Recuperar(entQueryNorma);
                    if (srcQueryNorma == null) { srcQueryNorma = entQueryNorma; nuevaNorma = true; }
                    if (srcQueryMzVia != null)
                    {
                        srcQueryNorma.NUMALTURA = srcQueryMzVia.NUMALTURA;
                        srcQueryNorma.TXTOBSERVACION = srcQueryMzVia.TXTOBSERVACION;
                    }
                    #endregion
                    if (ItemLote.CodigoViaAnterior != null && ItemLote.CodigoTipoColindante2 == "010002")
                    {
                        BE.SIC_LOTELINDERODET entQueryViaLote = new BE.SIC_LOTELINDERODET();
                        entQueryViaLote = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERODET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                        entQueryViaLote.CODLADO = ItemLote.CodigoLado; entQueryViaLote.CODCORRLADO = ItemLote.Codigo;
                        entQueryViaLote.ESTATICO = ItemLote.Estatico;
                        BE.SIC_LOTELINDERODET srcQueryViaLote = new BL.SIC_LOTELINDERODET().Recuperar(entQueryViaLote);
                        entSIC_RETORNO_VIA = new BL.SIC_LOTELINDERODET().Eliminar(srcQueryViaLote);
                    }
                    else if (ItemLote.CodigoViaAnterior != null)
                    {
                        if (ItemLote.CodigoColindante != ItemLote.CodigoViaAnterior || Eliminar == true)
                        {
                            int indiceDel = ItemLote.CodigoViaAnterior.IndexOf("-");
                            string codcormanDel = ItemLote.CodigoViaAnterior.Substring(0, indice);
                            string codviaDel = ItemLote.CodigoViaAnterior.Substring(indice + 1);
                            BE.SIC_LOTELINDEROVIADET entQueryViaDel = new BE.SIC_LOTELINDEROVIADET();
                            entQueryViaDel = JsonConvert.DeserializeObject<BE.SIC_LOTELINDEROVIADET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                            entQueryViaDel.CODLADO = ItemLote.CodigoLado;
                            entQueryViaDel.CODCORRMANZVIA = codcormanDel; entQueryViaDel.CODVIA = codviaDel;
                            entQueryViaDel.ESTATICO = ItemLote.Estatico;
                            IEnumerable<BE.SIC_LOTELINDEROVIADET> srcQueryListViaDel = new BL.SIC_LOTELINDEROVIADET().Buscar(entQueryViaDel);
                            int totalFilas = srcQueryListViaDel.Count();
                            if (totalFilas == 1)
                            {
                                entQueryViaDel.CODCORRLADO = ItemLote.Codigo;
                                entQueryViaDel.ESTATICO = ItemLote.Estatico;
                                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTELINDEROVIADET().Eliminar(entQueryViaDel);

                                BE.SIC_LOTEVIA entQueryLoteViaDel = new BE.SIC_LOTEVIA();
                                entQueryLoteViaDel = JsonConvert.DeserializeObject<BE.SIC_LOTEVIA>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                                entQueryLoteViaDel.CODVIA = codviaDel; entQueryLoteViaDel.CODCORRMANZVIA = codcormanDel;
                                entQueryLoteViaDel.ESTATICO = ItemLote.Estatico;
                                BE.SIC_RETORNO entSIC_RETORNOLV = new BL.SIC_LOTEVIA().Eliminar(entQueryLoteViaDel);

                                BE.SIC_LOTENORMAURBANA entQueryNormaDel = new BE.SIC_LOTENORMAURBANA();
                                entQueryNormaDel = JsonConvert.DeserializeObject<BE.SIC_LOTENORMAURBANA>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                                entQueryNormaDel.ESTATICO = ItemLote.Estatico;
                                entQueryNormaDel.CODVIA = codviaDel; entQueryNormaDel.CODCORRMANZVIA = codcormanDel;
                                BE.SIC_RETORNO entSIC_RETORNONU = new BL.SIC_LOTENORMAURBANA().Eliminar(entQueryNormaDel);
                            }
                        }
                    }

                    if (srcQueryVia == null)
                    {
                        srcQueryVia = entQueryVia; nuevoLinderoVia = true;
                    }
                    if (srcQueryLoteVia == null) { srcQueryLoteVia = entQueryLoteVia; nuevoLoteVia = true; }

                    srcQueryVia.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    srcQueryVia.FLAGPARQUE = "0";
                    srcQueryVia.FLAGAVE = "0";
                    if (srcQueryViaEntidad.CODTIPOVIA == "010031")
                        srcQueryVia.FLAGPARQUE = "1";
                    else if (srcQueryViaEntidad.CODTIPOVIA == "010007")
                        srcQueryVia.FLAGAVE = "1";
                    srcQueryLoteVia.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    srcQueryNorma.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    srcQueryVia.ESTATICO = ItemLote.Estatico;
                    srcQueryLoteVia.ESTATICO = ItemLote.Estatico;
                    srcQueryNorma.ESTATICO = ItemLote.Estatico;
                    srcQueryVia.CODALTVIAFOR = ItemLote.CodigoAlturaVia;
                    entSIC_RETORNO_VIA = (nuevoLinderoVia == false) ? new BL.SIC_LOTELINDEROVIADET().Actualizar(srcQueryVia) : new BL.SIC_LOTELINDEROVIADET().Grabar(srcQueryVia);
                    entSIC_RETORNO_VIA = (nuevoLoteVia == false) ? new BL.SIC_LOTEVIA().Actualizar(srcQueryLoteVia) : new BL.SIC_LOTEVIA().Grabar(srcQueryLoteVia);
                    entSIC_RETORNO_VIA = (nuevaNorma == false) ? new BL.SIC_LOTENORMAURBANA().Actualizar(srcQueryNorma) : new BL.SIC_LOTENORMAURBANA().Grabar(srcQueryNorma);
                }
            }
            else
            {
                foreach (var item in ItemLote.ListaCodigoColindante)
                {
                    var CodigoLote = item.Value.ToString();

                    #region Asignar la entidad LinderoDet
                    BE.SIC_LOTELINDERODET entQueryVia = new BE.SIC_LOTELINDERODET();
                    entQueryVia = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERODET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
                    entQueryVia.CODLADO = ItemLote.CodigoLado;
                    entQueryVia.CODCORRLADO = ItemLote.Codigo;
                    entQueryVia.ESTATICO = ItemLote.Estatico;
                    entQueryVia.CODLOTECOLI = CodigoLote;



                    //entQueryVia.CODCORRMANZVIA = codcorman; entQueryVia.CODVIA = codvia;
                    #endregion
                    BE.SIC_LOTELINDERODET srcQueryVia = new BL.SIC_LOTELINDERODET().Recuperar(entQueryVia);
                    if (srcQueryVia == null)
                    {
                        srcQueryVia = entQueryVia;
                        nuevoLinderoVia = true;
                    }
                    srcQueryVia.CODSECTCOLI = ItemLote.CodigoSector;
                    srcQueryVia.CODMANZCOLI = ItemLote.CodigoManzana;
                    srcQueryVia.CODLOTECOLI = CodigoLote;
                    srcQueryVia.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    srcQueryVia.ESTATICO = ItemLote.Estatico;

                    entSIC_RETORNO_VIA = (nuevoLinderoVia == false) ? new BL.SIC_LOTELINDERODET().Actualizar(srcQueryVia) : new BL.SIC_LOTELINDERODET().Grabar(srcQueryVia);
                }
            }
            return entSIC_RETORNO_VIA.Ok;
        }
        public Nullable<bool> GrabarLoteDirecMunicipal(RegistrarDirecMunicipalViewModel ItemLote)
        {
            int indice1 = ItemLote.CodigoVia.IndexOf("-"); int indice2 = ItemLote.CodigoVia.IndexOf("_"); int indice3 = ItemLote.CodigoVia.IndexOf("|");
            string codcorman = ItemLote.CodigoVia.Substring(0, indice1); string codvia = ItemLote.CodigoVia.Substring(indice1 + 1, (indice2-indice1-1));
            string codcormanant = (ItemLote.CodigoViaAnt != null) ? ItemLote.CodigoViaAnt.Substring(0, indice1) : "";
            string codviaant = (ItemLote.CodigoViaAnt != null) ? ItemLote.CodigoViaAnt.Substring(indice1 + 1, (indice2 - indice1 - 1)) : "";
            string numcuadra = ItemLote.CodigoVia.Substring(indice2 + 1, (indice3-indice2-1)); string codlado = ItemLote.CodigoVia.Substring(indice3 + 1);

            #region Asignar la entidad
            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = ItemLote.CodigoDistrito; entQuery.CODSECTOR = ItemLote.CodigoSector; entQuery.CODMANZANA = ItemLote.CodigoManzana; entQuery.CODLOTE = ItemLote.CodigoLote;
            entQuery.CODCORRMANZVIA = codcorman; entQuery.CODVIA = codvia; entQuery.CODCORRUNIDDIREMUNI = ItemLote.Codigo; entQuery.CODTIPOASIG = ItemLote.CodigoAsignacion;
            entQuery.CODTIPOEDIF = ItemLote.TipoEdificacion; entQuery.CODTIPOPUER = ItemLote.CodigoTipoPuerta; entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento; 
            entQuery.TXTLETRA = ItemLote.LetraPuerta; entQuery.TXTNUMEDIF = ItemLote.NumTipoEdificacion; entQuery.TXTNUMERO = ItemLote.NumeroPuerta;
            entQuery.NUMCUADRA = Convert.ToInt32(numcuadra); entQuery.CODLADO = codlado;
            entQuery.ESTATICO = ItemLote.Estatico;
            #endregion
            BE.SIC_RETORNO entSIC_RETORNO;
            if (ItemLote.Estado == "2") {
                if (codvia == codviaant || entQuery.ESTATICO == false)
                {
                    entSIC_RETORNO = new BL.SIC_LOTEDIRECMUNI().Actualizar(entQuery);
                }
                else {
                    entQuery.CODVIAANT = codviaant;
                    entQuery.CODCORRMANZVIAANT = codcormanant; 
                    entSIC_RETORNO = new BL.SIC_LOTEDIRECMUNI().ActualizarMod(entQuery);
                }
                
            } else {
                entSIC_RETORNO = new BL.SIC_LOTEDIRECMUNI().Grabar(entQuery);
            }
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> GrabarLoteRetiroMunicipal(RegistrarRetiroMunicipalViewModel ItemLote)
        {
            int indice1 = ItemLote.CodigoVia.IndexOf("-"); int indice2 = ItemLote.CodigoVia.IndexOf("_");
            string codcorman = ItemLote.CodigoVia.Substring(0, indice1); string codvia = ItemLote.CodigoVia.Substring(indice1 + 1, (indice2 - indice1 - 1));
            string numcuadra = ItemLote.CodigoVia.Substring(indice2 + 1);

            BE.SIC_VIADETALLE entQueryVia = new BE.SIC_VIADETALLE();
            entQueryVia.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'); entQueryVia.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQueryVia.CODDISTRITO = ItemLote.CodigoDistrito; entQueryVia.CODVIA = codvia; entQueryVia.NUMCUADRA = Convert.ToInt32(numcuadra);
            
            BE.SIC_VIADETALLE srcQueryVia = new BL.SIC_VIADETALLE().Retiro(entQueryVia);
            var detalle = (srcQueryVia != null) ? srcQueryVia.NUMANCHVIA : 0;
            //if (ItemLote.RetiroCampo > detalle || ItemLote.JardinAislamOfi > detalle || (ItemLote.RetiroCampo + ItemLote.JardinAislamOfi) > detalle)
            //{
            //    return false;
            //}
            //else {
                #region Asignar la entidad
                BE.SIC_LOTERETIRO entQuery = new BE.SIC_LOTERETIRO();
                entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'); entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
                entQuery.CODDISTRITO = ItemLote.CodigoDistrito; entQuery.CODSECTOR = ItemLote.CodigoSector; entQuery.CODMANZANA = ItemLote.CodigoManzana; entQuery.CODLOTE = ItemLote.CodigoLote;
                entQuery.CODCORRMANZVIA = codcorman; entQuery.CODVIA = codvia; entQuery.CODCORRLOTERETI = ItemLote.Codigo;
                entQuery.NUMJARDAISL = ItemLote.JardinAislamOfi; entQuery.NUMRETIMUNI = ItemLote.RetiroCampo;
                entQuery.FLGOCUPRETI = ItemLote.OcupacionRetiro; entQuery.FLGOCUPJARD = ItemLote.OcupacionJardin;
                entQuery.CODDESCRETI = ItemLote.DescripcionRetiro; entQuery.CODDESCJARD = ItemLote.DescripcionJardin;
                entQuery.ESTATICO = ItemLote.Estatico;
                entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                #endregion
                BE.SIC_RETORNO entSIC_RETORNO = (ItemLote.Estado == "2") ? new BL.SIC_LOTERETIRO().Actualizar(entQuery) : new BL.SIC_LOTERETIRO().Grabar(entQuery);
                return entSIC_RETORNO.Ok;
            //}
        }
        public Nullable<bool> GrabarLoteDocumentoRRPP(LoteDocumentosRRPPViewModel ItemLote, out string correlativo)
        {
            int contProceso = 0;
            BE.SIC_RETORNO entSIC_RETORNO;
            var datosEncontrados = true;                
            BE.SIC_LOTERRPP entQuery = new BE.SIC_LOTERRPP()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = ItemLote.CodigoDistrito,
                CODSECTOR = ItemLote.CodigoSector,
                CODMANZANA = ItemLote.CodigoManzana,
                CODLOTE = ItemLote.CodigoLote,
                CODCORRLOTERRPP = ItemLote.Codigo,
                ESTATICO = ItemLote.Estatico
            };
            BE.SIC_LOTERRPP srcQuery = new BL.SIC_LOTERRPP().Recuperar(entQuery);
            if (srcQuery == null)
            {
                srcQuery = entQuery;
                datosEncontrados = false;
            }
            srcQuery.CODTIPODOCU = ItemLote.CodigoDocumento;
            if (ItemLote.Fecha != null) srcQuery.FECDOCUMENTO = DateTime.Parse(ItemLote.Fecha);
            srcQuery.TXTTOMOFICH = ItemLote.TomoFicha;
            srcQuery.TXTPARTELEC = ItemLote.PartidaElectronica;
            srcQuery.TXTFOLIO = ItemLote.Folio; ;
            srcQuery.TXTASIENTO = ItemLote.Asiento;
            srcQuery.ESTATICO = ItemLote.Estatico;
            srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            var cont = 0;
            if (ItemLote.CodigoDocumento != null) cont++;
            if (ItemLote.PartidaElectronica != null) cont++;
            if (ItemLote.TomoFicha != null) cont++;
            if (ItemLote.Folio != null) cont++;
            if (ItemLote.Asiento != null) cont++;

            //Eliminar, actualizar o grabar
            if (cont > 0 )
            {
                entSIC_RETORNO = (ItemLote.Estado == "1") ? new BL.SIC_LOTERRPP().Eliminar(srcQuery) : (datosEncontrados == true) ? new BL.SIC_LOTERRPP().Actualizar(srcQuery) : new BL.SIC_LOTERRPP().Grabar(srcQuery);
                correlativo = (entSIC_RETORNO.CODIGO != null) ? entSIC_RETORNO.CODIGO : srcQuery.CODCORRLOTERRPP;
                
            }
            else {
                entSIC_RETORNO = new BE.SIC_RETORNO();
                correlativo = "";
                
            }
            return entSIC_RETORNO.Ok;
        }
        public string BuscarRutaDocumentoRRPP(LoteDocumentosRRPPViewModel ItemLote) {
            BE.SIC_LOTERRPP entQuery = new BE.SIC_LOTERRPP()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = ItemLote.CodigoDistrito,
                CODSECTOR = ItemLote.CodigoSector,
                CODMANZANA = ItemLote.CodigoManzana,
                CODLOTE = ItemLote.CodigoLote,
                CODCORRLOTERRPP = ItemLote.Codigo,
                ESTATICO = ItemLote.Estatico
            };
            BE.SIC_LOTERRPP srcQuery = new BL.SIC_LOTERRPP().Recuperar(entQuery);
            if (srcQuery == null) {
                srcQuery = new BE.SIC_LOTERRPP();
            }
            return srcQuery.TXTNOMDOCUINT;
        }
        
        public string DescargarOtrosDocumento(LoteOtrosDocumentosViewModel ItemLote)
        {
            BE.SIC_LOTEOTRODOC entQuery = new BE.SIC_LOTEOTRODOC()
            {
                CODDISTRITO = ItemLote.CodigoDistrito,
                CODSECTOR = ItemLote.CodigoSector,
                CODMANZANA = ItemLote.CodigoManzana,
                CODLOTE = ItemLote.CodigoLote,
                CORRELATIVO = ItemLote.Correlativo,
                ESTATICO = ItemLote.Estatico
            };
            BE.SIC_LOTEOTRODOC srcQuery = new BL.SIC_LOTEOTRODOC().DescargarOtrosDocumento(entQuery);
            if (srcQuery == null)
            {
                srcQuery = new BE.SIC_LOTEOTRODOC();
            }
            return srcQuery.TXTRUTAPDF;
        }

        public Nullable<bool> GrabarLoteDocumentoRRPPImagen(LoteDocumentosRRPPViewModel Lote, out string correlativo)
        {
            BE.SIC_LOTERRPP entQuery = new BE.SIC_LOTERRPP()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODCORRLOTERRPP = Lote.Codigo,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTERRPP srcQuery = new BL.SIC_LOTERRPP().Recuperar(entQuery);

            #region Subir archivo
            var archivo = Lote.Archivo;
            //string repo = "REPOSIC"; string anio = DateTime.Now.Year.ToString(); string mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string repo = "DOCUMENTOS"; string tiporepo = "LOTE\\RRPP";
            string carpeta = "\\" + repo + "\\" + tiporepo; ;
            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                if (archivo != null)
                {
                    string _NombreArchivo = Path.GetFileName(archivo.FileName);
                    string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                    string _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                    _Ext = _Ext.Substring(1);
                    string _FN = string.Format("{0}{1}.{2}", _Nombre, _Date, _Ext);

          //      @ConfigurationManager.AppSettings["RUTA_FOTOS"]


                    string _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                    srcQuery.TXTNOMDOCU = string.Format("{0}{1}", _Nombre, _Date);
                    srcQuery.TXTNOMDOCUINT = _Ruta;
                    srcQuery.ESTATICO = Lote.Estatico;
                    BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTERRPP().Actualizar(srcQuery);
                    correlativo = Lote.Codigo;
                    subida = true;
                    archivo.SaveAs(_Ruta);
                }
                else {
                    correlativo = null;
                    subida = false;
                }
            
            #endregion
            return subida;
        }
  
        public Nullable<bool> GrabarLoteOtroDocumentoRRPPImagen(LoteOtrosDocumentosViewModel Lote, out string correlativo)
        {
            BE.SIC_LOTEOTRODOC entQuery = new BE.SIC_LOTEOTRODOC()
            {
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CORRELATIVO = Lote.Correlativo,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_LOTEOTRODOC srcQuery = new BL.SIC_LOTEOTRODOC().DescargarOtrosDocumento(entQuery);


            #region Subir archivo
            var archivo = Lote.Archivo;

            string repo = "DOCUMENTOS"; string tiporepo = "LOTE\\DOCADICIONAL";
            string carpeta = "\\" + repo + "\\" + tiporepo; ;

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;

            if (archivo != null)
            {
                string _NombreArchivo = Path.GetFileName(archivo.FileName);
                string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                string _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                _Ext = _Ext.Substring(1);
                string _FN = string.Format("{0}{1}.{2}", _Nombre, _Date, _Ext);

                //      @ConfigurationManager.AppSettings["RUTA_FOTOS"]


                string _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                srcQuery.TXTPDF = string.Format("{0}{1}", _Nombre, _Date);
                srcQuery.TXTRUTAPDF = _Ruta;
                srcQuery.ESTATICO = Lote.Estatico;

                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().ActualizarPDFOtrosDocumentos(srcQuery);
                correlativo = Lote.Codigo;
                subida = true;
                archivo.SaveAs(_Ruta);
            }
            else
            {
                correlativo = null;
                subida = false;
            }

            #endregion
            return subida;
        }
        public Nullable<bool> GrabarLoteDocumento(List<LoteDocumentosViewModel> Lote)
        {
            int contProceso = 0;
            if (Lote != null)
            {
                foreach (LoteDocumentosViewModel ItemLote in Lote)
                {
                    var datosEncontrados = true;
                    BE.SIC_LOTEEXPEDOCU entQuery = new BE.SIC_LOTEEXPEDOCU()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = ItemLote.CodigoDistrito,
                        CODSECTOR = ItemLote.CodigoSector,
                        CODMANZANA = ItemLote.CodigoManzana,
                        CODLOTE = ItemLote.CodigoLote,
                        CODCORRLOTEEXPEDOCU = ItemLote.Correlativo,
                        ESTATICO = ItemLote.Estatico
                    };
                    BE.SIC_LOTEEXPEDOCU srcQuery = new BL.SIC_LOTEEXPEDOCU().Recuperar(entQuery);
                    if (srcQuery == null)
                    {
                        srcQuery = entQuery;
                        datosEncontrados = false;
                    }
                    if(ItemLote.Fecha != null ) {
                        srcQuery.FECDOCUMENTO =  DateTime.Parse(ItemLote.Fecha);
                    }
                    srcQuery.TXTOBSERVACION = ItemLote.Detalle;
                    srcQuery.TXTSOLICITANTE = ItemLote.Solicitante;
                    srcQuery.CODTIPODOCU = ItemLote.Documento;
                    srcQuery.TXTNUMERO = ItemLote.Numero;
                    srcQuery.FLGINTEXT = ItemLote.Flag;
                    srcQuery.CODSOLICITANTE = ItemLote.CodSoli;
                    srcQuery.TXTIDTRAMITEDOC = ItemLote.Codigo;
                    srcQuery.ESTATICO = ItemLote.Estatico;
                    srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    BE.SIC_RETORNO entSIC_RETORNO;
                    //entSIC_RETORNO = new BL.SIC_LOTEEXPEDOCU().Eliminar(srcQuery);
                    entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_LOTEEXPEDOCU().Actualizar(srcQuery) : new BL.SIC_LOTEEXPEDOCU().Grabar(srcQuery);
                    if (entSIC_RETORNO.Ok == false)
                    {
                        contProceso++;
                    }
                }
            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> GrabarLoteObras(List<LicenciaEdificacionViewModel> Lote)
        {
            int contProceso = 0; int indice = 0;
            if (Lote != null)
            {
                foreach (LicenciaEdificacionViewModel ItemLote in Lote)
                {
                    BE.SIC_LOTEAUTOEDIF entQuery = new BE.SIC_LOTEAUTOEDIF()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = ItemLote.CodigoDistrito,
                        CODSECTOR = ItemLote.CodigoSector,
                        CODMANZANA = ItemLote.CodigoManzana,
                        CODLOTE = ItemLote.CodigoLote,
                        ESTATICO = ItemLote.Estatico
                    };
                    if (indice == 0)
                    {
                        BE.SIC_RETORNO entSIC_RETORNODEL = new BL.SIC_LOTEAUTOEDIF().EliminarLote(entQuery);
                    }
                    entQuery.TXTSOLICITANTE = ItemLote.Solicitante;
                    entQuery.TXTBENEFICIARIO = ItemLote.Beneficiario;
                    entQuery.TXTTIPOOBRA = ItemLote.TipoObra;
                    entQuery.TXTNUMLICENCIA = ItemLote.NumeroLicencia;
                    entQuery.FECLICENCIA = DateTime.Parse(ItemLote.FechaLicencia);
                    entQuery.TXTCODUNICO = ItemLote.Codigo;
                    entQuery.ESTATICO = ItemLote.Estatico;
                    entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTEAUTOEDIF().Grabar(entQuery);
                    if (entSIC_RETORNO.Ok == false)
                    {
                        contProceso++;
                    }
                    indice++;
                }
            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> GrabarLoteLicencias(List<LicenciaViewModel> Lote)
        {
            int contProceso = 0; int indice = 0;
            if (Lote != null) { 
                foreach (LicenciaViewModel ItemLote in Lote)
                {
                
                    BE.SIC_LOTEAUTOLICE entQuery = new BE.SIC_LOTEAUTOLICE()
                    {
                        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                        CODDISTRITO = ItemLote.CodigoDistrito,
                        CODSECTOR = ItemLote.CodigoSector,
                        CODMANZANA = ItemLote.CodigoManzana,
                        CODLOTE = ItemLote.CodigoLote,
                        ESTATICO = ItemLote.Estatico
                    };
                    if (indice == 0) {
                        BE.SIC_RETORNO entSIC_RETORNODEL = new BL.SIC_LOTEAUTOLICE().EliminarLote(entQuery);
                    }
                    entQuery.TXTSOLICITANTE = ItemLote.Solicitante;
                    entQuery.TXTBENEFICIARIO = ItemLote.Beneficiario;
                    entQuery.TXTTIPOLICENCIA = ItemLote.TipoLicencia;
                    entQuery.TXTNUMLICENCIA = ItemLote.NumeroLicencia;
                    entQuery.TXTGIRO = ItemLote.Giros;
                    entQuery.CODGIRO = ItemLote.CodGiro;
                    entQuery.FECLICENCIA = DateTime.Parse(ItemLote.FechaLicencia);
                    entQuery.TXTCODUNICO = ItemLote.Codigo;
                    entQuery.ESTATICO = ItemLote.Estatico;
                    entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTEAUTOLICE().Grabar(entQuery);
                    if (entSIC_RETORNO.Ok == false)
                    {
                        contProceso++;
                    }
                    indice++;
                }
            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> GrabarLoteObservacion(List<LoteObservacionViewModel> Lote)
        {
            int contProceso = 0;
            foreach (LoteObservacionViewModel ItemLote in Lote)
            {
                var datosEncontrados = true;
                BE.SIC_LOTEOBSERVACION entQuery = new BE.SIC_LOTEOBSERVACION()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = ItemLote.CodigoDistrito,
                    CODSECTOR = ItemLote.CodigoSector,
                    CODMANZANA = ItemLote.CodigoManzana,
                    CODLOTE = ItemLote.CodigoLote,
                    CODCORROBSE = ItemLote.Codigo,
                    ESTATICO = ItemLote.Estatico
                };
                BE.SIC_LOTEOBSERVACION srcQuery = new BL.SIC_LOTEOBSERVACION().Recuperar(entQuery);
                if (srcQuery == null) {
                    srcQuery = entQuery;
                    datosEncontrados = false;
                }
                if(ItemLote.Fecha != null) srcQuery.FECOBSERVACION = DateTime.Parse(ItemLote.Fecha);
                srcQuery.TXTOBSERVACION = ItemLote.Detalle;
                srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                srcQuery.ESTATICO = ItemLote.Estatico;
                BE.SIC_RETORNO entSIC_RETORNO;
                if (ItemLote.Estado == "1")
                {
                    entSIC_RETORNO =  new BL.SIC_LOTEOBSERVACION().Eliminar(srcQuery);
                }
                else {
                    if (srcQuery.TXTOBSERVACION != null)
                    {
                        entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_LOTEOBSERVACION().Actualizar(srcQuery) : new BL.SIC_LOTEOBSERVACION().Grabar(srcQuery);
                    }
                    else {
                        entSIC_RETORNO = new BE.SIC_RETORNO();
                    }
                }
                
                if (entSIC_RETORNO.Ok == false)
                {
                    contProceso++;
                }
            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> GrabarZonifLote(List<ZonifLoteViewModel> Lote)
        {
            int contProceso = 0;
            foreach (ZonifLoteViewModel ItemLote in Lote)
            {
                var datosEncontrados = true;
                BE.SIC_ZONIFLOTE entQuery = new BE.SIC_ZONIFLOTE()
                {
                    CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                    CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                    CODDISTRITO = ItemLote.CodigoDistrito,
                    CODSECTOR = ItemLote.CodigoSector,
                    CODMANZANA = ItemLote.CodigoManzana,
                    CODLOTE = ItemLote.CodigoLote,
                    CODZONIFICACION = ItemLote.Codigo,
                    ESTATICO = ItemLote.Estatico,
                };
                BE.SIC_ZONIFLOTE srcQuery = new BL.SIC_ZONIFLOTE().Recuperar(entQuery);
                if (srcQuery == null)
                {
                    srcQuery = entQuery;
                    datosEncontrados = false;
                }
                srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                srcQuery.ESTATICO = ItemLote.Estatico;
                BE.SIC_RETORNO entSIC_RETORNO;
                if (ItemLote.Estado == "1")
                {
                    entSIC_RETORNO = new BL.SIC_ZONIFLOTE().Eliminar(srcQuery);
                }
                else
                {
                    entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_ZONIFLOTE().Actualizar(srcQuery) : new BL.SIC_ZONIFLOTE().Grabar(srcQuery);
                }

                if (entSIC_RETORNO.Ok == false)
                {
                    contProceso++;
                }
            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> ProcesarHabilitacion(RegistrarHabilitacionViewModel Habilitacion)
        {
            #region Asignar a la Entidad
            BE.SIC_LOTEHABIURBA entQuery = new BE.SIC_LOTEHABIURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Habilitacion.CodigoDistrito,
                CODMANZANA = Habilitacion.CodigoManzana,
                CODSECTOR = Habilitacion.CodigoSector,
                CODLOTE = Habilitacion.CodigoLote,
                CODHABURBA = Habilitacion.CodigoHabilitacionUrbana,
                CODMANZURB = Habilitacion.CodigoManzanaUrbana,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_LOTEHABIURBA srcQuery = new BL.SIC_LOTEHABIURBA().Recuperar(entQuery);
            entQuery.ESTATICO = Habilitacion.ModalEstatico;
            #endregion
            BE.SIC_RETORNO entSIC_RETORNO;
            //entSIC_RETORNO = (Habilitacion.Estado == "2") ? new BL.SIC_LOTEHABIURBA().Actualizar(entQuery) : new BL.SIC_LOTEHABIURBA().Grabar(entQuery);
            entSIC_RETORNO = (srcQuery != null) ? new BL.SIC_LOTEHABIURBA().Actualizar(entQuery) : new BL.SIC_LOTEHABIURBA().Grabar(entQuery);
            return entSIC_RETORNO.Ok;

        }

        
        public Nullable<bool> EliminarHabilitacion(RegistrarHabilitacionViewModel Lote)
        {
            BE.SIC_LOTEHABIURBA entQuery = new BE.SIC_LOTEHABIURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODMANZURB = Lote.CodigoManzanaUrbana,
                CODHABURBA = Lote.CodigoHabilitacionUrbana,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                ESTATICO = Lote.Estatico
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTEHABIURBA().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> EliminarLindero(LoteLinderosViewModel ItemLote)
        {

            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_LOTELINDEROVIADET entQueryLindero = new BE.SIC_LOTELINDEROVIADET();

            entQueryLindero = JsonConvert.DeserializeObject<BE.SIC_LOTELINDEROVIADET>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQueryLindero.CODDEPARTAMENTO = ItemLote.CodigoDepartamento;
            entQueryLindero.CODPROVINCIA = ItemLote.CodigoProvincia;
            entQueryLindero.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryLindero.CODSECTOR = ItemLote.CodigoSector;
            entQueryLindero.CODMANZANA = ItemLote.CodigoManzana;
            entQueryLindero.CODLOTE = ItemLote.CodigoLote;
            entQueryLindero.CODLADO = ItemLote.CodigoLado;
            entQueryLindero.CODCORRLADO = ItemLote.Codigo;
            entQueryLindero.ESTATICO = ItemLote.Estatico;
            entQueryLindero.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTELINDEROVIADET().EliminarColindante(entQueryLindero);


            return entSIC_RETORNO_COLINDANTE.Ok;

        }
        public Nullable<bool> EliminarDetalleLindero(LoteLinderosViewModel Lote)
        {
            int indice = 1;
            string codcorman = "";
            string codvia = "";

            BE.SIC_LOTELINDERODET entQuery = new BE.SIC_LOTELINDERODET();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTELINDERODET>(JsonConvert.SerializeObject(LlenarEntidad(Lote, true)));
            entQuery.ESTATICO = Lote.Estatico;
            entQuery.CODDEPARTAMENTO = Lote.CodigoDepartamento;
            entQuery.CODPROVINCIA = Lote.CodigoProvincia;
            entQuery.CODDISTRITO = Lote.CodigoDistrito;
            entQuery.CODSECTOR = Lote.CodigoSector;
            entQuery.CODMANZANA = Lote.CodigoManzana;
            entQuery.CODLOTE = Lote.CodigoLote;
            entQuery.CODCORRLADO = Lote.Codigo;
            entQuery.CODLADO = Lote.CodigoLado;
            entQuery.CODTIPOCOLI = Lote.CodigoTipoColind;
            entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            entQuery.CORRELATIVO = Lote.Correlativo;


            entQuery.CODVIA = Lote.CodigoVia;
            entQuery.CODCORMANZANA = Lote.CodigoCorManzana;
           
            

            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTELINDERODETALLE().EliminarDetalleLindero(entQuery);

            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> EliminarMunicipalDirec(RegistrarDirecMunicipalViewModel Lote)
        {
            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODVIA = Lote.CodigoVia,
                CODCORRMANZVIA = Lote.CodigoManzanaVia,
                CODCORRUNIDDIREMUNI = Lote.Codigo,
                ESTATICO = Lote.Estatico,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTEDIRECMUNI().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> EliminarRetiroMunicipal(RegistrarRetiroMunicipalViewModel Lote)
        {
            BE.SIC_LOTERETIRO entQuery = new BE.SIC_LOTERETIRO()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODVIA = Lote.CodigoVia,
                CODCORRMANZVIA = Lote.CodigoManzanaVia,
                CODCORRLOTERETI = Lote.Codigo,
                ESTATICO = Lote.Estatico,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_LOTERETIRO().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }

        #endregion
        
        #region LISTAR COMBOS

        public List<SelectListItem> ListarColindanteSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA(); entQuery = JsonConvert.DeserializeObject<BE.SIC_MANZANAVIA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, false)));
            entQuery.PARQUE = FiltrarSolUnidad.Ubicacion;
            IEnumerable<BE.SIC_MANZANAVIA> lisQuery = new BL.SIC_MANZANAVIA().BuscarVias(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) 
            { 
                lisDataQuery.Add(new SelectListItem { Value = item.CODCORRMANZVIA + "-" + item.CODVIA, Text = item.TXTVIA.ToUpper() + " - CUADRA " + item.NUMCUADRA + " - LADO " + item.TXTPARIDAD }); 
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarViasMuniSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTEVIA entQuery = new BE.SIC_LOTEVIA(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEVIA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            IEnumerable<BE.SIC_LOTEVIA> lisQuery = new BL.SIC_LOTEVIA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODCORRMANZVIA + "-" + item.CODVIA + "_" + item.NUMCUADRA + "|" + item.CODLADO, Text = item.TXTVIA + " - CUADRA " + item.NUMCUADRA + " - LADO " + item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarViasRetMuniSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTEVIA entQuery = new BE.SIC_LOTEVIA(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEVIA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            IEnumerable<BE.SIC_LOTEVIA> lisQuery = new BL.SIC_LOTEVIA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODCORRMANZVIA + "-" + item.CODVIA + "_" + item.NUMCUADRA, Text = item.TXTVIA + " - CUADRA " + item.NUMCUADRA + " - LADO " + item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoLoteVia(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTEDIRECMUNI entQuery = new BE.SIC_LOTEDIRECMUNI(); entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTEDIRECMUNI>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            entQuery.ESTATICO = FiltrarSolUnidad.Estatico;
            IEnumerable<BE.SIC_LOTEDIRECMUNI> lisQuery = new BL.SIC_LOTEDIRECMUNI().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODVIA + "-" + item.CODCORRMANZVIA + "-" + item.CODCORRUNIDDIREMUNI,
                    Text = item.TXTTIPODEVIA + ". " + item.TXTVIA
                });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarColindanteLoteSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            IEnumerable<BE.SIC_LOTE> lisQuery = new BL.SIC_LOTE().ListarEstatico(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLOTE , Text = "LOTE CATASTRAL " + item.CODLOTE }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarColindanteLoteMobiliarioUrbanoSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE();
            entQuery = JsonConvert.DeserializeObject<BE.SIC_LOTE>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, true)));
            IEnumerable<BE.SIC_LOTE> lisQuery = new BL.SIC_LOTE().ListarColindanteLoteMobiliarioUrbanoSelect(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLOTE, Text = "LOTE CATASTRAL " + item.CODLOTE }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarParamConfirmacionSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoSiNo();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarParamAlturaVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoAlturaVia();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery){ lisDataQuery.Add(new SelectListItem{ Value = item.CODPARAMETRO,Text = item.TXTDESCRIPCION}); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoLoteSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoLote();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarLadoLinderoSelect()
        {
            IEnumerable<BE.SIC_LADO> lisQuery = new BL.SIC_LADO().Linderos(new BE.SIC_LADO());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLADO, Text = item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        
        public List<SelectListItem> ListarTipoOtrosDocumentos()
        {
            IEnumerable<BE.SIC_LOTEOTRODOC> lisQuery = new BL.SIC_LOTEOTRODOC().ListarTipoOtrosDocumentos();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODDOCUMENTO, Text = item.TXTDOCUMENTO }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoEdificacionSelect()
        {
            IEnumerable<BE.SIC_EDIFICACION> lisQuery = new BL.SIC_EDIFICACION().Listar(new BE.SIC_EDIFICACION());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODTIPOEDIF, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoPuertaSelect()
        {
            IEnumerable<BE.SIC_PUERTA> lisQuery = new BL.SIC_PUERTA().Listar(new BE.SIC_PUERTA());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODTIPOPUER, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarLadoLoteSelect()
        {
            IEnumerable<BE.SIC_LADO> lisQuery = new BL.SIC_LADO().Vias(new BE.SIC_LADO());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLADO, Text = item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarFuentesColinSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().FuenteColindante();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) {
                lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoColindanteSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoColindante();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) {
                if (item.CODPARAMETRO == "010001" || item.CODPARAMETRO == "010002" || item.CODPARAMETRO == "010003") { 
                    lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION });
                }
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoDocRRPP()
        {
            IEnumerable<BE.SIC_TIPODOCURRP> lisQuery = new BL.SIC_TIPODOCURRP().Listar(new BE.SIC_TIPODOCURRP());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODTIPODOCU, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarFuenteSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().FuentesInscripcionCatastral();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoDocumentoRRPPSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDocumento();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarDescripcionRetiroSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().DescripcionRetiro();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarAsignacionRetiroSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().AsignacionRetiro();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        
        public List<SelectListItem> ListarZonificacionSelect(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_ZONIFMANZA entQuery = new BE.SIC_ZONIFMANZA();entQuery = JsonConvert.DeserializeObject<BE.SIC_ZONIFMANZA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, false)));
            IEnumerable<BE.SIC_ZONIFMANZA> lisQuery = new BL.SIC_ZONIFMANZA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODZONIFICACION, Text = item.CODZONIFICACION + "-" +item.TXTABREVIACION }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarZonificacion2Select(SolicitudUnidadViewModel FiltrarSolUnidad)
        {
            BE.SIC_ZONIFMANZA entQuery = new BE.SIC_ZONIFMANZA(); entQuery = JsonConvert.DeserializeObject<BE.SIC_ZONIFMANZA>(JsonConvert.SerializeObject(LlenarEntidadSol(FiltrarSolUnidad, false)));
            IEnumerable<BE.SIC_ZONIFMANZA> lisQuery = new BL.SIC_ZONIFMANZA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODZONIFICACION, Text = item.TXTZONIFICACION }); }
            return lisDataQuery;
        }

        #endregion

        #region COMPLETAR DATOS
        private Object LlenarEntidadSol(SolicitudUnidadViewModel ItemLote, bool lote)
        {
            DATOS_LOTES entidad = new DATOS_LOTES();
            entidad.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entidad.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entidad.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
            entidad.CODSECTOR = ItemLote.CodigoSector;
            entidad.CODMANZANA = ItemLote.CodigoManzana;
            if (lote == true)
            {
                entidad.CODLOTE = ItemLote.CodigoLote;
            }
            return entidad;
        }
        private Object LlenarEntidad(LoteLinderosViewModel ItemLote, bool lote)
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
        public class DATOS_LOTES
        {
            public string CODDEPARTAMENTO { get; set; }
            public string CODPROVINCIA { get; set; }
            public string CODDISTRITO { get; set; }
            public string CODSECTOR { get; set; }
            public string CODMANZANA { get; set; }
            public string CODLOTE { get; set; }
        }
        #endregion

        public Nullable<bool> AgregarDocumentos(SolicitudUnidadViewModel ItemLote)
        {

            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_LOTEEXPEDOCU entQueryDocumentos= new BE.SIC_LOTEEXPEDOCU();

            //entQueryDocumentos = JsonConvert.DeserializeObject<BE.SIC_LOTEEXPEDOCU>(JsonConvert.SerializeObject(LlenarEntidad(ItemLote, true)));
            entQueryDocumentos.CODDEPARTAMENTO = ItemLote.CodigoDepartamento;
            entQueryDocumentos.CODPROVINCIA = ItemLote.CodigoProvincia;
            entQueryDocumentos.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryDocumentos.CODSECTOR = ItemLote.CodigoSector;
            entQueryDocumentos.CODMANZANA = ItemLote.CodigoManzana;
            entQueryDocumentos.CODLOTE = ItemLote.CodigoLote;

            entQueryDocumentos.CODTIPODOCU = ItemLote.CodigoTipoDocumento;
            entQueryDocumentos.TXTNUMERO = ItemLote.CodigoNumeroSolicitud;
            entQueryDocumentos.TXTSOLICITANTE = ItemLote.Solicitante;
            if (ItemLote.FechaDocumento != null)
            {
                entQueryDocumentos.FECDOCUMENTO = DateTime.Parse(ItemLote.FechaDocumento);
            }
            entQueryDocumentos.TXTOBSERVACION = ItemLote.Observacion;
            entQueryDocumentos.TXTIDTRAMITE = ItemLote.CodigoTramite;
            entQueryDocumentos.CODSOLICITANTE = ItemLote.CodigoSolicitante;
            entQueryDocumentos.ESTATICO = ItemLote.Estatico;
            entQueryDocumentos.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTEEXPEDOCU().AgregarDocumentos(entQueryDocumentos);


            return entSIC_RETORNO_COLINDANTE.Ok;
        }
        public Nullable<bool> EliminarDocumentos(SolicitudUnidadViewModel ItemLote)
        {
            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_LOTEEXPEDOCU entQueryDocumentos = new BE.SIC_LOTEEXPEDOCU();

            entQueryDocumentos.CODDEPARTAMENTO = ItemLote.CodigoDepartamento;
            entQueryDocumentos.CODPROVINCIA = ItemLote.CodigoProvincia;
            entQueryDocumentos.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryDocumentos.CODSECTOR = ItemLote.CodigoSector;
            entQueryDocumentos.CODMANZANA = ItemLote.CodigoManzana;
            entQueryDocumentos.CODLOTE = ItemLote.CodigoLote;
            entQueryDocumentos.CODCORRLOTEEXPEDOCU = ItemLote.CodigoCorrelativo;
            entQueryDocumentos.ESTATICO = ItemLote.Estatico;
            entQueryDocumentos.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTEEXPEDOCU().EliminarDocumentos(entQueryDocumentos);

            return entSIC_RETORNO_COLINDANTE.Ok;
        }


        public string RecuperarLoteImagen(RegistrarLoteViewModel Lote)
        {
            BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
            };
            entQuery.ESTATICO = Lote.Estatico;
            BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);

            byte[] archivo = null;
            if (srcQuery != null)
            {
                BE.SIC_UNIDAD entQueryFoto = new BE.SIC_UNIDAD();
                entQueryFoto.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                //srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                BE.SIC_UNIDAD srcQueryFoto = new BL.SIC_UNIDAD().RecuperarFoto(entQueryFoto);

                if (srcQueryFoto != null)
                {
                    var path = @srcQueryFoto.TXTRUTAFOTO == null ? "" : @srcQueryFoto.TXTRUTAFOTO;
                    return @ConfigurationManager.AppSettings["RUTA_FOTOS"] + path.Substring(2, path.Length - 2);
                }

            }
            return "";
        }

        //public byte[] RecuperarLoteImagen(RegistrarLoteViewModel Lote)
        //{
        //    BE.SIC_LOTE entQuery = new BE.SIC_LOTE()
        //    {
        //        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
        //        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
        //        CODDISTRITO = Lote.CodigoDistrito,
        //        CODSECTOR = Lote.CodigoSector,
        //        CODMANZANA = Lote.CodigoManzana,
        //        CODLOTE = Lote.CodigoLote,
        //        ESTATICO = Lote.Estatico
        //    };
        //    BE.SIC_LOTE srcQuery = new BL.SIC_LOTE().Recuperar(entQuery);
        //    //var path = @"C:\ARCHIVOS\REPOSIC\2018\JULIO\MSICAS20180709122321316.png";
        //    var path = @srcQuery.TXTNOMDOCUINT;
        //    byte[] archivo = null;
        //    if (path != null) {
        //        try
        //        {
        //            try
        //            {
        //                archivo = System.IO.File.ReadAllBytes(path);
        //            }
        //            catch (System.IO.DirectoryNotFoundException ex)
        //            {
        //                Console.WriteLine(ex);
        //            }
        //        }
        //        catch (FileNotFoundException ex)
        //        {
        //            Console.WriteLine(ex);
        //        }
        //    }else {
        //        return null;
        //    }
        //    return archivo;
        //}
        public ManzanaMediasViewModel RecuperarManzanaMedidas(RegistrarRetiroMunicipalViewModel Lote)
        {
            int indice1 = Lote.CodigoVia.IndexOf("-"); int indice2 = Lote.CodigoVia.IndexOf("_");
            string codcorman = Lote.CodigoVia.Substring(0, indice1); string codvia = Lote.CodigoVia.Substring(indice1 + 1, (indice2 - indice1 - 1));
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODCORRMANZVIA = codcorman,
                CODVIA = codvia
            };
            BE.SIC_MANZANAVIA lisQuery = new BL.SIC_MANZANAVIA().Recuperar(entQuery);
            if (lisQuery == null)
            {
                lisQuery = new BE.SIC_MANZANAVIA() { NUMRETIRO = 0, NUMJARDIN = 0 };
            }
            ManzanaMediasViewModel medidas = new ManzanaMediasViewModel() { Retiro = lisQuery.NUMRETIRO, Jardin = lisQuery.NUMJARDIN };
            return medidas;
        }
        public string RecuperarZonificacion(ZonifManzaViewModel Lote)
        {
            BE.SIC_ZONIFICACION lisQuery = new BL.SIC_ZONIFICACION().Recuperar(new BE.SIC_ZONIFICACION()
            {
                CODZONIFICACION = Lote.CodigoZonificacion
            });
            if (lisQuery == null)
            {
                lisQuery = new BE.SIC_ZONIFICACION() { TXTZONIFICACION = "" };
            }
            return lisQuery.TXTZONIFICACION;
        }
        public string RecuperarZonifLote(ZonifLoteViewModel Lote)
        {
            BE.SIC_ZONIFLOTE entQuery = new BE.SIC_ZONIFLOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Lote.CodigoDistrito,
                CODSECTOR = Lote.CodigoSector,
                CODMANZANA = Lote.CodigoManzana,
                CODLOTE = Lote.CodigoLote,
                CODZONIFICACION = ""
            };
            BE.SIC_ZONIFLOTE lisQuery = new BL.SIC_ZONIFLOTE().Recuperar(entQuery);
            if (lisQuery == null)
            {
                lisQuery = new BE.SIC_ZONIFLOTE() { CODZONIFICACION = "" };
            }
            return lisQuery.CODZONIFICACION;
        }
        public Nullable<bool> EliminarOtrosDocumentos(LoteOtrosDocumentosViewModel ItemLote)
        {

            BE.SIC_RETORNO entSIC_RETORNO_COLINDANTE = new BE.SIC_RETORNO();
            entSIC_RETORNO_COLINDANTE.Ok = false;

            BE.SIC_LOTEOTRODOC entQueryLindero = new BE.SIC_LOTEOTRODOC();
            entQueryLindero.CODDISTRITO = ItemLote.CodigoDistrito;
            entQueryLindero.CODSECTOR = ItemLote.CodigoSector;
            entQueryLindero.CODMANZANA = ItemLote.CodigoManzana;
            entQueryLindero.CODLOTE = ItemLote.CodigoLote;
            entQueryLindero.CORRELATIVO = ItemLote.Correlativo;
            entQueryLindero.ESTATICO = ItemLote.Estatico;
            entQueryLindero.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            entSIC_RETORNO_COLINDANTE = new BL.SIC_LOTEOTRODOC().EliminarOtrosDocumentos(entQueryLindero);


            return entSIC_RETORNO_COLINDANTE.Ok;

        }
    }
}
