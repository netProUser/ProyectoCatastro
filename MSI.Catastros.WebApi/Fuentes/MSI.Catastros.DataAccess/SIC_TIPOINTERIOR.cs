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
    public class SIC_TIPOINTERIOR : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (29/05/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOLLENA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOLLENA
        /// </summary>
        public IEnumerable<BE.SIC_TIPOINTERIOR> Listar()
        {
            List<BE.SIC_TIPOINTERIOR> lista = new List<BE.SIC_TIPOINTERIOR>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_LISTAR", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPOINTERIOR(reader, BE.SIC_TIPOINTERIOR.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_TIPOINTERIOR> Buscar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            List<BE.SIC_TIPOINTERIOR> lista = new List<BE.SIC_TIPOINTERIOR>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINTE", entSIC_TIPOINTERIOR.CODTIPOINTE);
            db.SetParameterValue(dbCommand, "pvcTXTDESCRIPCION", entSIC_TIPOINTERIOR.TXTDESCRIPCION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_TIPOINTERIOR.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_TIPOINTERIOR.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_TIPOINTERIOR.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPOINTERIOR(reader, BE.SIC_TIPOINTERIOR.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_TIPOINTERIOR BuscarInt(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_TIPOINTERIOR lista = new BE.SIC_TIPOINTERIOR();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, entSIC_TIPOINTERIOR.CODTIPOINTE);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_TIPOINTERIOR.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_TIPOINTERIOR.PAGINAREGISTROS);
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
        public BE.SIC_TIPOINTERIOR Recuperar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_TIPOINTERIOR lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINTE", entSIC_TIPOINTERIOR.CODTIPOINTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TIPOINTERIOR(reader, BE.SIC_TIPOINTERIOR.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_TIPOINTERIOR.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVANT", DbType.String, entSIC_TIPOINTERIOR.TXTABREVANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOINTERIOR.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODTIPOINTE"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, entSIC_TIPOINTERIOR.CODTIPOINTE);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_TIPOINTERIOR.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVANT", DbType.String, entSIC_TIPOINTERIOR.TXTABREVANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOINTERIOR.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_TIPOINTERIOR entSIC_TIPOINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_TIPOINTERIOR.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, entSIC_TIPOINTERIOR.CODTIPOINTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOINTERIOR.CODUSUARIO);
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
