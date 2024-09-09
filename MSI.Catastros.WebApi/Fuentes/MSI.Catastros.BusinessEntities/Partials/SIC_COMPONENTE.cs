using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_COMPONENTE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion
        
        public SIC_COMPONENTE() { }

        public SIC_COMPONENTE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOCOMP = reader.GetSafeString("CODTIPOCOMP");
                    CODCOMPO = reader.GetSafeString("CODCOMPO");
                    TXTDESCCOMPO = reader.GetSafeString("TXTDESCCOMPO");
                    TXTCODIGOA = reader.GetSafeString("TXTCODIGOA");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
