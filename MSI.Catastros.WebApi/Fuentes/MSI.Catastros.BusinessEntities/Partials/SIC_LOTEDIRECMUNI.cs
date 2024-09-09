using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEDIRECMUNI
    {
        public enum Query
        {
            None,
            Listar,
            Buscar,
            Recuperar,
        }

        #region Campos aumentados
        public decimal? NUMRETIRO { get; set; }
        public decimal? NUMJARDIN { get; set; }
        public string TXTASIGNACION { get; set; }
        public string NUMEROCUADRA { get; set; }
        public string CODVIAANT { get; set; }
        public string CODCORRMANZVIAANT { get; set; }
        public string ORDEN { set; get; }
        #endregion
        
        public SIC_LOTEDIRECMUNI() { }

        public SIC_LOTEDIRECMUNI(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Buscar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    CODCORRUNIDDIREMUNI = reader.GetSafeString("CODCORRUNIDDIREMUNI");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    TXTEDIFICACION = reader.GetSafeString("TXTEDIFICACION");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    TXTNUMEDIF = reader.GetSafeString("TXTNUMEDIF");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTASIGNACION = reader.GetSafeString("TXTASIGNACION");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    CODTIPOASIG = reader.GetSafeString("CODTIPOASIG");
                    break;
                case Query.Listar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    CODCORRUNIDDIREMUNI = reader.GetSafeString("CODCORRUNIDDIREMUNI");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    TXTEDIFICACION = reader.GetSafeString("TXTEDIFICACION");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    TXTNUMEDIF = reader.GetSafeString("TXTNUMEDIF");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODCORRUNIDDIREMUNI = reader.GetSafeString("CODCORRUNIDDIREMUNI");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODTIPOEDIF = reader.GetSafeString("CODTIPOEDIF");
                    CODTIPOPUER = reader.GetSafeString("CODTIPOPUER");
                    CODTIPOASIG = reader.GetSafeString("CODTIPOASIG");
                    NUMCUADRA = reader.GetInt32("NUMCUADRA");
                    CODLADO = reader.GetSafeString("CODLADO");
                    TXTNUMEDIF = reader.GetSafeString("TXTNUMEDIF");
                    break;
                default:
                    break;
            }
        }
    }
}
