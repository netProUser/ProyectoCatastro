using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MANZAVIAVALOR
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_MANZAVIAVALOR() { }

        public SIC_MANZAVIAVALOR(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODANOVAL = reader.GetSafeString("CODANOVAL");
                    NUMVALOR = reader.GetSafeDecimal("NUMVALOR");
                    break;
                default:
                    break;
            }
        }
    }
}
