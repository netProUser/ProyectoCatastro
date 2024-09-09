﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTEMOBILURBA
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
        public string CODCLASE { get; set; }
        public string CODSUBCLASE { get; set; }
        public string CODOBJETO { get; set; }
        public string CORRELURBA { get; set; }

        public string CODVIA { get; set; }
        public string CODCORRVIADETA { get; set; }
        public string TXTUBICESPECIF { get; set; }
        public string NUMCUADRA { get; set; }
                
        public Nullable<decimal> NUMLATITUD { get; set; }
        public Nullable<decimal> NUMLONGITUD { get; set; }
        public string TXTCAMPANA { get; set; }
        public Nullable<DateTime> FECCAMPANA { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
