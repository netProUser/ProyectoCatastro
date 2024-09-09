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
    public class SIC_UNIDADAUTOLICE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOLICE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADAUTOLICE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOLICE.CODUNI);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADAUTOLICE.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_UNIDADAUTOLICE.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLICENCIA", DbType.String, entSIC_UNIDADAUTOLICE.TXTTIPOLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_UNIDADAUTOLICE.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTGIRO", DbType.String, entSIC_UNIDADAUTOLICE.TXTGIRO);
            db.AddInParameter(dbCommand, "pvcCODGIRO", DbType.String, entSIC_UNIDADAUTOLICE.CODGIRO);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_UNIDADAUTOLICE.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_UNIDADAUTOLICE.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOLICE", DbType.String, entSIC_UNIDADAUTOLICE.CODCORRLOTEAUTOLICE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOLICE.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRAUTOLICE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRAUTOLICE"));
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
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOLICE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOLICE.CODUNI);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_UNIDADAUTOLICE.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_UNIDADAUTOLICE.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLICENCIA", DbType.String, entSIC_UNIDADAUTOLICE.TXTTIPOLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_UNIDADAUTOLICE.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTGIRO", DbType.String, entSIC_UNIDADAUTOLICE.TXTGIRO);
            db.AddInParameter(dbCommand, "pvcCODGIRO", DbType.String, entSIC_UNIDADAUTOLICE.CODGIRO);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_UNIDADAUTOLICE.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_UNIDADAUTOLICE.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOLICE", DbType.String, entSIC_UNIDADAUTOLICE.CODCORRLOTEAUTOLICE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOLICE.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRAUTOLICE", DbType.String, entSIC_UNIDADAUTOLICE.CODCORRAUTOLICE);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOLICE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_UNIDADAUTOLICE Recuperar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_UNIDADAUTOLICE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOLICE.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRAUTOLICE", entSIC_UNIDADAUTOLICE.CODCORRAUTOLICE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADAUTOLICE(reader, BE.SIC_UNIDADAUTOLICE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADAUTOLICE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADAUTOLICE.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRAUTOLICE", DbType.String, entSIC_UNIDADAUTOLICE.CODCORRAUTOLICE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADAUTOLICE.TXTIPREG);
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

        public IEnumerable<BE.SIC_UNIDADAUTOLICE> Listar(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            List<BE.SIC_UNIDADAUTOLICE> lista = new List<BE.SIC_UNIDADAUTOLICE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADAUTOLICE.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);  

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOLICE.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADAUTOLICE(reader, BE.SIC_UNIDADAUTOLICE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        
         public IEnumerable<BE.SIC_UNIDADAUTOLICE> CargarUnidadLicenciasFuncHistorica(BE.SIC_UNIDADAUTOLICE entSIC_UNIDADAUTOLICE)
        {
            List<BE.SIC_UNIDADAUTOLICE> lista = new List<BE.SIC_UNIDADAUTOLICE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_OBTENERLICENCIAHISTORICO";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);

            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADAUTOLICE.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADAUTOLICE.NUMVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADAUTOLICE(reader, BE.SIC_UNIDADAUTOLICE.Query.Listar));
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
