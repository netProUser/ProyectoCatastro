using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMOBOBSER
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        #endregion
        
        public SIC_LOTEMOBOBSER() { }

        public SIC_LOTEMOBOBSER(IDataReader reader, Query query = Query.None)
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
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    CODOBSER = reader.GetSafeString("CODOBSER");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    //FECOBSERVACION = reader.GetDateTime("FECOBSERVACION");
                    if (reader.IsDBNull("FECOBSERVACION")) { FECOBSERVACION = null; }
                    else { FECOBSERVACION = reader.GetDateTime("FECOBSERVACION"); }
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    FECOBSERVACION = reader.GetSafeDateTime("FECOBSERVACION");
                    CORRELURBA = reader.GetSafeString("CORRELURBA");
                    CODOBSER = reader.GetSafeString("CODOBSER");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    break;
                default:
                    break;
            }
        }
    }
}

