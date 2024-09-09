using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_SOLUNIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(28/05/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CODTIPODOC { get; set; }
        public string CORRELUNIDAD { get; set; }
        public Nullable<int> CODUNI { get; set; }
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODEDIFICACION { get; set; }
        public string CODENTRADA { get; set; }
        public string CODPISO { get; set; }
        public string CODUNIDAD { get; set; }
        public string CODCONTRIBUYENTE { get; set; }
        public string ESTADOUNIDAD { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string FLG_TRABAJO { get; set; } //aca esta 
        public string FLG_USUARIO { get; set; }
        public string CODESTADOFINAL { get; set; }
        public string NUMVERSION { get; set; }
        public string TXTREPRESENTANTEL { get; set; }
        public string TXTSOLICITANTE { get; set; }
        public string UBICPRINCIPAL { get; set; }
        public string TXTTELEFONO { get; set; }
        public string TXTUBICACION { get; set; }
    }
}
