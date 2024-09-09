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
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using MSI.Catastros.Web.Funcionalidad.Sectores;
using MSI.Catastros.Web.Funcionalidad.Manzana;
using MSI.Catastros.Web.Funcionalidad.Vias;
using MSI.Catastros.Web.Funcionalidad.DetalleVias;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.ManzanaVia
{
    public class ManzanaViaHandler
    {
        public List<ManzanaViaViewModel> RecargarGrid(
                string draw,
                string start,
                string length,
                int pageSize,
                int skip,
                DataTableAjaxPostModel FilterHabil,
                FiltrarManzanaViaViewModel ManzanaVia, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (FilterHabil.search != null) ? FilterHabil.search.value : null;
            #region Obtener datos
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA()
            {
                CODSECTOR = ManzanaVia.CodigoSector,
                CODMANZANA = ManzanaVia.CodigoManzana,
                CODVIA = ManzanaVia.CodigoVia,
                TXTVIA = ManzanaVia.NombreVia ,
                TXTSECTOR = ManzanaVia.NombreSector,
                TXTMANZANA = ManzanaVia.NombreManzana,
                CODLADO = ManzanaVia.Posicionlado,
                NUMCUADRA = ManzanaVia.Numcuadra,
                NUMVALOR = ManzanaVia.Valorizacion
            };

            var srcQuery = new BL.SIC_MANZANAVIA().Buscar(entQuery);
            #endregion

            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<ManzanaViaViewModel>();
            var listLado = ParametroLado();
            var listVias = ListarVias();
            foreach (var item in data)
            {
                lisDataQuery.Add(new ManzanaViaViewModel
                {
                    CodigoSector = item.CODSECTOR,
                    CodigoManzana = item.CODMANZANA,
                    CodigoManzanaVia = item.CODCORRMANZVIA,
                    CodigoVia = item.CODVIA,
                    NombreVia = listVias.Find(x => x.Value.Contains(item.CODVIA)).Text,
                    NombreSector = item.TXTSECTOR,
                    NombreManzana = item.TXTMANZANA,
                    Posicionlado = listLado.Find(x => x.Value.Contains(item.CODLADO)).Text,
                    Numcuadra = item.NUMCUADRA,
                    RetiroOficial = (item.NUMRETIRO != null) ? item.NUMRETIRO : 0,
                    JardinOficial = (item.NUMJARDIN != null) ? item.NUMJARDIN : 0,
                    Valorizacion = item.NUMVALOR
                });
            }
            return lisDataQuery;
        }

        public List<RegistroManzanaViaViewModel> RecargarGridDetalle(DataTableAjaxPostModel model, RegistroManzanaViaViewModel FiltrarManzanaVia, out int totalResultado)
        {
            var pageSize = 20;
            var skip = model.start;

            #region Obtener datos
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = FiltrarManzanaVia.CodigoSectorReg,
                CODMANZANA = FiltrarManzanaVia.CodigoManzanaReg,
            };
            ICollection<BE.SIC_MANZANAVIA> srcQuery = new BL.SIC_MANZANAVIA().BuscarDetalle(entQuery);
            #endregion

            totalResultado = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            if (srcQuery.Count == 0) { srcQuery = new List<BE.SIC_MANZANAVIA>(); }
            int indice = 1;
            var lisDataQuery = new List<RegistroManzanaViaViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new RegistroManzanaViaViewModel
                {
                    NombreViaReg = item.TXTVIA,
                    NumcuadraReg = item.NUMCUADRA,
                    PosicionladoReg = item.CODLADO,
                    NombreladoReg = item.TXTLADO,
                    PeriodoReg = item.CODANOVAL,
                    ValorizacionReg = (item.NUMVALOR != null) ? item.NUMVALOR : 0,
                    AlturaNormativaReg = (item.NUMALTURA != null) ? item.NUMALTURA : 0,
                    AlturaNormativa = item.TXTALTURA,
                    ObservacionNormativaReg = item.TXTOBSERVACION,
                    RetiroOficialReg = (item.NUMRETIRO != null ) ? item.NUMRETIRO : 0, 
                    JardinOficialReg = (item.NUMJARDIN != null ) ?item.NUMJARDIN : 0,
                    CodigoViaReg = item.CODVIA,
                    CodigoManzanaViaReg = item.CODCORRMANZVIA
                });
                indice++;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ParametroSector()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var collection = new SectoresHandler().ListarSectores(new FiltrarSectoresViewModel());
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Text = item.NombreSector,
                    Value = item.CodigoSector
                });
            }
            return result;
        }

        public List<SelectListItem> ParametroCuadra(string id)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var collection = new DetalleViasHandler().ListarDetalleViasCombo(id);
            if (collection.Count == 0) {
                result.Add(new SelectListItem {Text = "", Value = ""});
            }
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Text = item.NumCuadra.ToString(),
                    Value = item.NumCuadra.ToString()
                });
            }

            return result;
        }
        public List<SelectListItem> ParametroLado() 
        {
            IEnumerable<BE.SIC_LADO> lisQuery = new BL.SIC_LADO().Vias(new BE.SIC_LADO());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODLADO, Text = item.TXTPARIDAD }); }
            return lisDataQuery;
        }
        public List<SelectListItem> ParametroVia()
        {
            //ACA SE VA A CONSUMIR LOS SERVICIOS REST
            IEnumerable<BE.SIC_VIA> lisQuery = new BL.SIC_VIA().Listar(new BE.SIC_VIA
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODTIPOVIA = "",
                CODCLASVIA = ""
            });

            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                result.Add(new SelectListItem
               {
                   Value = item.CODVIA,
                   Text = item.TXTVIA
               });
            }

            return result;
        }

        public List<SelectListItem> ParametroManzana(string id)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var collection = new ManzanaHandler().ListarManzanaCombo(id);
            foreach (var item in collection)
            {
                result.Add(new SelectListItem
                {
                    Text = item.NombreManzana,
                    Value = item.CodigoManzana
                });
            }

            return result;
        }

        //public List<SelectListItem> ParamtroVia()
        //{

        //    List<SelectListItem> result = new List<SelectListItem>();
        //    var collection = new ViasHandler().ListarParametosVias();
        //    foreach (var item in collection)
        //    {
        //        result.Add(new SelectListItem
        //        {
        //            Text = item.Descripcion,
        //            Value = item.CodigoParametro
        //        });
        //    }

        //    return result;
        //}


        public List<ManzanaViaViewModel> ListarManzanaVia(string nombres)
        {
            #region Obtener datos
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA();
            entQuery.CODCORRMANZVIA = nombres;
            IEnumerable<BE.SIC_MANZANAVIA> lisQuery = new BL.SIC_MANZANAVIA().Buscar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<ManzanaViaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ManzanaViaViewModel
                {
                    CODCORRMANZVIA = item.CODCORRMANZVIA,
                    CodigoManzana = item.CODMANZANA,
                    NombreVia = item.TXTVIA,
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    NombreManzana = item.TXTMANZANA,
                    CodigoVia = item.CODVIA,
                    Numcuadra = item.NUMCUADRA,
                    Posicionlado = item.CODLADO,
                    Valorizacion = item.NUMVALOR,
                });
            }
            #endregion
            return lisDataQuery;
        }
        public RegistroManzanaViaViewModel BuscarManzanaVia(string id, string sector, string manzana, string vias)
        {
            #region Obtener datos
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA();
            entQuery.CODCORRMANZVIA = id;
            entQuery.CODSECTOR = sector;
            entQuery.CODMANZANA = manzana;
            entQuery.CODVIA = vias;
            //SIEMPRE VA COMO VALOR STATICO
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');

            BE.SIC_MANZANAVIA query = new BL.SIC_MANZANAVIA().Recuperar(entQuery);
            List<SelectListItem> ParametroManzana = new ManzanaViaHandler().ParametroManzana("0");
            List<SelectListItem> ParametroSector = new ManzanaViaHandler().ParametroSector();
            List<SelectListItem> ParametroCuadra = new ManzanaViaHandler().ParametroCuadra(vias);
            List<SelectListItem> ParametroVia = new ManzanaViaHandler().ListarVias();
            List<SelectListItem> ParametroLado = new ManzanaViaHandler().ParametroLado();

            IEnumerable<BE.SIC_ZONIFMANZAVIA> querys = new BL.SIC_ZONIFMANZAVIA().Listar(new BE.SIC_ZONIFMANZAVIA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = entQuery.CODSECTOR,
                CODMANZANA = entQuery.CODMANZANA,
                CODVIA = entQuery.CODVIA,
                CODCORRMANZVIA = entQuery.CODCORRMANZVIA
            });
            var collection = new BL.SIC_ZONIFICACION().Buscar(new BE.SIC_ZONIFICACION());
            List<Zonificacion> detalle = new List<Zonificacion>();
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

            if (query == null)
            {
                return new RegistroManzanaViaViewModel();
            }
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroManzanaViaViewModel();
            dataQuery.tablaCodZonificacion = detalle;
            dataQuery.Departamento = query.CODDEPARTAMENTO;
            dataQuery.Provincia = query.CODPROVINCIA;
            dataQuery.CodigoSectorReg = query.CODSECTOR;
            dataQuery.AlturaNormativa = query.TXTALTURA;
            dataQuery.NombreViaReg = query.TXTVIA;
            dataQuery.NombreManzanaReg = query.TXTMANZANA;
            dataQuery.CodigoManzanaReg = query.CODMANZANA;
            dataQuery.CodigoViaReg = query.CODVIA;
            dataQuery.CodigoManzanaViaReg = query.CODCORRMANZVIA;
            dataQuery.NombreSectorReg = query.TXTSECTOR;
            dataQuery.NumcuadraReg = query.NUMCUADRA;
            dataQuery.PosicionladoReg = query.CODLADO;
            dataQuery.ValorizacionReg = query.NUMVALOR;
            dataQuery.PeriodoReg = query.CODANOVAL;
            dataQuery.ParametroCuadra = ParametroCuadra;
            dataQuery.ParametroSector = ParametroSector;
            dataQuery.ParametroManzana = ParametroManzana;
            dataQuery.ParametroVia = ParametroVia;
            dataQuery.ParametroLado = ParametroLado;
            dataQuery.AlturaNormativaReg = query.NUMALTURA;
            dataQuery.RetiroOficialReg = query.NUMRETIRO;
            dataQuery.JardinOficialReg = query.NUMJARDIN;
            dataQuery.ObservacionNormativaReg = query.TXTOBSERVACION;

            #endregion
            return dataQuery;
        }

        public List<SelectListItem> ListarVias()
        {
            #region Obtener datos
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            // entQuery.CODVIA = id;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');

            IEnumerable<BE.SIC_VIA> lisQuery = new BL.SIC_VIA().Listar(entQuery);
            #endregion

            #region Asignar al ViewModel
            //var lisDataQuery = new List<ViaViewModel>();
            List<SelectListItem> lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODVIA,
                    Text = item.TXTTIPODEVIA + " - " + item.TXTVIA
                });
            }
            #endregion
            return lisDataQuery;
        }
        public List<Zonificacion> BuscarZonificacion(string idCodManzana, string idCodSector, string idCodVia, string idCodManzanaVia)
        {
            IEnumerable<BE.SIC_ZONIFMANZAVIA> querys = new BL.SIC_ZONIFMANZAVIA().Listar(new BE.SIC_ZONIFMANZAVIA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = idCodSector,
                CODMANZANA = idCodManzana,
                CODCORRMANZVIA = idCodManzanaVia,
                CODVIA = idCodVia
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
            return detalle;
        }
        public List<SelectListItem> ListarParamAlturaVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoAlturaVia();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODPARAMETRO, Text = item.TXTDESCRIPCION }); }
            return lisDataQuery;
        }
        public BE.SIC_RETORNO ProcesarManzanaVia(RegistroManzanaViaViewModel ManzanaVia)
        {
            #region Asignar a la Entidad
            BE.SIC_MANZANAVIA entQuery = new BE.SIC_MANZANAVIA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = ManzanaVia.CodigoSectorReg,
                CODCORRMANZVIA = ManzanaVia.CodigoManzanaViaReg,
                CODMANZANA = ManzanaVia.CodigoManzanaReg,
                TXTSECTOR = ManzanaVia.NombreSectorReg,
                CODVIA = ManzanaVia.CodigoViaReg,
                NUMCUADRA = ManzanaVia.NumcuadraReg,
                CODLADO = ManzanaVia.PosicionladoReg,
                NUMVALOR = ManzanaVia.ValorizacionReg,
                TXTALTURA = ManzanaVia.AlturaNormativa,
                NUMRETIRO = ManzanaVia.RetiroOficialReg,
                NUMJARDIN = ManzanaVia.JardinOficialReg,
                TXTOBSERVACION = ManzanaVia.ObservacionNormativaReg,
                CODANOVAL = ManzanaVia.PeriodoReg,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            BE.SIC_MANZAVIAVALOR entQueryValor = new BE.SIC_MANZAVIAVALOR()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODSECTOR = ManzanaVia.CodigoSectorReg,
                CODCORRMANZVIA = ManzanaVia.CodigoManzanaViaReg,
                CODMANZANA = ManzanaVia.CodigoManzanaReg,
                CODVIA = ManzanaVia.CodigoViaReg,
                NUMCUADRA = ManzanaVia.NumcuadraReg,
                CODLADO = ManzanaVia.PosicionladoReg,
                NUMVALOR = ManzanaVia.ValorizacionReg,
                CODANOVAL = ManzanaVia.PeriodoReg,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion
            var srcQueryValor = new BL.SIC_MANZAVIAVALOR().Recuperar(entQueryValor);
            

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            BE.SIC_RETORNO entSIC_RETORNO_VALOR;
            switch (ManzanaVia.Estado)
            {
                case 1:
                    var srcQueryVerif = new BL.SIC_MANZANAVIA().RecuperarVerificacion(entQuery);
                    if (srcQueryVerif == null) {
                        entSIC_RETORNO = new BL.SIC_MANZANAVIA().Grabar(entQuery);
                        if (entSIC_RETORNO.Ok == true) {
                            entQueryValor.CODCORRMANZVIA = entSIC_RETORNO.CODIGO;entSIC_RETORNO_VALOR = new BL.SIC_MANZAVIAVALOR().Grabar(entQueryValor);
                        }
                    }
                    else {
                        entSIC_RETORNO = new BE.SIC_RETORNO(){ Ok = false, NoMENSAJE = 8556, MENSAJE = "El registro ya ha sido ingresado"  };
                    }
                break;
                case 2: entSIC_RETORNO = new BL.SIC_MANZANAVIA().Actualizar(entQuery);
                    if (entSIC_RETORNO.Ok == true)
                    {
                        if (srcQueryValor == null) {
                            entSIC_RETORNO_VALOR = new BL.SIC_MANZAVIAVALOR().Grabar(entQueryValor);
                        }
                        else if (Convert.ToInt32(srcQueryValor.CODANOVAL) < Convert.ToInt32(entQueryValor.CODANOVAL)) {
                            entSIC_RETORNO_VALOR = new BL.SIC_MANZAVIAVALOR().Grabar(entQueryValor);
                        }
                        else {
                            entSIC_RETORNO_VALOR = new BL.SIC_MANZAVIAVALOR().Actualizar(entQueryValor);
                        }
                    }
                break;
                default: entSIC_RETORNO = new BL.SIC_MANZANAVIA().Eliminar(entQuery); break;
            }
            #endregion
            if (entSIC_RETORNO.Ok == true)
            {
                string CodManzana = entSIC_RETORNO.CODIGO;
                if (entSIC_RETORNO.CODIGO == null)
                {
                    CodManzana = ManzanaVia.CodigoManzanaViaReg;
                }
                new BL.SIC_ZONIFMANZAVIA().Eliminar(new BE.SIC_ZONIFMANZAVIA()
                {
                    CODDEPARTAMENTO = entQuery.CODDEPARTAMENTO,
                    CODPROVINCIA = entQuery.CODPROVINCIA,
                    CODDISTRITO = entQuery.CODDISTRITO,
                    CODSECTOR = entQuery.CODSECTOR,
                    CODMANZANA = entQuery.CODMANZANA,
                    CODVIA = entQueryValor.CODVIA,
                    CODCORRMANZVIA = entQueryValor.CODCORRMANZVIA,
                    CODUSUARIO = VariablesWeb.IdUsuarioIntento
                });
                if (ManzanaVia.tablaCodZonificacion != null)
                {
                    foreach (var item in ManzanaVia.tablaCodZonificacion)
                    {
                        BE.SIC_ZONIFMANZAVIA entZonif = new BE.SIC_ZONIFMANZAVIA()
                        {
                            CODDEPARTAMENTO = entQuery.CODDEPARTAMENTO,
                            CODPROVINCIA = entQuery.CODPROVINCIA,
                            CODDISTRITO = entQuery.CODDISTRITO,
                            CODSECTOR = entQuery.CODSECTOR,
                            CODMANZANA = entQuery.CODMANZANA,
                            CODVIA = entQueryValor.CODVIA,
                            CODCORRMANZVIA = entQueryValor.CODCORRMANZVIA,
                            CODZONIFICACION = item.CodigoZonicacion,
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento
                        };
                        BE.SIC_ZONIFMANZA srcZonif = new BL.SIC_ZONIFMANZAVIA().Recuperar(entZonif);
                        if (srcZonif == null)
                        {
                            entSIC_RETORNO = new BL.SIC_ZONIFMANZAVIA().Grabar(entZonif);
                        }
                        else
                        {
                            entSIC_RETORNO = new BL.SIC_ZONIFMANZAVIA().Actualizar(entZonif);
                        }
                    }
                }
                entSIC_RETORNO.CODIGO = CodManzana;
                entSIC_RETORNO.Ok = true;
            }
            return entSIC_RETORNO;

        }
    }
}