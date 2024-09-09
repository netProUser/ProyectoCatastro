using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADAUTOLICE
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public Boolean ESTATICO { get; set; }
        public string CODGIRO { get; set; }
        #endregion

        public SIC_UNIDADAUTOLICE() { }

        public SIC_UNIDADAUTOLICE(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRAUTOLICE = reader.GetSafeString("CODCORRAUTOLICE");
                    CODCORRLOTEAUTOLICE = reader.GetSafeString("CODCORRLOTEAUTOLICE");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTBENEFICIARIO = reader.GetSafeString("TXTBENEFICIARIO");
                    TXTTIPOLICENCIA = reader.GetSafeString("TXTTIPOLICENCIA");
                    TXTNUMLICENCIA = reader.GetSafeString("TXTNUMLICENCIA");
                    FECLICENCIA = reader.GetSafeDateTime("FECLICENCIA");
                    TXTGIRO = reader.GetSafeString("TXTGIRO");
                    CODGIRO = reader.GetSafeString("CODGIRO");
                    TXTCODUNICO = reader.GetSafeString("TXTCODUNICO");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRAUTOLICE = reader.GetSafeString("CODCORRAUTOLICE");
                    CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    CODGIRO = reader.GetSafeString("TXTNUMERO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    break;
                default:
                    break;
            }
        }
    }
}
