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
    public class SIC_INFORMESUBDETA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORME.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_INFORME
        /// </summary>
        public IEnumerable<BE.SIC_INFORMESUBDETA> Buscar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            List<BE.SIC_INFORMESUBDETA> lista = new List<BE.SIC_INFORMESUBDETA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_BUSCAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMESUBDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMESUBDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRELDETA", entSIC_INFORMESUBDETA.CODCORRELDETA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INFORMESUBDETA(reader, BE.SIC_INFORMESUBDETA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMESUBDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORMESUBDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMESUBDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMESUBDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMESUBDETA.CODCORRELDETA);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO", DbType.String, entSIC_INFORMESUBDETA.TXTSUBTITULO);
            db.AddInParameter(dbCommand, "pvcTXTSUBDETALLE", DbType.String, entSIC_INFORMESUBDETA.TXTSUBDETALLE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMESUBDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODSUBDETA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODSUBDETA"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMESUBDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMESUBDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMESUBDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMESUBDETA.CODCORRELDETA);
            db.AddInParameter(dbCommand, "pvcCODSUBDETA", DbType.String, entSIC_INFORMESUBDETA.CODSUBDETA);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO", DbType.String, entSIC_INFORMESUBDETA.TXTSUBTITULO);
            db.AddInParameter(dbCommand, "pvcTXTSUBDETALLE", DbType.String, entSIC_INFORMESUBDETA.TXTSUBDETALLE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMESUBDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMESUBDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_INFORMESUBDETA Recuperar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_INFORMESUBDETA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMESUBDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMESUBDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRELDETA", entSIC_INFORMESUBDETA.CODCORRELDETA);
            db.SetParameterValue(dbCommand, "pvcCODSUBDETA", entSIC_INFORMESUBDETA.CODSUBDETA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_INFORMESUBDETA(reader, BE.SIC_INFORMESUBDETA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMESUBDETA.DatosInformeDetalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public DataSet DatosInformeDetalle(DataSet dtDatosInformeDetalle, BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMESUBDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMESUBDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRELDETA", entSIC_INFORMESUBDETA.CODCORRELDETA);
            try
            {
                dtDatosInformeDetalle = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtDatosInformeDetalle;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMESUBDETA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMESUBDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMESUBDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMESUBDETA.CODCORRELDETA);
            db.AddInParameter(dbCommand, "pvcCODSUBDETA", DbType.String, entSIC_INFORMESUBDETA.CODSUBDETA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMESUBDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarDetalle(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMESUBDETA.PRC_ELIMINAR_DETALLE");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMESUBDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMESUBDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMESUBDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMESUBDETA.CODCORRELDETA);
            //db.AddInParameter(dbCommand, "pvcCODSUBDETA", DbType.String, entSIC_INFORMESUBDETA.CODSUBDETA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMESUBDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_INFORMESUBDETA.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        
        public DataSet ListaInformeDetalle(DataSet dtListaInformeDetalle, string codigoInforme, string codigoAnio, string codigoTipoInforme)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", codigoInforme);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", codigoAnio);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", codigoTipoInforme);
            try
            {
                dtListaInformeDetalle = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtListaInformeDetalle;
        }
        
    }
}
