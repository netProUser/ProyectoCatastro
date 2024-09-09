using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADAUTOLICE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(22/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODUNI { get; set; }
        public Nullable<int> NUMVERSION { get; set; }
        
        public string CODCORRAUTOLICE { get; set; }
        public string CODSOLICITANTE { get; set; }
        public string CODTIPODOCU { get; set; }
        public string TXTNUMERO { get; set; }
        public Nullable<DateTime> FECDOCUMENTO { get; set; }
        public string TXTOBSERVACION { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string TXTBENEFICIARIO { get; set; }
        public string TXTTIPOLICENCIA { get; set; }
        public string TXTNUMLICENCIA { get; set; }
        public string TXTCODUNICO { get; set; }
        public Nullable<DateTime> FECLICENCIA { get; set; }
        public string TXTGIRO { get; set; }
        public string CODCORRLOTEAUTOLICE { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
