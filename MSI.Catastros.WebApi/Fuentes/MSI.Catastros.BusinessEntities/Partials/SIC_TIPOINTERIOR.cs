using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPOINTERIOR
    {

        public enum Query
        {
            None,
            Listar,
            Recuperar
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_TIPOINTERIOR() { }

        public SIC_TIPOINTERIOR(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    break;
                case Query.Recuperar:
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVANT = reader.GetSafeString("TXTABREVANT");
                    break;
                default:
                    break;
            }
            
            
        }
    }
}
