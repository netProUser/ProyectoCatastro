using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MOVINSPEC
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Inspectores
        }

        #region Campos aumentados
        public string TXTNOMBRE { get; set; }
        public string TXTCARGO { get; set; }
        public string TXTNOMAREA { get; set; }

        public string FECINSPE { get; set; }
        #endregion
        public SIC_MOVINSPEC() { }

        public SIC_MOVINSPEC(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCORRELINSP = reader.GetSafeString("CODCORRELINSP");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    TXTCARGO = reader.GetSafeString("TXTCARGO");
                    FLAGRESPONSABLE = reader.GetSafeString("FLAGRESPONSABLE");
                    break;
                case Query.Inspectores:
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRES");
                    TXTCARGO = reader.GetSafeString("TXTDECCARG");
                    TXTNOMAREA = reader.GetSafeString("TXTNOMAREA");
                    break;
                case Query.Recuperar:
                    CODCORRELINSP = reader.GetSafeString("CODCORRELINSP");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    FLAGRESPONSABLE = reader.GetSafeString("FLAGRESPONSABLE");
                    break;
                default:
                    break;
            }
        }
    }
}
