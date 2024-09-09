using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SEG_OPCION
    {
        public string PK_eIdOpcion { get; set; }
        public int FK_eIdAplicacion { get; set; }
        public string uNombreOpcion { get; set; }
        public string uUrl { get; set; }
        public string uTituloOpcion { get; set; }
        public string uDireccionOpcion { get; set; }
        public string eIdGrupoOpcion { get; set; }
        public int eNroOrden { get; set; }
        public bool cEsVisible { get; set; }
        public string Imagen { get; set; }
    }
}
