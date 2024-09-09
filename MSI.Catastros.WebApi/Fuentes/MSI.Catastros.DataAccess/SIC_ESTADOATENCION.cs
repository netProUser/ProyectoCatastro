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
    public class SIC_ESTADOATENCION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: BusinessLogic.SIC_ESTADOATENCION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ESTADOATENCION
        /// </summary>
        public IEnumerable<BE.SIC_ESTADOATENCION> Buscar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            List<BE.SIC_ESTADOATENCION> lista = new List<BE.SIC_ESTADOATENCION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_ESTADOATENCION.PRC_BUSCAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcTXTESTADOATENCION", entSIC_ESTADOATENCION.TXTESTADOATENCION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_ESTADOATENCION(reader, BE.SIC_ESTADOATENCION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: BusinessLogic.SIC_ESTADOATENCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_ESTADOATENCION Recuperar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_ESTADOATENCION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_ESTADOATENCION.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODESTATENCION", entSIC_ESTADOATENCION.CODESTATENCION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_ESTADOATENCION(reader, BE.SIC_ESTADOATENCION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: BusinessLogic.SIC_ESTADOATENCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ESTADOATENCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_ESTADOATENCION.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTESTADOATENCION", DbType.String, entSIC_ESTADOATENCION.TXTESTADOATENCION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ESTADOATENCION.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODESTATENCION", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODESTATENCION"));
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
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: BusinessLogic.SIC_ESTADOATENCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_ESTADOATENCION.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcTXTESTADOATENCION", DbType.String, entSIC_ESTADOATENCION.TXTESTADOATENCION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ESTADOATENCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODESTATENCION", DbType.String, entSIC_ESTADOATENCION.CODESTATENCION);
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
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: BusinessLogic.SIC_ESTADOATENCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ESTADOATENCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ESTADOATENCION entSIC_ESTADOATENCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_ESTADOATENCION.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODESTATENCION", DbType.String, entSIC_ESTADOATENCION.CODESTATENCION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ESTADOATENCION.CODUSUARIO);
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
