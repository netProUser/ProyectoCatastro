using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONSULTAGEN
    {
        public enum Query
        {
            None,
            Listar,
            ListarSimple,
        }

        #region Campos aumentados
        public string CODCONTRIBUYENTE { get; set; }
        public string TXTDOCIDENTIDAD { get; set; }
        public string CODVIA { get; set; }
        public string CODHU { get; set; }
        public string CODUSOPRED  { get; set; }
        public string CODCLAS  { get; set; }
        public string CODESTACONS  { get; set; }
        public string NIVEL  { get; set; }
        public string CODCATASTRAL { get; set; }

        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        
        #endregion

        public SIC_CONSULTAGEN() { }

        public SIC_CONSULTAGEN(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarSimple:
                    CODCATASTRAL = reader.GetSafeString("CODCATASTRAL");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    break;
                case Query.Listar:                 
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    TXTTITULARES = reader.GetSafeString("TXTTITULARES");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    break;             
                default:
                    break;
            }
        }
    }
}
