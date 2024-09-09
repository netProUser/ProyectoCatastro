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
    public class SIC_LOTERRPP : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERRPP.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTERRPP, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERRPP.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTERRPP.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERRPP.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERRPP.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERRPP.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERRPP.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERRPP.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERRPP.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_LOTERRPP.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTPARTELEC", DbType.String, entSIC_LOTERRPP.TXTPARTELEC);
            db.AddInParameter(dbCommand, "pvcTXTTOMOFICH", DbType.String, entSIC_LOTERRPP.TXTTOMOFICH);
            db.AddInParameter(dbCommand, "pvcTXTFOLIO", DbType.String, entSIC_LOTERRPP.TXTFOLIO);
            db.AddInParameter(dbCommand, "pvcTXTASIENTO", DbType.String, entSIC_LOTERRPP.TXTASIENTO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_LOTERRPP.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_LOTERRPP.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_LOTERRPP.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERRPP.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTERRPP"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTERRPP.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERRPP.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTERRPP.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERRPP.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERRPP.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERRPP.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERRPP.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERRPP.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERRPP.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODTIPODOCU", DbType.String, entSIC_LOTERRPP.CODTIPODOCU);
            db.AddInParameter(dbCommand, "pvcTXTPARTELEC", DbType.String, entSIC_LOTERRPP.TXTPARTELEC);
            db.AddInParameter(dbCommand, "pvcTXTTOMOFICH", DbType.String, entSIC_LOTERRPP.TXTTOMOFICH);
            db.AddInParameter(dbCommand, "pvcTXTFOLIO", DbType.String, entSIC_LOTERRPP.TXTFOLIO);
            db.AddInParameter(dbCommand, "pvcTXTASIENTO", DbType.String, entSIC_LOTERRPP.TXTASIENTO);
            db.AddInParameter(dbCommand, "pvcFECDOCUMENTO", DbType.Date, entSIC_LOTERRPP.FECDOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_LOTERRPP.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_LOTERRPP.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERRPP.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, entSIC_LOTERRPP.CODCORRLOTERRPP);
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
        //Utilizado por	: BusinessLogic.SIC_LOTERRPP.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_LOTERRPP Recuperar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_LOTERRPP lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERRPP.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTERRPP.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTERRPP.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTERRPP.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTERRPP.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTERRPP.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTERRPP.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTERRPP.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODCORRLOTERRPP", entSIC_LOTERRPP.CODCORRLOTERRPP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTERRPP(reader, BE.SIC_LOTERRPP.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTERRPP.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTERRPP
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERRPP.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTERRPP.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERRPP.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERRPP.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERRPP.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERRPP.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERRPP.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERRPP.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERRPP", DbType.String, entSIC_LOTERRPP.CODCORRLOTERRPP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERRPP.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERRPP.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTERRPP
        /// </summary>
        public IEnumerable<BE.SIC_LOTERRPP> Buscar(BE.SIC_LOTERRPP entSIC_LOTERRPP)
        {
            List<BE.SIC_LOTERRPP> lista = new List<BE.SIC_LOTERRPP>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERRPP.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERRPP.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTERRPP.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTERRPP.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTERRPP.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTERRPP.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTERRPP.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTERRPP.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTERRPP.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTERRPP.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTERRPP(reader, BE.SIC_LOTERRPP.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_LOTERRPP> CargarLoteOtrosDocumentos(BE.SIC_LOTERRPP entSIC_LOTE)
        {
            List<BE.SIC_LOTERRPP> lista = new List<BE.SIC_LOTERRPP>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_OTROSDOC" : ".PKG_MSISIC_PROC_LOTEDOCADI.PRC_OTROSDOC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTE.CODLOTE);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTERRPP(reader, BE.SIC_LOTERRPP.Query.ListarOtrosDocumentos));
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
