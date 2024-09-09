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
    public class SIC_UNIDADINSPECCION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINSPECCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADINSPECCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDADINSPECCI.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDADINSPECCION.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDADINSPECCION.CTIPODOCUMENTO);

            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_UNIDADINSPECCION.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADINSPECCION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADINSPECCION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADINSPECCION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADINSPECCION.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADINSPECCION.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADINSPECCION.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDADINSPECCION.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDADINSPECCION.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDADINSPECCION.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDADINSPECCION.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDADINSPECCION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINSPECCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADINSPECCION.TXTTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDINSP", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
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
        //Creado por	: Pedro Peña Salazar (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINSPECCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDADINSPECCI.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDADINSPECCION.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDADINSPECCION.CTIPODOCUMENTO);

            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_UNIDADINSPECCION.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADINSPECCION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADINSPECCION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADINSPECCION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADINSPECCION.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADINSPECCION.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADINSPECCION.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDADINSPECCION.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDADINSPECCION.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDADINSPECCION.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDADINSPECCION.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDADINSPECCION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINSPECCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPREG", DbType.String, entSIC_UNIDADINSPECCION.TXTTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINSP", DbType.String, entSIC_UNIDADINSPECCION.CODCORRUNIDINSP);
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
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINSPECCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_UNIDADINSPECCION Recuperar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_UNIDADINSPECCION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDADINSPECCI.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDADINSPECCION.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDADINSPECCION.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDADINSPECCION.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_UNIDADINSPECCION.CODNROINSPEC);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDINSP", entSIC_UNIDADINSPECCION.CODCORRUNIDINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADINSPECCION(reader, BE.SIC_UNIDADINSPECCION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINSPECCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public List<BE.SIC_UNIDADINSPECCION> Listar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            List<BE.SIC_UNIDADINSPECCION> lista = new List<BE.SIC_UNIDADINSPECCION>(); ;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDADINSPECCI.PRC_LISTAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDADINSPECCION.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDADINSPECCION.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDADINSPECCION.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_UNIDADINSPECCION.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADINSPECCION(reader, BE.SIC_UNIDADINSPECCION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (12/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADINSPECCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADINSPECCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADINSPECCION entSIC_UNIDADINSPECCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDADINSPECCI.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDADINSPECCION.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDADINSPECCION.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_UNIDADINSPECCION.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDINSP", DbType.String, entSIC_UNIDADINSPECCION.CODCORRUNIDINSP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADINSPECCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPREG", DbType.String, entSIC_UNIDADINSPECCION.TXTTIPREG);
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
        public DataSet BuscarInspeccion(DataSet dtSubGen, string numeroInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_GEST_PROGINSPEC.PRC_BUSCAR_PROGRAMACIONINS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcNUMEROINSPECCION", numeroInforme);
            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
        public DataSet BuscarDireccionInspeccion(DataSet dtSubGen, string numeroInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_GEST_PROGINSPEC.PRC_BUSCAR_UNIDADCATASTRALINS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcNUMEROINSPECCION", numeroInforme);
            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
        
        public DataSet BuscarTipoInspeccion(DataSet dtSubGen, string numeroInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_GEST_PROGINSPEC.PRC_BUSCAR_TIPOINSPECCION", new object[2]);
            db.SetParameterValue(dbCommand, "pvcNUMEROINSPECCION", numeroInforme);
            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
    }
}
