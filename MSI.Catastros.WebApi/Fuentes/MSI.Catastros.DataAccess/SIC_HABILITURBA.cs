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
    public class SIC_HABILITURBA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_HABILITURBA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_HABILITURBA
        /// </summary>
        public IEnumerable<BE.SIC_HABILITURBA> Buscar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            List<BE.SIC_HABILITURBA> lista = new List<BE.SIC_HABILITURBA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABILITURBA.PRC_BUSCAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOHABURB", entSIC_HABILITURBA.CODTIPOHABURB);
            db.SetParameterValue(dbCommand, "pvcTXTURBANIZACION", entSIC_HABILITURBA.TXTURBANIZACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_HABILITURBA(reader, BE.SIC_HABILITURBA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_HABILITURBA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_HABILITURBA Recuperar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_HABILITURBA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABILITURBA.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODHABURBA", entSIC_HABILITURBA.CODHABURBA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_HABILITURBA(reader, BE.SIC_HABILITURBA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_HABILITURBA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_HABILITURBA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABILITURBA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOHABURB", DbType.String, entSIC_HABILITURBA.CODTIPOHABURB);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_HABILITURBA.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_HABILITURBA.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_HABILITURBA.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcFECACTDOCU", DbType.Date, entSIC_HABILITURBA.FECACTDOCU);
            db.AddInParameter(dbCommand, "pvcTXTDIFERENCIADORHABURBA", DbType.String, entSIC_HABILITURBA.TXTDIFERENCIADORHABURBA);
            db.AddInParameter(dbCommand, "pvcFECAPROBACION", DbType.Date, entSIC_HABILITURBA.FECAPROBACION);
            db.AddInParameter(dbCommand, "pvcTXTNUMDOCPROB", DbType.String, entSIC_HABILITURBA.TXTNUMDOCPROB);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABILITURBA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODHABURBA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODHABURBA"));
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_HABILITURBA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABILITURBA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOHABURB", DbType.String, entSIC_HABILITURBA.CODTIPOHABURB);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_HABILITURBA.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_HABILITURBA.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_HABILITURBA.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcFECACTDOCU", DbType.Date, entSIC_HABILITURBA.FECACTDOCU);
            db.AddInParameter(dbCommand, "pvcTXTDIFERENCIADORHABURBA", DbType.String, entSIC_HABILITURBA.TXTDIFERENCIADORHABURBA);
            db.AddInParameter(dbCommand, "pvcFECAPROBACION", DbType.Date, entSIC_HABILITURBA.FECAPROBACION);
            db.AddInParameter(dbCommand, "pvcTXTNUMDOCPROB", DbType.String, entSIC_HABILITURBA.TXTNUMDOCPROB);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABILITURBA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_HABILITURBA.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcTXTRUTAIMAGEN", DbType.String, entSIC_HABILITURBA.TXTRUTAIMAGEN);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_HABILITURBA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABILITURBA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_HABILITURBA.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABILITURBA.CODUSUARIO);
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
