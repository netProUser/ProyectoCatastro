using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_URBANIZACION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_URBANIZACION() { }

        public SIC_URBANIZACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODURBANIZACION = reader.GetSafeString("CODURBANIZACION");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODURBANIZACION = reader.GetSafeString("CODURBANIZACION");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    break;
                default:
                    break; 
            }
        }
    }
}
