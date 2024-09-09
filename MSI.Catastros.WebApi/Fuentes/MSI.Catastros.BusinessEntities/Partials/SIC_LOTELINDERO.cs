using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTELINDERO
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string ORDEN { get; set; }
        public string CODFTELIN { get; set; }
        public string TXTFUENTE { get; set; }
        public string TXTTIPOCOLI { get; set; }
        public string TXTPARIDAD { get; set; }
        #endregion
        
        public SIC_LOTELINDERO() { }

        public SIC_LOTELINDERO(IDataReader reader, Query query = Query.None)
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
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRLADO = reader.GetSafeString("CODCORRLADO");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CODFTELIN = reader.GetSafeString("CODFTELIN");
                    TXTFUENTE = reader.GetSafeString("TXTFUENTE");
                    TXTTIPOCOLI = reader.GetSafeString("TXTTIPOCOLI");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    TXTALTVIAFOR = reader.GetSafeString("TXTALTVIAFOR");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRLADO = reader.GetSafeString("CODCORRLADO");
                    NUMMEDICAMP = reader.GetSafeDecimal("NUMMEDICAMP");
                    NUMMEDIOFIC = reader.GetSafeDecimal("NUMMEDIOFIC");
                    CODTIPOCOLI = reader.IsColumnExists("CODTIPOCOLI") ? reader.GetSafeString("CODTIPOCOLI") : "";
                    CODALTVIAFOR = reader.IsColumnExists("CODALTVIAFOR") ? reader.GetSafeString("CODALTVIAFOR") : "";
                    CODFTELIN = reader.GetSafeString("CODFTELIN");
                    break;
                default:
                    break;
            }
        }
    }
}
