using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INFORMESUBDETA
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
        }

        #region Campos aumentados
        
        #endregion
        public SIC_INFORMESUBDETA() { }

        public SIC_INFORMESUBDETA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    TXTSUBDETALLE = reader.GetSafeString("TXTSUBDETALLE");
                    TXTSUBTITULO = reader.GetSafeString("TXTSUBTITULO");
                    CODCORRELDETA = reader.GetSafeString("CODCORRELDETA");
                    CODSUBDETA = reader.GetSafeString("CODSUBDETA");
                    break;
                case Query.Recuperar:
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    CODANOINFO = reader.GetSafeString("CODANOINFO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODCORRELDETA = reader.GetSafeString("CODCORRELDETA");
                    TXTSUBTITULO = reader.GetSafeString("TXTSUBTITULO");
                    TXTSUBDETALLE = reader.GetSafeString("TXTSUBDETALLE");

                    break;
                default:
                    break;
            }
        }
    }
}
