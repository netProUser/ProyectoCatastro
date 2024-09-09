using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTENORMAURBANA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTVIA;
        public string TXTALTURA { get; set; }
        public string TXTZONIFICACION { get; set; }

        #endregion

        public SIC_LOTENORMAURBANA() { }

        public SIC_LOTENORMAURBANA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    NUMALTURA = reader.GetSafeDecimal("NUMALTURA");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    TXTALTURA = reader.GetSafeString("TXTALTURA");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
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
                    NUMALTURA = reader.GetSafeDecimal("NUMALTURA");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTALTURA = reader.GetSafeString("TXTALTURA");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    break;
                default:
                    break;
            }
        }
    }
}
