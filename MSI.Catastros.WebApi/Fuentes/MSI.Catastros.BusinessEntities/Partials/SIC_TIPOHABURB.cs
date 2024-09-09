using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPOHABURB
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_TIPOHABURB() { }

        public SIC_TIPOHABURB(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    TXTHABILITAURBA = reader.GetSafeString("TXTHABILITAURBA");
                    break;
                case Query.Recuperar:
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    TXTHABILITAURBA = reader.GetSafeString("TXTHABILITAURBA");
                    ESTADO = reader.GetSafeString("ESTADO");
                    break;
                default:
                    break;
            }
        }
    }
}
