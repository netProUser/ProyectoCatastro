using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_USOGENE
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

        public SIC_USOGENE() { }

        public SIC_USOGENE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUSOGENE = reader.GetSafeString("CODUSOGENE");
                    TXTUSOGENE = reader.GetSafeString("TXTUSOGENE");
                    TXTCODANTE = reader.GetSafeString("TXTCODANTE");
                    break;
                case Query.Recuperar:
                    CODUSOGENE = reader.GetSafeString("CODUSOGENE");
                    TXTUSOGENE = reader.GetSafeString("TXTUSOGENE");
                    TXTCODANTE = reader.GetSafeString("TXTCODANTE");
                    break;
                default:
                    break;
            }
        }
    }
}

