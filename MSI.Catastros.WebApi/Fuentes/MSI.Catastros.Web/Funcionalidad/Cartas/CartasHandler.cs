using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Web.Reportes;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;


namespace MSI.Catastros.Web.Funcionalidad.Cartas
{
    public class CartasHandler
    {

        public List<CartasViewModel> RecargarTablaCartas(DataTableAjaxPostModel model, CartasViewModel FiltrarInspecciones, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_CARTA entQuery = new BE.SIC_CARTA()
            {
                CODCARTA = "0001",
                CODTIPOSOLI = FiltrarInspecciones.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarInspecciones.FiltrarNumeroSolicitud,
                CODANO = System.DateTime.Now.Year.ToString(),
                CODANOSOLI = FiltrarInspecciones.FiltrarCodigoPeriodo,
                CODTIPOINFOR = FiltrarInspecciones.FiltrarCodigoTipoInforme,
                CTIPODOCUMENTO = FiltrarInspecciones.FiltrarCodigoTipoDocumentoReg,
                CODNROINSPEC = FiltrarInspecciones.FiltrarNumeroInspeccion
            };
            ICollection<BE.SIC_CARTA> srcQuery = new BL.SIC_CARTA().BuscarCartas(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CARTA>();
            }
            int indice = 1;
            var lisDataQuery = new List<CartasViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CartasViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    FiltrarNumeroInspeccion = item.CODNROINSPEC,
                    CodigoCatastral = item.TXTCODIGOCATASTRAL,
                    Ubicacion = item.TXTUBICACION,
                    FechaGeneracion = item.TXTFECHAGENERACION,
                    FechaNueva = item.TXTFECHANUEVA,
                    CodigoUsuario = item.CODUSUARIO,
                    CodigoCorrelativoTramite = (item.CODTRAMITE == null) ? item.CODCORRCARTA + "-" + item.FECREG.Value.Year.ToString() + "-1220" : item.CODTRAMITE,
                    Documento = "",
                    FiltrarCodigoCorrelativo = item.CODCORRCARTA,
                    CodigoDocumentoGenerado = item.CODDOCUMGEN,
                    Item = indice.ToString(),
                    Parrafo1 = item.TXTPARRAFO1
                });
                indice++;
            }
            return lisDataQuery;
        }
        public CartasViewModel RecuperarGrabarCarta(CartasViewModel FiltrarInformes, out bool resul)
        {
            BE.SIC_CARTA entQuery = new BE.SIC_CARTA()
            {
                CODCARTA = "0001",
                CODTIPOINFOR = FiltrarInformes.FiltrarCodigoTipoInforme,                
                CODANO = System.DateTime.Now.Year.ToString(),
                //CODTIPOSOLI = FiltrarInformes.FiltrarCodigoTipoSolicitud,
                //CODANOSOLI = System.DateTime.Now.Year.ToString(),
                //CODNUMESOLI = FiltrarInformes.FiltrarNumeroSolicitud,
                //CTIPODOCUMENTO = FiltrarInformes.FiltrarCodigoTipoDocumentoReg,
                //CODNROINSPEC = FiltrarInformes.FiltrarNumeroInspeccion,
                CODCORRCARTA = FiltrarInformes.FiltrarCodigoCorrelativo
            };
            BE.SIC_CARTA srcQuery = new BL.SIC_CARTA().Recuperar(entQuery);
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarInformes.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarInformes.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarInformes.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            CartasViewModel lisDataQuery;
            if (srcQuerySol == null)
            {
                lisDataQuery = new CartasViewModel();
                resul = false;
            } else {
                lisDataQuery = new CartasViewModel();
                lisDataQuery.CodigoOficina = srcQuery.CODOOFICINA;
                lisDataQuery.NombreAnio = srcQuery.TXTANIO;
                lisDataQuery.FiltrarCodigoCorrelativo = srcQuery.CODCORRCARTA; lisDataQuery.FiltrarCodigoCarta = srcQuery.CODCARTA;
                lisDataQuery.Subtitulo1 = srcQuery.TXTSUBTITULO1; lisDataQuery.Subtitulo2 = srcQuery.TXTSUBTITULO2;
                lisDataQuery.Subtitulo3 = srcQuery.TXTSUBTITULO3; lisDataQuery.Subtitulo4 = srcQuery.TXTSUBTITULO4;
                lisDataQuery.Subtitulo5 = srcQuery.TXTSUBTITULO5; lisDataQuery.Subtitulo6 = srcQuery.TXTSUBTITULO6;
                lisDataQuery.Subtitulo7 = srcQuery.TXTSUBTITULO7;
                lisDataQuery.Parrafo1 = srcQuery.TXTPARRAFO1; lisDataQuery.Parrafo2 = srcQuery.TXTPARRAFO2;
                lisDataQuery.Parrafo3 = srcQuery.TXTPARRAFO3; lisDataQuery.Parrafo4 = srcQuery.TXTPARRAFO4;
                lisDataQuery.Parrafo5 = srcQuery.TXTPARRAFO5; lisDataQuery.Parrafo6 = srcQuery.TXTPARRAFO6;
                lisDataQuery.Parrafo7 = srcQuery.TXTPARRAFO7; lisDataQuery.Parrafo8 = srcQuery.TXTPARRAFO8;
                lisDataQuery.Parrafo9 = srcQuery.TXTPARRAFO9; lisDataQuery.Parrafo10 = srcQuery.TXTPARRAFO10;
                lisDataQuery.Firma1 = srcQuery.TXTFIRMA1; lisDataQuery.Firma2 = srcQuery.TXTFIRMA2;
                lisDataQuery.Firma3 = srcQuery.TXTFIRMA3; lisDataQuery.Firma4 = srcQuery.TXTFIRMA4;
                lisDataQuery.Firma5 = srcQuery.TXTFIRMA5;
                lisDataQuery.Parrafo7 = ((srcQuerySol.NUMCALVER != null) ? srcQuerySol.NUMCALVER + "-" : "") + srcQuerySol.TXTANOCALVER;
                lisDataQuery.PiePagina = srcQuery.TXTPIEPAGINA;
                lisDataQuery.TipoPersonas = srcQuery.CODPEREMISION;
                lisDataQuery.CodigoDocumentoGenerado = srcQuery.CODDOCUMGEN;
                lisDataQuery.ListTipoUbicacion = new List<SelectListItem>();
                lisDataQuery.ListTipoInspectores = new List<SelectListItem>();
                lisDataQuery.ListTitulares = new List<SelectListItem>();
                lisDataQuery.ListDiasProgramados = new List<SelectListItem>();
                lisDataQuery.ListTipoPersona = new CartasHandler().ListadoTipoPersona();
                resul = true;
            }
            return lisDataQuery;
        }

        public BE.SIC_RETORNO CrearCarta(CartasViewModel Informe)
        {
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODTIPODOC = Informe.FiltrarCodigoTipoDocumentoReg
            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            BE.SIC_PROGINSPEC entQueryProg = new BE.SIC_PROGINSPEC()
            {
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
            };
            BE.SIC_PROGINSPEC srcQueryProg = new BL.SIC_PROGINSPEC().ListarUltima(entQueryProg);
            if (srcQueryProg == null) {
                srcQueryProg = new BE.SIC_PROGINSPEC();
            }
            var nroInspec = (Informe.FiltrarCodigoTipoInforme == "CITA" || Informe.FiltrarCodigoTipoInforme == "CAPI") ? srcQueryProg.CODNROINSPEC : Informe.FiltrarNumeroInspeccion;

            string numTramite = null;
            if (Informe.FiltrarCodigoTipoSolicitud != "010003")
            {
                BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                {
                    VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VTIPO_DOCUMENTO = Informe.FiltrarCodigoTipoInforme,
                    TXTASUNTO = (srcQuerySol.TXTASUNTO != null) ? srcQuerySol.TXTASUNTO : "",
                    VUSUARIO = VariablesWeb.IdUsuarioIntento,
                    VCONTRIBUYENTE = srcQuerySol.CODIGO_CONTRIBUYENTE,
                    NUMFOLIO = srcQuerySol.NUMFOLSOL,
                    VCOD_ACTIVIDAD = srcQuerySol.COD_ACCION
                };
                BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().ObtenerDocumento(entQueryExt);
                numTramite = entSIC_RETORNO_INT.CODIGO;
                if (Informe.FiltrarCodigoTipoInforme != "CAPI")
                {
                    numTramite = null;
                }
            }
            BE.SIC_CARTA entQuery = new BE.SIC_CARTA()
            {
                CODCARTA = "0001",
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
                //CODCORRCARTA = Informe.FiltrarCodigoCorrelativo,
                CODANO = System.DateTime.Now.Year.ToString(),
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                CODTRAMITE = numTramite,
                CTIPODOCUMENTO = (Informe.FiltrarCodigoTipoSolicitud != "010003") ? Informe.FiltrarCodigoTipoDocumentoReg : "REQI",
                CODNROINSPEC = nroInspec,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_RETORNO entSIC_RETORNO;

            if (srcQueryProg.CODNROINSPEC != null)
            {
                entSIC_RETORNO = new BL.SIC_CARTA().Grabar(entQuery);
            }
            else 
            {
                entSIC_RETORNO = new BE.SIC_RETORNO() { MENSAJE = "No se ha agregado el documento porque no existe una inspección", Ok = false};
            }
            return entSIC_RETORNO;
        }

        public Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                var fileName = System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + "\\" + "texto" + ".pdf";
                pdf.Save(fileName);
                res = ms.ToArray();

            }
            return res;
        }
        public BE.SIC_RETORNO GrabarCarta(CartasViewModel Informe)
        {
            BE.SIC_CARTA entQuery = new BE.SIC_CARTA()
            {
                CODCARTA = Informe.FiltrarCodigoCarta,
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
                CODCORRCARTA = Informe.FiltrarCodigoCorrelativo,
                CODANO = System.DateTime.Now.Year.ToString(),
            };
            BE.SIC_CARTA srcQuery = new BL.SIC_CARTA().Recuperar(entQuery);
            string nuevoTemp = srcQuery.CODDOCUMGEN;

            srcQuery.CODOOFICINA = Informe.CodigoOficina;
            srcQuery.TXTSUBTITULO1 = Informe.Subtitulo1; srcQuery.TXTSUBTITULO2 = Informe.Subtitulo2;
            if (Informe.FiltrarCodigoTipoInforme == "CAPI")
            {
                if (Informe.Subtitulo3 != null) srcQuery.TXTSUBTITULO3 = ToTitleCase(Informe.Subtitulo3);
                if (Informe.Subtitulo4 != null) srcQuery.TXTSUBTITULO4 = ToTitleCase(Informe.Subtitulo4);
            }
            else 
            {
                srcQuery.TXTSUBTITULO3 = Informe.Subtitulo3;
                srcQuery.TXTSUBTITULO4 = Informe.Subtitulo4;
            }
            
            srcQuery.TXTSUBTITULO5 = Informe.Subtitulo5; srcQuery.TXTSUBTITULO6 = Informe.Subtitulo6;
            srcQuery.TXTSUBTITULO7 = Informe.Subtitulo7;
            
            srcQuery.TXTPARRAFO1 = Informe.Parrafo1;            srcQuery.TXTPARRAFO2 = Informe.Parrafo2;            srcQuery.TXTPARRAFO3 = Informe.Parrafo3;
            srcQuery.TXTPARRAFO4 = Informe.Parrafo4;            srcQuery.TXTPARRAFO5 = Informe.Parrafo5;            srcQuery.TXTPARRAFO6 = Informe.Parrafo6;
            srcQuery.TXTPARRAFO7 = Informe.Parrafo7;            srcQuery.TXTPARRAFO8 = Informe.Parrafo8;            srcQuery.TXTPARRAFO9 = Informe.Parrafo9;
            srcQuery.TXTPARRAFO10 = Informe.Parrafo10;

            srcQuery.TXTFIRMA1 = Informe.Firma1; srcQuery.TXTFIRMA2 = Informe.Firma2; srcQuery.TXTFIRMA3 = Informe.Firma3;
            srcQuery.TXTFIRMA4 = Informe.Firma4; srcQuery.TXTFIRMA5 = Informe.Firma5;

            srcQuery.TXTPIEPAGINA = Informe.PiePagina;
            srcQuery.CODPEREMISION = Informe.TipoPersonas;
            srcQuery.CODDOCUMGEN = "1";
            srcQuery.TXTANIO = Informe.NombreAnio;
            srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            
            GrabarInformeUnidad(Informe);
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CARTA().Actualizar(srcQuery);

            RegistrarArchivos registrarArchivos = new RegistrarArchivos()
            {
                FiltrarCodigoCarta = "0001",
                FiltrarCodigoTipoInforme = Informe.FiltrarCodigoTipoInforme,
                FiltrarCodigoCorrelativo = Informe.FiltrarCodigoCorrelativo,
                FiltrarCodigoPeriodo = System.DateTime.Now.Year.ToString(),
                Actualizar = (nuevoTemp == "1") ? true : false,
            };
            string rut = "";
            var local = GrabarInformeServer(registrarArchivos, out rut);
            entSIC_RETORNO.MENSAJE = rut.Substring(0, rut.Length-4);
            return entSIC_RETORNO;
        }
        public Nullable<bool> GrabarInformeServer(RegistrarArchivos Informe, out string Ruta)
        {
            #region Subir archivo
            string repo = "DOCUMENTOS"; string tiporepo = "CARTAS\\PERIODO\\SOLICITUD";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                _Ext = "pdf";
                string tempCodigo = Informe.FiltrarCodigoTipoInforme + Informe.FiltrarCodigoCarta + Informe.FiltrarCodigoCorrelativo + Informe.FiltrarCodigoPeriodo;
                string tempCodigo1 = Informe.FiltrarCodigoTipoInforme + "," + Informe.FiltrarCodigoCarta + "," + Informe.FiltrarCodigoCorrelativo + "," + Informe.FiltrarCodigoPeriodo;
                string aleatorio = Guid.NewGuid().ToString();
                string _FN = tempCodigo + "_" + "CARTA_DOC" + aleatorio + "." + _Ext;
                _Codigo = tempCodigo + "_" + "CARTA_DOC" + aleatorio;

                _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                {
                    TXTNOMTABLA = "SIC_CARTA",
                    CODPKTABLA = tempCodigo1,
                    TXTPKTABLANOM = "CODTIPOINFOR,CODCARTA,CODCORRCARTA,CODANO",
                    TXTEXTENSION = _Ext,
                    TXTRUTA = _Ruta,
                    FLGPRINCIPAL = "1",
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };
                BE.SIC_RETORNO entSIC_RETORNO_DETA;
                if (Informe.Actualizar == false)
                {
                    entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Grabar(entQueryDeta);
                }
                else
                {
                    ICollection<BE.SIC_DETAFILESERVER> srcData = new BL.SIC_DETAFILESERVER().Recuperar(entQueryDeta);var data = srcData.ToList();
                    if (srcData.Count == 0){ srcData = new List<BE.SIC_DETAFILESERVER>();}
                    else { entQueryDeta.CODCORRELFS = data[data.Count - 1].CODCORRELFS; }
                    entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Actualizar(entQueryDeta);
                }
                
                subida = true;
            
            #endregion
            Ruta = _Ruta;
            return subida;
        }
        private bool GrabarInformeUnidad(CartasViewModel Informe)
        {
            string InfCodigoCatastral = "";
            if (Informe.FiltrarCodigoTipoInforme == "CAPI") {
                InfCodigoCatastral = Informe.Subtitulo5;
            } else if (Informe.FiltrarCodigoTipoInforme == "CITA") {
                InfCodigoCatastral = Informe.Subtitulo3;
            } else if (Informe.FiltrarCodigoTipoInforme == "CONV") {
                InfCodigoCatastral = Informe.Subtitulo2;
            }
            var Unidades = InfCodigoCatastral.Split('|');
            var CodigoUnico = Informe.CodigoUnico.Split('|');
            BE.SIC_DOCUUNIDAD entQuery = new BE.SIC_DOCUUNIDAD();
            int contUnidades = 0;
            foreach (var Item in Unidades)
            {
                var Codigo = Item.Split('-');

                entQuery.CODANOINFORCARTA = System.DateTime.Now.Year.ToString();
                entQuery.CODCORRINFORCARTA = Informe.FiltrarCodigoCorrelativo;
                entQuery.CODINFORCARTA = Informe.FiltrarCodigoCarta;
                entQuery.CODTIPOINFORCARTA = Informe.FiltrarCodigoTipoInforme;
                entQuery.CODUNI = Convert.ToInt32(CodigoUnico[contUnidades]);
                BE.SIC_DOCUUNIDAD srcQueryUni = new BL.SIC_DOCUUNIDAD().RecuperarUnidad(entQuery);
                if (srcQueryUni != null)
                {
                    entQuery = srcQueryUni;
                }

                entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
                entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');

                entQuery.CODDISTRITO = Codigo[0];
                entQuery.CODSECTOR = Codigo[1];
                entQuery.CODMANZANA = Codigo[2];
                entQuery.CODLOTE = Codigo[3];
                entQuery.CODEDIFICACION = Codigo[4];
                entQuery.CODENTRADA = Codigo[5];
                entQuery.CODPISO = Codigo[6];
                entQuery.CODUNIDAD = Codigo[7];
                entQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                BE.SIC_RETORNO entSIC_RETORNO = (srcQueryUni != null) ? new BL.SIC_DOCUUNIDAD().Actualizar(entQuery) : new BL.SIC_DOCUUNIDAD().Grabar(entQuery);


                contUnidades++;
            }

            return false;
        }
        public Nullable<bool> EliminarInforme(CartasViewModel Detalle)
        {
            BE.SIC_CARTA entQuery = new BE.SIC_CARTA()
            {
                CODCARTA = "0001",
                CODTIPOINFOR = Detalle.FiltrarCodigoTipoInforme,
                CODCORRCARTA = Detalle.FiltrarCodigoCorrelativo,
                CODANO = System.DateTime.Now.Year.ToString(),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CARTA().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public List<SelectListItem> ListadoTipoPersona()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoPersona();
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
        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
        public List<CartasViewModel> RecuperarSolicitud(CartasViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODNROINSPEC = FiltrarSolUnidad.FiltrarNumeroInspeccion,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            ICollection<BE.SIC_SOLISEGUI> srcQuery = new BL.SIC_SOLISEGUI().Carta(entQuery);

            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            
            var data = srcQuery.ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
            }
            var lisDataQuery = new List<CartasViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CartasViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    HoraInspeccion = item.TXTHORAINSP,
                    FiltrarCodigoTipoSolicitud = item.CODTIPOSOLI,
                    CalidadVerificacion = ((srcQuerySol.NUMCALVER != null) ? srcQuerySol.NUMCALVER + "-" : "") + srcQuerySol.TXTANOCALVER,
                    Solicitante = srcQuerySol.TXTSOLICITANTE,
                    FechaCitacion = (item.FECLIMITE != null) ? item.FECLIMITE.Value.ToString("dd/MM/yyyy") : "",
                    //NombreTipoLlenado = item.TXTNOMBRELLENADO,
                    FechaInspeccion = (item.FECINSPE != null) ? item.FECINSPE.Value.ToString("dd/MM/yyyy") : "",
                });
            }
            return lisDataQuery;
        }

        public string RecuperarTelefono(string CodigoInspectores)
        {
            BE.SIC_USUCARCAT entQuery = new BE.SIC_USUCARCAT()
            {
                CODUSUASIS = CodigoInspectores
            };
            BE.SIC_USUCARCAT srcQuery = new BL.SIC_USUCARCAT().Recuperar(entQuery);

            if (srcQuery == null)
            {
                return "";
            }
            return srcQuery.NUMCELCONTA;
        }

        public List<CartasViewModel> RecuperarInspectores(CartasViewModel FiltrarSolUnidad)
        {
            BE.SIC_MOVINSPEC entQuery = new BE.SIC_MOVINSPEC()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODNROINSPEC = FiltrarSolUnidad.FiltrarNumeroInspeccion,
                CODANOSOLI = System.DateTime.Now.Year.ToString()

            };
            ICollection<BE.SIC_MOVINSPEC> srcQuery = new BL.SIC_MOVINSPEC().ListarInforme(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_MOVINSPEC>();
            }
            var lisDataQuery = new List<CartasViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CartasViewModel
                {
                    Inspectores = (item.TXTNOMBRE != null) ? item.TXTNOMBRE :  "",
                    CodigoInspectores = (item.CODUSUASIS != null) ? item.CODUSUASIS :  "",
                    EstadoResul = item.FLAGRESPONSABLE
                });
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarUbicacion(CartasViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarDirec(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            string tempUbicacion = "";
            foreach (var item in data)
            {
                if (item.TXTDIRECCION != tempUbicacion) { 
                    lisDataQuery.Add(new SolicitudUnidadViewModel
                    {
                        Ubicacion = (item.TXTDIRECCION == null) ? "" : item.TXTDIRECCION,
                    });
                }
                tempUbicacion = item.TXTDIRECCION;
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarSolUnidad(CartasViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                
            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
           ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarSolicitud(entQuery);           
            var data = srcQuery.ToList();
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
                    Ubicacion = (item.TXTDIRECCION != null) ? item.TXTDIRECCION : "",
                    Titular = (item.TXTTITULARES != null) ? item.TXTTITULARES : "",
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> RecuperarDiasProg(CartasViewModel FiltrarCartas)
        {
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarCartas.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarCartas.FiltrarCodigoTipoDocumentoReg;
            }
            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ListarNumero(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODNROINSPEC + " - " + item.FECINSPE.ToString().Substring(0, 10) + " " + item.TXTHORAINSP,
                    Text = item.CODNROINSPEC + " - " + item.FECINSPE.ToString().Substring(0, 10) + " " + item.TXTHORAINSP
                });
            }
            return lisDataQuery;
        }
        public CartasViewModel CargarSolicitante(CartasViewModel FiltrarSolicitud)
        {
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarSolicitud.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolicitud.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarSolicitud.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarSolicitud.FiltrarCodigoTipoDocumentoReg != "REQI") { entQuerySoli.CODTIPODOC = FiltrarSolicitud.FiltrarCodigoTipoDocumentoReg; }
            BE.SIC_SOLICITUD srcQuerySoli = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);

            CartasViewModel InformeSoli = new CartasViewModel()
            {
                NombreSolicitante = srcQuerySoli.TXTSOLICITANTE,
                NombreRepresentante = srcQuerySoli.TXTREPRESENTANTEL
            };
            return InformeSoli;

        }
        public List<CartasViewModel> RecuperarInspecciones(CartasViewModel FiltrarCartas)
        {
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarCartas.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarCartas.FiltrarCodigoTipoDocumentoReg;
            }
            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ListarNumero(entQuery);
            
            
            var lisDataQuery = new List<CartasViewModel>();
            foreach (var item in lisQuery)
            {
                BE.SIC_UNIDADINSPECCION entQueryUnid = new BE.SIC_UNIDADINSPECCION()
                {
                    CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                    CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                    CODANOSOLI = System.DateTime.Now.Year.ToString(),
                    CODNROINSPEC = item.CODNROINSPEC
                };
                IEnumerable<BE.SIC_UNIDADINSPECCION> lisQueryUni = new BL.SIC_UNIDADINSPECCION().Listar(entQueryUnid);
                string codigoCatastral = "";
                foreach (var itemUni in lisQueryUni) {
                    codigoCatastral = codigoCatastral + "/" + itemUni.CODDISTRITO + "-" + itemUni.CODSECTOR + "-" + itemUni.CODMANZANA + "-" + itemUni.CODLOTE + "-" + itemUni.CODEDIFICACION + "-" + itemUni.CODENTRADA + "-" + itemUni.CODPISO + "-" + itemUni.CODUNIDAD;
                }


                lisDataQuery.Add(new CartasViewModel { 
                    FiltrarNumeroInspeccion = item.CODNROINSPEC,
                    FechaInspeccion = item.FECINSPE.ToString().Substring(0,10),
                    HoraInspeccion = item.TXTHORAINSP,
                    EstadoInspeccion = item.TXTESTADOINSPEC,
                    CodigoCatastral = codigoCatastral.Substring(1),                       
                    Inspecciones = item.CODNROINSPEC + " - " + item.TXTESTADOINSPEC
                });
            }
            return lisDataQuery;
        }

        public List<SelectListItem> ListarNumeroInspeccionSelect(CartasViewModel FiltrarCartas)
        {
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarCartas.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarCartas.FiltrarCodigoTipoDocumentoReg;
            }
            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ListarNumero(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) {
                lisDataQuery.Add(new SelectListItem { Value = item.CODNROINSPEC, Text = item.CODNROINSPEC.Substring(0,4) + "-" +  item.CODNROINSPEC.Substring(4)}); 
            }
            return lisDataQuery;
        }
        
    }
}