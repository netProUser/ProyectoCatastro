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
using System.Globalization;
using System.Configuration;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Informes
{
    public class InformesHandler
    {

        public BE.SIC_RETORNO CrearInforme(InformesViewModel Informe)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODTIPODOC = (Informe.FiltrarCodigoTipoSolicitud != "010003") ? Informe.FiltrarCodigoTipoDocumentoReg : "REQI",
            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);

            BE.SIC_INFORME entInforme = new BE.SIC_INFORME()
            {
                CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme
            };

            if (srcQuerySol != null)
            {
                string numTramite = null;
                
                //{
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
                    if (Informe.FiltrarCodigoTipoInforme == "INFT") {
                        numTramite = null;
                    }
                
                //{
                //    BE.SIC_INFORME srcQueryTot = new BL.SIC_INFORME().RecuperarNumeroRegistro(entInforme);
                //    numTramite = srcQueryTot.ITEM + '-' + System.DateTime.Now.Year.ToString() + "-" + "1220";
                //}

                BE.SIC_INFORME entQuery = new BE.SIC_INFORME()
                {
                    CODINFORME = "0001",
                    CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
                    CODTRAMITE = numTramite,
                    //CODCORRCARTA = Informe.FiltrarCodigoCorrelativo,
                    CODANOINFO = System.DateTime.Now.Year.ToString(),
                    CODANOSOLI = System.DateTime.Now.Year.ToString(),
                    CODNUMESOLI = Informe.FiltrarNumeroSolicitud,
                    CODTIPOSOLI = Informe.FiltrarCodigoTipoSolicitud,
                    CTIPODOCUMENTO = Informe.FiltrarCodigoTipoDocumentoReg,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                };
                entSIC_RETORNO = new BL.SIC_INFORME().Grabar(entQuery);
            }
            else {
                entSIC_RETORNO.Ok = false;
                entSIC_RETORNO.MENSAJE = "La solicitud ingresada no existe en el sistema";
            }
            return entSIC_RETORNO;
        }
        public Nullable<bool> GrabarInformeServer(RegistrarArchivos Informe, out string Ruta, out string Ext)
        {
            #region Subir archivo
            var archivo = Informe.File;
            string repo = "DOCUMENTOS"; string tiporepo = "INFORMES\\PERIODO\\SOLICITUD";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                if (Informe.documento != null)
                {
                    //string _NombreArchivo = Path.GetFileName(archivo.FileName);
                    string _NombreArchivo = "PDFView.pdf";
                    string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                    _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                    _Ext = _Ext.Substring(1);
                    string tempCodigo1 = Informe.FiltrarCodigoTipoInforme + "," + Informe.FiltrarCodigoInforme + "," + Informe.FiltrarCodigoCorrelativo + "," + Informe.FiltrarCodigoPeriodo;
                    string tempCodigo = Informe.FiltrarCodigoTipoInforme + Informe.FiltrarCodigoInforme + Informe.FiltrarCodigoCorrelativo + Informe.FiltrarCodigoPeriodo;
                    string aleatorio = Guid.NewGuid().ToString();
                    string _FN = tempCodigo + "_" + "INFORME_DOC" + aleatorio + "." + _Ext;
                    _Codigo = tempCodigo + "_" + "INFORME_DOC" + aleatorio;

                    _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                    BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                    {
                        TXTNOMTABLA = "SIC_INFORME",
                        CODPKTABLA = tempCodigo1,
                        TXTPKTABLANOM = "CODTIPOINFORME,CODINFORME,CODCORRINFO,CODANOINFO",
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
                    else {
                        ICollection<BE.SIC_DETAFILESERVER> srcData = new BL.SIC_DETAFILESERVER().Recuperar(entQueryDeta);
                        var data = srcData.ToList();
                        if (srcData.Count == 0) {
                            srcData = new List<BE.SIC_DETAFILESERVER>();
                        } else {
                            entQueryDeta.CODCORRELFS = data[data.Count - 1].CODCORRELFS;
                        }
                        entSIC_RETORNO_DETA = new BL.SIC_DETAFILESERVER().Actualizar(entQueryDeta);
                    }

                    System.IO.File.WriteAllBytes(@_Ruta, Informe.documento);
                    //File.WriteAllBytes(@_Ruta, Informe.documento);
                    //archivo.SaveAs(_Ruta);
                }
                subida = true;
            
            #endregion
            Ruta = _Codigo;
            Ext = _Ext;
            return subida;
        }
        public byte[] RecuperarLoteImagen(string Ruta)
        {
           
            
            //var path = @"C:\ARCHIVOS\REPOSIC\2018\JULIO\MSICAS20180709122321316.png";
            var path = Ruta;
            byte[] archivo = null;
            if (path != null)
            {
                //try
                //{
                //    try
                //    {
                        archivo = System.IO.File.ReadAllBytes(path);
                //    }
                //    catch (System.IO.DirectoryNotFoundException ex)
                //    {
                //        Console.WriteLine(ex);
                //    }
                //}
                //catch (FileNotFoundException ex)
                //{
                //    Console.WriteLine(ex);
                //}
            }
            else
            {
                return null;
            }
            return archivo;
        }
        public Nullable<bool> GrabarLoteImagen(RegistrarArchivos Lote, out string Ruta, out string Ext)
        {
            #region Subir archivo
            var archivo = Lote.File;
            string repo = "DOCUMENTOS"; string tiporepo = "INFORMES\\IMAGENES";
            string carpeta = "\\" + repo + "\\" + tiporepo; string _Ruta = ""; string _Codigo = ""; string _Ext = "";

            if (!Directory.Exists(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            bool subida;
            
                if (archivo != null)
                {
                    string _NombreArchivo = Path.GetFileName(archivo.FileName);
                    string _Date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string _Nombre = Path.GetFileNameWithoutExtension(Regex.Replace(_NombreArchivo, @"(\s+|@|&|'|\(|\)|<|>|#)", "").Replace(" ", "").Substring(0, 6));
                    _Ext = Path.GetExtension(_NombreArchivo) ?? ".dat";
                    _Ext = _Ext.Substring(1);
                    string tempCodigo = Lote.FiltrarCodigoTipoInforme + Lote.FiltrarCodigoInforme + Lote.FiltrarCodigoCorrelativo + Lote.FiltrarCodigoPeriodo;
                    string aleatorio = Guid.NewGuid().ToString();
                    string _FN = tempCodigo + "_" + "INFORME" + aleatorio + "." + _Ext;
                    _Codigo = tempCodigo + "_" + "INFORME" + aleatorio;

                    _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
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
                    archivo.SaveAs(_Ruta);
                }
                subida = true;
            
            #endregion
            Ruta = _Codigo;
            Ext = _Ext;
            return subida;
        }
        public List<InformesViewModel> RecargarTablaInformes(DataTableAjaxPostModel model, InformesViewModel FiltrarInspecciones, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_INFORME entQuery = new BE.SIC_INFORME()
            {
                CODINFORME = "0001",
                CODTIPOSOLI = FiltrarInspecciones.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarInspecciones.FiltrarNumeroSolicitud,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODANOSOLI = FiltrarInspecciones.FiltrarCodigoPeriodo,
                CODTIPOINFOR = FiltrarInspecciones.FiltrarCodigoTipoInforme,
                CTIPODOCUMENTO = FiltrarInspecciones.FiltrarCodigoTipoDocumentoReg,
            };
            ICollection<BE.SIC_INFORME> srcQuery = new BL.SIC_INFORME().BuscarInformes(entQuery);

            
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_INFORME>();
            }
            int indice = 1;
            var lisDataQuery = new List<InformesViewModel>();
            var correlativo = "0";
            foreach (var item in data)
            {
                if (item.CODTRAMITE == null) {
                    //correlativo = srcQueryTot.ITEM + "-" + item.FECREG.Value.Year.ToString() + "-1220";
                    correlativo = item.CODCORRINFO + "-" + item.FECREG.Value.Year.ToString() + "-1220";
                } else {
                    correlativo = item.CODTRAMITE;
                    
                }
                lisDataQuery.Add(new InformesViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    FiltrarCodigoTipoInforme = item.CODTIPOINFOR,
                    FiltrarCodigoInforme = item.CODINFORME,
                    CodigoCatastral = (item.TXTCODIGOCATASTRAL != null) ? item.TXTCODIGOCATASTRAL.Replace(",","<br>") : "",
                    Asunto = item.TXTASUNTO,
                    UbicacionPredio = (item.TXTUBICACION != null ) ? item.TXTUBICACION.Replace(",", "<br>") : "",
                    FechaGeneracion = item.TXTFECHAGENERACION,
                    CodigoOficina = item.CODOFICINA,
                    CodigoDocumentoGenerado = item.CODDOCUMGEN,
                    CodigoUsuario = item.CODUSUARIO,
                    Bloqueado = item.CODESTADOFINAL,
                    Documento = "",
                    FiltrarCodigoCorrelativo = item.CODCORRINFO,
                    CodigoCorrelativoTramite = correlativo,
                    Item = indice.ToString(),
                });
                indice++;
            }
            return lisDataQuery;
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
        public InformesViewModel RecuperarGrabarInformes(InformesViewModel FiltrarInformes, out bool resul)
        {
            BE.SIC_INFORME entQuery = new BE.SIC_INFORME() {
                CODTIPOINFOR = FiltrarInformes.FiltrarCodigoTipoInforme,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODINFORME = "0001",
                CODCORRINFO = FiltrarInformes.FiltrarCodigoCorrelativo
            };
            BE.SIC_INFORME srcQuery = new BL.SIC_INFORME().Recuperar(entQuery);
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarInformes.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarInformes.FiltrarNumeroSolicitud,
                CODTIPODOC = FiltrarInformes.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);



            InformesViewModel lisDataQuery = lisDataQuery = new InformesViewModel();
            if (srcQuerySol == null) {
                resul = false;
            } else {

                lisDataQuery.NombreSigla = srcQuery.TXTSIGLA;
                lisDataQuery.Asunto = srcQuery.TXTASUNTO;
                lisDataQuery.Unidades = srcQuery.TXTUNIDADES;
                lisDataQuery.CodigoCatastral = srcQuery.TXTUNIDAD;
                lisDataQuery.CodigoUnidad = srcQuery.TXTCODIGOUNICO;
                lisDataQuery.UbicacionPredio = srcQuery.TXTUNIDADDIREC;
                lisDataQuery.TitularCatastral = srcQuery.TXTUNIDADTITULAR;

                lisDataQuery.NombreFirma = srcQuery.TXTNOMBREFIRMA;
                lisDataQuery.Solicitante = srcQuery.TXTSOLICITANTE;
                lisDataQuery.DescripcionInforme = srcQuery.TXTDESCRIPCIONINFORME;
                lisDataQuery.NombreOficina = srcQuery.TXTOFICINA;
                lisDataQuery.FiltrarCodigoInforme = srcQuery.CODINFORME;
                lisDataQuery.TipoPersonas = srcQuery.CODPEREMISION;
                lisDataQuery.NroCalidadVerificacion = srcQuery.NROCALIDADVERIFICACION;
                //lisDataQuery.ListTipoPersona = lisDataQueryTipo;

                resul = true;
            }
            return lisDataQuery;
        }
        public List<RegistrarInformeDetalle> CargarSubDetalle(InformesViewModel Detalle)
        {
            BE.SIC_INFORMESUBDETA entQuery = new BE.SIC_INFORMESUBDETA()
            {
                CODTIPOINFOR = Detalle.FiltrarCodigoTipoInforme,
                CODINFORME = Detalle.FiltrarCodigoInforme,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODCORRELDETA = Detalle.FiltrarCodigoCorrelativo
            };
            ICollection<BE.SIC_INFORMESUBDETA> srcQuery = (Detalle.FiltrarCodigoTipoInforme == "" && Detalle.FiltrarCodigoInforme == "") ? new List<BE.SIC_INFORMESUBDETA>() : new BL.SIC_INFORMESUBDETA().Buscar(entQuery);
            var lisDataQuery = new List<RegistrarInformeDetalle>();
            int cont = 0;
            foreach (var item in srcQuery)
            {
                cont++;
                lisDataQuery.Add(new RegistrarInformeDetalle
                {
                    SubDetalle = item.TXTSUBDETALLE,
                    Item = cont.ToString(),
                    SubTitulo = item.TXTSUBTITULO,
                    CodigoSubCorrelativo = item.CODSUBDETA,
                    CodigoCorrelativo = item.CODCORRELDETA,
                });
            }
            return lisDataQuery;
        }
        public List<RegistrarInformeDetalle> CargarDetalle(InformesViewModel Detalle)
        {
            BE.SIC_INFORMEDETA entQuery = new BE.SIC_INFORMEDETA()
            { 
                CODTIPOINFOR = Detalle.FiltrarCodigoTipoInforme,
                CODINFORME = "0001",
                CODCORRINFO = Detalle.FiltrarCodigoCorrelativo,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
            };
            ICollection<BE.SIC_INFORMEDETA> srcQuery = (Detalle.FiltrarCodigoTipoInforme == "" && Detalle.FiltrarCodigoInforme == "") ? new List<BE.SIC_INFORMEDETA>() : new BL.SIC_INFORMEDETA().Buscar(entQuery);
            var lisDataQuery = new List<RegistrarInformeDetalle>();
            int cont  = 0;
            var contexto = System.Web.HttpContext.Current.Request.ApplicationPath;
            foreach (var item in srcQuery)
            {
                cont++;
                string output = item.TXTDETALLE;
                if (item.TXTDETALLE != null) {
                    Regex regex = new Regex(@"src=.(.[a-zA-Z]*)");
                    Match match = regex.Match(item.TXTDETALLE);
                    if (match.Success)
                    {
                        string key = match.Groups[1].Value;
                        if (key.Substring(0, 4).ToUpper() == "/MSI") {
                            output = Regex.Replace(item.TXTDETALLE, key, contexto);
                        } else {
                            output = Regex.Replace(item.TXTDETALLE, key, contexto + key);
                        }
                        output = output.Replace("//", "/");
                    }
                }
                lisDataQuery.Add(new RegistrarInformeDetalle
                {
                    Detalle = output,
                    Item = cont.ToString(),
                    Titulo = item.TXTTITULO,
                    CodigoCorrelativo = item.CODCORRELDETA,
                    SubTitulo = item.TXTSUBTITULO,
                    CodigoTipoDetalle = item.CODTIPODETALLE
                });
                

            }
            return lisDataQuery;
        }
        public Nullable<bool> GrabarInforme(InformesViewModel Informe)
        {
            BE.SIC_INFORME entQuery = new BE.SIC_INFORME()
            {
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
                CODCORRINFO = Informe.FiltrarCodigoCorrelativo,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODINFORME = Informe.FiltrarCodigoInforme,
            };
            BE.SIC_INFORME srcQuery = new BL.SIC_INFORME().Recuperar(entQuery);

            string nuevoTemp = srcQuery.CODDOCUMGEN;

            srcQuery.CODOFICINA = Informe.CodigoOficina;
            srcQuery.TXTSIGLA = Informe.NombreSigla;
            srcQuery.CODCARCAT = VariablesWeb.CodigoPerfil;
            srcQuery.CODPERSONA = VariablesWeb.IdUsuarioIntento;
            if (VariablesWeb.NombrePerfil != null) srcQuery.TXTCARGOFIRMA = ToTitleCase(VariablesWeb.NombrePerfil);
            srcQuery.TXTANIO = Informe.NombreAnio;
            if (Informe.NombreFirma != null) srcQuery.TXTNOMBREFIRMA = ToTitleCase(Informe.NombreFirma);
            if (Informe.FechaInspeccion != null) srcQuery.FECINSPECCION = DateTime.Parse(Informe.FechaInspeccion);
            srcQuery.TXTTIPOLLENADO = Informe.NombreTipoLlenado;
            srcQuery.TXTASUNTO = Informe.Asunto;
            srcQuery.TXTUNIDAD = Informe.CodigoCatastral;
            srcQuery.TXTCODIGOUNICO = Informe.CodigoUnico;
            srcQuery.TXTUNIDADDIREC = Informe.UbicacionPredio;
            srcQuery.TXTUNIDADTITULAR = Informe.TitularCatastral;
            srcQuery.TXTSOLICITANTE = Informe.Solicitante;
            srcQuery.TXTUNIDADES = Informe.Unidades;
            srcQuery.CODDOCUMGEN = "1";
            srcQuery.CODPEREMISION = Informe.TipoPersonas;
            if (Informe.NombreOficina != null) srcQuery.TXTOFICINA = ToTitleCase(Informe.NombreOficina);
            srcQuery.TXTDESCRIPCIONINFORME = Informe.DescripcionInforme;
            srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
            srcQuery.NROCALIDADVERIFICACION = Informe.NroCalidadVerificacion;
            GrabarInformeUnidad(Informe);
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_INFORME().Actualizar(srcQuery);

            Byte[] pdfBytes = new InformePdfHandler().VerificacionPdfSharpConvert(Informe.FiltrarCodigoTipoInforme, "0001", Informe.FiltrarCodigoCorrelativo, System.DateTime.Now.Year.ToString());
            string filename = "PDFView.pdf";
            RegistrarArchivos registrarArchivos = new RegistrarArchivos()
            {
                FiltrarCodigoInforme = "0001",
                FiltrarCodigoTipoInforme = Informe.FiltrarCodigoTipoInforme,
                FiltrarCodigoCorrelativo = Informe.FiltrarCodigoCorrelativo,
                FiltrarCodigoPeriodo = System.DateTime.Now.Year.ToString(),
                Actualizar = (nuevoTemp == "1") ? true : false,
                archivo = (HttpPostedFileBase)new MemoryPostedFile(pdfBytes, filename),
                documento = pdfBytes
            };
            string rut = "", ex = "";
            var local = GrabarInformeServer(registrarArchivos, out rut, out ex);

            
            return entSIC_RETORNO.Ok;
        }
        private bool GrabarInformeUnidad(InformesViewModel Informe)
        {
            var Unidades = (Informe.CodigoCatastral != null) ? Informe.CodigoCatastral.Split('|') : new string[0];
            var CodigoUnico = (Informe.CodigoUnico != null) ? Informe.CodigoUnico.Split('|') : new string[0];
            BE.SIC_DOCUUNIDAD entQuery = new BE.SIC_DOCUUNIDAD();
            int contUnidades = 0;
            foreach (var Item in Unidades) 
            {
                var Codigo = Item.Split('-');

                entQuery.CODANOINFORCARTA = System.DateTime.Now.Year.ToString();
                entQuery.CODCORRINFORCARTA = Informe.FiltrarCodigoCorrelativo;
                entQuery.CODINFORCARTA = Informe.FiltrarCodigoInforme;
                entQuery.CODTIPOINFORCARTA = Informe.FiltrarCodigoTipoInforme;
                entQuery.NROCALIDADVERIFICACION = Informe.NroCalidadVerificacion;
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
        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
        public InformesViewModel CargarSolicitante(InformesViewModel FiltrarSolicitud)
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

            InformesViewModel InformeSoli = new InformesViewModel()
            {
                NombreSolicitante = srcQuerySoli.TXTSOLICITANTE,
                NombreRepresentante = srcQuerySoli.TXTREPRESENTANTEL
            };
            return InformeSoli;
            
        }
        public List<InformesViewModel> RecuperarSolicitud(InformesViewModel FiltrarSolUnidad)
        {
            #region Buscar Solicitud
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud, CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud, CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD entQuerySoli = new BE.SIC_SOLICITUD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud, CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud, CODTIPODOC = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            BE.SIC_SOLICITUD srcQuerySol = new BL.SIC_SOLICITUD().Recuperar(entQuerySoli);
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") { entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;   }
            ICollection<BE.SIC_SOLISEGUI> srcQuery = new BL.SIC_SOLISEGUI().Informe(entQuery);
            #endregion
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLISEGUI>();
            }
            var lisDataQuery = new List<InformesViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new InformesViewModel
                {
                    FiltrarNumeroSolicitud = item.CODNUMESOLI,
                    FiltrarCodigoTipoSolicitud = item.CODTIPOSOLI,
                    NombreTipoLlenado = item.TXTNOMBRELLENADO,
                    Solicitante = srcQuerySol.TXTSOLICITANTE,
                    FechaInspeccion = (item.FECINSPE != null) ? item.FECINSPE.Value.ToString("yyyy-MM-dd") : "",
                });
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarSolUnidad(InformesViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                
            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") { entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;  }
            if (FiltrarSolUnidad.FiltrarCodigoTipoInforme != "INFV") {
                FiltrarSolUnidad.Estatico = true;
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
                    Titular = (item.TXTTITULARES == null) ? "" : item.TXTTITULARES,
                });
            }
            return lisDataQuery;
        }
        public List<SolicitudUnidadViewModel> RecuperarUbicacion(InformesViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarSolUnidad.CodigoSector,
                CODMANZANA = FiltrarSolUnidad.CodigoManzana,
                CODLOTE = FiltrarSolUnidad.CodigoLote,
                CODENTRADA = FiltrarSolUnidad.CodigoEntrada,
                CODEDIFICACION = FiltrarSolUnidad.CodigoEdificacion,
                CODPISO = FiltrarSolUnidad.CodigoPiso,
                CODUNIDAD = FiltrarSolUnidad.CodigoUnidad
            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI")
            {
                entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg;
            }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarDirecTemp(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SolicitudUnidadViewModel>();
            string direccion;
            string tempUbicacion = "";
            foreach (var item in data)
            {
                direccion = item.TXTTIPOVIA + " " + item.TXTVIA + " " + item.TXTTIPOPUERTA + " " + item.TXTNUMEROPUERTA + " " + item.TXTTIPOINTERIOR + " " +  item.TXTNUMERO + item.TXTLETRA;
                if (direccion != tempUbicacion) { 
                    lisDataQuery.Add(new SolicitudUnidadViewModel
                    {
                        Ubicacion = (direccion == null) ? "" : direccion,
                    });
                }
                tempUbicacion = direccion;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> RecuperarSolUnidadSelect(InformesViewModel FiltrarSolUnidad)
        {
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODTIPOSOLI = FiltrarSolUnidad.FiltrarCodigoTipoSolicitud,
                CODNUMESOLI = FiltrarSolUnidad.FiltrarNumeroSolicitud,
                CODANOSOLI = System.DateTime.Now.Year.ToString(),

            };
            if (FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg != "REQI") { entQuery.CTIPODOCUMENTO = FiltrarSolUnidad.FiltrarCodigoTipoDocumentoReg; }
            ICollection<BE.SIC_SOLUNIDAD> srcQuery = new BL.SIC_SOLUNIDAD().BuscarSolicitud(entQuery);
            var data = srcQuery.ToList();
            //ICollection<BE.SIC_SOLUNIDAD> data = new List<BE.SIC_SOLUNIDAD>();
            if (srcQuery.Count == 0)
            {
                srcQuery = new List<BE.SIC_SOLUNIDAD>();
            }
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in data)
            {
                string codcat = item.CODDISTRITO + "-" + item.CODSECTOR + "-" + item.CODMANZANA + "-" + item.CODLOTE + "-" + item.CODEDIFICACION + "-" + item.CODENTRADA + "-" + item.CODPISO + "-" + item.CODUNIDAD;
                string direccion = (item.TXTDIRECCION == null) ? "" : item.TXTDIRECCION;
                string titular = item.TXTAPEPAT + " " + item.TXTAPEMAT + " " + item.TXTNOMBRE;
                lisDataQuery.Add(new SelectListItem
                {
                    Value = codcat + "_" + item.CODUNI + "|" + direccion + "*" + titular,
                    Text = codcat + " - " + direccion + " - "  + titular
                });
            }
            return lisDataQuery;
        }
        public Nullable<bool> GrabarInformeSubDetalle(List<RegistrarInformeDetalle> Detalle)
        {
            #region Asignar a la Entidad
            int cont = 0;
            foreach (var item in Detalle)
            {
                BE.SIC_INFORMESUBDETA entQuery = new BE.SIC_INFORMESUBDETA()
                {
                    CODINFORME = item.CodigoInforme,
                    CODANOINFO = System.DateTime.Now.Year.ToString(),
                    CODTIPOINFOR = item.CodigoTipoInforme,
                    CODCORRELDETA = item.CodigoCorrelativo,
                    CODSUBDETA = item.CodigoSubCorrelativo,
                    TXTSUBTITULO = item.SubTitulo,
                    TXTSUBDETALLE = (item.SubDetalle != null) ? JustifyText(item.SubDetalle) : "",
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                };
                if (cont == 0)
                {
                    BE.SIC_RETORNO entSIC_RETORNODEL = new BL.SIC_INFORMESUBDETA().EliminarDetalle(entQuery);
                }
                BE.SIC_RETORNO entSIC_RETORNO;
                entSIC_RETORNO = (entQuery.CODSUBDETA != null) ? new BL.SIC_INFORMESUBDETA().Actualizar(entQuery) : new BL.SIC_INFORMESUBDETA().Grabar(entQuery);
                cont++;
            }
            #endregion
            return true;

        }
        public Nullable<bool> GrabarInformeSubDetalleUnique(RegistrarInformeDetalle Detalle)
        {
            #region Asignar a la Entidad
            
            BE.SIC_INFORMESUBDETA entQuery = new BE.SIC_INFORMESUBDETA()
            {
                CODINFORME = Detalle.CodigoInforme,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODTIPOINFOR = Detalle.CodigoTipoInforme,
                CODCORRELDETA = Detalle.CodigoCorrelativo,
                CODSUBDETA = Detalle.CodigoSubCorrelativo,
                TXTSUBTITULO = Detalle.SubTitulo,
                TXTSUBDETALLE = (Detalle.SubDetalle != null) ? JustifyText(Detalle.SubDetalle) : "",
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_INFORMESUBDETA().Actualizar(entQuery);
            #endregion
            return entSIC_RETORNO.Ok;

        }
        public Nullable<bool> ProcesarDetalle(RegistrarInformeDetalle Detalle, out string correlativo)
        {
            #region Asignar a la Entidad
            BE.SIC_INFORMEDETA entQuery = new BE.SIC_INFORMEDETA()
            {
                CODINFORME = "0001",
                CODANOINFO = Detalle.CodigoPeriodo,
                CODTIPOINFOR = Detalle.CodigoTipoInforme,
                CODCORRINFO = Detalle.CodigoSubCorrelativo,
                CODCORRELDETA  = Detalle.CodigoCorrelativo,
                TXTTITULO = Detalle.Titulo,
                TXTDETALLE = (Detalle.Detalle != null) ? JustifyText(Detalle.Detalle) : "",
                CODTIPODETALLE = Detalle.CodigoTipoDetalle,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion
            BE.SIC_RETORNO entSIC_RETORNO;
            if (Detalle.Estado == "2") { 
                entSIC_RETORNO = new BL.SIC_INFORMEDETA().Actualizar(entQuery);
            } else {
                var detalle = entQuery.TXTDETALLE;
                entQuery.TXTDETALLE = "";
                entSIC_RETORNO = new BL.SIC_INFORMEDETA().Grabar(entQuery);
                entQuery.CODCORRELDETA = entSIC_RETORNO.CODIGO;
                entQuery.TXTDETALLE = detalle;
                BE.SIC_RETORNO entSIC_RETORNOupd = new BL.SIC_INFORMEDETA().Actualizar(entQuery);
            }
            
            if (entSIC_RETORNO.CODIGO != null){
                correlativo = entSIC_RETORNO.CODIGO;
            }
            else
            {
                correlativo = Detalle.CodigoCorrelativo;
            }
            return entSIC_RETORNO.Ok;

        }
        public string JustifyText(string str)
        {
            string patron1 = "text-align: justify";
            string patron2 = "text-align:justify";
            str = str.Replace(patron1, patron2);
            int cont = str.Length - str.Replace(patron2, "                 ").Length;
            int at = 0; int pos = 0;
            for (int i = 0; i < cont; i++) {
                pos = str.IndexOf("style", at);
                str = str.Insert(pos, "align=\"justify\" ");
                at = str.IndexOf(patron2, 0);
            }
            return str;

        }

        public Nullable<bool> EliminarInforme(RegistrarInformeDetalle Detalle)
        {
            BE.SIC_INFORME entQuery = new BE.SIC_INFORME()
            {
                CODINFORME = Detalle.CodigoInforme,
                CODCORRINFO = Detalle.CodigoCorrelativo,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODTIPOINFOR = Detalle.CodigoTipoInforme,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_INFORME().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }

        public Nullable<bool> EliminarDetalle(RegistrarInformeDetalle Detalle)
        {
            BE.SIC_INFORMEDETA entQuery = new BE.SIC_INFORMEDETA()
            {
                CODINFORME = Detalle.CodigoInforme,
                CODANOINFO = System.DateTime.Now.Year.ToString(),
                CODTIPOINFOR = Detalle.CodigoTipoInforme,
                CODCORRINFO = Detalle.CodigoCorrelativo,
                CODCORRELDETA = Detalle.CodigoSubCorrelativo,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_INFORMEDETA().Eliminar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public RegistrarInformeDetalle RecuperarInformeDetalle(RegistrarInformeDetalle Detalle)
        {
            BE.SIC_INFORMEDETA entQuery = new BE.SIC_INFORMEDETA()
            {
                CODINFORME = Detalle.CodigoInforme,
                CODCORRINFO = Detalle.CodigoCorrelativo,
                CODTIPOINFOR = Detalle.CodigoTipoInforme,
                CODCORRELDETA = Detalle.CodigoSubCorrelativo,
                CODANOINFO = System.DateTime.Now.Year.ToString()
            };
            BE.SIC_INFORMEDETA srcQuery = new BL.SIC_INFORMEDETA().Recuperar(entQuery);
            string contexto = System.Web.HttpContext.Current.Request.ApplicationPath;
            string output = srcQuery.TXTDETALLE;
            if (srcQuery.TXTDETALLE != null)
            {
                Regex regex = new Regex(@"src=.(.[a-zA-Z]*)");
                Match match = regex.Match(srcQuery.TXTDETALLE);
                if (match.Success)
                {
                    string key = match.Groups[1].Value;
                    if (key.Substring(0, 4).ToUpper() == "/MSI")
                    {
                        output = Regex.Replace(srcQuery.TXTDETALLE, key, contexto);
                    }
                    else
                    {
                        output = Regex.Replace(srcQuery.TXTDETALLE, key, contexto + key);
                    }
                    output = output.Replace("//", "/");
                }
            }
            RegistrarInformeDetalle lisDataQuery = new RegistrarInformeDetalle()
            {
                CodigoInforme = srcQuery.CODINFORME,
                CodigoTipoInforme = srcQuery.CODTIPOINFOR,
                CodigoCorrelativo = srcQuery.CODCORRELDETA,
                Titulo = srcQuery.TXTTITULO,
                Detalle = output,
                CodigoTipoDetalle = srcQuery.CODTIPODETALLE
            };
            return lisDataQuery;
        }
        
    }
}