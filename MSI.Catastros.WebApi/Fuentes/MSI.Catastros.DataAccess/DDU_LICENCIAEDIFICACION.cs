using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSI.Catastros.DataAccess
{
    public class DDU_LICENCIAEDIFICACION : Base
    {

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (13/06/2018)
        //Utilizado por	: BusinessLogic.DDU_LICENCIAEDIFICACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla DDU_LICENCIAEDIFICACION
        /// </summary>
        public IEnumerable<BE.DDU_LICENCIAEDIFICACION> Consulta(BE.DDU_LICENCIAEDIFICACION entDDU_LICENCIA)
        {
            List<BE.DDU_LICENCIAEDIFICACION> lista = new List<BE.DDU_LICENCIAEDIFICACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaUrbano + ".PKG_CONSULTA_LICENCIAS.PRC_CONSULTA_LICENCIASEDIF", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCATRASTAL", entDDU_LICENCIA.CODIGO_CATASTRAL);
            db.SetParameterValue(dbCommand, "pvcCODCATRASTALANTIGUO", entDDU_LICENCIA.CODIGO_CATASTRAL_ANTIGUO);


            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.DDU_LICENCIAEDIFICACION(reader, BE.DDU_LICENCIAEDIFICACION.Query.Consultar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
    }
}
