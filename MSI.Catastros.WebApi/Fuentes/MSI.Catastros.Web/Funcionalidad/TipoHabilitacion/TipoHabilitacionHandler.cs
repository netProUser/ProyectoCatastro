using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using MSI.Catastros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.TipoHabilitacion
{
    public class TipoHabilitacionHandler
    {

        public ICollection<BE.SIC_TIPOHABURB> ListarGrid(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            var result = BuscarDB(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);
            if (result == null)
            {
                // empty collection...
                return new List<BE.SIC_TIPOHABURB>();
            }
            return result;
        }
        public ICollection<BE.SIC_TIPOHABURB> BuscarDB(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
        {
            if (String.IsNullOrEmpty(searchBy))
            {
                sortBy = "Id";
                sortDir = true;
            }
            BE.SIC_TIPOHABURB entQuery = new BE.SIC_TIPOHABURB();
            //entQuery.PAGINANUMERO = 1;
            //entQuery.PAGINAREGISTROS = 5;
            //entQuery = new BL.SIC_VIA().BuscarInt(entQuery);

            //entQuery.ORDEN = "CODVIA";
            //entQuery.PAGINANUMERO = (skip / take == 0) ? 1 : (skip / take) + 1;
            //entQuery.PAGINAREGISTROS = 5;
            var srcQuery = new BL.SIC_TIPOHABURB().Buscar(entQuery);

            //// now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            //filteredResultsCount = entQuery.TOTALREGISTROS ?? default(int);
            //totalResultsCount = entQuery.TOTALREGISTROS ?? default(int);
            filteredResultsCount = 0;
            totalResultsCount = 0;
            return srcQuery;
        }
        public List<TipoHabilitacionViewModel> RecargarGrid(
                string draw, 
                string start, 
                string length, 
                int pageSize, 
                int skip, 
                DataTableAjaxPostModel FilterTipHab,
                FiltrarTipoHabilitacionViewModel TipoHabilitacion, out int recordsTotal) 
        {
            recordsTotal = 0;
            var searchBy = (FilterTipHab.search != null) ? FilterTipHab.search.value : null;
            #region Obtener datos
            BE.SIC_TIPOHABURB entQuery = new BE.SIC_TIPOHABURB() 
            { 
                TXTHABILITAURBA = TipoHabilitacion.NombreTipoHabilitacion
            };
            
            var srcQuery = new BL.SIC_TIPOHABURB().Buscar(entQuery);
            #endregion
                  
            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<TipoHabilitacionViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new TipoHabilitacionViewModel
                {
                    CodigoTipoHabilitacion = item.CODTIPOHABURB,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                });
            }
            return lisDataQuery;
        }
        public List<TipoHabilitacionViewModel> ListarTipoHabilitacion(FiltrarTipoHabilitacionViewModel FilterTipHab)
        {
            #region Obtener datos
            BE.SIC_TIPOHABURB entQuery = new BE.SIC_TIPOHABURB();
            entQuery.TXTHABILITAURBA = FilterTipHab.NombreTipoHabilitacion;
            IEnumerable<BE.SIC_TIPOHABURB> lisQuery = new BL.SIC_TIPOHABURB().Buscar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<TipoHabilitacionViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new TipoHabilitacionViewModel
                {
                    CodigoTipoHabilitacion = item.CODTIPOHABURB,
                    NombreTipoHabilitacion = item.TXTHABILITAURBA,
                });
            }
            #endregion
            return lisDataQuery;
        }
        
        public List<SelectListItem> ListarTipoHabilitacionSelect()
        {
            IEnumerable<BE.SIC_TIPOHABURB> lisQuery = new BL.SIC_TIPOHABURB().Buscar(new BE.SIC_TIPOHABURB());
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
        public RegistroTipoHabilitacionViewModel BuscarTipoHabilitacion(string id)
        {
            #region Obtener datos
            BE.SIC_TIPOHABURB entQuery = new BE.SIC_TIPOHABURB();
            entQuery.CODTIPOHABURB = id;
            BE.SIC_TIPOHABURB query = new BL.SIC_TIPOHABURB().Recuperar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroTipoHabilitacionViewModel();
            dataQuery.CodigoTipoHabilitacion = query.CODTIPOHABURB;
            dataQuery.NombreTipoHabilitacion = query.TXTHABILITAURBA;
            #endregion
            return dataQuery; 
        }

        public Nullable<bool> ProcesarHabilitacion(RegistroTipoHabilitacionViewModel TipoHabilitacion)
        {
            #region Asignar a la Entidad
            BE.SIC_TIPOHABURB entQuery = new BE.SIC_TIPOHABURB()
            {
                CODTIPOHABURB = TipoHabilitacion.CodigoTipoHabilitacion,
                TXTHABILITAURBA = TipoHabilitacion.NombreTipoHabilitacion,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (TipoHabilitacion.Estado) {
                case 1 : entSIC_RETORNO = new BL.SIC_TIPOHABURB().Grabar(entQuery); break;
                case 2 : entSIC_RETORNO = new BL.SIC_TIPOHABURB().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_TIPOHABURB().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;

        }
    }
}