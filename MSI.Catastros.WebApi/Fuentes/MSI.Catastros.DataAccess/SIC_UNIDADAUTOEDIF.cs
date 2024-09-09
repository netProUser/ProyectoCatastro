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
    public class SIC_UNIDADAUTOEDIF : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOEDIF.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADAUTOEDIF, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOEDIF.CODUNI);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADAUTOEDIF.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_UNIDADAUTOEDIF.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_UNIDADAUTOEDIF.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOOBRA", DbType.String, entSIC_UNIDADAUTOEDIF.TXTTIPOOBRA);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_UNIDADAUTOEDIF.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_UNIDADAUTOEDIF.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOEDIF", DbType.String, entSIC_UNIDADAUTOEDIF.CODCORRLOTEAUTOEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOEDIF.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOEDIF.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDAE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDAE"));
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
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOEDIF.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOEDIF.CODUNI);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADAUTOEDIF.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_UNIDADAUTOEDIF.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_UNIDADAUTOEDIF.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOOBRA", DbType.String, entSIC_UNIDADAUTOEDIF.TXTTIPOOBRA);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_UNIDADAUTOEDIF.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_UNIDADAUTOEDIF.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOEDIF", DbType.String, entSIC_UNIDADAUTOEDIF.CODCORRLOTEAUTOEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOEDIF.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOEDIF.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDAE", DbType.String, entSIC_UNIDADAUTOEDIF.CODCORRUNIDAE);
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
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOEDIF.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_UNIDADAUTOEDIF Recuperar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_UNIDADAUTOEDIF lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOEDIF.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDAE", entSIC_UNIDADAUTOEDIF.CODCORRUNIDAE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADAUTOEDIF(reader, BE.SIC_UNIDADAUTOEDIF.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOEDIF.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOEDIF.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDAE", DbType.String, entSIC_UNIDADAUTOEDIF.CODCORRUNIDAE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOEDIF.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOEDIF.TXTIPREG);
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
        //Creado por	: Juan Quispe Ipanaque (26/07/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOEDIF.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los registro de la tabla SIC_UNIDADAUTOEDIF
        /// </summary>
        public IEnumerable<BE.SIC_UNIDADAUTOEDIF> Listar(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            List<BE.SIC_UNIDADAUTOEDIF> lista = new List<BE.SIC_UNIDADAUTOEDIF>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADAUTOEDIF.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);  
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOEDIF.CODUNI);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADAUTOEDIF(reader, BE.SIC_UNIDADAUTOEDIF.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADAUTOEDIF> CargarUnidadObrasPrivadasHistoricas(BE.SIC_UNIDADAUTOEDIF entSIC_UNIDADAUTOEDIF)
        {
            List<BE.SIC_UNIDADAUTOEDIF> lista = new List<BE.SIC_UNIDADAUTOEDIF>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENEROBRASHISTORICO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOEDIF.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADAUTOEDIF.NUMVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADAUTOEDIF(reader, BE.SIC_UNIDADAUTOEDIF.Query.Listar));
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
