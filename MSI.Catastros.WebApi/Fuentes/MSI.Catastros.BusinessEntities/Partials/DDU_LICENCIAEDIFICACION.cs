using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class DDU_LICENCIAEDIFICACION
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
        public string COD_ACTIVIDAD { get; set; }
        public string COD_ACCION { get; set; }
        public Nullable<DateTime> FECHA_LIMITE { get; set; }
        public Nullable<int> NUMFOLIO { get; set; }
        public string TXTAREASOLICITANTE { get; set; }
        public string CODAREASOLICITANTE { get; set; }
        #endregion

        public DDU_LICENCIAEDIFICACION() { }

        public DDU_LICENCIAEDIFICACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    //CODLADO = reader.GetSafeString("CODLADO");
                    //TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    break;
                case Query.Consultar:
                    SOLICITANTE = reader.GetSafeString("SOLICITANTE");
                    BENEFICIARIO = reader.GetSafeString("BENEFICIARIO");
                    TIPO_OBRA = reader.GetSafeString("TIPO_OBRA");
                    NUMERO_LICENCIA = reader.GetSafeString("NUMERO_LICENCIA");
                    FECHA_LICENCIA = reader.GetSafeDateTime("FECHA_LICENCIA");
                    CODIGO_CATASTRAL = reader.GetSafeString("CODIGO_CATASTRAL");
                    OBSERVACIONES = reader.GetSafeString("OBSERVACIONES");
                    PDF = reader.GetSafeString("PDF");
                    CODUNICO = reader.GetSafeString("CODUNICO");
                    ESTADO_LICENCIA = reader.GetSafeString("ESTADO_LICENCIA");

                    break;
                default:
                    break;
            }
        }
    }
}
