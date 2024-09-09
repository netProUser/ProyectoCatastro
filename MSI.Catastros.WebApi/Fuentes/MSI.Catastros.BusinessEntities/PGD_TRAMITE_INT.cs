using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class PGD_TRAMITE_INT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(05/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> VTIPO { get; set; }
        public string VFECHA { get; set; }
        public string VTIPO_DOCUMENTO { get; set; }
        public string VUSUARIO { get; set; }
        public string VID { get; set; }
        public string VNRODOC { get; set; }
        public string VOBSERVACION { get; set; }
        public string VCODIGO_CONTRIBUYENTE { get; set; }
        public string VUSUARIO_AREA { get; set; }
        public string VCONTRIBUYENTE { get; set; }
        public string VBODY { get; set; }
        public Nullable<int> VPAGINAS { get; set; }
        public Nullable<int> VREQRPTA { get; set; }
        public DateTime? VFECLIMRPTA { get; set; }
        public string VCOD_ACTIVIDAD { get; set; }
        public Nullable<int> VNUMFOLEXP { get; set; }
    }
}
