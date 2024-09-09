using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMUCONFIG
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region CamposAdicionales
        public string TXTTIPOCAMPO { get; set; }
        public string TXTNOMBRE { get; set; }
        public string TXTDESPLE { get; set; }        
        #endregion
        public SIC_LOTEMUCONFIG() { }

        public SIC_LOTEMUCONFIG(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCORSCLASE = reader.GetSafeString("CODCORSCLASE");                    
                    TXTTIPOCAMPO = reader.GetSafeString("TXTTIPOCAMPO");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    TXTDESPLE = reader.GetSafeString("TXTDESPLE");
                    TXTVALOR = reader.GetSafeString("TXTVALOR");
                    break;
                case Query.Recuperar:
                    CODCORSCLASE = reader.GetSafeString("CODCORSCLASE");
                    TXTVALOR = reader.GetSafeString("TXTVALOR");
                    break;
                default:
                    break;
            }
        }
    }
}
