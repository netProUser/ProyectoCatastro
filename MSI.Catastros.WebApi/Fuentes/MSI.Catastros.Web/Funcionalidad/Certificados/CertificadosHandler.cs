using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Globalization;

namespace MSI.Catastros.Web.Funcionalidad.Certificados
{
    public class CertificadosHandler
    {

        public List<CertificadosViewModel> RecargarTablaCertificados(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados, out int totalResultado)
        {
            var pageSize = 3000;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
            {
                CODCERTIFICADO = FiltrarCertificados.FiltrarCodigoCertificado,
                CODTIPOSOLI = FiltrarCertificados.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCertificados.FiltrarNumeroSolicitud,
                CODANOCERTI = FiltrarCertificados.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODANOSOLI = FiltrarCertificados.CodAnioSolicitud, //FiltrarCertificados.FiltrarCodigoPeriodo,
                CODTIPOCERTI = FiltrarCertificados.FiltrarCodigoTipoCertificado,
                CTIPODOCUMENTO = FiltrarCertificados.FiltrarCodigoTipoDocumentoReg,
            };
            if (FiltrarCertificados.FiltrarCodigoTipoCertificado == "CEAC")
            {
                entQuery.ORDEN = " S.CODDISTRITO DESC, S.CODSECTOR DESC, S.CODMANZANA DESC, S.CODLOTE DESC, C.CODCERTIFICADO ";
            }
            ICollection<BE.SIC_CERTIFICADO> srcQuery = new BL.SIC_CERTIFICADO().BuscarCertificados(entQuery);
            //srcQuery[0].CODANIOSOL
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarCertificados.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCertificados.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarCertificados.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
                CODTIPODOC = FiltrarCertificados.FiltrarCodigoTipoDocumentoReg
            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            #endregion


            List<BE.SIC_CERTIFICADO> data = srcQuery.Skip(skip).Take(pageSize).ToList();
            totalResultado = srcQuery.Count();

            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CERTIFICADO>();
                totalResultado = 0;
            }
            var bloqueado = "";
            if (srcQuerySol != null)
            {
                if (srcQuerySol.FECFINSOLICITUD == null) bloqueado = "true";
            }

            int indice = 1;
            int cont = 1;
            string codAnt = "";

            int contCer = 0;
            foreach (var item in data)
            {
                if (item.FLG_TRABAJO == "R") contCer++;
            }

            var lisDataQuery = new List<CertificadosViewModel>();

            //foreach (var item in (FiltrarCertificados.FiltrarCodigoTipoCertificado == "CEAC") ? data.AsEnumerable().Reverse() : data)
            foreach (var item in data)
            {
                if (indice != 1)
                {
                    if (codAnt == item.TXTCODIGOCATASTRAL)
                    {
                        cont++;
                    }
                    else
                    {
                        cont = 1;
                    }
                }
                if (item.FECREG == null)
                {
                    item.FECREG = DateTime.Now;
                }
                var correl = item.CODCERTIFICADO;
                if (item.CODCERTIFICADO != null)
                {
                    correl = item.CODCERTIFICADO + "-" + item.FECREG.Value.Year.ToString() + "-1310";
                }
                lisDataQuery.Add(new CertificadosViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    CodigoCertificadoTemp = cont.ToString().PadLeft(4, '0'),
                    FiltrarCodigoCertificado = item.CODCERTIFICADO,
                    FiltrarCodigoTipoCertificado = item.CODTIPOCERTI,
                    FiltrarCodigoPeriodo = item.CODANOCERTI,
                    CodAnioSolicitud = item.CODANOSOLI,
                    CodigoCatastral = item.TXTCODIGOCATASTRAL,
                    Ubicacion = item.TXTUBICACION,
                    FechaGeneracion = (item.TXTFECHAGENERACION != null) ? item.TXTFECHAGENERACION.Value.ToString("dd/MM/yyyy") : "",
                    CodigoUnico = item.TXTCODUNI,
                    Bloqueado = bloqueado,
                    CodigoUsuario = item.CODUSUARIO,
                    CodigoCorrelativoTramite = (item.CODTRAMITE == null) ? correl : item.CODTRAMITE,
                    FlagTrabajo = (contCer == 0) ? "T" : item.FLG_TRABAJO,
                    CodigoDocumentoGenerado = item.CODDOCUMGEN,
                    Ruta = item.TXTRUTAIMAGEN == null ? "" : item.TXTRUTAIMAGEN.Replace("\\", ",").Replace("/", ","),
                    Item = indice.ToString(),
                    Parrafo1 = item.TXTPARRAFO1
                });
                codAnt = item.TXTCODIGOCATASTRAL;
                indice++;
            }
            return lisDataQuery;
        }
        public List<CertificadosDetalleViewModel> RecargarTablaCertificadosNomenclatura(DataTableAjaxPostModel model, CertificadosViewModel FiltrarCertificados, out int totalResultado)
        {
            var pageSize = 3000;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_CERTIFIDETA entQuery = new BE.SIC_CERTIFIDETA()
            {
                CODCERTIFICADO = FiltrarCertificados.FiltrarCodigoCertificado,
                CODANOCERTI = FiltrarCertificados.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODTIPOCERTI = FiltrarCertificados.FiltrarCodigoTipoCertificado,
            };
            ICollection<BE.SIC_CERTIFIDETA> srcQuery = new BL.SIC_CERTIFIDETA().Buscar(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CERTIFIDETA>();
            }
            int indice = 1;
            var lisDataQuery = new List<CertificadosDetalleViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CertificadosDetalleViewModel
                {
                    Item = indice.ToString(),
                    FiltrarCodigoCorrelativo = item.CODCORRELCERT,
                    NombreVia = item.TXTNOMVIA,
                    CodigoVia = item.CODVIA,
                    TipoVia = item.TXTTIPOVIA,

                    NombreViaEsq = item.TXTNOMVIAESQ,
                    CodigoViaEsq = item.CODVIAESQ,
                    TipoViaEsq = item.TXTTIPOVIAESQ,

                    NombreViaAnt = item.TXTNOMVIAANT,
                    TipoViaAnt = item.TXTTIPOVIAANT,


                    NombreViaEsqAnt = item.TXTNOMVIAESQANT,
                    TipoViaEsqAnt = item.TXTTIPOVIAESQANT

                });
                indice++;
            }
            return lisDataQuery;
        }
        public CertificadosViewModel RecuperarGrabarCertificado(CertificadosViewModel FiltrarCertificados, out bool resul)
        {
            BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
            {
                CODCERTIFICADO = FiltrarCertificados.FiltrarCodigoCertificado,
                CODTIPOCERTI = FiltrarCertificados.FiltrarCodigoTipoCertificado,
                CODANOCERTI = FiltrarCertificados.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
            };
            BE.SIC_CERTIFICADO srcQuery = new BL.SIC_CERTIFICADO().Recuperar(entQuery);
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarCertificados.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCertificados.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarCertificados.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = FiltrarCertificados.CodAnioSolicitud, // System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            CertificadosViewModel lisDataQuery;
            if (srcQuerySol == null)
            {
                lisDataQuery = new CertificadosViewModel();
                resul = false;
            }
            else
            {
                BE.SIC_SOLUNIDAD entQueryUni = new BE.SIC_SOLUNIDAD()
                {
                    CODTIPOSOLI = FiltrarCertificados.FiltrarCodigoTipoSolicitud,
                    CODNUMESOLI = FiltrarCertificados.FiltrarNumeroSolicitud,
                    CODANOSOLI = FiltrarCertificados.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
                    CODUNI = Convert.ToInt32(FiltrarCertificados.CodigoUnico)
                };
                if (FiltrarCertificados.FiltrarCodigoTipoDocumentoReg != "REQI") { entQueryUni.CTIPODOCUMENTO = FiltrarCertificados.FiltrarCodigoTipoDocumentoReg; }
                entQueryUni.ESTATICO = true;
                BE.SIC_SOLUNIDAD srcQueryUni = new BL.SIC_SOLUNIDAD().Listar(entQueryUni);
                string CodigoCatastralTemp = srcQueryUni.CODDISTRITO + srcQueryUni.CODSECTOR + srcQueryUni.CODMANZANA + srcQueryUni.CODLOTE + srcQueryUni.CODEDIFICACION + srcQueryUni.CODENTRADA + srcQueryUni.CODPISO + srcQueryUni.CODUNIDAD;

                entQuery.TXTUNIDAD = srcQueryUni.CODDEPARTAMENTO + srcQueryUni.CODPROVINCIA + CodigoCatastralTemp;
                BE.SIC_CERTIFICADO srcQueryCerti = new BL.SIC_CERTIFICADO().RecuperarUrbanizacion(entQuery);
                if (srcQuery == null)
                {
                    srcQuery = new BE.SIC_CERTIFICADO();
                }
                string[] Partida = { };
                if (srcQuery.TXTPARTIDA != null)
                {
                    Partida = srcQuery.TXTPARTIDA.Split('|');
                }
                lisDataQuery = new CertificadosViewModel();
                lisDataQuery.FiltrarCodigoPeriodo = (string.IsNullOrEmpty(FiltrarCertificados.FiltrarCodigoPeriodo)? System.DateTime.Now.Year.ToString() : FiltrarCertificados.FiltrarCodigoPeriodo);
                lisDataQuery.CodAnioSolicitud =  FiltrarCertificados.CodAnioSolicitud;
                lisDataQuery.CodigoCatastral = CodigoCatastralTemp;
                lisDataQuery.CodigoUnico = srcQueryUni.CODUNIDAD;
                lisDataQuery.CodigoOficina = srcQuery.CODOFICINA;
                lisDataQuery.NombreAnio = srcQuery.TXTANIO;
                lisDataQuery.Urbanizacion = srcQueryCerti.TXTURBANIZACION;
                lisDataQuery.FechaGeneracion = ((!string.IsNullOrEmpty(srcQuery.FECCERTIFICADO)) ? DateTime.Parse(srcQuery.FECCERTIFICADO).ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"));
                lisDataQuery.NumeroSolicitud = FiltrarCertificados.FiltrarNumeroSolicitud;
                lisDataQuery.FiltrarCodigoCertificado = srcQuery.CODCERTIFICADO;
                lisDataQuery.Direccion = srcQuery.TXTUNIDADDIREC;
                lisDataQuery.CUC = srcQueryUni.TXTCUC;
                lisDataQuery.Solicitante = srcQuery.TXTSOLICITANTE;
                lisDataQuery.TipoPersonas = srcQuery.CODPEREMISION;


                if (FiltrarCertificados.FiltrarCodigoTipoCertificado != "CNMU")
                {
                    lisDataQuery.Anotaciones = (srcQuery.TXTOBSERV != null) ? srcQuery.TXTOBSERV.Replace("|", "") : "";
                }
                else
                {
                    lisDataQuery.Anotaciones = (srcQuery.TXTOBSERV != null) ? srcQuery.TXTOBSERV.Replace("|", "\n") : "";
                }

                lisDataQuery.Nivel = srcQuery.TXTNIVEL;
                lisDataQuery.NivelDescripcion = srcQuery.TXTDESCRIPVIVIENDA;
                lisDataQuery.Interior = srcQuery.TXTINTERIOR;
                lisDataQuery.CodigoHojaCatastral = srcQuery.TXTCODHOJACATAS;

                lisDataQuery.TipoInscripcion = srcQuery.CODTIPINSC;
                lisDataQuery.Recibo = srcQuery.TXTRECIBO;
                //lisDataQuery.FechaPago = srcQuery.FECPAGO;
                lisDataQuery.HojaPlano = srcQuery.TXTHOJAPLANO;
                lisDataQuery.EscalaPlano = srcQuery.TXTESCAPLANO;

                lisDataQuery.FechaPago = (srcQuery.FECPAGO != null) ? srcQuery.FECPAGO.Value.ToString("dd/MM/yyyy") : "";

                lisDataQuery.Partida = Partida;
                lisDataQuery.PartidaString = srcQuery.TXTPARTIDA;

                lisDataQuery.ListTipoUbicacion = new List<SelectListItem>();
                lisDataQuery.ListTipoInspectores = new List<SelectListItem>();
                lisDataQuery.ListTitulares = new List<SelectListItem>();
                lisDataQuery.ListDiasProgramados = new List<SelectListItem>();
                lisDataQuery.ListTipoInscripcion = new List<SelectListItem>() {
                    new SelectListItem() {Text = "ACUMULACIÓN" , Value = "010001"},
                    new SelectListItem() {Text = "SUB-DIVISIÓN" , Value = "010002"},
                    new SelectListItem() {Text = "INMATRICULACIÓN" , Value = "010003"}
                };
                lisDataQuery.ListTipoPersona = new CertificadosHandler().ListadoTipoPersona();
                resul = true;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> CargarUnidadRRPP(string CodigoUnico, string Tipo)
        {

            BE.SIC_UNIDADRRPP entQuery = new BE.SIC_UNIDADRRPP();
            entQuery.CODUNI = CodigoUnico == "" ? 0 : Convert.ToInt32(CodigoUnico);

            //entQuery.ESTATICO = true;
            ICollection<BE.SIC_UNIDADRRPP> listsrcQuery = new BL.SIC_UNIDADRRPP().Listar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in listsrcQuery)
            {
                string partidaTemp = (item.TXTPARTELEC != "null") ? item.TXTPARTELEC : "--";
                string folioTemp = (item.TXTFOLIO != "null") ? item.TXTFOLIO : " -- ";
                string tomoTemp = (item.TXTTOMOFICH != "null") ? item.TXTTOMOFICH : " -- ";
                string asientoTemp = (item.TXTASIENTO != "null") ? item.TXTASIENTO : " -- ";
                string valueTemp = (Tipo == "1") ? item.TXTTIPODOCU + "|" + partidaTemp + "|" + tomoTemp + "|" + folioTemp + "|" + asientoTemp : item.TXTTIPODOCU + " PARTIDA: " + partidaTemp + " TOMO: " + tomoTemp + " FOJA: " + folioTemp + " ASIENTO: " + asientoTemp;
                lisDataQuery.Add(new SelectListItem
                {
                    Value = valueTemp,
                    Text = item.TXTTIPODOCU + " PARTIDA: " + partidaTemp + " TOMO: " + tomoTemp + " FOJA: " + folioTemp + " ASIENTO: " + asientoTemp
                    //Fecha = (item.FECDOCUMENTO != null) ? item.FECDOCUMENTO.Value.ToString("yyyy-MM-dd") : "",
                    //Folio = item.TXTFOLIO,
                    //Asiento = item.TXTASIENTO,
                    //CodigoCorrelativo = item.CODCORRUNIDRRPP,
                    //CodigoCorrelativoLote = item.CODCORRLOTERRPP,
                    //Ruta = item.TXTNOMDOCUINT,
                });
            }
            return lisDataQuery;
        }
        public BE.SIC_RETORNO CrearCertificado(CertificadosViewModel Informe)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODANOSOLI =  Informe.FiltrarCodigoPeriodo,
                CODTIPODOC = Informe.FiltrarCodigoTipoDocumentoReg
            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);

            if (srcQuerySol != null)
            {
                string numTramite = null;
                if (Informe.FiltrarCodigoTipoSolicitud != "010003")
                {
                    BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                    {
                        VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                        VTIPO_DOCUMENTO = Informe.FiltrarCodigoTipoCertificado,
                        TXTASUNTO = (srcQuerySol.TXTASUNTO != null) ? srcQuerySol.TXTASUNTO : "",
                        VUSUARIO = VariablesWeb.IdUsuarioIntento,
                        VCONTRIBUYENTE = srcQuerySol.CODIGO_CONTRIBUYENTE,
                        NUMFOLIO = srcQuerySol.NUMFOLSOL,
                        VCOD_ACTIVIDAD = srcQuerySol.COD_ACCION
                    };
                    BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().ObtenerDocumento(entQueryExt);
                    numTramite = entSIC_RETORNO_INT.CODIGO;
                }



                BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
                {
                    CODCERTIFICADO = Informe.FiltrarCodigoCertificado,
                    CODTIPOCERTI = Informe.FiltrarCodigoTipoCertificado,
                    CODANOCERTI = (string.IsNullOrEmpty(Informe.FiltrarCodigoPeriodo) ? System.DateTime.Now.Year.ToString() : Informe.FiltrarCodigoPeriodo), // System.DateTime.Now.Year.ToString(),
                    CODANOSOLI = Informe.CodAnioSolicitud,
                    CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                    TXTCODIGOUNICO = Informe.CodigoUnico,
                    FECCERTIFICADO = DateTime.Now.ToString("dd-MM-yyyy"),
                    CODTRAMITE = numTramite,
                    CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                    CTIPODOCUMENTO = (Informe.FiltrarCodigoTipoSolicitud != "010003") ? Informe.FiltrarCodigoTipoDocumentoReg : "REQI",
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };
                entSIC_RETORNO = new BL.SIC_CERTIFICADO().Grabar(entQuery);
            }
            else
            {
                entSIC_RETORNO.Ok = false;
                entSIC_RETORNO.MENSAJE = "La solicitud ingresada no existe en el sistema";
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
        public BE.SIC_RETORNO GrabarCertificado(CertificadosViewModel Informe, out string codigo)
        {
            BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
            {
                CODCERTIFICADO = Informe.FiltrarCodigoCertificado,
                CODTIPOCERTI = Informe.FiltrarCodigoTipoCertificado,
                //CODANOCERTI = (string.IsNullOrEmpty(Informe.FiltrarCodigoPeriodo) ? System.DateTime.Now.Year.ToString() : Informe.FiltrarCodigoPeriodo), //System.DateTime.Now.Year.ToString(),
                CODANOCERTI = Informe.FiltrarCodigoPeriodo,
            };
            BE.SIC_CERTIFICADO srcQuery = new BL.SIC_CERTIFICADO().Recuperar(entQuery);
            string Estado = "2";
            if (srcQuery == null)
            {
                srcQuery = new BE.SIC_CERTIFICADO();
                srcQuery.CODTIPOCERTI = Informe.FiltrarCodigoTipoCertificado;
                srcQuery.CODANOCERTI = (string.IsNullOrEmpty(Informe.FiltrarCodigoPeriodo) ? System.DateTime.Now.Year.ToString() : Informe.FiltrarCodigoPeriodo); //System.DateTime.Now.Year.ToString();
                srcQuery.CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud;
                srcQuery.CODNUMESOLI = Informe.FiltrarNumeroSolicitud;
                srcQuery.CODANOSOLI = Informe.CodAnioSolicitud; //System.DateTime.Now.Year.ToString();
                Estado = "1";
            }
            srcQuery.TXTUNIDAD = Informe.CodigoCatastral;
            srcQuery.TXTCODIGOUNICO = Informe.CodigoUnico;
            srcQuery.TXTURBANIZACION = Informe.Urbanizacion;
            srcQuery.TXTMANZANAURB = Informe.ManzanaUrbana;
            srcQuery.TXTLOTEURB = Informe.LoteUrbano;
            srcQuery.TXTCUC = Informe.CUC;
            srcQuery.TXTSUBLOTEURB = Informe.SubLoteUrbano;
            srcQuery.TXTSOLICITANTE = Informe.Solicitante;
            srcQuery.CODPEREMISION = Informe.TipoPersonas;
            string anotaciones = Informe.Anotaciones;
            if (srcQuery.CODTIPOCERTI != "CNMU")
            {
                if (anotaciones != null)
                {
                    anotaciones = Regex.Replace(anotaciones, "\n\\s+\n\\s+\n", "\n");
                    anotaciones = Regex.Replace(anotaciones, "\n\n\n", "\n");
                    anotaciones = Regex.Replace(anotaciones, "\n\\s+\n", "\n");
                    anotaciones = Regex.Replace(anotaciones, "\n\n", "\n");
                    int lineaReal = 0;
                    bool insertado = false;

                    int ind1 = anotaciones.IndexOf("\n", 0);
                    if (ind1 != -1)
                    {
                        lineaReal = EvaluarSalto(ind1);
                        if (lineaReal >= 3)
                        {
                            anotaciones = "|" + anotaciones;
                            insertado = true;
                        }
                        int ind2 = anotaciones.IndexOf("\n", ind1 + 1);
                        if (ind2 != -1)
                        {
                            lineaReal = lineaReal + EvaluarSalto(ind1);
                            if (insertado == false && lineaReal >= 3)
                            {
                                anotaciones = anotaciones.Substring(0, ind2) + "|" + anotaciones.Substring(ind2);
                                insertado = true;
                            }
                            int ind3 = anotaciones.IndexOf("\n", ind2 + 1);
                            if (ind3 != -1)
                            {
                                lineaReal = lineaReal + EvaluarSalto(ind1);
                                if (insertado == false && lineaReal >= 3)
                                {
                                    anotaciones = anotaciones.Substring(0, ind3) + "|" + anotaciones.Substring(ind3);
                                    insertado = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (anotaciones != null)
                {
                    anotaciones = anotaciones.Replace('\n', '|');
                }
            }

            srcQuery.TXTOBSERV = anotaciones;
            if (srcQuery.CODTIPOCERTI == "CNMU")
            {
                srcQuery.TXTOBSERV = anotaciones + "|";
            }

            srcQuery.TXTINTERIOR = Informe.Interior;
            srcQuery.TXTCODHOJACATAS = Informe.CodigoHojaCatastral;
            srcQuery.TXTDESCRIPVIVIENDA = Informe.NivelDescripcion;
            srcQuery.TXTNIVEL = Informe.Nivel;
            srcQuery.TXTRECIBO = Informe.Recibo;
            srcQuery.TXTHOJAPLANO = Informe.HojaPlano;
            srcQuery.TXTESCAPLANO = Informe.EscalaPlano;
            srcQuery.CODTIPINSC = Informe.TipoInscripcion;
            if (Informe.FechaPago != null)
            {
                srcQuery.FECPAGO = Convert.ToDateTime(Informe.FechaPago);
            }
            //srcQuery.FECCERTIFICADO = "";
            srcQuery.FECCERTIFICADO = (string.IsNullOrEmpty(Informe.FechaGeneracion) ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(Informe.FechaGeneracion).ToString("dd-MM-yyyy"));

            srcQuery.TXTPARTIDA = (Informe.Partida != null) ? string.Join("/", Informe.Partida) : "";
            srcQuery.TXTUNIDADDIREC = Informe.Direccion;
            srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;

            srcQuery.CODTIPODOC = Informe.FiltrarCodigoTipoDocumentoReg;
            srcQuery.CTIPODOCUMENTO = Informe.FiltrarCodigoTipoDocumentoReg;
            string numTramite = null;
            if (Estado != "2")
            {
                BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
                {
                    CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                    CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                    CODANOSOLI = Informe.CodAnioSolicitud, // System.DateTime.Now.Year.ToString(),
                    CODTIPODOC = Informe.FiltrarCodigoTipoDocumentoReg
                };
                BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
                BE.PGD_TRAMITE_INT entQueryExt = new BE.PGD_TRAMITE_INT()
                {
                    VFECHA = System.DateTime.Now.ToString("dd/MM/yyyy"),
                    VTIPO_DOCUMENTO = (Informe.FiltrarCodigoTipoCertificado != "CEAC") ? Informe.FiltrarCodigoTipoCertificado : "PLAN",
                    TXTASUNTO = (srcQuerySol.TXTASUNTO != null) ? srcQuerySol.TXTASUNTO : "",
                    VUSUARIO = VariablesWeb.IdUsuarioIntento,
                    VCONTRIBUYENTE = srcQuerySol.CODIGO_CONTRIBUYENTE,
                    NUMFOLIO = srcQuerySol.NUMFOLSOL,
                    VCOD_ACTIVIDAD = srcQuerySol.COD_ACCION
                };
                BE.SIC_RETORNO entSIC_RETORNO_INT = new BL.PGD_TRAMITE_INT().ObtenerDocumento(entQueryExt);
                numTramite = entSIC_RETORNO_INT.CODIGO;

            }
            srcQuery.CODTRAMITE = numTramite;

            BE.SIC_RETORNO entSIC_RETORNO = (Estado == "2") ? new BL.SIC_CERTIFICADO().Actualizar(srcQuery) : new BL.SIC_CERTIFICADO().Grabar(srcQuery);
            codigo = (Estado == "2") ? Informe.FiltrarCodigoCertificado : entSIC_RETORNO.CODIGO;
            RegistrarArchivos registrarArchivos = new RegistrarArchivos()
            {
                FiltrarCodigoCertificado = codigo,
                FiltrarCodigoTipoCertificado = Informe.FiltrarCodigoTipoCertificado,
                FiltrarCodigoPeriodo = (string.IsNullOrEmpty(Informe.FiltrarCodigoPeriodo) ? System.DateTime.Now.Year.ToString() : Informe.FiltrarCodigoPeriodo),
                Actualizar = (Estado == "2") ? true : false,
            };
            string rut = "";
            var local = GrabarCertificadoServer(registrarArchivos, out rut);
            entSIC_RETORNO.MENSAJE = rut.Substring(0, rut.Length - 4);


            return entSIC_RETORNO;
        }
        public Nullable<bool> GrabarCertificadoServer(RegistrarArchivos Informe, out string Ruta)
        {
            #region Subir archivo
            string repo = "DOCUMENTOS"; string tiporepo = "CERTIFICADOS\\PERIODO\\SOLICITUD";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;

            _Ext = "pdf";
            string tempCodigo = Informe.FiltrarCodigoTipoCertificado + Informe.FiltrarCodigoCertificado + Informe.FiltrarCodigoPeriodo;
            string tempCodigo1 = Informe.FiltrarCodigoTipoCertificado + "," + Informe.FiltrarCodigoCertificado + "," + Informe.FiltrarCodigoPeriodo;
            string aleatorio = Guid.NewGuid().ToString();
            string _FN = tempCodigo + "_" + "CARTA_DOC" + aleatorio + "." + _Ext;
            _Codigo = tempCodigo + "_" + "CARTA_DOC" + aleatorio;

            _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
            BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
            {
                TXTNOMTABLA = "SIC_CERTIFICADO",
                CODPKTABLA = tempCodigo1,
                TXTPKTABLANOM = "CODTIPOCERTI,CODCERTIFICADO,CODANOCERTI",
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
                ICollection<BE.SIC_DETAFILESERVER> srcData = new BL.SIC_DETAFILESERVER().Recuperar(entQueryDeta); var data = srcData.ToList();
                if (srcData.Count == 0) { srcData = new List<BE.SIC_DETAFILESERVER>(); }
                else { entQueryDeta.CODCORRELFS = data[data.Count - 1].CODCORRELFS; }
                entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Actualizar(entQueryDeta);
            }

            subida = true;

            #endregion
            Ruta = _Ruta;
            return subida;
        }
        public int EvaluarSalto(int indice)
        {
            int linea = 180;
            if (indice > linea * 3) { return 4; }
            else if (indice > linea * 2) { return 3; }
            else if (indice > linea) { return 2; }
            else if (indice <= linea) { return 1; }
            else { return 0; }
        }
        public Nullable<bool> GrabarCertificadoDetalle(List<CertificadosDetalleViewModel> Informe)
        {
            int contProceso = 0;
            if (Informe != null)
            {
                foreach (CertificadosDetalleViewModel ItemDetalle in Informe)
                {
                    var datosEncontrados = true;
                    BE.SIC_CERTIFIDETA entQuery = new BE.SIC_CERTIFIDETA()
                    {
                        CODCERTIFICADO = ItemDetalle.FiltrarCodigoCertificado,
                        CODTIPOCERTI = ItemDetalle.FiltrarCodigoTipoCertificado,
                        CODCORRELCERT = ItemDetalle.FiltrarCodigoCorrelativo,
                        CODANOCERTI = ItemDetalle.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                    };
                    BE.SIC_CERTIFIDETA srcQuery = new BL.SIC_CERTIFIDETA().Recuperar(entQuery);
                    if (srcQuery == null)
                    {
                        srcQuery = entQuery;
                        datosEncontrados = false;
                    }
                    srcQuery.TXTNOMVIA = ItemDetalle.NombreVia;
                    srcQuery.TXTNOMVIAANT = ItemDetalle.NombreViaAnt;
                    srcQuery.TXTNOMVIAESQ = ItemDetalle.NombreViaEsq;
                    srcQuery.TXTTIPOVIA = ItemDetalle.NombreTipoVia;
                    srcQuery.TXTTIPOVIAANT = ItemDetalle.TipoViaAnt;
                    srcQuery.TXTTIPOVIAESQ = ItemDetalle.TipoViaEsq;
                    srcQuery.CODVIA = ItemDetalle.CodigoVia;
                    srcQuery.TXTNIVEL = (ItemDetalle.Nivel != null) ? ItemDetalle.Nivel.ToUpper() : "";
                    srcQuery.TXTINSCRIPCION = ItemDetalle.DescripcionInscrip;
                    srcQuery.TXTDESCRIPCION = ItemDetalle.DescripcionInscrip;
                    srcQuery.TXTTIPOPUERTA = ItemDetalle.TipoPuerta;
                    srcQuery.TXTBLOQTE = ItemDetalle.TipoInterior;
                    srcQuery.TXTINTERIOR = ItemDetalle.Interior;
                    srcQuery.TXTNUMERO = ItemDetalle.NumeroPuerta;
                    srcQuery.CODVIAESQ = ItemDetalle.CodigoViaEsq;
                    srcQuery.CODUNI = Convert.ToInt32(ItemDetalle.CodigoUni);
                    srcQuery.CODCORRUNIDDIREINTE = ItemDetalle.CodigoCorrelativoUnidad;
                    srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                    srcQuery.TXTNOMVIAESQANT = ItemDetalle.NombreViaEsqAnt;
                    srcQuery.TXTTIPOVIAESQANT = ItemDetalle.TipoViaEsqAnt;

                    BE.SIC_RETORNO entSIC_RETORNO;
                    //entSIC_RETORNO = new BL.SIC_LOTEEXPEDOCU().Eliminar(srcQuery);
                    if (ItemDetalle.Marcado == "0")
                    {
                        entSIC_RETORNO = new BL.SIC_CERTIFIDETA().Eliminar(srcQuery);
                    }
                    else
                    {
                        entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_CERTIFIDETA().Actualizar(srcQuery) : new BL.SIC_CERTIFIDETA().Grabar(srcQuery);
                    }
                    if (entSIC_RETORNO.Ok == false)
                    {
                        contProceso++;
                    }
                }

            }
            return (contProceso == 0) ? true : false;
        }
        public Nullable<bool> EliminarCertificado(CertificadosViewModel Detalle)
        {
            BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
            {
                CODCERTIFICADO = Detalle.FiltrarCodigoCertificado,
                CODTIPOCERTI = Detalle.FiltrarCodigoTipoCertificado,
                CODANOCERTI = Detalle.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CERTIFICADO().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> EliminarCertificadoDetalle(CertificadosDetalleViewModel Detalle)
        {
            BE.SIC_CERTIFIDETA entQuery = new BE.SIC_CERTIFIDETA()
            {
                CODCERTIFICADO = Detalle.FiltrarCodigoCertificado,
                CODTIPOCERTI = Detalle.FiltrarCodigoTipoCertificado,
                CODCORRELCERT = Detalle.FiltrarCodigoCorrelativo,
                CODANOCERTI = Detalle.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CERTIFIDETA().Eliminar(entQuery);
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
        public List<CertificadosViewModel> RecuperarSolicitud(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODNROINSPEC = FiltrarSolUnidad.FiltrarNumeroInspeccion,
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),

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
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);

            var data = srcQuery.ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
            }
            var lisDataQuery = new List<CertificadosViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CertificadosViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    HoraInspeccion = item.TXTHORAINSP,
                    FiltrarCodigoTipoSolicitud = item.CODTIPOSOLI,
                    CalidadVerificacion = item.CODNROINSPEC + '-' + System.DateTime.Now.Year.ToString() + '-' + item.NUMCALVER,
                    Solicitante = srcQuerySol.TXTSOLICITANTE,
                    //NombreTipoLlenado = item.TXTNOMBRELLENADO,
                    FechaInspeccion = (item.FECINSPE != null) ? item.FECINSPE.Value.ToString("dd/MM/yyyy") : "",
                });
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarViasEsquinas(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_LOTELINDEROVIADET entQuery = new BE.SIC_LOTELINDEROVIADET()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODLADO = FiltrarSolUnidad.CodigoLado,
                CODVIA = FiltrarSolUnidad.CodigoVia
            };
            entQuery.ESTATICO = true;
            ICollection<BE.SIC_LOTELINDEROVIADET> srcQuery = new BL.SIC_LOTELINDEROVIADET().BuscarVias(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_LOTELINDEROVIADET>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new SolicitudUnidadViewModel
                {
                    Ubicacion = item.TXTTIPOVIA + " " + item.TXTVIA,
                    Unidad = item.CODVIA + "|" + item.TXTTIPOVIA + "|" + item.TXTVIA + "|" + item.TXTTIPOVIAANT + "|" + item.TXTVIAANTE

                });
            }
            return lisDataQuery;
        }
        public string RecuperarUrbanizacion(CertificadosViewModel FiltrarSolUnidad)
        {

            BE.SIC_LOTEHABIURBA entQuery = new BE.SIC_LOTEHABIURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote
            };
            entQuery.ESTATICO = true;
            List<BE.SIC_LOTEHABIURBA> srcQuery = new BL.SIC_LOTEHABIURBA().Buscar(entQuery);

            BE.SIC_UNIDAD entQueryUni = new BE.SIC_UNIDAD()
            {
                CODUNI = Convert.ToInt32(FiltrarSolUnidad.CodigoUnico)
            };
            entQueryUni.ESTATICO = true;
            BE.SIC_UNIDAD srcQueryUni = new BL.SIC_UNIDAD().Recuperar(entQueryUni);
            string InscripcionCatastral = "";
            if (srcQueryUni != null)
            {
                InscripcionCatastral = srcQueryUni.TXTINSCCATA;
            }


            BE.SIC_LOTE entQueryLote = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote
            };
            BE.SIC_LOTE srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);

            if (srcQueryLote == null)
            {
                entQueryLote.ESTATICO = true;
                srcQueryLote = new BL.SIC_LOTE().Recuperar(entQueryLote);
            }



            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_LOTEHABIURBA>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            string NombreHabilitacionTemp = "";

            string NombreHabilitacion = "";
            string NombreManzana = "";
            string tipoHab = "";
            foreach (var item in data)
            {
                if (FiltrarSolUnidad.FiltrarCodigoTipoCertificado == "CEJU")
                {
                    tipoHab = item.TXTHABILITAURBA + " ";
                }

                if (NombreHabilitacionTemp == item.TXTURBANIZACION)
                {
                    NombreManzana = NombreManzana + "/" + item.TXTMANZAURB;
                }
                else
                {
                    //tipoHab = item.txt
                    NombreHabilitacion = NombreHabilitacion + "|" + tipoHab + item.TXTURBANIZACION;
                    NombreManzana = NombreManzana + "|" + item.TXTMANZAURB;
                }
                NombreHabilitacionTemp = item.TXTURBANIZACION;
            }
            string nomhab = (NombreHabilitacion == "") ? NombreHabilitacion : NombreHabilitacion.Substring(1);
            string nomman = (NombreManzana == "") ? NombreManzana : NombreManzana.Substring(1);
            return nomhab + "|" + nomman + "|" + srcQueryLote.TXTLOTEURBA + "|" + srcQueryLote.TXTSUBLOTEURBA + "|" + InscripcionCatastral;
        }
        public List<CertificadosDetalleViewModel> CargarDirecUnidadVias(CertificadosViewModel FiltrarSolUnidad)
        {
            #region Obtener dato
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
                //CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                //CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                //CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODEDIFICACION = FiltrarSolUnidad.CodigoEdificacion,
                CODENTRADA = FiltrarSolUnidad.CodigoEntrada,
                CODPISO = FiltrarSolUnidad.CodigoPiso,
                CODUNIDAD = FiltrarSolUnidad.CodigoUnidad,

                CODCERTIFICADO = FiltrarSolUnidad.FiltrarCodigoCertificado,
                CODANOCERTI = FiltrarSolUnidad.FiltrarCodigoPeriodo, // System.DateTime.Now.Year.ToString(),
                CODTIPOCERTI = FiltrarSolUnidad.FiltrarCodigoTipoCertificado,

            };
            ICollection<BE.SIC_SOLUNIDAD> srcQuery;
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            if (FiltrarSolUnidad.FiltrarCodigoTipoCertificado == "RNUM")
            {
                srcQuery = new BL.SIC_SOLUNIDAD().BuscarCertiFilter(entQuery);
            }
            else
            {
                srcQuery = new BL.SIC_SOLUNIDAD().BuscarCerti(entQuery);
            }

            #endregion

            var data = srcQuery.ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            int indice = 1;
            var lisDataQuery = new List<CertificadosDetalleViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CertificadosDetalleViewModel
                {
                    NombreVia = RepNulos(item.TXTVIA),
                    NombreTipoVia = RepNulos(item.TXTTIPODEVIA),
                    DescripcionInscrip = (item.TXTDESCRIPCION != null) ? item.TXTDESCRIPCION : "-",
                    NombreViaAnt = (item.TXTVIAANTE == null) ? "" : item.TXTVIAANTE,
                    FiltrarCodigoCorrelativo = RepNulos(item.CODCORRELCERT),
                    TipoInterior = (item.TXTIPOINTERIOR != null) ? item.TXTIPOINTERIOR : "-",
                    Interior = EvalNull2(item.TXTNUMERO, item.TXTLETRA),
                    CodigoTipoInterior = RepNulos(item.CODTIPOINTE),
                    TipoPuerta = RepNulos(item.TXTTIPOPUERTA),
                    Nivel = (item.TXTNIVEL == null) ? "" : item.TXTNIVEL,
                    NumeroPuerta = EvalNull2(item.TXTNUMEROPUERTA, item.TXTLETRAPUERTA),
                    CodigoVia = RepNulos(item.CODVIA),
                    NombreViaEsq = ""

                });
                indice++;
            }
            return lisDataQuery;
        }
        public string EvalNull(string val1, string val2)
        {
            if (val1 != null && val2 != null)
            {
                return val1 + "-" + val2;
            }
            else if (val1 != null)
            {
                return val1;
            }
            else
            {
                return val2;
            }
        }
        public string EvalNull2(string val1, string val2)
        {
            if (val1 != null && val2 != null)
            {
                return val1 + "-" + val2;
            }
            else if (val1 != null)
            {
                return val1;
            }
            else if (val2 != null)
            {
                return val2;
            }
            else
            {
                return "-";
            }
        }
        public List<CertificadosDetalleViewModel> CargarDirecUnidad(DataTableAjaxPostModel model, CertificadosViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 1000;
            var skip = model.start;

            #region Obtener dato
            BE.SIC_CERTIFIDETA entQuery = new BE.SIC_CERTIFIDETA()
            {
                CODUNI = Convert.ToInt32(FiltrarSolUnidad.CodigoUnico),
                CODCERTIFICADO = FiltrarSolUnidad.FiltrarCodigoCertificado,
                CODANOCERTI = FiltrarSolUnidad.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODTIPOCERTI = FiltrarSolUnidad.FiltrarCodigoTipoCertificado,

            };
            ICollection<BE.SIC_CERTIFIDETA> srcQuery = new BL.SIC_CERTIFIDETA().BuscarCertificados(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CERTIFIDETA>();
            }
            int indice = 1;
            var lisDataQuery = new List<CertificadosDetalleViewModel>();
            var puertaViaTemp = "";
            foreach (var item in data)
            {
                //if (puertaViaTemp != item.TXTNUMERO+item.TXTLETRA+item.TXTNUMEROPUERTA + item.CODVIA) { 
                lisDataQuery.Add(new CertificadosDetalleViewModel
                {
                    FiltrarCodigoCertificado = FiltrarSolUnidad.FiltrarCodigoPeriodo,
                    CodAnioSolicitud = FiltrarSolUnidad.CodAnioSolicitud,
                    NombreVia = item.TXTVIA,
                    NombreViaAnt = (item.TXTVIAANTE == null) ? "" : item.TXTVIAANTE,
                    NombreViaAntReal = (item.TXTNOMVIAANT == null) ? "" : item.TXTNOMVIAANT,
                    FiltrarCodigoCorrelativo = item.CODCORRELCERT,
                    TipoInterior = item.TXTIPOINTERIOR,
                    Interior = EvalNull(item.TXTNUMERO, item.TXTLETRA),
                    CodigoTipoInterior = item.CODTIPOINTE,
                    TipoPuerta = item.TXTTIPOPUERTA,
                    NumeroPuerta = EvalNull(item.TXTNUMEROPUERTA, item.TXTLETRAPUERTA),
                    CodigoVia = item.CODVIA,
                    Nivel = item.TXTNIVEL,
                    CodigoUni = item.CODUNI.ToString(),
                    CodigoCorrelativoUnidad = item.CODCORRUNIDDIREINTE,
                    NombreTipoVia = item.TXTTIPODEVIA,
                    DescripcionInscrip = item.TXTDESCRIPCION,
                    Edificacion = item.TXTABREVANT,
                    NombreViaEsq = ""

                });
                // }
                puertaViaTemp = item.TXTNUMERO + item.TXTLETRA + item.TXTNUMEROPUERTA + item.CODVIA;
                indice++;
            }
            return lisDataQuery;
        }
        public bool? ProcesarRecibo(CertificadosReciboViewModel Recibo)
        {

            #region Asignar a la Entidad
            BE.SIC_CERTIFIRECI entQuery = new BE.SIC_CERTIFIRECI()
            {

                CODCERTIFICADO = Recibo.FiltrarCodigoCertificado,
                CODTIPOCERTI = Recibo.FiltrarCodigoTipoCertificado,
                CODCORRELCERE = Recibo.FiltrarCodigoCorrelativo,
                CODANOCERTI = Recibo.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                TXTRECIBO = Recibo.NumeroRecibo,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            if (Recibo.FechaRecibo != null) entQuery.FECRECIBO = DateTime.Parse(Recibo.FechaRecibo);
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (Recibo.Estado)
            {
                case "1": entSIC_RETORNO = new BL.SIC_CERTIFIRECI().Grabar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_CERTIFIRECI().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
        public List<CertificadosReciboViewModel> CargarRecibos(DataTableAjaxPostModel model, CertificadosViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 3000;
            var skip = model.start;

            #region Obtener dato
            BE.SIC_CERTIFIRECI entQuery = new BE.SIC_CERTIFIRECI()
            {
                CODCERTIFICADO = FiltrarSolUnidad.FiltrarCodigoCertificado,
                CODANOCERTI = FiltrarSolUnidad.FiltrarCodigoPeriodo, //System.DateTime.Now.Year.ToString(),
                CODTIPOCERTI = FiltrarSolUnidad.FiltrarCodigoTipoCertificado,
            };
            ICollection<BE.SIC_CERTIFIRECI> srcQuery = new BL.SIC_CERTIFIRECI().Buscar(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_CERTIFIRECI>();
            }
            int indice = 1;
            var lisDataQuery = new List<CertificadosReciboViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new CertificadosReciboViewModel
                {
                    Item = Convert.ToString(indice),
                    NumeroRecibo = item.TXTRECIBO,
                    Correlativo = item.CODCORRELCERE,
                    FechaRecibo = (item.FECRECIBO != null) ? item.FECRECIBO.Value.ToString("dd/MM/yyyy") : "",
                    FiltrarCodigoPeriodo = FiltrarSolUnidad.FiltrarCodigoPeriodo,
                    CodAnioSolicitud = FiltrarSolUnidad.CodAnioSolicitud,
                });

                indice++;
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> CargarDirecLote(DataTableAjaxPostModel model, CertificadosViewModel FiltrarSolUnidad, out int totalResultado)
        {
            var pageSize = 3000;
            var skip = model.start;

            #region Obtener dato
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODEDIFICACION = FiltrarSolUnidad.CodigoEdificacion,
                CODENTRADA = FiltrarSolUnidad.CodigoEntrada,
                CODPISO = FiltrarSolUnidad.CodigoPiso,
                CODUNIDAD = FiltrarSolUnidad.CodigoUnidad,

            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarSolicitud(entQuery);

            entQuery.CODSECTOR = FiltrarSolUnidad.CodigoCatastral.Substring(2, 2);
            entQuery.CODMANZANA = FiltrarSolUnidad.CodigoCatastral.Substring(4, 3);
            entQuery.CODLOTE = FiltrarSolUnidad.CodigoCatastral.Substring(7, 3);
            ICollection<BE.SIC_SOLUNIDAD> srcQueryTitulares = new BL.SIC_SOLUNIDAD().BuscarTitulares(entQuery);
            var dataTitulares = srcQueryTitulares.Skip(skip).Take(pageSize).ToList();
            if (srcQueryTitulares.Count == 0) { srcQueryTitulares = new List<BE.SIC_SOLUNIDAD>(); }
            var titulares = "";
            var tipoTitulares = "";
            int conTitulares = 0;
            foreach (var item in dataTitulares)
            {
                if (conTitulares == 0)
                {
                    titulares = item.TXTTITULARES; tipoTitulares = item.TXTTIPOPROPIETARIO;
                }
                else
                {
                    titulares = titulares + "<br>" + item.TXTTITULARES;
                    tipoTitulares = tipoTitulares + "<br>" + item.TXTTIPOPROPIETARIO;
                }
                conTitulares++;
            }
            #endregion
            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0) { srcQuery = new List<BE.SIC_SOLUNIDAD>(); }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            var tempCodigoCatastral = "";
            var tempLoteCodigoCatastral = "";
            foreach (var item in data)
            {
                if (tempLoteCodigoCatastral != item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE)
                {
                    lisDataQuery.Add(new SolicitudUnidadViewModel
                    {

                        //CodigoCatastral = tempCodigoCatastral + "|" + item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE + item.CODEDIFICACION + item.CODENTRADA + item.CODPISO + item.CODUNIDAD,
                        LoteCodigoCatastral = item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE,
                        CodigoDistrito = item.CODDISTRITO,
                        CodigoSector = item.CODSECTOR,
                        CodigoManzana = item.CODMANZANA,
                        CodigoLote = item.CODLOTE,
                        Ed = item.CODEDIFICACION,
                        Entrada = item.CODENTRADA,
                        Piso = item.CODPISO,
                        Unidad = item.CODUNIDAD,
                        CodigoUni = item.CODUNI,
                        CodigoCorrelativo = "",
                        CodigoPeriodo = item.CODANOSOLI,
                        CodigoTipoSolicitud = item.CODTIPOSOLI,
                        CodigoNumeroSolicitud = item.CODNUMESOLI,
                        Ubicacion = (item.TXTDIRECCION == null) ? "" : item.TXTDIRECCION,
                        Titular = titulares,
                        TipoPropietario = tipoTitulares
                    });
                }
                //<br>3101015002010101001
                lisDataQuery.Last().CodigoCatastral = item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE + item.CODEDIFICACION + item.CODENTRADA + item.CODPISO + item.CODUNIDAD + "<br>" + lisDataQuery.Last().CodigoCatastral;
                tempCodigoCatastral = item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE + item.CODEDIFICACION + item.CODENTRADA + item.CODPISO + item.CODUNIDAD;
                tempLoteCodigoCatastral = item.CODDISTRITO + item.CODSECTOR + item.CODMANZANA + item.CODLOTE;
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarUbicacion(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                //CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
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
            foreach (var item in data)
            {
                lisDataQuery.Add(new SolicitudUnidadViewModel
                {
                    Ubicacion = (item.TXTDIRECCION == null) ? "" : item.TXTDIRECCION,
                    Unidad = item.FLGLOTEESQU + "|" + item.CODVIA + "|" + item.TXTVIA + "|" + item.TXTVIAANTE
                });
            }
            return lisDataQuery;
        }

        public List<SolicitudUnidadViewModel> RecuperarUbicacionTipo(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarDirecCerti(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            string tempUbi = "";
            foreach (var item in data)
            {
                if (item.TXTVIA != tempUbi)
                {
                    lisDataQuery.Add(new SolicitudUnidadViewModel
                    {
                        Ubicacion = (item.TXTTIPOVIA + item.TXTVIA == null) ? "" : item.TXTTIPOVIA + " " + item.TXTVIA,
                        Unidad = item.FLGLOTEESQU + "|" + item.CODVIA + "|" + item.TXTTIPOVIA + "|" + item.TXTVIA + "|" + item.TXTTIPOVIAANT + "|" + item.TXTVIAANTE
                    });
                }
                tempUbi = item.TXTVIA;
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarUbicacionSel(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
            };
            BE.SIC_LOTE entQueryLoteGen = new BE.SIC_LOTE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote
            };
            //entQueryLoteGen.ESTATICO = true;
            BE.SIC_LOTE srcQueryLoteGen = new BL.SIC_LOTE().Recuperar(entQueryLoteGen);

            BE.SIC_LOTEHABIURBA entQueryLote = new BE.SIC_LOTEHABIURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote
            };
            //entQueryLote.ESTATICO = true;
            List<BE.SIC_LOTEHABIURBA> srcQueryLote = new BL.SIC_LOTEHABIURBA().Buscar(entQueryLote);

            string ManzanaUrba = "";
            foreach (var item in srcQueryLote) { ManzanaUrba = ManzanaUrba + "/" + item.TXTMANZAURB; }
            if (ManzanaUrba != "") { ManzanaUrba = ManzanaUrba.Substring(1); }

            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") { entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg; }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarDirec(entQuery); var data = srcQuery.ToList();

            string CodigoCatastralTemp = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0') + FiltrarSolUnidad.CodigoSector + FiltrarSolUnidad.CodigoManzana + FiltrarSolUnidad.CodigoLote + FiltrarSolUnidad.CodigoEdificacion + FiltrarSolUnidad.CodigoEntrada + FiltrarSolUnidad.CodigoPiso + FiltrarSolUnidad.CodigoUnidad;

            BE.SIC_CERTIFICADO entQueryCerti = new BE.SIC_CERTIFICADO();
            entQueryCerti.TXTUNIDAD = entQueryLote.CODDEPARTAMENTO + entQueryLote.CODPROVINCIA + CodigoCatastralTemp;
            BE.SIC_CERTIFICADO srcQueryCerti = new BL.SIC_CERTIFICADO().RecuperarUrbanizacion(entQueryCerti);
            if (srcQueryCerti == null) { srcQueryCerti = new BE.SIC_CERTIFICADO(); }

            if (srcQuery.Count == 0) { srcQuery = new List<BE.SIC_SOLUNIDAD>(); }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            string unidadTemp = "";
            foreach (var item in data)
            {
                if (unidadTemp != (item.CODTIPOVIA) + "|" + RepNulos(item.TXTVIA) + "|" + RepNulos(item.TXTNUMEROPUERTA + item.TXTLETRAPUERTA) + "|" + RepNulos(item.TXTNUMERO + item.TXTLETRA) + "|" + RepNulos(srcQueryLoteGen.TXTLOTEURBA) + "|" + RepNulos(ManzanaUrba) + "|" + RepNulos(srcQueryCerti.TXTURBANIZACION) + "|SAN ISIDRO|LIMA|LIMA")
                {
                    lisDataQuery.Add(new SolicitudUnidadViewModel
                    {
                        Ubicacion = (item.TXTDIRECCION == null) ? "" : item.TXTTIPOVIA + " " + item.TXTVIA + " " + item.TXTNUMEROPUERTA,
                        Unidad = RepNulos(item.CODTIPOVIA) + "|" + RepNulos(item.TXTVIA) + "|" + RepNulos(item.TXTNUMEROPUERTA + item.TXTLETRAPUERTA) + "|" + RepNulos(item.TXTNUMERO + item.TXTLETRA) + "|" + RepNulos(srcQueryLoteGen.TXTLOTEURBA) + "|" + RepNulos(ManzanaUrba) + "|" + RepNulos(srcQueryCerti.TXTURBANIZACION) + "|SAN ISIDRO|LIMA|LIMA"
                    });
                }
                unidadTemp = RepNulos(item.CODTIPOVIA) + "|" + RepNulos(item.TXTVIA) + "|" + RepNulos(item.TXTNUMEROPUERTA + item.TXTLETRAPUERTA) + "|" + RepNulos(item.TXTNUMERO + item.TXTLETRA) + "|" + RepNulos(srcQueryLoteGen.TXTLOTEURBA) + "|" + RepNulos(ManzanaUrba) + "|" + RepNulos(srcQueryCerti.TXTURBANIZACION) + "|SAN ISIDRO|LIMA|LIMA";

            }
            return lisDataQuery;
        }
        public string RepNulos(string cadena)
        {
            if (cadena == null || cadena == "")
            {
                return "-";
            }
            return cadena;
        }
        public List<SolicitudUnidadViewModel> RecuperarSolUnidad(CertificadosViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                //CODANOSOLI = FiltrarSolUnidad.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODEDIFICACION = FiltrarSolUnidad.CodigoEdificacion,
                CODENTRADA = FiltrarSolUnidad.CodigoEntrada,
                CODPISO = FiltrarSolUnidad.CodigoPiso,
                CODUNIDAD = FiltrarSolUnidad.CodigoUnidad,

            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
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
                    Ubicacion = (item.TXTDIRECCION == null) ? "" : item.TXTDIRECCION,
                    Titular = item.TXTTITULARES,
                });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> RecuperarDiasProg(CertificadosViewModel FiltrarCartas)
        {
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarCartas.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
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
        public List<SelectListItem> ListarNumeroInspeccionSelect(CertificadosViewModel FiltrarCartas)
        {
            BE.SIC_PROGINSPEC entQuery = new BE.SIC_PROGINSPEC()
            {
                CODTIPOSOLI = FiltrarCartas.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarCartas.FiltrarNumeroSolicitud,
                CODANOSOLI = FiltrarCartas.CodAnioSolicitud, //System.DateTime.Now.Year.ToString(),
            };
            if (FiltrarCartas.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarCartas.FiltrarCodigoTipoDocumentoReg;
            }
            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ListarNumero(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem { Value = item.CODNROINSPEC, Text = item.CODNROINSPEC.Substring(0, 4) + "-" + item.CODNROINSPEC.Substring(4) });
            }
            return lisDataQuery;
        }

        public Nullable<bool> GrabarHabilitacionImagen(ImagenCertificado Certificado, out string correlativo)
        {
            BE.SIC_CERTIFICADO entQuery = new BE.SIC_CERTIFICADO()
            {
                CODANOCERTI = Certificado.FiltrarCodigoPeriodo,
                CODTIPOCERTI = Certificado.FiltrarCodigoTipoCertificado,
                CODCERTIFICADO = Certificado.FiltrarCodigoCertificado,
            };
            BE.SIC_CERTIFICADO srcQuery = new BL.SIC_CERTIFICADO().Recuperar(entQuery);

            #region Subir archivo
            var archivo = Certificado.Archivo;
            string carpeta = string.Format("\\{0}\\{1}\\{2}\\{3}\\{4}\\", "DOCUMENTOS", "CERTIFICADOS", entQuery.CODCERTIFICADO, entQuery.CODTIPOCERTI, entQuery.CODANOCERTI);
            if (!Directory.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);

            if (archivo != null)
            {
                string _NombreArchivo = Path.GetFileName(archivo.FileName);
                string NombreArchivo = string.Format("{0}{1}{2}_{3}{4}", entQuery.CODCERTIFICADO, entQuery.CODTIPOCERTI, entQuery.CODANOCERTI, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(archivo.FileName) ?? ".dat");

                srcQuery.TXTRUTAIMAGEN = Path.Combine(carpeta, NombreArchivo);
                BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CERTIFICADO().Actualizar(srcQuery);

                BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                {
                    TXTNOMTABLA = "SIC_CERTIFICADO",
                    CODPKTABLA = string.Format("{0}{1}{2}", entQuery.CODCERTIFICADO, entQuery.CODTIPOCERTI, entQuery.CODANOCERTI),
                    TXTPKTABLANOM = "CODCERTIFICADO,CODTIPOCERTI,CODANOCERTI",
                    TXTEXTENSION = Path.GetExtension(archivo.FileName) ?? ".dat",
                    TXTRUTA = Path.Combine(carpeta, NombreArchivo),
                    FLGPRINCIPAL = "1",
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };
                BE.SIC_RETORNO entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Grabar(entQueryDeta);
                archivo.SaveAs(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta + NombreArchivo);
                correlativo = "1";
                return true;
            }
            else
            {
                correlativo = null;
                return false;
            }

            #endregion
        }

        public string VerImagenHabilitacion(string carpeta)
        {
            #region Subir archivo

            if (File.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
            {
                //using (Image image = Image.FromFile(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                //{
                //using (MemoryStream m = new MemoryStream())
                //{
                //    image.Save(m, image.RawFormat);
                //    byte[] imageBytes = m.ToArray();

                var base64Img = new Base64Image
                {
                    FileContents = File.ReadAllBytes(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta),
                    ContentType = "image/png"
                };
                // Convert byte[] to Base64 String
                return base64Img.ToString();
                //}
                //}
            }
            else
            {
                return "";
            }
            #endregion
        }
    }
    public class Base64Image
    {
        public static Base64Image Parse(string base64Content)
        {
            if (string.IsNullOrEmpty(base64Content))
            {
                throw new ArgumentNullException((base64Content));
            }

            int indexOfSemiColon = base64Content.IndexOf(";", StringComparison.OrdinalIgnoreCase);

            string dataLabel = base64Content.Substring(0, indexOfSemiColon);

            string contentType = dataLabel.Split(':').Last();

            var startIndex = base64Content.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;

            var fileContents = base64Content.Substring(startIndex);

            var bytes = Convert.FromBase64String(fileContents);

            return new Base64Image
            {
                ContentType = contentType,
                FileContents = bytes
            };
        }

        public string ContentType { get; set; }

        public byte[] FileContents { get; set; }

        public override string ToString()
        {
            return "data:" + ContentType + ";base64," + Convert.ToBase64String(FileContents);
        }
    }
}