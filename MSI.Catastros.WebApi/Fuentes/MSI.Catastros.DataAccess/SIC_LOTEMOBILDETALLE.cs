using System;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;


namespace MSI.Catastros.DataAccess
{
    public class SIC_LOTEMOBILDETALLE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILDETALLE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILDETAL.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMOBILDETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMOBILDETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMOBILDETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMOBILDETALLE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMOBILDETALLE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMOBILDETALLE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMOBILDETALLE.CORRELURBA);
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_LOTEMOBILDETALLE.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcCODCONFOBJETO", DbType.String, entSIC_LOTEMOBILDETALLE.CODCONFOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTVALOR", DbType.String, entSIC_LOTEMOBILDETALLE.TXTVALOR);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILDETALLE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILDETALLE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILDETAL.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMOBILDETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMOBILDETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMOBILDETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMOBILDETALLE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMOBILDETALLE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMOBILDETALLE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMOBILDETALLE.CORRELURBA);
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODSUBCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODSUBCLASE);
            db.AddInParameter(dbCommand, "pvcCODCORSCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODCONFOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTVALOR", DbType.String, entSIC_LOTEMOBILDETALLE.TXTVALOR);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILDETALLE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILDETALLE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMOBILDETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_LOTEMOBILDETALLE"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILDETAL.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCLASE", DbType.String, entSIC_LOTEMOBILDETALLE.CODCLASE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILDETALLE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILDETALLE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_LOTEMOBILDETALLE Recuperar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            BE.SIC_LOTEMOBILDETALLE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILDETAL.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_LOTEMOBILDETALLE.CODCLASE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEMOBILDETALLE(reader, BE.SIC_LOTEMOBILDETALLE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILDETALLE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_LOTEMOBILDETALLE> Listar(BE.SIC_LOTEMOBILDETALLE entSIC_LOTEMOBILDETALLE)
        {
            List<BE.SIC_LOTEMOBILDETALLE> lista = new List<BE.SIC_LOTEMOBILDETALLE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILDETAL.PRC_LISTAR", new object[12]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEMOBILDETALLE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEMOBILDETALLE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEMOBILDETALLE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEMOBILDETALLE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEMOBILDETALLE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEMOBILDETALLE.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCORRELURBA", entSIC_LOTEMOBILDETALLE.CORRELURBA);
            db.SetParameterValue(dbCommand, "pvcCODCLASE", entSIC_LOTEMOBILDETALLE.CODCLASE);
            db.SetParameterValue(dbCommand, "pvcCODSUBCLASE", entSIC_LOTEMOBILDETALLE.CODSUBCLASE);
            db.SetParameterValue(dbCommand, "pvcCODOBJETO", entSIC_LOTEMOBILDETALLE.CODOBJETO);
            db.SetParameterValue(dbCommand, "pvcCODCONFOBJETO", entSIC_LOTEMOBILDETALLE.CODCONFOBJETO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEMOBILDETALLE(reader, BE.SIC_LOTEMOBILDETALLE.Query.Listar));
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
