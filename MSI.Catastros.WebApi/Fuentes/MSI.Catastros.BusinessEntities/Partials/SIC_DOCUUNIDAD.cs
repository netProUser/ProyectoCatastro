using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_DOCUUNIDAD
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        
        #endregion

        public SIC_DOCUUNIDAD() { }

        public SIC_DOCUUNIDAD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODINFORCARTA = reader.GetSafeString("CODINFORCARTA");
                    CODANOINFORCARTA = reader.GetSafeString("CODANOINFORCARTA");
                    CODTIPOINFORCARTA = reader.GetSafeString("CODTIPOINFORCARTA");
                    CODCORRINFORCARTA = reader.GetSafeString("CODCORRINFORCARTA");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODUNI = reader.GetInt32("CODUNI");
                    
                    break;
                case Query.Recuperar:
                    CODINFORCARTA = reader.GetSafeString("CODINFORCARTA");
                    CODANOINFORCARTA = reader.GetSafeString("CODANOINFORCARTA");
                    CODTIPOINFORCARTA = reader.GetSafeString("CODTIPOINFORCARTA");
                    CODCORRINFORCARTA = reader.GetSafeString("CODCORRINFORCARTA");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODUNI = reader.GetInt32("CODUNI");
                    break;
                default:
                    break;
            }
        }
    }
}
