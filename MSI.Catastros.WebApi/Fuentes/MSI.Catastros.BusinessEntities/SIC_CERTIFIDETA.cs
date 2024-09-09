using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CERTIFIDETA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe (13/08/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――

        public string CODCERTIFICADO { get; set; }
        public string CODANOCERTI { get; set; }
        public string CODTIPOCERTI { get; set; }
        public string CODCORRELCERT { get; set; }
        public string CODVIA  { get; set; }
        public string TXTNOMVIA { get; set; }
        public string TXTTIPOPUERTA { get; set; }
        public string TXTBLOQTE { get; set; }
        public string TXTNIVEL { get; set; }
        public string TXTINTERIOR { get; set; }
        public string TXTNUMERO { get; set; }
        public string CODINSCRP { get; set; }
        public string TXTNOMVIAANT { get; set; }
        public string CODTIPOPUER { get; set; }
        public string TXTINSCRIPCION { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string FLAGESQ { get; set; }
        public string CODVIAESQ { get; set; }
        public string TXTNOMVIAESQ { get; set; }
        public string TXTTIPOVIA { get; set; }
        public string TXTTIPOVIAANT { get; set; }
        public string TXTTIPOVIAESQ { get; set; }
        public string TXTNOMVIAESQANT { get; set; }
        public string TXTTIPOVIAESQANT { get; set; }
    }
}
