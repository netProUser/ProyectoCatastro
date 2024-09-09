using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_EDIFICACION
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

        public SIC_EDIFICACION() { }

        public SIC_EDIFICACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOEDIF = reader.GetSafeString("CODTIPOEDIF");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVANT = reader.GetSafeString("TXTABREVANT");
                    break;
                case Query.Recuperar:
                    CODTIPOEDIF = reader.GetSafeString("CODTIPOEDIF");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVANT = reader.GetSafeString("TXTABREVANT");
                    break;
                default:
                    break;
            }
        }
    }
}
