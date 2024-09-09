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
    public class SIC_CONTROLCALIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (30/04/2018)
        //Utilizado por	: BusinessLogic.SIC_CONTROLCALIDAD.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CONTROLCALIDAD
        /// </summary>
        public IEnumerable<BE.SIC_CONTROLCALIDAD> Listar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            List<BE.SIC_CONTROLCALIDAD> lista = new List<BE.SIC_CONTROLCALIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_CONTROLCALIDAD.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_CONTROLCALIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_CONTROLCALIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_CONTROLCALIDAD.CODTIPOSOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONTROLCALIDAD(reader, BE.SIC_CONTROLCALIDAD.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_CONTROLCALIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONTROLCALIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_CONTROLCALIDAD.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CONTROLCALIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOERROR", DbType.String, entSIC_CONTROLCALIDAD.CODTIPOERROR);
            db.AddInParameter(dbCommand, "pvcCODERRORCALIDAD", DbType.String, entSIC_CONTROLCALIDAD.CODERRORCALIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUASIS", DbType.String, entSIC_CONTROLCALIDAD.CODUSUASIS);
            db.AddInParameter(dbCommand, "pvcCODCART", DbType.String, entSIC_CONTROLCALIDAD.CODCART);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_CONTROLCALIDAD.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcTXTNROINSPECREF", DbType.String, entSIC_CONTROLCALIDAD.TXTNROINSPECREF);
            db.AddInParameter(dbCommand, "pvcCODUSUARESP", DbType.String, entSIC_CONTROLCALIDAD.CODUSUARESP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONTROLCALIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_CONTROLCALIDAD.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CONTROLCALIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcCODCORRCONCALI", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRCONCALI"));
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
        //Creado por	: Pedro Peña Salazar (05/06/2018)
        //Utilizado por	: BusinessLogic.SIC_CONTROLCALIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONTROLCALIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_CONTROLCALIDAD.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CONTROLCALIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOERROR", DbType.String, entSIC_CONTROLCALIDAD.CODTIPOERROR);
            db.AddInParameter(dbCommand, "pvcCODERRORCALIDAD", DbType.String, entSIC_CONTROLCALIDAD.CODERRORCALIDAD);
            db.AddInParameter(dbCommand, "pvcTXTDETALLE", DbType.String, entSIC_CONTROLCALIDAD.TXTDETALLE);
            db.AddInParameter(dbCommand, "pvcTXTNROINSPECREF", DbType.String, entSIC_CONTROLCALIDAD.TXTNROINSPECREF);
            db.AddInParameter(dbCommand, "pvcCODUSUARESP", DbType.String, entSIC_CONTROLCALIDAD.CODUSUARESP);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONTROLCALIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_CONTROLCALIDAD.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRCONCALI", DbType.String, entSIC_CONTROLCALIDAD.CODCORRCONCALI);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_CONTROLCALIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_CONTROLCALIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_CONTROLCALIDAD.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CONTROLCALIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CONTROLCALIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODCORRCONCALI", DbType.String, entSIC_CONTROLCALIDAD.CODCORRCONCALI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CONTROLCALIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_CONTROLCALIDAD.TXTIPREG);
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
