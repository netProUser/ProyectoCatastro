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
    public class SIC_PUERTA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_PUERTA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PUERTA
        /// </summary>
        public IEnumerable<BE.SIC_PUERTA> Listar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            List<BE.SIC_PUERTA> lista = new List<BE.SIC_PUERTA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_LISTAR", new object[1]);
            //db.SetParameterValue(dbCommand, "pvcCODTIPOINSP", entSIC_PUERTA.CODTIPOINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PUERTA(reader, BE.SIC_PUERTA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_PUERTA> Buscar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            List<BE.SIC_PUERTA> lista = new List<BE.SIC_PUERTA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOPUER", entSIC_PUERTA.CODTIPOPUER);
            db.SetParameterValue(dbCommand, "pvcTXTDESCRIPCION", entSIC_PUERTA.TXTDESCRIPCION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_PUERTA.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_PUERTA.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_PUERTA.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PUERTA(reader, BE.SIC_PUERTA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_PUERTA BuscarInt(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_PUERTA lista = new BE.SIC_PUERTA();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_PUERTA.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_PUERTA.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_PUERTA.PAGINAREGISTROS);
            db.AddOutParameter(dbCommand, "pinTOTPAG", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pinTOTREG", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                lista.TOTALPAGINAS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTPAG"));
                lista.TOTALREGISTROS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTREG"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_PUERTA Recuperar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_PUERTA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOPUER", entSIC_PUERTA.CODTIPOPUER);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_PUERTA(reader, BE.SIC_PUERTA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_PUERTA.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVI", DbType.String, entSIC_PUERTA.TXTABREVI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PUERTA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, 2);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODTIPOPUER"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_PUERTA.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_PUERTA.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVI", DbType.String, entSIC_PUERTA.TXTABREVI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PUERTA.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_PUERTA entSIC_PUERTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_PUERTA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_PUERTA.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PUERTA.CODUSUARIO);
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
    }
}
