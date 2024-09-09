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
    public class SIC_USOGENE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (09/07/2018)
        //Utilizado por	: BusinessLogic.SIC_USOGENE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_USOGENE
        /// </summary>
        public IEnumerable<BE.SIC_USOGENE> Listar()
        {
            List<BE.SIC_USOGENE> lista = new List<BE.SIC_USOGENE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_LISTAR_TMP", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOGENE(reader, BE.SIC_USOGENE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_USOGENE> Buscar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            List<BE.SIC_USOGENE> lista = new List<BE.SIC_USOGENE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_BUSCAR", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODUSOGENE", entSIC_USOGENE.CODUSOGENE);
            db.SetParameterValue(dbCommand, "pvcTXTUSOGENE", entSIC_USOGENE.TXTUSOGENE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_USOGENE.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_USOGENE.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_USOGENE.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_USOGENE(reader, BE.SIC_USOGENE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_USOGENE BuscarInt(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_USOGENE lista = new BE.SIC_USOGENE();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOGENE.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTUSOGENE", DbType.String, entSIC_USOGENE.TXTUSOGENE);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_USOGENE.PAGINAREGISTROS);
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
        public BE.SIC_USOGENE Recuperar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_USOGENE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUSOGENE", entSIC_USOGENE.CODUSOGENE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_USOGENE(reader, BE.SIC_USOGENE.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTUSOGENE", DbType.String, entSIC_USOGENE.TXTUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTCODANTE", DbType.String, entSIC_USOGENE.TXTCODANTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOGENE.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODUSOGENE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODUSOGENE"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOGENE.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTUSOGENE", DbType.String, entSIC_USOGENE.TXTUSOGENE);
            db.AddInParameter(dbCommand, "pvcTXTCODANTE", DbType.String, entSIC_USOGENE.TXTCODANTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOGENE.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_USOGENE entSIC_USOGENE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_USOESPE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODUSOGENE", DbType.String, entSIC_USOGENE.CODUSOGENE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_USOGENE.CODUSUARIO);
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
