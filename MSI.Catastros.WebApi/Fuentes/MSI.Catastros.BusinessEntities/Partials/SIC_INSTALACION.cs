using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INSTALACION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        public SIC_INSTALACION() { }

        public SIC_INSTALACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODINSTALACION = reader.GetSafeString("CODINSTALACION");
                    TXTINSTALACION = reader.GetSafeString("TXTINSTALACION");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
