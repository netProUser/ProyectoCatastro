
using MSI.Catastros.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BE = MSI.Catastros.BusinessEntities;
using BL = MSI.Catastros.BusinessLogic;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.Distritos
{
    public class DistritosHandler
    {
        public List<DistritoViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarDistritosViewModel FiltroDistritos)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = "CODDISTRITO";
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroDistritos);
            var resultado = new List<DistritoViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new DistritoViewModel { CodigoDistrito = s.CODDISTRITO, NombreDistrio = s.TXTDISTRITO, Abreviatura = s.TXTABREVIATURA });
            }
            return (resultado == null) ? new List<DistritoViewModel>() : resultado;
        }
        public ICollection<BE.SIC_DISTRITO> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarDistritosViewModel FiltroDistritos)
        {
            BE.SIC_DISTRITO entQuery = new BE.SIC_DISTRITO();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.TXTDISTRITO = "";
            entQuery = new BL.SIC_DISTRITO().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.TXTDISTRITO = FiltroDistritos.Distro;
            entQuery.ORDEN = ordenar;
            var srcQuery = new BL.SIC_DISTRITO().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }

        public RegistroDistritoViewModel BuscarDistritos(string id)
        {
            #region Obtener datos
            BE.SIC_DISTRITO entQuery = new BE.SIC_DISTRITO();
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = id;
            BE.SIC_DISTRITO query = new BL.SIC_DISTRITO().Recuperar(entQuery);
            List<DistritoViewModel> lisDistritos = new DistritosHandler().ListarDistritos("");
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroDistritoViewModel();
            dataQuery.CodigoDistrito = query.CODDISTRITO;
            dataQuery.NombreDistrio = query.TXTDISTRITO;
            dataQuery.Abreviatura = query.TXTABREVIATURA;
            #endregion
            return dataQuery;
        }
        //private static HttpResponseMessage ClientPostRequest(string RequestURI, DistritoViewModel emp)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:1379/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = client.PostAsJsonAsync(RequestURI, emp).Result;
        //    return response;
        //}
        public List<SelectListItem> ListarDepartamento()
        {
            var resul = new BL.SIC_DEPARTAMENTO().Listar();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in resul)
            {

                list.Add(new SelectListItem
                {
                    Text = item.TXTDEPARTAMENTO,
                    Value = item.CODDEPARTAMENTO
                });
            }
            return list;
        }

        public List<SelectListItem> ListarProvincia(string codDeparamento)
        {
            var resul = new BL.SIC_PROVINCIA().Listar(new BE.SIC_PROVINCIA { CODDEPARTAMENTO = codDeparamento });
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in resul)
            {

                list.Add(new SelectListItem
                {
                    Text = item.TXTPROVINCIA,
                    Value = item.CODDEPARTAMENTO
                });
            }
            return list;

        }
        public List<DistritoViewModel> ListarDistritos(string nombres)
        {
            var result = new BL.SIC_DISTRITO().Listar(new BE.SIC_DISTRITO
            {
                CODDEPARTAMENTO = "15",
                CODPROVINCIA = "01",
                TXTDISTRITO = nombres,
                TXTABREVIATURA = ""
            });
            var dataPrueba = new List<DistritoViewModel>();
            foreach (var item in result)
            {
                dataPrueba.Add(new DistritoViewModel
                {
                    Abreviatura = item.TXTABREVIATURA,
                    CodigoDistrito = item.CODDISTRITO,
                    NombreDistrio = item.TXTDISTRITO
                });
            }
            return dataPrueba;
        }
        public Nullable<bool> ProcesarHabilitacion(RegistroDistritoViewModel entDistritos)
        {
            #region Asignar a la Entidad
            BE.SIC_DISTRITO entQuery = new BE.SIC_DISTRITO();
            entQuery.TXTDISTRITO = entDistritos.NombreDistrio;
            entQuery.TXTABREVIATURA = entDistritos.Abreviatura;
            //SIEMPRE VA COMO VALOR STATICO
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = entDistritos.CodigoDistrito;
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (entDistritos.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_DISTRITO().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_DISTRITO().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_DISTRITO().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;

        }
    }
}