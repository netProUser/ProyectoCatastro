using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEOTRODOC
    {
        public enum Query
        {
            None,
            ListarOtrosDocumentos,
            ListarTipoOtrosDocumentos,
        }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public SIC_LOTEOTRODOC() { }

        public SIC_LOTEOTRODOC(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
              
                case Query.ListarOtrosDocumentos:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    CORRELATIVO = reader.GetSafeString("CORRELATIVO");
                    CODDOCUMENTO = reader.GetSafeString("CODDOCUMENTO");
                    TXTNRODOCUMENTO = reader.GetSafeString("TXTNRODOCUMENTO");
                    TXTRUTAPDF = reader.GetSafeString("TXTRUTAPDF");
                    PDFHABILITADO = reader.GetSafeString("PDFHABILITADO");
                    TXTTIPODOCU = reader.GetSafeString("TXTTIPODOCU");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    break;
                case Query.ListarTipoOtrosDocumentos:
                    TXTDOCUMENTO = reader.GetSafeString("TXTDOCUMENTO");
                    CODDOCUMENTO = reader.GetSafeString("CODDOCUMENTO");
                    
                    break;
                default:
                    break;
            }
        }
    }
}
