using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.RecepcionDocumentos
{
    public class SolicitudSeguimientoHandler
    {
        public List<SolicitudSeguimientoViewModel> ListarGrid(DataTableAjaxPostModel model, FiltrarSolicitudSeguimientoViewModel FiltroRecepcionDocumentos, out int totalResul)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            var listQuery = BuscarDB(length, skip, FiltroRecepcionDocumentos, out totalResul);
            var resultado = new List<SolicitudSeguimientoViewModel>(listQuery.Count);
            int i = 1;
            int total = listQuery.Count;
            int totalTemp = totalResul - skip;
            foreach (var s in listQuery)
            {
                if (s.CODRESPRECIBE == VariablesWeb.IdUsuarioIntento && i == 1 && s.FECRECEPCION == null)
                {
                    totalTemp--;
                }
                else {
                    SolicitudSeguimientoViewModel tempSol = new SolicitudSeguimientoViewModel()
                    {
                        Indice = totalTemp,
                        CodigoPeriodoSolicitud = s.CODANOSOLI,
                        CodigoTipoSolicitud = s.CODTIPOSOLI,
                        NumeroSolicitud = s.CODNUMESOLI,
                        NombreTipoSolicitud = (s.CODTIPOSOLI == "010003") ? "CATASTRAL" : "",
                        CodigoTipoDocumento = (s.CODTIPOSOLI == "010003") ? "001" : "",
                        NombreTipoDocumento = (s.CODTIPOSOLI == "010003") ? "REQUERIMIENTO INTERNO" : "",
                        CodigoAreaSolicitante = (s.CODTIPOSOLI == "010003") ? "A-1" : "",
                        NombreAreaSolicitante = (s.CODTIPOSOLI == "010003") ? "SUB GERENCIA DE CATASTRO" : "",
                        Asunto = s.TXTOBSERVACION,
                        Folios = s.NUMFOLIOS,
                        FechaRecepcion = s.FECRECEPCION.ToString(),
                        //PuestoRemitente = (s.CODTIPOSOLI == "010003") ?  (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO" : s.TXTPUESTOREMITENTE : "EXTERNO",
                        PuestoRecepcion = s.TXTPUESTORECEPCION,
                        UsuarioRemitente= s.CODRESPENVIA ,
                        UsuarioRecepcion= s.CODRESPRECIBE,


                    };
                    if(s.CODTIPOSOLI == "010003") {
                        tempSol.PuestoRemitente =  (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO" : s.TXTPUESTOREMITENTE;
                    } else if(s.CODTIPOSOLI == "010001"){
                        tempSol.PuestoRemitente = (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO - EXTERNO" : s.TXTPUESTOREMITENTE;
                    } else {
                        tempSol.PuestoRemitente = (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO - INTERNO" : s.TXTPUESTOREMITENTE;
                    }
                    resultado.Add(tempSol);
                    totalTemp--;
                    i++;
                }
            }
            return (resultado == null) ? new List<SolicitudSeguimientoViewModel>() : resultado;
        }
        public List<SolicitudSeguimientoViewModel> ListarDetalleSeguimiento(DataTableAjaxPostModel model, FiltrarSolicitudSeguimientoViewModel FiltroRecepcionDocumentos, out int totalResul)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            var listQuery = BuscarSeguimientoDB(length, skip, FiltroRecepcionDocumentos, out totalResul);


            var resultado = new List<SolicitudSeguimientoViewModel>(listQuery.Count);
            int i = 1;
            int total = listQuery.Count;
            int totalTemp = totalResul - skip;
            foreach (var s in listQuery)
            {
                    SolicitudSeguimientoViewModel tempSol = new SolicitudSeguimientoViewModel()
                    {
                        Indice = totalTemp,
                        CodigoPeriodoSolicitud = s.CODANOSOLI,
                        CodigoTipoSolicitud = s.CODTIPOSOLI,
                        NumeroSolicitud = s.CODNUMESOLI,
                        NombreTipoSolicitud = (s.CODTIPOSOLI == "010003") ? "CATASTRAL" : "",
                        CodigoTipoDocumento = (s.CODTIPOSOLI == "010003") ? "001" : "",
                        NombreTipoDocumento = (s.CODTIPOSOLI == "010003") ? "REQUERIMIENTO INTERNO" : "",
                        CodigoAreaSolicitante = (s.CODTIPOSOLI == "010003") ? "A-1" : "",
                        NombreAreaSolicitante = (s.CODTIPOSOLI == "010003") ? "SUB GERENCIA DE CATASTRO" : "",
                        Asunto = s.TXTOBSERVACION,
                        Folios = s.NUMFOLIOS,
                        FechaRecepcion = s.FECRECEPCION.ToString(),
                        //PuestoRemitente = (s.CODTIPOSOLI == "010003") ?  (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO" : s.TXTPUESTOREMITENTE : "EXTERNO",
                        PuestoRecepcion = s.TXTPUESTORECEPCION,
                        UsuarioRemitente = s.CODRESPENVIA,
                        UsuarioRecepcion = s.CODRESPRECIBE,
                    };
                    if (s.CODTIPOSOLI == "010003")
                    {
                        tempSol.PuestoRemitente = (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO" : s.TXTPUESTOREMITENTE;
                    }
                    else if (s.CODTIPOSOLI == "010001")
                    {
                        tempSol.PuestoRemitente = (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO - EXTERNO" : s.TXTPUESTOREMITENTE;
                    }
                    else
                    {
                        tempSol.PuestoRemitente = (s.TXTPUESTOREMITENTE == null) ? "SUB GERENCIA DE CATASTRO - INTERNO" : s.TXTPUESTOREMITENTE;
                    }
                    resultado.Add(tempSol);
                    totalTemp--;
                    i++;
            }
            return (resultado == null) ? new List<SolicitudSeguimientoViewModel>() : resultado;
        }
        public ICollection<BE.SIC_SOLISEGUI> BuscarSeguimientoDB(int length, int skip, FiltrarSolicitudSeguimientoViewModel FiltroRecepcionDocumentos, out int totalResul)
        {
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitud;
            entQuery.CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitud;
            entQuery.CODANOSOLI = FiltroRecepcionDocumentos.CodigoPeriodoSolicitud;
            entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento;


            if (FiltroRecepcionDocumentos.CodigoTipoDocumento != "REQI") { entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento; }
            entQuery = new BL.SIC_SOLISEGUI().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.ORDEN = "CODCORRSEG desc";
            entQuery.CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitud;
            entQuery.CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitud;
            entQuery.CODANOSOLI = FiltroRecepcionDocumentos.CodigoPeriodoSolicitud;
            entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento;
            if (FiltroRecepcionDocumentos.CodigoTipoDocumento != "REQI") { entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento; }
            ICollection<BE.SIC_SOLISEGUI> srcQuery = new BL.SIC_SOLISEGUI().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }

        public ICollection<BE.SIC_SOLISEGUI> BuscarDB(int length, int skip, FiltrarSolicitudSeguimientoViewModel FiltroRecepcionDocumentos, out int totalResul)
        {
            BE.SIC_SOLISEGUI entQuery = new BE.SIC_SOLISEGUI();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitudReg;
            entQuery.CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitudReg;
            entQuery.CODANOSOLI = FiltroRecepcionDocumentos.Periodo;
            if (FiltroRecepcionDocumentos.CodigoTipoDocumento != "REQI") { entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento; }
            entQuery = new BL.SIC_SOLISEGUI().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.ORDEN = "CODCORRSEG desc";
            entQuery.CODNUMESOLI = FiltroRecepcionDocumentos.NumeroSolicitudReg;
            entQuery.CODTIPOSOLI = FiltroRecepcionDocumentos.CodigoTipoSolicitudReg;
            entQuery.CODANOSOLI = FiltroRecepcionDocumentos.Periodo;
            if (FiltroRecepcionDocumentos.CodigoTipoDocumento != "REQI") { entQuery.CTIPODOCUMENTO = FiltroRecepcionDocumentos.CodigoTipoDocumento; }
            ICollection<BE.SIC_SOLISEGUI> srcQuery = new BL.SIC_SOLISEGUI().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }
    }
}