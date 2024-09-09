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
    public class SIC_UNIDADDIRECCONINTERIOR : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADDIRECCONINTERIOR.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADDIRECCONINTERIOR.ESTATICO == "true") ? ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRUNIDDIREMUNI);
            db.AddInParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODTIPOINTE);
            db.AddInParameter(dbCommand, "pvcCODESTAINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODESTAINTE);
            db.AddInParameter(dbCommand, "pvcCODTIPOASIG", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODTIPOASIG);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTLETRA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTLETRA);
            db.AddInParameter(dbCommand, "pvcCODINSCATINT", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODINSCATINT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcNUMAREATEMPI", DbType.Decimal, entSIC_UNIDADDIRECCONINTERIOR.NUMAREATEMPI);
            db.AddInParameter(dbCommand, "pvcFLAGINDIREC", DbType.Int32, entSIC_UNIDADDIRECCONINTERIOR.FLAGINDIREC);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDDIREINTE", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDDIREINTE"));
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
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADDIRECCONINTERIOR.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADDIRECCONINTERIOR.ESTATICO == "true") ? ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRMANZVIA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRMANZVIA);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREMUNI", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRUNIDDIREMUNI);
            db.AddInParameter(dbCommand, "pvcCODTIPOINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODTIPOINTE);
            db.AddInParameter(dbCommand, "pvcTXTNUMERO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTNUMERO);
            db.AddInParameter(dbCommand, "pvcTXTLETRA", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTLETRA);
            db.AddInParameter(dbCommand, "pvcCODINSCATINT", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODINSCATINT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTIPREG);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRUNIDDIREINTE);
            db.AddInParameter(dbCommand, "pvcCODESTAINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODESTAINTE);
            db.AddInParameter(dbCommand, "pvcNUMAREATEMPI", DbType.Decimal, entSIC_UNIDADDIRECCONINTERIOR.NUMAREATEMPI);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADDIRECCONINTERIOR.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_UNIDADDIRECCONINTERIOR Recuperar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_UNIDADDIRECCONINTERIOR lista = null;

            Database db = DatabaseFactory.CreateDatabase();

            string NombreProcedure = (entSIC_UNIDADDIRECCONINTERIOR.ESTATICO == "true") ? ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_DATOS" : ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[5]);
            //DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_DATOS_TMP", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDDIREINTE", entSIC_UNIDADDIRECCONINTERIOR.CODCORRUNIDDIREINTE);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_UNIDADDIRECCONINTERIOR.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODCORRMANZVIA", entSIC_UNIDADDIRECCONINTERIOR.CODCORRMANZVIA);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADDIRECCONINTERIOR(reader, BE.SIC_UNIDADDIRECCONINTERIOR.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADDIRECCONINTERIOR.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADDIRECCONINTERIOR.ESTATICO == "true") ? ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDDIREINTE", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODCORRUNIDDIREINTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADDIRECCONINTERIOR.TXTIPREG);
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

        public IEnumerable<BE.SIC_UNIDADDIRECCONINTERIOR> Listar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            List<BE.SIC_UNIDADDIRECCONINTERIOR> lista = new List<BE.SIC_UNIDADDIRECCONINTERIOR>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADDIRECCONINTERIOR.ESTATICO == "true") ? ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADDIRECCON.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.SetParameterValue(dbCommand, "pvcFLAGINDIREC", entSIC_UNIDADDIRECCONINTERIOR.FLAGINDIREC);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADDIRECCONINTERIOR(reader, BE.SIC_UNIDADDIRECCONINTERIOR.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_UNIDADDIRECCONINTERIOR> CargarDireccionHistoricaUnidad(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            List<BE.SIC_UNIDADDIRECCONINTERIOR> lista = new List<BE.SIC_UNIDADDIRECCONINTERIOR>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_NUMERACIONHISTORICA";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADDIRECCONINTERIOR.CODUNI);
            db.SetParameterValue(dbCommand, "pvcFLAGINDIREC", entSIC_UNIDADDIRECCONINTERIOR.FLAGINDIREC);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADDIRECCONINTERIOR.NVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADDIRECCONINTERIOR(reader, BE.SIC_UNIDADDIRECCONINTERIOR.Query.Listar));
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
