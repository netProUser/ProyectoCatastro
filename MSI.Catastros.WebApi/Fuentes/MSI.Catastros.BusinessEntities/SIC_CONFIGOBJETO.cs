using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CONFIGOBJETO
    {
        public string CODCONFOBJETO { get; set; }

        public string CODSUBCLASE { get; set; }
        public string CODCLASE { get; set; }
        public string CODOBJETO { get; set; }
                
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }

        public string TXTIPMODIF { get; set; }

        public string TXTNOMBREO { get; set; }
        public string TXTORDENO { get; set; }
        public string TXTIPOCAMPOB { get; set; }
        public string TXTTAMANOB { get; set; }
        public string TXTDESPLEOB { get; set; }

    }
}
