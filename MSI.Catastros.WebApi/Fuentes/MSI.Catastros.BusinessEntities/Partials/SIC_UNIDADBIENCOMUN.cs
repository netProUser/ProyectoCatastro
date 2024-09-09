using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADBIENCOMUN
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        public SIC_UNIDADBIENCOMUN() { }

        public SIC_UNIDADBIENCOMUN(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODBIENCOMUN = reader.GetSafeInt32("CODBIENCOMUN");
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
                    NUMPOROFI = reader.GetSafeDecimal("NUMPOROFI");
                    NUMPORCAL = reader.GetSafeDecimal("NUMPORCAL");
                    NUMATECOM = reader.GetSafeDecimal("NUMATECOM");
                    NUMACONCOM = reader.GetSafeDecimal("NUMACONCOM");
                    CODCORRUNIDBC = reader.GetSafeString("CODCORRUNIDBC");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODBIENCOMUN = reader.GetSafeInt32("CODBIENCOMUN");
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
                    NUMPOROFI = reader.GetSafeDecimal("NUMPOROFI");
                    NUMPORCAL = reader.GetSafeDecimal("NUMPORCAL");
                    NUMATECOM = reader.GetSafeDecimal("NUMATECOM");
                    NUMACONCOM = reader.GetSafeDecimal("NUMACONCOM");
                    CODCORRUNIDBC = reader.GetSafeString("CODCORRUNIDBC");
                    break;
                default:
                    break;
            }
        }
    }
}
