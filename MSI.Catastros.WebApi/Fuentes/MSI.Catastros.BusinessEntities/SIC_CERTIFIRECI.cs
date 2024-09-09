using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CERTIFIRECI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――

        public string CODCERTIFICADO { get; set; }
        public string CODANOCERTI { get; set; }
        public string CODTIPOCERTI { get; set; }
        public string CODCORRELCERE { get; set; }
        public string TXTRECIBO  { get; set; }
        public Nullable<DateTime> FECRECIBO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
