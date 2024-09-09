using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_PARAMETROS
    {
        public enum Query
        {
            None,
            Datos,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_PARAMETROS() { }

        public SIC_PARAMETROS(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Datos:
                    CODPARAMETRO = reader.GetSafeString("CODPARAMETRO");
                    TXTDESCRIPCION = reader.GetSafeString("DESCRIPCION");
                    break;
                default:
                    CODGRUPOPARAMETRO = reader.GetSafeInt32("CODGRUPOPARAMETRO");
                    CODPARAMETRO = reader.GetSafeString("CODPARAMETRO");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVIATURA = reader.GetSafeString("TXTABREVIATURA");
                    break;
            }
        }
    }
}
