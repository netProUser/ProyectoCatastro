using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace MSI.Catastros.DataAccess
{
    public class SIC_LOTEMUCONFIG : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMUCONFIG.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMUCONFIG.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMUCONFIG.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMUCONFIG.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMUCONFIG.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMUCONFIG.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMUCONFIG.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMUCONFIG.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMUCONFIG.CORRELURBA);
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODCORSCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODCORSCLASE);
            db.AddInParameter(dbCommand, "pvcTXTVALOR", DbType.String, entSIC_LOTEMUCONFIG.TXTVALOR);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMUCONFIG.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMUCONFIG.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMUCONFIG.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMUCONFIG.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMUCONFIG.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMUCONFIG.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMUCONFIG.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMUCONFIG.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMUCONFIG.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMUCONFIG.CORRELURBA);
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODCORSCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODCORSCLASE);
            db.AddInParameter(dbCommand, "pvcTXTVALOR", DbType.String, entSIC_LOTEMUCONFIG.TXTVALOR);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMUCONFIG.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMUCONFIG.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMUCONFIG, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_LOTEMUCONFIG"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMUCONFIG.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMUCONFIG.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMUCONFIG.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMUCONFIG.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_LOTEMUCONFIG Recuperar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            BE.SIC_LOTEMUCONFIG lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMUCONFIG.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_LOTEMUCONFIG.CODCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEMUCONFIG(reader, BE.SIC_LOTEMUCONFIG.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMUCONFIG.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_LOTEMUCONFIG> Listar(BE.SIC_LOTEMUCONFIG entSIC_LOTEMUCONFIG)
        {
            List<BE.SIC_LOTEMUCONFIG> lista = new List<BE.SIC_LOTEMUCONFIG>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMUCONFIG.PRC_LISTAR", new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEMUCONFIG.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEMUCONFIG.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEMUCONFIG.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEMUCONFIG.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEMUCONFIG.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEMUCONFIG.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCORRELURBA", entSIC_LOTEMUCONFIG.CORRELURBA);

            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_LOTEMUCONFIG.CODCLASE);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE", entSIC_LOTEMUCONFIG.CODSUBCLASE);
            db.SetParameterValue(dbCommand, "pvcCODCORSCLASE", entSIC_LOTEMUCONFIG.CODCORSCLASE);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEMUCONFIG(reader, BE.SIC_LOTEMUCONFIG.Query.Listar));
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
