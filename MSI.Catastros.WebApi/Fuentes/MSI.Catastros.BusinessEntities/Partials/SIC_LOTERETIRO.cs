using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTERETIRO
    {
        public enum Query
        {
            None,
            Listar,
            Buscar,
            Recuperar,
        }

        #region Campos aumentados
        public string TXTVIA { get; set; }
        public int? NUMCUADRA { get; set; }
        public decimal? NUMRETIRO { get; set; }
        public decimal? NUMJARDIN { get; set; }
        public string TXTPARIDAD { get; set; }

        public string FLGOCUPRETI { get; set; }
        public string FLGOCUPJARD { get; set; }
        public string CODDESCRETI { get; set; }
        public string CODDESCJARD { get; set; }
        #endregion
        
        public SIC_LOTERETIRO() { }

        public SIC_LOTERETIRO(IDataReader reader, Query query = Query.None)
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
                    CODCORRLOTERETI = reader.GetSafeString("CODCORRLOTERETI");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    NUMRETIRO = reader.GetSafeDecimal("NUMRETIRO");
                    NUMJARDIN = reader.GetSafeDecimal("NUMJARDIN");
                    TXTPARIDAD = reader.GetSafeString("TXTPARIDAD");
                    NUMBERMA = reader.GetSafeDecimal("NUMBERMA");
                    NUMJARDAISL = reader.GetSafeDecimal("NUMJARDAISL");
                    NUMPISTA = reader.GetSafeDecimal("NUMPISTA");
                    NUMRETIMUNI = reader.GetSafeDecimal("NUMRETIMUNI");
                    NUMVEREDA = reader.GetSafeDecimal("NUMVEREDA");
                    FLGOCUPRETI = reader.GetSafeString("FLGOCUPRETI");
                    FLGOCUPJARD = reader.GetSafeString("FLGOCUPJARD");
                    CODDESCRETI = reader.GetSafeString("CODDESCRETI");
                    CODDESCJARD = reader.GetSafeString("CODDESCJARD");
                    break;
                case Query.Listar:
                    /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");*/
                    break;
                case Query.Recuperar:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    CODCORRMANZVIA = reader.GetSafeString("CODCORRMANZVIA");
                    CODCORRLOTERETI = reader.GetSafeString("CODCORRLOTERETI");
                    NUMRETIMUNI = reader.GetSafeDecimal("NUMRETIMUNI");
                    NUMJARDAISL = reader.GetSafeDecimal("NUMJARDAISL");
                    NUMVEREDA = reader.GetSafeDecimal("NUMVEREDA");
                    NUMBERMA = reader.GetSafeDecimal("NUMBERMA");
                    NUMPISTA = reader.GetSafeDecimal("NUMPISTA");
                    NUMANCHVIA = reader.GetSafeDecimal("NUMANCHVIA");
                    FLGOCUPRETI = reader.GetSafeString("FLGOCUPRETI");
                    FLGOCUPJARD = reader.GetSafeString("FLGOCUPJARD");
                    CODDESCRETI = reader.GetSafeString("CODDESCRETI");
                    CODDESCJARD = reader.GetSafeString("CODDESCJARD");
                    NUMCUADRA = reader.GetSafeInt32("NUMCUADRA");
                    break;
                default:
                    break;
            }
        }
    }
}
