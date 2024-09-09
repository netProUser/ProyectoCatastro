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
    public class SIC_VIA : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/04/2018)
        //Utilizado por	: BusinessLogic.SIC_VIA.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIA BuscarInt(BE.SIC_VIA entSIC_VIA)
        {
            BE.SIC_VIA lista = new BE.SIC_VIA();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODTIPOVIA", DbType.String, entSIC_VIA.CODTIPOVIA);
            db.AddInParameter(dbCommand, "pvcCODCLASVIA", DbType.String, entSIC_VIA.CODCLASVIA);
            db.AddInParameter(dbCommand, "pvcTXTVIA", DbType.String, entSIC_VIA.TXTVIA);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_VIA.PAGINAREGISTROS);
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
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_VIA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public IEnumerable<BE.SIC_VIA> Buscar(BE.SIC_VIA entSIC_VIA)
        {
            List<BE.SIC_VIA> lista = new List<BE.SIC_VIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_BUSCAR", new object[10]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODTIPOVIA", entSIC_VIA.CODTIPOVIA);
            db.SetParameterValue(dbCommand, "pvcCODCLASVIA", entSIC_VIA.CODCLASVIA);
            db.SetParameterValue(dbCommand, "pvcTXTVIA", entSIC_VIA.TXTVIA);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_VIA.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_VIA.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_VIA.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_VIA(reader, BE.SIC_VIA.Query.Listar));
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
        //Utilizado por	: BusinessLogic.SIC_VIA.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public IEnumerable<BE.SIC_VIA> Listar(BE.SIC_VIA entSIC_VIA)
        {
            List<BE.SIC_VIA> lista = new List<BE.SIC_VIA>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_LISTAR", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIA.CODDISTRITO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_VIA(reader, BE.SIC_VIA.Query.Listar));
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
        //Utilizado por	: BusinessLogic.SIC_VIA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIA Recuperar(BE.SIC_VIA entSIC_VIA)
        {
            BE.SIC_VIA lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_DATOS", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIA.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIA.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIA.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIA.CODVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_VIA(reader, BE.SIC_VIA.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_VIA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_VIA entSIC_VIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcTXTVIA", DbType.String, entSIC_VIA.TXTVIA);
            db.AddInParameter(dbCommand, "pvcCODTIPOVIA", DbType.String, entSIC_VIA.CODTIPOVIA);
            db.AddInParameter(dbCommand, "pvcCODCLASVIA", DbType.String, entSIC_VIA.CODCLASVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIA.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODVIAANTE", DbType.String, entSIC_VIA.CODVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTVIAANTE", DbType.String, entSIC_VIA.TXTVIAANTE);
            db.AddInParameter(dbCommand, "pvcCODVIAEQUIV", DbType.String, entSIC_VIA.CODVIAEQUIV);
            db.AddInParameter(dbCommand, "pvcCODGRUPOPAR", DbType.String, entSIC_VIA.CODGRUPOPAR);
            db.AddInParameter(dbCommand, "pvcCODADMVIA", DbType.String, entSIC_VIA.CODADMVIA);
            db.AddOutParameter(dbCommand, "pvcCODVIA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODVIA"));
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
        //Utilizado por	: BusinessLogic.SIC_VIA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_VIA entSIC_VIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcTXTVIA", DbType.String, entSIC_VIA.TXTVIA);
            db.AddInParameter(dbCommand, "pvcCODTIPOVIA", DbType.String, entSIC_VIA.CODTIPOVIA);
            db.AddInParameter(dbCommand, "pvcCODCLASVIA", DbType.String, entSIC_VIA.CODCLASVIA);
            db.AddInParameter(dbCommand, "pvcCODVIAANTE", DbType.String, entSIC_VIA.CODVIAANTE);
            db.AddInParameter(dbCommand, "pvcTXTVIAANTE", DbType.String, entSIC_VIA.TXTVIAANTE);
            db.AddInParameter(dbCommand, "pvcCODVIAEQUIV", DbType.String, entSIC_VIA.CODVIAEQUIV);
            db.AddInParameter(dbCommand, "pvcCODGRUPOPAR", DbType.String, entSIC_VIA.CODGRUPOPAR);
            db.AddInParameter(dbCommand, "pvcCODADMVIA", DbType.String, entSIC_VIA.CODADMVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIA.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_VIA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_VIA entSIC_VIA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIA.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIA.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIA.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIA.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIA.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIA.CODUSUARIO);
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
