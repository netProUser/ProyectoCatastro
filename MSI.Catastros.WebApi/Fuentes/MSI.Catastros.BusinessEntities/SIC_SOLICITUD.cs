using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLICITUD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(17/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODAREASOLI { get; set; }
        public string CODTIPOLLENA { get; set; }
        public string CODTIPODOC { get; set; }
        public string TXTTIPODOC { get; set; }
        public Nullable<DateTime> FECINGRESO { get; set; }
        public Nullable<DateTime> FECSOLICITUD { get; set; }
        public string TXTASUNTO { get; set; }
        public Nullable<int> NUMCALVER { get; set; }
        public string TXTANOCALVER { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public Nullable<DateTime> FECFINSOLICITUD { get; set; }
        public string CODESTADOFINAL { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public Nullable<int> NUMFOLSOL { get; set; }
        public Nullable<DateTime> FECRECEP { get; set; }
        public string ID_REF { get; set; }

        public string CODIGO_CONTRIBUYENTE { get; set; }
        public string COD_RECURRENTE { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string TXTDESC_TIPODOCREC { get; set; }
        public string TXTDOCIDRECURRENTE { get; set; }
        public string TXTREPRESENTANTEL { get; set; }
        public string TXTCODTIPODOCUMENTOREC { get; set; }
        public string TXTDES_TIPODOCREPL { get; set; }
        public string TXTCODTIPODOCREPLEGAL { get; set; }
        public string TXTDOCIDEREPRESENTANTEL { get; set; }
        public string FECINICIO { get; set; }
        public string FECFIN { get; set; }
        public string CORMAXSOLI { get; set; }
        public string USUARIORECEPCION { get; set; }
        public string USUARIOENVIA { get; set; }
        public Nullable<int> NRO { get; set; }
        public string TXTNOMBRERECEPCION { get; set; }
        public string TXTTIPOSOLI { get; set; }
        public string PRIMERAASIGNACION { get; set; }
        public string TXTUBICACION { get; set; }
        public string TXTTELEFONO { get; set; }
        public string TXTUNIDADCATASTRAL { get; set; }
    }
}
