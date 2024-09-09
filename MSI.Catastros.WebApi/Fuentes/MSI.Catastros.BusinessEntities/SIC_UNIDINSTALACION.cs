using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDINSTALACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(22/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODUNI { get; set; }
        public string CODCORRUNIDINST { get; set; }
        public string CODINSTALACION { get; set; }
        public Nullable<int> NUMORDEN { get; set; }
        public string TXTMES { get; set; }
        public string TXTANO { get; set; }
        public string CODESTACONSE { get; set; }
        public string CODUNIDAD { get; set; }
        public Nullable<decimal> NUMCAPACIDAD { get; set; }
        public Nullable<int> NUMCANTIDAD { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string NVERSION { get; set; }

        public Nullable<int> NUMVERSION { get; set; }
    }
}
