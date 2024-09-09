using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_TIPOLLENA
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            Limite,
        }

        #region Campos aumentados
        public string FECHALIMITE { get; set; }
        #endregion

        public SIC_TIPOLLENA() { }

        public SIC_TIPOLLENA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    break;
                case Query.Recuperar:
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    TXTTIPOLLENADO = reader.GetSafeString("TXTTIPOLLENADO");
                    NUMTIEDIAS = reader.GetSafeInt32("NUMTIEDIAS");
                    NUMTPROGINSPE = reader.GetSafeInt32("NUMTPROGINSPE");
                    NUMTPROCINSPE = reader.GetSafeInt32("NUMTPROCINSPE");
                    NUMTPROAC = reader.GetSafeInt32("NUMTPROAC");
                    NUMTPROAF = reader.GetSafeInt32("NUMTPROAF");
                    break;
                case Query.Limite:
                    FECHALIMITE = reader.GetSafeString("FECHALIMITE");
                    break;
                default:
                    break;
            }
        }
    }
}
