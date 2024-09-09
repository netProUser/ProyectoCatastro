using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_URBAMANZA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTURBANIZACION { get; set; }
        public string TXTHABILITAURBA { get; set; }
        public string CODTIPOMANZA { get; set; }
        public string TXTTIPOMANZA { get; set; }
        #endregion

        public SIC_URBAMANZA() { }

        public SIC_URBAMANZA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODMANZURB = reader.GetSafeString("CODMANZURB");
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    TXTMANZAURB = reader.GetSafeString("TXTMANZAURB");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    TXTHABILITAURBA = reader.GetSafeString("TXTHABILITAURBA");
                    CODTIPOMANZA = reader.GetSafeString("CODTIPOMANZA");
                    TXTTIPOMANZA = reader.GetSafeString("TXTTIPOMANZA");
                    break;
                case Query.Recuperar:
                    CODMANZURB = reader.GetSafeString("CODMANZURB");
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    TXTMANZAURB = reader.GetSafeString("TXTMANZAURB");
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    CODTIPOMANZA = reader.GetSafeString("CODTIPOMANZA");
                    break;
                default:
                    break;
            }
        }
    }
}
