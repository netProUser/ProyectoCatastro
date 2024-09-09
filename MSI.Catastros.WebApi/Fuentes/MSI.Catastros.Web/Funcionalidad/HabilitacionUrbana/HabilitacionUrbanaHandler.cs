using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc; 
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Configuration;
using System.Globalization;

namespace MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana
{
    public class HabilitacionUrbanaHandler
    {
        public List<HabilitacionUrbanaViewModel> RecargarGrid(
                string draw,
                string start,
                string length,
                int pageSize,
                int skip,
                DataTableAjaxPostModel FilterHabil,
                FiltrarHabilitacionUrbanaViewModel HabilitacionUrbana, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (FilterHabil.search != null) ? FilterHabil.search.value : null;
            #region Obtener datos
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA()
            {
                CODTIPOHABURB = HabilitacionUrbana.CodigoTipoHabilitacion,
                TXTURBANIZACION = HabilitacionUrbana.NombreHabilitacionUrbana
            };

            var srcQuery = new BL.SIC_HABILITURBA().Buscar(entQuery);
            #endregion

            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<HabilitacionUrbanaViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new HabilitacionUrbanaViewModel
                {
                    CodigoHabilitacionUrbana = item.CODHABURBA,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                    NombreHabilitacionUrbana = item.TXTURBANIZACION,
                    NombreDocumento = item.TXTNOMDOCU,
                    NombreDocumentoRandom = item.TXTNOMDOCUINT,
                    NombreRealDiferenciador = item.TXTNOMBREDIFERENCIADOR,
                    Ruta = item.TXTRUTAIMAGEN == null ? "" : item.TXTRUTAIMAGEN.Replace("\\", ",").Replace("/", ","),
                    //FechaAprobacion = item.FECAPROBACION,
                    txtFechaAprobacion = item.FECAPROBACION.HasValue ? item.FECAPROBACION.Value.ToString("dd/MM/yyyy") : string.Empty,
                    NumeroDocumento = item.TXTNUMDOCPROB
                });
            }
            return lisDataQuery;
        }
        public List<HabilitacionUrbanaViewModel> ListarHabilitacionUrbana(FiltrarHabilitacionUrbanaViewModel filtrarHabilitacion)
        {
            #region Obtener datos

            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA();
            entQuery.TXTURBANIZACION = filtrarHabilitacion.NombreHabilitacionUrbana;
            entQuery.CODTIPOHABURB = filtrarHabilitacion.CodigoTipoHabilitacion;
            IEnumerable<BE.SIC_HABILITURBA> lisQuery = new BL.SIC_HABILITURBA().Buscar(entQuery);
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<HabilitacionUrbanaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new HabilitacionUrbanaViewModel
                {
                    CodigoHabilitacionUrbana = item.CODHABURBA,
                    NombreHabilitacionUrbana = item.TXTURBANIZACION,
                    CodigoTipoHabilitacionUrbana = item.CODTIPOHABURB,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                    TipoHabilitacion = lisTipoHabilitacion,
                    NombreDocumento = item.TXTNOMDOCU,
                    NombreDocumentoRandom = item.TXTNOMDOCUINT,
                    NombreDiferenciador = item.TXTDIFERENCIADORHABURBA
                });
            }
            #endregion
            return lisDataQuery;
        }

        public Nullable<bool> GrabarHabilitacionImagen(ImagenHabilitacion Habilitacion, out string correlativo)
        {
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA()
            {
                CODHABURBA = Habilitacion.CodigoHabilitacionUrbana,
            };
            BE.SIC_HABILITURBA srcQuery = new BL.SIC_HABILITURBA().Recuperar(entQuery);

            #region Subir archivo
            var archivo = Habilitacion.Archivo;
            string carpeta = string.Format("\\{0}\\{1}\\{2}\\", "IMAGENES", "HABILITACION", entQuery.CODHABURBA);
            if (!Directory.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);
            
                if (archivo != null)
                {
                    string _NombreArchivo = Path.GetFileName(archivo.FileName);
                    string NombreArchivo = string.Format("{0}_{1}{2}", entQuery.CODHABURBA, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(archivo.FileName) ?? ".dat");

                    srcQuery.TXTRUTAIMAGEN = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, NombreArchivo);
                    BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_HABILITURBA().Actualizar(srcQuery);

                    BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                    {
                        TXTNOMTABLA = "SIC_HABILITURBA",
                        CODPKTABLA = string.Format("{0}", entQuery.CODHABURBA),
                        TXTPKTABLANOM = "CODHABURBA",
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


        public string DescargarImagen(string carpeta)
        {
            #region Subir archivo

            if (File.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
            {
                var base64Img = new Base64Image
                {
                    FileContents = File.ReadAllBytes(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta),
                    ContentType = "image/png"
                };
                return base64Img.ToString();
            }
            else
            {
                return "";
            }
            #endregion
        }

        public string VerImagenHabilitacion(string carpeta)
        {
            #region Subir archivo

            if (File.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
            {
                var base64Img = new Base64Image
                {
                    FileContents = File.ReadAllBytes(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta),
                    ContentType = "image/png"
                };
                return base64Img.ToString();
            }
            else
            {
                return "";
            }
            #endregion
        }

        public RegistroHabilitacionUrbanaViewModel BuscarHabilitacionUrbana(string id)
        {
            #region Obtener datos
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA();
            entQuery.CODHABURBA = id;
            BE.SIC_HABILITURBA query = new BL.SIC_HABILITURBA().Recuperar(entQuery);
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            List<SelectListItem> lisDiferenciador = new HabilitacionUrbanaHandler().ListarDiferenciadorSelect();
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroHabilitacionUrbanaViewModel();
            dataQuery.CodigoHabilitacionUrbana = query.CODHABURBA;
            dataQuery.NombreHabilitacionUrbana = query.TXTURBANIZACION;
            dataQuery.CodigoTipoHabilitacion = query.CODTIPOHABURB;
            dataQuery.NombreDocumento = query.TXTNOMDOCU;
            dataQuery.NombreDiferenciador = query.TXTDIFERENCIADORHABURBA;
            dataQuery.FechaAprobacion = query.FECAPROBACION;
            dataQuery.NumeroDocumento = query.TXTNUMDOCPROB;
            dataQuery.NombreDocumentoRandom = query.TXTNOMDOCUINT;
            dataQuery.TipoHabilitacion = lisTipoHabilitacion;
            dataQuery.ListDiferenciador = lisDiferenciador;
            #endregion
            return dataQuery;
        }

        public List<HabilitacionUrbanaViewModel> ListarHabilitacionUrbanaCombo(string datos)
        {
            #region Obtener datos
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA();
            entQuery.CODTIPOHABURB = datos;
            IEnumerable<BE.SIC_HABILITURBA> lisQuery = new BL.SIC_HABILITURBA().Buscar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<HabilitacionUrbanaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new HabilitacionUrbanaViewModel
                {
                    CodigoHabilitacionUrbana = item.CODHABURBA,
                    NombreHabilitacionUrbana = item.TXTURBANIZACION,
                });
            }
            #endregion
            return lisDataQuery;
        }
        public List<SelectListItem> ListarHabilitacionUrbanaSelect(string datos)
        {
            #region Obtener datos
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA() { CODTIPOHABURB = datos };
            IEnumerable<BE.SIC_HABILITURBA> lisQuery = new BL.SIC_HABILITURBA().Buscar(entQuery);
            #endregion

            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODHABURBA,
                    Text = item.TXTURBANIZACION
                }); ;
            }
            return lisDataQuery;
        }
        public List<ObservacionViewModel> BuscarObservacion(HabilitacionUrbanaViewModel FiltrarHabilitacion)
        {
            BE.SIC_HABURBAOBSER entQuery = new BE.SIC_HABURBAOBSER()
            {
                CODHABURBA = FiltrarHabilitacion.CodigoHabilitacionUrbana 
            };
            ICollection<BE.SIC_HABURBAOBSER> lisQuery = new BL.SIC_HABURBAOBSER().Listar(entQuery);
            var lisDataQuery = new List<ObservacionViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ObservacionViewModel
                {
                    Detalle = (item.TXTOBSERVA != null) ? item.TXTOBSERVA : "",
                    Codigo = item.CODCORRELOBS
                });
            }
            return lisDataQuery;
        }
        public Nullable<bool> GrabarObservacion(List<ObservacionViewModel> Lote,string codigo)
        {
            int contProceso = 0;
            foreach (ObservacionViewModel ItemLote in Lote)
            {
                var datosEncontrados = true;
                BE.SIC_HABURBAOBSER entQuery = new BE.SIC_HABURBAOBSER()
                {
                    //CODHABURBA = ItemLote.CodigoHabilitacionUrbana,
                    CODHABURBA = codigo,
                    CODCORRELOBS = ItemLote.Codigo,
                    TXTOBSERVA = ItemLote.Detalle,
                };
                BE.SIC_HABURBAOBSER srcQuery = new BL.SIC_HABURBAOBSER().Recuperar(entQuery);
                if (srcQuery == null)
                {
                    srcQuery = entQuery;
                    datosEncontrados = false;
                }
                srcQuery.TXTOBSERVA = ItemLote.Detalle;
                srcQuery.CODUSUARIO = VariablesWeb.IdUsuarioIntento;
                BE.SIC_RETORNO entSIC_RETORNO;
                if (ItemLote.Estado == "1")
                {
                    entSIC_RETORNO = new BL.SIC_HABURBAOBSER().Eliminar(srcQuery);
                }
                else
                {
                    entSIC_RETORNO = (datosEncontrados == true) ? new BL.SIC_HABURBAOBSER().Actualizar(srcQuery) : new BL.SIC_HABURBAOBSER().Grabar(srcQuery);
                }

                if (entSIC_RETORNO.Ok == false)
                {
                    contProceso++;
                }
            }
            return (contProceso == 0) ? true : false;
        }
        
        public Nullable<bool> ProcesarHabilitacion(RegistroHabilitacionUrbanaViewModel HabilitacionUrbana, out string codigo)
        {
            #region Asignar a la Entidad
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA()
            {
                CODHABURBA = HabilitacionUrbana.CodigoHabilitacionUrbana,
                TXTURBANIZACION = HabilitacionUrbana.NombreHabilitacionUrbana,
                TXTNOMDOCU = HabilitacionUrbana.NombreDocumento,
                TXTNOMDOCUINT = HabilitacionUrbana.NombreDocumentoRandom,
                TXTDIFERENCIADORHABURBA = HabilitacionUrbana.NombreDiferenciador,
                
                TXTNUMDOCPROB = HabilitacionUrbana.NumeroDocumento,
                FECACTDOCU = System.DateTime.Now,
                CODTIPOHABURB = HabilitacionUrbana.CodigoTipoHabilitacion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            if (HabilitacionUrbana.FechaAprobacion != null) {
                entQuery.FECAPROBACION = HabilitacionUrbana.FechaAprobacion;
            }
            #endregion

            

            

            #region Subir archivo
            var archivo = HabilitacionUrbana.archivo;
            string repo = "DOCUMENTOS"; string tiporepo = "HABILITACION";
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
                    //string _FN = string.Format("{0}{1}.{2}", _Nombre, _Date, _Ext);
                    string tempCodigo = (entSIC_RETORNO.CODIGO != null) ? entSIC_RETORNO.CODIGO : HabilitacionUrbana.CodigoHabilitacionUrbana;
                    string _FN = tempCodigo + "_"+ "HABILITACION" + Guid.NewGuid().ToString()+ "." + _Ext;

                    string _Ruta = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta, _FN);
                    entQuery.TXTNOMDOCU = _NombreArchivo;
                    entQuery.TXTNOMDOCUINT = _FN.Substring(0, _FN.Length - 4);

                    BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                    {
                        TXTNOMTABLA = "SIC_HABILITURBA",
                        CODPKTABLA = tempCodigo,
                        TXTPKTABLANOM = "HABILITACION",
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

            #region Grabar, Actualizar, Eliminar
            switch (HabilitacionUrbana.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_HABILITURBA().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_HABILITURBA().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_HABILITURBA().Eliminar(entQuery); break;
            }
            #endregion

            if (subida == false) {
                codigo = "";
                return false;
            }
            codigo = (entSIC_RETORNO.CODIGO != null) ? entSIC_RETORNO.CODIGO : HabilitacionUrbana.CodigoHabilitacionUrbana;
            return entSIC_RETORNO.Ok;

        }

        public List<SelectListItem> ListarDiferenciadorSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDiferenciador();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
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