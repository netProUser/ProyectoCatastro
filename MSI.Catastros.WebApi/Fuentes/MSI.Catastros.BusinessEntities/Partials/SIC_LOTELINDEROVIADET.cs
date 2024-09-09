using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTELINDEROVIADET
    {
        public enum Query
        {
            None,
            Listar,
            ListarVia,
            Recuperar,
            ListarColindantes
        }

        #region Campos aumentados
        public string TXTVIA { get; set; }
        public string TXTTIPOVIA { get; set; }

        #endregion
        
        public SIC_LOTELINDEROVIADET() { }

        public SIC_LOTELINDEROVIADET(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarVia:
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTTIPOVIA = reader.GetSafeString("TXTTIPOVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTTIPOVIAANT = reader.GetSafeString("TXTTIPOVIAANT");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");


                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTALTVIAFOR = reader.GetSafeString("TXTALTVIAFOR");
                    CODALTVIAFOR = reader.GetSafeString("CODALTVIAFOR");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRLADO = reader.GetSafeString("CODCORRLADO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    break;
                case Query.ListarColindantes:
                    TXTCOLINDANTE = reader.GetSafeString("TXTCOLINDANTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    TXTTIPOCOLINDANTE = reader.GetSafeString("TXTTIPOCOLINDANTE");
                    CODTIPOCOLI = reader.GetSafeString("CODTIPOCOLI");
                    CORRELATIVO = reader.GetSafeString("CORRELATIVO");
                    CODLADO = reader.GetSafeString("CODLADO");
                    CODCORRLADO = reader.GetSafeString("CODCORRLADO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    
                    break;
                default:
                    break;
            }
        }

        public string CODALTVIAFOR { get; set; }

        public string TXTALTVIAFOR { get; set; }
    }
}
