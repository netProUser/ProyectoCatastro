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
    public class SIC_URBAMANZA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: BusinessLogic.SIC_URBAMANZA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_URBAMANZA
        /// </summary>
        public IEnumerable<BE.SIC_URBAMANZA> Buscar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            List<BE.SIC_URBAMANZA> lista = new List<BE.SIC_URBAMANZA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBAMANZA.PRC_BUSCAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOHABURB", entSIC_URBAMANZA.CODTIPOHABURB);
            db.SetParameterValue(dbCommand, "pvcCODHABURBA", entSIC_URBAMANZA.CODHABURBA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOMANZA", entSIC_URBAMANZA.CODTIPOMANZA);
            db.SetParameterValue(dbCommand, "pvcTXTMANZAURB", entSIC_URBAMANZA.TXTMANZAURB);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_URBAMANZA(reader, BE.SIC_URBAMANZA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: BusinessLogic.SIC_URBAMANZA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_URBAMANZA Recuperar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_URBAMANZA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBAMANZA.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODMANZURB", entSIC_URBAMANZA.CODMANZURB);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_URBAMANZA(reader, BE.SIC_URBAMANZA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: BusinessLogic.SIC_URBAMANZA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_URBAMANZA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBAMANZA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_URBAMANZA.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcTXTMANZAURB", DbType.String, entSIC_URBAMANZA.TXTMANZAURB);
            db.AddInParameter(dbCommand, "pvcCODTIPOMANZA", DbType.String, entSIC_URBAMANZA.CODTIPOMANZA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBAMANZA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODMANZURB", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODMANZURB"));
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
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: BusinessLogic.SIC_URBAMANZA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBAMANZA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcTXTMANZAURB", DbType.String, entSIC_URBAMANZA.TXTMANZAURB);
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_URBAMANZA.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcCODTIPOMANZA", DbType.String, entSIC_URBAMANZA.CODTIPOMANZA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBAMANZA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODMANZURB", DbType.String, entSIC_URBAMANZA.CODMANZURB);
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
        //Creado por	: Pedro Peña Salazar (08/05/2018)
        //Utilizado por	: BusinessLogic.SIC_URBAMANZA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_URBAMANZA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_URBAMANZA entSIC_URBAMANZA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBAMANZA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODMANZURB", DbType.String, entSIC_URBAMANZA.CODMANZURB);
            db.AddInParameter(dbCommand, "pvcCODHABURBA", DbType.String, entSIC_URBAMANZA.CODHABURBA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBAMANZA.CODUSUARIO);
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
