using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPODOCURRP
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion
        
        public SIC_TIPODOCURRP() { }

        public SIC_TIPODOCURRP(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
