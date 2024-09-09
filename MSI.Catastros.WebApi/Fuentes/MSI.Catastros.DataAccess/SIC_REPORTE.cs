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
    public class SIC_REPORTE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe (25/09/2018)
        //Utilizado por	: REPORTS.ASPX
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// GENERA REPORTE HOJA INFORMATIVA (DATOS GENERICOS)
        /// </summary>
        public DataSet UnidadxInscripcion(DataSet dtSubGen)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_INSCRIPCIONUNIDAD", new object[1]);

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

        public DataSet UnidadxSector(DataSet dtSubGen)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_SECTORUNIDAD", new object[1]);

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

        public DataSet LotexSector(DataSet dtSubGen)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_SECTORLOTE", new object[1]);

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

        public DataSet LoteDetalleUsoPredio(DataSet dtSubGen)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_LOTEDETALLE", new object[1]);

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

        public DataSet LoteSectorManzana(DataSet dtSubGen)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_LOTESECTORMANZANA", new object[1]);

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

        public DataSet EstadisticoGeneralUso(DataSet dtSubGen, string Anio)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_ESTADISTICOGENERALUSO", new object[2]);
            db.SetParameterValue(dbCommand, "pvcANIO", Anio);
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
        public DataSet EstadisticoGeneralUsoAnio(DataSet dtSubGen,string Anio)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_REPORTE.PRC_ESTADISTICOGENERALUSOANIO", new object[2]);
            db.SetParameterValue(dbCommand, "pvcANIO", Anio);
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

    }
}
