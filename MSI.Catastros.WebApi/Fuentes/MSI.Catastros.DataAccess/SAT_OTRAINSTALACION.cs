using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSI.Catastros.DataAccess
{
    public class SAT_OTRAINSTALACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: BusinessLogic.SAT_OTRAINSTALACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SAT_OTRAINSTALACION
        /// </summary>
        public IEnumerable<BE.SAT_OTRAINSTALACION> Listar(BE.SAT_OTRAINSTALACION entSAT_OTRAINSTALACION)
        {
            List<BE.SAT_OTRAINSTALACION> lista = new List<BE.SAT_OTRAINSTALACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OTRAINSTALACIO.PRC_LISTAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODANIOINSTALACION", entSAT_OTRAINSTALACION.CODANIOINSTALACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SAT_OTRAINSTALACION(reader, BE.SAT_OTRAINSTALACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: BusinessLogic.SAT_OTRAINSTALACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SAT_OTRAINSTALACION
        /// </summary>
        public IEnumerable<BE.SAT_OTRAINSTALACION> ListarAnioActual()
        {
            List<BE.SAT_OTRAINSTALACION> lista = new List<BE.SAT_OTRAINSTALACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OTRAINSTALACIO.PRC_LISTARANIOACT", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SAT_OTRAINSTALACION(reader, BE.SAT_OTRAINSTALACION.Query.ListarOtra));
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
