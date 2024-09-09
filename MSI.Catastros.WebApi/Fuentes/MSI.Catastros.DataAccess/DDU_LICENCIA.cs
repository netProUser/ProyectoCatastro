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
    public class DDU_LICENCIA : Base
    {
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (13/06/2018)
        //Utilizado por	: BusinessLogic.DDU_LICENCIA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla DDU_LICENCIA
        /// </summary>
        public IEnumerable<BE.DDU_LICENCIA> Consulta(BE.DDU_LICENCIA entDDU_LICENCIA)
        {
            List<BE.DDU_LICENCIA> lista = new List<BE.DDU_LICENCIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaUrbano + ".PKG_CONSULTA_LICENCIAS.PRC_CONSULTA_LICENCIASFUNC", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCATRASTAL", entDDU_LICENCIA.CODIGO_CATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.DDU_LICENCIA(reader, BE.DDU_LICENCIA.Query.Consultar));
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
