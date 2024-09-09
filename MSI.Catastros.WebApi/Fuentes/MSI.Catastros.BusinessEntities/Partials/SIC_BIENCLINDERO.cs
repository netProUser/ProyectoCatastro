using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_BIENCLINDERO
    {
         public enum Query
        {
            None,
            Listar,
            Recuperar,
            ListarColidante,
            ListarColindantes,
        }

        #region Campos aumentados
        public string ORDEN { get; set; }

        #endregion

        public SIC_BIENCLINDERO() { }

        public SIC_BIENCLINDERO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");                    
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRELLINDE = reader.GetSafeString("CODCORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CODSECTCOLI = reader.GetSafeString("CODSECTCOLI");
                    CODMANZCOLI = reader.GetSafeString("CODMANZCOLI");
                    CODLOTECOLI = reader.GetSafeString("CODLOTECOLI");
                    CODEDIFICCOLI = reader.GetSafeString("CODEDIFICCOLI");
                    CODENTRACOLI = reader.GetSafeString("CODENTRACOLI");
                    CODPISOCOLI = reader.GetSafeString("CODPISOCOLI");
                    CODUNIDADCOLI = reader.GetSafeString("CODUNIDADCOLI");
                    CODUNICOLI = reader.GetSafeInt32("CODUNICOLI");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORMANZVIA = reader.GetSafeString("CODCORMANZVIA");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");                   
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRELLINDE = reader.GetSafeString("CODCORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeInt32("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeInt32("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");   
                    CODSECTCOLI = reader.GetSafeString("CODSECTCOLI");
                    CODMANZCOLI = reader.GetSafeString("CODMANZCOLI");
                    CODLOTECOLI = reader.GetSafeString("CODLOTECOLI");
                    CODEDIFICCOLI = reader.GetSafeString("CODEDIFICCOLI");
                    CODENTRACOLI = reader.GetSafeString("CODENTRACOLI");
                    CODPISOCOLI = reader.GetSafeString("CODPISOCOLI");
                    CODUNIDADCOLI = reader.GetSafeString("CODUNIDADCOLI");
                    CODUNICOLI = reader.GetSafeInt32("CODUNICOLI");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORMANZVIA = reader.GetSafeString("CODCORMANZVIA");
                    break;
                case Query.ListarColidante:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRELLINDE = reader.GetSafeString("CODCORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    TXTPARIDAD = reader.IsColumnExists("TXTPARIDAD") ? reader.GetSafeString("TXTPARIDAD") : "";
                    break;
                case Query.ListarColindantes:
                    TXTCOLINDANTE = reader.GetSafeString("TXTCOLINDANTE");
                    TXTTIPOCOLINDANTE = reader.IsColumnExists("TXTTIPOCOLINDANTE") ? reader.GetSafeString("TXTTIPOCOLINDANTE") : "";
                    CORRELATIVO = reader.IsColumnExists("CORRELATIVO") ? reader.GetSafeString("CORRELATIVO") : "";
                    CODLADO = reader.IsColumnExists("CODLADO") ? reader.GetSafeString("CODLADO") : "";
                    CODCORRELLINDE = reader.IsColumnExists("CODCORRELLINDE") ? reader.GetSafeString("CODCORRELLINDE") : "";
                    CODTIPOCOLI = reader.IsColumnExists("CODTIPOCOLI") ? reader.GetSafeString("CODTIPOCOLI") : "";

                    break;
                default:
                    break;
            }
        }
    
    }
}
