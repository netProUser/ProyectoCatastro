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
    public class SEG_USUARIO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SEG_USUARIO.ValidarAcceso
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SEG_USUARIO
        /// </summary>
        public BE.SEG_USUARIO ValidarAcceso(BE.SEG_USUARIO entSEG_USUARIO)
        {
            BE.SEG_USUARIO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand(EsquemaSeguridad + ".PKGCAS_SEGURIDAD.PS_USUARIOYCLAVE", new object[3]);
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaSeguridad + ".PKGCAS_LOGIN.PS_INICIARSESION", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSEG_USUARIO.CODUSUARIO);
            db.SetParameterValue(dbCommand, "pvcCONTRASENIA", entSEG_USUARIO.TXTPASSWORD);

            db.SetParameterValue(dbCommand, "pvcCODSISTEMA", entSEG_USUARIO.CODSISTEMA);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            try
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    lista = new BE.SEG_USUARIO(row, BE.SEG_USUARIO.Query.Recuperar);
                }
                //using (IDataReader reader = db.ExecuteReader(dbCommand))
                //{
                //    if (reader.Read())
                //        lista = new BE.SEG_USUARIO(reader, BE.SEG_USUARIO.Query.Recuperar);
                //}
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public IEnumerable<BE.SEG_OPCION> CargarOpciones(BE.SEG_USUARIO entSEG_USUARIO)
        {
            List<BE.SEG_OPCION> lista = new List<BE.SEG_OPCION>();

            Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand(EsquemaSeguridad + ".PKGCAS_SEGURIDAD.PS_INICIARSESIONS", new object[4]);
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaSeguridad + ".PKGCAS_LOGIN.PS_INICIARSESION", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODUSUARIO", entSEG_USUARIO.CODUSUARIO);
            db.SetParameterValue(dbCommand, "pvcCONTRASENIA", entSEG_USUARIO.TXTPASSWORD);
            db.SetParameterValue(dbCommand, "pvcCODSISTEMA", entSEG_USUARIO.CODSISTEMA);
            
            //db.SetParameterValue(dbCommand, "pvcCODSISTEMA", "010004");
            //db.AddOutParameter(dbCommand, "", DbType.Object, 30000);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(new BE.SEG_OPCION(row, BE.SEG_OPCION.Query.Listar));
                }
                //using (IDataReader reader = db.ExecuteReader(dbCommand))
                //{
                //    while (reader.Read())
                //        lista.Add(new BE.SEG_OPCION(reader, BE.SEG_OPCION.Query.Listar));
                //}
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SEG_USUARIO CambiarContraseña(BE.SEG_USUARIO entSIC_LOTELINDEROVIADET)
        {
            BE.SEG_USUARIO entSIC_RETORNO = new BE.SEG_USUARIO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKGCAS_LOGIN.PU_TXTPASSWORD";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaSeguridad + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTELINDEROVIADET.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTPASSANT", DbType.String, entSIC_LOTELINDEROVIADET.TXTPASSWORD);
            db.AddInParameter(dbCommand, "pvcTXTPASSNUE", DbType.String, entSIC_LOTELINDEROVIADET.TXTPASSWORDNUEVA);
            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
    }
}
