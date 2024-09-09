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
    public class SIC_TIPODOCURRP : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (10/07/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPODOCURRP.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PUERTA
        /// </summary>
        public IEnumerable<BE.SIC_TIPODOCURRP> Listar(BE.SIC_TIPODOCURRP entSIC_PUERTA)
        {
            List<BE.SIC_TIPODOCURRP> lista = new List<BE.SIC_TIPODOCURRP>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_DOCRRPP.PRC_LISTAR_TMP", new object[1]);
            //db.SetParameterValue(dbCommand, "pvcCODTIPOINSP", entSIC_PUERTA.CODTIPOINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPODOCURRP(reader, BE.SIC_TIPODOCURRP.Query.Listar));
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
