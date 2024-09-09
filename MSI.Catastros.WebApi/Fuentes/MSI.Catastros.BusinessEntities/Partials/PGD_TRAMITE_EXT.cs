using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class PGD_TRAMITE_EXT
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Consultar
        }

        #region Campos aumentados
        public string TXTTIPO_DOCUMENTO { get; set; }
        public string TXTASUNTO { get; set; }
        public string TXTFOLIO { get; set; }
        public string TXTPERSONREM { get; set; }
        public string COD_ACTIVIDAD { get; set; }
        public string COD_ACCION { get; set; }
        public Nullable<DateTime> FECVENCE { get; set; }
        public Nullable<DateTime> FECHA_INGRESO { get; set; }
        public string TXTAREASOLICITANTE { get; set; }
        public string CODAREASOLICITANTE { get; set; }
        #endregion

        public PGD_TRAMITE_EXT() { }

        public PGD_TRAMITE_EXT(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    //CODLADO = reader.GetSafeString("CODLADO");
                    //TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    break;
                case Query.Consultar:
                    
                    //TXTTIPO_DOCUMENTO = reader.GetSafeString("TIPO_DOCUMENTO");
                    //TXTNRODOC = reader.GetSafeString("NRODOC");
                    
                    //TXTFOLIO = reader.GetSafeString("FOLIO");
                    //COD_ACTIVIDAD = reader.GetSafeString("COD_ACTIVIDAD");
                    //COD_ACCION = reader.GetSafeString("COD_ACCION");
                    VID_REF = reader.GetSafeString("ID");
                    TXTAREASOLICITANTE = reader.GetSafeString("DESC_AREA");
                    CODAREASOLICITANTE = reader.GetSafeString("COD_AREA");
                    COD_LOCAL = reader.GetSafeString("COD_LOCAL");
                    SECUENCIA = reader.GetSafeString("SECUENCIA");
                    DASUNTO = reader.GetSafeString("DASUNTO");
                    RAZON_SOCIAL = reader.GetSafeString("RAZON_SOCIAL");
                    NUMERO_VALOR = reader.GetSafeString("NUMERO_VALOR");
                    USUARIO = reader.GetSafeString("USUARIO");
                    TIPO_DE_VALOR = reader.GetSafeString("TIPO_DE_VALOR");
                    TELEFONOS = reader.GetSafeString("TELEFONOS");
                    FOLIO = reader.GetSafeString("FOLIO");
                    OBSERVACIONES = reader.GetSafeString("OBSERVACIONES");
                    DOCIDREPRESENTANTEL = reader.GetSafeString("DOCIDREPRESENTANTEL");
                    DES_TIPODOCREPL = reader.GetSafeString("DES_TIPODOCREPL");
                    CODTIPODOCREPLEGAL = reader.GetSafeString("CODTIPODOCREPLEGAL");
                    REPRESENTANTEL = reader.GetSafeString("REPRESENTANTEL");
                    DES_TIPODOCREC = reader.GetSafeString("DES_TIPODOCREC");
                    DOCIDRECURRENTE = reader.GetSafeString("DOCIDRECURRENTE");
                    CODTIPODOCUMENTOREC = reader.GetSafeString("CODTIPODOCUMENTOREC");
                    VREMITE = reader.GetSafeString("REMITE");
                    COD_ACTIVIDAD = reader.GetSafeString("COD_ACTIVIDAD");
                    COD_ACCION = reader.GetSafeString("COD_ACCION");
                    FECVENCE = reader.GetSafeDateTime("FECVENCE");
                    TXTPERSONREM = reader.GetSafeString("PERSONREM");
                    CODIGO_CONTRIBUYENTE = reader.GetSafeString("CODIGO_CONTRIBUYENTE");
                    TXTASUNTO = reader.GetSafeString("ASUNTO");
                    SOLICITANTE = reader.GetSafeString("SOLICITANTE");
                    COD_RECURRENTE = reader.GetSafeString("COD_RECURRENTE");
                    FECHA_INGRESO = reader.GetSafeDateTime("FECHA_INGRESO");
                    TIPO_DOCUMENTO = reader.GetSafeString("TIPO_DOCUMENTO");
                    NRODOC = reader.GetSafeString("NRODOC");                    
                    CODIGO_CATASTRAL = reader.GetSafeString("CODIGO_CATASTRAL");

                    TIPO_DE_VIA = reader.GetSafeString("TIPO_DE_VIA");
                    COD_RECDOMICILIO = reader.GetSafeString("COD_RECDOMICILIO");
                    DENOMINACION_DE_LA_VIA = reader.GetSafeString("DENOMINACION_DE_LA_VIA");
                    DESCRIPCION_RECPREDIO = reader.GetSafeString("DESCRIPCION_RECPREDIO");
                    break;
                default:
                    break;
            }
        }
    }
}
