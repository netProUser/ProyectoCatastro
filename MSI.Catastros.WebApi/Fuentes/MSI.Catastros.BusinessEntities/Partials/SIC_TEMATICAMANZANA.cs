using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TEMATICAMANZANA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_TEMATICAMANZANA() { }

        public SIC_TEMATICAMANZANA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTEMATICO = reader.GetSafeString("CODTEMATICO");
                    TXTTEMATICO = reader.GetSafeString("TXTTEMATICO");
                    break;
                case Query.Recuperar:
                    CODTEMATICO = reader.GetSafeString("CODTEMATICO");
                    TXTTEMATICO = reader.GetSafeString("TXTTEMATICO");
                    break;
                default:
                    break;
            }
        }
    }
}
