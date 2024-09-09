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
    public class SIC_INSCRIPCION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: BusinessLogic.SIC_INSCRIPCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INSCRIPCION
        /// </summary>
        public BE.SIC_INSCRIPCION Recuperar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_INSCRIPCION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_DATOS_TMP", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODINSCCATA", entSIC_INSCRIPCION.CODINSCCATA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_INSCRIPCION(reader, BE.SIC_INSCRIPCION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: BusinessLogic.SIC_INSCRIPCION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_INSCRIPCION
        /// </summary>
        public IEnumerable<BE.SIC_INSCRIPCION> Listar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            List<BE.SIC_INSCRIPCION> lista = new List<BE.SIC_INSCRIPCION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_LISTAR_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcTXTINSCRIPCION", entSIC_INSCRIPCION.TXTINSCRIPCION);
            db.SetParameterValue(dbCommand, "pvcTXTORDEN", entSIC_INSCRIPCION.TXTORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INSCRIPCION(reader, BE.SIC_INSCRIPCION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_INSCRIPCION> Buscar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            List<BE.SIC_INSCRIPCION> lista = new List<BE.SIC_INSCRIPCION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODINSCCATA", entSIC_INSCRIPCION.CODINSCCATA);
            db.SetParameterValue(dbCommand, "pvcTXTINSCRIPCION", entSIC_INSCRIPCION.TXTINSCRIPCION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_INSCRIPCION.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_INSCRIPCION.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_INSCRIPCION.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_INSCRIPCION(reader, BE.SIC_INSCRIPCION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_INSCRIPCION BuscarInt(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_INSCRIPCION lista = new BE.SIC_INSCRIPCION();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODINSCCATA", DbType.String, entSIC_INSCRIPCION.CODINSCCATA);
            db.AddInParameter(dbCommand, "pvcTXTINSCRIPCION", DbType.String, entSIC_INSCRIPCION.TXTINSCRIPCION);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_INSCRIPCION.PAGINAREGISTROS);
            db.AddOutParameter(dbCommand, "pinTOTPAG", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pinTOTREG", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                lista.TOTALPAGINAS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTPAG"));
                lista.TOTALREGISTROS = Convert.ToInt32(db.GetParameterValue(dbCommand, "pinTOTREG"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTINSCRIPCION", DbType.String, entSIC_INSCRIPCION.TXTINSCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTIPOANT", DbType.String, entSIC_INSCRIPCION.TXTIPOANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INSCRIPCION.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODINSCCATA", DbType.String, 3);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODINSCCATA"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODINSCCATA", DbType.String, entSIC_INSCRIPCION.CODINSCCATA);
            db.AddInParameter(dbCommand, "pvcTXTINSCRIPCION", DbType.String, entSIC_INSCRIPCION.TXTINSCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTIPOANT", DbType.String, entSIC_INSCRIPCION.TXTIPOANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INSCRIPCION.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_INSCRIPCION entSIC_INSCRIPCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_INSCRIPCION.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODINSCCATA", DbType.String, entSIC_INSCRIPCION.CODINSCCATA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_INSCRIPCION.CODUSUARIO);
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
