using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMOBILDETALLE
    {
        //public string CODSECTOR { get; set; }
        //public string CODMANZANA { get; set; }
        //public string CODLOTE { get; set; }
        //public string CORRELURBA { get; set; }
        //public string CODDISTRITO { get; set; }
        //public string CODPROVINCIA { get; set; }
        //public string CODDEPARTAMENTO { get; set; }
        //public string CODCORRELOBJ { get; set; }
        //public string CODUSUARIO { get; set; }
        //public Nullable<DateTime> FECREG { get; set; }
        //public string TXTIPREG { get; set; }
        //public string ESTADO { get; set; }
        //public string CODUSUARIOMODIF { get; set; }
        //public Nullable<DateTime> FECMODIF { get; set; }
        //public string TXTIPMODIF { get; set; }

        public string CODPROVINCIA { get; set; }
        public string CODDEPARTAMENTO { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CORRELURBA { get; set; }
        public string CODOBJETO { get; set; }
        public string CODSUBCLASE { get; set; }
        public string CODCLASE { get; set; }
        public string CODCONFOBJETO { get; set; }
        public string TXTVALOR { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}