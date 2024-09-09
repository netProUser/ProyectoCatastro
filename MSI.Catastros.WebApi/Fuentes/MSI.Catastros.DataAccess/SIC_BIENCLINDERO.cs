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
    public class SIC_BIENCLINDERO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (28/08/2018)
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_BIENCLINDERO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_INSERTAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_BIENCLINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_BIENCLINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_BIENCLINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_BIENCLINDERO.NUMMEDIOFIC);   
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_BIENCLINDERO.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_BIENCLINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_BIENCLINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_BIENCLINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_BIENCLINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_BIENCLINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOLI", DbType.String, entSIC_BIENCLINDERO.CODPISOCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCOLI", DbType.String, entSIC_BIENCLINDERO.CODUNIDADCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNICOLI", DbType.Int32, entSIC_BIENCLINDERO.CODUNICOLI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_BIENCLINDERO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORMANZVIA", DbType.String, entSIC_BIENCLINDERO.CODCORMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_BIENCLINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_BIENCLINDERO.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRELLINDE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELLINDE"));
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_MODIFICAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_BIENCLINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_BIENCLINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_BIENCLINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_BIENCLINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODTIPOCOLI", DbType.String, entSIC_BIENCLINDERO.CODTIPOCOLI);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_BIENCLINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_BIENCLINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_BIENCLINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_BIENCLINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_BIENCLINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOLI", DbType.String, entSIC_BIENCLINDERO.CODPISOCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNIDADCOLI", DbType.String, entSIC_BIENCLINDERO.CODUNIDADCOLI);
            db.AddInParameter(dbCommand, "pvcCODUNICOLI", DbType.Int32, entSIC_BIENCLINDERO.CODUNICOLI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_BIENCLINDERO.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORMANZVIA", DbType.String, entSIC_BIENCLINDERO.CODCORMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_BIENCLINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_BIENCLINDERO.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRELLINDE", DbType.String, entSIC_BIENCLINDERO.CODCORRELLINDE);
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_BIENCLINDERO Recuperar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_BIENCLINDERO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_DATOS_TMP", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_BIENCLINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_BIENCLINDERO.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRELLINDE", entSIC_BIENCLINDERO.CODCORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_BIENCLINDERO(reader, BE.SIC_BIENCLINDERO.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_BIENCLINDERO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_ELIMINAR_TMP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_BIENCLINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_BIENCLINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRELLINDE", DbType.String, entSIC_BIENCLINDERO.CODCORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_BIENCLINDERO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_BIENCLINDERO.TXTIPREG);
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los Lotes de la unidad SIC_BIENCLINDERO
        /// </summary>
        public IEnumerable<BE.SIC_BIENCLINDERO> Buscar(BE.SIC_BIENCLINDERO entSIC_BIENCLINDERO)
        {
            List<BE.SIC_BIENCLINDERO> lista = new List<BE.SIC_BIENCLINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCAR_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_BIENCLINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcORDEN", "");
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_BIENCLINDERO(reader, BE.SIC_BIENCLINDERO.Query.Listar));
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.ListarEdif
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Edificaciones de la unidad SIC_BIENCLINDERO
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> ListarEdif(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_LISTAREDIF" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_LISTAREDIF_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
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
        //Utilizado por	: BusinessLogic.SIC_BIENCLINDERO.ListarUnidad
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar las Unidades de la unidad SIC_BIENCLINDERO
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> ListarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_LISTARUNIDAD" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_LISTARUNIDAD_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);

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
        public BE.SIC_BIENCLINDERO BuscarLinderoDetalle(BE.SIC_BIENCLINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_BIENCLINDERO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCAR_LINDERODET" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCAR_LINDERODET_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_LOTELINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDERO.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDERO.CODCORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_BIENCLINDERO(reader, BE.SIC_BIENCLINDERO.Query.ListarColidante);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public IEnumerable<BE.SIC_BIENCLINDERO> BuscarLinderoC(BE.SIC_BIENCLINDERO entSIC_QUINTALINDERO)
        {
            List<BE.SIC_BIENCLINDERO> lista = new List<BE.SIC_BIENCLINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_QUINTALINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCARLIN" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCARLIN_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_QUINTALINDERO.CODUNI);
            db.SetParameterValue(dbCommand, "pvcORDEN", "");
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_BIENCLINDERO(reader, BE.SIC_BIENCLINDERO.Query.ListarColidante));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_BIENCLINDERO> BuscarLinderosUnidad(BE.SIC_BIENCLINDERO entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_BIENCLINDERO> lista = new List<BE.SIC_BIENCLINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCAR_LINDERO" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_BUSCAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_LOTELINDEROVIADET.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CODCORRELLINDE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_BIENCLINDERO(reader, BE.SIC_BIENCLINDERO.Query.ListarColindantes));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_RETORNO EliminarLinderoUnidad(BE.SIC_BIENCLINDERO entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_ELIMINAR_LINDERO" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_ELIMINAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_LOTELINDEROVIADET.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRELLINDE);
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
        public BE.SIC_RETORNO EliminarDetalleLindero(BE.SIC_BIENCLINDERO entSIC_LOTELINDERODET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERODET.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_ELIMINAR_DETALLE" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_ELIMINAR_DETALLE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);

            db.AddInParameter(dbCommand, "pvcCORRELATIVO", DbType.String, entSIC_LOTELINDERODET.CORRELATIVO);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERODET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDERODET.CODCORRELLINDE);
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
        public BE.SIC_RETORNO GrabarUnidadLinderoDetalle(BE.SIC_BIENCLINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_INSERTAR_LINDERO" : ".PKG_MSISIC_PROC_BCOMUNLINDERO.PRC_INSERTAR_LINDERO_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNILINDERO", DbType.String, entSIC_LOTELINDERO.CODUNI);
            db.AddInParameter(dbCommand, "pvcCORRELLINDE", DbType.String, entSIC_LOTELINDERO.CODCORRELLINDE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcNUMMEDICAMP", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDICAMP);
            db.AddInParameter(dbCommand, "pvcNUMMEDIOFIC", DbType.Decimal, entSIC_LOTELINDERO.NUMMEDIOFIC);
            db.AddInParameter(dbCommand, "pvcCODSECTCOLI", DbType.String, entSIC_LOTELINDERO.CODSECTCOLI);
            db.AddInParameter(dbCommand, "pvcCODMANZCOLI", DbType.String, entSIC_LOTELINDERO.CODMANZCOLI);
            db.AddInParameter(dbCommand, "pvcCODLOTECOLI", DbType.String, entSIC_LOTELINDERO.CODLOTECOLI);
            db.AddInParameter(dbCommand, "pvcCODEDIFICCOLI", DbType.String, entSIC_LOTELINDERO.CODEDIFICCOLI);
            db.AddInParameter(dbCommand, "pvcCODENTRACOLI", DbType.String, entSIC_LOTELINDERO.CODENTRACOLI);
            db.AddInParameter(dbCommand, "pvcCODPISOCOL", DbType.String, entSIC_LOTELINDERO.CODPISOCOLI);
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
