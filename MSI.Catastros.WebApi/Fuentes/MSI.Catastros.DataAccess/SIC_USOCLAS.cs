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
    public class SIC_USOCLAS : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: BusinessLogic.SIC_USOCLAS.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOCLAS
        /// </summary>
        public IEnumerable<BE.SIC_USOCLAS> Listar()
        {
            List<BE.SIC_USOCLAS> lista = new List<BE.SIC_USOCLAS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_LISTAR", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOCLAS(reader, BE.SIC_USOCLAS.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_USOCLAS> Buscar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            List<BE.SIC_USOCLAS> lista = new List<BE.SIC_USOCLAS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_BUSCAR", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODUSOGENE", entSIC_USOCLAS.CODUSOGENE);
            db.SetParameterValue(dbCommand, "pvcCODUSOCLAS", entSIC_USOCLAS.CODUSOCLAS);
            db.SetParameterValue(dbCommand, "pvcTXTUSOCLAS", entSIC_USOCLAS.TXTUSOCLAS);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_USOCLAS.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_USOCLAS.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_USOCLAS.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOCLAS(reader, BE.SIC_USOCLAS.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_USOCLAS BuscarInt(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_USOCLAS lista = new BE.SIC_USOCLAS();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_BUSCAR_INT");
            db.SetParameterValue(dbCommand, "pvcCODUSOGENE", entSIC_USOCLAS.CODUSOGENE);
            db.SetParameterValue(dbCommand, "pvcCODUSOCLAS", entSIC_USOCLAS.CODUSOCLAS);
            db.SetParameterValue(dbCommand, "pvcTXTUSOCLAS", entSIC_USOCLAS.TXTUSOCLAS);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_USOCLAS.PAGINAREGISTROS);
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
        public BE.SIC_USOCLAS Recuperar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_USOCLAS lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUSOGENE", entSIC_USOCLAS.CODUSOGENE);
            db.SetParameterValue(dbCommand, "pvcCODUSOCLAS", entSIC_USOCLAS.CODUSOCLAS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_USOCLAS(reader, BE.SIC_USOCLAS.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOCLAS.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTUSOCLAS", DbType.String, entSIC_USOCLAS.TXTUSOCLAS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOCLAS.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODUSOCLAS"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_USOCLAS.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOCLAS.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTUSOCLAS", DbType.String, entSIC_USOCLAS.TXTUSOCLAS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOCLAS.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOCLAS entSIC_USOCLAS)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOCLAS.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODUSOCLAS", DbType.String, entSIC_USOCLAS.CODUSOCLAS);
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOCLAS.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOCLAS.CODUSUARIO);
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
