using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDINSTALACION
    {
        public enum Query
        {
            None,
            Listar,
            ListarHistorico,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTNOMBRE { get; set; }
        public Boolean ESTATICO { get; set; }
        #endregion

        public SIC_UNIDINSTALACION() { }

        public SIC_UNIDINSTALACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDINST = reader.GetSafeString("CODCORRUNIDINST");
                    CODINSTALACION = reader.GetSafeString("CODINSTALACION");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    NUMCAPACIDAD = reader.GetSafeDecimal("NUMCAPACIDAD");
                    NUMCANTIDAD = reader.GetSafeInt32("NUMCANTIDAD");
                    break;

                case Query.ListarHistorico:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDINST = reader.GetSafeString("CODCORRUNIDINST");
                    CODINSTALACION = reader.GetSafeString("CODINSTALACION");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    NUMCAPACIDAD = reader.GetSafeDecimal("NUMCAPACIDAD");
                    NUMCANTIDAD = reader.GetSafeInt32("NUMCANTIDAD");
                    NUMORDEN = reader.GetSafeInt32("NUMORDEN");
                    
                    break;

                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDINST = reader.GetSafeString("CODCORRUNIDINST");
                    CODINSTALACION = reader.GetSafeString("CODINSTALACION");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    NUMCAPACIDAD = reader.GetSafeDecimal("NUMCAPACIDAD");
                    NUMCANTIDAD = reader.GetSafeInt32("NUMCANTIDAD");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    break;
                default:
                    break;
            }
        }
    }
}
