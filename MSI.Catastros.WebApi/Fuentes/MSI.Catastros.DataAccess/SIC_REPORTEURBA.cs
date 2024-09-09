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
    public class SIC_REPORTEURBA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (21/09/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE HAB URBANA (Datos Genericos)
        /// </summary>
        public DataSet DatosGenerico(DataSet dtSubGen, string CodigoHu)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_URBANA.PRC_DATOGEN", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODHABURBA", CodigoHu);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (21/09/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE HAB URBANA (Datos Manzana)
        /// </summary>
        public DataSet DatosManza(DataSet dtSubManza, string CodigoHu)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_URBANA.PRC_DATOMANZAURBA", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODHABURBA", CodigoHu);

            try
            {
                dtSubManza = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubManza;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (21/09/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE HAB URBANA (Datos Observacion)
        /// </summary>
        public DataSet DatosObs(DataSet dtSubObs, string CodigoHu)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_URBANA.PRC_DATOOBSURBA", new object[2]);

            db.SetParameterValue(dbCommand, "pvcCODHABURBA", CodigoHu);

            try
            {
                dtSubObs = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubObs;
        }
    }
}
