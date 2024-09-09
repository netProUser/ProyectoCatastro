using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
namespace MSI.Catastros.DataAccess
{
    public class SIC_DOCISO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCISO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Grabar(BE.SIC_DOCISO entSIC_DOCISO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DOCISO.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_DOCISO.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_DOCISO.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCISO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCISO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_RETORNO Actualizar(BE.SIC_DOCISO entSIC_DOCISO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DOCISO.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDOCCAT", DbType.String, entSIC_DOCISO.CODDOCCAT);
            db.AddInParameter(dbCommand, "pvcCODTIPODOC", DbType.String, entSIC_DOCISO.CODTIPODOC);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_DOCISO.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCISO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCISO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DOCISO, retorna numero de ERROR o ID generado
        /// </summary>
        /// <param name="entSIC_DOCISO"></param>
        /// <returns></returns>
        public BE.SIC_RETORNO Eliminar(BE.SIC_DOCISO entSIC_DOCISO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DOCISO.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDOCCAT", DbType.String, entSIC_DOCISO.CODDOCCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCISO.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCISO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public BE.SIC_DOCISO Recuperar(BE.SIC_DOCISO entSIC_DOCISO)
        {
            BE.SIC_DOCISO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DOCISO.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODDOCCAT", entSIC_DOCISO.CODDOCCAT);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_DOCISO(reader, BE.SIC_DOCISO.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCISO.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        public IEnumerable<BE.SIC_DOCISO> Listar(BE.SIC_DOCISO entSIC_DOCISO)
        {
            List<BE.SIC_DOCISO> lista = new List<BE.SIC_DOCISO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DOCISO.PRC_LISTAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_DOCISO.CODTIPODOC);
            db.SetParameterValue(dbCommand, "pvcTXTDESCRIPCION", entSIC_DOCISO.TXTDESCRIPCION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_DOCISO(reader, BE.SIC_DOCISO.Query.Listar));
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
