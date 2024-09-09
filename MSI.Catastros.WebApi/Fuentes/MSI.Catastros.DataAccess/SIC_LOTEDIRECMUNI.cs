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
    public class SIC_LOTEDIRECMUNI : Base
    {

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (05/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public IEnumerable<BE.SIC_LOTEDIRECMUNI> Buscar(BE.SIC_LOTEDIRECMUNI entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTEDIRECMUNI> lista = new List<BE.SIC_LOTEDIRECMUNI>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEDIRECMUNI(reader, BE.SIC_LOTEDIRECMUNI.Query.Buscar));
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
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEDIRECMUNI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDIRECMUNI.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTLETRA", DbType.String, entSIC_LOTEDIRECMUNI.TXTLETRA);
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcCODTIPOASIG", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOASIG);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_LOTEDIRECMUNI.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTEDIRECMUNI.CODLADO);
            db.AddInParameter(dbCommand, "pvcTXTNUMEDIF", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDIRECMUNI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDDIREMUNI"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDIRECMUNI.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTLETRA", DbType.String, entSIC_LOTEDIRECMUNI.TXTLETRA);
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcCODTIPOASIG", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOASIG);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_LOTEDIRECMUNI.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTEDIRECMUNI.CODLADO);
            db.AddInParameter(dbCommand, "pvcTXTNUMEDIF", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDIRECMUNI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRUNIDDIREMUNI); 
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
        public BE.SIC_RETORNO ActualizarMod(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_MODIFICAR_MOD" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_MODIFICAR_MOD_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDIRECMUNI.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODVIAANT", DbType.String, entSIC_LOTEDIRECMUNI.CODVIAANT);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIAANT", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIAANT);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTLETRA", DbType.String, entSIC_LOTEDIRECMUNI.TXTLETRA);
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcCODTIPOASIG", DbType.String, entSIC_LOTEDIRECMUNI.CODTIPOASIG);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_LOTEDIRECMUNI.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTEDIRECMUNI.CODLADO);
            db.AddInParameter(dbCommand, "pvcTXTNUMEDIF", DbType.String, entSIC_LOTEDIRECMUNI.TXTNUMEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDIRECMUNI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRUNIDDIREMUNI);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_LOTEDIRECMUNI Recuperar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_LOTEDIRECMUNI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEDIRECMUNI.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTEDIRECMUNI.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDDIREMUNI", entSIC_LOTEDIRECMUNI.CODCORRUNIDDIREMUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEDIRECMUNI(reader, BE.SIC_LOTEDIRECMUNI.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDIRECMUNI.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRUNIDDIREMUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDIRECMUNI.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_LOTEDIRECMUNI.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO EliminarVias(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_ELIMINARVIAS" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_ELIMINARVIAS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEDIRECMUNI.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEDIRECMUNI.CODUSUARIO);
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

        public IEnumerable<BE.SIC_LOTEDIRECMUNI> Listar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            List<BE.SIC_LOTEDIRECMUNI> lista = new List<BE.SIC_LOTEDIRECMUNI>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_LISTAR" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEDIRECMUNI.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTEDIRECMUNI.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTEDIRECMUNI.CODCORRMANZVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDDIREMUNI", entSIC_LOTEDIRECMUNI.CODCORRUNIDDIREMUNI);
            db.SetParameterValue(dbCommand, "pvcNUMCUADRA", entSIC_LOTEDIRECMUNI.NUMCUADRA);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTEDIRECMUNI.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOEDIF", entSIC_LOTEDIRECMUNI.CODTIPOEDIF);
            db.SetParameterValue(dbCommand, "pvcCODTIPOASIG", entSIC_LOTEDIRECMUNI.CODTIPOASIG);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEDIRECMUNI(reader, BE.SIC_LOTEDIRECMUNI.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_LOTEDIRECMUNI> ListarParaUc(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            List<BE.SIC_LOTEDIRECMUNI> lista = new List<BE.SIC_LOTEDIRECMUNI>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEDIRECMUNI.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_LISTAR_UC" : ".PKG_MSISIC_PROC_LOTEDIRECMUNI.PRC_LISTAR_UC_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEDIRECMUNI.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEDIRECMUNI.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEDIRECMUNI.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEDIRECMUNI.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEDIRECMUNI.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEDIRECMUNI.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODTIPOASIG", entSIC_LOTEDIRECMUNI.CODTIPOASIG);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEDIRECMUNI(reader, BE.SIC_LOTEDIRECMUNI.Query.Listar));
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
