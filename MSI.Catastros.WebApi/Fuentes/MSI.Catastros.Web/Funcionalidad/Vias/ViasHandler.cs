using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using MSI.Catastros.Web.Funcionalidad.Parametros;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Utiles;


namespace MSI.Catastros.Web.Funcionalidad.Vias
{
    public class ViasHandler
    {
        public List<ViaViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarViasViewModel FiltroVias)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = "CODVIA";
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroVias);
            var resultado = new List<ViaViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new ViaViewModel { CodigoVia = s.CODVIA, NombreVia = s.TXTVIA, DesTipoVia = s.TXTTIPODEVIA, DesClaseVia = s.TXTCLASIFICACIONVIA, CodClaseVia = s.CODCLASVIA, CodViaEquivalente = s.CODVIAEQUIV, DesAdmVia = s.TXTCODADMVIA });
            }
            return (resultado == null) ? new List<ViaViewModel>() : resultado;
        }

        public ICollection<BE.SIC_VIA> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarViasViewModel FiltroVias)
        {
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTVIA = FiltroVias.FiltrarNombreVia;
            entQuery.CODTIPOVIA = FiltroVias.FiltrarCodTipoVia;
            entQuery = new BL.SIC_VIA().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTVIA = FiltroVias.FiltrarNombreVia;
            entQuery.CODTIPOVIA = FiltroVias.FiltrarCodTipoVia;
            entQuery.ORDEN = ordenar;
            var srcQuery = new BL.SIC_VIA().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }

        public ICollection<BE.SIC_VIA> ListarGrid2(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount, FiltrarViasViewModel Filtrovias)
        {
            var buscarPor = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            // search the dbase taking into consideration table sorting and paging
            var result = BuscarDB2(buscarPor, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount, Filtrovias);
            if (result == null)
            {
                // empty collection...
                return new List<BE.SIC_VIA>();
            }
            return result;
        }

        
        public ICollection<BE.SIC_VIA> BuscarDB2(string buscarPor, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount, FiltrarViasViewModel Filtrovias)
        {
            // the example datatable used is not supporting multi column ordering
            // so we only need get the column order from the first column passed to us.        

            if (String.IsNullOrEmpty(buscarPor))
            {
                // if we have an empty search then just order the results by Id ascending
                sortBy = "Id";
                sortDir = true;
            }
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = 5;
            entQuery.TXTVIA = Filtrovias.FiltrarNombreVia;
            entQuery.CODTIPOVIA = Filtrovias.FiltrarCodTipoVia;
            entQuery = new BL.SIC_VIA().BuscarInt(entQuery);

            entQuery.ORDEN = "CODVIA";
            if (take == 0)
            {
                take = 1;
            }
            entQuery.PAGINANUMERO = (skip / take == 0) ? 1 : (skip/take) +1;
            entQuery.PAGINAREGISTROS = 5;
            entQuery.TXTVIA = Filtrovias.FiltrarNombreVia;
            entQuery.CODTIPOVIA = Filtrovias.FiltrarCodTipoVia;
            var srcQuery = new BL.SIC_VIA().Buscar(entQuery);

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            filteredResultsCount = entQuery.TOTALREGISTROS ?? default(int);
            totalResultsCount = entQuery.TOTALREGISTROS ?? default(int);

            return srcQuery;
        }
        public List<ViaViewModel> ListarVias(FiltrarViasViewModel FilterVia)
        {
            #region Obtener datos
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            entQuery.TXTVIA = FilterVia.FiltrarNombreVia;
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = 30;
            IEnumerable<BE.SIC_VIA> lisQuery = new BL.SIC_VIA().Buscar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<ViaViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ViaViewModel
                {
                    CodigoVia = item.CODVIA,
                    DesTipoVia = "",
                    NombreVia = item.TXTVIA,
                    TotalVirtual = 80
                });
            }
            #endregion

            return lisDataQuery;
        }

        public List<ParametrosViewModel> ListarParametosVias()
        {
            //ACA SE VA A CONSUMIR LOS SERVICIOS REST
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().TipoDeVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,

                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }

        public List<ParametrosViewModel> ListarParametosClaseVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().ClasificacionVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,
                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }

        public List<ParametrosViewModel> ListarParametosAnchoVia()
        {
            IEnumerable<BE.SIC_PARAMETROS> lisQuery = new BL.SIC_PARAMETROS().AnchoVia();
            var lisDataQuery = new List<ParametrosViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new ParametrosViewModel
                {
                    CodigoParametro = item.CODPARAMETRO,
                    Descripcion = item.TXTDESCRIPCION
                });
            }

            return lisDataQuery;
        }

        public RegistroViaViewModel BuscarVia(string id)
        {
            #region Obtener datos
            BE.SIC_VIA entQuery = new BE.SIC_VIA();
            entQuery.CODVIA = id;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');

            BE.SIC_VIA query = new BL.SIC_VIA().Recuperar(entQuery);
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroViaViewModel();
            dataQuery.CodigoVia = query.CODVIA;
            dataQuery.NombreVia = query.TXTVIA;
            dataQuery.CodTipoVia = query.CODTIPOVIA;
            dataQuery.CodClaseVia = query.CODCLASVIA;
            #endregion
            return dataQuery;
        }

        public BE.SIC_RETORNO ProcesarVias(RegistroViaViewModel RegistroVias)
        {
            #region Asignar a la Entidad
            BE.SIC_VIA entQuery = new BE.SIC_VIA()
            {
                CODVIA = RegistroVias.CodigoVia,
                TXTVIA = RegistroVias.NombreVia,
                CODTIPOVIA = RegistroVias.CodTipoVia,
                CODCLASVIA = RegistroVias.CodClaseVia,
                CODVIAANTE = "0000010",
                TXTVIAANTE = "ABASCAL, Virrey",
                CODADMVIA = (RegistroVias.CodClaseVia == "010004") ? "010002" : "010001", //(RegistroVias.CodClaseVia = "010004") ? 'MSI' : 'MML', 
                // CODVIAEQUIV = "L27" + RegistroVias.CodigoVia,
                CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0'),
                CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0'),
                CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0'),
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (RegistroVias.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_VIA().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_VIA().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_VIA().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO;

        }
    }
}