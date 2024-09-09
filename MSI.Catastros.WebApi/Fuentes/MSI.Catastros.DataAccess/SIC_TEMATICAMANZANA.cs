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
    public class SIC_TEMATICAMANZANA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TEMATICAMANZANA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public IEnumerable<BE.SIC_TEMATICAMANZANA> Buscar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            List<BE.SIC_TEMATICAMANZANA> lista = new List<BE.SIC_TEMATICAMANZANA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TEMATICAMANZAN.PRC_BUSCAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcTXTTEMATICO", entSIC_TEMATICAMANZANA.TXTTEMATICO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_TEMATICAMANZANA(reader, BE.SIC_TEMATICAMANZANA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TEMATICAMANZANA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_TEMATICAMANZANA Recuperar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_TEMATICAMANZANA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TEMATICAMANZAN.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTEMATICO", entSIC_TEMATICAMANZANA.CODTEMATICO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_TEMATICAMANZANA(reader, BE.SIC_TEMATICAMANZANA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TEMATICAMANZANA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_TEMATICAMANZANA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TEMATICAMANZAN.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTTEMATICO", DbType.String, entSIC_TEMATICAMANZANA.TXTTEMATICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TEMATICAMANZANA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODTEMATICO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODTEMATICO"));
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
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TEMATICAMANZANA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TEMATICAMANZAN.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcTXTTEMATICO", DbType.String, entSIC_TEMATICAMANZANA.TXTTEMATICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TEMATICAMANZANA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODTEMATICO", DbType.String, entSIC_TEMATICAMANZANA.CODTEMATICO);
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
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: BusinessLogic.SIC_TEMATICAMANZANA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_TEMATICAMANZAN.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODTEMATICO", DbType.String, entSIC_TEMATICAMANZANA.CODTEMATICO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_TEMATICAMANZANA.CODUSUARIO);
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
