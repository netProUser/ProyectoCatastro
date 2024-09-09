using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_USOCLAS
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

        public SIC_USOCLAS() { }

        public SIC_USOCLAS(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUSOCLAS = reader.GetSafeString("CODUSOCLAS");
                    CODUSOGENE = reader.GetSafeString("CODUSOGENE");
                    TXTUSOCLAS = reader.GetSafeString("TXTUSOCLAS");
                    break;
                case Query.Recuperar:
                    CODUSOCLAS = reader.GetSafeString("CODUSOCLAS");
                    CODUSOGENE = reader.GetSafeString("CODUSOGENE");
                    TXTUSOCLAS = reader.GetSafeString("TXTUSOCLAS");
                    break;
                default:
                    break;
            }
        }
    }
}
