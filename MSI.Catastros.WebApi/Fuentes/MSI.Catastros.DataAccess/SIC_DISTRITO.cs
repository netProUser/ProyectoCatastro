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
    public class SIC_DISTRITO : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_DISTRITO
        /// </summary>
        public IEnumerable<BE.SIC_DISTRITO> Buscar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            List<BE.SIC_DISTRITO> lista = new List<BE.SIC_DISTRITO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_BUSCAR", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_DISTRITO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_DISTRITO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcTXTDISTRITO", entSIC_DISTRITO.TXTDISTRITO);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_DISTRITO.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_DISTRITO.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_DISTRITO.PAGINAREGISTROS);
            //try
            //{
            using (IDataReader reader = db.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                    lista.Add(new BE.SIC_DISTRITO(reader, BE.SIC_DISTRITO.Query.Listar));
            }
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message); ;
            //}
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_DISTRITO
        /// </summary>
        public BE.SIC_DISTRITO BuscarInt(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            BE.SIC_DISTRITO lista = new BE.SIC_DISTRITO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_BUSCAR_INT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DISTRITO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DISTRITO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcTXTDISTRITO", DbType.String, entSIC_DISTRITO.TXTDISTRITO);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_DISTRITO.PAGINAREGISTROS);
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
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (17/04/2018)
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_DISTRITO
        /// </summary>
        public IEnumerable<BE.SIC_DISTRITO> Listar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            List<BE.SIC_DISTRITO> lista = new List<BE.SIC_DISTRITO>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_LISTAR", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_DISTRITO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_DISTRITO.CODPROVINCIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_DISTRITO(reader, BE.SIC_DISTRITO.Query.Listar));
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
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_DISTRITO
        /// </summary>
        public BE.SIC_DISTRITO Recuperar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            BE.SIC_DISTRITO lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_DATOS", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_DISTRITO.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_DISTRITO.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_DISTRITO.CODDISTRITO);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_DISTRITO(reader, BE.SIC_DISTRITO.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DISTRITO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DISTRITO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DISTRITO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcTXTDISTRITO", DbType.String, entSIC_DISTRITO.TXTDISTRITO);
            db.AddInParameter(dbCommand, "pvcTXTABREVIATURA", DbType.String, entSIC_DISTRITO.TXTABREVIATURA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DISTRITO.CODUSUARIO);
            db.AddOutParameter(dbCommand, "pvcCODDISTRITO", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODDISTRITO"));
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
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_DISTRITO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_MODIFICAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DISTRITO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DISTRITO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcTXTDISTRITO", DbType.String, entSIC_DISTRITO.TXTDISTRITO);
            db.AddInParameter(dbCommand, "pvcTXTABREVIATURA", DbType.String, entSIC_DISTRITO.TXTABREVIATURA);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DISTRITO.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_DISTRITO.CODDISTRITO);
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
        //Utilizado por	: BusinessLogic.SIC_DISTRITO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_DISTRITO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_DISTRITO entSIC_DISTRITO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_MANT_DISTRITO.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_DISTRITO.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_DISTRITO.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_DISTRITO.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DISTRITO.CODUSUARIO);
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
