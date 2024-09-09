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
    public class SIC_TIPOLLENA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (29/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOLLENA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPOLLENA
        /// </summary>
        public BE.SIC_TIPOLLENA Recuperar(BE.SIC_TIPOLLENA entSIC_TIPOLLENA)
        {
            BE.SIC_TIPOLLENA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TIPOLLENA.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOLLENA", entSIC_TIPOLLENA.CODTIPOLLENA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TIPOLLENA(reader, BE.SIC_TIPOLLENA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_TIPOLLENA ObtenerDiasHabiles(DateTime FechaInicio, int Dias)
        {
            BE.SIC_TIPOLLENA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TIPOLLENA.PRC_OBTENERFECHAHBIL", new object[3]);
            db.SetParameterValue(dbCommand, "pvcFECHAINICIO", FechaInicio);
            db.SetParameterValue(dbCommand, "pvcDIAS", Dias);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TIPOLLENA(reader, BE.SIC_TIPOLLENA.Query.Limite);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (29/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOLLENA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOLLENA
        /// </summary>
        public IEnumerable<BE.SIC_TIPOLLENA> Listar()
        {
            List<BE.SIC_TIPOLLENA> lista = new List<BE.SIC_TIPOLLENA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_TIPOLLENA.PRC_LISTAR", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPOLLENA(reader, BE.SIC_TIPOLLENA.Query.Listar));
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
