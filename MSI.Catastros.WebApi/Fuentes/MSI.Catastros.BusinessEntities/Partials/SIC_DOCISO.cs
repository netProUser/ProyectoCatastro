using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_DOCISO
    {
          public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public string TXTTIPODOCUMENTO { set; get; }
        #endregion

        public SIC_DOCISO() { }

        public SIC_DOCISO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:

                    CODDOCCAT = reader.GetSafeString("CODDOCCAT");
                    TXTTIPODOCUMENTO = reader.GetSafeString("TXTTIPODOCUMENTO");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    break;
                case Query.Recuperar:
                    CODDOCCAT = reader.GetSafeString("CODDOCCAT");
                    TXTTIPODOCUMENTO = reader.GetSafeString("TXTTIPODOCUMENTO");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    CODTIPODOC = reader.GetSafeString("CODTIPODOC");
                    break;
                default:
                    break;
            }
        }
    }
}
