﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_MANZAVIANORMA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (12/03/2019)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODZONIFICACION { get; set; }
        public string CODVIA { get; set; }
        public string CODCORRMANZVIA { get; set; }

        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
