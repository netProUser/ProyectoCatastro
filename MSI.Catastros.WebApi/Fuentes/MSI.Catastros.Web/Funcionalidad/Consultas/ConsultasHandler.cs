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

namespace MSI.Catastros.Web.Funcionalidad.Consultas
{
    public class ConsultasHandler
    {

        public List<FiltrarConsultasViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarConsultasViewModel FiltroConsultas)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = null;
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroConsultas);
            var resultado = new List<FiltrarConsultasViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new FiltrarConsultasViewModel {
                    Titulares = s.TXTTITULARES,
                    Ubicacion = s.TXTUBICACION,
                    Urbanizacion = s.TXTURBANIZACION,
                    CodigoUnico = s.CODUNI.ToString(),
                    CodigoCatastral = s.CODDISTRITO + s.CODSECTOR + s.CODMANZANA + s.CODLOTE + s.CODEDIFICACION + s.CODENTRADA + s.CODPISO + s.CODUNIDAD
                });
            }
            return (resultado == null) ? new List<FiltrarConsultasViewModel>() : resultado;
        }

        public List<FiltrarConsultasViewModel> BuscarSimple(FiltrarConsultasViewModel FiltroConsultas)
        {
            BE.SIC_CONSULTAGEN entQuery = new BE.SIC_CONSULTAGEN();
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;

            entQuery.CODVIA = FiltroConsultas.CodigoVia;
            entQuery.CODHU = FiltroConsultas.CodigoHabilitacion;
            entQuery.TXTTITULARES = FiltroConsultas.NombreTitular;
            entQuery.TXTDOCIDENTIDAD = FiltroConsultas.CodigoTipoDocumento;
            //entQuery.TXTDOCIDENTIDAD = FiltroConsultas.NumeroDocumento;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODCLAS = FiltroConsultas.Clasificacion;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODESTACONS = FiltroConsultas.EstadoConstruccion;

            entQuery.NIVEL = (FiltroConsultas.Nivel == null) ? "01" : FiltroConsultas.Nivel;


            entQuery.TXTTITULARES = FiltroConsultas.Titulares;
            entQuery.TXTUBICACION = FiltroConsultas.Ubicacion;
            entQuery.TXTURBANIZACION = FiltroConsultas.Urbanizacion;
            var srcQuery = new BL.SIC_CONSULTAGEN().BuscarSimple(entQuery);
            var resultado = new List<FiltrarConsultasViewModel>();
            foreach (var s in srcQuery)
            {
                resultado.Add(new FiltrarConsultasViewModel
                {
                    CodigoUnico = s.CODUNI.ToString(),
                    CodigoCatastral = s.CODCATASTRAL
                });
            }

            return resultado;
        }
        public ICollection<BE.SIC_CONSULTAGEN> BuscarDB(int length, int skip, string ordenar, out int totalResul, FiltrarConsultasViewModel FiltroConsultas)
        {
            BE.SIC_CONSULTAGEN entQuery = new BE.SIC_CONSULTAGEN();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;

            entQuery.CODVIA = FiltroConsultas.CodigoVia;
            entQuery.CODHU = FiltroConsultas.CodigoHabilitacion;
            entQuery.TXTTITULARES = FiltroConsultas.NombreTitular;
            entQuery.TXTDOCIDENTIDAD = FiltroConsultas.CodigoTipoDocumento;
            //entQuery.TXTDOCIDENTIDAD = FiltroConsultas.NumeroDocumento;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODCLAS = FiltroConsultas.Clasificacion;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODESTACONS = FiltroConsultas.EstadoConstruccion;

            entQuery.NIVEL = (FiltroConsultas.Nivel == null) ? "01" : FiltroConsultas.Nivel;
            entQuery = new BL.SIC_CONSULTAGEN().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDISTRITO = FiltroConsultas.FiltrarCodigoDistrito;
            entQuery.CODSECTOR = FiltroConsultas.FiltrarCodigoSector;
            entQuery.CODMANZANA = FiltroConsultas.FiltrarCodigoManzana;
            entQuery.CODLOTE = FiltroConsultas.FiltrarCodigoLote;
            entQuery.CODEDIFICACION = FiltroConsultas.FiltrarEd;
            entQuery.CODENTRADA = FiltroConsultas.FiltrarEntrada;
            entQuery.CODPISO = FiltroConsultas.FiltrarPiso;
            entQuery.CODUNIDAD = FiltroConsultas.FiltrarUnidad;

            entQuery.CODVIA = FiltroConsultas.CodigoVia;
            entQuery.CODHU = FiltroConsultas.CodigoHabilitacion;
            entQuery.TXTTITULARES = FiltroConsultas.NombreTitular;
            entQuery.TXTDOCIDENTIDAD = FiltroConsultas.CodigoTipoDocumento;
            //entQuery.TXTDOCIDENTIDAD = FiltroConsultas.NumeroDocumento;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODCLAS = FiltroConsultas.Clasificacion;
            entQuery.CODUSOPRED = FiltroConsultas.UsoPredio;
            entQuery.CODESTACONS = FiltroConsultas.EstadoConstruccion;

            entQuery.NIVEL = (FiltroConsultas.Nivel == null) ? "01" : FiltroConsultas.Nivel;


            entQuery.TXTTITULARES = FiltroConsultas.Titulares;
            entQuery.TXTUBICACION = FiltroConsultas.Ubicacion;
            entQuery.TXTURBANIZACION = FiltroConsultas.Urbanizacion;
            var srcQuery = new BL.SIC_CONSULTAGEN().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);

            return srcQuery;
        }
        
    }
}