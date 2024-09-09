using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INSCRIPCION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTORDEN { get; set; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_INSCRIPCION() { }

        public SIC_INSCRIPCION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODINSCCATA = reader.GetSafeString("CODINSCCATA");
                    TXTINSCRIPCION = reader.GetSafeString("TXTINSCRIPCION");
                    break;
                case Query.Recuperar:
                    CODINSCCATA = reader.GetSafeString("CODINSCCATA");
                    TXTINSCRIPCION = reader.GetSafeString("TXTINSCRIPCION");
                    break;
                default:
                    break;
            }
        }
    }
}
