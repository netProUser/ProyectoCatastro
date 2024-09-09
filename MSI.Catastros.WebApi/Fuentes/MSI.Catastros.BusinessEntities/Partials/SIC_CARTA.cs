using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CARTA
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
            ListarCarta
        }

        #region Campos aumentados

        public string CODNROINSPEC { get; set; }
        public string TXTUBICACION { get; set; }
        public string TXTCODIGOCATASTRAL { get; set; }
        public string TXTFECHAGENERACION { get; set; }
        public string TXTFECHANUEVA { get; set; }
        public string TXTDOCUMENTO { get; set; }
        public string CODPEREMISION { get; set; }
        public string CODDOCUMGEN { get; set; }
        //public DateTime? FECREG { get; set; } 

        #endregion
        public SIC_CARTA() { }

        public SIC_CARTA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarCarta:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODNROINSPEC = reader.GetSafeString("CODNROINSPEC");
                    TXTCODIGOCATASTRAL = reader.GetSafeString("TXTCODIGOCATASTRAL");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    TXTFECHAGENERACION = reader.GetSafeString("TXTFECHAGENERACION");
                    TXTFECHANUEVA = reader.GetSafeString("TXTFECHANUEVA");
                    TXTDOCUMENTO = "";
                    CODCORRCARTA = reader.GetSafeString("CODCORRCARTA");
                    TXTPARRAFO1 = reader.GetSafeString("TXTPARRAFO1");
                    CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    CODTRAMITE = reader.GetSafeString("CODTRAMITE");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    break;

                case Query.Listar:
                    CODCARTA = reader.GetSafeString("CODCARTA");
                    CODCORRCARTA = reader.GetSafeString("CODCORRCARTA");
                    CODANO = reader.GetSafeString("CODANO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODOOFICINA = reader.GetSafeString("CODOOFICINA");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CTIPODOCUMENTO = reader.GetSafeString("CTIPODOCUMENTO");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTSUBTITULO1 = reader.GetSafeString("TXTSUBTITULO1");
                    TXTSUBTITULO2 = reader.GetSafeString("TXTSUBTITULO2");
                    TXTSUBTITULO3 = reader.GetSafeString("TXTSUBTITULO3");
                    TXTSUBTITULO4 = reader.GetSafeString("TXTSUBTITULO4");
                    TXTSUBTITULO5 = reader.GetSafeString("TXTSUBTITULO5");
                    TXTSUBTITULO6 = reader.GetSafeString("TXTSUBTITULO6");
                    TXTSUBTITULO7 = reader.GetSafeString("TXTSUBTITULO7");
                    TXTPARRAFO1 = reader.GetSafeString("TXTPARRAFO1");
                    TXTPARRAFO2 = reader.GetSafeString("TXTPARRAFO2");
                    TXTPARRAFO3 = reader.GetSafeString("TXTPARRAFO3");
                    TXTPARRAFO4 = reader.GetSafeString("TXTPARRAFO4");
                    TXTPARRAFO5 = reader.GetSafeString("TXTPARRAFO5");
                    TXTPARRAFO6 = reader.GetSafeString("TXTPARRAFO6");
                    TXTPARRAFO7 = reader.GetSafeString("TXTPARRAFO7");
                    TXTPARRAFO8 = reader.GetSafeString("TXTPARRAFO8");
                    TXTPARRAFO9 = reader.GetSafeString("TXTPARRAFO9");
                    TXTPARRAFO10 = reader.GetSafeString("TXTPARRAFO10");
                    TXTFIRMA1 = reader.GetSafeString("TXTFIRMA1");
                    TXTFIRMA2 = reader.GetSafeString("TXTFIRMA2");
                    TXTFIRMA3 = reader.GetSafeString("TXTFIRMA3");
                    TXTFIRMA4 = reader.GetSafeString("TXTFIRMA4");
                    TXTFIRMA5 = reader.GetSafeString("TXTFIRMA5");
                    TXTPIEPAGINA = reader.GetSafeString("TXTPIEPAGINA");
                    break;
                case Query.Recuperar:
                    CODCARTA = reader.GetSafeString("CODCARTA");
                    CODCORRCARTA = reader.GetSafeString("CODCORRCARTA");
                    CODANO = reader.GetSafeString("CODANO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODOOFICINA = reader.GetSafeString("CODOOFICINA");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTSUBTITULO1 = reader.GetSafeString("TXTSUBTITULO1");
                    TXTSUBTITULO2 = reader.GetSafeString("TXTSUBTITULO2");
                    TXTSUBTITULO3 = reader.GetSafeString("TXTSUBTITULO3");
                    TXTSUBTITULO4 = reader.GetSafeString("TXTSUBTITULO4");
                    TXTSUBTITULO5 = reader.GetSafeString("TXTSUBTITULO5");
                    TXTSUBTITULO6 = reader.GetSafeString("TXTSUBTITULO6");
                    TXTSUBTITULO7 = reader.GetSafeString("TXTSUBTITULO7");
                    TXTPARRAFO1 = reader.GetSafeString("TXTPARRAFO1");
                    TXTPARRAFO2 = reader.GetSafeString("TXTPARRAFO2");
                    TXTPARRAFO3 = reader.GetSafeString("TXTPARRAFO3");
                    TXTPARRAFO4 = reader.GetSafeString("TXTPARRAFO4");
                    TXTPARRAFO5 = reader.GetSafeString("TXTPARRAFO5");
                    TXTPARRAFO6 = reader.GetSafeString("TXTPARRAFO6");
                    TXTPARRAFO7 = reader.GetSafeString("TXTPARRAFO7");
                    TXTPARRAFO8 = reader.GetSafeString("TXTPARRAFO8");
                    TXTPARRAFO9 = reader.GetSafeString("TXTPARRAFO9");
                    TXTPARRAFO10 = reader.GetSafeString("TXTPARRAFO10");
                    TXTFIRMA1 = reader.GetSafeString("TXTFIRMA1");
                    TXTFIRMA2 = reader.GetSafeString("TXTFIRMA2");
                    TXTFIRMA3 = reader.GetSafeString("TXTFIRMA3");
                    TXTFIRMA4 = reader.GetSafeString("TXTFIRMA4");
                    TXTFIRMA5 = reader.GetSafeString("TXTFIRMA5");
                    CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    TXTPIEPAGINA = reader.GetSafeString("TXTPIEPAGINA");
                    CODPEREMISION = reader.GetSafeString("CODPEREMISION");
                    break;
                default:
                    break;
            }
        }



        public string CODTRAMITE { get; set; }
    }
}
