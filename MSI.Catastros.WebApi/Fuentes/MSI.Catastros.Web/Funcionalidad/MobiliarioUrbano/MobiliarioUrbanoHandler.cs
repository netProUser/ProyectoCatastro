using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;
namespace MSI.Catastros.Web.Funcionalidad.MobiliarioUrbano
{
    public class MobiliarioUrbanoHandler
    {
        public List<SelectListItem> ListadoUnidad(formularioDinamico ent_Formulario)
        {
            IEnumerable<BE.SIC_LOTEMOBILURBA> lisQuery = new BL.SIC_LOTEMOBILURBA().Listar(new BE.SIC_LOTEMOBILURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CODOBJETO = ent_Formulario.codObjeto
            });
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CORRELURBA,
                    Text = item.CORRELURBA
                });
            }
            return lisDataQuery;
        }


        public formularioDinamico BuscarUnidad(formularioDinamico ent_Formulario)
        {
            /*cabecera*/
            BE.SIC_LOTEMOBILURBA EntQuery = new BL.SIC_LOTEMOBILURBA().Recuperar(new BE.SIC_LOTEMOBILURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CODOBJETO = ent_Formulario.codObjeto,
                CORRELURBA = ent_Formulario.codUnidad
            });


            List<Observacion> listDinamico = new List<Observacion>();
            /*obteniedo sublcaseconfiguracion*/
            IEnumerable<BE.SIC_LOTEMUCONFIG> EntSubClase = new BL.SIC_LOTEMUCONFIG().Listar(new BE.SIC_LOTEMUCONFIG()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CORRELURBA = ent_Formulario.codUnidad
            });
            foreach (var item in EntSubClase)
            {
                listDinamico.Add(new Observacion
                {
                    configuracion = "SUBLCASE",
                    valor = item.TXTVALOR,
                    codigoConfiguracion=item.CODCORSCLASE,
                    codTipoCampo = item.TXTTIPOCAMPO,
                    Descripcion = item.TXTNOMBRE,
                    OpcionDesplegable = item.TXTDESPLE
                    /*fecha = item.FECOBSERVACION.HasValue ? item.FECOBSERVACION.Value.ToString("dd/MM/yyyy") : "",
                    Detalle = item.CODOBSER*/
                });
            }
            /*obteniedo objetoconfiguracion*/
            IEnumerable<BE.SIC_LOTEMOBILDETALLE> EntObjeto = new BL.SIC_LOTEMOBILDETALLE().Listar(new BE.SIC_LOTEMOBILDETALLE()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CORRELURBA = ent_Formulario.codUnidad,

                CODCLASE = ent_Formulario.codClase,
                CODSUBCLASE = ent_Formulario.codSubClase,
                CODOBJETO = ent_Formulario.codObjeto,
                CODCONFOBJETO = "",
            });
            foreach (var item in EntObjeto)
            {
                listDinamico.Add(new Observacion
                {
                    configuracion = "OBJETO",
                    valor = item.TXTVALOR,
                    codigoConfiguracion = item.CODCONFOBJETO,
                    codTipoCampo = item.TXTIPOCAMPOB,
                    Descripcion = item.TXTNOMBREO,
                    OpcionDesplegable = item.TXTDESPLEOB
                });
            }

            /*obteniedo detalle*/
            IEnumerable<BE.SIC_LOTEMOBOBSER> EntObservacion = new BL.SIC_LOTEMOBOBSER().Listar(new BE.SIC_LOTEMOBOBSER()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CORRELURBA = ent_Formulario.codUnidad
            });
            List<Observacion> listDetalle = new List<Observacion>();
            foreach (var item in EntObservacion)
            {
                listDetalle.Add(new Observacion
                {
                    codigo = item.CODOBSER,
                    fecha = item.FECOBSERVACION.HasValue ? item.FECOBSERVACION.Value.ToString("dd/MM/yyyy") : "",
                    Detalle = item.TXTOBSERVACION
                });
            }
            formularioDinamico entRetorno = new formularioDinamico();
            entRetorno.numeroUnidad = EntQuery.CORRELURBA;
            entRetorno.fechaCampania = EntQuery.FECCAMPANA.HasValue ? EntQuery.FECCAMPANA.Value.ToString("dd/MM/yyyy") : "";
            entRetorno.codVia_1 = EntQuery.CODVIA;
            entRetorno.ubicacionEspecificada = EntQuery.TXTUBICESPECIF;
            entRetorno.latitud = EntQuery.NUMLATITUD.ToString();
            entRetorno.longitud = EntQuery.NUMLONGITUD.ToString();
            entRetorno.Detalle = listDetalle;
            entRetorno.Dinamico = listDinamico;
            return entRetorno;
        }
        public Nullable<bool> ProcesoSubClase(formularioDinamico ent_Formulario)
        {
            #region Asignar a la Entidad
            BE.SIC_LOTEMOBILURBA entQuery = new BE.SIC_LOTEMOBILURBA()
            {
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                CODSECTOR = ent_Formulario.codSector,
                CODMANZANA = ent_Formulario.codManzana,
                CODLOTE = ent_Formulario.codLote,
                CODOBJETO = ent_Formulario.codObjeto,
                TXTCAMPANA = "",
                FECCAMPANA = ent_Formulario.fechaCampania == "" ? DateTime.Now : Convert.ToDateTime(ent_Formulario.fechaCampania),
                CODVIA = ent_Formulario.codVia_1,
                CODCORRVIADETA = "",
                TXTUBICESPECIF = ent_Formulario.ubicacionEspecificada,
                NUMCUADRA = "",
                NUMLATITUD = Convert.ToDecimal(ent_Formulario.latitud),
                NUMLONGITUD = Convert.ToDecimal(ent_Formulario.longitud),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_Formulario.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_LOTEMOBILURBA().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_LOTEMOBILURBA().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_LOTEMOBILURBA().Eliminar(entQuery); break;
            }
            #endregion
            if (entSIC_RETORNO.Ok == true)
            {
                /*LLENAR DATOS DINAMICOS*/
                foreach (var item in ent_Formulario.Dinamico)
                {

                    if (item.configuracion == "SUBLCASE")
                    {
                        #region Asignar a la Entidad
                        BE.SIC_LOTEMUCONFIG entDinamico = new BE.SIC_LOTEMUCONFIG()
                        {
                            CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                            CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                            CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                            CODSECTOR = ent_Formulario.codSector,
                            CODMANZANA = ent_Formulario.codManzana,
                            CODLOTE = ent_Formulario.codLote,
                            /*pk lote*/
                            CORRELURBA = entSIC_RETORNO.CODIGO,

                            CODCLASE = ent_Formulario.codClase,
                            CODSUBCLASE = ent_Formulario.codSubClase,
                            /*pkconfig*/
                            CODCORSCLASE = item.codigo,
                            TXTVALOR = item.valor,

                            CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                        };
                        #endregion
                        #region Grabar, Actualizar, Eliminar
                        BE.SIC_RETORNO entSIC_RETORNO_Dinamico;
                        switch (ent_Formulario.Estado)
                        {
                            case 1: entSIC_RETORNO_Dinamico = new BL.SIC_LOTEMUCONFIG().Grabar(entDinamico); break;
                            case 2: entSIC_RETORNO_Dinamico = new BL.SIC_LOTEMUCONFIG().Actualizar(entDinamico); break;
                            default: entSIC_RETORNO_Dinamico = new BL.SIC_LOTEMUCONFIG().Eliminar(entDinamico); break;
                        }
                        #endregion
                    }
                    else if (item.configuracion == "OBJETO")
                    {
                        #region Asignar a la Entidad
                        BE.SIC_LOTEMOBILDETALLE entDinamico = new BE.SIC_LOTEMOBILDETALLE()
                        {
                            CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                            CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                            CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                            CODSECTOR = ent_Formulario.codSector,
                            CODMANZANA = ent_Formulario.codManzana,
                            CODLOTE = ent_Formulario.codLote,
                            /*pk lote*/
                            CORRELURBA = entSIC_RETORNO.CODIGO,

                            CODCLASE = ent_Formulario.codClase,
                            CODSUBCLASE = ent_Formulario.codSubClase,
                            CODOBJETO = ent_Formulario.codObjeto,
                            /*pkconfig*/
                            CODCONFOBJETO = item.codigo,
                            TXTVALOR = item.valor,
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                        };
                        #endregion
                        #region Grabar, Actualizar, Eliminar
                        BE.SIC_RETORNO entSIC_RETORNO_Detalle;
                        switch (ent_Formulario.Estado)
                        {
                            case 1: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBILDETALLE().Grabar(entDinamico); break;
                            case 2: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBILDETALLE().Actualizar(entDinamico); break;
                            default: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBILDETALLE().Eliminar(entDinamico); break;
                        }
                        #endregion
                    }
                }

                foreach (var item in ent_Formulario.Detalle)
                {
                    #region Asignar a la Entidad
                    BE.SIC_LOTEMOBOBSER entDinamico = new BE.SIC_LOTEMOBOBSER()
                        {
                            CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                            CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                            CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString(),
                            CODSECTOR = ent_Formulario.codSector,
                            CODMANZANA = ent_Formulario.codManzana,
                            CODLOTE = ent_Formulario.codLote,
                            /*pk lote*/
                            CORRELURBA = entSIC_RETORNO.CODIGO,
                            /*pkconfig*/

                            TXTOBSERVACION = item.Detalle,
                            FECOBSERVACION = item.fecha == "" ? DateTime.Now : Convert.ToDateTime(item.fecha),
                            CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                        };
                    #endregion
                    #region Grabar, Actualizar, Eliminar
                    BE.SIC_RETORNO entSIC_RETORNO_Detalle;
                    switch (ent_Formulario.Estado)
                    {
                        case 1: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBOBSER().Grabar(entDinamico); break;
                        case 2: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBOBSER().Actualizar(entDinamico); break;
                        default: entSIC_RETORNO_Detalle = new BL.SIC_LOTEMOBOBSER().Eliminar(entDinamico); break;
                    }
                    #endregion
                }
            }
            return entSIC_RETORNO.Ok;
        }
    }
}