using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.ProgramarInspeccion
{
    public class FiltrarProgramarInspeccionViewModel
    {

        public bool DatosEncontrados { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        public IEnumerable<SelectListItem> TipoSolicitud { get; set; }
        public string codTipoSolicitud { get; set; }
        [Display(Name = "Tipo Documento")]
        public IEnumerable<SelectListItem> ListTipoDocumento { get; set; }
        public string CodigoTipoDocumentoReg { get; set; }

        [Display(Name = "Nro. Solicitud")]
        public string nroSolicitud { get; set; }

        /**/
        public string AniSolcitud { get; set; }
        //public string codTipo { get; set; }
        public string Estado { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DataType(DataType.Date)]
        [Display(Name = "Fecha Vencimiento de Plazo")]
        public string FechaLimite { get; set; }

        [Display(Name = "Entrega a Análisis")]
        public string FechaLimiProgInspec { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DataType(DataType.Date)]
        [Display(Name = "Entrega de Inspector")]
        public string FechaLimiteInspeccion { get; set; }

        [Display(Name = "Asunto")]
        public string Asunto { get; set; }

        [Display(Name = "Tipo de Llenado")]
        public string TipoLlenado { get; set; }

        public IEnumerable<CodigoCatastralAsignado> ListCatastral { get; set; }

        [Display(Name = "Documento de Identidad")]
        public string DocumentoIdentidad { get; set; }
        [Display(Name = "Nombre o Razón Social")]
        public string NombreRazonSocial { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Tipo Doc")]
        public string TipoDocumentoRepresentante { get; set; }
        [Display(Name = "Nro. Documento")]
        public string NumeroroDocumentoRepresentante { get; set; }
        [Display(Name = "Nombre y Apellido")]
        public string NombreApellidoRepresentante { get; set; }

        [Display(Name = "Ap. Materno Repre.")]
        public string ApeMaternoRepresentante { get; set; }
        [Display(Name = "Nombre Repre.")]
        public string NombreRepresentante { get; set; }

        [Display(Name = "Teléfono")]
        public string TelefonoRepresentante { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoRepresentante { get; set; }
        [Display(Name = "Representante")]
        public string Representante { get; set; }
        [Display(Name = "Solicitante")]
        public string Solicitante { get; set; }
        public string NroInspeccion { get; set; }

        public string EstadoAtencion { get; set; }
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }
        [Display(Name = "Teléfono Ins.")]
        public string TelefonoInspeccion { get; set; }

        [Display(Name = "Inspectores")]
        public string Inspectores { get; set; }
        public List<SelectListItem> codInspectores { get; set; }

        [Display(Name = "Inspector Responsable")]
        public string Responsable { get; set; }
        public List<SelectListItem> codResponsable { get; set; }
        [Display(Name = "Fecha Inspección")]
        public string FechaInspeccion { get; set; }

    }
    public class CodigoCatastralAsignado
    {
        public int Indice { get; set; }
        public string Distrito { get; set; }
        public string Sec { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Ed { get; set; }
        public string Entr { get; set; }
        public string Piso { get; set; }
        public string Unidad { get; set; }
        public string UbicacionPredio { get; set; }
        public string Titular { get; set; }
        /**/
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string TXTTIPOINTEDESCRIPCION { get; set; }
        public string CORRELUNIDAD { get; set; }
        public string CODUNI { get; set; }

        public string TipoTrabajo { get; set; }
        public string EstadoUnidad { get; set; }
        public string Referencia { get; set; }


        /**/
        public string CANTDIRECCION { get; set; }
        public string CANTCLASIFICACION { get; set; }
        public string CANTTITULARIDAD { get; set; }
        public string CANTOBSERVACION { get; set; }
        public string CANTLINEASCONSTRUCTIVAS { get; set; }
        public string CANTOTRASINSTALACIONES { get; set; }
        public string CANTAREATERRENO { get; set; }
    }

    public class RegistrarInspeccion
    {
        public RegistrarInspeccion()
        {
            codInspectores = new List<SelectListItem>();
        }
        public string temCodInspeccion { get; set; }
        public string Index { get; set; }
        [Display(Name = "Nro. Inspeccion")]
        public string NroInspeccion { get; set; }


        [Display(Name = "Fecha Vencimiento de Plazo")]
        public string FechaLimiteM { get; set; }

        [Display(Name = "Entrega a Análisis")]
        public string FechaLimiProgInspecM { get; set; }
        [Display(Name = "Entrega de Inspector")]
        public string FechaLimiteInspeccionM { get; set; }



        [Display(Name = "Fecha Inspección")]
        public string FechaInspeccion { get; set; }
        [Display(Name = "Fecha de Reprogramación")]
        public string FechaReprogramacion { get; set; }
        [Display(Name = "Hora Inspección")]
        public string HoraInspeccion { get; set; }
        [Display(Name = "Inspectores")]
        public string Inspectores { get; set; }
        public List<SelectListItem> codInspectores { get; set; }

        [Display(Name = "Inspector Responsable")]
        public string Responsable { get; set; }
        public List<SelectListItem> codResponsable { get; set; }

        [Display(Name = "Estado Inspección")]
        public string EstadoInspeccion { get; set; }
        [Display(Name = "Fecha Citación Entrega Resultados")]
        public string FechaCitacion { get; set; }
        [Display(Name = "Observación")]
        public string Observacion { get; set; }
        [Display(Name = "Fecha Aviso Inspección")]
        public string FechaAvisoInspeccion { get; set; }
        public IEnumerable<CodigoCatastralAsignado> ListunidadCatastral { get; set; }
        //public IEnumerable<RegistrarInspeccion> ListaInspeccion { get; set; }
        public string NumInspeccion { get; set; }
        public string TelefonoInspeccion { get; set; }
        public string Ubicacion { get; set; }

    }

    public class Inspectores
    {
        public string CodInspector { get; set; }
        public bool asignado { get; set; }
        public string NombreCompleto { get; set; }
        public bool Responsale { get; set; }
    }
}