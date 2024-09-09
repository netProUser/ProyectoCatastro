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
    public class SIC_QUINTALINDERO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_QUINTALINDERO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_INSERTAR" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_QUINTALINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_QUINTALINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_QUINTALINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_QUINTALINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_QUINTALINDERO.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_QUINTALINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_QUINTALINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_QUINTALINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_QUINTALINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_QUINTALINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOL", DbType.String, entSIC_QUINTALINDERO.CODPISOCOL);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCOLI", DbType.String, entSIC_QUINTALINDERO.CODUNIDADCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNICOLI", DbType.Int32, entSIC_QUINTALINDERO.CODUNICOLI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_QUINTALINDERO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORMANZVIA", DbType.String, entSIC_QUINTALINDERO.CODCORMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_QUINTALINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_QUINTALINDERO.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCORRELLINDE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCORRELLINDE"));
                var asc = db.GetParameterValue(dbCommand, "pvcNROMENSAJE");
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
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_QUINTALINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_QUINTALINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_QUINTALINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_QUINTALINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_QUINTALINDERO.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_QUINTALINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_QUINTALINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_QUINTALINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_QUINTALINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_QUINTALINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOL", DbType.String, entSIC_QUINTALINDERO.CODPISOCOL);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCOLI", DbType.String, entSIC_QUINTALINDERO.CODUNIDADCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNICOLI", DbType.Int32, entSIC_QUINTALINDERO.CODUNICOLI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_QUINTALINDERO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORMANZVIA", DbType.String, entSIC_QUINTALINDERO.CODCORMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_QUINTALINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_QUINTALINDERO.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_QUINTALINDERO.CORRELLINDE);
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
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_QUINTALINDERO Recuperar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_QUINTALINDERO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_DATOS" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_QUINTALINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_QUINTALINDERO.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCORRELLINDE", entSIC_QUINTALINDERO.CORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_QUINTALINDERO(reader, BE.SIC_QUINTALINDERO.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_QUINTALINDERO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();

            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_QUINTALINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_QUINTALINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_QUINTALINDERO.CORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_QUINTALINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_QUINTALINDERO.TXTIPREG);
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
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los Lotes de la unidad SIC_QUINTALINDERO
        /// </summary>
        public IEnumerable<BE.SIC_QUINTALINDERO> Buscar(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_QUINTALINDERO> lista = new List<BE.SIC_QUINTALINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);  
 
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_QUINTALINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcORDEN", "");
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_QUINTALINDERO(reader, BE.SIC_QUINTALINDERO.Query.ListarColidante));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
           public IEnumerable<BE.SIC_QUINTALINDERO> BuscarHistoricoLoteLinderos(BE.SIC_QUINTALINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_QUINTALINDERO> lista = new List<BE.SIC_QUINTALINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERLINDEROSUNIDADHST";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_QUINTALINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_QUINTALINDERO.NUMVERSION);
            db.SetParameterValue(dbCommand, "pvcORDEN", "");
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_QUINTALINDERO(reader, BE.SIC_QUINTALINDERO.Query.ListarHistorico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (29/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.ListarEdif
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Edificaciones de la unidad SIC_QUINTALINDERO
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> ListarEdif(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_LISTAREDIF", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarEdif));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (29/08/2018)
        //Utilizado por	: BusinessLogic.SIC_QUINTALINDERO.ListarUnidad
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Unidades de la unidad SIC_QUINTALINDERO
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> ListarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_LISTARUNIDAD", new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarUnidad));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_QUINTALINDERO> BuscarLinderosUnidad(BE.SIC_QUINTALINDERO entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_QUINTALINDERO> lista = new List<BE.SIC_QUINTALINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR_LINDERO" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_LOTELINDEROVIADET.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_QUINTALINDERO(reader, BE.SIC_QUINTALINDERO.Query.ListarColindantes));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_RETORNO EliminarLinderoUnidad(BE.SIC_QUINTALINDERO entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR_LINDERO" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_LOTELINDEROVIADET.CODUNILINDERO);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDEROVIADET.CORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDEROVIADET.CODUSUARIO);
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
        public BE.SIC_QUINTALINDERO BuscarLinderoDetalle(BE.SIC_QUINTALINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_QUINTALINDERO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR_LINDERODET" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_BUSCAR_LINDERODET_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_LOTELINDERO.CODUNILINDERO);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDERO.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDERO.CORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_QUINTALINDERO(reader, BE.SIC_QUINTALINDERO.Query.ListarColidante);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO EliminarDetalleLindero(BE.SIC_QUINTALINDERO entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR_DETALLE" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_ELIMINAR_DETALLE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);

            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERODET.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDERODET.CORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_LOTELINDERODET.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERODET.CODUSUARIO);
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
        public BE.SIC_RETORNO GrabarUnidadLinderoDetalle(BE.SIC_QUINTALINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_INSERTAR_LINDERO" : ".PKG_MSISIC_PROC_QUINTALINDERO.PRC_INSERTAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNILINDERO", DbType.String, entSIC_LOTELINDERO.CODUNILINDERO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDERO.CORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_LOTELINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_LOTELINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_LOTELINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_LOTELINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_LOTELINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOL", DbType.String, entSIC_LOTELINDERO.CODPISOCOL);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCOLI", DbType.String, entSIC_LOTELINDERO.CODUNIDADCOLI);
            db.AddInParameter(dbCommand, "pvcCODCORMANZVIA", DbType.String, entSIC_LOTELINDERO.CODCORMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDERO.CODVIA);
            db.AddInParameter(dbCommand, "pvcESTADO", DbType.String, entSIC_LOTELINDERO.ESTADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_LOTELINDERO.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLADO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLADO"));
                var asc = db.GetParameterValue(dbCommand, "pvcNROMENSAJE");
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
