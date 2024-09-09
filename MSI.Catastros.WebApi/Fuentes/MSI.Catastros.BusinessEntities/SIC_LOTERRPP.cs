﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_LOTERRPP
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(11/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public string CODDEPARTAMENTO { get; set; }
        public string CODPROVINCIA { get; set; }
        public string CODDISTRITO { get; set; }
        public string CODSECTOR { get; set; }
        public string CODMANZANA { get; set; }
        public string CODLOTE { get; set; }
        public string CODCORRLOTERRPP { get; set; }
        public string CODTIPODOCU { get; set; }
        public string TXTPARTELEC { get; set; }
        public string TXTTOMOFICH { get; set; }
        public string TXTFOLIO { get; set; }
        public string TXTASIENTO { get; set; }
        public Nullable<DateTime> FECDOCUMENTO { get; set; }
        public string CODUSUARIO { get; set; }
        public Nullable<DateTime> FECREG { get; set; }
        public string TXTIPREG { get; set; }
        public string ESTADO { get; set; }
        public string CODUSUARIOMODIF { get; set; }
        public Nullable<DateTime> FECMODIF { get; set; }
        public string TXTIPMODIF { get; set; }

        public string TXTNOMDOCU { get; set; }
        public string TXTNOMDOCUINT { get; set; }
        public bool ESTATICO { get; set; }

        public string CORRELATIVO { get; set; }
        public string CODDOCUMENTO { get; set; }
        public string TXTNRODOCUMENTO { get; set; }
        public string TXTRUTAPDF  { get; set; }
        public string PDFHABILITADO  { get; set; }
        public string TXTOBSERVACION { get; set; }
    }
}
