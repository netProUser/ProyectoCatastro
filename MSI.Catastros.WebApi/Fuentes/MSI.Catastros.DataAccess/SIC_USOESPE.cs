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
    public class SIC_USOESPE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: BusinessLogic.SIC_USOESPE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOESPE
        /// </summary>
        public IEnumerable<BE.SIC_USOESPE> Listar()
        {
            List<BE.SIC_USOESPE> lista = new List<BE.SIC_USOESPE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_LISTAR_TMP", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOESPE(reader, BE.SIC_USOESPE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_USOESPE> Buscar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            List<BE.SIC_USOESPE> lista = new List<BE.SIC_USOESPE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODUSOESPE", entSIC_USOESPE.CODUSOESPE);
            db.SetParameterValue(dbCommand, "pvcTXTUSOESPE", entSIC_USOESPE.TXTUSOESPE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_USOESPE.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_USOESPE.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_USOESPE.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOESPE(reader, BE.SIC_USOESPE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_USOESPE BuscarInt(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_USOESPE lista = new BE.SIC_USOESPE();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_USOESPE.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcTXTUSOESPE", DbType.String, entSIC_USOESPE.TXTUSOESPE);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_USOESPE.PAGINAREGISTROS);
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
        public BE.SIC_USOESPE Recuperar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_USOESPE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUSOESPE", entSIC_USOESPE.CODUSOESPE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_USOESPE(reader, BE.SIC_USOESPE.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_USOESPE.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcTXTUSOESPE", DbType.String, entSIC_USOESPE.TXTUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOESPE.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODUSOESPE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODUSOESPE"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_USOESPE.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_USOESPE.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcTXTUSOESPE", DbType.String, entSIC_USOESPE.TXTUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOESPE.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOESPE entSIC_USOESPE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_USOESPE.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOESPE.CODUSUARIO);
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
