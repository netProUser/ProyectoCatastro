using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMOBILURBA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion
        
        public SIC_LOTEMOBILURBA() { }

        public SIC_LOTEMOBILURBA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");                    
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODOBJETO = reader.GetSafeString("CODOBJETO");     
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    TXTUBICESPECIF = reader.GetSafeString("TXTUBICESPECIF");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");                   
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    TXTUBICESPECIF = reader.GetSafeString("TXTUBICESPECIF");
                    CODVIA = reader.GetSafeString("CODVIA");                    
                    NUMLATITUD = reader.GetSafeDecimal("NUMLATITUD");
                    NUMLONGITUD = reader.GetSafeDecimal("NUMLONGITUD");
                    TXTCAMPANA = reader.GetSafeString("TXTCAMPANA");
                    FECCAMPANA = reader.GetSafeDateTime("FECCAMPANA");
                    break;
                default:
                    break;
            }
        }
    }
}
