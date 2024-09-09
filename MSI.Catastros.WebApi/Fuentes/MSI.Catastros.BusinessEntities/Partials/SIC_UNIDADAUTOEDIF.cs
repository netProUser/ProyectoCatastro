using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADAUTOEDIF
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

        public SIC_UNIDADAUTOEDIF() { }

        public SIC_UNIDADAUTOEDIF(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDAE = reader.GetSafeString("CODCORRUNIDAE");
                    CODCORRLOTEAUTOEDIF = reader.GetSafeString("CODCORRLOTEAUTOEDIF");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTBENEFICIARIO = reader.GetSafeString("TXTBENEFICIARIO");
                    TXTNUMLICENCIA = reader.GetSafeString("TXTNUMLICENCIA");
                    FECLICENCIA = reader.GetSafeDateTime("FECLICENCIA");
                    TXTTIPOOBRA = reader.GetSafeString("TXTTIPOOBRA");
                    TXTCODUNICO = reader.GetSafeString("TXTCODUNICO");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDAE = reader.GetSafeString("CODCORRUNIDAE");
                    CODCORRLOTEAUTOEDIF = reader.GetSafeString("CODCORRLOTEAUTOEDIF");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTBENEFICIARIO = reader.GetSafeString("TXTBENEFICIARIO");
                    TXTNUMLICENCIA = reader.GetSafeString("TXTNUMLICENCIA");
                    FECLICENCIA = reader.GetSafeDateTime("FECLICENCIA");
                    TXTTIPOOBRA = reader.GetSafeString("TXTTIPOOBRA");
                    TXTCODUNICO = reader.GetSafeString("TXTCODUNICO");
                    break;
                default:
                    break;
            }
        }
    }
}
