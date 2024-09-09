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
    public class SIC_MANZAVIAVALOR : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZAVIAVALOR.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MANZAVIAVALOR
        /// </summary>
        public BE.SIC_MANZAVIAVALOR Recuperar(BE.SIC_MANZAVIAVALOR entSIC_MANZAVIAVALOR)
        {
            BE.SIC_MANZAVIAVALOR lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZAVIAVALOR.PRC_DATOS", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZAVIAVALOR.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZAVIAVALOR.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_MANZAVIAVALOR.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZAVIAVALOR.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZAVIAVALOR.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZAVIAVALOR.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_MANZAVIAVALOR.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_MANZAVIAVALOR(reader, BE.SIC_MANZAVIAVALOR.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (16/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZAVIAVALOR.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MANZAVIAVALOR, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MANZAVIAVALOR entSIC_MANZAVIAVALOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZAVIAVALOR.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZAVIAVALOR.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZAVIAVALOR.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_MANZAVIAVALOR.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_MANZAVIAVALOR.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.String, entSIC_MANZAVIAVALOR.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_MANZAVIAVALOR.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODANOVAL", DbType.String, entSIC_MANZAVIAVALOR.CODANOVAL);
            db.AddInParameter(dbCommand, "pvcNUMVALOR", DbType.Decimal, entSIC_MANZAVIAVALOR.NUMVALOR);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZAVIAVALOR.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZAVIAVALOR.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZAVIAVALOR.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZAVIAVALOR.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                //entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRMANZVIA"));
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
        //Creado por	: Jaime Díaz Espinoza (16/05/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZAVIAVALOR.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MANZAVIAVALOR
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MANZAVIAVALOR entSIC_MANZAVIAVALOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZAVIAVALOR.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZAVIAVALOR.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZAVIAVALOR.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_MANZAVIAVALOR.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_MANZAVIAVALOR.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.String, entSIC_MANZAVIAVALOR.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_MANZAVIAVALOR.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODANOVAL", DbType.String, entSIC_MANZAVIAVALOR.CODANOVAL);
            db.AddInParameter(dbCommand, "pvcNUMVALOR", DbType.Decimal, entSIC_MANZAVIAVALOR.NUMVALOR);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZAVIAVALOR.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZAVIAVALOR.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZAVIAVALOR.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZAVIAVALOR.CODUSUARIO);
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
