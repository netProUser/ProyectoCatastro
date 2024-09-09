using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.HistoricoErrores
{
    public class HistoricoErroresHandler
    {
        /// <summary>
        /// Reotnar listado de Número De Trámite Documentario
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoNroTramiteDocumentario()
        {
            return new List<SelectListItem>() { };
        }

        public List<SelectListItem> ListadoNroSolicitud()
        {
            return new List<SelectListItem>() { };
        }

        public List<SelectListItem> ListadoAreaSolicitante()
        {
            return new List<SelectListItem> { };
        }


        public List<SelectListItem> ListadoEstadoAtencion()
        {
            return new List<SelectListItem>() { };
                 
        }

        public List<SelectListItem> ListadoEstadoSolicitud()
        {
            return new List<SelectListItem>() { };

        }
        public List<SelectListItem> LitadoTipoRequerimiento()
        {
            return new List<SelectListItem> { };
        }
        }
    }