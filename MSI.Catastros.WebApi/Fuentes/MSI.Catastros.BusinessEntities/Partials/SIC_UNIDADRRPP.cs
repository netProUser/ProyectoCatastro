using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADRRPP
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTTIPODOCU { get; set; }
        public Nullable<DateTime> FECDOCUMENTO { get; set; }
        public string CODTIPODOCU { get; set; }
        public string TXTPARTELEC { get; set; }
        public string TXTTOMOFICH { get; set; }
        public string TXTFOLIO { get; set; }
        public string TXTASIENTO { get; set; }
        public bool ESTATICO { get; set; }
        #endregion

        public SIC_UNIDADRRPP() { }

        public SIC_UNIDADRRPP(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDRRPP = reader.GetSafeString("CODCORRUNIDRRPP");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTPARTELEC = reader.GetSafeString("TXTPARTELEC");
                    TXTTOMOFICH = reader.GetSafeString("TXTTOMOFICH");
                    TXTFOLIO = reader.GetSafeString("TXTFOLIO");
                    TXTASIENTO = reader.GetSafeString("TXTASIENTO");
                    TXTTIPODOCU = reader.GetSafeString("TXTTIPODOCU");
                    CODCORRLOTERRPP = reader.GetSafeString("CODCORRLOTERRPP");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDRRPP = reader.GetSafeString("CODCORRUNIDRRPP");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTPARTELEC = reader.GetSafeString("TXTPARTELEC");
                    TXTTOMOFICH = reader.GetSafeString("TXTTOMOFICH");
                    TXTFOLIO = reader.GetSafeString("TXTFOLIO");
                    TXTASIENTO = reader.GetSafeString("TXTASIENTO");
                    break;
                default:
                    break;
            }
        }
    }
}
