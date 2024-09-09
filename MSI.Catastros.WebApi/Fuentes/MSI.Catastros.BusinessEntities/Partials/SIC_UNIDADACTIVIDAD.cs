using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADACTIVIDAD
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

        public SIC_UNIDADACTIVIDAD() { }

        public SIC_UNIDADACTIVIDAD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRELACTI = reader.GetSafeString("CODCORRELACTI");
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    NUMMETROS = reader.GetSafeDecimal("NUMMETROS");
                    FECACTI = reader.GetSafeDateTime("FECACTI");
                    CODUSORETIRO = reader.GetSafeString("CODUSORETIRO");
                    CODOPCIONANUN = reader.GetSafeString("CODOPCIONANUN");
                    CODANUNCIO = reader.GetSafeString("CODANUNCIO");
                    break;
                case Query.ListarHistorico:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRELACTI = reader.GetSafeString("CODCORRELACTI");
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    NUMMETROS = reader.GetSafeDecimal("NUMMETROS");
                    FECACTI = reader.GetSafeDateTime("FECACTI");
                    CODUSORETIRO = reader.GetSafeString("CODUSORETIRO");
                    CODOPCIONANUN = reader.GetSafeString("CODOPCIONANUN");
                    CODANUNCIO = reader.GetSafeString("CODANUNCIO");
                    TXTUSOESPE = reader.GetSafeString("TXTUSOESPE");
                    break;
                    
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRELACTI = reader.GetSafeString("CODCORRELACTI");
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    NUMMETROS = reader.GetSafeDecimal("NUMMETROS");
                    FECACTI = reader.GetSafeDateTime("FECACTI");
                    CODUSORETIRO = reader.GetSafeString("CODUSORETIRO");
                    CODOPCIONANUN = reader.GetSafeString("CODOPCIONANUN");
                    CODANUNCIO = reader.GetSafeString("CODANUNCIO");
                    break;
                default:
                    break;
            }
        }
    }
}
