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
    public class SIC_MOVINSPEC : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MOVINSPEC, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_MOVINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_MOVINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_MOVINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_MOVINSPEC.CTIPODOCUMENTO);

            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_MOVINSPEC.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_MOVINSPEC.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_MOVINSPEC.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MOVINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_MOVINSPEC.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcFLAGRESPONSABLE", DbType.String, entSIC_MOVINSPEC.FLAGRESPONSABLE);
            db.AddOutParameter(dbCommand, "pvcCODCORRELINSP", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELINSP"));
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
        //Creado por	: Pedro Peña Salazar (23/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_MOVINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_MOVINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_MOVINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_MOVINSPEC.CTIPODOCUMENTO);

            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_MOVINSPEC.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_MOVINSPEC.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_MOVINSPEC.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MOVINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_MOVINSPEC.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRELINSP", DbType.String, entSIC_MOVINSPEC.CODCORRELINSP);
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
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_MOVINSPEC Recuperar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_MOVINSPEC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_MOVINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_MOVINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_MOVINSPEC.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_MOVINSPEC.CODNROINSPEC);
            db.SetParameterValue(dbCommand, "pvcCODCORRELINSP", entSIC_MOVINSPEC.CODCORRELINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_MOVINSPEC(reader, BE.SIC_MOVINSPEC.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MOVINSPEC
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_MOVINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_MOVINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_MOVINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_MOVINSPEC.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MOVINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_MOVINSPEC.TXTIPREG);
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
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MOVINSPEC
        /// </summary>
        public IEnumerable<BE.SIC_MOVINSPEC> Listar(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lista = new List<BE.SIC_MOVINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_LISTAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_MOVINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_MOVINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_MOVINSPEC.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_MOVINSPEC.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MOVINSPEC(reader, BE.SIC_MOVINSPEC.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_MOVINSPEC> ListarInforme(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lista = new List<BE.SIC_MOVINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_LISTAR_INFORME", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_MOVINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_MOVINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_MOVINSPEC.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_MOVINSPEC.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MOVINSPEC(reader, BE.SIC_MOVINSPEC.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MOVINSPEC.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MOVINSPEC
        /// </summary>
        public IEnumerable<BE.SIC_MOVINSPEC> Inspectores(BE.SIC_MOVINSPEC entSIC_MOVINSPEC)
        {
            List<BE.SIC_MOVINSPEC> lista = new List<BE.SIC_MOVINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_MOVINSPEC.PRC_INSPECTORES", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCARCAT", entSIC_MOVINSPEC.CODCARCAT);
            db.SetParameterValue(dbCommand, "pvcFECINSPE", entSIC_MOVINSPEC.FECINSPE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MOVINSPEC(reader, BE.SIC_MOVINSPEC.Query.Inspectores));
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
