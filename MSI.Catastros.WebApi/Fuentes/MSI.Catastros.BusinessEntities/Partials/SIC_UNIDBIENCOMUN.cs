using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDBIENCOMUN
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Filtrar
        }

        #region Campos aumentados
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODEDIFICACION { get; set; }
        public string CODENTRADA { get; set; }
        public string CODPISO { get; set; }
        public string CODUNIDAD { get; set; }
        public string CODUNIDADCATASTRAL { get; set; }
        public bool ESTATICO { get; set; }
        public Nullable<decimal> NUMAREAOCUP { get; set; }
        public Nullable<decimal> NUMAREATERRCOMU { get; set; }
        public Nullable<decimal> NUMATECOM { get; set; }
        #endregion

        public SIC_UNIDBIENCOMUN() { }

        public SIC_UNIDBIENCOMUN(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODBIENCOMUN = reader.GetSafeInt32("CODBIENCOMUN");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    FLGINDEP = reader.GetSafeString("FLGINDEP");
                    NUMPOROFI = reader.GetSafeDecimal("NUMPOROFI");
                    NUMAREATERRCOMU = reader.GetSafeDecimal("NUMAREATERRCOMU");
                    NUMAREAOCUP = reader.GetSafeDecimal("NUMAREAOCUP");
                    ESTADOUNIDAD = reader.IsColumnExists("ESTADOUNIDAD") ? reader.GetSafeString("ESTADOUNIDAD") : "";

                    break;
                case Query.Filtrar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODBIENCOMUN = reader.GetSafeInt32("CODBIENCOMUN");
                    NUMPOROFI = reader.GetSafeDecimal("NUMPOROFI");
                    FLGINDEP = reader.GetSafeString("FLGINDEP");
                    NUMATECOM = reader.GetSafeDecimal("NUMATECOM");
                    CODUNIDADCATASTRAL = reader.GetSafeString("CODUNIDADCATASTRAL"); 
                    break;
                default:
                    break;
            }
        }
    }
}


