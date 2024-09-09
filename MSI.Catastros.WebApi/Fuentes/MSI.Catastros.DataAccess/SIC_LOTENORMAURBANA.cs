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
    public class SIC_LOTENORMAURBANA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (02/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTENORMAURBANA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTENORMAURBANA
        /// </summary>
        public IEnumerable<BE.SIC_LOTENORMAURBANA> Buscar(BE.SIC_LOTENORMAURBANA entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTENORMAURBANA> lista = new List<BE.SIC_LOTENORMAURBANA>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTENORMAURBANA(reader, BE.SIC_LOTENORMAURBANA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTENORMAURBANA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTENORMAURBANA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTENORMAURBANA entSIC_LOTENORMAURBANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTENORMAURBANA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTENORMAURBANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTENORMAURBANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTENORMAURBANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTENORMAURBANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTENORMAURBANA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTENORMAURBANA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTENORMAURBANA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTENORMAURBANA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMALTURA", DbType.Decimal, entSIC_LOTENORMAURBANA.NUMALTURA);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTENORMAURBANA.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTALTURA", DbType.String, entSIC_LOTENORMAURBANA.TXTALTURA);
            db.AddInParameter(dbCommand, "pvcTXTZONIFICACION", DbType.String, entSIC_LOTENORMAURBANA.TXTZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTENORMAURBANA.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTENORMAURBANA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTENORMAURBANA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTENORMAURBANA entSIC_LOTENORMAURBANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTENORMAURBANA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTENORMAURBANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTENORMAURBANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTENORMAURBANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTENORMAURBANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTENORMAURBANA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTENORMAURBANA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTENORMAURBANA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTENORMAURBANA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcNUMALTURA", DbType.Decimal, entSIC_LOTENORMAURBANA.NUMALTURA);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_LOTENORMAURBANA.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcTXTALTURA", DbType.String, entSIC_LOTENORMAURBANA.TXTALTURA);
            db.AddInParameter(dbCommand, "pvcTXTZONIFICACION", DbType.String, entSIC_LOTENORMAURBANA.TXTZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTENORMAURBANA.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTENORMAURBANA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTENORMAURBANA
        /// </summary>
        public BE.SIC_LOTENORMAURBANA Recuperar(BE.SIC_LOTENORMAURBANA entSIC_LOTENORMAURBANA)
        {
            BE.SIC_LOTENORMAURBANA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTENORMAURBANA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTENORMAURBANA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTENORMAURBANA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTENORMAURBANA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTENORMAURBANA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTENORMAURBANA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTENORMAURBANA.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTENORMAURBANA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTENORMAURBANA.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTENORMAURBANA(reader, BE.SIC_LOTENORMAURBANA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (11/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTENORMAURBANA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTENORMAURBANA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTENORMAURBANA entSIC_LOTENORMAURBANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTENORMAURBANA.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTENORMAURBAN.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);

            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTENORMAURBANA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTENORMAURBANA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTENORMAURBANA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTENORMAURBANA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTENORMAURBANA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTENORMAURBANA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTENORMAURBANA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTENORMAURBANA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTENORMAURBANA.CODUSUARIO);
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
    }
}
