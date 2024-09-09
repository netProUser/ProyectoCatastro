using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLINSPEACT
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion

        public SIC_SOLINSPEACT() { }

        public SIC_SOLINSPEACT(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");
                    TXTDISTRITO = reader.GetSafeString("TXTDISTRITO");*/
                    break;
                case Query.Recuperar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODCORRSEG = reader.GetSafeString("CODCORRSEG");
                    CODCORRCOD = reader.GetSafeString("CODCORRCOD");
                    CODINDDET = reader.GetSafeString("CODINDDET");
                    CODTIPOINSP = reader.GetSafeString("CODTIPOINSP");
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    FECPROGRAMA = reader.GetSafeDateTime("FECPROGRAMA");
                    TXTDETTIPINS = reader.GetSafeString("TXTDETTIPINS");
                    CODTIPINSP = reader.GetSafeString("CODTIPINSP");
                    break;
                default:
                    break;
            }
        }
    }
}
