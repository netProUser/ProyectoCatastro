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
    public class SIC_TIPPROCED : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPPROCED.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPPROCED
        /// </summary>
        public IEnumerable<BE.SIC_TIPPROCED> Buscar(BE.SIC_TIPPROCED entSIC_TIPPROCED)
        {
            List<BE.SIC_TIPPROCED> lista = new List<BE.SIC_TIPPROCED>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPPROCED.PRC_BUSCAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcTXTDESCPRO", entSIC_TIPPROCED.TXTDESCPRO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPPROCED(reader, BE.SIC_TIPPROCED.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPPROCED.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPPROCED
        /// </summary>
        public BE.SIC_TIPPROCED Recuperar(BE.SIC_TIPPROCED entSIC_TIPPROCED)
        {
            BE.SIC_TIPPROCED lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPPROCED.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPPROC", entSIC_TIPPROCED.CODTIPPROC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TIPPROCED(reader, BE.SIC_TIPPROCED.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
    }
}
