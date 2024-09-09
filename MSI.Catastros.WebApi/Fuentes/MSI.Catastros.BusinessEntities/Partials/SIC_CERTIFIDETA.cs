using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CERTIFIDETA
    {
        public enum Query
        {
            None,
            Recuperar,
            Listar,
            ListarCerti,
            ListarDetalleNomenclatura
        }

        #region Campos aumentados

        public int? CODUNI { get; set; }
        public string CODCORRUNIDDIREINTE { get; set; }
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODEDIFICACION { get; set; }
        public string CODENTRADA { get; set; }
        public string CODPISO { get; set; }
        public string CODUNIDAD { get; set; }
        public string TXTTIPODEVIA { get; set; }
        public string TXTVIA { get; set; }
        public string CODTIPOINTE { get; set; }
        public string TXTIPOINTERIOR { get; set; }
        public string TXTLETRA { get; set; }
        public string TXTNUMEROPUERTA { get; set; }
        public string TXTLETRAPUERTA { get; set; }
        public string TXTVIAANTE { get; set; }
        public string TXTDESCRIPCION { get; set; }
        public string TXTABREVANT { get; set; }
        #endregion
        public SIC_CERTIFIDETA() { }

        public SIC_CERTIFIDETA(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Recuperar:

                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI");
                    CODCORRELCERT = reader.GetSafeString("CODCORRELCERT");
                    //CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    break;
                case Query.ListarCerti:
                    CODCORRELCERT = reader.GetSafeString("CODCORRELCERT");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTIPOINTERIOR = reader.GetSafeString("TXTIPOINTERIOR");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTNOMVIAANT = reader.GetSafeString("TXTNOMVIAANT");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");
                    TXTNIVEL = reader.GetSafeString("TXTNIVEL");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTABREVANT = reader.GetSafeString("TXTABREVANT");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDDIREINTE = reader.GetSafeString("CODCORRUNIDDIREINTE");

                    

                    break;
                case Query.Listar:

                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO");
                    CODCORRELCERT = reader.GetSafeString("CODCORRELCERT");
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI");
                    CODINSCRP = reader.GetSafeString("CODINSCRP");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODVIAESQ = reader.GetSafeString("CODVIAESQ");
                    TXTNOMVIA = reader.GetSafeString("TXTNOMVIA");
                    TXTNOMVIAESQ = reader.GetSafeString("TXTNOMVIAESQ");
                    TXTNOMVIAANT = reader.GetSafeString("TXTNOMVIAANT");
                    TXTNIVEL = reader.GetSafeString("TXTNIVEL");
                    TXTTIPOVIAANT = reader.GetSafeString("TXTTIPOVIAANT");
                    TXTTIPOVIA = reader.GetSafeString("TXTTIPOVIA");
                    TXTTIPOVIAESQ = reader.GetSafeString("TXTTIPOVIAESQ");
                    //CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    TXTNOMVIAESQANT = reader.GetSafeString("TXTNOMVIAESQANT");
                    TXTTIPOVIAESQANT = reader.GetSafeString("TXTTIPOVIAESQANT");

                    break;
                case Query.ListarDetalleNomenclatura:

                    CODCERTIFICADO = reader.GetSafeString("CODCERTIFICADO"); 
                    CODANOCERTI = reader.GetSafeString("CODANOCERTI"); 
                    CODTIPOCERTI = reader.GetSafeString("CODTIPOCERTI"); 
                    CODCORRELCERT = reader.GetSafeString("CODCORRELCERT"); 
                    CODVIA = reader.GetSafeString("CODVIA"); 
                    TXTNOMVIA = reader.GetSafeString("TXTNOMVIA");  
                    TXTNOMVIAANT = reader.GetSafeString("TXTNOMVIAANT");  
                    FLAGESQ = reader.GetSafeString("FLAGESQ");  
                    CODVIAESQ = reader.GetSafeString("CODVIAESQ");  
                    TXTNOMVIAESQ = reader.GetSafeString("TXTNOMVIAESQ");  
                    TXTTIPOVIA = reader.GetSafeString("TXTTIPOVIA"); 
                    TXTTIPOVIAANT = reader.GetSafeString("TXTTIPOVIAANT");  
                    TXTTIPOVIAESQ = reader.GetSafeString("TXTTIPOVIAESQ"); 
                    
                    //CODDOCUMGEN = reader.GetSafeString("CODDOCUMGEN");
                    break;
                default:
                    break;
            }
        }
    }
}
