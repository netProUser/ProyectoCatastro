using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_ZONIFICACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODZONIFICACION { get; set; }
        public string TXTZONIFICACION { get; set; }
        public string TXTABREVIACION { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> CONTROL { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
