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
    public class SIC_REPORTE_MANZANA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (26/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE MANZANA (Datos Genericos)
        /// </summary>
        public DataSet DatosGenerico(DataSet dtSubGen,string CodigoDistrito, string CodigoSector, string CodigoManzana)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_MANZANA.PRC_DATOGENMZ", new object[6]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);

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
        //Creado por	: AA (26/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE MANZANA (Ubicacion de la Manzana)
        /// </summary>
        public DataSet DatosUbicMz(DataSet dtSubUbic, string CodigoDistrito, string CodigoSector, string CodigoManzana)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_MANZANA.PRC_DATOUBICMZ", new object[6]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);

            try
            {
                dtSubUbic = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubUbic;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (26/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE MANZANA (Linderos Mz)
        /// </summary>
        public DataSet DatosLindMz(DataSet dtSubLinderos, string CodigoDistrito, string CodigoSector, string CodigoManzana)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_MANZANA.PRC_DATOLINDEROMZ", new object[6]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);

            try
            {
                dtSubLinderos = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubLinderos;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (26/07/2018)
        //Utilizado por	: Reports.aspx
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE DE MANZANA (Lotes Totales)
        /// </summary>
        public DataSet DatosLotTot(DataSet dtSubLotTot, string CodigoDistrito, string CodigoSector, string CodigoManzana)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_MANZANA.PRC_DATOTOTALLOTE", new object[6]);

            db.SetParameterValue(dbCommand, "PVCCODDEPARTAMENTO", "15");
            db.SetParameterValue(dbCommand, "PVCCODPROVINCIA", "01");
            db.SetParameterValue(dbCommand, "PVCCODDISTRITO", "31");
            db.SetParameterValue(dbCommand, "PVCCODSECTOR", CodigoSector);
            db.SetParameterValue(dbCommand, "PVCCODMANZANA", CodigoManzana);

            try
            {
                dtSubLotTot = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubLotTot;
        }
    }
}
