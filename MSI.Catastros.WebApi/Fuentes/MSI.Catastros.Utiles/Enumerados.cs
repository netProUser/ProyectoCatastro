using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MSI.Catastros.Utiles
{
    public class Enumerados
    {        
    }

    [DataContract]
    public enum EnumUbigeoSI
    {
        [EnumMember]
        Departamento = 15,
        [EnumMember]
        Provincia = 01,
        [EnumMember]
        Distrito = 31
    }
}
