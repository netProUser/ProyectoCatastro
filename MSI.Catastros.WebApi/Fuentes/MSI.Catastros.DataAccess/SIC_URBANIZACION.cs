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
    public class SIC_URBANIZACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_URBANIZACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_URBANIZACION
        /// </summary>
        public IEnumerable<BE.SIC_URBANIZACION> Buscar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            List<BE.SIC_URBANIZACION> lista = new List<BE.SIC_URBANIZACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBANIZACION.PRC_BUSCAR", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_URBANIZACION.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_URBANIZACION.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_URBANIZACION.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcTXTURBANIZACION", entSIC_URBANIZACION.TXTURBANIZACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_URBANIZACION(reader, BE.SIC_URBANIZACION.Query.Listar));
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
        //Utilizado por	: BusinessLogic.SIC_URBANIZACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_URBANIZACION
        /// </summary>
        public BE.SIC_URBANIZACION Recuperar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            BE.SIC_URBANIZACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBANIZACION.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_URBANIZACION.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_URBANIZACION.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_URBANIZACION.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODURBANIZACION", entSIC_URBANIZACION.CODURBANIZACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_URBANIZACION(reader, BE.SIC_URBANIZACION.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_URBANIZACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_URBANIZACION, retorna numero de ERROR o ID generado
        /// </summary>
        public int Grabar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBANIZACION.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_URBANIZACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_URBANIZACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_URBANIZACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_URBANIZACION.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBANIZACION.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODURBANIZACION", DbType.String, 10);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                intResultado = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcCODURBANIZACION"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intResultado;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_URBANIZACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_URBANIZACION
        /// </summary>
        public int Actualizar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBANIZACION.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_URBANIZACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_URBANIZACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_URBANIZACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODURBANIZACION", DbType.String, entSIC_URBANIZACION.CODURBANIZACION);
            db.AddInParameter(dbCommand, "pvcTXTURBANIZACION", DbType.String, entSIC_URBANIZACION.TXTURBANIZACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBANIZACION.CODUSUARIO);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                intResultado = 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intResultado;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_URBANIZACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_URBANIZACION
        /// </summary>
        public int Eliminar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_URBANIZACION.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_URBANIZACION.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_URBANIZACION.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_URBANIZACION.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODURBANIZACION", DbType.String, entSIC_URBANIZACION.CODURBANIZACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_URBANIZACION.CODUSUARIO);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                intResultado = 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intResultado;
        }
    }
}
