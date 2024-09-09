using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CERTIFIRECI
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
        }

        #region Campos aumentados
        #endregion
        public SIC_CERTIFIRECI() { }

        public SIC_CERTIFIRECI(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Recuperar:

                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    CODCORRELCERE = reader.GetSafeString("CODCORRELCERE");
                    break;
                case Query.Listar:
                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODCORRELCERE = reader.GetSafeString("CODCORRELCERE");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    TXTRECIBO = reader.GetSafeString("TXTRECIBO");
                    FECRECIBO = reader.GetSafeDateTime("FECRECIBO");
                    break;
                default:
                    break;
            }
        }
    }
}
