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
    public class SIC_SOLUNIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLUNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_SOLUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_SOLUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_SOLUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_SOLUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_SOLUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_SOLUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_SOLUNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_SOLUNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_SOLUNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_SOLUNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcESTADOUNIDAD", DbType.String, entSIC_SOLUNIDAD.ESTADOUNIDAD);
            db.AddOutParameter(dbCommand, "pvcCORRELUNIDAD", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pvcMENSAJE", DbType.String, 2000);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCORRELUNIDAD"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.MENSAJE = Convert.ToString(db.GetParameterValue(dbCommand, "pvcMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO GrabarNuevo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_INSERTAR_NUEVO");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_SOLUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_SOLUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_SOLUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_SOLUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_SOLUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_SOLUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_SOLUNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_SOLUNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_SOLUNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_SOLUNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODREFANT", DbType.String, entSIC_SOLUNIDAD.CODREFANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCORRELUNIDAD", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcCODLOTECATASTRAL", DbType.String, 20);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCORRELUNIDAD"));
                entSIC_RETORNO.CODLOTECATASTRAL = (string)(db.GetParameterValue(dbCommand, "pvcCODLOTECATASTRAL"));
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
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_SOLUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_SOLUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_SOLUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_SOLUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_SOLUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_SOLUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_SOLUNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_SOLUNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_SOLUNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_SOLUNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCORRELUNIDAD", DbType.String, entSIC_SOLUNIDAD.CORRELUNIDAD);
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
        public BE.SIC_RETORNO ActualizarFlag(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_MODIFICAR_FLAG");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcFLG_TRABAJO", DbType.String, entSIC_SOLUNIDAD.FLG_TRABAJO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_SOLUNIDAD Recuperar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCORRELUNIDAD", entSIC_SOLUNIDAD.CORRELUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SOLUNIDAD
        /// </summary>
        public BE.SIC_RETORNO EliminarNuevo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_ELIMINAR_NUEVO");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_SOLUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_SOLUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_SOLUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_SOLUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_SOLUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
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

        public BE.SIC_RETORNO EliminarNuevoUnidad(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ELIMINAR_REFERENCIA");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_SOLUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLUNIDAD.CTIPODOCUMENTO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLUNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLUNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCORRELUNIDAD", DbType.String, entSIC_SOLUNIDAD.CORRELUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLUNIDAD.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLUNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_SOLUNIDAD> Buscar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarMasivo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_MASIVO", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcFLG_TRABAJO", entSIC_SOLUNIDAD.FLG_TRABAJO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> Buscar2(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR2", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLUNIDAD.CODUSUARIO);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarConsulta));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> ParaMigrar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_PARA_MIGRAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> ParaMigrarLote(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_PARA_MIGRAR_LOTE", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarLote));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarBComun(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCARBCOMUN", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLUNIDAD.CODUSUARIO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarConsulta));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> RecuperarxCC(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLUNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCC" : ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCC";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarEstatico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> RecuperarxCCU(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLUNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCCU" : ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCCU";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarEstatico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }


        public BE.SIC_SOLUNIDAD Listar(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            BE.SIC_SOLUNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLUNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_LISTAR_EST" : ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_LISTAR";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_SOLUNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.Listar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarTitulares(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_TITULARES", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarTitulares));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarSolicitud(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLUNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_SOL" : ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_SOL_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[15]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarSol));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarSolMasivo(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure =  ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_SOLMASIVO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[15]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarSol));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarDirec(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_DIREC", new object[15]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);

            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarDirec));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarDirecTemp(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_DIREC_TMP", new object[15]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);

            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarDirec));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarDirecCerti(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_DIREC_CERTI", new object[15]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);

            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarDirec));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarCerti(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_CERTI", new object[18]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);

            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_SOLUNIDAD.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_SOLUNIDAD.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_SOLUNIDAD.CODTIPOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarCerti));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarCertiFilter(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_CERTI_FILTER", new object[18]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);

            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_SOLUNIDAD.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_SOLUNIDAD.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_SOLUNIDAD.CODTIPOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarCerti));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLUNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLUNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_SOLUNIDAD> BuscarUnique(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_SOLUNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_UNIQUE" : ".PKG_MSISIC_GEST_SOLUNIDAD.PRC_BUSCAR_UNIQUE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLUNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLUNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLUNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLUNIDAD.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSIC_SOLUNIDAD.CODUSUARIO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarUnico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLUNIDAD> RecuperarHistoricoxCCU(BE.SIC_SOLUNIDAD entSIC_SOLUNIDAD)
        {
            List<BE.SIC_SOLUNIDAD> lista = new List<BE.SIC_SOLUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_UNIDAD.PRC_DATOSHISTORICOUNIDAD";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_SOLUNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_SOLUNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_SOLUNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_SOLUNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_SOLUNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_SOLUNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_SOLUNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_SOLUNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_SOLUNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_SOLUNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLUNIDAD(reader, BE.SIC_SOLUNIDAD.Query.BuscarHistorico));
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
