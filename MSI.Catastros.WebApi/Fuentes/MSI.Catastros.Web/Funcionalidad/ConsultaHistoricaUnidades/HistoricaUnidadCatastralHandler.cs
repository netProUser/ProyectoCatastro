using MSI.Catastros.Utiles;
using MSI.Catastros.Web.Funcionalidad.ActualizacionEstado;
using MSI.Catastros.Web.Funcionalidad.BienComun;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.UnidadCatastral;

namespace MSI.Catastros.Web.Funcionalidad.ConsultaHistoricaUnidades
{
    public class HistoricaUnidadCatastralHandler
    {
        public List<SolicitudUnidadViewModel> BuscarHistoricoUnidades(DataTableAjaxPostModel model, FiltrarHistoricoUnidadCatastralViewModel FiltrarUnidadBuscar, out int totalResultado)
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
                CODUNIDAD = (FiltrarUnidadBuscar.FiltrarUnidad != null ? FiltrarUnidadBuscar.FiltrarUnidad : "")
            };
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().RecuperarHistoricoxCCU(entQuery);
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
                    CodigoDistrito = item.CODDISTRITO,
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoLote = item.CODLOTE,
                    Ed = item.CODEDIFICACION,
                    Entrada = item.CODENTRADA,
                    Piso = item.CODPISO,
                    Unidad = item.CODUNIDAD,
                    CodigoUni = item.CODUNI,
                    Numversion = item.NUMVERSION,
                    TipoLlenado = item.CODTIPOLLENA,
                    NumAreaTerrenoVerificada = item.NUMAREATERRVERI,
                    NumAreaTerrenoComun = item.NUMAREATERRCOMU,
                    NumAreaTerrenoTotal = item.NUMAREATERRTOTA,
                    NumPorcentajeBienComun = item.NUMPORCBIENCOMUOFIC,
                    Inscripcion = item.TXTINSCCATA,
                    NumeroPrincipal = item.TXTNUMERO,
                    ViaPrincipal = item.UBICPRINCIPAL,
                    TipoInterior = item.TXTDESCRIPCION,
                    Referencia = (item.CODREFANT != null) ? item.CODREFANT.Replace("|", "<br>") : ""
                });
            }
            return lisDataQuery;
        }
        public FiltrarConsultaHistoricaUnidadesViewModel RecuperarHistoricoUnidadCatastralEST (int CodigoUniCat,string NumVersion, out bool resul)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD();
            entQuery.CODUNI = CodigoUniCat;
            entQuery.NVERSION = NumVersion;

            BE.SIC_UNIDAD query = new BL.SIC_UNIDAD().RecuperarHistoricoUnidadCatastralEST(entQuery);

            FiltrarConsultaHistoricaUnidadesViewModel dataQuery;

            dataQuery = new FiltrarConsultaHistoricaUnidadesViewModel()
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

                AreaTerrenoSubValuada = query.NUMAREATERRSUBVAL,
                AreaTerrenoSobreValuada = query.NUMAREATERRSOBVAL,

                AreaConstruidaSubValuada = query.NUMAREACONSSUBVAL,
                AreaConstruidaSobreValuada = query.NUMAREACONSSOBVAL,

                

                AreaConstruidaTotalVerificada = query.NUMAREACONSTRUIDA,
                codigollenado = query.CODTIPOLLENA,
                FlgIndependiente = query.FLGINDEP,
                FechaUltimaInspeccion = (query.FECINSPEC != null) ? query.FECINSPEC.Value.ToString("dd/MM/yyyy") : "",
                FechaActualizacion = (query.FECACT != null) ? query.FECACT.Value.ToString("dd/MM/yyyy") : "",
                version = query.NVERSION
            }; 
             resul = true;

            return dataQuery;
        }
        public string RecuperarImagenHistoricaLote(FiltrarConsultaHistoricaUnidadesViewModel UnidadCatras)
        {
            BE.SIC_UNIDAD entQuery = new BE.SIC_UNIDAD()
            {
                CODUNI = UnidadCatras.CodigoUnidadCatastral,
                NVERSION = UnidadCatras.version
            };

            BE.SIC_UNIDAD srcQuery = new BL.SIC_UNIDAD().RecuperarHistoricoUnidadCatastralEST(entQuery);

            byte[] archivo = null;
            if (srcQuery != null)
            {
                srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                //srcQuery.CODLOTECATASTRAL = srcQuery.CODDISTRITO + srcQuery.CODSECTOR + srcQuery.CODMANZANA + srcQuery.CODLOTE;
                BE.SIC_UNIDAD srcQueryFoto = new BL.SIC_UNIDAD().RecuperarFoto(srcQuery);
                if (srcQueryFoto != null)
                {
                    var path = @srcQueryFoto.TXTRUTAFOTO == null ? "" : @srcQueryFoto.TXTRUTAFOTO;
                    return @ConfigurationManager.AppSettings["RUTA_FOTOS"] + path.Substring(2, path.Length - 2);
                }       
            }
            return "";
        }
        public List<NumeracionHistoricaPredioViewModel> CargarDireccionHistoricaUnidad(string CodigoUniCat, int flgindirec,string Numversion)
        {

            BE.SIC_UNIDADDIRECCONINTERIOR entQuery = new BE.SIC_UNIDADDIRECCONINTERIOR();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.FLAGINDIREC = flgindirec;
            entQuery.NVERSION = Numversion;

            ICollection<BE.SIC_UNIDADDIRECCONINTERIOR> listsrcQuery = new BL.SIC_UNIDADDIRECCONINTERIOR().CargarDireccionHistoricaUnidad(entQuery);
            var lisDataQuery = new List<NumeracionHistoricaPredioViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new NumeracionHistoricaPredioViewModel
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

        public List<LineasContructivasHistoricasViewModel> RecuperarUnidadConstruccionHistoricas(string CodigoUniCat, string NumVersion)
        {
            BE.SIC_UNIDADCONSTRUCCION entQuery = new BE.SIC_UNIDADCONSTRUCCION();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = NumVersion == "" ? 0 : Convert.ToInt32(NumVersion);


            ICollection<BE.SIC_UNIDADCONSTRUCCION> srcQuery = new BL.SIC_UNIDADCONSTRUCCION().RecuperarUnidadConstruccionHistoricas(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADCONSTRUCCION>();
            }
            var lisDataQuery = new List<LineasContructivasHistoricasViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new LineasContructivasHistoricasViewModel
                {
                    CodigoCorrelativo = item.CODCORRUNIDCONS,
                    txtPiso = item.TXTPISO,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    NumOrden = item.NUMORDEN,
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
                    
                });
            }
            return lisDataQuery;
        }
        public List<OtrasInstalacionesUnidadesHistoricasViewModel> RecuperaInstalacionesHistoricasUnidades(string CodigoUniCat, string NumVersion)
        {
            BE.SIC_UNIDINSTALACION entQuery = new BE.SIC_UNIDINSTALACION();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = NumVersion == "" ? 0 : Convert.ToInt32(NumVersion);


            ICollection<BE.SIC_UNIDINSTALACION> srcQuery = new BL.SIC_UNIDINSTALACION().RecuperaInstalacionesHistoricasUnidades(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDINSTALACION>();
            }
            var lisDataQuery = new List<OtrasInstalacionesUnidadesHistoricasViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new OtrasInstalacionesUnidadesHistoricasViewModel
                {
                    NumOrden = item.NUMORDEN,
                    CodigoUnidadCatastral = item.CODUNI,
                    Mes = item.TXTMES,
                    Ano = item.TXTANO,
                    EstadoConserva = item.CODESTACONSE,
                    CodigoUnidad = item.CODUNIDAD,
                    CodigoTipoInstalacion = item.TXTNOMBRE,
                    Cantidad = item.NUMCANTIDAD,
                    Capacidad = item.NUMCAPACIDAD,
                    CodigoCorrelativo = item.CODCORRUNIDINST,
                });
            }
            return lisDataQuery;
        }

        public List<OtrasLinderosUnidadesHistoricasViewModel> BuscarHistoricoLoteLinderos(string CodigoUniCat, string NumVersion)
        {
            BE.SIC_QUINTALINDERO entQuery = new BE.SIC_QUINTALINDERO();

            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = NumVersion == "" ? 0 : Convert.ToInt32(NumVersion);


            ICollection<BE.SIC_QUINTALINDERO> lisQuery = new BL.SIC_QUINTALINDERO().BuscarHistoricoLoteLinderos(entQuery);
            var lisDataQuery = new List<OtrasLinderosUnidadesHistoricasViewModel>();
            foreach (var item in lisQuery)
            {
                
                lisDataQuery.Add(new OtrasLinderosUnidadesHistoricasViewModel
                {
                    MedidaLadoCam = item.NUMMEDICAMP,
                    MedidaLadoOfi = item.NUMMEDIOFIC,
                    CodigoTipoColind = item.CODTIPOCOLI,
                    CodigoLado = item.CODLADO,
                    NumeroLado = item.CORRELLINDE,
                    Colindante = item.TXTCOLINDANTE,
                    Codigo = item.CORRELLINDE

                    


                });
            }
            return lisDataQuery;
        }

        public List<HistoricoObservacionViewModel> BuscarHistoricoObservacion(string CodigoUniCat, string Numversion, string tipObs)
        {
            BE.SIC_UNIDADOBSERVACION entQuery = new BE.SIC_UNIDADOBSERVACION();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);
            entQuery.TIPOBSERVA = tipObs;

            ICollection<BE.SIC_UNIDADOBSERVACION> srcQuery = new BL.SIC_UNIDADOBSERVACION().BuscarHistoricoObservacion(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADOBSERVACION>();
            }
            var lisDataQuery = new List<HistoricoObservacionViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new HistoricoObservacionViewModel
                {
                    NumOrden = item.NUMORDEN,
                    CodigoUnidadCatastral = item.CODUNI,
                    Fecha = (item.FECOBSERVACION != null) ? item.FECOBSERVACION.Value.ToString("dd/MM/yyyy") : "",
                    Observacion = item.TXTOBSERVACION,
                    TipoObservacion = item.TIPOBSERVA,
                    CodigoCorrelativo = item.CODCORROBSE,
                });
            }
            return lisDataQuery;
        }

        public List<LoteHistoricoDocumentosRRPPViewModel> CargarUnidadRRPPHistorica(string CodigoUniCat,string Numversion)
        {

            BE.SIC_UNIDADRRPP entQuery = new BE.SIC_UNIDADRRPP();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);
          

            ICollection<BE.SIC_UNIDADRRPP> listsrcQuery = new BL.SIC_UNIDADRRPP().CargarUnidadRRPPHistorica(entQuery);
            var lisDataQuery = new List<LoteHistoricoDocumentosRRPPViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new LoteHistoricoDocumentosRRPPViewModel
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
                    TipoDocumento = item.TXTTIPODOCU

                });
                indice++;
            }
            return lisDataQuery;
        }

        public List<UnidadHistoricaExpedienteDocViewModel> CargarUnidadExpedienteDocHistorica(string CodigoUniCat,string Numversion)
        {

            BE.SIC_UNIDADEXPEDOCU entQuery = new BE.SIC_UNIDADEXPEDOCU();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);
            

            ICollection<BE.SIC_UNIDADEXPEDOCU> listsrcQuery = new BL.SIC_UNIDADEXPEDOCU().CargarUnidadExpedienteDocHistorica(entQuery);
            var lisDataQuery = new List<UnidadHistoricaExpedienteDocViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadHistoricaExpedienteDocViewModel
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
        public List<UnidadHistoricaLicenciaFuncViewModel> CargarUnidadLicenciasFuncHistorica(string CodigoUniCat, string Numversion)
        {

            BE.SIC_UNIDADAUTOLICE entQuery = new BE.SIC_UNIDADAUTOLICE();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);

            ICollection<BE.SIC_UNIDADAUTOLICE> listsrcQuery = new BL.SIC_UNIDADAUTOLICE().CargarUnidadLicenciasFuncHistorica(entQuery);
            var lisDataQuery = new List<UnidadHistoricaLicenciaFuncViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadHistoricaLicenciaFuncViewModel
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
        public List<UnidadHistoricaObrasPrivadasViewModel> CargarUnidadObrasPrivadasHistoricas(string CodigoUniCat, string Numversion)
        {

            BE.SIC_UNIDADAUTOEDIF entQuery = new BE.SIC_UNIDADAUTOEDIF();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);

            ICollection<BE.SIC_UNIDADAUTOEDIF> listsrcQuery = new BL.SIC_UNIDADAUTOEDIF().CargarUnidadObrasPrivadasHistoricas(entQuery);
            var lisDataQuery = new List<UnidadHistoricaObrasPrivadasViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadHistoricaObrasPrivadasViewModel
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
        public List<UnidadHistoricaTitularViewModel> CargarUnidadTitularHistoricas(string CodigoUniCat, string Numversion)
        {

            BE.SIC_UNIDADTITULAR entQuery = new BE.SIC_UNIDADTITULAR();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);

            ICollection<BE.SIC_UNIDADTITULAR> listsrcQuery = new BL.SIC_UNIDADTITULAR().CargarUnidadTitularHistoricas(entQuery);
            var lisDataQuery = new List<UnidadHistoricaTitularViewModel>();
            int indice = 1;
            foreach (var item in listsrcQuery)
            {
                lisDataQuery.Add(new UnidadHistoricaTitularViewModel
                {
                    Item = Convert.ToString(indice),
                    CodigoContribuyente = item.CODCONTRIBUYENTE,
                    RasonSocial = item.TXTRAZONSOCIAL,
                    NumeroDocumento = item.TXTDOCIDENTIDAD,
                    PorcentajeTitularidad = item.NUMPORCTITU,
                    CondicionPropiedad = item.TXTCONDTITU,
                    TipoDocumento = item.TXTDOCIDENTIDAD,
                    TipoPropietario = item.TXTTIPOPROPIETARIO
                });
                indice++;
            }
            return lisDataQuery;
        }
        public List<ActividadHistoricaEconomicaViewModel> CargarUnidadActividadEconomicaHistoricas(string CodigoUniCat, string Numversion)
        {
            BE.SIC_UNIDADACTIVIDAD entQuery = new BE.SIC_UNIDADACTIVIDAD();
            entQuery.CODUNI = CodigoUniCat == "" ? 0 : Convert.ToInt32(CodigoUniCat);
            entQuery.NUMVERSION = Numversion == "" ? 0 : Convert.ToInt32(Numversion);


            ICollection<BE.SIC_UNIDADACTIVIDAD> srcQuery = new BL.SIC_UNIDADACTIVIDAD().CargarUnidadActividadEconomicaHistoricas(entQuery);

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_UNIDADACTIVIDAD>();
            }
            var lisDataQuery = new List<ActividadHistoricaEconomicaViewModel>();
            foreach (var item in srcQuery.ToList())
            {
                lisDataQuery.Add(new ActividadHistoricaEconomicaViewModel
                {
                    CodigoUnidadCatastral = item.CODUNI,
                    CodigoUso = item.CODUSOESPE,
                    NombreUso = item.TXTUSOESPE,
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

    }
}