using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_CARTACONFI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(13/08/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODCARTA { get; set; }
        public string CODTIPOINFOR { get; set; }
        public string TXTTITULOGENERAL { get; set; }
        public string TXTSIGLAS { get; set; }
        public string CODOOFICINA { get; set; }
        public string TXTANIO { get; set; }
        public string TXTCONFSUBTITULO1 { get; set; }
        public string TXTCONFSUBTITULO2 { get; set; }
        public string TXTCONFSUBTITULO3 { get; set; }
        public string TXTCONFSUBTITULO4 { get; set; }
        public string TXTCONFSUBTITULO5 { get; set; }
        public string TXTCONFSUBTITULO6 { get; set; }
        public string TXTCONFSUBTITULO7 { get; set; }
        public string TXTCONFPARRAFO1 { get; set; }
        public string TXTCONFPARRAFO2 { get; set; }
        public string TXTCONFPARRAFO3 { get; set; }
        public string TXTCONFPARRAFO4 { get; set; }
        public string TXTCONFPARRAFO5 { get; set; }
        public string TXTCONFPARRAFO6 { get; set; }
        public string TXTCONFPARRAFO7 { get; set; }
        public string TXTCONFPARRAFO8 { get; set; }
        public string TXTCONFPARRAFO9 { get; set; }
        public string TXTCONFPARRAFO10 { get; set; }
        public string TXTCONFFIRMA1 { get; set; }
        public string TXTCONFFIRMA2 { get; set; }
        public string TXTCONFFIRMA3 { get; set; }
        public string TXTCONFFIRMA4 { get; set; }
        public string TXTCONFFIRMA5 { get; set; }
        public string TXTCONFPIEPAGINA { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        
    }
}
