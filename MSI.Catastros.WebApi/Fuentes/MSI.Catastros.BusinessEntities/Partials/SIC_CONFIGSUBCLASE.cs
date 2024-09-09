using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONFIGSUBCLASE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        public SIC_CONFIGSUBCLASE() { }

        public SIC_CONFIGSUBCLASE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCLASE = reader.GetSafeString("CODCLASE");
                    CODSUBCLASE = reader.GetSafeString("CODSUBCLASE");
                    CODCORSCLASE = reader.GetSafeString("CODCORSCLASE");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    TXTTIPOCAMPO = reader.GetSafeString("TXTTIPOCAMPO");
                    TXTTAMANO = reader.GetSafeString("TXTTAMANO");
                    TXTDESPLE = reader.GetSafeString("TXTDESPLE");
                    TXTORDEN = reader.GetSafeString("TXTORDEN");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
