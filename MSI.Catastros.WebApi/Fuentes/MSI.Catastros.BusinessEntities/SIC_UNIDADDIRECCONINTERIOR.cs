using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADDIRECCONINTERIOR
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(22/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODUNI { get; set; }
        public string CODCORRUNIDDIREINTE { get; set; }
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODVIA { get; set; }
        public string CODCORRMANZVIA { get; set; }
        public string CODCORRUNIDDIREMUNI { get; set; }
        public string CODTIPOINTE { get; set; }
        public string CODESTAINTE { get; set; }
        public string CODINSCATINT { get; set; }
        public string TXTNUMERO { get; set; }
        public string TXTLETRA { get; set; }
        public string CODTIPOASIG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public Nullable<decimal> NUMAREATEMPI { get; set; }
        public int FLAGINDIREC { get; set; }
        public string  NVERSION { get; set; }
    }
}
