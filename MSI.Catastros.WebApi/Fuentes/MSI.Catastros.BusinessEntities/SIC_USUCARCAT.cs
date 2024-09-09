using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_USUCARCAT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(28/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODUSUASIS { get; set; }
        public string CODPERSONA { get; set; }
        public string CODCARCAT { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string ESTADO { get; set; }
        public string TXTIPREG { get; set; }
        public Nullable<DateTime> FECINI { get; set; }
        public Nullable<DateTime> FECFIN { get; set; }
    }
}
