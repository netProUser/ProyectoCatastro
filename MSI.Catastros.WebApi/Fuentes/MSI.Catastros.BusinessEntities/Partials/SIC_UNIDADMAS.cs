using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADMAS
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar
        }
        public string ORDEN { set; get; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }

        public string DIRECCION { get; set; }
        public string CLASIFICACION { get; set; }
        public string TITULARIDAD { get; set; }
        public string OBSERVACION { get; set; }
        public string LINEASCONSTRUCTIVAS { get; set; }
        public string OTRASINSTALACIONES { get; set; }
        public string AREATERRENO { get; set; }
        public SIC_UNIDADMAS() { }

        public SIC_UNIDADMAS(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    TXTTIPOINTEDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");

                    DIRECCION = reader.GetSafeString("DIRECCION");
                    CLASIFICACION = reader.GetSafeString("CLASIFICACION");
                    TITULARIDAD = reader.GetSafeString("TITULARIDAD");
                    OBSERVACION = reader.GetSafeString("OBSERVACION");
                    LINEASCONSTRUCTIVAS = reader.GetSafeString("LINEASCONSTRUCTIVAS");
                    OTRASINSTALACIONES = reader.GetSafeString("OTRASINSTALACIONES");
                    AREATERRENO = reader.GetSafeString("AREATERRENO");

                    /*CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    CODCLASIFICA = reader.GetSafeString("CODCLASIFICA");
                    CODTIPODPTO = reader.GetSafeString("CODTIPODPTO");
                    CODCARREG = reader.GetSafeString("CODCARREG");
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    TXTCODIPREDRENT = reader.GetSafeString("TXTCODIPREDRENT");
                    CODINSCCATA = reader.GetSafeString("CODINSCCATA");
                    NUMAREATERRVERI = reader.GetSafeDecimal("NUMAREATERRVERI");
                    NUMAREATERRTOTA = reader.GetSafeDecimal("NUMAREATERRTOTA");
                    NUMAREATERRCOMU = reader.GetSafeDecimal("NUMAREATERRCOMU");
                    NUMAREACONSDECLTOTA = reader.GetSafeDecimal("NUMAREACONSDECLTOTA");
                    NUMAREAOCUP = reader.GetSafeDecimal("NUMAREAOCUP");
                    NUMPORCBIENCOMUOFIC = reader.GetSafeDecimal("NUMPORCBIENCOMUOFIC");

                    NUMAREATERRDECLA = reader.GetSafeDecimal("NUMAREATERRDECLA");
                    NUMAREATERRSUBVAL = reader.GetSafeDecimal("NUMAREATERRSUBVAL");
                    NUMAREATERRSOBVAL = reader.GetSafeDecimal("NUMAREATERRSOBVAL");
                    NUMAREACONSSUBVAL = reader.GetSafeDecimal("NUMAREACONSSUBVAL");
                    NUMAREACONSSOBVAL = reader.GetSafeDecimal("NUMAREACONSSOBVAL");
                    NUMPORCBIENCOMUCAL = reader.GetSafeDecimal("NUMPORCBIENCOMUCAL");

                    CODESTACONST = reader.GetSafeString("CODESTACONST");
                    TXTDENOMINACION = reader.GetSafeString("TXTDENOMINACION");
                    CODFUENINSCCATA = reader.GetSafeString("CODFUENINSCCATA");
                    TXTTRAMITEDOCU = reader.GetSafeString("TXTTRAMITEDOCU");
                    TXTSOLICITUD = reader.GetSafeString("TXTSOLICITUD");
                    TXTNOMDOCU = reader.GetSafeString("TXTNOMDOCU");
                    TXTNOMDOCUINT = reader.GetSafeString("TXTNOMDOCUINT");
                    NUMPORESTACONT = reader.GetSafeDecimal("NUMPORESTACONT");*/
                    break;
                default:
                    break;
            }
        }
    }
}
