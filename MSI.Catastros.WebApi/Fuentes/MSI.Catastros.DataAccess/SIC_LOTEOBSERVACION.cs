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
    public class SIC_LOTEOBSERVACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEOBSERVACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEOBSERVACION.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEOBSERVACION.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEOBSERVACION.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTEOBSERVACION.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcFECOBSERVACION", DbType.Date, entSIC_LOTEOBSERVACION.FECOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEOBSERVACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORROBSE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORROBSE"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEOBSERVACION.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEOBSERVACION.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEOBSERVACION.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTEOBSERVACION.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcFECOBSERVACION", DbType.Date, entSIC_LOTEOBSERVACION.FECOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEOBSERVACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORROBSE", DbType.String, entSIC_LOTEOBSERVACION.CODCORROBSE);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_LOTEOBSERVACION Recuperar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_LOTEOBSERVACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEOBSERVACION.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEOBSERVACION.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEOBSERVACION.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODCORROBSE", entSIC_LOTEOBSERVACION.CODCORROBSE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEOBSERVACION(reader, BE.SIC_LOTEOBSERVACION.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEOBSERVACION.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEOBSERVACION.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEOBSERVACION.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORROBSE", DbType.String, entSIC_LOTEOBSERVACION.CODCORROBSE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEOBSERVACION.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (25/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public IEnumerable<BE.SIC_LOTEOBSERVACION> Buscar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            List<BE.SIC_LOTEOBSERVACION> lista = new List<BE.SIC_LOTEOBSERVACION>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEOBSERVACION.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEOBSERVACION.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEOBSERVACION.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcTXTOBSERVACION", entSIC_LOTEOBSERVACION.TXTOBSERVACION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTEOBSERVACION.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_LOTEOBSERVACION.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_LOTEOBSERVACION.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEOBSERVACION(reader, BE.SIC_LOTEOBSERVACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (25/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEOBSERVACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public IEnumerable<BE.SIC_LOTEOBSERVACION> Listar(BE.SIC_LOTEOBSERVACION entSIC_LOTEOBSERVACION)
        {
            List<BE.SIC_LOTEOBSERVACION> lista = new List<BE.SIC_LOTEOBSERVACION>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEOBSERVACION.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_LISTAR" : ".PKG_MSISIC_PROC_LOTEOBSERVACIO.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEOBSERVACION.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEOBSERVACION.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEOBSERVACION.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEOBSERVACION.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEOBSERVACION.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEOBSERVACION.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcTXTOBSERVACION", entSIC_LOTEOBSERVACION.TXTOBSERVACION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTEOBSERVACION.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEOBSERVACION(reader, BE.SIC_LOTEOBSERVACION.Query.Listar));
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
