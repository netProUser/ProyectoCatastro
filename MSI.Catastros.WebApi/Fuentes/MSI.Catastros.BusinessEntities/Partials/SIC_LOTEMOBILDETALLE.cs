using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMOBILDETALLE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }
        #region CamposAdicionales
        public string TXTIPOCAMPOB { get; set; }
        public string TXTNOMBREO { get; set; }
        public string TXTDESPLEOB { get; set; }
        #endregion
        public SIC_LOTEMOBILDETALLE() { }

        public SIC_LOTEMOBILDETALLE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    /*CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    */
                    CODCONFOBJETO = reader.GetSafeString("CODCONFOBJETO");
                    TXTIPOCAMPOB = reader.GetSafeString("TXTIPOCAMPOB");
                    TXTNOMBREO = reader.GetSafeString("TXTNOMBREO");
                    TXTDESPLEOB = reader.GetSafeString("TXTDESPLEOB");
                    TXTVALOR = reader.GetSafeString("TXTVALOR");

                    break;
                case Query.Recuperar:
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    break;
                default:
                    break;
            }
        }
    }
}
