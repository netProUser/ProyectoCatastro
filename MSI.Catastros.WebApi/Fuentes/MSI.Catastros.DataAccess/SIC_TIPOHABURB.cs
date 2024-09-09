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
    public class SIC_TIPOHABURB : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOHABURB.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOHABURB
        /// </summary>
        public IEnumerable<BE.SIC_TIPOHABURB> Buscar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            List<BE.SIC_TIPOHABURB> lista = new List<BE.SIC_TIPOHABURB>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPOHABURB.PRC_BUSCAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcTXTHABILITAURBA", entSIC_TIPOHABURB.TXTHABILITAURBA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TIPOHABURB(reader, BE.SIC_TIPOHABURB.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOHABURB.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_TIPOHABURB Recuperar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_TIPOHABURB lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPOHABURB.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOHABURB", entSIC_TIPOHABURB.CODTIPOHABURB);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TIPOHABURB(reader, BE.SIC_TIPOHABURB.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOHABURB.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_TIPOHABURB, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPOHABURB.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTHABILITAURBA", DbType.String, entSIC_TIPOHABURB.TXTHABILITAURBA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOHABURB.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODTIPOHABURB", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODTIPOHABURB"));
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
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOHABURB.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPOHABURB.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcTXTHABILITAURBA", DbType.String, entSIC_TIPOHABURB.TXTHABILITAURBA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOHABURB.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODTIPOHABURB", DbType.String, entSIC_TIPOHABURB.CODTIPOHABURB);
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
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TIPOHABURB.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TIPOHABURB.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOHABURB", DbType.String, entSIC_TIPOHABURB.CODTIPOHABURB);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TIPOHABURB.CODUSUARIO);
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
