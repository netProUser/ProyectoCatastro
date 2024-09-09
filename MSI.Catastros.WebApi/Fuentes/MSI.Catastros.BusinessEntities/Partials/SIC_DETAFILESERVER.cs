using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_DETAFILESERVER
    {
        public enum Query
        {
            None,
            //Listar,
            Recuperar,
        }
        public SIC_DETAFILESERVER() { }

        public SIC_DETAFILESERVER(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Recuperar:
                    CODCORRELFS = reader.GetSafeString("CODCORRELFS");
                    TXTNOMTABLA = reader.GetSafeString("TXTNOMTABLA");
                    CODPKTABLA = reader.GetSafeString("CODPKTABLA");
                    TXTPKTABLANOM = reader.GetSafeString("TXTPKTABLANOM");
                    TXTEXTENSION = reader.GetSafeString("TXTEXTENSION");
                    TXTRUTA = reader.GetSafeString("TXTRUTA");
                    FLGPRINCIPAL = reader.GetSafeString("FLGPRINCIPAL");                    
                    break;
                default:
                    break;
            }
        }
    }
}
