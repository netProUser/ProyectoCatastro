using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_HABILITURBA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTHABILITAURBA { get; set; }
        public string TXTNOMBREDIFERENCIADOR { get; set; }
        public string TXTRUTAIMAGEN { get; set; }
        #endregion

        public SIC_HABILITURBA() { }

        public SIC_HABILITURBA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    TXTHABILITAURBA = reader.GetSafeString("TXTHABILITAURBA");
                    TXTDIFERENCIADORHABURBA = reader.GetSafeString("TXTDIFERENCIADORHABURBA");
                    TXTNOMBREDIFERENCIADOR = reader.GetSafeString("TXTNOMBREDIFERENCIADOR");
                    FECAPROBACION = reader.GetSafeDateTime("FECAPROBACION");
                    TXTNUMDOCPROB = reader.GetSafeString("TXTNUMDOCPROB");
                    TXTNOMDOCU = reader.GetSafeString("TXTNOMDOCU");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    FECACTDOCU = reader.GetSafeDateTime("FECACTDOCU");
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");
                    break;
                case Query.Recuperar:
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    TXTNOMDOCU = reader.GetSafeString("TXTNOMDOCU");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    TXTDIFERENCIADORHABURBA = reader.GetSafeString("TXTDIFERENCIADORHABURBA");
                    FECAPROBACION = reader.GetSafeDateTime("FECAPROBACION");
                    TXTNUMDOCPROB = reader.GetSafeString("TXTNUMDOCPROB");
                    FECACTDOCU = reader.GetSafeDateTime("FECACTDOCU");
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");
                    break;
                default:
                    break;
            }
        }
    }
}
