using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_ESTADOATENCION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_ESTADOATENCION() { }

        public SIC_ESTADOATENCION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODESTATENCION = reader.GetSafeString("CODESTATENCION");
                    TXTESTADOATENCION = reader.GetSafeString("TXTESTADOATENCION");
                    break;
                case Query.Recuperar:
                    CODESTATENCION = reader.GetSafeString("CODLADO");
                    TXTESTADOATENCION = reader.GetSafeString("TXTESTADOATENCION");
                    break;
                default:
                    break;
            }
        }
    }
}
