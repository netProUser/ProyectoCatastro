using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADEXPEDOCU
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public bool ESTATICO { get; set; }
        #endregion

        public SIC_UNIDADEXPEDOCU() { }

        public SIC_UNIDADEXPEDOCU(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDEXPEDOCU = reader.GetSafeString("CODCORRUNIDEXPEDOCU");
                    CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    CODCORRLOTEEXPEDOCU = reader.GetSafeString("CODCORRLOTEEXPEDOCU");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDEXPEDOCU = reader.GetSafeString("CODCORRUNIDEXPEDOCU");
                    CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    break;
                default:
                    break;
            }
        }
    }
}
