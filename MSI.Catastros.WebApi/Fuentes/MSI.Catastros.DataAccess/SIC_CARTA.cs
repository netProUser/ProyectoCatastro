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
    public class SIC_CARTA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CARTA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CARTA
        /// </summary>
        public IEnumerable<BE.SIC_CARTA> Buscar(BE.SIC_CARTA entSIC_CARTA)
        {
            List<BE.SIC_CARTA> lista = new List<BE.SIC_CARTA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_BUSCAR", new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", entSIC_CARTA.CODCARTA);
            db.SetParameterValue(dbCommand, "pvcCODCORRCARTA", entSIC_CARTA.CODCORRCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANO", entSIC_CARTA.CODANO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_CARTA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_CARTA.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_CARTA.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_CARTA.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_CARTA.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_CARTA.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CARTA(reader, BE.SIC_CARTA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_CARTA> BuscarCartas(BE.SIC_CARTA entSIC_CARTA)
        {
            List<BE.SIC_CARTA> lista = new List<BE.SIC_CARTA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_BUSCAR_CARTA", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", entSIC_CARTA.CODCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANO", entSIC_CARTA.CODANO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_CARTA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_CARTA.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_CARTA.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_CARTA.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCTIPODOCUMENTO", entSIC_CARTA.CTIPODOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcCODNROINSPEC", entSIC_CARTA.CODNROINSPEC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CARTA(reader, BE.SIC_CARTA.Query.ListarCarta));
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
        //Utilizado por	: BusinessLogic.SIC_CARTA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CARTA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CARTA entSIC_CARTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_CARTA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCARTA", DbType.String, entSIC_CARTA.CODCARTA);
            db.AddInParameter(dbCommand, "pvcCODANO", DbType.String, entSIC_CARTA.CODANO);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CARTA.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CARTA.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CARTA.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CARTA.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_CARTA.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODOOFICINA", DbType.String, entSIC_CARTA.CODOOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTANIO", DbType.String, entSIC_CARTA.TXTANIO);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO1", DbType.String, entSIC_CARTA.TXTSUBTITULO1);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO2", DbType.String, entSIC_CARTA.TXTSUBTITULO2);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO3", DbType.String, entSIC_CARTA.TXTSUBTITULO3);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO4", DbType.String, entSIC_CARTA.TXTSUBTITULO4);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO5", DbType.String, entSIC_CARTA.TXTSUBTITULO5);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO6", DbType.String, entSIC_CARTA.TXTSUBTITULO6);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO7", DbType.String, entSIC_CARTA.TXTSUBTITULO7);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO1", DbType.String, entSIC_CARTA.TXTPARRAFO1);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO2", DbType.String, entSIC_CARTA.TXTPARRAFO2);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO3", DbType.String, entSIC_CARTA.TXTPARRAFO3);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO4", DbType.String, entSIC_CARTA.TXTPARRAFO4);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO5", DbType.String, entSIC_CARTA.TXTPARRAFO5);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO6", DbType.String, entSIC_CARTA.TXTPARRAFO6);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO7", DbType.String, entSIC_CARTA.TXTPARRAFO7);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO8", DbType.String, entSIC_CARTA.TXTPARRAFO8);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO9", DbType.String, entSIC_CARTA.TXTPARRAFO9);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO10", DbType.String, entSIC_CARTA.TXTPARRAFO10);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA1", DbType.String, entSIC_CARTA.TXTFIRMA1);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA2", DbType.String, entSIC_CARTA.TXTFIRMA2);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA3", DbType.String, entSIC_CARTA.TXTFIRMA3);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA4", DbType.String, entSIC_CARTA.TXTFIRMA4);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA5", DbType.String, entSIC_CARTA.TXTFIRMA5);
            db.AddInParameter(dbCommand, "pvcTXTPIEPAGINA", DbType.String, entSIC_CARTA.TXTPIEPAGINA);
            db.AddInParameter(dbCommand, "pvcCODTRAMITE", DbType.String, entSIC_CARTA.CODTRAMITE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CARTA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRCARTA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRCARTA"));
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
        //Utilizado por	: BusinessLogic.SIC_CARTA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CARTA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CARTA entSIC_CARTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCARTA", DbType.String, entSIC_CARTA.CODCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_CARTA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRCARTA", DbType.String, entSIC_CARTA.CODCORRCARTA);
            db.AddInParameter(dbCommand, "pvcCODANO", DbType.String, entSIC_CARTA.CODANO);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_CARTA.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_CARTA.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_CARTA.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_CARTA.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNROINSPEC", DbType.String, entSIC_CARTA.CODNROINSPEC);
            db.AddInParameter(dbCommand, "pvcCODOOFICINA", DbType.String, entSIC_CARTA.CODOOFICINA);
            db.AddInParameter(dbCommand, "pvcTXTANIO", DbType.String, entSIC_CARTA.TXTANIO);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO1", DbType.String, entSIC_CARTA.TXTSUBTITULO1);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO2", DbType.String, entSIC_CARTA.TXTSUBTITULO2);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO3", DbType.String, entSIC_CARTA.TXTSUBTITULO3);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO4", DbType.String, entSIC_CARTA.TXTSUBTITULO4);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO5", DbType.String, entSIC_CARTA.TXTSUBTITULO5);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO6", DbType.String, entSIC_CARTA.TXTSUBTITULO6);
            db.AddInParameter(dbCommand, "pvcTXTSUBTITULO7", DbType.String, entSIC_CARTA.TXTSUBTITULO7);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO1", DbType.String, entSIC_CARTA.TXTPARRAFO1);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO2", DbType.String, entSIC_CARTA.TXTPARRAFO2);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO3", DbType.String, entSIC_CARTA.TXTPARRAFO3);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO4", DbType.String, entSIC_CARTA.TXTPARRAFO4);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO5", DbType.String, entSIC_CARTA.TXTPARRAFO5);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO6", DbType.String, entSIC_CARTA.TXTPARRAFO6);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO7", DbType.String, entSIC_CARTA.TXTPARRAFO7);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO8", DbType.String, entSIC_CARTA.TXTPARRAFO8);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO9", DbType.String, entSIC_CARTA.TXTPARRAFO9);
            db.AddInParameter(dbCommand, "pvcTXTPARRAFO10", DbType.String, entSIC_CARTA.TXTPARRAFO10);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA1", DbType.String, entSIC_CARTA.TXTFIRMA1);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA2", DbType.String, entSIC_CARTA.TXTFIRMA2);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA3", DbType.String, entSIC_CARTA.TXTFIRMA3);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA4", DbType.String, entSIC_CARTA.TXTFIRMA4);
            db.AddInParameter(dbCommand, "pvcTXTFIRMA5", DbType.String, entSIC_CARTA.TXTFIRMA5);
            db.AddInParameter(dbCommand, "pvcTXTPIEPAGINA", DbType.String, entSIC_CARTA.TXTPIEPAGINA);
            db.AddInParameter(dbCommand, "pvcCODPEREMISION", DbType.String, entSIC_CARTA.CODPEREMISION);
            db.AddInParameter(dbCommand, "pvcCODDOCUMGEN", DbType.String, entSIC_CARTA.CODDOCUMGEN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CARTA.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_CARTA entSIC_CARTA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCARTA", DbType.String, entSIC_CARTA.CODCARTA);
            db.AddInParameter(dbCommand, "pvcCODTIPOINFOR", DbType.String, entSIC_CARTA.CODTIPOINFOR);
            db.AddInParameter(dbCommand, "pvcCODCORRCARTA", DbType.String, entSIC_CARTA.CODCORRCARTA);
            db.AddInParameter(dbCommand, "pvcCODANO", DbType.String, entSIC_CARTA.CODANO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CARTA.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CARTA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CARTA
        /// </summary>
        public BE.SIC_CARTA Recuperar(BE.SIC_CARTA entSIC_CARTA)
        {
            BE.SIC_CARTA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", entSIC_CARTA.CODCARTA);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", entSIC_CARTA.CODTIPOINFOR);
            db.SetParameterValue(dbCommand, "pvcCODCORRCARTA", entSIC_CARTA.CODCORRCARTA);
            db.SetParameterValue(dbCommand, "pvcCODANO", entSIC_CARTA.CODANO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CARTA(reader, BE.SIC_CARTA.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CARTA.DatosInforme
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un dataset de la tabla SIC_CARTA
        /// </summary>
        public DataSet DatosCarta(DataSet dtDatosCarta, string codigoCarta, string codigoTipoInforme, string codigoAnio, string CodigoCorrCarta )
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CARTA.PRC_DATOS_REPORTE", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODCARTA", codigoCarta);
            db.SetParameterValue(dbCommand, "pvcCODTIPOINFOR", codigoTipoInforme);
            db.SetParameterValue(dbCommand, "pvcCODCORRCARTA", CodigoCorrCarta);
            db.SetParameterValue(dbCommand, "pvcCODANO", codigoAnio);
            try
            {
                dtDatosCarta = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtDatosCarta;
        }
        
    }
}
