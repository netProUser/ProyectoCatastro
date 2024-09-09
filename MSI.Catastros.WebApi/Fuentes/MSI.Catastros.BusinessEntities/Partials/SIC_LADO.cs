using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LADO
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_LADO() { }

        public SIC_LADO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    break;
                case Query.Recuperar:
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    break;
                default:
                    break;
            }
        }
    }
}
