using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADTITULAR
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            ListarRentas,
        }

        #region Campos aumentados
        public string TXTRAZONSOCIAL {get; set;}
        public string TXTDOCIDENTIDAD { get; set; }
        public string TXTCONDTITU { get; set; }
        public string CODTIPODOCIDENTIDAD { get; set; }
        public string TIPODOCIDENTIDAD { get; set; }

        public string CODCATASTRAL { get; set; } // Rentas
        public string CODPREDIO { get; set; }
        public string CODANEXO { get; set; }
        public string TXTDIRECCION { get; set; }
        public string CODCONDICIONPROPIEDAD { get; set; }
        public string CONDICIONPROPIEDAD { get; set; }
        public string PCTCONDOMINO { get; set; }
        public string CODPERSONA { get; set; }
        public string NUMVERSIONPERSONA { get; set; }
        public string TIPOPERSONA { get; set; }
        public string CODTIPOPERSONA { get; set; }
        public string TXTTIPOPROPIETARIO { get; set; }
        public bool ESTATICO { get; set; }
        #endregion

        public SIC_UNIDADTITULAR() { }

        public SIC_UNIDADTITULAR(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    NUMPORCTITU = reader.GetSafeString("NUMPORCTITU");
                    CODCONDTITU = reader.GetSafeString("CODCONDTITU");
                    TXTRAZONSOCIAL = reader.GetSafeString("TXTRAZONSOCIAL");
                    TXTDOCIDENTIDAD = reader.GetSafeString("TXTDOCIDENTIDAD");
                    TXTCONDTITU = reader.GetSafeString("TXTCONDTITU");
                    TXTTIPOPROPIETARIO = reader.GetSafeString("TXTTIPOPROPIETARIO");
                    TXTTIPODOCIDENTIDAD = reader.GetSafeString("TXTTIPODOCIDENTIDAD");
                    TXTPROCEDENCIA = reader.GetSafeString("TXTPROCEDENCIA");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    NUMPORCTITU = reader.GetSafeString("NUMPORCTITU");
                    CODCONDTITU = reader.GetSafeString("CODCONDTITU");
                    break;
                case Query.ListarRentas:
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    CODPERSONA = reader.GetSafeString("CODPERSONA");
                    NUMVERSIONPERSONA = reader.GetSafeString("NUMVERSIONPERSONA");
                    TXTRAZONSOCIAL = reader.GetSafeString("TXTRAZONSOCIAL");
                    CODTIPODOCIDENTIDAD = reader.GetSafeString("CODTIPODOCIDENTIDAD");
                    TIPODOCIDENTIDAD = reader.GetSafeString("TIPODOCIDENTIDAD");
                    TXTDOCIDENTIDAD = reader.GetSafeString("TXTDOCIDENTIDAD");  
                    TIPOPERSONA = reader.GetSafeString("TIPOPERSONA");
                    CODTIPOPERSONA = reader.GetSafeString("CODTIPOPERSONA");
           
                    //CODCATASTRAL = reader.GetSafeString("CODCATASTRAL");
                    //CODPREDIO = reader.GetSafeString("CODPREDIO");
                    //CODANEXO = reader.GetSafeString("CODANEXO");
                    //TXTDIRECCION = reader.GetSafeString("TXTDIRECCION");
                    //CODCONDICIONPROPIEDAD = reader.GetSafeString("CODCONDICIONPROPIEDAD");
                    //CONDICIONPROPIEDAD = reader.GetSafeString("CONDICIONPROPIEDAD");
                    //PCTCONDOMINO = reader.GetSafeString("PCTCONDOMINO");
                    break;

                default:
                    break;
            }
        }
    }
}
