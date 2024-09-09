using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_HABILITURBA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(18/04/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODHABURBA { get; set; }
        public string CODTIPOHABURB { get; set; }
        public string TXTURBANIZACION { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTNOMDOCU { get; set; }
        public string TXTNOMDOCUINT { get; set; }
        public string TXTDIFERENCIADORHABURBA { get; set; }
        public Nullable<DateTime> FECAPROBACION { get; set; }
        public string TXTNUMDOCPROB { get; set; }
        public Nullable<DateTime> FECACTDOCU { get; set; }
        
    }
}
