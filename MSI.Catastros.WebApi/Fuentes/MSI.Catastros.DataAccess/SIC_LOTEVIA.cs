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
    public class SIC_LOTEVIA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEVIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEVIA
        /// </summary>
        public IEnumerable<BE.SIC_LOTEVIA> Buscar(BE.SIC_LOTEVIA entSIC_LOTEVIA)
        {
            List<BE.SIC_LOTEVIA> lista = new List<BE.SIC_LOTEVIA>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEVIA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEVIA.PRC_BUSCAR_VIAS" : ".PKG_MSISIC_PROC_LOTEVIA.PRC_BUSCAR_VIAS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEVIA.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEVIA(reader, BE.SIC_LOTEVIA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEVIA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEVIA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEVIA entSIC_LOTEVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEVIA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEVIA.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEVIA.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEVIA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMRETIMUNI", DbType.Int32, entSIC_LOTEVIA.NUMRETIMUNI);
            db.AddInParameter(dbCommand, "pvcMUNJARDAISL", DbType.Int32, entSIC_LOTEVIA.MUNJARDAISL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEVIA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            //db.AddOutParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTERRPP"));
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
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEVIA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEVIA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEVIA entSIC_LOTEVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEVIA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEVIA.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEVIA.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEVIA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMRETIMUNI", DbType.Int32, entSIC_LOTEVIA.NUMRETIMUNI);
            db.AddInParameter(dbCommand, "pvcMUNJARDAISL", DbType.Int32, entSIC_LOTEVIA.MUNJARDAISL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEVIA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            //db.AddInParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, entSIC_LOTEVIA.CODCORRLOTERRPP);
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
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEVIA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEVIA
        /// </summary>
        public BE.SIC_LOTEVIA Recuperar(BE.SIC_LOTEVIA entSIC_LOTEVIA)
        {
            BE.SIC_LOTEVIA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEVIA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEVIA.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEVIA.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEVIA.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTEVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTEVIA.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEVIA(reader, BE.SIC_LOTEVIA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEVIA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEVIA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEVIA entSIC_LOTEVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEVIA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEVIA.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEVIA.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);

            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEVIA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEVIA.CODUSUARIO);
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
    }
}
