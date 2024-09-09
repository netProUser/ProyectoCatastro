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
    public class SIC_UNIDADTITULAR : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADTITULAR, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADTITULAR.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADTITULAR.CODUNI);
            db.AddInParameter(dbCommand, "pvcNUMPORCTITU", DbType.Decimal, entSIC_UNIDADTITULAR.NUMPORCTITU);
            db.AddInParameter(dbCommand, "pvcCODCONDTITU", DbType.String, entSIC_UNIDADTITULAR.CODCONDTITU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADTITULAR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADTITULAR.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCONTRIBUYENTE", DbType.String, entSIC_UNIDADTITULAR.CODCONTRIBUYENTE);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                //entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCONTRIBUYENTE"));
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
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADTITULAR.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADTITULAR.CODUNI);
            db.AddInParameter(dbCommand, "pvcNUMPORCTITU", DbType.Decimal, entSIC_UNIDADTITULAR.NUMPORCTITU);
            db.AddInParameter(dbCommand, "pvcCODCONDTITU", DbType.String, entSIC_UNIDADTITULAR.CODCONDTITU);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADTITULAR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADTITULAR.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCONTRIBUYENTE", DbType.String, entSIC_UNIDADTITULAR.CODCONTRIBUYENTE);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_UNIDADTITULAR Recuperar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_UNIDADTITULAR lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADTITULAR.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCONTRIBUYENTE", entSIC_UNIDADTITULAR.CODCONTRIBUYENTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADTITULAR(reader, BE.SIC_UNIDADTITULAR.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADTITULAR.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADTITULAR.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCONTRIBUYENTE", DbType.String, entSIC_UNIDADTITULAR.CODCONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADTITULAR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADTITULAR.TXTIPREG);
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
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registros de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADTITULAR> Listar(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            List<BE.SIC_UNIDADTITULAR> lista = new List<BE.SIC_UNIDADTITULAR>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADTITULAR.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADTITULAR.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);  

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADTITULAR.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADTITULAR(reader, BE.SIC_UNIDADTITULAR.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADTITULAR> CargarUnidadTitularHistoricas(BE.SIC_UNIDADTITULAR entSIC_UNIDADOBSERVACION)
        {
            List<BE.SIC_UNIDADTITULAR> lista = new List<BE.SIC_UNIDADTITULAR>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERTITULDHISTORICO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADOBSERVACION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADOBSERVACION.NUMVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADTITULAR(reader, BE.SIC_UNIDADTITULAR.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (18/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADTITULAR.ListarRentas
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registros de la tabla SIC_UNIDADTITULAR
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADTITULAR> ListarRentas(BE.SIC_UNIDADTITULAR entSIC_UNIDADTITULAR)
        {
            List<BE.SIC_UNIDADTITULAR> lista = new List<BE.SIC_UNIDADTITULAR>();

            Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("MSISAT.PKGSAT_CONTRIBUYENTE.PS_CONSULTACATASTRO", new object[6]);PS_CONSULTACATASTROCONTRIB
            DbCommand dbCommand = db.GetStoredProcCommand("MSISAT.PKGSAT_CONTRIBUYENTE.PS_CONSULTACATASTROPROP", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODCONTRIBUYENTE", entSIC_UNIDADTITULAR.CODCONTRIBUYENTE);
            db.SetParameterValue(dbCommand, "pvcCODTIPOPERSONA", entSIC_UNIDADTITULAR.CODTIPODOCIDENTIDAD);
            db.SetParameterValue(dbCommand, "pvcTXTDOCIDENTIDAD", entSIC_UNIDADTITULAR.TXTDOCIDENTIDAD);
            db.SetParameterValue(dbCommand, "pvcTXTRAZONSOCIAL", entSIC_UNIDADTITULAR.TXTRAZONSOCIAL);
            //db.SetParameterValue(dbCommand, "pvcCODCATASTRAL", entSIC_UNIDADTITULAR.CODCATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADTITULAR(reader, BE.SIC_UNIDADTITULAR.Query.ListarRentas));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

    }
}
