using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public class SIC_RETORNO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(21/04/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODIGO { get; set; }
        public string NUMERO { get; set; }
        public Nullable<bool> Ok { get; set; }
        public Nullable<int> NoMENSAJE { get; set; }
        public string MENSAJE { get; set; }
        public string CODLOTECATASTRAL { get; set; }
    }
}
