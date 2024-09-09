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
    public class SIC_LOTEMOBILURBA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILURBA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEMOBILURBA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEMOBILURBA entSIC_LOTEMOBILURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILURBA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMOBILURBA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMOBILURBA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMOBILURBA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMOBILURBA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMOBILURBA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMOBILURBA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODOBJETO", DbType.String, entSIC_LOTEMOBILURBA.CODOBJETO);
            db.AddInParameter(dbCommand, "pvcTXTCAMPANA", DbType.String, entSIC_LOTEMOBILURBA.TXTCAMPANA);
            db.AddInParameter(dbCommand, "pvcFECCAMPANA", DbType.Date, entSIC_LOTEMOBILURBA.FECCAMPANA);

            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_LOTEMOBILURBA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRVIADETA", DbType.String, entSIC_LOTEMOBILURBA.CODCORRVIADETA);
            db.AddInParameter(dbCommand, "pvcTXTUBICESPECIF", DbType.String, entSIC_LOTEMOBILURBA.TXTUBICESPECIF);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.String, entSIC_LOTEMOBILURBA.NUMCUADRA);

            db.AddInParameter(dbCommand, "pvcNUMLATITUD", DbType.Decimal, entSIC_LOTEMOBILURBA.NUMLATITUD);
            db.AddInParameter(dbCommand, "pvcNUMLONGITUD", DbType.Decimal, entSIC_LOTEMOBILURBA.NUMLONGITUD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILURBA.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCORRELURBA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCORRELURBA"));
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILURBA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEMOBILURBA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEMOBILURBA entSIC_LOTEMOBILURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILURBA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMOBILURBA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMOBILURBA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMOBILURBA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMOBILURBA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMOBILURBA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMOBILURBA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcNUMLATITUD", DbType.Decimal, entSIC_LOTEMOBILURBA.NUMLATITUD);
            db.AddInParameter(dbCommand, "pvcNUMLONGITUD", DbType.Decimal, entSIC_LOTEMOBILURBA.NUMLONGITUD);
            db.AddInParameter(dbCommand, "pvcTXTCAMPANA", DbType.String, entSIC_LOTEMOBILURBA.TXTCAMPANA);
            db.AddInParameter(dbCommand, "pvcFECCAMPANA", DbType.Date, entSIC_LOTEMOBILURBA.FECCAMPANA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILURBA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_LOTEMOBILURBA.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMOBILURBA.CORRELURBA);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILURBA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEMOBILURBA
        /// </summary>
        public BE.SIC_LOTEMOBILURBA Recuperar(BE.SIC_LOTEMOBILURBA entSIC_LOTEMOBILURBA)
        {
            BE.SIC_LOTEMOBILURBA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILURBA.PRC_DATOS", new object[8]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEMOBILURBA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEMOBILURBA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEMOBILURBA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEMOBILURBA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEMOBILURBA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEMOBILURBA.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCORRELURBA", entSIC_LOTEMOBILURBA.CORRELURBA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_LOTEMOBILURBA(reader, BE.SIC_LOTEMOBILURBA.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTEMOBILURBA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEMOBILURBA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEMOBILURBA entSIC_LOTEMOBILURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILURBA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_LOTEMOBILURBA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_LOTEMOBILURBA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_LOTEMOBILURBA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_LOTEMOBILURBA.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_LOTEMOBILURBA.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_LOTEMOBILURBA.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCORRELURBA", DbType.String, entSIC_LOTEMOBILURBA.CORRELURBA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_LOTEMOBILURBA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_LOTEMOBILURBA.TXTIPREG);
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
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: BusinessLogic.SIC_LOTE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LOTE
        /// </summary>
        public IEnumerable<BE.SIC_LOTEMOBILURBA> Listar(BE.SIC_LOTEMOBILURBA entSIC_LOTEMOBILURBA)
        {
            List<BE.SIC_LOTEMOBILURBA> lista = new List<BE.SIC_LOTEMOBILURBA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_LOTEMOBILURBA.PRC_LISTAR", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_LOTEMOBILURBA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_LOTEMOBILURBA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_LOTEMOBILURBA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_LOTEMOBILURBA.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_LOTEMOBILURBA.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_LOTEMOBILURBA.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODOBJETO", entSIC_LOTEMOBILURBA.CODOBJETO);            
            db.SetParameterValue(dbCommand, "pvcCORRELURBA", entSIC_LOTEMOBILURBA.CORRELURBA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_LOTEMOBILURBA(reader, BE.SIC_LOTEMOBILURBA.Query.Listar));
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
