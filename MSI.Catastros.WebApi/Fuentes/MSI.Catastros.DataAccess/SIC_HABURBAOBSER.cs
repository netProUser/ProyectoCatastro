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
    public class SIC_HABURBAOBSER : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (26/09/2018)
        //Utilizado por	: BusinessLogic.SIC_HABURBAOBSER.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_HABURBAOBSER
        /// </summary>
        public IEnumerable<BE.SIC_HABURBAOBSER> Listar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            List<BE.SIC_HABURBAOBSER> lista = new List<BE.SIC_HABURBAOBSER>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABURBAOBSER.PRC_LISTAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODHABURBA", entSIC_HABURBAOBSER.CODHABURBA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_HABURBAOBSER(reader, BE.SIC_HABURBAOBSER.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (26/09/2018)
        //Utilizado por	: BusinessLogic.SIC_HABURBAOBSER.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_HABURBAOBSER Recuperar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_HABURBAOBSER lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABURBAOBSER.PRC_DATOS", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODHABURBA", entSIC_HABURBAOBSER.CODHABURBA);
            db.SetParameterValue(dbCommand, "pvcCODCORRELOBS", entSIC_HABURBAOBSER.CODCORRELOBS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_HABURBAOBSER(reader, BE.SIC_HABURBAOBSER.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (26/09/2018)
        //Utilizado por	: BusinessLogic.SIC_HABURBAOBSER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_HABURBAOBSER, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABURBAOBSER.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_HABURBAOBSER.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVA", DbType.String, entSIC_HABURBAOBSER.TXTOBSERVA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABURBAOBSER.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODCORRELOBS", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELOBS"));
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
        //Creado por	: Pedro Peña Salazar (26/09/2018)
        //Utilizado por	: BusinessLogic.SIC_HABURBAOBSER.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABURBAOBSER.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_HABURBAOBSER.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcCODCORRELOBS", DbType.String, entSIC_HABURBAOBSER.CODCORRELOBS);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVA", DbType.String, entSIC_HABURBAOBSER.TXTOBSERVA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABURBAOBSER.CODUSUARIO);
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
        //Creado por	: Pedro Peña Salazar (26/09/2018)
        //Utilizado por	: BusinessLogic.SIC_HABURBAOBSER.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_HABURBAOBSER
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_HABURBAOBSER entSIC_HABURBAOBSER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_HABURBAOBSER.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_HABURBAOBSER.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcCODCORRELOBS", DbType.String, entSIC_HABURBAOBSER.CODCORRELOBS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_HABURBAOBSER.CODUSUARIO);
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
