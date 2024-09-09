using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(28/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODUNI { get; set; }
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
        public string CODUSOESPE { get; set; }
        public string CODCLASIFICA { get; set; }
        public string CODTIPODPTO { get; set; }
        public string TXTCUC { get; set; }
        public string TXTCODIPREDRENT { get; set; }
        public string CODINSCCATA { get; set; }
        public Nullable<DateTime> FECINSPEC	 { get; set; }
        public Nullable<DateTime> FECACT { get; set; }
       
        
        public Nullable<decimal> NUMAREATERRVERI { get; set; }
        public Nullable<decimal> NUMAREATERRTOTA { get; set; }
        public Nullable<decimal> NUMAREATERRCOMU { get; set; }
        public Nullable<decimal> NUMAREACONSDECLTOTA { get; set; }
        public Nullable<decimal> NUMAREAOCUP { get; set; }
        public Nullable<decimal> NUMPORCBIENCOMUOFIC { get; set; }
        public Nullable<decimal> NUMAREATERRDECLA { get; set; }
        public Nullable<decimal> NUMAREATERRSUBVAL { get; set; }
        public Nullable<decimal> NUMAREATERRSOBVAL { get; set; }
        public Nullable<decimal> NUMAREACONSSUBVAL { get; set; }
        public Nullable<decimal> NUMAREACONSSOBVAL { get; set; }
        public Nullable <decimal> NUMAREACONSTRUIDA { get; set; }
        public Nullable<decimal> NUMPORCBIENCOMUCAL { get; set; }

        
        public string CODTIPOLLENA { get; set; }
        public string CODESTACONST { get; set; }
        public string TXTDENOMINACION { get; set; }
        public string CODFUENINSCCATA { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string TXTTRAMITEDOCU { get; set; }
        public string TXTSOLICITUD { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public Nullable<decimal> NUMPORESTACONT { get; set; }
        public string CODCARREG { get; set; }
        public string ESTADOUNIDAD { get; set; }

        public string FLGINDEP { get; set; }
        

        public string ORDEN { set; get; }
        public Nullable<int> TOTALPAGINAS { set; get; }
        public Nullable<int> TOTALREGISTROS { set; get; }
        public Nullable<int> NROEDIFICACIONES { get; set; }
        public string ESTADO_UNIDAD { get; set; }

    }
}
