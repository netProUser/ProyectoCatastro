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
    public class SIC_PROGINSPEC : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_PROGINSPEC.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_PROGINSPEC, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_PROGINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_PROGINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_PROGINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcFECINSPE", DbType.Date, entSIC_PROGINSPEC.FECINSPE);
            db.AddInParameter(dbCommand, "pvcTXTHORAINSP", DbType.String, entSIC_PROGINSPEC.TXTHORAINSP);
            db.AddInParameter(dbCommand, "pvcFECCITACION", DbType.Date, entSIC_PROGINSPEC.FECCITACION);
            db.AddInParameter(dbCommand, "pvcFECAVIINSPEC", DbType.Date, entSIC_PROGINSPEC.FECAVIINSPEC);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_PROGINSPEC.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODESTATENCION", DbType.String, entSIC_PROGINSPEC.CODESTATENCION);
            db.AddInParameter(dbCommand, "pvcFECREPROG", DbType.Date, entSIC_PROGINSPEC.FECREPROG);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PROGINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_PROGINSPEC.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEA", DbType.String, entSIC_PROGINSPEC.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_PROGINSPEC.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcTXTFTXTFECLIMITE", DbType.String, entSIC_PROGINSPEC.TXTFTXTFECLIMITE);
            db.AddInParameter(dbCommand, "pvcTXTFECLIMITEPROGINSP", DbType.String, entSIC_PROGINSPEC.TXTFECLIMITEPROGINSP);
            db.AddInParameter(dbCommand, "pvcTXTFECLIMITEINSPECCION", DbType.String, entSIC_PROGINSPEC.TXTFECLIMITEINSPECCION);
           
            db.AddOutParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODNROINSPEC"));
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
        //Utilizado por	: BusinessLogic.SIC_PROGINSPEC.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_PROGINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_PROGINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_PROGINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcFECINSPE", DbType.Date, entSIC_PROGINSPEC.FECINSPE);
            db.AddInParameter(dbCommand, "pvcTXTHORAINSP", DbType.String, entSIC_PROGINSPEC.TXTHORAINSP);
            db.AddInParameter(dbCommand, "pvcFECCITACION", DbType.Date, entSIC_PROGINSPEC.FECCITACION);
            db.AddInParameter(dbCommand, "pvcFECAVIINSPEC", DbType.Date, entSIC_PROGINSPEC.FECAVIINSPEC);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_PROGINSPEC.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODESTATENCION", DbType.String, entSIC_PROGINSPEC.CODESTATENCION);
            db.AddInParameter(dbCommand, "pvcFECREPROG", DbType.Date, entSIC_PROGINSPEC.FECREPROG);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PROGINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_PROGINSPEC.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_PROGINSPEC.CODNROINSPEC);
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
        //Utilizado por	: BusinessLogic.SIC_PROGINSPEC.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_PROGINSPEC Recuperar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_PROGINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_PROGINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_PROGINSPEC.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_PROGINSPEC.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_PROGINSPEC ListarInspectores(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_LISTAR_RESPONSABLE", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_PROGINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_PROGINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_PROGINSPEC.CODTIPOSOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.ListarInspectores);
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
        //Utilizado por	: BusinessLogic.SIC_PROGINSPEC.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_PROGINSPEC
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_PROGINSPEC.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_PROGINSPEC.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_PROGINSPEC.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_PROGINSPEC.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_PROGINSPEC.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_PROGINSPEC.TXTIPREG);
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
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: BusinessLogic.SIC_PROGINSPEC.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PROGINSPEC
        /// </summary>
        public IEnumerable<BE.SIC_PROGINSPEC> Listar(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            List<BE.SIC_PROGINSPEC> lista = new List<BE.SIC_PROGINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_PROGINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_PROGINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_PROGINSPEC.CODTIPOSOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_PROGINSPEC ListarUltima(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            BE.SIC_PROGINSPEC lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_LISTAR_ULTIMA", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_PROGINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_PROGINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_PROGINSPEC.CODTIPOSOLI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.ListarNumero);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public IEnumerable<BE.SIC_PROGINSPEC> ListarNumero(BE.SIC_PROGINSPEC entSIC_PROGINSPEC)
        {
            List<BE.SIC_PROGINSPEC> lista = new List<BE.SIC_PROGINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_LISTAR_NUMERO", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_PROGINSPEC.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_PROGINSPEC.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_PROGINSPEC.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_PROGINSPEC.CTIPODOCUMENTO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.ListarNumero));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_PROGINSPEC> ListarStatusInspecciones(Int16 entTipoBusqueda, string entNroSolicitud, DateTime? FechaInicio, DateTime? FechaFin)
        {
            List<BE.SIC_PROGINSPEC> lista = new List<BE.SIC_PROGINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_LISTSTATUSINSPEC", new object[5]);
            db.SetParameterValue(dbCommand, "pvcTIPOBUSQUEDA", entTipoBusqueda);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entNroSolicitud);
            db.SetParameterValue(dbCommand, "pvcFECHAINICIO", FechaInicio);
            db.SetParameterValue(dbCommand, "pvcFECHAFIN", FechaFin);
            //db.SetParameterValue(dbCommand, "pvcCODIGOCATASTRAL", CodigoCatastral);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.StatusInspeccion));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_PROGINSPEC> ConsultaStatusInspecciones(BE.SIC_PROGINSPEC entConsultaInspeccion)
        {
            List<BE.SIC_PROGINSPEC> lista = new List<BE.SIC_PROGINSPEC>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_PROGINSPEC.PRC_CONSULTAINSPECCION", new object[6]);
            db.SetParameterValue(dbCommand, "pvcTIPOBUSQUEDA", entConsultaInspeccion.CODTIPOBUSQUEDA);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entConsultaInspeccion.TXTNUMSOLI);
            db.SetParameterValue(dbCommand, "pvcFECHAINICIO", entConsultaInspeccion.TXTFECHAINSPECCIONINICIO);
            db.SetParameterValue(dbCommand, "pvcFECHAFIN", entConsultaInspeccion.TXTFECHAINSPECCIONFIN);
            db.SetParameterValue(dbCommand, "pvcCODIGOCATASTRAL", entConsultaInspeccion.TXTCODCATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PROGINSPEC(reader, BE.SIC_PROGINSPEC.Query.ConsultaInspeccion));
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
