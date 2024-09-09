using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPOPROCINSPACT
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_TIPOPROCINSPACT() { }

        public SIC_TIPOPROCINSPACT(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOINSP = reader.GetSafeString("CODTIPOINSP");
                    CODTIPINSP = reader.GetSafeString("CODTIPINSP");
                    TXTDETALINSP = reader.GetSafeString("TXTDETALINSP");
                    break;
                case Query.Recuperar:
                    CODTIPOINSP = reader.GetSafeString("CODTIPOINSP");
                    CODTIPINSP = reader.GetSafeString("CODTIPINSP");
                    TXTDETALINSP = reader.GetSafeString("TXTDETALINSP");
                    break;
                default:
                    break;
            }
        }
    }
}
