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
    public class SIC_UNIDADACTIVIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADACTIVIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADACTIVIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADACTIVIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADACTIVIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcNUMMETROS", DbType.Decimal, entSIC_UNIDADACTIVIDAD.NUMMETROS);
            db.AddInParameter(dbCommand, "pvcFECACTI", DbType.Date, entSIC_UNIDADACTIVIDAD.FECACTI);
            db.AddInParameter(dbCommand, "pvcCODUSORETIRO", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSORETIRO);
            db.AddInParameter(dbCommand, "pvcCODOPCIONANUN", DbType.String, entSIC_UNIDADACTIVIDAD.CODOPCIONANUN);
            db.AddInParameter(dbCommand, "pvcCODANUNCIO", DbType.String, entSIC_UNIDADACTIVIDAD.CODANUNCIO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADACTIVIDAD.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRELACTI", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELACTI"));
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
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADACTIVIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADACTIVIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcNUMMETROS", DbType.Decimal, entSIC_UNIDADACTIVIDAD.NUMMETROS);
            db.AddInParameter(dbCommand, "pvcFECACTI", DbType.Date, entSIC_UNIDADACTIVIDAD.FECACTI);
            db.AddInParameter(dbCommand, "pvcCODUSORETIRO", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSORETIRO);
            db.AddInParameter(dbCommand, "pvcCODOPCIONANUN", DbType.String, entSIC_UNIDADACTIVIDAD.CODOPCIONANUN);
            db.AddInParameter(dbCommand, "pvcCODANUNCIO", DbType.String, entSIC_UNIDADACTIVIDAD.CODANUNCIO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADACTIVIDAD.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRELACTI", DbType.String, entSIC_UNIDADACTIVIDAD.CODCORRELACTI);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADACTIVIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADACTIVIDAD
        /// </summary>
        public BE.SIC_UNIDADACTIVIDAD Recuperar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_UNIDADACTIVIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADACTIVIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADACTIVIDAD.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRELACTI", entSIC_UNIDADACTIVIDAD.CODCORRELACTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADACTIVIDAD(reader, BE.SIC_UNIDADACTIVIDAD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADACTIVIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADACTIVIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRELACTI", DbType.String, entSIC_UNIDADACTIVIDAD.CODCORRELACTI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADACTIVIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADACTIVIDAD.TXTIPREG);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registros de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADACTIVIDAD> Listar(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADACTIVIDAD> lista = new List<BE.SIC_UNIDADACTIVIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADACTIVIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADACTIVID.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);  
          
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADACTIVIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADACTIVIDAD(reader, BE.SIC_UNIDADACTIVIDAD.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADACTIVIDAD> CargarUnidadActividadEconomicaHistoricas(BE.SIC_UNIDADACTIVIDAD entSIC_UNIDADACTIVIDAD)
        {
            List<BE.SIC_UNIDADACTIVIDAD> lista = new List<BE.SIC_UNIDADACTIVIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERACTYIVIDADHISTORICO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADACTIVIDAD.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADACTIVIDAD.NUMVERSION);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADACTIVIDAD(reader, BE.SIC_UNIDADACTIVIDAD.Query.ListarHistorico));
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
