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
    public class SIC_LOTEAUTOEDIF : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOEDIF.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEAUTOEDIF, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOEDIF.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEAUTOEDIF.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_LOTEAUTOEDIF.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOOBRA", DbType.String, entSIC_LOTEAUTOEDIF.TXTTIPOOBRA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_LOTEAUTOEDIF.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_LOTEAUTOEDIF.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_LOTEAUTOEDIF.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOEDIF.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLOTEAUTOEDIF", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTEAUTOEDIF"));
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
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOEDIF.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOEDIF.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEAUTOEDIF.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_LOTEAUTOEDIF.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOOBRA", DbType.String, entSIC_LOTEAUTOEDIF.TXTTIPOOBRA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_LOTEAUTOEDIF.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_LOTEAUTOEDIF.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_LOTEAUTOEDIF.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOEDIF.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOEDIF", DbType.String, entSIC_LOTEAUTOEDIF.CODCORRLOTEAUTOEDIF);
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
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOEDIF.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_LOTEAUTOEDIF Recuperar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_LOTEAUTOEDIF lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEAUTOEDIF.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODCORRLOTEAUTOEDIF", entSIC_LOTEAUTOEDIF.CODCORRLOTEAUTOEDIF);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEAUTOEDIF(reader, BE.SIC_LOTEAUTOEDIF.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (17/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOEDIF.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOEDIF.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOEDIF", DbType.String, entSIC_LOTEAUTOEDIF.CODCORRLOTEAUTOEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOEDIF.CODUSUARIO);
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
        public BE.SIC_RETORNO EliminarLote(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_ELIMINAR_LOTE" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_ELIMINAR_LOTE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOEDIF.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOEDIF.CODUSUARIO);
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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (26/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOEDIF.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEAUTOEDIF
        /// </summary>
        public IEnumerable<BE.SIC_LOTEAUTOEDIF> Buscar(BE.SIC_LOTEAUTOEDIF entSIC_LOTEAUTOEDIF)
        {
            List<BE.SIC_LOTEAUTOEDIF> lista = new List<BE.SIC_LOTEAUTOEDIF>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOEDIF.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTEAUTOEDIF.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEAUTOEDIF.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEAUTOEDIF.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEAUTOEDIF.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEAUTOEDIF.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEAUTOEDIF.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEAUTOEDIF.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTEAUTOEDIF.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEAUTOEDIF(reader, BE.SIC_LOTEAUTOEDIF.Query.Listar));
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
