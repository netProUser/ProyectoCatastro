using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEAUTOLICE
    {
        

        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public string CODGIRO { get; set; }
        #endregion

        public SIC_LOTEAUTOLICE() { }

        public SIC_LOTEAUTOLICE(IDataReader reader, Query query = Query.None)
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
                    CODCORRLOTEAUTOLICE = reader.GetSafeString("CODCORRLOTEAUTOLICE");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTBENEFICIARIO = reader.GetSafeString("TXTBENEFICIARIO");
                    TXTTIPOLICENCIA = reader.GetSafeString("TXTTIPOLICENCIA");
                    TXTNUMLICENCIA = reader.GetSafeString("TXTNUMLICENCIA");
                    FECLICENCIA = reader.GetSafeDateTime("FECLICENCIA");
                    TXTGIRO = reader.GetSafeString("TXTGIRO");
                    CODGIRO = reader.GetSafeString("CODGIRO");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODGIRO = reader.GetSafeString("CODGIRO");
                    CODCORRLOTEAUTOLICE = reader.GetSafeString("CODCORRLOTEAUTOLICE");
                    //CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    //CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    //TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    //FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    //TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    break;
                default:
                    break;
            }
        }
    }
}
