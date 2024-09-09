using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLISEGUI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(21/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODCORRSEG { get; set; }
        public string TXTOBSERVACION { get; set; }
        public Nullable<DateTime> FECRECEPCION { get; set; }
        public string CODRESPENVIA { get; set; }
        public string CODRESPRECIBE { get; set; }
        public Nullable<DateTime> FECENVIO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public Nullable<int> NUMFOLIOS { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODTIPOREQ { get; set; }
        public string CODESTATENCION { get; set; }
        public string CODESTATENCIONE { get; set;} 
        public string CODTIPPROC { get; set; }
        public string CODCARCAT { get; set; }
        public string CODCARCATE { get; set; }
        public string CODACCION { get; set; }
        public string CODACTIVIDAD { get; set; }
        public Nullable<DateTime> FECLIMITE { get; set; }
        public Nullable<DateTime> FECPROGAINSPE { get; set; }
        public Nullable<DateTime> FECLIMITEI { get; set; }
        public Nullable<DateTime> FECLIMIACT { get; set; }
        public Nullable<DateTime> FECLIMIANA { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string TXTDES_TIPODOCREPL { get; set; }
        public string TXTDOCIDEREPRESENTANTEL { get; set; }
        public string TXTREPRESENTANTEL { get; set; }
        public string FECINICIO { get; set; }
        public string FECFIN { get; set; }
        public string TXTTELEFONO { get; set; }
        public string TXTUBICACION { get; set; }
        public string CODTIPOLLENA { get; set; }
    }
}
