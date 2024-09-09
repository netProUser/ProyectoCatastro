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
    public class SIC_UNIDADCONSTRUCCION : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/04/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDADCONSTRUCCION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADCONSTRUCCION, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADCONSTRUCCION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_INSERTAR" : ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUNI);
            db.AddInParameter(dbCommand, "pvcNUMORDEN", DbType.String, entSIC_UNIDADCONSTRUCCION.NUMORDEN);
            db.AddInParameter(dbCommand, "pvcTXTPISO", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTPISO);
            db.AddInParameter(dbCommand, "pvcTXTMES", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTMES);
            db.AddInParameter(dbCommand, "pvcTXTANO", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTANO);
            db.AddInParameter(dbCommand, "pvcCODMATEESTR", DbType.String, entSIC_UNIDADCONSTRUCCION.CODMATEESTR);
            db.AddInParameter(dbCommand, "pvcCODESTACONSE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODESTACONSE);
            db.AddInParameter(dbCommand, "pvcCODCATEMURO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEMURO);
            db.AddInParameter(dbCommand, "pvcCODCATETECH", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATETECH);
            db.AddInParameter(dbCommand, "pvcCODCATEPISO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEPISO);
            db.AddInParameter(dbCommand, "pvcCODCATEPUERVENT", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEPUERVENT);
            db.AddInParameter(dbCommand, "pvcCODCATEREVE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEREVE);
            db.AddInParameter(dbCommand, "pvcCODCATEBANO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEBANO);
            db.AddInParameter(dbCommand, "pvcCODCATEINSTELEC", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEINSTELEC);
            db.AddInParameter(dbCommand, "pvcNUMAREADECL", DbType.Decimal, entSIC_UNIDADCONSTRUCCION.NUMAREADECL);
            db.AddInParameter(dbCommand, "pvcNUMAREAVERI", DbType.Decimal, entSIC_UNIDADCONSTRUCCION.NUMAREAVERI);
            //db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTIPREG);
            db.AddOutParameter(dbCommand, "pvcCODCORRUNIDCONS", DbType.String, 10);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDCONS"));
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADCONSTRUCCION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADCONSTRUCCION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_MODIFICAR" : ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUNI);
            db.AddInParameter(dbCommand, "pvcNUMORDEN", DbType.String, entSIC_UNIDADCONSTRUCCION.NUMORDEN);
            db.AddInParameter(dbCommand, "pvcTXTPISO", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTPISO);
            db.AddInParameter(dbCommand, "pvcTXTMES", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTMES);
            db.AddInParameter(dbCommand, "pvcTXTANO", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTANO);
            db.AddInParameter(dbCommand, "pvcCODMATEESTR", DbType.String, entSIC_UNIDADCONSTRUCCION.CODMATEESTR);
            db.AddInParameter(dbCommand, "pvcCODESTACONSE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODESTACONSE);
            db.AddInParameter(dbCommand, "pvcCODCATEMURO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEMURO);
            db.AddInParameter(dbCommand, "pvcCODCATETECH", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATETECH);
            db.AddInParameter(dbCommand, "pvcCODCATEPISO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEPISO);
            db.AddInParameter(dbCommand, "pvcCODCATEPUERVENT", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEPUERVENT);
            db.AddInParameter(dbCommand, "pvcCODCATEREVE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEREVE);
            db.AddInParameter(dbCommand, "pvcCODCATEBANO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEBANO);
            db.AddInParameter(dbCommand, "pvcCODCATEINSTELEC", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCATEINSTELEC);
            db.AddInParameter(dbCommand, "pvcNUMAREADECL", DbType.Decimal, entSIC_UNIDADCONSTRUCCION.NUMAREADECL);
            db.AddInParameter(dbCommand, "pvcNUMAREAVERI", DbType.Decimal, entSIC_UNIDADCONSTRUCCION.NUMAREAVERI);
            //db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDCONS", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCORRUNIDCONS);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTIPREG);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADCONSTRUCCION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_UNIDADCONSTRUCCION Recuperar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_UNIDADCONSTRUCCION lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_DATOS_TMP", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADCONSTRUCCION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODCORRUNIDCONS", entSIC_UNIDADCONSTRUCCION.CODCORRUNIDCONS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDADCONSTRUCCION(reader, BE.SIC_UNIDADCONSTRUCCION.Query.Recuperar);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDADCONSTRUCCION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADCONSTRUCCION
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADCONSTRUCCION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_ELIMINAR" : ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_ELIMINAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODCORRUNIDCONS", DbType.String, entSIC_UNIDADCONSTRUCCION.CODCORRUNIDCONS);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDADCONSTRUCCION.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, entSIC_UNIDADCONSTRUCCION.TXTIPREG);
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

        public IEnumerable<BE.SIC_UNIDADCONSTRUCCION> Listar(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            List<BE.SIC_UNIDADCONSTRUCCION> lista = new List<BE.SIC_UNIDADCONSTRUCCION>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDADCONSTRUCCION.ESTATICO == true) ? ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_LISTAR" : ".PKG_MSISIC_PROC_UNIDADCONSTRUC.PRC_LISTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);          
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADCONSTRUCCION.CODUNI);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADCONSTRUCCION(reader, BE.SIC_UNIDADCONSTRUCCION.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public IEnumerable<BE.SIC_UNIDADCONSTRUCCION> RecuperarUnidadConstruccionHistoricas(BE.SIC_UNIDADCONSTRUCCION entSIC_UNIDADCONSTRUCCION)
        {
            List<BE.SIC_UNIDADCONSTRUCCION> lista = new List<BE.SIC_UNIDADCONSTRUCCION>();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_FNC.PRC_CONSTRUCCIONESHISTORICAS";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDADCONSTRUCCION.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDADCONSTRUCCION.NUMVERSION);
            

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADCONSTRUCCION(reader, BE.SIC_UNIDADCONSTRUCCION.Query.ListarHistorico));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
    }
}
