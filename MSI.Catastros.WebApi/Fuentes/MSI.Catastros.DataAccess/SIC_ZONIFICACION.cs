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
    public class SIC_ZONIFICACION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFICACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ZONIFICACION
        /// </summary>
        public IEnumerable<BE.SIC_ZONIFICACION> Buscar(BE.SIC_ZONIFICACION entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_ZONIFICACION> lista = new List<BE.SIC_ZONIFICACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_BUSCAR", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_ZONIFICACION(reader, BE.SIC_ZONIFICACION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFICACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ZONIFICACION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFICACION.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcTXTZONIFICACION", DbType.String, entSIC_ZONIFICACION.TXTZONIFICACION);
            db.AddInParameter(dbCommand, "pvcTXTABREVIACION", DbType.String, entSIC_ZONIFICACION.TXTABREVIACION);
          // db.AddInParameter(dbCommand, "pvcCONTROL", DbType.DateTime, entSIC_ZONIFICACION.CONTROL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFICACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFICACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFICACION.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcTXTZONIFICACION", DbType.String, entSIC_ZONIFICACION.TXTZONIFICACION);
            db.AddInParameter(dbCommand, "pvcTXTABREVIACION", DbType.String, entSIC_ZONIFICACION.TXTABREVIACION);
         // db.AddInParameter(dbCommand, "pvcCONTROL", DbType.DateTime, entSIC_ZONIFICACION.CONTROL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFICACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFICACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_ZONIFICACION Recuperar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_ZONIFICACION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_DATOS", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODZONIFICACION", entSIC_ZONIFICACION.CODZONIFICACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_ZONIFICACION(reader, BE.SIC_ZONIFICACION.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFICACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ZONIFICACION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ZONIFICACION entSIC_ZONIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFICACION.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFICACION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
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
        public BE.SIC_ZONIFICACION BuscarGrillaZonificacion(BE.SIC_ZONIFICACION entSIC_USOESPE)
        {
            BE.SIC_ZONIFICACION lista = new BE.SIC_ZONIFICACION();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_BUSCAR_PAG");
            db.AddInParameter(dbCommand, "pvcTXTZONIFICACION", DbType.String, entSIC_USOESPE.TXTZONIFICACION);
            db.AddInParameter(dbCommand, "pvcTXTABREVIACION", DbType.String, entSIC_USOESPE.TXTABREVIACION);
            db.AddInParameter(dbCommand, "pinNUMPAG", DbType.Int32, entSIC_USOESPE.PAGINANUMERO);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_USOESPE.PAGINAREGISTROS);
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
        public IEnumerable<BE.SIC_ZONIFICACION> BuscarDetalleGrilla(BE.SIC_ZONIFICACION entSIC_USOESPE)
        {
            List<BE.SIC_ZONIFICACION> lista = new List<BE.SIC_ZONIFICACION>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFICACION.PRC_BUSCAR_DET", new object[6]);
            db.SetParameterValue(dbCommand, "pvcTXTZONIFICACION", entSIC_USOESPE.TXTZONIFICACION);
            db.SetParameterValue(dbCommand, "pvcTXTABREVIACION",  entSIC_USOESPE.TXTABREVIACION);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_USOESPE.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_USOESPE.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_USOESPE.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_ZONIFICACION(reader, BE.SIC_ZONIFICACION.Query.ListarGrilla));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

    }
}
