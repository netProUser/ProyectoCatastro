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
    public class SIC_VIASANTE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIASANTE BuscarInt(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_VIASANTE lista = new BE.SIC_VIASANTE();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcTXTVIAANTE", DbType.String, entSIC_VIASANTE.TXTVIAANTE);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_VIASANTE.PAGINAREGISTROS);
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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIASANTE
        /// </summary>
        public IEnumerable<BE.SIC_VIASANTE> Buscar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            List<BE.SIC_VIASANTE> lista = new List<BE.SIC_VIASANTE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_BUSCAR", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIASANTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIASANTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIASANTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIASANTE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcTXTVIAANTE", entSIC_VIASANTE.TXTVIAANTE);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_VIASANTE.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_VIASANTE.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_VIASANTE.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_VIASANTE(reader, BE.SIC_VIASANTE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_VIASANTE Recuperar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_VIASANTE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIASANTE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIASANTE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIASANTE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIASANTE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORVIA", entSIC_VIASANTE.CODCORVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_VIASANTE(reader, BE.SIC_VIASANTE.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIASANTE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODVIAANTE", DbType.String, entSIC_VIASANTE.CODVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAANTE", DbType.String, entSIC_VIASANTE.TXTTIPOVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTVIAANTE", DbType.String, entSIC_VIASANTE.TXTVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTNORMATIVA", DbType.String, entSIC_VIASANTE.TXTNORMATIVA);
            db.AddInParameter(dbCommand, "pvcFECINICIO", DbType.Date, entSIC_VIASANTE.FECINICIO);
            db.AddInParameter(dbCommand, "pvcFECFIN", DbType.Date, entSIC_VIASANTE.FECFIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIASANTE.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODCORVIA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORVIA"));
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
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORVIA", DbType.String, entSIC_VIASANTE.CODCORVIA);
            db.AddInParameter(dbCommand, "pvcCODVIAANTE", DbType.String, entSIC_VIASANTE.CODVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTTIPOVIAANTE", DbType.String, entSIC_VIASANTE.TXTTIPOVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTVIAANTE", DbType.String, entSIC_VIASANTE.TXTVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTNORMATIVA", DbType.String, entSIC_VIASANTE.TXTNORMATIVA);
            db.AddInParameter(dbCommand, "pvcFECINICIO", DbType.Date, entSIC_VIASANTE.FECINICIO);
            db.AddInParameter(dbCommand, "pvcFECFIN", DbType.Date, entSIC_VIASANTE.FECFIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIASANTE.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (07/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORVIA", DbType.String, entSIC_VIASANTE.CODCORVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIASANTE.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (16/05/2018)
        //Utilizado por	: BusinessLogic.SIC_VIASANTE.ValidarFechas
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite validar los rangos de fechas de la tabla SIC_VIASANTE
        /// </summary>
        public BE.SIC_RETORNO ValidarFechas(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_VALIDAR_FEC");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcFECINICIO", DbType.Date, entSIC_VIASANTE.FECINICIO);
            db.AddInParameter(dbCommand, "pvcFECFIN", DbType.Date, entSIC_VIASANTE.FECFIN);
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

        public BE.SIC_RETORNO ValidarFechasActualizar(BE.SIC_VIASANTE entSIC_VIASANTE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIASANTE.PRC_VALIDAR_FECACT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIASANTE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIASANTE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIASANTE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIASANTE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORVIA", DbType.String, entSIC_VIASANTE.CODCORVIA);
            db.AddInParameter(dbCommand, "pvcFECINICIO", DbType.Date, entSIC_VIASANTE.FECINICIO);
            db.AddInParameter(dbCommand, "pvcFECFIN", DbType.Date, entSIC_VIASANTE.FECFIN);
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
