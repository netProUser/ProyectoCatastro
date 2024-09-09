using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_HABURBAOBSER
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion
        
        public SIC_HABURBAOBSER() { }

        public SIC_HABURBAOBSER(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODCORRELOBS = reader.GetSafeString("CODCORRELOBS");
                    TXTOBSERVA = reader.GetSafeString("TXTOBSERVA");
                    break;
                case Query.Recuperar:
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODCORRELOBS = reader.GetSafeString("CODCORRELOBS");
                    TXTOBSERVA = reader.GetSafeString("TXTOBSERVA");
                    break;
                default:
                    break;
            }
        }
    }
}
