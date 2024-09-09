
using System.Data;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_OBJETO
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        public SIC_OBJETO() { }

        public SIC_OBJETO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCLASE = reader.GetSafeString("CODCLASE");
                    CODSUBCLASE = reader.GetSafeString("CODSUBCLASE");
                    CODOBJETO = reader.GetSafeString("CODOBJETO");
                    TXTDESCOBJETO = reader.GetSafeString("TXTDESCOBJETO");
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
