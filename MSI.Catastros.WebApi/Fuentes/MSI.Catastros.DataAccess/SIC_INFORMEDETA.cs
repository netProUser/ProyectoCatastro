using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MSI.Catastros.DataAccess
{
    public class SIC_INFORMEDETA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (13/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORME.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_INFORME
        /// </summary>
        public IEnumerable<BE.SIC_INFORMEDETA> Buscar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            List<BE.SIC_INFORMEDETA> lista = new List<BE.SIC_INFORMEDETA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_BUSCAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMEDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", entSIC_INFORMEDETA.CODCORRINFO);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMEDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMEDETA.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INFORMEDETA(reader, BE.SIC_INFORMEDETA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMEDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORMEDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            var bytesTXTDETALLE = Encoding.ASCII.GetBytes(entSIC_INFORMEDETA.TXTDETALLE);
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMEDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODCORRINFO", DbType.String, entSIC_INFORMEDETA.CODCORRINFO);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMEDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMEDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcTXTTITULO", DbType.String, entSIC_INFORMEDETA.TXTTITULO);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_INFORMEDETA.TXTDETALLE);
            //db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.Byte, bytesTXTDETALLE);
            //db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType., System.Text.Encoding.UTF8.GetBytes(entSIC_INFORMEDETA.TXTDETALLE));
            db.AddInParameter(dbCommand, "pvcTXTRUTA", DbType.String, entSIC_INFORMEDETA.TXTRUTA);
            db.AddInParameter(dbCommand, "pvcCODTIPODETALLE", DbType.String, entSIC_INFORMEDETA.CODTIPODETALLE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMEDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELDETA"));
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
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMEDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        //public BE.SIC_RETORNO Actualizar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        //{
        //    BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_MODIFICAR");
        //    db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMEDETA.CODINFORME);
        //    db.AddInParameter(dbCommand, "pvcCODCORRINFO", DbType.String, entSIC_INFORMEDETA.CODCORRINFO);
        //    db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMEDETA.CODANOINFO);
        //    db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMEDETA.CODTIPOINFOR);
        //    db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMEDETA.CODCORRELDETA);
        //    db.AddInParameter(dbCommand, "pvcTXTTITULO", DbType.String, entSIC_INFORMEDETA.TXTTITULO);
        //    db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType., entSIC_INFORMEDETA.TXTDETALLE);
        //    db.AddInParameter(dbCommand, "pvcTXTRUTA", DbType.String, entSIC_INFORMEDETA.TXTRUTA);
        //    db.AddInParameter(dbCommand, "pvcCODTIPODETALLE", DbType.String, entSIC_INFORMEDETA.CODTIPODETALLE);
        //    db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMEDETA.CODUSUARIO);
        //    db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
        //    db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
        //    try
        //    {
        //        db.ExecuteNonQuery(dbCommand);
        //        entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
        //        entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return entSIC_RETORNO;
        //}

        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["cnnCATASTRO"].ConnectionString);
            cnx.Open();
            OracleTransaction trans = cnx.BeginTransaction();

            try
            {              
                OracleCommand cmd = new OracleCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_MODIFICAR", cnx, trans);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("pvcCODINFORME", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODINFORME != null) ? entSIC_INFORMEDETA.CODINFORME : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODCORRINFO", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODCORRINFO != null) ? entSIC_INFORMEDETA.CODCORRINFO : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODANOINFO", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODANOINFO != null) ? entSIC_INFORMEDETA.CODANOINFO : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODTIPOINFOR", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODTIPOINFOR != null) ? entSIC_INFORMEDETA.CODTIPOINFOR : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODCORRELDETA", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODCORRELDETA != null) ? entSIC_INFORMEDETA.CODCORRELDETA : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcTXTTITULO", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.TXTTITULO != null) ? entSIC_INFORMEDETA.TXTTITULO : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcTXTDETALLE", OracleType.Clob)).Value = ((entSIC_INFORMEDETA.TXTDETALLE != null) ? entSIC_INFORMEDETA.TXTDETALLE : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcTXTRUTA", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.TXTRUTA != null) ? entSIC_INFORMEDETA.TXTRUTA : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODTIPODETALLE", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODTIPODETALLE != null) ? entSIC_INFORMEDETA.CODTIPODETALLE : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcCODUSUARIO", OracleType.VarChar)).Value = ((entSIC_INFORMEDETA.CODUSUARIO != null) ? entSIC_INFORMEDETA.CODUSUARIO : (object)DBNull.Value);
                cmd.Parameters.Add(new OracleParameter("pvcTXTIPREG", OracleType.VarChar)).Value = ((IPLocal != null) ? IPLocal : (object)DBNull.Value);

                cmd.Parameters.Add(new OracleParameter("pvcNROMENSAJE", OracleType.Int32)).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                               
                entSIC_RETORNO.NoMENSAJE = (Int32)cmd.Parameters["pvcNROMENSAJE"].Value;
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);

                trans.Commit();

            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }            
            finally
            {
                cnx.Close();
            }

            return entSIC_RETORNO;
        }



        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMEDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public BE.SIC_INFORMEDETA Recuperar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_INFORMEDETA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMEDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", entSIC_INFORMEDETA.CODCORRINFO);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMEDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMEDETA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRELDETA", entSIC_INFORMEDETA.CODCORRELDETA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_INFORMEDETA(reader, BE.SIC_INFORMEDETA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMEDETA.DatosInformeDetalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public DataSet DatosInformeDetalle(DataSet dtDatosInformeDetalle, BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMEDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", entSIC_INFORMEDETA.CODCORRINFO);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMEDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMEDETA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRELDETA", entSIC_INFORMEDETA.CODCORRELDETA);
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
        //Creado por	: Pedro Peña Salazar (11/08/2018)
        //Utilizado por	: BusinessLogic.SIC_INFORMEDETA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORMEDETA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODINFORME", DbType.String, entSIC_INFORMEDETA.CODINFORME);
            db.AddInParameter(dbCommand, "pvcCODCORRINFO", DbType.String, entSIC_INFORMEDETA.CODCORRINFO);            
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_INFORMEDETA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRELDETA", DbType.String, entSIC_INFORMEDETA.CODCORRELDETA);
            db.AddInParameter(dbCommand, "pvcCODANOINFO", DbType.String, entSIC_INFORMEDETA.CODANOINFO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INFORMEDETA.CODUSUARIO);
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
        
        public DataSet ListaInformeDetalle(DataSet dtListaInformeDetalle, string codigoInforme, string codigoAnio, string codigoTipoInforme,  string CodigoCorrInforme)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_LISTAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", codigoInforme);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", CodigoCorrInforme);            
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

        public DataSet ListaInformeDetalleNumeracion(DataSet dtListaInformeDetalle, string codigoInforme, string codigoAnio, string codigoTipoInforme)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_LISTAR_REPORTE", new object[4]);
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

        public DataSet ListarInformeConstruccion(DataSet dtListaInformeDetalleConstruccion, string codigoInforme, string codigoAnio, string codigoTipoInforme)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_LISTAR_CONST_REPORTE", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", codigoInforme);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", codigoAnio);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", codigoTipoInforme);
            try
            {
                dtListaInformeDetalleConstruccion = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtListaInformeDetalleConstruccion;
        }

        public IEnumerable<BE.SIC_INFORMEDETA> Listar(BE.SIC_INFORMEDETA entSIC_INFORMEDETA)
        {
            List<BE.SIC_INFORMEDETA> lista = new List<BE.SIC_INFORMEDETA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_INFORMEDETA.PRC_LISTAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORME", entSIC_INFORMEDETA.CODINFORME);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFO", entSIC_INFORMEDETA.CODCORRINFO);
            db.SetParameterValue(dbCommand, "pvcCODANOINFO", entSIC_INFORMEDETA.CODANOINFO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_INFORMEDETA.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INFORMEDETA(reader, BE.SIC_INFORMEDETA.Query.ListarDetalle));
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
