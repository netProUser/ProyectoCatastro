using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.TipoHabilitacion;
using MSI.Catastros.Web.Funcionalidad.HabilitacionUrbana;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ManzanaUrbana
{
    public class ManzanaUrbanaHandler
    {
        public List<ManzanaUrbanaViewModel> RecargarGrid(
                string draw,
                string start,
                string length,
                int pageSize,
                int skip,
                DataTableAjaxPostModel FilterHabil,
                FiltrarManzanaUrbanaViewModel ManzanaUrbana, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (FilterHabil.search != null) ? FilterHabil.search.value : null;
            #region Obtener datos
            BE.SIC_URBAMANZA entQuery = new BE.SIC_URBAMANZA()
            {
                CODHABURBA = ManzanaUrbana.CodigoHabilitacionUrbanaReg,
                CODTIPOHABURB = ManzanaUrbana.CodigoTipoHabilitacionReg,
                CODTIPOMANZA = ManzanaUrbana.CodigoTipoManzanaUrbanaReg,
                TXTMANZAURB =  ManzanaUrbana.NombreManzanaUrbanaReg
            };

            var srcQuery = new BL.SIC_URBAMANZA().Buscar(entQuery);
            #endregion

            recordsTotal = srcQuery.Count();

            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<ManzanaUrbanaViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new ManzanaUrbanaViewModel
                {
                    CodigoManzanaUrbana = item.CODMANZURB,
                    NombreManzanaUrbana = item.TXTMANZAURB,
                    NombreHabilitacionUrbana = item.TXTURBANIZACION,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                    NombreTipoManzana = item.TXTTIPOMANZA
                    
                });
            }
            return lisDataQuery;
        }
        public List<ManzanaUrbanaViewModel> ListarManzanaUrbana(FiltrarManzanaUrbanaViewModel filtrarManzanaUrbana)
        {
            #region Obtener datos

            BE.SIC_HABILITURBA entQuery = new BE.SIC_HABILITURBA();
            entQuery.TXTURBANIZACION = filtrarManzanaUrbana.NombreHabilitacionUrbanaReg;
            entQuery.CODTIPOHABURB = filtrarManzanaUrbana.CodigoTipoHabilitacionReg;
            entQuery.CODHABURBA = filtrarManzanaUrbana.CodigoHabilitacionUrbanaReg;
            IEnumerable<BE.SIC_HABILITURBA> lisQuery = new BL.SIC_HABILITURBA().Buscar(entQuery);
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<ManzanaUrbanaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ManzanaUrbanaViewModel
                {
                    NombreTipoHabilitacion = item.CODHABURBA,
                    NombreHabilitacionUrbana = item.CODHABURBA,
                    NombreManzanaUrbana = item.TXTURBANIZACION
                     

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
                    Value = item.CODTIPOHABURB,
                    Text = item.TXTHABILITAURBA
                }); ;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarTipoManzanaUrbanaSelect()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoManzanaUrbana();
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
        public List<SelectListItem> ListarManzanaUrbanaSelect(FiltrarManzanaUrbanaViewModel filtrarManzUrb)
        {
            #region Obtener datos
            BE.SIC_URBAMANZA entQuery = new BE.SIC_URBAMANZA() { CODTIPOHABURB = filtrarManzUrb.CodigoTipoHabilitacionReg, CODHABURBA = filtrarManzUrb.CodigoHabilitacionUrbanaReg };
            IEnumerable<BE.SIC_URBAMANZA> lisQuery = new BL.SIC_URBAMANZA().Buscar(entQuery);
            #endregion

            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SelectListItem
                {
                    Value = item.CODMANZURB,
                    Text = item.TXTMANZAURB
                }); ;
            }
            return lisDataQuery;
        }
          
        public RegistroManzanaUrbanaViewModel BuscarManzanaUrbana(string id)
        {
            #region Obtener datos
            BE.SIC_URBAMANZA entQuery = new BE.SIC_URBAMANZA();
            entQuery.CODMANZURB = id;
            BE.SIC_URBAMANZA query = new BL.SIC_URBAMANZA().Recuperar(entQuery);
            List<TipoHabilitacionViewModel> lisTipoHabilitacion = new TipoHabilitacionHandler().ListarTipoHabilitacion(new FiltrarTipoHabilitacionViewModel());
            List<HabilitacionUrbanaViewModel> lisHabilitacionUrbana = new List<HabilitacionUrbanaViewModel>();
            List<SelectListItem> listTipoManzana = new ManzanaUrbanaHandler().ListarTipoManzanaUrbanaSelect();
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroManzanaUrbanaViewModel();
            dataQuery.TipoHabilitacion = lisTipoHabilitacion;
            dataQuery.CodigoTipoManzanaUrbana = query.CODTIPOMANZA;
            dataQuery.ListTipoManzanaUrbana = listTipoManzana;
            dataQuery.HabilitacionUrbana = lisHabilitacionUrbana;
            dataQuery.NombreManzanaUrbana = query.TXTMANZAURB;
            dataQuery.CodigoManzanaUrbana = query.CODMANZURB;
            dataQuery.CodigoHabilitacionUrbana = query.CODHABURBA;
            dataQuery.CodigoTipoHabilitacion = query.CODTIPOHABURB;
            
            #endregion
            return dataQuery;
        }

        public Nullable<bool> ProcesarManzanaUrbana(RegistroManzanaUrbanaViewModel ManzanaUrbana)
        {
            #region Asignar a la Entidad
            BE.SIC_URBAMANZA entQuery = new BE.SIC_URBAMANZA()
            {
                CODMANZURB = ManzanaUrbana.CodigoManzanaUrbana,
                CODTIPOMANZA = ManzanaUrbana.CodigoTipoManzanaUrbana,
                TXTMANZAURB = ManzanaUrbana.NombreManzanaUrbana,
                CODHABURBA = ManzanaUrbana.CodigoHabilitacionUrbana,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (ManzanaUrbana.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_URBAMANZA().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_URBAMANZA().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_URBAMANZA().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;

        }
    }
}