using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_VIA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTTIPODEVIA { set; get; }
        public string TXTCLASIFICACIONVIA { set; get; }
        public string TXTCODADMVIA { set; get; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_VIA() { }

        public SIC_VIA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODVIAEQUIV = reader.GetSafeString("CODVIAEQUIV");
                    CODCLASVIA = reader.GetSafeString("CODCLASVIA");
                    TXTCODADMVIA = reader.GetSafeString("CODADMVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTCLASIFICACIONVIA = reader.GetSafeString("TXTCLASIFICACIONVIA");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODTIPOVIA = reader.GetSafeString("CODTIPOVIA");
                    CODCLASVIA = reader.GetSafeString("CODCLASVIA");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODVIAEQUIV = reader.GetSafeString("CODVIAEQUIV");
                    CODADMVIA = reader.GetSafeString("CODADMVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    break;
                default:
                    break;
            }
        }
    }
}