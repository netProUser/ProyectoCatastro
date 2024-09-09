using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class PGD_TRAMITE_EXT
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza(05/06/2018)
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public Nullable<int> VTIPO { get; set; }
        public Nullable<int> VTIPODESTINO { get; set; }
        public string VID_REF { get; set; }
        public string VREMITE { get; set; }
        public string VRECIBE { get; set; }
        public string VTIPREC { get; set; }
        public string VPERREM { get; set; }
        public string VPERREC { get; set; }
        public string VOBSERV { get; set; }
        public string VFECING { get; set; }
        public string VFOLIOS { get; set; }
        public string VCODACT2 { get; set; }
        public string VCODACC2 { get; set; }
        public string TXTTIPODOC { get; set; }
        public string TXTNRODOC { get; set; }


        public string TIPO_DE_VIA { get; set; }
        public string DENOMINACION_DE_LA_VIA { get; set; }


        public string CODIGO_CATASTRAL { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string NRODOC { get; set; }
        
        public string COD_RECURRENTE { get; set; }
        public string SOLICITANTE { get; set; }
        public string CODIGO_CONTRIBUYENTE { get; set; }
        public string CODTIPODOCUMENTOREC { get; set; }
        public string DES_TIPODOCREC { get; set; }
        public string DOCIDRECURRENTE { get; set; }
        public string REPRESENTANTEL { get; set; }
        public string CODTIPODOCREPLEGAL { get; set; }
        public string DES_TIPODOCREPL { get; set; }
        public string DOCIDREPRESENTANTEL { get; set; }
        public string COD_PREDIO { get; set; }
        public string CALLE1 { get; set; }
        public string NRO_PREDIO1 { get; set; }
        public string NRO_PREDIO2 { get; set; }
        public string DESCRIPCION_PREDIO { get; set; }
        public string COD_ASUNTO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string TELEFONOS { get; set; }
        public string FOLIO { get; set; }
        public string COD_RECDOMICILIO { get; set; }
        public string CALLE2 { get; set; }
        public string NRO_RECPREDIO1 { get; set; }
        public string NRO_RECPREDIO2 { get; set; }
        public string DESCRIPCION_RECPREDIO { get; set; }
        public string USUARIO { get; set; }
        public string TIPO_DE_VALOR { get; set; }
        public string NUMERO_VALOR { get; set; }
        public string DASUNTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string AREA_DESTINO { get; set; }
        public string TIPO_INT_PREDIO { get; set; }
        public string NRO_INT1_PREDIO { get; set; }
        public string COD_LOCAL { get; set; }
        public string SECUENCIA { get; set; }
        public string TXTTUPA { get; set; }
        public string NRO_RECIBO { get; set; }

    }
}
