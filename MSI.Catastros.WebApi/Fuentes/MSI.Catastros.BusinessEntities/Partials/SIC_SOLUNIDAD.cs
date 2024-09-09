using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLUNIDAD
    {
        public enum Query
        {
            None,
            Buscar,
            BuscarHistorico,
            BuscarEstatico,
            BuscarLote,
            BuscarDirec,
            BuscarCerti,
            BuscarReferen,//BUSCAR REFERENCIA
            BuscarTitulares,
            BuscarSol,
            BuscarUnico,
            Recuperar,
            Listar,
            BuscarConsulta
        }

        #region Campos aumentados
        public string TXTAPEPAT { get; set; }
        public string TXTAPEMAT { get; set; }
        public string TXTNOMBRE { get; set; }
        public string TXTDIRECCION { get; set; }
        public string TXTTITULARES { get; set; }
        public string FLGLOTEESQU { get; set; }
        public string TXTVIA { get; set; }
        public string TXTVIAANTE { get; set; }
        public string TXTTIPODEVIA { get; set; }
        public string TXTTIPOPUERTA { get; set; }
        public string TXTNUMEROPUERTA { get; set; }
        public string TXTLETRAPUERTA { get; set; }
        public string TXTNUMERO { get; set; }
        public string TXTLETRA { get; set; }
        public string TXTIPOINTERIOR { get; set; }
        public string CODVIA { get; set; }
        public string TXTNIVEL { get; set; }
        public string CODTIPOINTE { get; set; }

        public string CODCERTIFICADO { get; set; }
        public string CODANOCERTI { get; set; }
        public string CODTIPOCERTI { get; set; }
        public string CODCORRELCERT { get; set; }
        public string CODTIPOVIA { get; set; }
        public string TXTCUC { get; set; }
        public string TXTDESCRIPCION { get; set; }
        public string TXTTIPOVIAANT { get; set; }
        public string TXTTIPOVIA { get; set; }
        public string TXTTIPOPROPIETARIO { get; set; }

        public string TXTESTADOHAB { get; set; }
        public string TXTESTADOTEMP { get; set; }
        public string TXTESTADOTOT { get; set; }
        public string CODREFANT { get; set; }
        public bool ESTATICO { get; set; }
        public string CODTIPOLLENA { get; set; }
        public Decimal NUMAREATERRVERI { get; set; }
        public Decimal NUMAREATERRCOMU { get; set; }
        public Decimal NUMAREATERRTOTA { get; set; }
        public decimal NUMPORCBIENCOMUOFIC { get; set; }
       public string TXTINSCCATA { get; set; }
        public string CODUSOESPE { get; set; }
        public string TXTTIPOINTERIOR { get; set; }




        public int? NVERSION { get; set; }

        #endregion
        public SIC_SOLUNIDAD() { }

        public SIC_SOLUNIDAD(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.BuscarCerti:
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTIPOINTERIOR = reader.GetSafeString("TXTIPOINTERIOR");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    CODCORRELCERT = reader.GetSafeString("CODCORRELCERT");
                    TXTNIVEL = reader.GetSafeString("TXTNIVEL");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    break;
                case Query.BuscarTitulares:
                    TXTTITULARES = reader.GetSafeString("TXTTITULARES");
                    TXTTIPOPROPIETARIO = reader.GetSafeString("TXTTIPOPROPIETARIO");
                    break;
                case Query.BuscarDirec:
                    TXTDIRECCION = reader.GetSafeString("TXTDIRECCION");
                    FLGLOTEESQU = reader.GetSafeString("FLGLOTEESQU");
                    TXTVIA = reader.GetSafeString("TXTVIA");
                    //TXTTIPOINTERIOR = reader.GetSafeString("TXTTIPOINTERIOR");
                    TXTTIPODEVIA = reader.GetSafeString("TXTTIPODEVIA");
                    TXTVIAANTE = reader.GetSafeString("TXTVIAANTE");
                    CODVIA = reader.GetSafeString("CODVIA");
                    TXTTIPOPUERTA = reader.GetSafeString("TXTTIPOPUERTA");
                    TXTNUMEROPUERTA = reader.GetSafeString("TXTNUMEROPUERTA");
                    TXTLETRAPUERTA = reader.GetSafeString("TXTLETRAPUERTA");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    TXTLETRA = reader.GetSafeString("TXTLETRA");
                    CODTIPOVIA = reader.GetSafeString("CODTIPOVIA");
                    TXTTIPOVIAANT = reader.GetSafeString("TXTTIPOVIAANT");
                    TXTTIPOVIA = reader.GetSafeString("TXTTIPOVIA");
                    break;
                case Query.BuscarSol:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CTIPODOCUMENTO = reader.GetSafeString("CTIPODOCUMENTO");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
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
                    TXTTITULARES = reader.GetSafeString("TXTTITULARES");
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    TXTDIRECCION = reader.GetSafeString("TXTDIRECCION");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    FLG_TRABAJO = reader.GetSafeString("FLG_TRABAJO");
                    break;
                case Query.Buscar:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
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
                    TXTAPEPAT = reader.GetSafeString("TXTAPEPAT");
                    TXTAPEMAT = reader.GetSafeString("TXTAPEMAT");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    FLG_TRABAJO = reader.GetSafeString("FLG_TRABAJO");
                   
                    //CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    break;
                case Query.BuscarConsulta:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
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
                    TXTAPEPAT = reader.GetSafeString("TXTAPEPAT");
                    TXTAPEMAT = reader.GetSafeString("TXTAPEMAT");
                    TXTNOMBRE = reader.GetSafeString("TXTNOMBRE");
                    CODCONTRIBUYENTE = reader.GetSafeString("CODCONTRIBUYENTE");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    FLG_TRABAJO = reader.GetSafeString("FLG_TRABAJO");
                    FLG_USUARIO = reader.GetSafeString("FLG_USUARIO");
                    //CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    break;
                case Query.BuscarHistorico:
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
                    NUMVERSION = reader.GetSafeString("NUMVERSION");
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    NUMAREATERRVERI = Convert.ToDecimal(reader.GetSafeString("NUMAREATERRVERI"));
                    NUMAREATERRCOMU = Convert.ToDecimal(reader.GetSafeString("NUMAREATERRCOMU"));
                    NUMAREATERRTOTA = Convert.ToDecimal(reader.GetSafeString("NUMAREATERRTOTA"));
                    NUMPORCBIENCOMUOFIC = Convert.ToDecimal(reader.GetSafeString("NUMPORCBIENCOMUOFIC"));
                    TXTINSCCATA = reader.GetSafeString("TXTINSCCATA");
                    TXTDESCRIPCION = reader.GetSafeString("TXTDESCRIPCION");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    UBICPRINCIPAL = reader.GetSafeString("UBICPRINCIPAL");
                    //CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    break;
                case Query.BuscarEstatico:
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
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    TXTINSCCATA = reader.GetSafeString("TXTINSCCATA");
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    UBICPRINCIPAL = reader.GetSafeString("UBICPRINCIPAL");
                    TXTNUMERO = reader.GetSafeString("TXTNUMERO");
                    CODUSOESPE = reader.GetSafeString("CODUSOESPE");
                    CODTIPOINTE = reader.GetSafeString("CODTIPOINTE");
                    NVERSION = reader.GetSafeInt32("NVERSION");
                    if (reader.IsDBNull("FECMODIF")) { FECMODIF = null; }
                    else { FECMODIF = reader.GetDateTime("FECMODIF"); }
                    CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    break;
                case Query.BuscarLote:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    NUMVERSION = reader.GetSafeString("NUMVERSION");
                    
                    //CODTIPOLLENA = reader.GetSafeString("CODTIPOLLENA");
                    break;
                case Query.BuscarReferen:             
                    ESTADOUNIDAD = reader.GetSafeString("ESTADOUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    TXTDIRECCION = reader.GetSafeString("TXTDIRECCION");
                    break;
                case Query.BuscarUnico:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    CODMANZANA = reader.GetSafeString("CODMANZANA");
                    CODLOTE = reader.GetSafeString("CODLOTE");
                    CODEDIFICACION = reader.GetSafeString("CODEDIFICACION");
                    CODESTADOFINAL = reader.GetSafeString("CODESTADOFINAL");
                    CODENTRADA = reader.GetSafeString("CODENTRADA");
                    CODPISO = reader.GetSafeString("CODPISO");
                    CODUNIDAD = reader.GetSafeString("CODUNIDAD");
                    CODREFANT = reader.GetSafeString("CODREFANT");
                    TXTESTADOHAB = reader.GetSafeString("TXTESTADOHAB");
                    TXTESTADOTEMP = reader.GetSafeString("TXTESTADOTEMP");
                    TXTESTADOTOT = reader.GetSafeString("TXTESTADOTOT");
                    FLG_TRABAJO = reader.GetSafeString("FLG_TRABAJO");
                    FLG_USUARIO = reader.GetSafeString("FLG_USUARIO");
                    break;
                case Query.Recuperar:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
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
                    break;
                case Query.Listar:
                    CODNUMESOLI = reader.GetSafeString("CODNUMESOLI");
                    CODANOSOLI = reader.GetSafeString("CODANOSOLI");
                    CODTIPOSOLI = reader.GetSafeString("CODTIPOSOLI");
                    CORRELUNIDAD = reader.GetSafeString("CORRELUNIDAD");
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
                    TXTCUC = reader.GetSafeString("TXTCUC");
                    break;
                default:
                    break;
            }
        }

    }
}
