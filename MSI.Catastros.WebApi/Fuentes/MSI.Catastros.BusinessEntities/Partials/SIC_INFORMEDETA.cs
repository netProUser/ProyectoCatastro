using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INFORMEDETA
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
            ListarDetalle,
        }

        #region Campos aumentados
        public string TXTSUBTITULO { get; set; }
        public string CODTIPODETALLE { get; set; }
        #endregion
        public SIC_INFORMEDETA() { }

        public SIC_INFORMEDETA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    CODCORRINFO = reader.GetSafeString("CODCORRINFO");
                    TXTTITULO = reader.GetSafeString("TXTTITULO");
                    CODCORRELDETA = reader.GetSafeString("CODCORRELDETA");
                    TXTSUBTITULO = reader.GetSafeString("TXTSUBTITULO");
                    CODTIPODETALLE = reader.GetSafeString("CODTIPODETALLE");
                    break;
                case Query.Recuperar:
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    CODCORRINFO = reader.GetSafeString("CODCORRINFO");
                    CODANOINFO = reader.GetSafeString("CODANOINFO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODCORRELDETA = reader.GetSafeString("CODCORRELDETA");
                    TXTTITULO = reader.GetSafeString("TXTTITULO");
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    TXTRUTA = reader.GetSafeString("TXTRUTA");
                    CODTIPODETALLE = reader.GetSafeString("CODTIPODETALLE");
                    break;
                case Query.ListarDetalle:
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    CODCORRINFO = reader.GetSafeString("CODCORRINFO");
                    CODANOINFO = reader.GetSafeString("CODANOINFO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    TXTTITULO = reader.GetSafeString("TXTTITULO");
                    CODCORRELDETA = reader.GetSafeString("CODCORRELDETA");
                    break;
                default:
                    break;
            }
        }
    }
}
