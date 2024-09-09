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
    public class SIC_UNIDBIENCOMUN : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: BusinessLogic.SIC_UNIDBIENCOMUN.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDBIENCOMUN, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDBIENCOMUN.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCATASTRAL", DbType.String, entSIC_UNIDBIENCOMUN.CODUNIDADCATASTRAL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDBIENCOMUN.TXTIPREG);
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
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: BusinessLogic.SIC_UNIDBIENCOMUN.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDBIENCOMUN.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcNUMPOROFI", DbType.Decimal, entSIC_UNIDBIENCOMUN.NUMPOROFI);
            db.AddInParameter(dbCommand, "pvcNUMATECOM", DbType.Decimal, entSIC_UNIDBIENCOMUN.NUMATECOM);
            db.AddInParameter(dbCommand, "pvcFLGINDEP", DbType.String, entSIC_UNIDBIENCOMUN.FLGINDEP);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCATASTRAL", DbType.String, entSIC_UNIDBIENCOMUN.CODUNIDADCATASTRAL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: BusinessLogic.SIC_UNIDBIENCOMUN.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_UNIDBIENCOMUN Recuperar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_UNIDBIENCOMUN lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_DATOS", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDBIENCOMUN.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODBIENCOMUN", entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDBIENCOMUN(reader, BE.SIC_UNIDBIENCOMUN.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_UNIDBIENCOMUN Filtrar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_UNIDBIENCOMUN lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_FILTRAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDBIENCOMUN.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDBIENCOMUN(reader, BE.SIC_UNIDBIENCOMUN.Query.Filtrar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: BusinessLogic.SIC_UNIDBIENCOMUN.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDBIENCOMUN.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.String, entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDBIENCOMUN.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDBIENCOMUN.TXTIPREG);
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
        //Creado por	: Pedro Peña Salazar(18/01/2019)
        //Utilizado por	: BusinessLogic.SIC_UNIDBIENCOMUN.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDBIENCOMUN
        /// </summary>
        public IEnumerable<BE.SIC_UNIDBIENCOMUN> Listar(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            List<BE.SIC_UNIDBIENCOMUN> lista = new List<BE.SIC_UNIDBIENCOMUN>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDBIENCOMUN.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADBIENCOM.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDBIENCOMUN.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODBIENCOMUN", entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDBIENCOMUN(reader, BE.SIC_UNIDBIENCOMUN.Query.Listar));
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
