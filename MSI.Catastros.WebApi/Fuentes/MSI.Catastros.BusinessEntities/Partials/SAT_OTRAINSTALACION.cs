using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SAT_OTRAINSTALACION
    {
        public enum Query
        {
            None,
            Listar,
            ListarOtra,
            Recuperar,
        }

        #region Campos aumentados
        public string CODUNIDADMEDIDA { get; set; }
        #endregion

        public SAT_OTRAINSTALACION() { }

        public SAT_OTRAINSTALACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODANIOINSTALACION = reader.GetSafeString("CODANIOINSTALACION");
                    CODOTRAINSTALACION = reader.GetSafeString("CODOTRAINSTALACION");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    break;
                case Query.ListarOtra:
                    CODANIOINSTALACION = reader.GetSafeString("CODANIOINSTALACION");
                    CODOTRAINSTALACION = reader.GetSafeString("CODOTRAINSTALACION");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    CODUNIDADMEDIDA = reader.GetSafeString("CODUNIDADMEDIDA");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
