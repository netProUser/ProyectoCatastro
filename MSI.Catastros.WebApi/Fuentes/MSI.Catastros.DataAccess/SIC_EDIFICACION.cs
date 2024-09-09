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
    public class SIC_EDIFICACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_EDIFICACION.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_EDIFICACION
        /// </summary>
        public IEnumerable<BE.SIC_EDIFICACION> Listar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            List<BE.SIC_EDIFICACION> lista = new List<BE.SIC_EDIFICACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_LISTAR_TMP", new object[1]);
            //db.SetParameterValue(dbCommand, "pvcCODTIPOINSP", entSIC_PUERTA.CODTIPOINSP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_EDIFICACION(reader, BE.SIC_EDIFICACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_EDIFICACION> Buscar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            List<BE.SIC_EDIFICACION> lista = new List<BE.SIC_EDIFICACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_BUSCAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOEDIF", entSIC_EDIFICACION.CODTIPOEDIF);
            db.SetParameterValue(dbCommand, "pvcTXTDESCRIPCION", entSIC_EDIFICACION.TXTDESCRIPCION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_EDIFICACION.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_EDIFICACION.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_EDIFICACION.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_EDIFICACION(reader, BE.SIC_EDIFICACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_EDIFICACION BuscarInt(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_EDIFICACION lista = new BE.SIC_EDIFICACION();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_EDIFICACION.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_EDIFICACION.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_EDIFICACION.PAGINAREGISTROS);
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
        public BE.SIC_EDIFICACION Recuperar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_EDIFICACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODTIPOEDIF", entSIC_EDIFICACION.CODTIPOEDIF);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_EDIFICACION(reader, BE.SIC_EDIFICACION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_RETORNO Grabar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_EDIFICACION.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVANT", DbType.String, entSIC_EDIFICACION.TXTABREVANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, 2);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODTIPOEDIF"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO Actualizar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_EDIFICACION.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcTXTDESCRIPCION", DbType.String, entSIC_EDIFICACION.TXTDESCRIPCION);
            db.AddInParameter(dbCommand, "pvcTXTABREVANT", DbType.String, entSIC_EDIFICACION.TXTABREVANT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_EDIFICACION entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_EDIFICACION.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOEDIF", DbType.String, entSIC_EDIFICACION.CODTIPOEDIF);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_EDIFICACION.CODUSUARIO);
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
