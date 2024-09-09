using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONFIGOBJETO
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        public SIC_CONFIGOBJETO() { }

        public SIC_CONFIGOBJETO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODSUBCLASE = reader.GetSafeString("CODSUBCLASE");
                    CODCLASE = reader.GetSafeString("CODCLASE");
                    CODOBJETO = reader.GetSafeString("CODOBJETO");
                    TXTNOMBREO = reader.GetSafeString("TXTNOMBREO");
                    TXTORDENO = reader.GetSafeString("TXTORDENO");
                    TXTIPOCAMPOB = reader.GetSafeString("TXTIPOCAMPOB");
                    TXTTAMANOB = reader.GetSafeString("TXTTAMANOB");
                    TXTDESPLEOB = reader.GetSafeString("TXTDESPLEOB");
                    CODCONFOBJETO = reader.GetSafeString("CODCONFOBJETO");
                    break;
                case Query.Recuperar:
                    CODSUBCLASE = reader.GetSafeString("CODSUBCLASE");
                    CODCLASE = reader.GetSafeString("CODCLASE");
                    CODOBJETO = reader.GetSafeString("CODOBJETO");
                    TXTNOMBREO = reader.GetSafeString("TXTNOMBREO");
                    TXTORDENO = reader.GetSafeString("TXTORDENO");
                    TXTIPOCAMPOB = reader.GetSafeString("TXTIPOCAMPOB");
                    TXTTAMANOB = reader.GetSafeString("TXTTAMANOB");
                    TXTDESPLEOB = reader.GetSafeString("TXTDESPLEOB");
                    CODCONFOBJETO = reader.GetSafeString("CODCONFOBJETO");
                    break;
                default:
                    break;
            }
        }
    }
}
