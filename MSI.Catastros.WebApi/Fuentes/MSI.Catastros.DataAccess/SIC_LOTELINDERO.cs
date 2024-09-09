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
    public class SIC_LOTELINDERO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTELINDERO, retorna numero de ERROR o ID generado
        /// </summary>
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTELINDERO
        /// </summary>
       
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTELINDERO
        /// </summary>
        public BE.SIC_LOTELINDERO Recuperar(BE.SIC_LOTELINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_LOTELINDERO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERO.PRC_DATOS" : ".PKG_MSISIC_PROC_LOTELINDERO.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDERO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDERO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDERO.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDERO.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDERO.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDERO.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_LOTELINDERO.CODLADO);
            db.SetParameterValue(dbCommand, "pvcCODCORRLADO", entSIC_LOTELINDERO.CODCORRLADO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTELINDERO(reader, BE.SIC_LOTELINDERO.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTELINDERO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTELINDERO entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERO.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_LOTELINDERO.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTELINDERO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTELINDERO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTELINDERO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTELINDERO.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTELINDERO.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTELINDERO.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_LOTELINDERO.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODCORRLADO", DbType.String, entSIC_LOTELINDERO.CODCORRLADO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDERO.CODUSUARIO);
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
        //Creado por	: Pedro Peña Salazar (28/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTELINDERO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTEOBSERVACION
        /// </summary>
        public IEnumerable<BE.SIC_LOTELINDERO> Buscar(BE.SIC_LOTELINDERO entSIC_LOTELINDERO)
        {
            List<BE.SIC_LOTELINDERO> lista = new List<BE.SIC_LOTELINDERO>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_LOTELINDERO.ESTATICO == true) ? ".PKG_MSISIC_PROC_LOTELINDERO.PRC_BUSCAR" : ".PKG_MSISIC_PROC_LOTELINDERO.PRC_BUSCAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDERO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDERO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDERO.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDERO.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDERO.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTELINDERO.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_LOTELINDERO.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTELINDERO(reader, BE.SIC_LOTELINDERO.Query.Listar));
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
