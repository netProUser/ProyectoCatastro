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
    public class SIC_CERTIFIDETA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CERTIFIDETA
        /// </summary>
        public IEnumerable<BE.SIC_CERTIFIDETA> Buscar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            List<BE.SIC_CERTIFIDETA> lista = new List<BE.SIC_CERTIFIDETA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_BUSCAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFIDETA.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFIDETA.CODTIPOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFIDETA(reader, BE.SIC_CERTIFIDETA.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_CERTIFIDETA> BuscarCertificados(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            List<BE.SIC_CERTIFIDETA> lista = new List<BE.SIC_CERTIFIDETA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_BUSCAR_CERTI_DETALLE", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_CERTIFIDETA.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFIDETA.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFIDETA.CODTIPOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFIDETA(reader, BE.SIC_CERTIFIDETA.Query.ListarCerti));
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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFIDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIDETA.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIDETA.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_CERTIFIDETA.CODVIA);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIA", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOPUERTA", DbType.String, entSIC_CERTIFIDETA.TXTTIPOPUERTA);
            db.AddInParameter(dbCommand, "pvcTXTBLOQTE", DbType.String, entSIC_CERTIFIDETA.TXTBLOQTE);
            db.AddInParameter(dbCommand, "pvcTXTNIVEL", DbType.String, entSIC_CERTIFIDETA.TXTNIVEL);
            db.AddInParameter(dbCommand, "pvcTXTINTERIOR", DbType.String, entSIC_CERTIFIDETA.TXTINTERIOR);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_CERTIFIDETA.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcCODINSCRP", DbType.String, entSIC_CERTIFIDETA.CODINSCRP);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAANT", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAANT);
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_CERTIFIDETA.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcTXTINSCRIPCION", DbType.String, entSIC_CERTIFIDETA.TXTINSCRIPCION);
            db.AddInParameter(dbCommand, "pvcFLAGESQ", DbType.String, entSIC_CERTIFIDETA.FLAGESQ);
            db.AddInParameter(dbCommand, "pvcCODVIAESQ", DbType.String, entSIC_CERTIFIDETA.CODVIAESQ);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAESQ", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAESQ);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIA", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAANT", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAANT);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAESQ", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAESQ);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_CERTIFIDETA.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREINTE", DbType.String, entSIC_CERTIFIDETA.CODCORRUNIDDIREINTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAESQANT", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAESQANT);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAESQANT", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAESQANT);

            db.AddOutParameter(dbCommand, "pvcCODCORRELCERT", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELCERT"));
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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIDETA.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIDETA.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODCORRELCERT", DbType.String, entSIC_CERTIFIDETA.CODCORRELCERT);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_CERTIFIDETA.CODVIA);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIA", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOPUERTA", DbType.String, entSIC_CERTIFIDETA.TXTTIPOPUERTA);
            db.AddInParameter(dbCommand, "pvcTXTBLOQTE", DbType.String, entSIC_CERTIFIDETA.TXTBLOQTE);
            db.AddInParameter(dbCommand, "pvcTXTNIVEL", DbType.String, entSIC_CERTIFIDETA.TXTNIVEL);
            db.AddInParameter(dbCommand, "pvcTXTINTERIOR", DbType.String, entSIC_CERTIFIDETA.TXTINTERIOR);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_CERTIFIDETA.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcCODINSCRP", DbType.String, entSIC_CERTIFIDETA.CODINSCRP);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAANT", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAANT);
            db.AddInParameter(dbCommand, "pvcCODTIPOPUER", DbType.String, entSIC_CERTIFIDETA.CODTIPOPUER);
            db.AddInParameter(dbCommand, "pvcTXTINSCRIPCION", DbType.String, entSIC_CERTIFIDETA.TXTINSCRIPCION);
            db.AddInParameter(dbCommand, "pvcFLAGESQ", DbType.String, entSIC_CERTIFIDETA.FLAGESQ);
            db.AddInParameter(dbCommand, "pvcCODVIAESQ", DbType.String, entSIC_CERTIFIDETA.CODVIAESQ);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAESQ", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAESQ);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIA", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIA);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAANT", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAANT);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAESQ", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAESQ);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_CERTIFIDETA.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREINTE", DbType.String, entSIC_CERTIFIDETA.CODCORRUNIDDIREINTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIDETA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcTXTNOMVIAESQANT", DbType.String, entSIC_CERTIFIDETA.TXTNOMVIAESQANT);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAESQANT", DbType.String, entSIC_CERTIFIDETA.TXTTIPOVIAESQANT);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIDETA.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIDETA.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODCORRELCERT", DbType.String, entSIC_CERTIFIDETA.CODCORRELCERT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIDETA.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public BE.SIC_CERTIFIDETA Recuperar(BE.SIC_CERTIFIDETA entSIC_CERTIFIDETA)
        {
            BE.SIC_CERTIFIDETA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIDETA.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFIDETA.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFIDETA.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFIDETA.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODCORRELCERT", entSIC_CERTIFIDETA.CODCORRELCERT);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CERTIFIDETA(reader, BE.SIC_CERTIFIDETA.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public DataSet ListarNomenclaturaDettalle(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIDETA.PRC_LISTAR_NOMENCLA", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public DataSet ListarResolNumeracionDettalle(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIDETA.PRC_LISTAR_RESOLNUM", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
        public DataSet ListarResolNumeracionAnexo(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIDETA.PRC_LISTAR_RESOLNUMANEXO", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
        

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public DataSet ListarCertNumeracionDetalle(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIDETA.PRC_LISTAR_CERTNUM", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIDETA.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIDETA
        /// </summary>
        public DataSet ListarResolNumeracionViaAnte(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIDETA.PRC_LISTAR_VIAANTE", new object[4]);

            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", CodigoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", CodigoAnhoCertificado);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", CodigoTipoCertificado);

            try
            {
                dtSubGen = db.ExecuteDataSet(dbCommand);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dtSubGen;
        }
    }
}
