using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEEXPEDOCU
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(07/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODCORRLOTEEXPEDOCU { get; set; }
        public string CODSOLICITANTE { get; set; }
        public string CODTIPODOCU { get; set; }
        public string TXTNUMERO { get; set; }
        public Nullable<DateTime> FECDOCUMENTO { get; set; }
        public string TXTOBSERVACION { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string FLGINTEXT { get; set; }
        public string TXTIDTRAMITEDOC { get; set; }
        public bool ESTATICO { get; set; }
        public string TXTCODIGOCATASTRAL { get; set; }
        public string TXTDOCUMENTO { get; set; }
        public string TXTIDTRAMITE { get; set; }
        public string COD_RECURRENTE { get; set; }
        public string HABILITADO { get; set; }
        public string TXTASUNTO { get; set; }
    }
}
