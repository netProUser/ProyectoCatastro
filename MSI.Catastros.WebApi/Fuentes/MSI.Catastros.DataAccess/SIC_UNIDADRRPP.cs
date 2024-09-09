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
    public class SIC_UNIDADRRPP : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADRRPP.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADRRPP, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADRRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADRRPP.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADRRPP.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADRRPP.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADRRPP.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADRRPP.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADRRPP.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADRRPP.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, entSIC_UNIDADRRPP.CODCORRLOTERRPP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADRRPP.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADRRPP.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDRRPP", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDRRPP"));
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADRRPP.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADRRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADRRPP.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_UNIDADRRPP.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTPARTELEC", DbType.String, entSIC_UNIDADRRPP.TXTPARTELEC);
            db.AddInParameter(dbCommand, "pvcTXTTOMOFICH", DbType.String, entSIC_UNIDADRRPP.TXTTOMOFICH);
            db.AddInParameter(dbCommand, "pvcTXTFOLIO", DbType.String, entSIC_UNIDADRRPP.TXTFOLIO);
            db.AddInParameter(dbCommand, "pvcTXTASIENTO", DbType.String, entSIC_UNIDADRRPP.TXTASIENTO);
            db.AddInParameter(dbCommand, "pvcFECREGIPUBL", DbType.Date, entSIC_UNIDADRRPP.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADRRPP.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADRRPP.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDRRPP", DbType.String, entSIC_UNIDADRRPP.CODCORRUNIDRRPP);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADRRPP.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_UNIDADRRPP Recuperar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_UNIDADRRPP lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADRRPP.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDRRPP", entSIC_UNIDADRRPP.CODCORRUNIDRRPP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADRRPP(reader, BE.SIC_UNIDADRRPP.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADRRPP.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADRRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDADRRPP.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDRRPP", DbType.String, entSIC_UNIDADRRPP.CODCORRUNIDRRPP);

            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADRRPP.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADRRPP.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADRRPP.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADRRPP.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADRRPP.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADRRPP.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, entSIC_UNIDADRRPP.CODCORRLOTERRPP);

            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADRRPP.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADRRPP.TXTIPREG);
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
        //Creado por	: Juan Quispe Ipanaque (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADRRPP.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADRRPP
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADRRPP> Listar(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            List<BE.SIC_UNIDADRRPP> lista = new List<BE.SIC_UNIDADRRPP>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADRRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADRRPP.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADRRPP.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADRRPP(reader, BE.SIC_UNIDADRRPP.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADRRPP> CargarUnidadRRPPHistorica(BE.SIC_UNIDADRRPP entSIC_UNIDADRRPP)
        {
            List<BE.SIC_UNIDADRRPP> lista = new List<BE.SIC_UNIDADRRPP>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERRRPPHISTORICA";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADRRPP.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADRRPP.NUMVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADRRPP(reader, BE.SIC_UNIDADRRPP.Query.Listar));
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
