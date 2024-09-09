using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CARTA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(13/08/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODCARTA { get; set; }
        public string CODTIPOINFOR { get; set; }
        public string CODCORRCARTA { get; set; }
        public string CODANO { get; set; }
        public string CODOOFICINA { get; set; }
        public string TXTANIO { get; set; }
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string TXTSUBTITULO1 { get; set; }
        public string TXTSUBTITULO2 { get; set; }
        public string TXTSUBTITULO3 { get; set; }
        public string TXTSUBTITULO4 { get; set; }
        public string TXTSUBTITULO5 { get; set; }
        public string TXTSUBTITULO6 { get; set; }
        public string TXTSUBTITULO7 { get; set; }
        public string TXTPARRAFO1 { get; set; }
        public string TXTPARRAFO2 { get; set; }
        public string TXTPARRAFO3 { get; set; }
        public string TXTPARRAFO4 { get; set; }
        public string TXTPARRAFO5 { get; set; }
        public string TXTPARRAFO6 { get; set; }
        public string TXTPARRAFO7 { get; set; }
        public string TXTPARRAFO8 { get; set; }
        public string TXTPARRAFO9 { get; set; }
        public string TXTPARRAFO10 { get; set; }
        public string TXTFIRMA1 { get; set; }
        public string TXTFIRMA2 { get; set; }
        public string TXTFIRMA3 { get; set; }
        public string TXTFIRMA4 { get; set; }
        public string TXTFIRMA5 { get; set; }
        public string TXTPIEPAGINA { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        
    }
}
