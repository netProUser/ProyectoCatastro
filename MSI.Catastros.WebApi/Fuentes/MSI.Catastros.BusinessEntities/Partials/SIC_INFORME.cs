using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INFORME
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
            ListarInforme,
            Total
        }

        #region Campos aumentados
        public string TXTANIO { get; set; }
        public string TXTNOMBREFIRMA { get; set; }
        public string TXTCARGOFIRMA { get; set; }
        public string TXTUBICACION { get; set; }
        public string TXTCODIGOCATASTRAL { get; set; }
        public string FECACTUAL { get; set; }
        public string RESPONSABLE { get; set; }
        public string CODTRAMITE { get; set; }
        public string ITEM { get; set; }
        #endregion
        public SIC_INFORME() { }

        public SIC_INFORME(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarInforme:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    TXTFECHAGENERACION = reader.GetSafeString("TXTFECHAGENERACION");
                    TXTCODIGOCATASTRAL = reader.GetSafeString("TXTCODIGOCATASTRAL");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    CODOFICINA = reader.GetSafeString("CODOFICINA");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    CODESTADOFINAL = reader.GetSafeString("CODESTADOFINAL");
                    CODTRAMITE = reader.GetSafeString("CODTRAMITE");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    TXTDOCUMENTO = "";
                    CODCORRINFO = reader.GetSafeString("CODCORRINFO");
                    //TXTPARRAFO1 = reader.GetSafeString("TXTPARRAFO1");
                    break;
                case Query.Listar:
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    CODANOINFO = reader.GetSafeString("CODANOINFO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODOFICINA = reader.GetSafeString("CODOFICINA");
                    TXTSIGLA = reader.GetSafeString("TXTSIGLA");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CTIPODOCUMENTO = reader.GetSafeString("CTIPODOCUMENTO");
                    FECINSPECCION = reader.GetSafeDateTime("FECINSPECCION");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    CODPERSONA = reader.GetSafeString("CODPERSONA");
                    TXTUNIDAD = reader.GetSafeString("TXTUNIDAD");
                    TXTCODIGOUNICO = reader.GetSafeString("TXTCODIGOUNICO");
                    TXTUNIDADDIREC = reader.GetSafeString("TXTUNIDADDIREC");
                    TXTUNIDADTITULAR = reader.GetSafeString("TXTUNIDADTITULAR");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTOFICINA = reader.GetSafeString("TXTOFICINA");
                    TXTDESCRIPCIONINFORME = reader.GetSafeString("TXTDESCRIPCIONINFORME");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTNOMBREFIRMA = reader.GetSafeString("TXTNOMBREFIRMA");
                    TXTUNIDADES = reader.GetSafeString("TXTUNIDADES");
                    break;
                case Query.Recuperar:
                    CODINFORME = reader.GetSafeString("CODINFORME");
                    CODCORRINFO = reader.GetSafeString("CODCORRINFO");
                    CODANOINFO = reader.GetSafeString("CODANOINFO");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    CODOFICINA = reader.GetSafeString("CODOFICINA");
                    TXTSIGLA = reader.GetSafeString("TXTSIGLA");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CTIPODOCUMENTO = reader.GetSafeString("CTIPODOCUMENTO");
                    FECINSPECCION = reader.GetSafeDateTime("FECINSPECCION");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    TXTASUNTO = reader.GetSafeString("TXTASUNTO");
                    CODCARCAT = reader.GetSafeString("CODCARCAT");
                    CODUSUASIS = reader.GetSafeString("CODUSUASIS");
                    CODPERSONA = reader.GetSafeString("CODPERSONA");
                    CODPEREMISION = reader.GetSafeString("CODPEREMISION");
                    TXTUNIDAD = reader.GetSafeString("TXTUNIDAD");
                    TXTCODIGOUNICO = reader.GetSafeString("TXTCODIGOUNICO");
                    TXTUNIDADDIREC = reader.GetSafeString("TXTUNIDADDIREC");
                    TXTUNIDADTITULAR = reader.GetSafeString("TXTUNIDADTITULAR");
                    TXTSOLICITANTE = reader.GetSafeString("TXTSOLICITANTE");
                    TXTOFICINA = reader.GetSafeString("TXTOFICINA");
                    TXTDESCRIPCIONINFORME = reader.GetSafeString("TXTDESCRIPCIONINFORME");
                    TXTUNIDADES = reader.GetSafeString("TXTUNIDADES");
                    FECACTUAL = reader.GetSafeString("FECACTUAL");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTCARGOFIRMA = reader.GetSafeString("TXTCARGOFIRMA");
                    TXTNOMBREFIRMA = reader.GetSafeString("TXTNOMBREFIRMA");
                    RESPONSABLE = reader.GetSafeString("RESPONSABLE");
                    CODTRAMITE = reader.GetSafeString("CODTRAMITE");
                    CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    NROCALIDADVERIFICACION = reader.IsColumnExists("NROCALIDADVERIFICACION") ? reader.GetSafeString("NROCALIDADVERIFICACION") : "";
                    TXTTIPODOCUMENTO = reader.IsColumnExists("TXTTIPODOCUMENTO") ? reader.GetSafeString("TXTTIPODOCUMENTO") : "";
                    TXTPEREMISION = reader.IsColumnExists("TXTPEREMISION") ? reader.GetSafeString("TXTPEREMISION") : "";
                    TIPO_VERIFICACION = reader.IsColumnExists("TIPO_VERIFICACION") ? reader.GetSafeString("TIPO_VERIFICACION") : "";
                    break;
                case Query.Total:
                    ITEM = reader.GetSafeString("ITEM");
                    break;
                default:
                    break;
            }
        }
    }
}
