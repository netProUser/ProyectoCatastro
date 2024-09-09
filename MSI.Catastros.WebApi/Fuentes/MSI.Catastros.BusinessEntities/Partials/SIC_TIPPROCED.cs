using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPPROCED
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_TIPPROCED() { }

        public SIC_TIPPROCED(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    TXTDESCPRO = reader.GetSafeString("TXTDESCPRO");
                    break;
                case Query.Recuperar:
                    CODTIPPROC = reader.GetSafeString("CODTIPPROC");
                    TXTDESCPRO = reader.GetSafeString("TXTDESCPRO");
                    ESTADO = reader.GetSafeString("ESTADO");
                    break;
                default:
                    break;
            }
        }
    }
}
