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
    public class SIC_VIADETALLE : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (26/04/2018)
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIA
        /// </summary>
        public BE.SIC_VIADETALLE BuscarInt(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lista = new BE.SIC_VIADETALLE();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIADETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIADETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIADETALLE.CODVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_VIADETALLE.NUMCUADRA);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_VIADETALLE.PAGINAREGISTROS);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIADETALLE
        /// </summary>
        public IEnumerable<BE.SIC_VIADETALLE> Buscar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            List<BE.SIC_VIADETALLE> lista = new List<BE.SIC_VIADETALLE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_BUSCAR", new object[9]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIADETALLE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIADETALLE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIADETALLE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcNUMCUADRA", entSIC_VIADETALLE.NUMCUADRA);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_VIADETALLE.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_VIADETALLE.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_VIADETALLE.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_VIADETALLE(reader, BE.SIC_VIADETALLE.Query.Buscar));
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
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_VIADETALLE
        /// </summary>
        public IEnumerable<BE.SIC_VIADETALLE> Listar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            List<BE.SIC_VIADETALLE> lista = new List<BE.SIC_VIADETALLE>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_LISTAR", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIADETALLE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIADETALLE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIADETALLE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_VIADETALLE.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_VIADETALLE(reader, BE.SIC_VIADETALLE.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (09/07/2018)
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Retiro
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_VIADETALLE Retiro(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_RETIRO", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIADETALLE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIADETALLE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIADETALLE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcNUMCUADRA", entSIC_VIADETALLE.NUMCUADRA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_VIADETALLE(reader, BE.SIC_VIADETALLE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_VIADETALLE Recuperar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_VIADETALLE lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_DATOS", new object[6]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_VIADETALLE.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_VIADETALLE.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_VIADETALLE.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRVIADETA", entSIC_VIADETALLE.CODCORRVIADETA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_VIADETALLE(reader, BE.SIC_VIADETALLE.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIADETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIADETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIADETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIADETALLE.CODVIA);
            db.AddInParameter(dbCommand, "pvcNUMANCHVIA", DbType.Decimal, entSIC_VIADETALLE.NUMANCHVIA);
            db.AddInParameter(dbCommand, "pvcCODANCHVIA", DbType.String, entSIC_VIADETALLE.CODANCHVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_VIADETALLE.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcNUMMEDINI", DbType.Decimal, entSIC_VIADETALLE.NUMMEDINI);
            db.AddInParameter(dbCommand, "pvcNUMMEDFIN", DbType.Decimal, entSIC_VIADETALLE.NUMMEDFIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIADETALLE.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODCORRVIADETA", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRVIADETA"));
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
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIADETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIADETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIADETALLE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRVIADETA", DbType.String, entSIC_VIADETALLE.CODCORRVIADETA);
            db.AddInParameter(dbCommand, "pvcNUMANCHVIA", DbType.Decimal, entSIC_VIADETALLE.NUMANCHVIA);
            db.AddInParameter(dbCommand, "pvcCODANCHVIA", DbType.String, entSIC_VIADETALLE.CODANCHVIA);
            db.AddInParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, entSIC_VIADETALLE.NUMCUADRA);
            db.AddInParameter(dbCommand, "pvcNUMMEDINI", DbType.Decimal, entSIC_VIADETALLE.NUMMEDINI);
            db.AddInParameter(dbCommand, "pvcNUMMEDFIN", DbType.Decimal, entSIC_VIADETALLE.NUMMEDFIN);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIADETALLE.CODUSUARIO);
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
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_VIADETALLE
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIADETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIADETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIADETALLE.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRVIADETA", DbType.String, entSIC_VIADETALLE.CODCORRVIADETA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_VIADETALLE.CODUSUARIO);
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
        //Creado por	: Jaime Díaz Espinoza (08/06/2018)
        //Utilizado por	: BusinessLogic.SIC_VIADETALLE.NumeroCuadra
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_VIADETALLE, retorna numero de ERROR o ID generado
        /// </summary>
        public int NumeroCuadra(BE.SIC_VIADETALLE entSIC_VIADETALLE)
        {
            int intResultado = 0;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_VIADETALLE.PRC_NUMCUADRA");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_VIADETALLE.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_VIADETALLE.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_VIADETALLE.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_VIADETALLE.CODVIA);
            db.AddOutParameter(dbCommand, "pvcNUMCUADRA", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                intResultado = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNUMCUADRA"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return intResultado;
        }
    }
}
