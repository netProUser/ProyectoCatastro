using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_PROGINSPEC
    {
        public enum Query
        {
            None,
            Listar,
            ListarNumero,
            Recuperar,
            ListarInspectores,
            StatusInspeccion,
            ConsultaInspeccion
        }

        #region Campos aumentados
        public string TXTESTADOINSPEC { get; set; }
        public string TXTINSPECTORES { get; set; }

        public string TXTINSRESPONSABLE { get; set; }

        public string TXTCODCATASTRAL { get; set; }
        public string CODUSUASIS { get; set; }
        #endregion
        public SIC_PROGINSPEC() { }

        public SIC_PROGINSPEC(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarNumero:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    TXTESTADOINSPEC = reader.GetSafeString("TXTESTADOINSPEC");
                    NROINSPECCION = reader.IsColumnExists("NROINSPECCION") ? reader.GetSafeString("NROINSPECCION") : "";
                    break;
                case Query.ListarInspectores:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    TXTESTADOINSPEC = reader.GetSafeString("TXTESTADOINSPEC");
                    break;
                case Query.Listar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    FECCITACION = reader.GetSafeDateTime("FECCITACION");
                    FECAVIINSPEC = reader.GetSafeDateTime("FECAVIINSPEC");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    FECREPROG = reader.GetSafeDateTime("FECREPROG");
                    TXTESTADOINSPEC = reader.GetSafeString("TXTESTADOINSPEC");
                    TXTINSPECTORES = reader.IsColumnExists("TXTINSPECTORES") ? reader.GetSafeString("TXTINSPECTORES") : "";
                    TXTCODCATASTRAL = reader.IsColumnExists("TXTCODCATASTRAL") ? reader.GetSafeString("TXTCODCATASTRAL") : "";
                    NROINSPECCION = reader.IsColumnExists("NROINSPECCION") ? reader.GetSafeString("NROINSPECCION") : "";


                    break;
                case Query.Recuperar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    FECCITACION = reader.GetSafeDateTime("FECCITACION");
                    FECAVIINSPEC = reader.GetSafeDateTime("FECAVIINSPEC");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    CODESTATENCION = reader.GetSafeString("CODESTATENCION");
                    FECREPROG = reader.GetSafeDateTime("FECREPROG");
                    break;
                case Query.StatusInspeccion:
                    CODANOSOLI = reader.IsColumnExists("CODANOSOLI") ? reader.GetSafeString("CODANOSOLI") : "";
                    CODNUMESOLI = reader.IsColumnExists("CODNUMESOLI") ? reader.GetSafeString("CODNUMESOLI") : ""; ;
                    CODTIPOSOLI = reader.IsColumnExists("CODTIPOSOLI") ? reader.GetSafeString("CODTIPOSOLI") : "";
                    CODNROINSPEC = reader.IsColumnExists("CODNROINSPEC") ? reader.GetSafeString("CODNROINSPEC") : "";
                    FECINSPE = reader.GetSafeDateTime("FECINSPE") ;
                    TXTHORAINSP = reader.IsColumnExists("TXTHORAINSP") ? reader.GetSafeString("TXTHORAINSP") : "";
                    FECCITACION = reader.GetSafeDateTime("FECCITACION") ;
                    FECAVIINSPEC = reader.GetSafeDateTime("FECAVIINSPEC") ;
                    TXTOBSERVACION = reader.IsColumnExists("TXTOBSERVACION") ? reader.GetSafeString("TXTOBSERVACION") : "";
                    FECREPROG = reader.GetSafeDateTime("FECREPROG");
                    TXTESTADOINSPEC = reader.IsColumnExists("TXTESTADOINSPEC") ? reader.GetSafeString("TXTESTADOINSPEC") : "";
                    TXTINSPECTORES = reader.IsColumnExists("TXTINSPECTORES") ? reader.GetSafeString("TXTINSPECTORES") : "";
                    TXTCODCATASTRAL = reader.IsColumnExists("TXTCODCATASTRAL") ? reader.GetSafeString("TXTCODCATASTRAL") : "";
                    TXTINSRESPONSABLE = reader.IsColumnExists("TXTINSRESPONSABLE") ? reader.GetSafeString("TXTINSRESPONSABLE") : "";
                    TXTUBICACION = reader.IsColumnExists("TXTUBICACION") ? reader.GetSafeString("TXTUBICACION") : "";
                    TXTTITULAR = reader.IsColumnExists("TXTTITULAR") ? reader.GetSafeString("TXTTITULAR") : "";
                    TXTREPRESENTANTE = reader.IsColumnExists("TXTREPRESENTANTE") ? reader.GetSafeString("TXTREPRESENTANTE") : "";
                    CODTIPOLLENA = reader.IsColumnExists("CODTIPOLLENA") ? reader.GetSafeString("CODTIPOLLENA") : "";
                    TXTNUMSOLI = reader.IsColumnExists("TXTNUMSOLI") ? reader.GetSafeString("TXTNUMSOLI") : "";
                    TXTPROGRAMADO = reader.IsColumnExists("TXTPROGRAMADO") ? reader.GetSafeString("TXTPROGRAMADO") : "";
                    TXTFECCITACION = reader.IsColumnExists("TXTFECCITACION") ? reader.GetSafeString("TXTFECCITACION") : "";
                    break;
                case Query.ConsultaInspeccion:
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    FECINSPE = reader.GetSafeDateTime("FECINSPE");
                    TXTHORAINSP = reader.GetSafeString("TXTHORAINSP");
                    TXTINSPECTORES = reader.GetSafeString("TXTINSPECTORES");
                    TXTINSRESPONSABLE = reader.GetSafeString("TXTINSRESPONSABLE");
                    TXTCODCATASTRAL = reader.GetSafeString("TXTCODCATASTRAL");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTESTADOINSPEC = reader.GetSafeString("TXTESTADOINSPEC");
                    break;
                default:
                    break;
            }
        }
    }
}
