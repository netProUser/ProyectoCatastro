using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class DDU_LICENCIA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(16/07/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string SOLICITANTE { get; set; }
        public string BENEFICIARIO { get; set; }
        public string TIPO_LICENCIA { get; set; }
        public string NUMERO_LICENCIA { get; set; }
        public string GIROS { get; set; }
        public DateTime? FECHA_LICENCIA { get; set; }
        public string CODIGO_CATASTRAL { get; set; }
        public string OBSERVACIONES { get; set; }
        public string PDF { get; set; }
        public string CODIGO_UNICO { get; set; }
        public string ESTADO_LICENCIA { get; set; }
    }
}
