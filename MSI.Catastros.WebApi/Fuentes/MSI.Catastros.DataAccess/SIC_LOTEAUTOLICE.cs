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
    public class SIC_LOTEAUTOLICE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOLICE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEAUTOLICE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOLICE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOLICE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOLICE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEAUTOLICE.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_LOTEAUTOLICE.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLICENCIA", DbType.String, entSIC_LOTEAUTOLICE.TXTTIPOLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_LOTEAUTOLICE.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTGIRO", DbType.String, entSIC_LOTEAUTOLICE.TXTGIRO);
            db.AddInParameter(dbCommand, "pvcCODGIRO", DbType.String, entSIC_LOTEAUTOLICE.CODGIRO);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_LOTEAUTOLICE.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_LOTEAUTOLICE.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRLOTEAUTOLICE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLOTEAUTOLICE"));
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOLICE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOLICE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOLICE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOLICE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITANTE", DbType.String, entSIC_LOTEAUTOLICE.TXTSOLICITANTE);
            db.AddInParameter(dbCommand, "pvcTXTBENEFICIARIO", DbType.String, entSIC_LOTEAUTOLICE.TXTBENEFICIARIO);
            db.AddInParameter(dbCommand, "pvcTXTTIPOLICENCIA", DbType.String, entSIC_LOTEAUTOLICE.TXTTIPOLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTNUMLICENCIA", DbType.String, entSIC_LOTEAUTOLICE.TXTNUMLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTGIRO", DbType.String, entSIC_LOTEAUTOLICE.TXTGIRO);
            db.AddInParameter(dbCommand, "pvcCODGIRO", DbType.String, entSIC_LOTEAUTOLICE.CODGIRO);
            db.AddInParameter(dbCommand, "pvcFECLICENCIA", DbType.Date, entSIC_LOTEAUTOLICE.FECLICENCIA);
            db.AddInParameter(dbCommand, "pvcTXTCODUNICO", DbType.String, entSIC_LOTEAUTOLICE.TXTCODUNICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOLICE", DbType.String, entSIC_LOTEAUTOLICE.CODCORRLOTEAUTOLICE);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOLICE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEAUTOLICE
        /// </summary>
        public BE.SIC_LOTEAUTOLICE Recuperar(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            BE.SIC_LOTEAUTOLICE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEAUTOLICE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEAUTOLICE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEAUTOLICE.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODCORRLOTEAUTOLICE", entSIC_LOTEAUTOLICE.CODCORRLOTEAUTOLICE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEAUTOLICE(reader, BE.SIC_LOTEAUTOLICE.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOLICE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEAUTOLICE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOLICE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOLICE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOLICE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODCORRLOTEAUTOLICE", DbType.String, entSIC_LOTEAUTOLICE.CODCORRLOTEAUTOLICE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_LOTEAUTOLICE.TXTIPREG);
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
        public BE.SIC_RETORNO EliminarLote(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_ELIMINAR_LOTE" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_ELIMINAR_LOTE_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEAUTOLICE.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEAUTOLICE.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEAUTOLICE.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEAUTOLICE.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_LOTEAUTOLICE.TXTIPREG);
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
        //Creado por	: Jaime Díaz Espinoza (26/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEAUTOLICE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEAUTOLICE
        /// </summary>
        public IEnumerable<BE.SIC_LOTEAUTOLICE> Buscar(BE.SIC_LOTEAUTOLICE entSIC_LOTEAUTOLICE)
        {
            List<BE.SIC_LOTEAUTOLICE> lista = new List<BE.SIC_LOTEAUTOLICE>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTEAUTOLICE.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTEAUTOLICE.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEAUTOLICE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEAUTOLICE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEAUTOLICE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEAUTOLICE.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEAUTOLICE.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEAUTOLICE.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTEAUTOLICE.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEAUTOLICE(reader, BE.SIC_LOTEAUTOLICE.Query.Listar));
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
