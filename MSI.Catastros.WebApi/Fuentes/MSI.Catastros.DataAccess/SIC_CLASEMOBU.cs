using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace MSI.Catastros.DataAccess
{
    public class SIC_CLASEMOBU : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_CLASEMOBU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_CLASEMOBU entSIC_CLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CLASEMOBU.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CLASEMOBU.CODCLASE);
            db.AddInParameter(dbCommand, "pvcTXTDESCLASE", DbType.String, entSIC_CLASEMOBU.TXTDESCLASE);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOA", DbType.String, entSIC_CLASEMOBU.TXTCODIGOA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CLASEMOBU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_CLASEMOBU entSIC_CLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CLASEMOBU.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CLASEMOBU.CODCLASE);
            db.AddInParameter(dbCommand, "pvcTXTDESCLASE", DbType.String, entSIC_CLASEMOBU.TXTDESCLASE);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOA", DbType.String, entSIC_CLASEMOBU.TXTCODIGOA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CLASEMOBU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CLASEMOBU, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_CLASEMOBU"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_CLASEMOBU entSIC_CLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CLASEMOBU.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CLASEMOBU.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CLASEMOBU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_CLASEMOBU Recuperar(BE.SIC_CLASEMOBU entSIC_CLASEMOBU)
        {
            BE.SIC_CLASEMOBU lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CLASEMOBU.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_CLASEMOBU.CODCLASE);            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CLASEMOBU(reader, BE.SIC_CLASEMOBU.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CLASEMOBU.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_CLASEMOBU> Listar(BE.SIC_CLASEMOBU entSIC_CLASEMOBU)
        {
            List<BE.SIC_CLASEMOBU> lista = new List<BE.SIC_CLASEMOBU>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CLASEMOBU.PRC_LISTAR", new object[1]);            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CLASEMOBU(reader, BE.SIC_CLASEMOBU.Query.Listar));
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
