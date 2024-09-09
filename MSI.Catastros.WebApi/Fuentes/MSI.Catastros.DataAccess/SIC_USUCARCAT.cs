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
    public class SIC_USUCARCAT : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_USUCARCAT.InspectoresLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USUCARCAT
        /// </summary>
        public IEnumerable<BE.SIC_USUCARCAT> InspectoresLis(BE.SIC_USUCARCAT entSIC_USUCARCAT)
        {
            List<BE.SIC_USUCARCAT> lista = new List<BE.SIC_USUCARCAT>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_USUCARCAT.PRC_INSPECTORES", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCARCAT", entSIC_USUCARCAT.CODCARCAT);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USUCARCAT(reader, BE.SIC_USUCARCAT.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public BE.SIC_USUCARCAT Recuperar(BE.SIC_USUCARCAT entSIC_USUCARCAT)
        {
            BE.SIC_USUCARCAT lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_USUCARCAT.PRC_DATOS_TELEFONO", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUSUASIS", entSIC_USUCARCAT.CODUSUASIS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_USUCARCAT(reader, BE.SIC_USUCARCAT.Query.Recuperar);
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
