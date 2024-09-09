using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_PROGINSPEC
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(28/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODNROINSPEC { get; set; }
        public Nullable<DateTime> FECINSPE { get; set; }
        public string TXTHORAINSP { get; set; }
        public Nullable<DateTime> FECCITACION { get; set; }
        public Nullable<DateTime> FECAVIINSPEC { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTOBSERVACION { get; set; }
        public string CODESTATENCION { get; set; }
        public Nullable<DateTime> FECREPROG { get; set; }
        public string CTIPODOCUMENTO { get; set; }

        public string TXTFTXTFECLIMITE { get; set; }

        public string TXTFECLIMITEPROGINSP { get; set; }
        public string TXTFECLIMITEINSPECCION { get; set; }


        public string TXTUBICACION { get; set; }
        public string TXTTITULAR { get; set; }
        public string TXTREPRESENTANTE { get; set; }
        public string CODTIPOLLENA { get; set; }
        public string TXTNUMSOLI  { get; set; }
        public string TXTPROGRAMADO { get; set; }
        public string TXTFECCITACION { get; set; }
        public string NROINSPECCION { get; set; }
        public string TXTTELEFONO { get; set; }
        public string TXTFECHAINSPECCIONINICIO { get; set; }
        public string TXTFECHAINSPECCIONFIN{ get; set; }
        public string CODTIPOBUSQUEDA { get; set; }

    }
}
