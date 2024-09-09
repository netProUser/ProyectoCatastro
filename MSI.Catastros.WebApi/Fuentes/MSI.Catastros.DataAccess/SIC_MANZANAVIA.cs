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
    public class SIC_MANZANAVIA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (28/06/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.BuscarVias
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public IEnumerable<BE.SIC_MANZANAVIA> BuscarVias(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lista = new List<BE.SIC_MANZANAVIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_BUSCAR_VIAS", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANAVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcPARQUE", entSIC_MANZANAVIA.PARQUE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MANZANAVIA(reader, BE.SIC_MANZANAVIA.Query.ListarVias));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public IEnumerable<BE.SIC_MANZANAVIA> Buscar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lista = new List<BE.SIC_MANZANAVIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_BUSCAR", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_MANZANAVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcTXTSECTOR", entSIC_MANZANAVIA.TXTSECTOR);
            db.SetParameterValue(dbCommand, "pvcTXTMANZANA", entSIC_MANZANAVIA.TXTMANZANA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MANZANAVIA(reader, BE.SIC_MANZANAVIA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (25/09/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.BuscarDetalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_MANZANAVIA
        /// </summary>
        public IEnumerable<BE.SIC_MANZANAVIA> BuscarDetalle(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            List<BE.SIC_MANZANAVIA> lista = new List<BE.SIC_MANZANAVIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_BUSCAR_DETALLE", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANAVIA.CODMANZANA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_MANZANAVIA(reader, BE.SIC_MANZANAVIA.Query.ListarDetalle));
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
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_MANZANAVIA
        /// </summary>
        public BE.SIC_MANZANAVIA Recuperar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_MANZANAVIA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_DATOS", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANAVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_MANZANAVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_MANZANAVIA.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_MANZANAVIA(reader, BE.SIC_MANZANAVIA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        public BE.SIC_MANZANAVIA RecuperarVerif(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_MANZANAVIA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_DATOS_VERIF", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_MANZANAVIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_MANZANAVIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_MANZANAVIA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_MANZANAVIA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_MANZANAVIA.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODLADO", entSIC_MANZANAVIA.CODLADO);
            db.SetParameterValue(dbCommand, "pvcNUMCUADRA", entSIC_MANZANAVIA.NUMCUADRA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_MANZANAVIA(reader, BE.SIC_MANZANAVIA.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_MANZANAVIA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZANAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_MANZANAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.String, entSIC_MANZANAVIA.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_MANZANAVIA.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODANOVAL", DbType.String, entSIC_MANZANAVIA.CODANOVAL);
            db.AddInParameter(dbCommand, "pvcNUMVALOR", DbType.Decimal, entSIC_MANZANAVIA.NUMVALOR);
            db.AddInParameter(dbCommand, "pvcNUMALTURA", DbType.Decimal, entSIC_MANZANAVIA.NUMALTURA);
            db.AddInParameter(dbCommand, "pvcNUMRETIRO", DbType.Decimal, entSIC_MANZANAVIA.NUMRETIRO);
            db.AddInParameter(dbCommand, "pvcNUMJARDIN", DbType.Decimal, entSIC_MANZANAVIA.NUMJARDIN);
            db.AddInParameter(dbCommand, "pvcTXTALTURA", DbType.String, entSIC_MANZANAVIA.TXTALTURA);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_MANZANAVIA.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANAVIA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRMANZVIA"));
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_MANZANA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZANAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_MANZANAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.String, entSIC_MANZANAVIA.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcCODLADO", DbType.String, entSIC_MANZANAVIA.CODLADO);
            db.AddInParameter(dbCommand, "pvcCODANOVAL", DbType.String, entSIC_MANZANAVIA.CODANOVAL);
            db.AddInParameter(dbCommand, "pvcNUMVALOR", DbType.Decimal, entSIC_MANZANAVIA.NUMVALOR);
            db.AddInParameter(dbCommand, "pvcNUMALTURA", DbType.Decimal, entSIC_MANZANAVIA.NUMALTURA);
            db.AddInParameter(dbCommand, "pvcNUMRETIRO", DbType.Decimal, entSIC_MANZANAVIA.NUMRETIRO);
            db.AddInParameter(dbCommand, "pvcNUMJARDIN", DbType.Decimal, entSIC_MANZANAVIA.NUMJARDIN);
            db.AddInParameter(dbCommand, "pvcTXTALTURA", DbType.String, entSIC_MANZANAVIA.TXTALTURA);
            db.AddInParameter(dbCommand, "pvcTXTOBSERVACION", DbType.String, entSIC_MANZANAVIA.TXTOBSERVACION);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANAVIA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_MANZANAVIA.CODCORRMANZVIA);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_MANZANAVIA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_MANZANAVIA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_MANZANAVIA entSIC_MANZANAVIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_MANZANAVIA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_MANZANAVIA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_MANZANAVIA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_MANZANAVIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_MANZANAVIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_MANZANAVIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_MANZANAVIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_MANZANAVIA.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_MANZANAVIA.CODUSUARIO);
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
