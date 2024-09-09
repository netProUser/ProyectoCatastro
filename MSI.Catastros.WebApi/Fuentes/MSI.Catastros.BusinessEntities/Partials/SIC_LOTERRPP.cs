using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTERRPP
    {
        public enum Query
        {
            None,
            Listar,
            ListarOtrosDocumentos,
            Recuperar,
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public string TXTTIPODOCU { set; get; }
        #endregion
        
        public SIC_LOTERRPP() { }

        public SIC_LOTERRPP(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODCORRLOTERRPP = reader.GetSafeString("CODCORRLOTERRPP");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTPARTELEC = reader.GetSafeString("TXTPARTELEC");
                    TXTTOMOFICH = reader.GetSafeString("TXTTOMOFICH");
                    TXTFOLIO = reader.GetSafeString("TXTFOLIO");
                    TXTASIENTO = reader.GetSafeString("TXTASIENTO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    TXTTIPODOCU = reader.GetSafeString("TXTTIPODOCU");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODCORRLOTERRPP = reader.GetSafeString("CODCORRLOTERRPP");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTPARTELEC = reader.GetSafeString("TXTPARTELEC");
                    TXTTOMOFICH = reader.GetSafeString("TXTTOMOFICH");
                    TXTFOLIO = reader.GetSafeString("TXTFOLIO");
                    TXTASIENTO = reader.GetSafeString("TXTASIENTO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    break;
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
                default:
                    break;
            }
        }
    }
}
