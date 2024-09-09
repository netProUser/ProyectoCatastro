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
    public class SIC_CARTACONFI : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTACONFI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CARTACONFI
        /// </summary>
        public IEnumerable<BE.SIC_CARTACONFI> Buscar(BE.SIC_CARTACONFI entSIC_CARTACONFI)
        {
            List<BE.SIC_CARTACONFI> lista = new List<BE.SIC_CARTACONFI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTACONFI.PRC_BUSCAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", entSIC_CARTACONFI.CODCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_CARTACONFI.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CARTACONFI(reader, BE.SIC_CARTACONFI.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTACONFI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CARTACONFI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CARTACONFI entSIC_CARTACONFI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTACONFI.PRC_INSERTAR");
            //db.AddInParameter(dbCommand, "pvcCODCORRCARTACONF", DbType.String, entSIC_CARTACONFI.CODCORRCARTACONF);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_CARTACONFI.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcTXTTITULOGENERAL", DbType.String, entSIC_CARTACONFI.TXTTITULOGENERAL);
            db.AddInParameter(dbCommand, "pvcTXTSIGLAS", DbType.String, entSIC_CARTACONFI.TXTSIGLAS);
            db.AddInParameter(dbCommand, "pvcCODOOFICINA", DbType.String, entSIC_CARTACONFI.CODOOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTANIO", DbType.String, entSIC_CARTACONFI.TXTANIO);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO1", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO1);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO2", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO2);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO3", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO3);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO4", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO4);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO5", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO5);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO6", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO6);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO7", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO7);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO1", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO1);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO2", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO2);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO3", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO3);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO4", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO4);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO5", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO5);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO6", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO6);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO7", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO7);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO8", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO8);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO9", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO9);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO10", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO10);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA1", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA1);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA2", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA2);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA3", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA3);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA4", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA4);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA5", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA5);

            db.AddInParameter(dbCommand, "pvcTXTCONFPIEPAGINA", DbType.String, entSIC_CARTACONFI.TXTCONFPIEPAGINA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CARTACONFI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCARTA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCARTA"));
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTACONFI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CARTACONFI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CARTACONFI entSIC_CARTACONFI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTACONFI.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCARTA", DbType.String, entSIC_CARTACONFI.CODCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_CARTACONFI.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcTXTTITULOGENERAL", DbType.String, entSIC_CARTACONFI.TXTTITULOGENERAL);
            db.AddInParameter(dbCommand, "pvcTXTSIGLAS", DbType.String, entSIC_CARTACONFI.TXTSIGLAS);
            db.AddInParameter(dbCommand, "pvcCODOOFICINA", DbType.String, entSIC_CARTACONFI.CODOOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTANIO", DbType.String, entSIC_CARTACONFI.TXTANIO);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO1", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO1);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO2", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO2);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO3", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO3);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO4", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO4);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO5", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO5);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO6", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO6);
            db.AddInParameter(dbCommand, "pvcTXTCONFSUBTITULO7", DbType.String, entSIC_CARTACONFI.TXTCONFSUBTITULO7);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO1", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO1);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO2", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO2);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO3", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO3);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO4", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO4);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO5", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO5);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO6", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO6);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO7", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO7);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO8", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO8);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO9", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO9);
            db.AddInParameter(dbCommand, "pvcTXTCONFPARRAFO10", DbType.String, entSIC_CARTACONFI.TXTCONFPARRAFO10);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA1", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA1);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA2", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA2);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA3", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA3);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA4", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA4);
            db.AddInParameter(dbCommand, "pvcTXTCONFFIRMA5", DbType.String, entSIC_CARTACONFI.TXTCONFFIRMA5);
            db.AddInParameter(dbCommand, "pvcTXTCONFPIEPAGINA", DbType.String, entSIC_CARTACONFI.TXTCONFPIEPAGINA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CARTACONFI.CODUSUARIO);
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTACONFI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CARTACONFI
        /// </summary>
        public BE.SIC_CARTACONFI Recuperar(BE.SIC_CARTACONFI entSIC_CARTACONFI)
        {
            BE.SIC_CARTACONFI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTACONFI.PRC_DATOS", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", entSIC_CARTACONFI.CODCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_CARTACONFI.CODTIPOINFOR);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CARTACONFI(reader, BE.SIC_CARTACONFI.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTACONFI.DatosInforme
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un dataset de la tabla SIC_CARTACONFI
        /// </summary>
        public DataSet DatosCartaConf(DataSet dtDatosCartaConf, string codigoCarta, string codigoTipoInforme)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTACONFI.PRC_DATOS", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", codigoCarta);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", codigoTipoInforme);
            try
            {
                dtDatosCartaConf = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtDatosCartaConf;
        }
        
    }
}
