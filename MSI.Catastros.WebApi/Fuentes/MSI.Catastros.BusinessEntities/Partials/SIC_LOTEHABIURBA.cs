using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEHABIURBA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Buscar,
        }

        #region Campos aumentados
        public string TXTURBANIZACION { get; set; }
        public string TXTMANZAURB { get; set; }
        public string TXTHABILITAURBA { get; set; }
        public string CODTIPOHABURB { get; set; }
        #endregion
        
        public SIC_LOTEHABIURBA() { }

        public SIC_LOTEHABIURBA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");*/
                    break;
                case Query.Buscar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODMANZURB = reader.GetSafeString("CODMANZURB");
                    TXTHABILITAURBA = reader.GetSafeString("TXTHABILITAURBA");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    TXTMANZAURB = reader.GetSafeString("TXTMANZAURB");
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODHABURBA = reader.GetSafeString("CODHABURBA");
                    CODMANZURB = reader.GetSafeString("CODMANZURB");
                    CODTIPOHABURB = reader.GetSafeString("CODTIPOHABURB");
                    break;
                default:
                    break;
            }
        }
    }
}
