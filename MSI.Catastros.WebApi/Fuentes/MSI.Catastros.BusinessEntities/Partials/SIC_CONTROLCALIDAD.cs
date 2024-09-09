using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONTROLCALIDAD
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string CODTIPOERROR { get; set; }
        public string TXTERRORCALIDAD { get; set; }
        public string TXTDESCRIPCION { get; set; }
        public string TXTNOMBRERECEPCION { get; set; }
        public string TXTNOMBRESOLICITANTE { get; set; }
        
        #endregion

        public SIC_CONTROLCALIDAD() { }

        public SIC_CONTROLCALIDAD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODCORRCONCALI = reader.GetSafeString("CODCORRCONCALI");
                    FECREVISION = reader.GetSafeDateTime("FECREVISION");
                    TXTNOMBRESOLICITANTE = reader.GetSafeString("TXTNOMBRESOLICITANTE");
                    TXTNOMBRERECEPCION = reader.GetSafeString("TXTNOMBRERECEPCION");
                    CODTIPOERROR = reader.GetSafeString("CODTIPOERROR");
                    CODERRORCALIDAD = reader.GetSafeString("CODERRORCALIDAD");
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    TXTNROINSPECREF = reader.GetSafeString("TXTNROINSPECREF");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTERRORCALIDAD = reader.GetSafeString("TXTERRORCALIDAD");
                    CODUSUARESP = reader.GetSafeString("CODUSUARESP");
                    break;
                case Query.Recuperar:
                    /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");*/
                    break;
                default:
                    break;
            }
        }
    }
}
