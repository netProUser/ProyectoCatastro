using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEDIRECMUNI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(07/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODVIA { get; set; }
        public string CODCORRMANZVIA { get; set; }
        public string CODCORRUNIDDIREMUNI { get; set; }
        public string TXTNUMERO { get; set; }
        public string TXTLETRA { get; set; }
        public string CODTIPOEDIF { get; set; }
        public string CODTIPOPUER { get; set; }
        public string CODTIPOASIG { get; set; }
        public Nullable<int> NUMCUADRA { get; set; }
        public string CODLADO { get; set; }
        public string TXTNUMEDIF { get; set; }
        public bool ESTATICO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
        public string TXTVIA { get; set; }
        public string TXTPARIDAD { get; set; }
        public string TXTEDIFICACION { get; set; }
        public string TXTTIPODEVIA { get; set; }
        public string TXTTIPOPUERTA { get; set; }
        

    }
}
