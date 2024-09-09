using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLICITUD
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Buscar,
            Seguimiento,
            RecepcionDocumento,
            RecepcionDocumentoExterno,
            RecepcionDocumentoInterno,
            RecuperarDatosRelevantes
        }

        #region Campos aumentados
        public string TXTAREASOLICITANTE { set; get; }
        public string TXTPUESTOREMITENTE { set; get; }
        public string TXTPUESTORECEPCION { set; get; }
        public string TXTNOMBRETITULAR { set; get; }
        public string TXTTIPOLLENADO { set; get; }
        public string TXTATENCIONACTUAL { set; get; }
        public Nullable<DateTime> FECRECEPCION { set; get; }
        public Nullable<DateTime> FECLIMITE { set; get; }
        public string TXTFECLIMITE { get; set; }
        public string TXTFECLIMITEPROGINSP { get; set; }
        public string TXTFECLIMITEINSPECCION { get; set; }
        public string CODPARETA { set; get; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }

        public string COD_ACCION { set; get; }
        public string COD_ACTIVIDAD { set; get; }

        #endregion

        public SIC_SOLICITUD() { }

        public SIC_SOLICITUD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Buscar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODAREASOLI = reader.GetSafeString("CODAREASOLI");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    FECFINSOLICITUD = reader.GetSafeDateTime("FECFINSOLICITUD");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODESTADOFINAL = reader.GetSafeString("CODESTADOFINAL");
                    NUMFOLSOL = reader.GetSafeInt32("NUMFOLSOL");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    TXTAREASOLICITANTE = "";
                    TXTPUESTOREMITENTE = "";
                    TXTPUESTORECEPCION = "";
                    break;
                case Query.Seguimiento:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    TXTATENCIONACTUAL = reader.GetSafeString("TXTATENCIONACTUAL");
                    TXTNOMBRETITULAR = reader.GetSafeString("TXTRAZONSOCIAL");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    FECLIMITE = reader.GetSafeDateTime("FECLIMITE");
                    CODPARETA = reader.GetSafeString("CODPARETA");
                    break;
                case Query.Recuperar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODAREASOLI = reader.GetSafeString("CODAREASOLI");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    FECFINSOLICITUD = reader.GetSafeDateTime("FECFINSOLICITUD");
                    FECRECEP = reader.GetSafeDateTime("FECRECEP");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    CODESTADOFINAL = reader.GetSafeString("CODESTADOFINAL");
                    NUMFOLSOL = reader.GetSafeInt32("NUMFOLSOL");
                    NUMCALVER = reader.GetSafeInt32("NUMCALVER");
                    TXTANOCALVER = reader.GetSafeString("TXTANOCALVER");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    ID_REF = reader.GetSafeString("ID_REF");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTREPRESENTANTEL = reader.GetSafeString("TXTREPRESENTANTEL");
                    break;
                case Query.RecepcionDocumento:

                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    TXTTIPOSOLI = reader.GetSafeString("TXTTIPOSOLI");
                    CODAREASOLI = reader.GetSafeString("CODAREASOLI");
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    FECSOLICITUD = reader.GetSafeDateTime("FECSOLICITUD");
                    FECFINSOLICITUD = reader.GetSafeDateTime("FECFINSOLICITUD");
                    FECRECEP = reader.GetSafeDateTime("FECRECEP");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODESTADOFINAL = reader.GetSafeString("CODESTADOFINAL");
                    NUMFOLSOL = reader.GetSafeInt32("NUMFOLSOL");
                    NUMCALVER = reader.GetSafeInt32("NUMCALVER");
                    TXTANOCALVER = reader.GetSafeString("TXTANOCALVER");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    TXTTIPODOC = reader.GetSafeString("TXTTIPODOC");
                    ID_REF = reader.GetSafeString("ID_REF");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTREPRESENTANTEL = reader.GetSafeString("TXTREPRESENTANTEL");
                    CORMAXSOLI = reader.GetSafeString("CORMAXSOLI");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    USUARIORECEPCION = reader.GetSafeString("USUARIORECEPCION");
                    USUARIOENVIA = reader.GetSafeString("USUARIOENVIA");
                    NRO = reader.GetSafeInt32("NRO");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    PRIMERAASIGNACION = reader.GetSafeString("PRIMERAASIGNACION");


                    break;
                case Query.RecepcionDocumentoExterno:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    TXTTIPOSOLI = reader.GetSafeString("TXTTIPOSOLI");
                    NRO = reader.GetSafeInt32("NRO");
                    CODNUMESOLI = reader.GetSafeString("NRODOC");
                    CODTIPODOC = reader.GetSafeString("TIPO_DOCUMENTO");
                    CODAREASOLI = reader.GetSafeString("DESC_AREA");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    NUMFOLSOL = reader.GetSafeInt32("NUMFOLSOL");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    USUARIORECEPCION = reader.GetSafeString("USUAIORECEPCION");
                    TXTPUESTOREMITENTE = reader.GetSafeString("TXTPUESTOREMITENTE");
                    PRIMERAASIGNACION = reader.GetSafeString("PRIMERAASIGNACION");
                    ID_REF = reader.GetSafeString("VID_REF");
                    CODIGO_CONTRIBUYENTE = reader.GetSafeString("CODIGO_CONTRIBUYENTE");
                    COD_RECURRENTE = reader.GetSafeString("COD_RECURRENTE");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTDESC_TIPODOCREC = reader.GetSafeString("DES_TIPODOCREC");
                    TXTDOCIDRECURRENTE = reader.GetSafeString("DOCIDRECURRENTE");
                    TXTREPRESENTANTEL = reader.GetSafeString("TXTREPRESENTANTEL");
                    TXTCODTIPODOCUMENTOREC = reader.GetSafeString("TXTCODTIPODOCREPLEGAL");
                    TXTDES_TIPODOCREPL = reader.GetSafeString("TXTDES_TIPODOCREPL");
                    TXTCODTIPODOCREPLEGAL = reader.GetSafeString("TXTCODTIPODOCREPLEGAL");
                    TXTDOCIDEREPRESENTANTEL = reader.GetSafeString("TXTDOCIDEREPRESENTANTEL");
                    CORMAXSOLI = reader.GetSafeString("CORMAXSOLI");
                    break;
                case Query.RecepcionDocumentoInterno:
                    TXTAREASOLICITANTE = reader.GetSafeString("TXTDESCRIPCIONAREA");
                    CODAREASOLI = reader.GetSafeString("CODAREA");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    CODNUMESOLI = reader.GetSafeString("NRODOC");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    NUMFOLSOL = reader.GetSafeInt32("NUMFOLSOL");
                    CODIGO_CONTRIBUYENTE = reader.GetSafeString("CODIGO_CONTRIBUYENTE");
                    COD_ACTIVIDAD = reader.GetSafeString("CODACTIVIDAD");
                    COD_ACCION = reader.GetSafeString("CODACCION");
                    FECRECEPCION = reader.GetSafeDateTime("FECRECEPCION");
                    USUARIORECEPCION = reader.GetSafeString("USUARIORECEPCION");
                    NRO = reader.GetSafeInt32("NRO");
                    ID_REF = reader.GetSafeString("VID_REF");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    PRIMERAASIGNACION = reader.GetSafeString("PRIMERAASIGNACION");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    TXTTIPOSOLI = reader.GetSafeString("TXTTIPOSOLI");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    CORMAXSOLI = reader.GetSafeString("CORMAXSOLI");
                    break;
                case Query.RecuperarDatosRelevantes:

                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    PRIMERAASIGNACION = reader.GetSafeString("PRIMERAASIGNACION");
                    break;

                default:
                    break;
            }
        }
    }
}
