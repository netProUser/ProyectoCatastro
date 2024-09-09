using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADACTIVIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque(18/07/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODUNI { get; set; }
        public Nullable<int> NUMVERSION { get; set; }
        public string CODCORRELACTI { get; set; }
        public string CODUSOESPE { get; set; }
        public string TXTUSOESPE { get; set; }
        public Nullable<decimal> NUMMETROS { get; set; }
        public Nullable<DateTime> FECACTI { get; set; }
        public string CODUSORETIRO { get; set; }
        public string CODOPCIONANUN { get; set; }
        public string CODANUNCIO { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
