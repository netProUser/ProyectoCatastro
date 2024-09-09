using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CARTACONFI
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
        }

        #region Campos aumentados
        #endregion
        public SIC_CARTACONFI() { }

        public SIC_CARTACONFI(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODCARTA = reader.GetSafeString("CODCARTA");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    TXTTITULOGENERAL = reader.GetSafeString("TXTTITULOGENERAL");
                    TXTSIGLAS = reader.GetSafeString("TXTSIGLAS");
                    CODOOFICINA = reader.GetSafeString("CODOOFICINA");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTCONFSUBTITULO1 = reader.GetSafeString("TXTCONFSUBTITULO1");
                    TXTCONFSUBTITULO2 = reader.GetSafeString("TXTCONFSUBTITULO2");
                    TXTCONFSUBTITULO3 = reader.GetSafeString("TXTCONFSUBTITULO3");
                    TXTCONFSUBTITULO4 = reader.GetSafeString("TXTCONFSUBTITULO4");
                    TXTCONFSUBTITULO5 = reader.GetSafeString("TXTCONFSUBTITULO5");
                    TXTCONFSUBTITULO6 = reader.GetSafeString("TXTCONFSUBTITULO6");
                    TXTCONFSUBTITULO7 = reader.GetSafeString("TXTCONFSUBTITULO7");
                    TXTCONFPARRAFO1 = reader.GetSafeString("TXTCONFPARRAFO1");
                    TXTCONFPARRAFO2 = reader.GetSafeString("TXTCONFPARRAFO2");
                    TXTCONFPARRAFO3 = reader.GetSafeString("TXTCONFPARRAFO3");
                    TXTCONFPARRAFO4 = reader.GetSafeString("TXTCONFPARRAFO4");
                    TXTCONFPARRAFO5 = reader.GetSafeString("TXTCONFPARRAFO5");
                    TXTCONFPARRAFO6 = reader.GetSafeString("TXTCONFPARRAFO6");
                    TXTCONFPARRAFO7 = reader.GetSafeString("TXTCONFPARRAFO7");
                    TXTCONFPARRAFO8 = reader.GetSafeString("TXTCONFPARRAFO8");
                    TXTCONFPARRAFO9 = reader.GetSafeString("TXTCONFPARRAFO9");
                    TXTCONFPARRAFO10 = reader.GetSafeString("TXTCONFPARRAFO10");
                    TXTCONFFIRMA1 = reader.GetSafeString("TXTCONFFIRMA1");
                    TXTCONFFIRMA2 = reader.GetSafeString("TXTCONFFIRMA2");
                    TXTCONFFIRMA3 = reader.GetSafeString("TXTCONFFIRMA3");
                    TXTCONFFIRMA4 = reader.GetSafeString("TXTCONFFIRMA4");
                    TXTCONFFIRMA5 = reader.GetSafeString("TXTCONFFIRMA5");
                    TXTCONFPIEPAGINA = reader.GetSafeString("TXTCONFPIEPAGINA");
                    break;
                case Query.Recuperar:
                    CODCARTA = reader.GetSafeString("CODCARTA");
                    CODTIPOINFOR = reader.GetSafeString("CODTIPOINFOR");
                    TXTTITULOGENERAL = reader.GetSafeString("TXTTITULOGENERAL");
                    TXTSIGLAS = reader.GetSafeString("TXTSIGLAS");
                    CODOOFICINA = reader.GetSafeString("CODOOFICINA");
                    TXTANIO = reader.GetSafeString("TXTANIO");
                    TXTCONFSUBTITULO1 = reader.GetSafeString("TXTCONFSUBTITULO1");
                    TXTCONFSUBTITULO2 = reader.GetSafeString("TXTCONFSUBTITULO2");
                    TXTCONFSUBTITULO3 = reader.GetSafeString("TXTCONFSUBTITULO3");
                    TXTCONFSUBTITULO4 = reader.GetSafeString("TXTCONFSUBTITULO4");
                    TXTCONFSUBTITULO5 = reader.GetSafeString("TXTCONFSUBTITULO5");
                    TXTCONFSUBTITULO6 = reader.GetSafeString("TXTCONFSUBTITULO6");
                    TXTCONFSUBTITULO7 = reader.GetSafeString("TXTCONFSUBTITULO7");
                    TXTCONFPARRAFO1 = reader.GetSafeString("TXTCONFPARRAFO1");
                    TXTCONFPARRAFO2 = reader.GetSafeString("TXTCONFPARRAFO2");
                    TXTCONFPARRAFO3 = reader.GetSafeString("TXTCONFPARRAFO3");
                    TXTCONFPARRAFO4 = reader.GetSafeString("TXTCONFPARRAFO4");
                    TXTCONFPARRAFO5 = reader.GetSafeString("TXTCONFPARRAFO5");
                    TXTCONFPARRAFO6 = reader.GetSafeString("TXTCONFPARRAFO6");
                    TXTCONFPARRAFO7 = reader.GetSafeString("TXTCONFPARRAFO7");
                    TXTCONFPARRAFO8 = reader.GetSafeString("TXTCONFPARRAFO8");
                    TXTCONFPARRAFO9 = reader.GetSafeString("TXTCONFPARRAFO9");
                    TXTCONFPARRAFO10 = reader.GetSafeString("TXTCONFPARRAFO10");
                    TXTCONFFIRMA1 = reader.GetSafeString("TXTCONFFIRMA1");
                    TXTCONFFIRMA2 = reader.GetSafeString("TXTCONFFIRMA2");
                    TXTCONFFIRMA3 = reader.GetSafeString("TXTCONFFIRMA3");
                    TXTCONFFIRMA4 = reader.GetSafeString("TXTCONFFIRMA4");
                    TXTCONFFIRMA5 = reader.GetSafeString("TXTCONFFIRMA5");
                    TXTCONFPIEPAGINA = reader.GetSafeString("TXTCONFPIEPAGINA");
                    break;
                default:
                    break;
            }
        }
    }
}
