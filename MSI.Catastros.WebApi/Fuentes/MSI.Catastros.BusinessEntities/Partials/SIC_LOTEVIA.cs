using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEVIA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string CODLADO { get; set; }
        public string TXTVIA { get; set; }
        public string TXTPARIDAD { get; set; }
        public int? NUMCUADRA { get; set; }
        public decimal? NUMRETIRO { get; set; }
        public decimal? NUMJARDIN { get; set; }
        public bool ESTATICO { get; set; }
        #endregion
        
        public SIC_LOTEVIA() { }

        public SIC_LOTEVIA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMRETIMUNI = reader.GetSafeInt32("NUMRETIMUNI");
                    MUNJARDAISL = reader.GetSafeInt32("MUNJARDAISL");
                    break;
                default:
                    break;
            }
        }
    }
}
