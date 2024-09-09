using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using System.Configuration;

namespace MSI.Catastros.Web.Funcionalidad.GenerarSolicitud
{
    public class GenerarSolicitudHandler
    {

        public BE.SIC_RETORNO ProcesarVias(GenerarSolicitudViewModel RegistroGenerarSolicitud)
        {
            #region Asignar a la Entidad
            BE.SIC_SOLICITUD entQuery = new BE.SIC_SOLICITUD()
            {
                CODANOSOLI = System.DateTime.Now.Year.ToString(),
                CODTIPOSOLI = "010003",
                TXTASUNTO = RegistroGenerarSolicitud.Asunto,
                NUMFOLSOL = Convert.ToInt32(RegistroGenerarSolicitud.Folios),
                CODAREASOLI = @ConfigurationManager.AppSettings["CODAREA"],
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                CODTIPODOC = "REQI"
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (RegistroGenerarSolicitud.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_SOLICITUD().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_SOLICITUD().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_SOLICITUD().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO;

        }

    }
}