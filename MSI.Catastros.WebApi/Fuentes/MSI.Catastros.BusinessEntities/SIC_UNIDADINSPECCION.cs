﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADINSPECCION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(12/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODANOSOLI { get; set; }
        public string CODNUMESOLI { get; set; }
        public string CODTIPOSOLI { get; set; }
        public string CTIPODOCUMENTO { get; set; }
        public string CODNROINSPEC { get; set; }
        public string CODCORRUNIDINSP { get; set; }
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
        public Nullable<int> CODUNI { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }
    }
}
