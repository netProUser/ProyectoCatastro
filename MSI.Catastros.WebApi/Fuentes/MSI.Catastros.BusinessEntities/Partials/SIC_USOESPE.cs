using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_USOESPE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_USOESPE() { }

        public SIC_USOESPE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    TXTUSOESPE = reader.GetSafeString("TXTUSOESPE");
                    break;
                case Query.Recuperar:
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    TXTUSOESPE = reader.GetSafeString("TXTUSOESPE");
                    CODUSOCLAS = reader.GetSafeString("CODUSOCLAS");
                    break;
                default:
                    break;
            }
        }
    }
}
