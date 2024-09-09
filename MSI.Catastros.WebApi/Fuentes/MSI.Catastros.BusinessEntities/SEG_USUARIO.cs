using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SEG_USUARIO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(10/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODUSUARIO { get; set; }
        public string TXTPASSWORD { get; set; }
        public string TXTEMAIL { get; set; }
        public string CODPERSONA { get; set; }
        public string CODAREA { get; set; }
        public string CODOFICINA { get; set; }
        public Nullable<int> NUMESTADO { get; set; }
        public string CODSISTEMA { get; set; }
        public string CODAREAUSUARIO { get; set; }
        public string TXTPASSWORDNUEVA { get; set; }
    }
}
