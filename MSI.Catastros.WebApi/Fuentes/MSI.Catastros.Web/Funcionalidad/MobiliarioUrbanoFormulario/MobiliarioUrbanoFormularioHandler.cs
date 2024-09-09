using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
namespace MSI.Catastros.Web.Funcionalidad.MobiliarioUrbanoFormulario
{
    public class MobiliarioUrbanoFormularioHandler
    {

        public List<SelectListItem> ListadoClase()
        {
            IEnumerable<BE.SIC_CLASEMOBU> lisQuery = new BL.SIC_CLASEMOBU().Listar(new BE.SIC_CLASEMOBU());
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODCLASE,
                    Text = item.TXTDESCLASE
                });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoSubClase(SubClaseViewModel modelo)
        {
            IEnumerable<BE.SIC_SUBCLASEMOBU> lisQuery = new BL.SIC_SUBCLASEMOBU().Listar(new BE.SIC_SUBCLASEMOBU()
            {
                CODCLASE = modelo.CodClase
            });
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODSUBCLASE,
                    Text = item.TXTDESCCOMPO
                });
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListadoObjeto(ObjetoViewModel modelo)
        {
            IEnumerable<BE.SIC_OBJETO> lisQuery = new BL.SIC_OBJETO().Listar(new BE.SIC_OBJETO()
            {
                CODCLASE = modelo.CodClase,
                CODSUBCLASE = modelo.CodSubClase
            });
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODOBJETO,
                    Text = item.TXTDESCOBJETO
                });
            }
            return lisDataQuery;
        }

        public Nullable<bool> ProcesoClase(ClaseViewModel ent_Clase)
        {
            #region Asignar a la Entidad
            BE.SIC_CLASEMOBU entQuery = new BE.SIC_CLASEMOBU()
            {
                TXTCODIGOA = ent_Clase.CodClase,
                TXTDESCLASE = ent_Clase.NombreClase,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_Clase.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_CLASEMOBU().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_CLASEMOBU().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_CLASEMOBU().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> ProcesoSubClase(SubClaseViewModel ent_SubClase)
        {
            #region Asignar a la Entidad
            BE.SIC_SUBCLASEMOBU entQuery = new BE.SIC_SUBCLASEMOBU()
            {
                CODCLASE = ent_SubClase.CodClase,
                TXTCODIGOA = ent_SubClase.CodSubClase,
                TXTDESCCOMPO = ent_SubClase.NombreSubClase,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_SubClase.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_SUBCLASEMOBU().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_SUBCLASEMOBU().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_SUBCLASEMOBU().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> ProcesoObjeto(ObjetoViewModel ent_Objeto)
        {
            #region Asignar a la Entidad
            BE.SIC_OBJETO entQuery = new BE.SIC_OBJETO()
            {
                CODCLASE = ent_Objeto.CodClase,
                CODSUBCLASE = ent_Objeto.CodSubClase,
                TXTDESCOBJETO = ent_Objeto.NombreObjeto,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_Objeto.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_OBJETO().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_OBJETO().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_OBJETO().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
        /*REGISTRO FORMULARIO SUB CLASE*/
        public Nullable<bool> ProcesoFormularioSubClase(FormularioDetalleViewModel ent_FormularioSubClase)
        {
            #region Asignar a la Entidad
            BE.SIC_CONFIGSUBCLASE entQuery = new BE.SIC_CONFIGSUBCLASE()
            {
                CODCLASE = ent_FormularioSubClase.CodClase,
                CODSUBCLASE = ent_FormularioSubClase.CodSubClase,
                TXTNOMBRE = ent_FormularioSubClase.Descripcion,
                TXTTIPOCAMPO = ent_FormularioSubClase.codTipoCampo,
                TXTTAMANO = ent_FormularioSubClase.TamanioCampo,
                TXTDESPLE = ent_FormularioSubClase.OpcionDesplegable,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_FormularioSubClase.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_CONFIGSUBCLASE().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_CONFIGSUBCLASE().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_CONFIGSUBCLASE().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }

        public List<FormularioDetalleViewModel> ListadoFormularioSubClase(ObjetoViewModel modelo)
        {
            IEnumerable<BE.SIC_CONFIGSUBCLASE> lisQuery = new BL.SIC_CONFIGSUBCLASE().Listar(new BE.SIC_CONFIGSUBCLASE()
            {
                CODCLASE = modelo.CodClase,
                CODSUBCLASE = modelo.CodSubClase
            });
            var lisDataQuery = new List<FormularioDetalleViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new FormularioDetalleViewModel
                {
                    codigoConfiguracion = item.CODCORSCLASE,
                    CodClase = item.CODCLASE,
                    CodSubClase = item.CODSUBCLASE,
                    Descripcion = item.TXTNOMBRE,
                    codTipoCampo = item.TXTTIPOCAMPO,
                    TamanioCampo = item.TXTTAMANO,
                    OpcionDesplegable = item.TXTDESPLE
                });
            }
            return lisDataQuery;
        }
        /*REGISTRO FORMULARIO OBJETO*/
        public Nullable<bool> ProcesoFormularioObjeto(FormularioDetalleViewModel ent_FormularioObjeto)
        {
            #region Asignar a la Entidad
            BE.SIC_CONFIGOBJETO entQuery = new BE.SIC_CONFIGOBJETO()
            {
                CODCLASE = ent_FormularioObjeto.CodClase,
                CODSUBCLASE = ent_FormularioObjeto.CodSubClase,
                CODOBJETO = ent_FormularioObjeto.CodObjeto,
                TXTNOMBREO = ent_FormularioObjeto.Descripcion,
                TXTIPOCAMPOB = ent_FormularioObjeto.codTipoCampo,
                TXTTAMANOB = ent_FormularioObjeto.TamanioCampo,
                TXTDESPLEOB = ent_FormularioObjeto.OpcionDesplegable,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_FormularioObjeto.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_CONFIGOBJETO().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_CONFIGOBJETO().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_CONFIGOBJETO().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
        public List<FormularioDetalleViewModel> ListadoFormularioObjeto(ObjetoViewModel modelo)
        {
            IEnumerable<BE.SIC_CONFIGOBJETO> lisQuery = new BL.SIC_CONFIGOBJETO().Listar(new BE.SIC_CONFIGOBJETO()
            {
                CODCLASE = modelo.CodClase,
                CODSUBCLASE = modelo.CodSubClase,
                CODOBJETO = modelo.CodObjeto
                
            });
            var lisDataQuery = new List<FormularioDetalleViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new FormularioDetalleViewModel
                {
                    codigoConfiguracion = item.CODCONFOBJETO,
                    CodClase = item.CODCLASE,
                    CodSubClase = item.CODSUBCLASE,
                    Descripcion = item.TXTNOMBREO,
                    codTipoCampo = item.TXTIPOCAMPOB,
                    TamanioCampo = item.TXTTAMANOB,
                    OpcionDesplegable = item.TXTDESPLEOB
                });
            }
            return lisDataQuery;
        }
    }
}