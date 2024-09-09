using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTE
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(07/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string TXTDENOMINACION { get; set; }
        public string TXTCUC { get; set; }
        public string FLGMONUHIST { get; set; }
        public string FLGLOTEESQU { get; set; }
        public string CODTIPOLOTE { get; set; }
        public string TXTLOTEURBA { get; set; }
        public string TXTSUBLOTEURBA { get; set; }
        public Nullable<decimal> NUMAREATERRCAMP { get; set; }
        public Nullable<decimal> NUMAREATERROFIC { get; set; }
        public Nullable<decimal> NUMAREACONSTOTAL { get; set; }
        public string CODFUENTE { get; set; }
        public string TXTSECTVECI { get; set; }
        public string TXTSECTPLAN { get; set; }
        public string TXTSECTSEGU { get; set; }
        public string TXTSUBSECTVECI { get; set; }
        public string TXTSUBSECTPLAN { get; set; }
        public string TXTSUBSECTSEGU { get; set; }

        public string TXTSECTCATAS { get; set; }
        public string TXTSUBSECTCATAS { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTRESONUM { get; set; }
        public Nullable<DateTime> FECRESOLUC { get; set; }
        public bool ESTATICO { get; set; }
        public string CODLOTECATASTRAL { get; set; }
    }
}
