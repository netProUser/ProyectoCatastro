using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace MSI.Catastros.DataAccess
{
    public class SIC_OBJETO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_OBJETO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_OBJETO entSIC_OBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OBJETO.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_OBJETO.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_OBJETO.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_OBJETO.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTDESCOBJETO", DbType.String, entSIC_OBJETO.TXTDESCOBJETO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_OBJETO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_OBJETO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_OBJETO entSIC_OBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OBJETO.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_OBJETO.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTDESCOBJETO", DbType.String, entSIC_OBJETO.TXTDESCOBJETO);            
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_OBJETO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_OBJETO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_OBJETO, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_OBJETO"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_OBJETO entSIC_OBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OBJETO.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_OBJETO.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_OBJETO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_OBJETO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_OBJETO Recuperar(BE.SIC_OBJETO entSIC_OBJETO)
        {
            BE.SIC_OBJETO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OBJETO.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_OBJETO.CODCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_OBJETO(reader, BE.SIC_OBJETO.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_OBJETO.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_OBJETO> Listar(BE.SIC_OBJETO entSIC_OBJETO)
        {
            List<BE.SIC_OBJETO> lista = new List<BE.SIC_OBJETO>();

            Database db = DatabaseFactory.CreateDatabase();            
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_OBJETO.PRC_LISTAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_OBJETO.CODCLASE);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE", entSIC_OBJETO.CODSUBCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_OBJETO(reader, BE.SIC_OBJETO.Query.Listar));
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
