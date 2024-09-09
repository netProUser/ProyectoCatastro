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
    public class SIC_UNIDADOBSERVACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADOBSERVACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADOBSERVACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADOBSERVACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcFECOBSERVACION", DbType.Date, entSIC_UNIDADOBSERVACION.FECOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_UNIDADOBSERVACION.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTIPOBSERVA", DbType.String, entSIC_UNIDADOBSERVACION.TIPOBSERVA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADOBSERVACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADOBSERVACION.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORROBSE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORROBSE"));
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
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADOBSERVACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADOBSERVACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcFECOBSERVACION", DbType.Date, entSIC_UNIDADOBSERVACION.FECOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_UNIDADOBSERVACION.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTIPOBSERVA", DbType.String, entSIC_UNIDADOBSERVACION.TIPOBSERVA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADOBSERVACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADOBSERVACION.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORROBSE", DbType.String, entSIC_UNIDADOBSERVACION.CODCORROBSE);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADOBSERVACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_UNIDADOBSERVACION Recuperar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_UNIDADOBSERVACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADOBSERVACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORROBSE",  entSIC_UNIDADOBSERVACION.CODCORROBSE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADOBSERVACION(reader, BE.SIC_UNIDADOBSERVACION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADOBSERVACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADOBSERVACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORROBSE", DbType.String, entSIC_UNIDADOBSERVACION.CODCORROBSE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADOBSERVACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADOBSERVACION.TXTIPREG);
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
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADOBSERVACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registros de la tabla SIC_UNIDADOBSERVACION
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADOBSERVACION> Listar(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            List<BE.SIC_UNIDADOBSERVACION> lista = new List<BE.SIC_UNIDADOBSERVACION>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADOBSERVAC.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);  
           
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADOBSERVACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", entSIC_UNIDADOBSERVACION.TIPOBSERVA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADOBSERVACION(reader, BE.SIC_UNIDADOBSERVACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADOBSERVACION> BuscarHistoricoObservacion(BE.SIC_UNIDADOBSERVACION entSIC_UNIDADOBSERVACION)
        {
            List<BE.SIC_UNIDADOBSERVACION> lista = new List<BE.SIC_UNIDADOBSERVACION>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENEROBSERVACIONES";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADOBSERVACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADOBSERVACION.NUMVERSION);
            db.SetParameterValue(dbCommand, "pvcTIPOBSERVA", entSIC_UNIDADOBSERVACION.TIPOBSERVA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADOBSERVACION(reader, BE.SIC_UNIDADOBSERVACION.Query.ListarHistorico));
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
