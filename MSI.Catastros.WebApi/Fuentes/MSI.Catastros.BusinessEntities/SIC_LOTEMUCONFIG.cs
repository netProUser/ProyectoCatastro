using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMUCONFIG
    {
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }

        public string CORRELURBA { get; set; }

        public string CODCLASE { get; set; }
        public string CODSUBCLASE { get; set; }
        public string CODOBJETO { get; set; }

        public string CODCORSCLASE { get; set; }

        public string TXTVALOR { get; set; }
        public string CODUSUARIO { get; set; }
        public string FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public string FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
