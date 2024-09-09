using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_QUINTALINDERO
    {
        public enum Query
        {
            None,
            ListarHistorico,
            Listar,
            Recuperar,
            ListarColindantes,
            ListarColidante,
        }

        #region Campos aumentados
        public string ORDEN { get; set; }
        public Boolean ESTATICO { get; set; } 

        #endregion

        public SIC_QUINTALINDERO() { }

        public SIC_QUINTALINDERO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CORRELLINDE = reader.GetSafeString("CORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CODSECTCOLI = reader.GetSafeString("CODSECTCOLI");
                    CODMANZCOLI = reader.GetSafeString("CODMANZCOLI");
                    CODLOTECOLI = reader.GetSafeString("CODLOTECOLI");
                    CODEDIFICCOLI = reader.GetSafeString("CODEDIFICCOLI");
                    CODENTRACOLI = reader.GetSafeString("CODENTRACOLI");
                    CODPISOCOL = reader.GetSafeString("CODPISOCOL");
                    CODUNIDADCOLI = reader.GetSafeString("CODUNIDADCOLI");
                    CODUNICOLI = reader.GetSafeInt32("CODUNICOLI");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORMANZVIA = reader.GetSafeString("CODCORMANZVIA");
                    TXTPARIDAD = reader.IsColumnExists("TXTPARIDAD") ? reader.GetSafeString("TXTPARIDAD") : "";

                    break;
                case Query.ListarColidante:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CORRELLINDE = reader.GetSafeString("CORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    TXTPARIDAD = reader.IsColumnExists("TXTPARIDAD") ? reader.GetSafeString("TXTPARIDAD") : "";

                    break;
                case Query.ListarHistorico:
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CORRELLINDE = reader.GetSafeString("CORRELLINDE");
                    TXTCOLINDANTE = reader.GetSafeString("TXTCOLINDANTE");
                    break;
                    
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CORRELLINDE = reader.GetSafeString("CORRELLINDE");
                    NUMMEDICAMP = reader.GetSafeInt32("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeInt32("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CODSECTCOLI = reader.GetSafeString("CODSECTCOLI");
                    CODMANZCOLI = reader.GetSafeString("CODMANZCOLI");
                    CODLOTECOLI = reader.GetSafeString("CODLOTECOLI");
                    CODEDIFICCOLI = reader.GetSafeString("CODEDIFICCOLI");
                    CODENTRACOLI = reader.GetSafeString("CODENTRACOLI");
                    CODPISOCOL = reader.GetSafeString("CODPISOCOL");
                    CODUNIDADCOLI = reader.GetSafeString("CODUNIDADCOLI");
                    CODUNICOLI = reader.GetSafeInt32("CODUNICOLI");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORMANZVIA = reader.GetSafeString("CODCORMANZVIA");
                    break;
                case Query.ListarColindantes:
                    TXTCOLINDANTE = reader.GetSafeString("TXTCOLINDANTE");
                    TXTTIPOCOLINDANTE = reader.IsColumnExists("TXTTIPOCOLINDANTE") ? reader.GetSafeString("TXTTIPOCOLINDANTE") : "";
                    CORRELATIVO = reader.IsColumnExists("CORRELATIVO") ? reader.GetSafeString("CORRELATIVO") : "";
                    CODLADO = reader.IsColumnExists("CODLADO") ? reader.GetSafeString("CODLADO") : "";
                    CORRELLINDE = reader.IsColumnExists("CORRELLINDE") ? reader.GetSafeString("CORRELLINDE") : "";
                    CODTIPOCOLI = reader.IsColumnExists("CODTIPOCOLI") ? reader.GetSafeString("CODTIPOCOLI") : "";

                    break;
                default:
                    break;
            }
        }

    }
}
