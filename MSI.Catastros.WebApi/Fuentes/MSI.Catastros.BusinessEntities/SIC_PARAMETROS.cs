using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_PARAMETROS
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(25/04/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> CODGRUPOPARAMETRO { get; set; }
        public string CODPARAMETRO { get; set; }
        public string CODTIPOREGISTRO { get; set; }
        public string TXTDESCRIPCION { get; set; }
        public string TXTABREVIATURA { get; set; }
        public string ESTADO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string CODUSUARIOREG { get; set; }
    }
}
