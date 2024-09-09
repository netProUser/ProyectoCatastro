using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace MSI.Catastros.DataAccess
{
    public class SIC_PARAMETROS : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/06/2018)
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.TipoError
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> TipoError(string iCODGRUPOPARAMETRO)
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_ERRORES", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODGRUPOPARAMETRO", iCODGRUPOPARAMETRO);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Datos));
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
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> Listar(int iCODGRUPOPARAMETRO)
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_LISTAR", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODGRUPOPARAMETRO", iCODGRUPOPARAMETRO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.TipoAccion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> TipoAccion()
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_ACCIONES", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODAREA", CodigoArea);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Datos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.TipoActividad
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> TipoActividad()
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_ACTIVIDAD", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Datos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.TipoDocumento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSIRENTAS.CD_TIPODOC
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> TipoDocumento()
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_DOCUMENTO", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Datos));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (21/06/2018)
        //Utilizado por	: BusinessLogic.SIC_PARAMETROS.TipoDocumentoInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSIRENTAS.CD_DOC_OFTIPO
        /// </summary>
        public IEnumerable<BE.SIC_PARAMETROS> TipoDocumentoInt()
        {
            List<BE.SIC_PARAMETROS> lista = new List<BE.SIC_PARAMETROS>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_PARAMETROS.PRC_DOCUMENTO_INT", new object[1]);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_PARAMETROS(reader, BE.SIC_PARAMETROS.Query.Datos));
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
