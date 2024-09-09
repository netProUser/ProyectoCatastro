using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_INFORME
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(07/08/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODINFORME { get; set; }
        public string CODANOINFO { get; set; }
        public string CODTIPOINFOR { get; set; }
        public string CODCORRINFO { get; set; }
        public string TXTDOCUMENTO { get; set; }
        public string TXTFECHAGENERACION { get; set; }

        public string CODOFICINA { get; set; }
        public string TXTSIGLA { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CTIPODOCUMENTO { get; set; }

        public Nullable<DateTime> FECINSPECCION { get; set; }
        public string TXTTIPOLLENADO { get; set; }
        public string CODCARCAT { get; set; }
        public string CODPERSONA { get; set; }
        public string CODUSUASIS { get; set; }
        public string TXTASUNTO { get; set; }
        public string TXTUNIDAD { get; set; }
        public string TXTCODIGOUNICO { get; set; }
        public string TXTUNIDADDIREC { get; set; }
        public string TXTUNIDADTITULAR { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string CODPEREMISION { get; set; }
        public string CODDOCUMGEN { get; set; }
        public string TXTDESCRIPCIONINFORME { get; set; }
        public string TXTOFICINA { get; set; }
        public string TXTUNIDADES { get; set; }
        public string CODUSUARIO { get; set; }
        public string CODESTADOFINAL { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string NROCALIDADVERIFICACION { get; set; }
        public string TXTTIPODOCUMENTO { get; set; }
        public string TXTPEREMISION { get; set; }
        public string TIPO_VERIFICACION { get; set; }
    }
}
