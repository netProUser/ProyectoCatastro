using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Exceptions
{
    public class ThrowError
    {
        public ThrowError(int Error)
        {
            switch (Error)
            {
                case -101:
                    throw new ExceptionsParameters("No se puede grabar, el código ya existe.");
                case -102:
                    throw new ExceptionsParameters("No se puede grabar, el nombre ya existe.");
                case -103:
                    throw new ExceptionsParameters("No se puede grabar, el grupo ya ha sido agregado.");
                case -104:
                    throw new ExceptionsParameters("No se puede grabar, el orden ya existe.");
                case -105:
                    throw new ExceptionsParameters("No se puede grabar, la competencia ya ha sido agregada.");
                case -106:
                    throw new ExceptionsParameters("No se puede grabar, la evaluación ya esta activada.");
                case -107:
                    throw new ExceptionsParameters("No se puede grabar, el nro. de documento ya ha sido agregado.");
                case -108:
                    throw new ExceptionsParameters("No se puede grabar, la pregunta ya ha sido agregada.");
                case -202:
                    throw new ExceptionsParameters("No se puede eliminar, el registro está activado.");
                case -201:
                    throw new ExceptionsParameters("No se puede eliminar, el registro está asociado.");
                default:
                    break;
            }
        }
    }
}
