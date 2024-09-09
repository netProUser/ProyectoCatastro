using MSI.Catastros.Web.Funcionalidad.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;

using System.Web;

namespace MSI.Catastros.Web.Funcionalidad.ConsultaCertificados
{
    public class ConsultaCertificadosHandler
    {
        public List<ConsultaCertificadosViewModel> CargarGrillaCertificados(string draw, string start, string length, int pageSize, int skip, DataTableAjaxPostModel model, ConsultaCertificadosViewModel FiltroConsultaCertificados, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (model.search != null) ? model.search.value : null;
         


            BE.SIC_CERTIFICADO entSOLISEG = new BE.SIC_CERTIFICADO()
            {
                CODTIPOCERTI = FiltroConsultaCertificados.FiltrarCodigoTipoCertificado,
                CODTIPOSOLI = FiltroConsultaCertificados.FiltrarCodigoTipoSolicitud,
                CTIPODOCUMENTO = FiltroConsultaCertificados.FiltrarCodigoTipoDocumentoReg,
                CODNUMESOLI = FiltroConsultaCertificados.FiltrarNumeroSolicitud,
                FECINICIO = FiltroConsultaCertificados.FechaInicio,
                FECFIN = FiltroConsultaCertificados.FechaFin,
                TXTCODIGOCATASTRAL = FiltroConsultaCertificados.txtCodigoCatastral,

            };

            ICollection<BE.SIC_CERTIFICADO> srcQuery = new BL.SIC_CERTIFICADO().CargarGrillaCertificados(entSOLISEG);
            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();

            var lisDataQuery = new List<ConsultaCertificadosViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new ConsultaCertificadosViewModel
                {

                    CodigoCertificado = item.CODCERTIFICADO,
                    CodigoAnioCertificado = item.CODANOCERTI,
                    codigoAnio = item.CODANOSOLI,
                    CodigoTipoSolicitud = item.CODTIPOSOLI,
                    NombreTipoSolicitud = item.TXTTIPOSOLI,
                    NumeroSolicitud = item.CODNUMESOLI,
                    CodigoTipoCertificado = item.CODTIPOCERTI,
                    NombreTipoCertificado = item.TXTTIPOCERTI,

                    CodigoCorrelativoTramite = item.CODTRAMITE,
                    FlagReporte = item.CODTRAMITE,
                    CodigoUnico = item.CODUNI,
                    CodigoCatastral = item.TXTCODIGOCATASTRAL,
                    Ubicacion = item.TXTUBICACION,
                    FlagTrabajo = item.FLG_TRABAJO,
                    Ruta = item.TXTRUTAIMAGEN,
                    FechaRegistro = (item.FECREG != null) ? item.FECREG.Value.ToString("dd/MM/yyyy") : "",
                    CodigoUsuario = item.CODUSUARIOREG,
                    CodigoDocumento = item.CODTIPODOC,
                    Nro = item.NRO


                });
            }


          



            return lisDataQuery;
        }
    }
}