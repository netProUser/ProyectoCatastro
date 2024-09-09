using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADOBSERVACION
    {
        public enum Query
        {
            None,
            Listar,
            ListarHistorico,
            Recuperar,
        }

        #region Campos aumentados
        public Boolean ESTATICO { get; set; }
        #endregion

        public SIC_UNIDADOBSERVACION() { }

        public SIC_UNIDADOBSERVACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORROBSE = reader.GetSafeString("CODCORROBSE");
                    FECOBSERVACION = reader.GetSafeDateTime("FECOBSERVACION");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TIPOBSERVA = reader.GetSafeString("TIPOBSERVA");
                    break;
                case Query.ListarHistorico:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORROBSE = reader.GetSafeString("CODCORROBSE");
                    FECOBSERVACION = reader.GetSafeDateTime("FECOBSERVACION");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TIPOBSERVA = reader.GetSafeString("TIPOBSERVA");
                    NUMORDEN = reader.GetSafeString("NUMORDEN");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORROBSE = reader.GetSafeString("CODCORROBSE");
                    FECOBSERVACION = reader.GetSafeDateTime("FECOBSERVACION");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TIPOBSERVA = reader.GetSafeString("TIPOBSERVA");
                    break;
                default:
                    break;
            }
        }
    }
}
