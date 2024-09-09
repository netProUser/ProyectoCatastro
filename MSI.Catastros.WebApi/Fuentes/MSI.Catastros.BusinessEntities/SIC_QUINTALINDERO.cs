using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_QUINTALINDERO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA(24/08/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――

        public Nullable<int> CODUNI { get; set; }
        public Nullable<int> NUMVERSION { get; set; }
        public string CODLADO { get; set; }
        public string CORRELLINDE { get; set; }
        public Nullable<decimal> NUMMEDICAMP { get; set; }
        public Nullable<decimal> NUMMEDIOFIC { get; set; }
        public string CODTIPOCOLI { get; set; }
        public string CODSECTCOLI { get; set; }
        public string CODMANZCOLI { get; set; }
        public string CODLOTECOLI { get; set; }
        public string CODEDIFICCOLI { get; set; }
        public string CODENTRACOLI { get; set; }
        public string CODPISOCOL { get; set; }
        public string CODUNIDADCOLI { get; set; }
        public Nullable<int> CODUNICOLI { get; set; }
        public string CODVIA { get; set; }
        public string CODCORMANZVIA { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTCOLINDANTE { get; set; }
        public string NOMBRELADO { get; set; }
        public string TXTPARIDAD { get; set; }
        public string CODUNILINDERO { get; set; }
        public string TXTTIPOCOLINDANTE { get; set; }
        public string CORRELATIVO { get; set; }
    }
}
