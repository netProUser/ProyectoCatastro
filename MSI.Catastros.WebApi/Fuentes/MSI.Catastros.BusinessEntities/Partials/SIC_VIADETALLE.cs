using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_VIADETALLE
    {
        public enum Query
        {
            None,
            Listar,
            Buscar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTVIA { set; get; }
        public string TXTANCHOVIA { set; get; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_VIADETALLE() { }

        public SIC_VIADETALLE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Buscar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRVIADETA = reader.GetSafeString("CODCORRVIADETA");
                    NUMANCHVIA = reader.GetSafeDecimal("NUMANCHVIA");
                    CODANCHVIA = reader.GetSafeString("CODANCHVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    NUMMEDINI = reader.GetSafeDecimal("NUMMEDINI");
                    NUMMEDFIN = reader.GetSafeDecimal("NUMMEDFIN");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTANCHOVIA = reader.GetSafeString("TXTANCHOVIA");
                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRVIADETA = reader.GetSafeString("CODCORRVIADETA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRVIADETA = reader.GetSafeString("CODCORRVIADETA");
                    NUMANCHVIA = reader.GetSafeDecimal("NUMANCHVIA");
                    CODANCHVIA = reader.GetSafeString("CODANCHVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    NUMMEDINI = reader.GetSafeDecimal("NUMMEDINI");
                    NUMMEDFIN = reader.GetSafeDecimal("NUMMEDFIN");
                    break;
                default:
                    break;
            }
        }
    }
}
