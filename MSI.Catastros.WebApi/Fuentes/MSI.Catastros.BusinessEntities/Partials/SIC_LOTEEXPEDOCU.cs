using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEEXPEDOCU
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            ListarDocumentos,
        }

        #region Campos aumentados
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        #endregion
        
        public SIC_LOTEEXPEDOCU() { }

        public SIC_LOTEEXPEDOCU(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                   CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    CODCORRLOTEEXPEDOCU = reader.GetSafeString("CODCORRLOTEEXPEDOCU");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODSOLICITANTE = reader.GetSafeString("CODSOLICITANTE");
                    CODTIPODOCU = reader.GetSafeString("CODTIPODOCU");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    CODCORRLOTEEXPEDOCU = reader.GetSafeString("CODCORRLOTEEXPEDOCU");
                    break;
                case Query.ListarDocumentos:
                    CODDEPARTAMENTO = reader.IsColumnExists("CODDEPARTAMENTO") ? reader.GetSafeString("CODDEPARTAMENTO") : "";
                    CODPROVINCIA = reader.IsColumnExists("CODPROVINCIA") ? reader.GetSafeString("CODPROVINCIA") : "";
                    CODDISTRITO = reader.IsColumnExists("CODDISTRITO") ? reader.GetSafeString("CODDISTRITO") : "";
                    CODSECTOR = reader.IsColumnExists("CODSECTOR") ? reader.GetSafeString("CODSECTOR") : "";
                    CODMANZANA = reader.IsColumnExists("CODMANZANA") ? reader.GetSafeString("CODMANZANA") : "";
                    CODLOTE = reader.IsColumnExists("CODLOTE") ? reader.GetSafeString("CODLOTE") : "";
                    CODSOLICITANTE = reader.IsColumnExists("CODSOLICITANTE") ? reader.GetSafeString("CODSOLICITANTE") : "";
                    CODTIPODOCU = reader.IsColumnExists("CODTIPODOCU") ? reader.GetSafeString("CODTIPODOCU") : "";
                    TXTNUMERO = reader.IsColumnExists("TXTNUMERO") ? reader.GetSafeString("TXTNUMERO") : "";
                    FECDOCUMENTO = reader.GetSafeDateTime("FECDOCUMENTO");
                    TXTOBSERVACION = reader.IsColumnExists("TXTOBSERVACION") ? reader.GetSafeString("TXTOBSERVACION") : "";
                    TXTSOLICITANTE = reader.IsColumnExists("TXTSOLICITANTE") ? reader.GetSafeString("TXTSOLICITANTE") : "";
                    CODCORRLOTEEXPEDOCU = reader.IsColumnExists("CODCORRLOTEEXPEDOCU") ? reader.GetSafeString("CODCORRLOTEEXPEDOCU") : "";
                    TXTIDTRAMITE = reader.IsColumnExists("TXTIDTRAMITE") ? reader.GetSafeString("TXTIDTRAMITE") : "";
                    COD_RECURRENTE = reader.IsColumnExists("COD_RECURRENTE") ? reader.GetSafeString("COD_RECURRENTE") : "";
                    HABILITADO = reader.IsColumnExists("HABILITADO") ? reader.GetSafeString("HABILITADO") : "";
                    TXTASUNTO = reader.IsColumnExists("TXTASUNTO") ? reader.GetSafeString("TXTASUNTO") : "";

                    

                    break;
                default:
                    break;
            }
        }
    }
}
