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
    public class SIC_UNIDINSTALACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDINSTALACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDINSTALACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDINSTALACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODINSTALACION", DbType.String, entSIC_UNIDINSTALACION.CODINSTALACION);
            db.AddInParameter(dbCommand, "pvcTXTMES", DbType.String, entSIC_UNIDINSTALACION.TXTMES);
            db.AddInParameter(dbCommand, "pvcTXTANO", DbType.String, entSIC_UNIDINSTALACION.TXTANO);
            db.AddInParameter(dbCommand, "pvcCODESTACONSE", DbType.String, entSIC_UNIDINSTALACION.CODESTACONSE);
            db.AddInParameter(dbCommand, "pvcNUMCAPACIDAD", DbType.Decimal, entSIC_UNIDINSTALACION.NUMCAPACIDAD);
            db.AddInParameter(dbCommand, "pvcNUMCANTIDAD", DbType.Int32, entSIC_UNIDINSTALACION.NUMCANTIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDINSTALACION.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDINSTALACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDINSTALACION.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDINST", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINST"));
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
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDINSTALACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDINSTALACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODINSTALACION", DbType.String, entSIC_UNIDINSTALACION.CODINSTALACION);
            db.AddInParameter(dbCommand, "pvcTXTMES", DbType.String, entSIC_UNIDINSTALACION.TXTMES);
            db.AddInParameter(dbCommand, "pvcTXTANO", DbType.String, entSIC_UNIDINSTALACION.TXTANO);
            db.AddInParameter(dbCommand, "pvcCODESTACONSE", DbType.String, entSIC_UNIDINSTALACION.CODESTACONSE);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDINSTALACION.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcNUMCAPACIDAD", DbType.Decimal, entSIC_UNIDINSTALACION.NUMCAPACIDAD);
            db.AddInParameter(dbCommand, "pvcNUMCANTIDAD", DbType.Int32, entSIC_UNIDINSTALACION.NUMCANTIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDINSTALACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDINSTALACION.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINST", DbType.String, entSIC_UNIDINSTALACION.CODCORRUNIDINST);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_UNIDINSTALACION Recuperar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_UNIDINSTALACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDINSTALACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDINSTALACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDINST", entSIC_UNIDINSTALACION.CODCORRUNIDINST);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDINSTALACION(reader, BE.SIC_UNIDINSTALACION.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDINSTALACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDINSTALACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDINSTALACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDINSTALACION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINST", DbType.String, entSIC_UNIDINSTALACION.CODCORRUNIDINST);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDINSTALACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDINSTALACION.TXTIPREG);
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

        public IEnumerable<BE.SIC_UNIDINSTALACION> Listar(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            List<BE.SIC_UNIDINSTALACION> lista = new List<BE.SIC_UNIDINSTALACION>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDINSTALACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);       
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDINSTALACION.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDINSTALACION(reader, BE.SIC_UNIDINSTALACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDINSTALACION> RecuperaInstalacionesHistoricasUnidades(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            List<BE.SIC_UNIDINSTALACION> lista = new List<BE.SIC_UNIDINSTALACION>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_INSTALACIONESHISTORICAS";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDINSTALACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDINSTALACION.NUMVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDINSTALACION(reader, BE.SIC_UNIDINSTALACION.Query.ListarHistorico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public string ObtenerDescripcionUnidad(BE.SIC_UNIDINSTALACION entSIC_UNIDINSTALACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDINSTALACIO.PRC_OBTENERUNIDAD_TMP");
            db.AddInParameter(dbCommand, "pvcCODINSTALACION", DbType.String, entSIC_UNIDINSTALACION.CODINSTALACION);
            db.AddOutParameter(dbCommand, "pvcDESCRIPCION", DbType.String, 20);
            string DESCRIPCION;
            try
            {
                db.ExecuteNonQuery(dbCommand);
                DESCRIPCION = (string)(db.GetParameterValue(dbCommand, "pvcDESCRIPCION"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return DESCRIPCION;
        }
    }
}
