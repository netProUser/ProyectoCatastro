using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_USUCARCAT
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTNOMBRES { get; set; }
        public string TXTEMAIL { get; set; }
        public string TXTNOMAREA { get; set; }
        public string TXTDECCARG { get; set; }
        public string NUMCELCONTA { get; set; }
        #endregion
        public SIC_USUCARCAT() { }

        public SIC_USUCARCAT(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    TXTNOMBRES = reader.GetSafeString("TXTNOMBRES");
                    TXTEMAIL = reader.GetSafeString("TXTEMAIL");
                    TXTNOMAREA = reader.GetSafeString("TXTNOMAREA");
                    TXTDECCARG = reader.GetSafeString("TXTDECCARG");
                    break;
                case Query.Recuperar:
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    NUMCELCONTA = reader.GetSafeString("NUMCELCONTA");
                    /*CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    FLAGRESPONSABLE = reader.GetSafeString("FLAGRESPONSABLE");*/
                    break;
                default:
                    break;
            }
        }
    }
}
