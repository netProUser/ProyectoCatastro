using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_ZONIFMANZAVIA
    {
        public enum Query
        {
            None,
            Listar,
            Buscar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTDESCRIPCION { get; set; }
        public string TXTZONIFICACION { get; set; }
        public string TXTABREVIACION { get; set; }
        #endregion
        
        public SIC_ZONIFMANZAVIA() { }

        public SIC_ZONIFMANZAVIA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Buscar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVIACION = reader.GetSafeString("TXTABREVIACION");
                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    //TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    //TXTABREVIACION = reader.GetSafeString("TXTABREVIACION");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    break;
                default:
                    break;
            }
        }
    }
}
