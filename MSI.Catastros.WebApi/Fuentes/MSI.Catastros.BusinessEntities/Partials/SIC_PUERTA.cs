using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_PUERTA
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

        public SIC_PUERTA() { }

        public SIC_PUERTA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOPUER = reader.GetSafeString("CODTIPOPUER");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVI = reader.GetSafeString("TXTABREVI");
                    break;
                case Query.Recuperar:
                    CODTIPOPUER = reader.GetSafeString("CODTIPOPUER");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVI = reader.GetSafeString("TXTABREVI");
                    break;
                default:
                    break;
            }
        }
    }
}
