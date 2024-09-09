using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SUBCLASEMOBU
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        public SIC_SUBCLASEMOBU() { }

        public SIC_SUBCLASEMOBU(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCLASE = reader.GetSafeString("CODCLASE");
                    CODSUBCLASE = reader.GetSafeString("CODSUBCLASE");
                    TXTDESCCOMPO = reader.GetSafeString("TXTDESCCOMPO");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
