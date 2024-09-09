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
    public class SIC_ZONIFMANZAVIA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ZONIFMANZAVIA
        /// </summary>
        public IEnumerable<BE.SIC_ZONIFMANZAVIA> Buscar(BE.SIC_ZONIFMANZAVIA entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_ZONIFMANZAVIA> lista = new List<BE.SIC_ZONIFMANZAVIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_BUSCAR", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTELINDEROVIADET.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTELINDEROVIADET.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTELINDEROVIADET.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTELINDEROVIADET.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTELINDEROVIADET.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_LOTELINDEROVIADET.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_LOTELINDEROVIADET.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_ZONIFMANZAVIA(reader, BE.SIC_ZONIFMANZAVIA.Query.Buscar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_ZONIFMANZA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFMANZAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_ZONIFMANZAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_ZONIFMANZAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_ZONIFMANZAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_ZONIFMANZAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_ZONIFMANZAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFMANZAVIA.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFMANZAVIA.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFMANZAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_ZONIFMANZAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_ZONIFMANZAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_ZONIFMANZAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_ZONIFMANZAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_ZONIFMANZAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFMANZAVIA.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFMANZAVIA.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_ZONIFMANZA Recuperar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFMANZAVIA)
        {
            BE.SIC_ZONIFMANZA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_DATOS", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_ZONIFMANZAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_ZONIFMANZAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_ZONIFMANZAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_ZONIFMANZAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_ZONIFMANZAVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODZONIFICACION", entSIC_ZONIFMANZAVIA.CODZONIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODVIA",  entSIC_ZONIFMANZAVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_ZONIFMANZAVIA.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_ZONIFMANZA(reader, BE.SIC_ZONIFMANZA.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFMANZAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_ZONIFMANZAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_ZONIFMANZAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_ZONIFMANZAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_ZONIFMANZAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_ZONIFMANZAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODZONIFICACION", DbType.String, entSIC_ZONIFMANZAVIA.CODZONIFICACION);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_ZONIFMANZAVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_ZONIFMANZAVIA.CODUSUARIO);
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
        //Creado por	: Eistein Dolores Tarazona (04/07/2018)
        //Utilizado por	: BusinessLogic.SIC_ZONIFMANZA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite Listar un registro de la tabla SIC_ZONIFMANZA
        /// </summary>
        public IEnumerable<BE.SIC_ZONIFMANZAVIA> Listar(BE.SIC_ZONIFMANZAVIA entSIC_ZONIFMANZAVIA)
        {
            List<BE.SIC_ZONIFMANZAVIA> lista = new List<BE.SIC_ZONIFMANZAVIA>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_ZONIFMANZAVIA.PRC_LISTAR", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_ZONIFMANZAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_ZONIFMANZAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_ZONIFMANZAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_ZONIFMANZAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_ZONIFMANZAVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_ZONIFMANZAVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_ZONIFMANZAVIA.CODCORRMANZVIA);
            //db.SetParameterValue(dbCommand, "pvcCODZONIFICACION", entSIC_ZONIFMANZA.CODZONIFICACION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_ZONIFMANZAVIA(reader, BE.SIC_ZONIFMANZAVIA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
    }
}
