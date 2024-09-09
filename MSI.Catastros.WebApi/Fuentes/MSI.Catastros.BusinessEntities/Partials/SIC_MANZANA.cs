using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MANZANA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTSECTOR { set; get; }
        public string TXTTEMATICO { set; get; }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }

        #endregion

        public SIC_MANZANA() { }

        public SIC_MANZANA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    TXTMANZANA = reader.GetSafeString("TXTMANZANA");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");
                    CODTEMATICO = reader.GetSafeString("CODTEMATICO");
                    TXTTEMATICO = reader.GetSafeString("TXTTEMATICO");
                    TXTMANZURBA = reader.GetSafeString("TXTMANZURBA");
                    TXTSECTVECI = reader.GetSafeString("TXTSECTVECI");
                    TXTSUBSECTVECI = reader.GetSafeString("TXTSUBSECTVECI");
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    TXTMANZANA = reader.GetSafeString("TXTMANZANA");
                    TXTMANZURBA = reader.GetSafeString("TXTMANZURBA");
                    CODTEMATICO = reader.GetSafeString("CODTEMATICO");

                    TXTSECTVECI = reader.GetSafeString("TXTSECTVECI");
                    TXTSUBSECTVECI = reader.GetSafeString("TXTSUBSECTVECI");
                    break;
                default:
                    break;
            }
        }
    }
}
