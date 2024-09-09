using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADDIRECCONINTERIOR
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
            public string TXTTIPODEVIA { get; set; }
            public string TXTVIA { get; set; }
            public string CODLADO { get; set; }
            public string TXTLADO { get; set; }
            public string TXTTIPOPUERTA { get; set; }
            public string TXTEDIFICACION { get; set; }
            public string TXTNUMEDIF { get; set; }
            public string TXTINSCRIPCION { get; set; }
            public string TXTNUMEROPUERTA { get; set; }
            public string TXTLETRAPUERTA { get; set; }           
            public int? NUMCUADRA { get; set; }
            public string TXTTIPOINTERIOR { get; set; }
            public string TXTESTADOINTERIOR { get; set; }
            public string TXTTIPOASIGNACION { get; set; }
            public string TEXTAREA { get; set; }
            public string ESTATICO { get; set; }
        
            
        #endregion

        public SIC_UNIDADDIRECCONINTERIOR() { }

        public SIC_UNIDADDIRECCONINTERIOR(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDDIREINTE = reader.GetSafeString("CODCORRUNIDDIREINTE");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODCORRUNIDDIREMUNI = reader.GetSafeString("CODCORRUNIDDIREMUNI");
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTLADO = reader.GetSafeString("TXTLADO");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    TXTEDIFICACION = reader.GetSafeString("TXTEDIFICACION");
                    TXTNUMEDIF = reader.GetSafeString("TXTNUMEDIF");
                    TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    TXTTIPOINTERIOR = reader.GetSafeString("TXTTIPOINTERIOR");
                    TXTESTADOINTERIOR = reader.GetSafeString("TXTESTADOINTERIOR");
                    CODTIPOASIG = reader.GetSafeString("CODTIPOASIG");
                    TXTTIPOASIGNACION = reader.GetSafeString("TXTTIPOASIGNACION");
                    TXTINSCRIPCION = reader.GetSafeString("TXTINSCRIPCION");
                    NUMAREATEMPI = reader.GetSafeDecimal("NUMAREATEMPI");
                    CODESTAINTE = reader.GetSafeString("CODESTAINTE");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDDIREINTE = reader.GetSafeString("CODCORRUNIDDIREINTE");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODCORRUNIDDIREMUNI = reader.GetSafeString("CODCORRUNIDDIREMUNI");
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    CODTIPOASIG = reader.GetSafeString("CODTIPOASIG");
                    CODESTAINTE = reader.GetSafeString("CODESTAINTE");
                    CODINSCATINT = reader.GetSafeString("CODINSCATINT");
                    NUMAREATEMPI = reader.GetSafeDecimal("NUMAREATEMPI");
                    //TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    //TXTVIA = reader.GetSafeString("TXTVIA");
                    //CODLADO = reader.GetSafeString("CODLADO");
                    //TXTLADO = reader.GetSafeString("TXTLADO");
                    //TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    //TXTEDIFICACION = reader.GetSafeString("TXTEDIFICACION");
                    //TXTNUMEDIF = reader.GetSafeString("TXTNUMEDIF");
                    //TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    //TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    //NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    //TXTTIPOINTERIOR = reader.GetSafeString("TXTTIPOINTERIOR");
                    //TXTESTADOINTERIOR = reader.GetSafeString("TXTESTADOINTERIOR");
                    break;
                default:
                    break;
            }
        }
    }
}
