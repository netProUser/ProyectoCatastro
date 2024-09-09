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
    public class SIC_TABPROCE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TABPROCE.Responsables
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TABPROCE
        /// </summary>
        public IEnumerable<BE.SIC_TABPROCE> Listar(BE.SIC_TABPROCE entSIC_TABPROCE)
        {
            List<BE.SIC_TABPROCE> lista = new List<BE.SIC_TABPROCE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TABPROCE.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODCARCAT", entSIC_TABPROCE.CODCARCAT);
            db.SetParameterValue(dbCommand, "pvcCODTIPPROC", entSIC_TABPROCE.CODTIPPROC);
            db.SetParameterValue(dbCommand, "pvcCODESTATENCIONE", entSIC_TABPROCE.CODESTATENCIONE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TABPROCE(reader, BE.SIC_TABPROCE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TABPROCE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TABPROCE
        /// </summary>
        public BE.SIC_TABPROCE Recuperar(BE.SIC_TABPROCE entSIC_TABPROCE)
        {
            BE.SIC_TABPROCE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TABPROCE.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_TABPROCE.CODUSUARIO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TABPROCE(reader, BE.SIC_TABPROCE.Query.Recuperar);
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
