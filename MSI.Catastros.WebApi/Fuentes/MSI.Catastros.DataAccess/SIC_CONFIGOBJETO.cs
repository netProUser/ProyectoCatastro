using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace MSI.Catastros.DataAccess
{
    public class SIC_CONFIGOBJETO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_CONFIGOBJETO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_CONFIGOBJETO entSIC_CONFIGOBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGOBJE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_CONFIGOBJETO.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_CONFIGOBJETO.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_CONFIGOBJETO.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTNOMBREO", DbType.String, entSIC_CONFIGOBJETO.TXTNOMBREO);
            db.AddInParameter(dbCommand, "pvcTXTIPOCAMPOB", DbType.String, entSIC_CONFIGOBJETO.TXTIPOCAMPOB);
            db.AddInParameter(dbCommand, "pvcTXTTAMANOB", DbType.String, entSIC_CONFIGOBJETO.TXTTAMANOB);
            db.AddInParameter(dbCommand, "pvcTXTDESPLEOB", DbType.String, entSIC_CONFIGOBJETO.TXTDESPLEOB);
            db.AddInParameter(dbCommand, "pvcTXTORDENO", DbType.String, entSIC_CONFIGOBJETO.TXTORDENO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGOBJETO.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGOBJETO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_CONFIGOBJETO entSIC_CONFIGOBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGOBJE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCONFOBJETO", DbType.String, entSIC_CONFIGOBJETO.CODCONFOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTNOMBREO", DbType.String, entSIC_CONFIGOBJETO.TXTNOMBREO);
            db.AddInParameter(dbCommand, "pvcTXTIPOCAMPOB", DbType.String, entSIC_CONFIGOBJETO.TXTIPOCAMPOB);
            db.AddInParameter(dbCommand, "pvcTXTTAMANOB", DbType.String, entSIC_CONFIGOBJETO.TXTTAMANOB);
            db.AddInParameter(dbCommand, "pvcTXTDESPLEOB", DbType.String, entSIC_CONFIGOBJETO.TXTDESPLEOB);
            db.AddInParameter(dbCommand, "pvcTXTORDENO", DbType.String, entSIC_CONFIGOBJETO.TXTORDENO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGOBJETO.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGOBJETO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONFIGOBJETO, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_CONFIGOBJETO"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_CONFIGOBJETO entSIC_CONFIGOBJETO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGOBJE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCONFOBJETO", DbType.String, entSIC_CONFIGOBJETO.CODCONFOBJETO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONFIGOBJETO.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGOBJETO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_CONFIGOBJETO Recuperar(BE.SIC_CONFIGOBJETO entSIC_CONFIGOBJETO)
        {
            BE.SIC_CONFIGOBJETO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGOBJE.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCONFOBJETO",  entSIC_CONFIGOBJETO.CODCONFOBJETO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CONFIGOBJETO(reader, BE.SIC_CONFIGOBJETO.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CONFIGOBJETO.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_CONFIGOBJETO> Listar(BE.SIC_CONFIGOBJETO entSIC_CONFIGOBJETO)
        {
            List<BE.SIC_CONFIGOBJETO> lista = new List<BE.SIC_CONFIGOBJETO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_CONFIGOBJE.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE",  entSIC_CONFIGOBJETO.CODCLASE);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE",  entSIC_CONFIGOBJETO.CODSUBCLASE);
            db.SetParameterValue(dbCommand, "pvcCODOBJETO", entSIC_CONFIGOBJETO.CODOBJETO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONFIGOBJETO(reader, BE.SIC_CONFIGOBJETO.Query.Listar));
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
