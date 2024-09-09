using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MANZANAVIA
    {
        public enum Query
        {
            None,
            Listar,
            ListarDetalle,
            ListarVias,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTSECTOR { set; get; }
        public string TXTVIA { set; get; }
        public string TXTMANZANA{ set; get; }

        public Nullable<decimal> NUMALTURA { get; set; }
        public Nullable<decimal> NUMRETIRO { get; set; }
        public Nullable<decimal> NUMJARDIN { get; set; }
        public string TXTOBSERVACION { get; set; }
        public string ORDEN { set; get; }
        public string PARQUE { set; get; }
        public string TXTPARIDAD { set; get; }
        public string TXTLADO { get; set; }
        public string TXTALTURA { get; set; }
        #endregion

        public SIC_MANZANAVIA() { }

        public SIC_MANZANAVIA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarVias:
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODANOVAL = reader.GetSafeString("CODANOVAL");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTMANZANA = reader.GetSafeString("TXTMANZANA");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");
                    NUMVALOR = reader.GetSafeDecimal("NUMVALOR");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    TXTALTURA = reader.GetSafeString("TXTALTURA");
                    break;
                case Query.ListarDetalle:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTLADO = reader.GetSafeString("TXTLADO");
                    CODANOVAL = reader.GetSafeString("CODANOVAL");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTMANZANA = reader.GetSafeString("TXTMANZANA");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");
                    NUMVALOR = reader.GetSafeDecimal("NUMVALOR");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    NUMALTURA = reader.GetSafeDecimal("NUMALTURA");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    CODANOVAL = reader.GetSafeString("CODANOVAL");
                    TXTALTURA = reader.GetSafeString("TXTALTURA");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODANOVAL = reader.GetSafeString("CODANOVAL");
                    NUMVALOR = reader.GetSafeDecimal("NUMVALOR");
                    NUMALTURA = reader.GetSafeDecimal("NUMALTURA");
                    TXTOBSERVACION = reader.GetSafeString("TXTOBSERVACION");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    TXTALTURA = reader.GetSafeString("TXTALTURA");
                    break;
                default:
                    break;
            }
        }
    }
}
