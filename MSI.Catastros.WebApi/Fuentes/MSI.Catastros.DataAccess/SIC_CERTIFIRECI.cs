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
    public class SIC_CERTIFIRECI : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CERTIFIRECI
        /// </summary>
        public IEnumerable<BE.SIC_CERTIFIRECI> Buscar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            List<BE.SIC_CERTIFIRECI> lista = new List<BE.SIC_CERTIFIRECI>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIRECI.PRC_BUSCAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFIRECI.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFIRECI.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFIRECI.CODTIPOCERTI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CERTIFIRECI(reader, BE.SIC_CERTIFIRECI.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFIRECI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIRECI.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIRECI.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIRECI.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIRECI.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcTXTRECIBO", DbType.String, entSIC_CERTIFIRECI.TXTRECIBO);
            db.AddInParameter(dbCommand, "pvcFECRECIBO", DbType.DateTime, entSIC_CERTIFIRECI.FECRECIBO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIRECI.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcCODCORRELCERE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRELCERE"));
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
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIRECI.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIRECI.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIRECI.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIRECI.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODCORRELCERE", DbType.String, entSIC_CERTIFIRECI.CODCORRELCERE);
            db.AddInParameter(dbCommand, "pvcTXTRECIBO", DbType.String, entSIC_CERTIFIRECI.TXTRECIBO);
            db.AddInParameter(dbCommand, "pvcFECRECIBO", DbType.String, entSIC_CERTIFIRECI.FECRECIBO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIRECI.CODUSUARIO);
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
        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIRECI.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODCERTIFICADO", DbType.String, entSIC_CERTIFIRECI.CODCERTIFICADO);
            db.AddInParameter(dbCommand, "pvcCODTIPOCERTI", DbType.String, entSIC_CERTIFIRECI.CODTIPOCERTI);
            db.AddInParameter(dbCommand, "pvcCODANOCERTI", DbType.String, entSIC_CERTIFIRECI.CODANOCERTI);
            db.AddInParameter(dbCommand, "pvcCODCORRELCERE", DbType.String, entSIC_CERTIFIRECI.CODCORRELCERE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_CERTIFIRECI.CODUSUARIO);
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
        //Creado por	: Pedro Peña (29/01/2019)
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public BE.SIC_CERTIFIRECI Recuperar(BE.SIC_CERTIFIRECI entSIC_CERTIFIRECI)
        {
            BE.SIC_CERTIFIRECI lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CERTIFIRECI.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODCERTIFICADO", entSIC_CERTIFIRECI.CODCERTIFICADO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOCERTI", entSIC_CERTIFIRECI.CODTIPOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODANOCERTI", entSIC_CERTIFIRECI.CODANOCERTI);
            db.SetParameterValue(dbCommand, "pvcCODCORRELCERE", entSIC_CERTIFIRECI.CODCORRELCERE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_CERTIFIRECI(reader, BE.SIC_CERTIFIRECI.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public DataSet ListarNomenclaturaDettalle(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIRECI.PRC_LISTAR_NOMENCLA", new object[4]);

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
        //Utilizado por	: BusinessLogic.SIC_CERTIFIRECI.ListarNomenclaturaDettalle
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFIRECI
        /// </summary>
        public DataSet ListarResolNumeracionDettalle(DataSet dtSubGen, string CodigoCertificado, string CodigoAnhoCertificado, string CodigoTipoCertificado)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("MSISIC.PKG_MSISIC_REP_CERTIFIRECI.PRC_LISTAR_RESOLNUM", new object[4]);

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
