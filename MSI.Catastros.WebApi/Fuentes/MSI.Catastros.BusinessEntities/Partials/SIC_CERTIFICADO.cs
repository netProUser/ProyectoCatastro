using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CERTIFICADO
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
            Urbanizacion,
            ListarCertificado,
            ListarConsultaCertificado
        }

        #region Campos aumentados

        public string TXTPARTIDACODIGO { get; set; }
        public string FLG_TRABAJO { get; set; }
        public string TOTALDETALLE { get; set; }

        #endregion
        public SIC_CERTIFICADO() { }

        public SIC_CERTIFICADO(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Urbanizacion:
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    break;
                case Query.ListarCertificado:
                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    TXTCODIGOCATASTRAL = reader.GetSafeString("TXTCODIGOCATASTRAL");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    TXTFECHAGENERACION = reader.GetSafeDateTime("TXTFECHAGENERACION");
                    TXTCODUNI = reader.GetSafeString("TXTCODUNI");
                    FLG_TRABAJO = reader.GetSafeString("FLG_TRABAJO");
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTRAMITE = reader.GetSafeString("CODTRAMITE");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    TXTDOCUMENTO = "";
                    //CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    break;

                case Query.Listar:
                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
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
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");
                    break;
                case Query.Recuperar:
                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    TXTDETALLE = reader.GetSafeString("TXTDETALLE");
                    CODOFICINA = reader.GetSafeString("CODOFICINA");
                    TXTSIGLA = reader.GetSafeString("TXTSIGLA");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    CTIPODOCUMENTO = reader.GetSafeString("CTIPODOCUMENTO");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    CODPERSONA = reader.GetSafeString("CODPERSONA");
                    TXTUNIDAD = reader.GetSafeString("TXTUNIDAD");
                    TXTUNIDADDIREC = reader.GetSafeString("TXTUNIDADDIREC");
                    TXTUNIDADTITULAR = reader.GetSafeString("TXTUNIDADTITULAR");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTDIRECSOLIC = reader.GetSafeString("TXTDIRECSOLIC");
                    TXTCODTIPOSOLI = reader.GetSafeString("TXTCODTIPOSOLI");
                    TXTPARTIDA = reader.GetSafeString("TXTPARTIDA");
                    TXTPARTIDACODIGO = reader.GetSafeString("TXTPARTIDACODIGO");
                    TXTCODHOJACATAS = reader.GetSafeString("TXTCODHOJACATAS");
                    TXTCODIGOUNICO = reader.GetSafeString("TXTCODIGOUNICO");
                    FECACTUAL = reader.GetSafeString("FECACTUAL");
                    TXTURBANIZACION = reader.GetSafeString("TXTURBANIZACION");
                    CODPEREMISION = reader.GetSafeString("CODPEREMISION");
                    TXTMANZANAURB = reader.GetSafeString("TXTMANZANAURB");
                    TXTLOTEURB = reader.GetSafeString("TXTLOTEURB");
                    TXTSUBLOTEURB = reader.GetSafeString("TXTSUBLOTEURB");
                    FECPAGO = reader.GetSafeDateTime("FECPAGO");

                    TXTCUC = reader.GetSafeString("TXTCUC");
                    CODTRAMITE = reader.GetSafeString("CODTRAMITE");

                    FECCERTIFICADO = reader.GetSafeString("FECCERTIFICADO").Substring(0,10);
                    TXTASUNTOCERT = reader.GetSafeString("TXTASUNTOCERT");
                    TXTPLANOCATAS = reader.GetSafeString("TXTPLANOCATAS");
                    CODTIPINSC = reader.GetSafeString("CODTIPINSC");
                    TXTRECIBO = reader.GetSafeString("TXTRECIBO");
                    TXTHOJAPLANO = reader.GetSafeString("TXTHOJAPLANO");
                    TXTESCAPLANO = reader.GetSafeString("TXTESCAPLANO");
                    NUMAREATECHCOM = reader.GetSafeString("NUMAREATECHCOM");

                    TXTOBSERV = reader.GetSafeString("TXTOBSERV");
                    TXTNIVEL = reader.GetSafeString("TXTNIVEL");
                    TXTDESCRIPVIVIENDA = reader.GetSafeString("TXTDESCRIPVIVIENDA");
                    TXTINTERIOR = reader.GetSafeString("TXTINTERIOR");
                    TXTRUTAIMAGEN = reader.GetSafeString("TXTRUTAIMAGEN");

                    TOTALDETALLE = reader.GetSafeString("TOTALDETALLE");
                    break;
                case Query.ListarConsultaCertificado:
                    CODCERTIFICADO     = reader.GetSafeString("CODCERTIFICADO");
                    CODANOCERTI        = reader.GetSafeString("CODANOCERTI");
                    CODANOSOLI         = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI        = reader.GetSafeString("CODTIPOSOLI");
                    TXTTIPOSOLI        = reader.GetSafeString("TXTTIPOSOLI");
                    CODNUMESOLI        = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOCERTI       = reader.GetSafeString("CODTIPOCERTI");
                    CODTRAMITE         = reader.GetSafeString("CODTRAMITE");
                    CODUNI             = reader.GetSafeString("CODUNI");
                    TXTCODIGOCATASTRAL = reader.GetSafeString("TXTCODIGOCATASTRAL");
                    TXTUBICACION       = reader.GetSafeString("TXTUBICACION");
                    FLG_TRABAJO        = reader.GetSafeString("FLG_TRABAJO");
                    TXTRUTAIMAGEN      = reader.GetSafeString("TXTRUTAIMAGEN");
                    FECREG             = reader.GetSafeDateTime("FECREG");
                    CODUSUARIOREG      = reader.GetSafeString("CODUSUARIOREG");
                    CODTIPODOC         = reader.GetSafeString("CODTIPODOC");
                    NRO                = reader.GetSafeString("NRO");
                    TXTTIPOCERTI       = reader.GetSafeString("TXTTIPOCERTI");


                    break;
                default:
                    break;
            }
        }

        public string CODTRAMITE { get; set; }
    }
}
