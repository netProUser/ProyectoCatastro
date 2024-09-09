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
    public class SIC_DOCUUNIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (12/10/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCUUNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DOCUUNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODANOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODCORRINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODCORRINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DOCUUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DOCUUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_DOCUUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_DOCUUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_DOCUUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_DOCUUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_DOCUUNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_DOCUUNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_DOCUUNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_DOCUUNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_DOCUUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCUUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_DOCUUNIDAD.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRDOCUNIDAD", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRDOCUNIDAD"));
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
        //Creado por	: Pedro Peña Salazar (12/10/2018)
        //Utilizado por	: BusinessLogic.SIC_DOCUUNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCORRDOCUNIDAD", DbType.String, entSIC_DOCUUNIDAD.CODCORRDOCUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODANOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODCORRINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODCORRINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DOCUUNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DOCUUNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_DOCUUNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_DOCUUNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_DOCUUNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_DOCUUNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_DOCUUNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_DOCUUNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_DOCUUNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_DOCUUNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_DOCUUNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCUUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_DOCUUNIDAD.TXTIPREG);
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
        //Utilizado por	: BusinessLogic.SIC_DOCUUNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_DOCUUNIDAD Recuperar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_DOCUUNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_DATOS_TMP", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORCARTA", entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANOINFORCARTA", entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFORCARTA", entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFORCARTA", entSIC_DOCUUNIDAD.CODCORRINFORCARTA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_DOCUUNIDAD(reader, BE.SIC_DOCUUNIDAD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_DOCUUNIDAD RecuperarUnidad(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_DOCUUNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_DATOS_UNIDAD", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODINFORCARTA", entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANOINFORCARTA", entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFORCARTA", entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFORCARTA", entSIC_DOCUUNIDAD.CODCORRINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_DOCUUNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_DOCUUNIDAD(reader, BE.SIC_DOCUUNIDAD.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_DOCUUNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_ELIMINAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODANOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.AddInParameter(dbCommand, "pvcCODCORRINFORCARTA", DbType.String, entSIC_DOCUUNIDAD.CODCORRINFORCARTA);

            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DOCUUNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_DOCUUNIDAD.TXTIPREG);
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
        //Utilizado por	: BusinessLogic.SIC_DOCUUNIDAD.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_DOCUUNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_DOCUUNIDAD> Listar(BE.SIC_DOCUUNIDAD entSIC_DOCUUNIDAD)
        {
            List<BE.SIC_DOCUUNIDAD> lista = new List<BE.SIC_DOCUUNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_DOCUUNIDAD.PRC_LISTAR_TMP", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODINFORCARTA", entSIC_DOCUUNIDAD.CODINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANOINFORCARTA", entSIC_DOCUUNIDAD.CODANOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFORCARTA", entSIC_DOCUUNIDAD.CODTIPOINFORCARTA);
            db.SetParameterValue(dbCommand, "pvcCODCORRINFORCARTA", entSIC_DOCUUNIDAD.CODCORRINFORCARTA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_DOCUUNIDAD(reader, BE.SIC_DOCUUNIDAD.Query.Listar));
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
