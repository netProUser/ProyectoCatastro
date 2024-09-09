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
    public class SIC_MANZANA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANA
        /// </summary>
        public IEnumerable<BE.SIC_MANZANA> Buscar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            List<BE.SIC_MANZANA> lista = new List<BE.SIC_MANZANA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_BUSCAR", new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODTEMATICO", entSIC_MANZANA.CODTEMATICO);
            db.SetParameterValue(dbCommand, "pvcTXTMANZANA", entSIC_MANZANA.TXTMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_MANZANA.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_MANZANA.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_MANZANA.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MANZANA(reader, BE.SIC_MANZANA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }

            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANA
        /// </summary>
        public IEnumerable<BE.SIC_MANZANA> Listar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            List<BE.SIC_MANZANA> lista = new List<BE.SIC_MANZANA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_LISTAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANA.CODDISTRITO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MANZANA(reader, BE.SIC_MANZANA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }

            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANA
        /// </summary>
        public BE.SIC_MANZANA BuscarInt(BE.SIC_MANZANA entSIC_MANZANA)
        {
            BE.SIC_MANZANA lista = new BE.SIC_MANZANA();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODTEMATICO", DbType.String, entSIC_MANZANA.CODTEMATICO);
            db.AddInParameter(dbCommand, "pvcTXTMANZANA", DbType.String, entSIC_MANZANA.TXTMANZANA);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_MANZANA.PAGINAREGISTROS);
            db.AddOutParameter(dbCommand, "pinTOTPAG", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pinTOTREG", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                lista.TOTALPAGINAS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTPAG"));
                lista.TOTALREGISTROS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTREG"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MANZANA
        /// </summary>
        public BE.SIC_MANZANA Recuperar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            BE.SIC_MANZANA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANA.CODMANZANA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_MANZANA(reader, BE.SIC_MANZANA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MANZANA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODTEMATICO", DbType.String, entSIC_MANZANA.CODTEMATICO);
            db.AddInParameter(dbCommand, "pvcTXTMANZANA", DbType.String, entSIC_MANZANA.TXTMANZANA);
            db.AddInParameter(dbCommand, "pvcTXTMANZURBA", DbType.String, entSIC_MANZANA.TXTMANZURBA);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANA.CODDISTRITO);

            db.AddInParameter(dbCommand, "pvcTXTSECTVECI", DbType.String, entSIC_MANZANA.TXTSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTVECI", DbType.String, entSIC_MANZANA.TXTSUBSECTVECI);


            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODMANZANA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODMANZANA"));
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
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MANZANA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODTEMATICO", DbType.String, entSIC_MANZANA.CODTEMATICO);
            db.AddInParameter(dbCommand, "pvcTXTMANZANA", DbType.String, entSIC_MANZANA.TXTMANZANA);
            db.AddInParameter(dbCommand, "pvcTXTMANZURBA", DbType.String, entSIC_MANZANA.TXTMANZURBA);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcTXTSECTVECI", DbType.String, entSIC_MANZANA.TXTSECTVECI);
            db.AddInParameter(dbCommand, "pvcTXTSUBSECTVECI", DbType.String, entSIC_MANZANA.TXTSUBSECTVECI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZANA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcTXTRUTAIMAGEN", DbType.String, entSIC_MANZANA.TXTRUTAIMAGEN);
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
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MANZANA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_MANZANA entSIC_MANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZANA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANA.CODUSUARIO);
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
