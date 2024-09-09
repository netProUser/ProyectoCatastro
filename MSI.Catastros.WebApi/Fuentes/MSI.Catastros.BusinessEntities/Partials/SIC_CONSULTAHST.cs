using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONSULTAHST
    {
        public enum Query
        {
            None,
            Listar,      
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
        public string CODTIPODOC { get; set; }
        public DateTime FECHAFIN { get; set; }
        public DateTime FECHAINI { get; set; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        
        #endregion

        public SIC_CONSULTAHST() { }

        public SIC_CONSULTAHST(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:                 
                    NRO = reader.GetInt32("NRO");
                    VERSION = reader.GetSafeString("VERSION");
                    FECHAGEN = reader.GetSafeString("FECHAGEN");
                    DOCUMENTO = reader.GetSafeString("DOCUMENTO");
                    RUTADOCUM = reader.GetSafeString("RUTADOCUM");
                  
                    break;             
                default:
                    break;
            }
        }
    }
}
