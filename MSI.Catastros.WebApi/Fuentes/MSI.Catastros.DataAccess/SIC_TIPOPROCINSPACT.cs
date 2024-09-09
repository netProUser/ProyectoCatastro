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
    public class SIC_TIPOPROCINSPACT : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOPROCINSPACT.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOPROCINSPACT
        /// </summary>
        public IEnumerable<BE.SIC_TIPOPROCINSPACT> Listar(BE.SIC_TIPOPROCINSPACT entSIC_TIPOPROCINSPACT)
        {
            List<BE.SIC_TIPOPROCINSPACT> lista = new List<BE.SIC_TIPOPROCINSPACT>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TIPOPROCINSPA.PRC_LISTAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINSP", entSIC_TIPOPROCINSPACT.CODTIPOINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPOPROCINSPACT(reader, BE.SIC_TIPOPROCINSPACT.Query.Listar));
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
