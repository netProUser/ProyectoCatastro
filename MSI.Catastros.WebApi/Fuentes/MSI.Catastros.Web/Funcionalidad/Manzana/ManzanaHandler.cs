using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using MSI.Catastros;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Drawing;

namespace MSI.Catastros.Web.Funcionalidad.Manzana
{
    public class ManzanaHandler
    {
        public List<ManzanaViewModel> RecargarGrid(
                string draw,
                string start,
                string length,
                int pageSize,
                int skip,
                DataTableAjaxPostModel FilterManzana,
                FiltrarManzanaViewModel Manzana, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (FilterManzana.search != null) ? FilterManzana.search.value : null;
            #region Obtener datos
            string tematica = Manzana.NombreTematica;
            //if (Manzana.NombreTematica == null)
            //{
            //    tematica = "";
            //}
            //else if (("golf").Contains(Manzana.NombreTematica.ToLower()))
            //{
            //    tematica = "01";
            //}
            //else if (("olivar").Contains(Manzana.NombreTematica.ToLower()))
            //{
            //    tematica = "02";
            //}
            //else if (("litigio").Contains(Manzana.NombreTematica.ToLower()))
            //{
            //    tematica = "03";
            //}
            //else
            //{
            //    tematica = "";
            //}
            /*
             "Sin Tematica", Value = "04", Selected=true },
                new SelectListItem { Text = "El Golf", Value = "01" },
                new SelectListItem { Text = "El Olivar", Value = "02" },
                new SelectListItem { Text = "Zona Litigio", Value = "03"
             */

            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA()
            {
                TXTSECTOR = Manzana.NombreSector,
                CODSECTOR = Manzana.CodigoSector,
                CODMANZANA = Manzana.CodigoManzana,
                TXTMANZANA = Manzana.NombreManzana,
                CODTEMATICO = tematica,//Manzana.NombreTematica,
                ORDEN = "M.CODSECTOR,M.CODMANZANA",
                PAGINANUMERO = 1,
                PAGINAREGISTROS = 100000
            };

            var srcQuery = new BL.SIC_MANZANA().Buscar(entQuery);
            #endregion

            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<ManzanaViewModel>();
            foreach (var item in data)
            {
                //string datos = string.Empty;
                ////try
                ////{
                //    datos = datos + "-";
                //    IEnumerable<BE.SIC_ZONIFMANZA> querys = new BL.SIC_ZONIFMANZA().Listar(new BE.SIC_ZONIFMANZA()
                //    {
                //        CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                //        CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                //        CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                //        CODSECTOR = item.CODSECTOR,
                //        CODMANZANA = item.CODMANZANA
                //    });
                    //var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION());
                    //if (querys.Count() > 0)
                    //{
                    //    datos = "";
                    //}
                    //foreach (var items in querys)
                    //{
                    //    foreach (var itemss in collection)
                    //    {
                    //        if (items.CODZONIFICACION == itemss.CODZONIFICACION)
                    //        {
                    //            datos = datos + "-" + itemss.TXTABREVIACION;
                    //            break;
                    //        }
                    //    }
                    //}
                //}
                //catch (Exception)
                //{

                //}
                lisDataQuery.Add(new ManzanaViewModel
                {
                    CodigoManzana = item.CODMANZANA,
                    NombreManzana = item.TXTMANZANA,
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    CodigoTematica = item.CODTEMATICO,
                    NombreTematica = item.TXTTEMATICO,
                    NombreManzanaUrbana = item.TXTMANZURBA,
                    SectorizacionVecinal = item.TXTSECTVECI,
                    SubSectorizacionVecinal = item.TXTSUBSECTVECI,
                    Ruta = item.TXTRUTAIMAGEN == null ? "" : item.TXTRUTAIMAGEN.Replace("\\", ",").Replace("/", ",")
                });
            }
            return lisDataQuery;
        }

        public List<ManzanaViewModel> ListarManzana(FiltrarManzanaViewModel FilterManzana)
        {
            #region Obtener datos
            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA();
            entQuery.TXTMANZANA = FilterManzana.NombreManzana;
            entQuery.CODSECTOR = FilterManzana.CodigoSector;
            IEnumerable<BE.SIC_MANZANA> lisQuery = new BL.SIC_MANZANA().Listar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<ManzanaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ManzanaViewModel
                {
                    CodigoManzana = item.CODMANZANA,
                    NombreManzana = item.TXTMANZANA,
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    CodigoTematica = item.CODTEMATICO,
                    NombreTematica = item.TXTTEMATICO,
                    NombreManzanaUrbana = item.TXTMANZURBA,
                });
            }
            #endregion
            return lisDataQuery;
        }

        public List<ManzanaViewModel> ListarManzanaCombo(string datos)
        {
            #region Obtener datos
            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA();
            entQuery.CODSECTOR = datos;
            IEnumerable<BE.SIC_MANZANA> lisQuery = new BL.SIC_MANZANA().Listar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<ManzanaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ManzanaViewModel
                {
                    CodigoManzana = item.CODMANZANA,
                    NombreManzana = item.TXTMANZANA,
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    CodigoTematica = item.CODTEMATICO,
                    NombreTematica = item.TXTTEMATICO,
                    NombreManzanaUrbana = item.TXTMANZURBA,
                });
            }
            #endregion
            return lisDataQuery;
        }
        public RegistroManzanaViewModel BuscarManzana(string idCodManzana, string idCodSector)
        {
            #region Obtener datos
            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA();
            entQuery.CODMANZANA = idCodManzana;
            entQuery.CODSECTOR = idCodSector;
            //SIEMPRE VA COMO VALOR STATICO
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
            BE.SIC_MANZANA query = new BL.SIC_MANZANA().Recuperar(entQuery);
            if (query == null)
            {
                return new RegistroManzanaViewModel();
            }
            IEnumerable<BE.SIC_ZONIFMANZA> querys = new BL.SIC_ZONIFMANZA().Listar(new BE.SIC_ZONIFMANZA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = entQuery.CODSECTOR,
                CODMANZANA = entQuery.CODMANZANA
            });
            List<Zonificacion> detalle = new List<Zonificacion>();
            var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION());
            foreach (var item in querys)
            {
                foreach (var items in collection)
                {
                    if (item.CODZONIFICACION == items.CODZONIFICACION)
                    {
                        detalle.Add(new Zonificacion()
                        {
                            CodigoZonicacion = item.CODZONIFICACION,
                            Descripcion = items.TXTABREVIACION
                        });
                        break;
                    }
                }

            }
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroManzanaViewModel();
            dataQuery.CodigoManzana = query.CODMANZANA;
            dataQuery.NombreManzana = query.TXTMANZANA;
            dataQuery.CodigoSector = query.CODSECTOR;
            dataQuery.CodigoTematica = query.CODTEMATICO;
            dataQuery.Departamento = query.CODDEPARTAMENTO;
            dataQuery.Provincia = query.CODPROVINCIA;
            dataQuery.NombreSector = query.TXTSECTOR;
            dataQuery.NombreTematica = query.CODTEMATICO;
            dataQuery.NombreManzanaUrbana = query.TXTMANZURBA;
            dataQuery.codSectorizacion = query.TXTSECTVECI;
            dataQuery.codSubSectorizacion = query.TXTSUBSECTVECI;

            dataQuery.tablaCodZonificacion = detalle;
            #endregion
            return dataQuery;
        }

        //public Nullable<bool> ProcesarManzana(RegistroManzanaViewModel Manzana)
        public BE.SIC_RETORNO ProcesarManzana(RegistroManzanaViewModel Manzana)
        {
            #region Asignar a la Entidad
            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA()
            {
                CODMANZANA = Manzana.CodigoManzana,
                TXTMANZANA = Manzana.NombreManzana,
                CODSECTOR = Manzana.CodigoSector,
                TXTSECTOR = Manzana.NombreSector,
                CODTEMATICO = Manzana.CodigoTematica,
                TXTMANZURBA = Manzana.NombreManzanaUrbana,
                CODDEPARTAMENTO = "15",
                CODPROVINCIA = "01",
                CODDISTRITO = "31",
                TXTSECTVECI = Manzana.codSectorizacion,
                TXTSUBSECTVECI = Manzana.codSubSectorizacion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (Manzana.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_MANZANA().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_MANZANA().Actualizar(entQuery);
                    entSIC_RETORNO.CODIGO = Manzana.CodigoManzana;
                    break;
                default: entSIC_RETORNO = new BL.SIC_MANZANA().Eliminar(entQuery); break;
            }
            #endregion
            if (entSIC_RETORNO.Ok == true)
            {
                string CodManzana = entSIC_RETORNO.CODIGO;
                if (entSIC_RETORNO.CODIGO == null) {
                    CodManzana = Manzana.CodigoManzana;
                }
                new BL.SIC_ZONIFMANZA().Eliminar(new BE.SIC_ZONIFMANZA()
                {
                    CODDEPARTAMENTO = entQuery.CODDEPARTAMENTO,
                    CODPROVINCIA = entQuery.CODPROVINCIA,
                    CODDISTRITO = entQuery.CODDISTRITO,
                    CODSECTOR = entQuery.CODSECTOR,
                    CODMANZANA = CodManzana,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                });
                if (Manzana.tablaCodZonificacion != null)
                {
                    foreach (var item in Manzana.tablaCodZonificacion)
                    {
                        BE.SIC_ZONIFMANZA entZonif = new BE.SIC_ZONIFMANZA()
                        {
                            CODDEPARTAMENTO = entQuery.CODDEPARTAMENTO,
                            CODPROVINCIA = entQuery.CODPROVINCIA,
                            CODDISTRITO = entQuery.CODDISTRITO,
                            CODSECTOR = entQuery.CODSECTOR,
                            CODMANZANA = CodManzana,
                            CODZONIFICACION = item.CodigoZonicacion,
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento
                        };
                        BE.SIC_ZONIFMANZA srcZonif = new BL.SIC_ZONIFMANZA().Recuperar(entZonif);
                        if (srcZonif == null)
                        {
                            entSIC_RETORNO = new BL.SIC_ZONIFMANZA().Grabar(entZonif);
                        }
                        else
                        {
                            entSIC_RETORNO = new BL.SIC_ZONIFMANZA().Actualizar(entZonif);
                        }
                        //{
                        //}
                        //catch (Exception)
                        //{
                        //}
                    }
                }
                entSIC_RETORNO.CODIGO = CodManzana;
                entSIC_RETORNO.Ok = true;
            }
            return entSIC_RETORNO;

        }
        public List<SelectListItem> ListadoSector()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var collection = new BL.SIC_SECTOR().Listar(new BE.SIC_SECTOR()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                TXTSECTOR = ""
            });
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Value = item.CODSECTOR,
                    Text = item.TXTSECTOR

                });
            }
            return result;
        }

        public List<SelectListItem> ListadoZonificacionSuelo()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION()
            {
            });
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Value = item.CODZONIFICACION,
                    Text = item.CODZONIFICACION + "-" + item.TXTABREVIACION

                });
            }
            return result;
        }
        public List<SelectListItem> ListadoZonificacionSueloDescripcion()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION()
            {
            });
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Value = item.CODZONIFICACION,
                    Text = item.TXTZONIFICACION

                });
            }
            return result;
        }

        public List<SelectListItem> ListadoCodigoSectorizacion()
        {
            //List<SelectListItem> result = new List<SelectListItem>();

            //var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION()
            //{
            //});
            //foreach (var item in collection)
            //{
            //    result.Add(new SelectListItem
            //    {
            //        Value = item.CODZONIFICACION,
            //        Text = item.TXTZONIFICACION

            //    });
            //}
            //return result;
            return null;
        }
        public List<SelectListItem> ListadoCodigoSubSectorizacion(int codigo)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            for (int i = 1; i <= 5; i++)
            {
                result.Add(new SelectListItem
                {
                    Value = codigo + "-" + i,
                    Text = codigo + "-" + i
                });
            }
            return result;
        }
        public List<SelectListItem> ListadoTematica()
        {
            BE.SIC_TEMATICAMANZANA entQuery = new BE.SIC_TEMATICAMANZANA();
            IEnumerable<BE.SIC_TEMATICAMANZANA> lisQuery = new BL.SIC_TEMATICAMANZANA().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTEMATICO,
                    Text = item.TXTTEMATICO
                });
            }
            return lisDataQuery;
        }
        public Nullable<bool> GrabarManzanaImagen(ImagenManzana manzana, out string correlativo)
        {
            BE.SIC_MANZANA entQuery = new BE.SIC_MANZANA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = manzana.CODDISTRITO,
                CODSECTOR = manzana.CODSECTOR,
                CODMANZANA = manzana.CODMANZANA
            };
            BE.SIC_MANZANA srcQuery = new BL.SIC_MANZANA().Recuperar(entQuery);

            #region Subir archivo
            var archivo = manzana.ARCHIVO;
            string carpeta = string.Format("\\{0}\\{1}\\{2}\\{3}\\", "DOCUMENTOS", "INTERIOR", entQuery.CODSECTOR, entQuery.CODMANZANA);
            if (!Directory.Exists(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta))
                Directory.CreateDirectory(@ConfigurationManager.AppSettings["RUTA_FILSERVER"] + carpeta);

            //try
            //{
                if (archivo != null)
                {
                    string _NombreArchivo = Path.GetFileName(archivo.FileName);

                    string NombreArchivo = string.Format("{0}{1}{2}{3}{4}_{5}{6}", entQuery.CODDEPARTAMENTO, entQuery.CODPROVINCIA, entQuery.CODDISTRITO, entQuery.CODSECTOR, entQuery.CODMANZANA, DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(archivo.FileName) ?? ".dat");

                    srcQuery.TXTRUTAIMAGEN = Path.Combine(carpeta, NombreArchivo);
                    BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_MANZANA().Actualizar(srcQuery);

                    BE.SIC_DETAFILESERVER entQueryDeta = new BE.SIC_DETAFILESERVER()
                    {
                        TXTNOMTABLA = "SIC_MANZANA",
                        CODPKTABLA = string.Format("{0},{1},{2},{3},{4}", entQuery.CODDEPARTAMENTO, entQuery.CODPROVINCIA, entQuery.CODDISTRITO, entQuery.CODSECTOR, entQuery.CODMANZANA),
                        TXTPKTABLANOM = "CODDEPARTAMENTO,CODPROVINCIA,CODDISTRITO,CODSECTOR,CODMANZANA",
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
            //}
            //catch (Exception ex)
            //{
            //    correlativo = ex.Message;
            //    return false;
            //}
            #endregion
        }
        public string VerImagenManzana(string carpeta)
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