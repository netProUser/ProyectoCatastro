using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MANZAVIAVALOR
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(16/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODVIA { get; set; }
        public Nullable<int> NUMCUADRA { get; set; }
        public string CODLADO { get; set; }
        public string CODCORRMANZVIA { get; set; }
        public string CODUSUARIO { get; set; }
        public string FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public string FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string CODANOVAL { get; set; }
        public Nullable<decimal> NUMVALOR { get; set; }
    }
}
