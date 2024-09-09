using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace MSI.Catastros.DataAccess
{
    public class SIC_CONFIGSUBCLASE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_CONFIGSUBCLASE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_CONFIGSUBCLASE entSIC_CONFIGSUBCLASE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGSUBCLASE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CONFIGSUBCLASE.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_CONFIGSUBCLASE.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcTXTNOMBRE", DbType.String, entSIC_CONFIGSUBCLASE.TXTNOMBRE);
            db.AddInParameter(dbCommand, "pvcTXTTIPOCAMPO", DbType.String, entSIC_CONFIGSUBCLASE.TXTTIPOCAMPO);
            db.AddInParameter(dbCommand, "pvcTXTTAMANO", DbType.String, entSIC_CONFIGSUBCLASE.TXTTAMANO);
            db.AddInParameter(dbCommand, "pvcTXTDESPLE", DbType.String, entSIC_CONFIGSUBCLASE.TXTDESPLE);
            db.AddInParameter(dbCommand, "pvcTXTORDEN", DbType.String, entSIC_CONFIGSUBCLASE.TXTORDEN);

            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGSUBCLASE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGSUBCLASE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_CONFIGSUBCLASE entSIC_CONFIGSUBCLASE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGSUBCLASE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CONFIGSUBCLASE.CODCLASE);
            db.AddInParameter(dbCommand, "pvcTXTDESCLASE", DbType.String, entSIC_CONFIGSUBCLASE.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOA", DbType.String, entSIC_CONFIGSUBCLASE.CODCORSCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGSUBCLASE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGSUBCLASE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONFIGSUBCLASE, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_CONFIGSUBCLASE"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_CONFIGSUBCLASE entSIC_CONFIGSUBCLASE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGSUBCLASE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CONFIGSUBCLASE.CODCORSCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGSUBCLASE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGSUBCLASE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_CONFIGSUBCLASE Recuperar(BE.SIC_CONFIGSUBCLASE entSIC_CONFIGSUBCLASE)
        {
            BE.SIC_CONFIGSUBCLASE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGSUBCLASE.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_CONFIGSUBCLASE.CODCORSCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CONFIGSUBCLASE(reader, BE.SIC_CONFIGSUBCLASE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGSUBCLASE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_CONFIGSUBCLASE> Listar(BE.SIC_CONFIGSUBCLASE entSIC_CONFIGSUBCLASE)
        {
            List<BE.SIC_CONFIGSUBCLASE> lista = new List<BE.SIC_CONFIGSUBCLASE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGSUBCLASE.PRC_LISTAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_CONFIGSUBCLASE.CODCLASE);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE", entSIC_CONFIGSUBCLASE.CODSUBCLASE);            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONFIGSUBCLASE(reader, BE.SIC_CONFIGSUBCLASE.Query.Listar));
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
