using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using BE = MSI.Catastros.BusinessEntities;

namespace MSI.Catastros.DataAccess
{
    public class SIC_SUBCLASEMOBU : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_SUBCLASEMOBU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_SUBCLASEMOBU.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_SUBCLASEMOBU.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_SUBCLASEMOBU.CODCLASE);
            db.AddInParameter(dbCommand, "pvcTXTDESCCOMPO", DbType.String, entSIC_SUBCLASEMOBU.TXTDESCCOMPO);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOA", DbType.String, entSIC_SUBCLASEMOBU.TXTCODIGOA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SUBCLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_SUBCLASEMOBU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_SUBCLASEMOBU.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_SUBCLASEMOBU.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcTXTDESCLASE", DbType.String, entSIC_SUBCLASEMOBU.TXTDESCCOMPO);
            db.AddInParameter(dbCommand, "pvcTXTCODIGOA", DbType.String, entSIC_SUBCLASEMOBU.TXTCODIGOA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SUBCLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_SUBCLASEMOBU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SUBCLASEMOBU, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_SUBCLASEMOBU"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_SUBCLASEMOBU.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_SUBCLASEMOBU.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SUBCLASEMOBU.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_SUBCLASEMOBU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_SUBCLASEMOBU Recuperar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_SUBCLASEMOBU lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_SUBCLASEMOBU.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE", entSIC_SUBCLASEMOBU.CODSUBCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SUBCLASEMOBU(reader, BE.SIC_SUBCLASEMOBU.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_SUBCLASEMOBU.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_SUBCLASEMOBU> Listar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            List<BE.SIC_SUBCLASEMOBU> lista = new List<BE.SIC_SUBCLASEMOBU>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_SUBCLASEMOBU.PRC_LISTAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_SUBCLASEMOBU.CODCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SUBCLASEMOBU(reader, BE.SIC_SUBCLASEMOBU.Query.Listar));
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
