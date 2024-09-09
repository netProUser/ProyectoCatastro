
using System.Data;
namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CLASEMOBU
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        public SIC_CLASEMOBU() { }

        public SIC_CLASEMOBU(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCLASE= reader.GetSafeString("CODCLASE");
                    TXTDESCLASE= reader.GetSafeString("TXTDESCLASE");                    
                    break;
                case Query.Recuperar:
                    break;
                default:
                    break;
            }
        }
    }
}
