using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Web.Mvc;
namespace MSI.Catastros.Web.Funcionalidad.Dociso
{
    public class DocisoHandler
    {
        public List<SelectListItem> ListadoTipoLlenado()
        {
            IEnumerable<BE.SIC_TIPOLLENA> lisQuery = new BL.SIC_TIPOLLENA().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODTIPOLLENA,
                    Text = item.CODTIPOLLENA + " - " + item.TXTTIPOLLENADO
                });
            }
            return lisDataQuery;
        }
        public List<DocisoViewModel> ListadoDocIso(DocisoViewModel ent_DocIso)
        {
            IEnumerable<BE.SIC_DOCISO> lisQuery = new BL.SIC_DOCISO().Listar(new BE.SIC_DOCISO()
            {
                CODTIPODOC = ent_DocIso.codTpDocumento,
                TXTDESCRIPCION = ent_DocIso.txtDescripcion
            });
            var lisDataQuery = new List<DocisoViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new DocisoViewModel
                {
                    txtDescripcion = item.TXTDESCRIPCION,
                    codTpDocumento = item.CODTIPODOC,
                    txtTpDocumento= item.TXTTIPODOCUMENTO,
                    CODDOCCAT= item.CODDOCCAT
                });
            }
            return lisDataQuery;
        }

        public Nullable<bool> ProcesarDocISO(DocisoViewModel ent_DocIso)
        {
            #region Asignar a la Entidad
            BE.SIC_DOCISO entQuery = new BE.SIC_DOCISO()
            {
                CODDOCCAT = ent_DocIso.CODDOCCAT,
                CODTIPODOC = ent_DocIso.codTpDocumento,
                TXTDESCRIPCION = ent_DocIso.txtDescripcion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ent_DocIso.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_DOCISO().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_DOCISO().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_DOCISO().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;
        }
    }
}