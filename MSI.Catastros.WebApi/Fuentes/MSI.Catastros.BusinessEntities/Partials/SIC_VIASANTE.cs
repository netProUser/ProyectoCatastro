using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_VIASANTE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTVIA { set; get; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion

        public SIC_VIASANTE() { }

        public SIC_VIASANTE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORVIA = reader.GetSafeString("CODCORVIA");
                    CODVIAANTE = reader.GetSafeString("CODVIAANTE");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTNORMATIVA = reader.GetSafeString("TXTNORMATIVA");
                    FECINICIO = reader.GetSafeDateTime("FECINICIO");
                    FECFIN = reader.GetSafeDateTime("FECFIN");
                    TXTTIPOVIAANTE = reader.GetSafeString("TXTTIPOVIAANTE");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORVIA = reader.GetSafeString("CODCORVIA");
                    CODVIAANTE = reader.GetSafeString("CODVIAANTE");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");
                    TXTNORMATIVA = reader.GetSafeString("TXTNORMATIVA");
                    FECINICIO = reader.GetSafeDateTime("FECINICIO");
                    FECFIN = reader.GetSafeDateTime("FECFIN");
                    TXTTIPOVIAANTE = reader.GetSafeString("TXTTIPOVIAANTE");
                    break;
                default:
                    break;
            }
        }
    }
}
