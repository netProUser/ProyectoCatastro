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
    public class SIC_SOLISEGUI : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLISEGUI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLISEGUI.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLISEGUI.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_SOLISEGUI.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODRESPENVIA", DbType.String, entSIC_SOLISEGUI.CODRESPENVIA);
            db.AddInParameter(dbCommand, "pvcCODRESPRECIBE", DbType.String, entSIC_SOLISEGUI.CODRESPRECIBE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLISEGUI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcNUMFOLIOS", DbType.Int32, entSIC_SOLISEGUI.NUMFOLIOS);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLISEGUI.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOREQ", DbType.String, entSIC_SOLISEGUI.CODTIPOREQ);
            db.AddInParameter(dbCommand, "pvcCODESTATENCION", DbType.String, entSIC_SOLISEGUI.CODESTATENCION);
            db.AddInParameter(dbCommand, "pvcCODESTATENCIONE", DbType.String, entSIC_SOLISEGUI.CODESTATENCIONE);
            db.AddInParameter(dbCommand, "pvcCODTIPPROC", DbType.String, entSIC_SOLISEGUI.CODTIPPROC);
            db.AddInParameter(dbCommand, "pvcCODCARCAT", DbType.String, entSIC_SOLISEGUI.CODCARCAT);
            db.AddInParameter(dbCommand, "pvcCODCARCATE", DbType.String, entSIC_SOLISEGUI.CODCARCATE);
            db.AddInParameter(dbCommand, "pvcCODACCION", DbType.String, entSIC_SOLISEGUI.CODACCION);
            db.AddInParameter(dbCommand, "pvcCODACTIVIDAD", DbType.String, entSIC_SOLISEGUI.CODACTIVIDAD);
            db.AddInParameter(dbCommand, "pvcFECRECEPCION", DbType.Date, entSIC_SOLISEGUI.FECRECEPCION);
            db.AddInParameter(dbCommand, "pvcFECENVIO", DbType.Date, entSIC_SOLISEGUI.FECENVIO);
            db.AddInParameter(dbCommand, "pvcFECLIMITE", DbType.Date, entSIC_SOLISEGUI.FECLIMITE);
            db.AddInParameter(dbCommand, "pvcFECPROGAINSPE", DbType.Date, entSIC_SOLISEGUI.FECPROGAINSPE);
            db.AddInParameter(dbCommand, "pvcFECLIMITEI", DbType.Date, entSIC_SOLISEGUI.FECLIMITEI);
            db.AddInParameter(dbCommand, "pvcFECLIMIACT", DbType.Date, entSIC_SOLISEGUI.FECLIMIACT);
            db.AddInParameter(dbCommand, "pvcFECLIMIANA", DbType.Date, entSIC_SOLISEGUI.FECLIMIANA);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcCODCORRSEG", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRSEG"));
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
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLISEGUI.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLISEGUI.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLISEGUI.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODCORRSEG", DbType.String, entSIC_SOLISEGUI.CODCORRSEG);
            db.AddInParameter(dbCommand, "pvcCODRESPENVIA", DbType.String, entSIC_SOLISEGUI.CODRESPENVIA);
            db.AddInParameter(dbCommand, "pvcCODRESPRECIBE", DbType.String, entSIC_SOLISEGUI.CODRESPRECIBE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_SOLISEGUI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcNUMFOLIOS", DbType.String, entSIC_SOLISEGUI.NUMFOLIOS);
            db.AddInParameter(dbCommand, "pvcFECRECEPCION", DbType.Date, entSIC_SOLISEGUI.FECRECEPCION);
            db.AddInParameter(dbCommand, "pvcFECENVIO", DbType.Date, entSIC_SOLISEGUI.FECENVIO);
            db.AddInParameter(dbCommand, "pvcCODTIPPROC", DbType.String, entSIC_SOLISEGUI.CODTIPPROC);
            db.AddInParameter(dbCommand, "pvcCODACCION", DbType.String, entSIC_SOLISEGUI.CODACCION);
            db.AddInParameter(dbCommand, "pvcCODTIPOREQ", DbType.String, entSIC_SOLISEGUI.CODTIPOREQ);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_SOLISEGUI.TXTOBSERVACION);
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
        //Creado por	: Pedro Peña Salazar (06/06/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.PRC_REGERROR
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Regerror(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_REGERROR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODCORRSEG", entSIC_SOLISEGUI.CODCORRSEG);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.RecuperarError);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (06/06/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Filtrar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Filtrar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_FILTRAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODCORRSEG", entSIC_SOLISEGUI.CODCORRSEG);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Filtrar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Recuperar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_DATOS", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODCORRSEG", entSIC_SOLISEGUI.CODCORRSEG);
            db.SetParameterValue(dbCommand, "pvcCODESTATENCION", entSIC_SOLISEGUI.CODESTATENCION);
            db.SetParameterValue(dbCommand, "pvcCODRESPRECIBE", entSIC_SOLISEGUI.CODRESPRECIBE);
            db.SetParameterValue(dbCommand, "pvcCODTIPODOC", entSIC_SOLISEGUI.CODTIPODOC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public IEnumerable<BE.SIC_SOLISEGUI> Buscar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_BUSCAR", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_SOLISEGUI.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_SOLISEGUI.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_SOLISEGUI.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI BuscarInt(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lista = new BE.SIC_SOLISEGUI();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_SOLISEGUI.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_SOLISEGUI.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_SOLISEGUI.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.String, entSIC_SOLISEGUI.PAGINAREGISTROS);
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
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (10/08/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Informe
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public IEnumerable<BE.SIC_SOLISEGUI> Informe(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_INFORME", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLISEGUI.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Informe));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_SOLISEGUI> Carta(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_CARTA", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_SOLISEGUI.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_SOLISEGUI.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Carta));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.NuevoLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public IEnumerable<BE.SIC_SOLISEGUI> NuevoLis(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_NUEVO", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Nuevo));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_SOLISEGUI> NuevoSegui(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_NUEVOSEGUI", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Nuevo));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (01/06/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.InicialLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public IEnumerable<BE.SIC_SOLISEGUI> InicialLis(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_INICIAL", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Inicial));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (04/06/2018)
        //Utilizado por	: BusinessLogic.SIC_SOLISEGUI.Seguimiento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public IEnumerable<BE.SIC_SOLISEGUI> Seguimiento(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lista = new List<BE.SIC_SOLISEGUI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_SOLISEGUI.PRC_SEGUIMIENTO", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_SOLISEGUI.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_SOLISEGUI.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_SOLISEGUI.CODNUMESOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_SOLISEGUI(reader, BE.SIC_SOLISEGUI.Query.Seguimiento));
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
