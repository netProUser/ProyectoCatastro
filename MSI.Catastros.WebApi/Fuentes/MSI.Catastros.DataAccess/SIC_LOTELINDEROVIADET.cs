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
    public class SIC_LOTELINDEROVIADET : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (02/07/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDEROVIADET.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public IEnumerable<BE.SIC_LOTELINDEROVIADET> Buscar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTELINDEROVIADET> lista = new List<BE.SIC_LOTELINDEROVIADET>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTELINDEROVIADET.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CODCORRLADO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTELINDEROVIADET(reader, BE.SIC_LOTELINDEROVIADET.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        

        public IEnumerable<BE.SIC_LOTELINDEROVIADET> BuscarVias(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTELINDEROVIADET> lista = new List<BE.SIC_LOTELINDEROVIADET>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_BUSCAR_VIASESQ" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_BUSCAR_VIASESQ_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTELINDEROVIADET.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CODCORRLADO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTELINDEROVIADET(reader, BE.SIC_LOTELINDEROVIADET.Query.ListarVia));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDEROVIADET.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTELINDEROVIADET, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_INSERTAR" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDEROVIADET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcFLGPARQUE", DbType.String, entSIC_LOTELINDEROVIADET.FLAGPARQUE);
            db.AddInParameter(dbCommand, "pvcFLGAVE", DbType.String, entSIC_LOTELINDEROVIADET.FLAGAVE);
            db.AddInParameter(dbCommand, "pvcCODALTVIAFOR", DbType.String, entSIC_LOTELINDEROVIADET.CODALTVIAFOR);             
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRLADO"));
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
        //Utilizado por	: BusinessLogic.SIC_LOTELINDEROVIADET.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDEROVIADET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcFLGPARQUE", DbType.String, entSIC_LOTELINDEROVIADET.FLAGPARQUE);
            db.AddInParameter(dbCommand, "pvcFLGAVE", DbType.String, entSIC_LOTELINDEROVIADET.FLAGAVE);
            db.AddInParameter(dbCommand, "pvcCODALTVIAFOR", DbType.String, entSIC_LOTELINDEROVIADET.CODALTVIAFOR);             
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
        //Utilizado por	: BusinessLogic.SIC_LOTELINDEROVIADET.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_LOTELINDEROVIADET Recuperar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_LOTELINDEROVIADET lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDEROVIADET.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDEROVIADET.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDEROVIADET.CODCORRLADO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTELINDEROVIADET.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTELINDEROVIADET(reader, BE.SIC_LOTELINDEROVIADET.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTELINDEROVIADET.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTELINDEROVIADET
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTELINDEROVIA.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
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
        
         public BE.SIC_RETORNO EliminarColindante(BE.SIC_LOTELINDEROVIADET entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDEROVIADET.ESTATICO == true) ? ".PKG_MSISIC_LOTELINDEROD.PRC_ELIMINAR_LINDERODET" : ".PKG_MSISIC_LOTELINDEROD.PRC_ELIMINAR_LINDERODET_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDEROVIADET.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDEROVIADET.CODCORRLADO);
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
        
    }
}
