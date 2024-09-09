using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TABPROCE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        
        #region Campos aumentados
        public string TXTNOMBRES { set; get; }
        public string TXTEMAIL { set; get; }
        public string TXTNOMAREA { set; get; }
        public string TXTDESCPRO { set; get; }
        public string TXTDECCARG { set; get; }
        public string TXTESTADO { set; get; }
        public string CODESTACTUAL { set; get; }
        public string TXTESTACTUAL { set; get; }
        public string CODESTANTER { set; get; }
        public string TXTESTANTER { set; get; }

        public Nullable<int> NUMESTADO { set; get; }
        #endregion
        public SIC_TABPROCE() { }
        public SIC_TABPROCE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUSUARIO = reader.GetSafeString("CODUSUASIS");
                    CODCARCATE = reader.GetSafeString("CODCARCATE");
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    TXTNOMBRES = reader.GetSafeString("TXTNOMBRES");
                    TXTEMAIL = reader.GetSafeString("TXTEMAIL");
                    TXTNOMAREA = reader.GetSafeString("TXTNOMAREA");
                    TXTDESCPRO = reader.GetSafeString("TXTDESCPRO");
                    TXTDECCARG = reader.GetSafeString("TXTDECCARG");
                    TXTESTADO = reader.GetSafeString("TXTESTADO");
                    NUMESTADO = reader.GetSafeInt32("NUMESTADO");

                    CODESTACTUAL = reader.GetSafeString("CODESTACTUAL");
                    TXTESTACTUAL = reader.GetSafeString("TXTESTACTUAL");
                    CODESTANTER = reader.GetSafeString("CODESTANTER");
                    TXTESTANTER = reader.GetSafeString("TXTESTANTER");
                    break;
                case Query.Recuperar:
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    CODCARCATE = reader.GetSafeString("CODCARCATE");
                    TXTNOMBRES = reader.GetSafeString("TXTNOMBRES");
                    TXTEMAIL = reader.GetSafeString("TXTEMAIL");
                    TXTNOMAREA = reader.GetSafeString("TXTNOMAREA");
                    TXTDECCARG = reader.GetSafeString("TXTDECCARG");
                    TXTESTADO = reader.GetSafeString("TXTESTADO");
                    break;
                default:
                    break;
            }
        }
    }
}
