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
    public class SIC_LOTERETIRO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (06/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public IEnumerable<BE.SIC_LOTERETIRO> Buscar(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            List<BE.SIC_LOTERETIRO> lista = new List<BE.SIC_LOTERETIRO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTERETIRO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTERETIRO.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTERETIRO.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTERETIRO.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTERETIRO.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTERETIRO(reader, BE.SIC_LOTERETIRO.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTERETIRO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERETIRO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERETIRO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERETIRO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERETIRO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERETIRO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTERETIRO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTERETIRO.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMRETIMUNI", DbType.Decimal, entSIC_LOTERETIRO.NUMRETIMUNI);
            db.AddInParameter(dbCommand, "pvcNUMJARDAISL", DbType.Decimal, entSIC_LOTERETIRO.NUMJARDAISL);
            db.AddInParameter(dbCommand, "pvcNUMVEREDA", DbType.Decimal, entSIC_LOTERETIRO.NUMVEREDA);
            db.AddInParameter(dbCommand, "pvcNUMBERMA", DbType.Decimal, entSIC_LOTERETIRO.NUMBERMA);
            db.AddInParameter(dbCommand, "pvcNUMPISTA", DbType.Decimal, entSIC_LOTERETIRO.NUMPISTA);
            db.AddInParameter(dbCommand, "pvcNUMANCHVIA", DbType.Decimal, entSIC_LOTERETIRO.NUMANCHVIA);
            db.AddInParameter(dbCommand, "pvcFLGOCUPRETI", DbType.String, entSIC_LOTERETIRO.FLGOCUPRETI);
            db.AddInParameter(dbCommand, "pvcFLGOCUPJARD", DbType.String, entSIC_LOTERETIRO.FLGOCUPJARD);
            db.AddInParameter(dbCommand, "pvcCODDESCRETI", DbType.String, entSIC_LOTERETIRO.CODDESCRETI);
            db.AddInParameter(dbCommand, "pvcCODDESCJARD", DbType.String, entSIC_LOTERETIRO.CODDESCJARD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERETIRO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLOTERETI", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTERETI"));
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTERETIRO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERETIRO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERETIRO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERETIRO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERETIRO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERETIRO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTERETIRO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTERETIRO.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMRETIMUNI", DbType.Decimal, entSIC_LOTERETIRO.NUMRETIMUNI);
            db.AddInParameter(dbCommand, "pvcNUMJARDAISL", DbType.Decimal, entSIC_LOTERETIRO.NUMJARDAISL);
            db.AddInParameter(dbCommand, "pvcNUMVEREDA", DbType.Decimal, entSIC_LOTERETIRO.NUMVEREDA);
            db.AddInParameter(dbCommand, "pvcNUMBERMA", DbType.Decimal, entSIC_LOTERETIRO.NUMBERMA);
            db.AddInParameter(dbCommand, "pvcNUMPISTA", DbType.Decimal, entSIC_LOTERETIRO.NUMPISTA);
            db.AddInParameter(dbCommand, "pvcNUMANCHVIA", DbType.Decimal, entSIC_LOTERETIRO.NUMANCHVIA);
            db.AddInParameter(dbCommand, "pvcFLGOCUPRETI", DbType.String, entSIC_LOTERETIRO.FLGOCUPRETI);
            db.AddInParameter(dbCommand, "pvcFLGOCUPJARD", DbType.String, entSIC_LOTERETIRO.FLGOCUPJARD);
            db.AddInParameter(dbCommand, "pvcCODDESCRETI", DbType.String, entSIC_LOTERETIRO.CODDESCRETI);
            db.AddInParameter(dbCommand, "pvcCODDESCJARD", DbType.String, entSIC_LOTERETIRO.CODDESCJARD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERETIRO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERETI", DbType.String, entSIC_LOTERETIRO.CODCORRLOTERETI);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTERETIRO
        /// </summary>
        public BE.SIC_LOTERETIRO Recuperar(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            BE.SIC_LOTERETIRO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTERETIRO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTERETIRO.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTERETIRO.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTERETIRO.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTERETIRO.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTERETIRO.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTERETIRO.CODCORRMANZVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRLOTERETI", entSIC_LOTERETIRO.CODCORRLOTERETI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTERETIRO(reader, BE.SIC_LOTERETIRO.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTERETIRO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERETIRO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERETIRO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERETIRO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERETIRO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERETIRO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTERETIRO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTERETIRO.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTERETI", DbType.String, entSIC_LOTERETIRO.CODCORRLOTERETI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERETIRO.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTERETIRO.EliminarVias
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTERETIRO
        /// </summary>
        public BE.SIC_RETORNO EliminarVias(BE.SIC_LOTERETIRO entSIC_LOTERETIRO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTERETIRO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTERETIRO.PRC_ELIMINARVIAS" : ".PKG_MSISIC_PROC_LOTERETIRO.PRC_ELIMINARVIAS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTERETIRO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTERETIRO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTERETIRO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTERETIRO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTERETIRO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTERETIRO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTERETIRO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTERETIRO.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTERETIRO.CODUSUARIO);
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
