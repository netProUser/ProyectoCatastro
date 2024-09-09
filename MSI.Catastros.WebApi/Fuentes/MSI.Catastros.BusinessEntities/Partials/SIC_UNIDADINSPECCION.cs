using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADINSPECCION
    {
        public enum Query
        {
            None,
            Buscar,
            Recuperar,
            Listar,
            ListarUnidad, 
            ListarCartaInforme
        }

        #region Campos aumentados
        public string FECINSPE {get; set;} 
        public string INSPECTORES {get; set;}
        public string TXTTIPOLLENADO {get; set;}
        public string INFORME {get; set;}
        public string TIPO_INFORME { get; set; }
        public string RESPONSABLE { get; set; }
        public string FECHA { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public bool ESTATICO { get; set; }
        #endregion
        public SIC_UNIDADINSPECCION() { }

        public SIC_UNIDADINSPECCION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Buscar:
                    /*CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");*/
                    break;
                case Query.Recuperar:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODCORRUNIDINSP = reader.GetSafeString("CODCORRUNIDINSP");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    break;
                case Query.Listar:
                     CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    CODCORRUNIDINSP = reader.GetSafeString("CODCORRUNIDINSP");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    break;
                case Query.ListarUnidad:

                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    FECINSPE = reader.GetSafeString("FECINSPE");
                    INSPECTORES = reader.GetSafeString("INSPECTORES");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    INFORME = reader.GetSafeString("INFORME");
                    TIPO_INFORME = reader.GetSafeString("TIPO_INFORME");
                    break;
                case Query.ListarCartaInforme:
                    FECHA = reader.GetSafeString("FECHA");
                    RESPONSABLE = reader.GetSafeString("RESPONSABLE");
                    INFORME = reader.GetSafeString("INFORME");
                    TIPO_DOCUMENTO = reader.GetSafeString("TIPO_DOCUMENTO");
                    break;
                default:
                    break;
            }
        }
    }
}
