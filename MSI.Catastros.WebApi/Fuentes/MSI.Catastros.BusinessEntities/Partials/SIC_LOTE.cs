using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            RecuperarSolicitud,
            ListarInspec,
            ListarDocum,
        }

        #region Campos aumentados
        public string TXTNOMDOCU { get; set; }
        public string TXTNOMDOCUINT { get; set; }
        public string TXTALTURAEDIF { get; set; }
        public string TXTUSOPREDO { get; set; }
        public string NUMALTULOTE { get; set; }
        public string CODUSOCLAS { get; set; }

        public Nullable<DateTime> FECINSPE { get; set; }
        public string CODIGOUNIDAD { get; set; }
        public string TXTINSPECTORES { get; set; }
        public string TXTRESPONSABLE { get; set; }
        public string TXTOBSERVACION { get; set; }
        public string CODNROINSPEC { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string TXTDOCUMENTO { get; set; }
        public string TXTNUMERO { get; set; }
        public string TXTIDTRAMITE { get; set; }
        public string CODIGO_CATASTRAL { get; set; }
        public string CODCORRLOTEEXPEDOCU { get; set; }
        public string COD_RECURRENTE { get; set; }
        public string FLAG { get; set; }
        public string FLGHABILITADO { get; set; }
        public string CODREFANT { get; set; }
        public Nullable<DateTime> FECHA { get; set; }
        public string LOTECODCATANT { get; set; }

        #endregion

        public SIC_LOTE() { }

        public SIC_LOTE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.RecuperarSolicitud:
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    break;
                case Query.ListarDocum:
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTDOCUMENTO = reader.GetSafeString("TXTDOCUMENTO");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    FECHA = reader.GetSafeDateTime("FECHA");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTIDTRAMITE = reader.GetSafeString("TXTIDTRAMITE");
                    CODCORRLOTEEXPEDOCU = reader.GetSafeString("CODCORRLOTEEXPEDOCU");
                    FLAG = reader.GetSafeString("FLAG");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    COD_RECURRENTE = reader.GetSafeString("COD_RECURRENTE");
                    break;
                case Query.ListarInspec:
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    CODIGOUNIDAD = reader.GetSafeString("CODIGOUNIDAD");
                    TXTINSPECTORES = reader.GetSafeString("TXTINSPECTORES");
                    TXTRESPONSABLE = reader.GetSafeString("TXTRESPONSABLE");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    TXTDENOMINACION = reader.GetSafeString("TXTDENOMINACION");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    TXTDENOMINACION = reader.GetSafeString("TXTDENOMINACION");
                    FLGMONUHIST = reader.GetSafeString("FLGMONUHIST");
                    FLGLOTEESQU = reader.GetSafeString("FLGLOTEESQU");
                    CODTIPOLOTE = reader.GetSafeString("CODTIPOLOTE");
                    TXTLOTEURBA = reader.GetSafeString("TXTLOTEURBA");
                    TXTSUBLOTEURBA = reader.GetSafeString("TXTSUBLOTEURBA");
                    NUMAREATERRCAMP = reader.GetSafeDecimal("NUMAREATERRCAMP");
                    NUMAREATERROFIC = reader.GetSafeDecimal("NUMAREATERROFIC");
                    CODFUENTE = reader.GetSafeString("CODFUENTE");
                    NUMAREACONSTOTAL = reader.GetSafeDecimal("NUMAREACONSTOTAL");
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    TXTSECTVECI = reader.GetSafeString("TXTSECTVECI");
                    TXTSECTPLAN = reader.GetSafeString("TXTSECTPLAN");
                    TXTSECTSEGU = reader.GetSafeString("TXTSECTSEGU");
                    TXTSUBSECTVECI = reader.GetSafeString("TXTSUBSECTVECI");
                    TXTSUBSECTPLAN = reader.GetSafeString("TXTSUBSECTPLAN");
                    TXTSECTCATAS = reader.GetSafeString("TXTSECTCATAS");
                    TXTSUBSECTCATAS = reader.GetSafeString("TXTSUBSECTCATAS");
                    TXTNOMDOCU = reader.GetSafeString("TXTNOMDOCU");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    TXTALTURAEDIF = reader.GetSafeString("TXTALTURAEDIF");
                    TXTUSOPREDO = reader.GetSafeString("TXTUSOPREDO");
                    TXTRESONUM = reader.GetSafeString("TXTRESONUM");
                    FECRESOLUC = reader.GetSafeDateTime("FECRESOLUC");
                    FLGHABILITADO = reader.GetSafeString("FLGHABILITADO");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    LOTECODCATANT = reader.GetSafeString("LOTECODCATANT");
                    CODLOTECATASTRAL = reader.IsColumnExists("CODLOTECATASTRAL") ? reader.GetSafeString("CODLOTECATASTRAL") : "";
                    

                    break;
                default:
                    break;
            }
        }

        public string CODNUMESOLI { get; set; }
    }
}
