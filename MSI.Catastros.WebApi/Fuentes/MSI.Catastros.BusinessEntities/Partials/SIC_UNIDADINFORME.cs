using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADINFORME
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_UNIDADINFORME() { }

        public SIC_UNIDADINFORME(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDINFO = reader.GetSafeString("CODCORRUNIDINFO");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    CODRESPONSABLE = reader.GetSafeString("CODRESPONSABLE");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTNUMEDOCU = reader.GetSafeString("TXTNUMEDOCU");
                    break;
                default:
                    break;
            }
        }
    }
}
