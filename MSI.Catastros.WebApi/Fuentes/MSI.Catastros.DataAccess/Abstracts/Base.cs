using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.DataAccess
{
    public abstract class Base
    {
        protected string EsquemaCatastro = ConfigurationManager.AppSettings["ESQUEMA_CATASTRO"];
        protected string EsquemaSeguridad = ConfigurationManager.AppSettings["ESQUEMA_SEGURIDAD"];
        protected string EsquemaTramite = ConfigurationManager.AppSettings["ESQUEMA_TRAMITE"];
        protected string EsquemaUrbano = ConfigurationManager.AppSettings["ESQUEMA_URBANO"];

        protected string CodigoArea = ConfigurationManager.AppSettings["CODAREA"];
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["cnnCATASTRO"].ConnectionString;

        protected string IPLocal = NetworkLocal.GetLocalIPAddress();
    }
}
