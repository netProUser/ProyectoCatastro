using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTELINDERODET
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
        
        public SIC_LOTELINDERODET() { }

        public SIC_LOTELINDERODET(IDataReader reader, Query query = Query.None)
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
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRLADO = reader.GetSafeString("CODCORRLADO");
                    CODSECTCOLI = reader.GetSafeString("CODSECTCOLI");
                    CODMANZCOLI = reader.GetSafeString("CODMANZCOLI");
                    CODLOTECOLI = reader.GetSafeString("CODLOTECOLI");
                    break;
                default:
                    break;
            }
        }
    }
}
