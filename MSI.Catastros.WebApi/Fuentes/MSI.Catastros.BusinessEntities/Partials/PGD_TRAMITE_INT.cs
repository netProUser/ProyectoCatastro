using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class PGD_TRAMITE_INT
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

        public PGD_TRAMITE_INT() { }

        public PGD_TRAMITE_INT(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    //CODLADO = reader.GetSafeString("CODLADO");
                    //TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    break;
                case Query.Consultar:
                    VID = reader.GetSafeString("ID");
                    TXTTIPO_DOCUMENTO = reader.GetSafeString("TIPO_DOCUMENTO");
                    VNRODOC = reader.GetSafeString("NRODOC");
                    TXTASUNTO = reader.GetSafeString("ASUNTO");
                    NUMFOLIO = reader.GetSafeInt32("FOLIOS");
                    COD_ACTIVIDAD = reader.GetSafeString("COD_ACTIVIDAD");
                    TXTAREASOLICITANTE = reader.GetSafeString("DESC_AREA");
                    CODAREASOLICITANTE = reader.GetSafeString("COD_AREA");
                    COD_ACCION = reader.GetSafeString("COD_ACCION");
                    FECHA_LIMITE = reader.GetSafeDateTime("FECHA_LIMITE");

                    break;
                default:
                    break;
            }
        }
    }
}
