using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MSI.Catastros.Web.Funcionalidad.ConsultaHistorica
{
    public class ConsultaHistoricaHandler
    {

        public List<FiltrarConsultaHistoricaViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarConsultaHistoricaViewModel FiltroConsultas)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = null;
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroConsultas);
            var resultado = new List<FiltrarConsultaHistoricaViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new FiltrarConsultaHistoricaViewModel
                {
                    Nro = s.NRO,
                    Version = s.VERSION,
                    FechaGen = s.FECHAGEN,
                    Documento = s.DOCUMENTO,
                    RutaDocu = s.RUTADOCUM
                });
            }
            return (resultado == null) ? new List<FiltrarConsultaHistoricaViewModel>() : resultado;
        }

        public ICollection<BE.SIC_CONSULTAHST> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarConsultaHistoricaViewModel FiltroConsultas)
        {
            BE.SIC_CONSULTAHST entQuery = new BE.SIC_CONSULTAHST();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            if (FiltroConsultas.FiltrarEd != null) { 
               entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd.ToUpper();
            }
            if (FiltroConsultas.FiltrarEntrada != null){
               entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada.ToUpper();
            }
            if (FiltroConsultas.FiltrarPiso != null) {
                entQuery.CODPISO = FiltroConsultas.FiltrarPiso.ToUpper();
            }
            if (FiltroConsultas.FiltrarUnidad != null){
                entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad.ToUpper();
            }
            entQuery.CODTIPODOC = FiltroConsultas.CODTIPODOC;
            entQuery.FECHAINI = FiltroConsultas.FECHAINI;
            entQuery.FECHAFIN = FiltroConsultas.FECHAFIN;

            entQuery = new BL.SIC_CONSULTAHST().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
           /* entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;*/

          //  entQuery.PAGINANUMERO = 1;
          //  entQuery.PAGINAREGISTROS = 1;

            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            if (FiltroConsultas.FiltrarEd != null)
            {
                entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd.ToUpper();
            }
            if (FiltroConsultas.FiltrarEntrada != null)
            {
                entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada.ToUpper();
            }
            if (FiltroConsultas.FiltrarPiso != null)
            {
                entQuery.CODPISO = FiltroConsultas.FiltrarPiso.ToUpper();
            }
            if (FiltroConsultas.FiltrarUnidad != null)
            {
                entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad.ToUpper();
            }
            entQuery.CODTIPODOC = FiltroConsultas.CODTIPODOC;
            entQuery.FECHAINI = FiltroConsultas.FECHAINI;
            entQuery.FECHAFIN = FiltroConsultas.FECHAFIN;
          
          
            var srcQuery = new BL.SIC_CONSULTAHST().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);

            return srcQuery;
        }

        public SolicitudUnidadViewModel RecuperarReferencia(String CodS, String CodM, String CodL, String CodEd, String CodEnt, String CodPi, String CodUn, String CODTIPODOC,  out bool resul)
        {
          
            #region Obtener datos
            BE.SIC_SOLUNIDAD entQuery = new BE.SIC_SOLUNIDAD()
            {
                CODDISTRITO = "31",
                CODSECTOR = CodS,
                CODMANZANA = CodM,
                CODLOTE = CodL,
                CODEDIFICACION = CodEd,
                CODENTRADA = CodEnt,
                CODPISO = CodPi,
                CODUNIDAD = CodUn,
                CTIPODOCUMENTO = CODTIPODOC
            };

            BE.SIC_SOLUNIDAD srcQuery = new BL.SIC_CONSULTAHST().obtenerReferen(entQuery);
            #endregion

            SolicitudUnidadViewModel dataQuery;

            dataQuery = new SolicitudUnidadViewModel()
            {
                Referencia = (srcQuery.CODREFANT != null) ? srcQuery.CODREFANT.Replace("|", ",") : "",
                EstadoUnidad = (srcQuery.ESTADOUNIDAD != null) ? srcQuery.ESTADOUNIDAD : "",
                Ubicacion = (srcQuery.TXTDIRECCION!=null) ? srcQuery.TXTDIRECCION :""
            };
            resul = true;

            return dataQuery;
     
        }
        
    }
}