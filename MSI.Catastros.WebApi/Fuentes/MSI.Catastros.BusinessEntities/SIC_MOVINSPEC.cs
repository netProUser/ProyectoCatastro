using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MOVINSPEC
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(28/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string CODNROINSPEC { get; set; }
        public string CODCORRELINSP { get; set; }
        public string CODUSUASIS { get; set; }
        public string CODCARCAT { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string FLAGRESPONSABLE { get; set; }
    }
}
