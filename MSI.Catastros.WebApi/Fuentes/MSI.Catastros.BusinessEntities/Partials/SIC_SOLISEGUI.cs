using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLISEGUI
    {
        public enum Query
        {
            None,
            Filtrar,
            Recuperar,
            RecuperarError,
            Buscar,
            Informe,
            Carta,
            Nuevo,
            Inicial,
            Seguimiento,
            RecepcionarDocumento
        }

        #region Campos aumentados
        public string TXTSOLICITANTE { get; set; }
        public string TXTAREASOLICITANTE { set; get; }
        public string TXTPUESTOREMITENTE { set; get; }
        public string TXTPUESTORECEPCION { set; get; }
        public string TXTESTADOATENCION { set; get; }
        public string TXTNOMBREREMITENTE { set; get; }
        public string TXTNOMBRERECEPCION { set; get; }
        public string TXTNOMBREPROCEDIMIENTO { set; get; }
        public string TXTNOMBREREQUERIMIENTO { set; get; }
        public string TXTNOMBRELLENADO { set; get; }
        public string TXTASUNTO { set; get; }
        public string CODNROINSPEC { get; set; }
        public string NUMCALVER { get; set; }
        public Nullable<DateTime> FECSOLICITUD { set; get; }
        public string TXTNROINSPECCION { set; get; }
        public string TXTNROACTUALIZACION { set; get; }
        public string TXTATENCIONPREVIA { set; get; }
        public string TXTATENCIONACTUAL { set; get; }
        public string TXTTIPOSOLICITUD { set; get; }
        public string TXTTIPODOCUMENTO { set; get; }
        public string FECHALIMITE { set; get; }
        public string FECHALIMITEINSPECCION { set; get; }
        public string FECHALIMITEACTUALIZACION { set; get; }
        public string FECHALIMITEINFORME { get; set; }
        public string CODPARETA { get; set; }
        public string CODTIPODOC { get; set; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public Nullable<DateTime> FECINSPE { get; set; }
        public string TXTHORAINSP { get; set; }

        #endregion
        public SIC_SOLISEGUI() { }

        public SIC_SOLISEGUI(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Informe:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    TXTNOMBRELLENADO = reader.GetSafeString("TXTNOMBRELLENADO");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    NUMCALVER = reader.GetSafeString("NUMCALVER");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    break;
                case Query.Carta:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    TXTNOMBRELLENADO = reader.GetSafeString("TXTNOMBRELLENADO");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    NUMCALVER = reader.GetSafeString("NUMCALVER");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    FECLIMITEI = reader.GetSafeDateTime("FECLIMITEI");
                    FECLIMITE = reader.GetSafeDateTime("FECLIMITE");
                    break;
                case Query.Inicial:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    TXTNOMBREPROCEDIMIENTO = reader.GetSafeString("TXTNOMBREPROCEDIMIENTO");
                    TXTNOMBREREQUERIMIENTO = reader.GetSafeString("TXTNOMBREREQUERIMIENTO");
                    TXTNOMBRELLENADO = reader.GetSafeString("TXTNOMBRELLENADO");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    FECHALIMITE = reader.GetSafeString("FECLIMITE");
                    FECHALIMITEINSPECCION = reader.GetSafeString("FECLIMITEI");
                    FECHALIMITEACTUALIZACION = reader.GetSafeString("FECLIMIACT");
                    FECHALIMITEINFORME = reader.GetSafeString("FECLIMIANA");
                    FECMODIF = reader.GetSafeDateTime("FECMODIF");
                    TXTNROACTUALIZACION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    TXTATENCIONACTUAL = reader.GetSafeString("TXTATENCIONACTUAL");
                    FECPROGAINSPE = reader.GetSafeDateTime("FECPROGAINSPE");
                    break;
                case Query.Nuevo:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    TXTNOMBREPROCEDIMIENTO = reader.GetSafeString("TXTNOMBREPROCEDIMIENTO");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    TXTNROINSPECCION = "";
                    TXTNROACTUALIZACION = "";
                    TXTATENCIONPREVIA = reader.GetSafeString("TXTATENCIONPREVIA");
                    TXTATENCIONACTUAL = reader.GetSafeString("TXTATENCIONACTUAL");
                    break;
                case Query.Buscar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    NUMFOLIOS = reader.GetSafeInt32("NUMFOLIOS");
                    TXTAREASOLICITANTE = "";
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    TXTPUESTORECEPCION = reader.GetSafeString("TXTPUESTORECEPCION");
                    CODRESPENVIA = reader.GetSafeString("CODRESPENVIA");
                    CODRESPRECIBE = reader.GetSafeString("CODRESPRECIBE");
                    break;
                case Query.Seguimiento:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    TXTTIPOSOLICITUD = reader.GetSafeString("TXTTIPOSOLICITUD");
                    TXTTIPODOCUMENTO = reader.GetSafeString("TXTTIPODOCUMENTO");
                    TXTAREASOLICITANTE = reader.IsColumnExists("TXTNOMBREAREA") ? reader.GetSafeString("TXTNOMBREAREA") : "";
                    TXTNOMBREPROCEDIMIENTO = reader.GetSafeString("TXTNOMBREPROCEDIMIENTO");
                    TXTNOMBREREMITENTE = reader.GetSafeString("TXTNOMBREREMITENTE");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    TXTPUESTORECEPCION = reader.GetSafeString("TXTPUESTORECEPCION");
                    TXTATENCIONACTUAL = reader.GetSafeString("TXTATENCIONACTUAL");
                    TXTNOMBREREQUERIMIENTO = reader.GetSafeString("TXTNOMBREREQUERIMIENTO");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECLIMIACT = reader.GetSafeDateTime("FECLIMIACT");
                    FECLIMITEI = reader.GetSafeDateTime("FECLIMITEI");
                    FECLIMIANA = reader.GetSafeDateTime("FECLIMIANA");
                    CODPARETA = reader.GetSafeString("CODPARETA");
                    break;
                case Query.Recuperar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    TXTESTADOATENCION = reader.GetSafeString("TXTESTADOATENCION");
                    TXTATENCIONPREVIA = reader.GetSafeString("TXTATENCIONPREVIA");
                    TXTNOMBREREMITENTE = reader.GetSafeString("TXTNOMBREREMITENTE");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    TXTPUESTORECEPCION = reader.GetSafeString("TXTPUESTORECEPCION");
                    CODRESPENVIA = reader.GetSafeString("CODRESPENVIA");
                    CODRESPRECIBE = reader.GetSafeString("CODRESPRECIBE");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    NUMFOLIOS = reader.GetSafeInt32("NUMFOLIOS");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPOREQ = reader.GetSafeString("CODTIPOREQ");
                    CODESTATENCION = reader.GetSafeString("CODESTATENCION");
                    CODESTATENCIONE = reader.GetSafeString("CODESTATENCIONE");
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODCARCATE = reader.GetSafeString("CODCARCATE");
                    CODACCION = reader.GetSafeString("CODACCION");
                    CODACTIVIDAD = reader.GetSafeString("CODACTIVIDAD");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    TXTNOMBREREQUERIMIENTO = reader.GetSafeString("TXTNOMBREREQUERIMIENTO");

                    //TXTDES_TIPODOCREPL = reader.GetSafeString("TXTDES_TIPODOCREPL");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTREPRESENTANTEL = reader.GetSafeString("TXTREPRESENTANTEL");
                    TXTUBICACION = reader.IsColumnExists("TXTUBICACION") ? reader.GetSafeString("TXTUBICACION") : "";
                    TXTTELEFONO = reader.IsColumnExists("TXTTELEFONO") ? reader.GetSafeString("TXTTELEFONO") : "";

                    FECLIMITE = reader.GetSafeDateTime("FECLIMITE") ;
                    FECPROGAINSPE = reader.GetSafeDateTime("FECPROGAINSPE") ;
                    FECLIMITEI = reader.GetSafeDateTime("FECLIMITEI");

                    CODTIPOLLENA = reader.IsColumnExists("CODTIPOLLENA") ? reader.GetSafeString("CODTIPOLLENA") : "";


                    break;
                case Query.Filtrar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    TXTESTADOATENCION = reader.GetSafeString("TXTESTADOATENCION");
                    TXTATENCIONPREVIA = reader.GetSafeString("TXTATENCIONPREVIA");
                    TXTNOMBREREMITENTE = reader.GetSafeString("TXTNOMBREREMITENTE");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    TXTPUESTORECEPCION = reader.GetSafeString("TXTPUESTORECEPCION");
                    CODRESPENVIA = reader.GetSafeString("CODRESPENVIA");
                    CODRESPRECIBE = reader.GetSafeString("CODRESPRECIBE");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    NUMFOLIOS = reader.GetSafeInt32("NUMFOLIOS");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPOREQ = reader.GetSafeString("CODTIPOREQ");
                    CODESTATENCION = reader.GetSafeString("CODESTATENCION");
                    CODESTATENCIONE = reader.GetSafeString("CODESTATENCIONE");
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODCARCATE = reader.GetSafeString("CODCARCATE");
                    CODACCION = reader.GetSafeString("CODACCION");
                    CODACTIVIDAD = reader.GetSafeString("CODACTIVIDAD");
                    break;
                case Query.RecuperarError:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    TXTESTADOATENCION = reader.GetSafeString("TXTESTADOATENCION");
                    TXTATENCIONPREVIA = reader.GetSafeString("TXTATENCIONPREVIA");
                    TXTNOMBREREMITENTE = reader.GetSafeString("TXTNOMBREREMITENTE");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    TXTPUESTORECEPCION = reader.GetSafeString("TXTPUESTORECEPCION");
                    CODRESPENVIA = reader.GetSafeString("CODRESPENVIA");
                    CODRESPRECIBE = reader.GetSafeString("CODRESPRECIBE");
                    FECENVIO = reader.GetSafeDateTime("FECENVIO");
                    NUMFOLIOS = reader.GetSafeInt32("NUMFOLIOS");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPOREQ = reader.GetSafeString("CODTIPOREQ");
                    CODESTATENCION = reader.GetSafeString("CODESTATENCION");
                    CODESTATENCIONE = reader.GetSafeString("CODESTATENCIONE");
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODCARCATE = reader.GetSafeString("CODCARCATE");
                    CODACCION = reader.GetSafeString("CODACCION");
                    CODACTIVIDAD = reader.GetSafeString("CODACTIVIDAD");
                    //CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    break;
                case Query.RecepcionarDocumento:
                    break;
                default:
                    break;
            }
        }
    }
}
