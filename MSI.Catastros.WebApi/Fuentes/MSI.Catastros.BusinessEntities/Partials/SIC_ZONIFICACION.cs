using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_ZONIFICACION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            ListarGrilla,
        }

        #region Campos aumentados
        #endregion
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public SIC_ZONIFICACION() { }

        public SIC_ZONIFICACION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    TXTABREVIACION = reader.GetSafeString("TXTABREVIACION");
                    //CONTROL = reader.GetSafeDateTime("CONTROL");
                    break;
                case Query.Recuperar:
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    TXTABREVIACION = reader.GetSafeString("TXTABREVIACION");
                    //CONTROL = reader.GetSafeDateTime("CONTROL");
                    break;
                case Query.ListarGrilla:
                     
                    CODZONIFICACION = reader.GetSafeString("CODZONIFICACION");
                    TXTZONIFICACION = reader.GetSafeString("TXTZONIFICACION");
                    TXTABREVIACION = reader.GetSafeString("TXTABREVIACION");
                    ESTADO = reader.GetSafeString("ESTADO");
                    //CONTROL = reader.GetSafeDateTime("CONTROL");
                    break;
                default:
                    break;
            }
        }
    }
}
