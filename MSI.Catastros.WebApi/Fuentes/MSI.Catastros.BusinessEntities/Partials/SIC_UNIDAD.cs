using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDAD
    {
        public enum Query
        {
            None,
            Listar,
            ListarBC,
            ListarEstado,
            Recuperar,
            RecuperarHistorico,
            BComun,
            RecuperarBC,
            RecuperarBCPorc,
            RecuperarAC,
            ListarEdif,
            ListarUnidad,
            Solicitud,
            RecuperarFoto
        }

        #region Campos aumentados
        public string TXTRAZONSOCIAL { get; set; }
        public string TXTUBICACION { get; set; }
        public string CODCONTRIBUYENTE { get; set; }
        public Nullable<int> PAGINANUMERO { set; get; }
        public Nullable<int> PAGINAREGISTROS { set; get; }
        public string TXTNOMDOCU { get; set; }
        public string TXTNOMDOCUINT { get; set; }

        public string CODANOSOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        //public string CODUNI { get; set; }
        public string CORRELUNIDAD { get; set; }
        public string TXTINSCCATA { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string CODREFANT { get; set; }
        public string NVERSION { get; set; }
        public string BCOMUN { get; set; }
        public string FLGTEMP { get; set; }
        public DateTime FECFINSOLICITUD { get; set; }
        public bool ESTATICO { get; set; }
        public string CODLOTECATASTRAL { get; set; }
        public string CODEDIFICACIONCATASTRAL { get; set; }
        public string TXTRUTAFOTO { get; set; }
        public Nullable<int> CODBIENCOMUN { get; set; }

        #endregion
        public SIC_UNIDAD() { }

        public SIC_UNIDAD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Solicitud:
                    TXTNOMDOCU = reader.GetSafeString("TXTNOMDOCU");
                    break;
                case Query.RecuperarAC:
                    AREATCOMUN = reader.GetSafeDecimal("AREATCOMUN");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    break;
                case Query.BComun:
                    BCOMUN = reader.GetSafeString("BCOMUN");
                    break;
                case Query.ListarBC:
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
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODBIENCOMUN = reader.GetSafeInt32("CODBIENCOMUN");
                    break;
                case Query.Listar:
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
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    break;
                case Query.ListarEstado:
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
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    TXTUBICACION = reader.GetSafeString("TXTUBICACION");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    NVERSION = reader.GetSafeString("NVERSION");
                    CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    ESTADO = reader.GetSafeString("ESTADO");
                    break;
                case Query.ListarEdif:
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    break;
                case Query.ListarUnidad:
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
                    break;
                case Query.RecuperarBCPorc:
                    NUMPORCBIENCOMUCAL = reader.GetSafeDecimal("NUMPORCBIENCOMUCAL");
                    break;
                case Query.RecuperarBC:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    NUMPORCBIENCOMUCAL = reader.GetSafeDecimal("NUMPORCBIENCOMUCAL");
                    break;
                case Query.Recuperar:
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
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    CODCLASIFICA = reader.GetSafeString("CODCLASIFICA"); 
                     CODTIPODPTO = reader.GetSafeString("CODTIPODPTO");
                    CODCARREG = reader.GetSafeString("CODCARREG");
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    TXTCODIPREDRENT = reader.GetSafeString("TXTCODIPREDRENT");
                    CODINSCCATA = reader.GetSafeString("CODINSCCATA");
                    TXTINSCCATA = reader.GetSafeString("TXTINSCCATA");
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
                    NUMPORESTACONT = reader.GetSafeDecimal("NUMPORESTACONT");
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    FLGINDEP = reader.GetSafeString("FLGINDEP");
                    FECINSPEC = reader.GetSafeDateTime("FECINSPEC");
                    FECACT = reader.GetSafeDateTime("FECACT");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    FECMODIF = reader.GetSafeDateTime("FECMODIF");
                    NVERSION = reader.GetSafeString("NVERSION");
                    NROEDIFICACIONES = reader.GetSafeInt16("NROEDIFICACIONES");
                    ESTADO_UNIDAD = reader.IsColumnExists("ESTADO_UNIDAD") ? reader.GetSafeString("ESTADO_UNIDAD") : "";
                    break;
                case Query.RecuperarHistorico:
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
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    CODCLASIFICA = reader.GetSafeString("CODCLASIFICA");
                    CODTIPODPTO = reader.GetSafeString("CODTIPODPTO");
                    CODCARREG = reader.GetSafeString("CODCARREG");
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    TXTCODIPREDRENT = reader.GetSafeString("TXTCODIPREDRENT");
                    CODINSCCATA = reader.GetSafeString("CODINSCCATA");
                    TXTINSCCATA = reader.GetSafeString("TXTINSCCATA");
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
                    NUMPORESTACONT = reader.GetSafeDecimal("NUMPORESTACONT");
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    FLGINDEP = reader.GetSafeString("FLGINDEP");
                    FECINSPEC = reader.GetSafeDateTime("FECINSPEC");
                    FECACT = reader.GetSafeDateTime("FECACT");
                    FECREG = reader.GetSafeDateTime("FECREG");
                    FECMODIF = reader.GetSafeDateTime("FECMODIF");
                    NVERSION = reader.GetSafeString("NVERSION");
                    NUMAREACONSTRUIDA = reader.GetSafeDecimal("NUMAREACONSTRUIDA");

                    break;
                case Query.RecuperarFoto:
                    TXTRUTAFOTO = reader.GetSafeString("TXTRUTAFOTO");
                    break;
                default:
                    break;
            }
        }



        public decimal? AREATCOMUN { get; set; }
    }
}
