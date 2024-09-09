using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace MSI.Catastros.DataAccess
{
    public class SIC_DETAFILESERVER : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (04/10/2018)
        //Utilizado por	: BusinessLogic.SIC_DETAFILESERVER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_DETAFILESERVER
        /// </summary>
        public IEnumerable<BE.SIC_DETAFILESERVER> Recuperar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            List<BE.SIC_DETAFILESERVER> lista = new List<BE.SIC_DETAFILESERVER>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DETAFILESERVER.PRC_DATOS", new object[3]);
            db.SetParameterValue(dbCommand, "pvcTXTNOMTABLA", entSIC_DETAFILESERVER.TXTNOMTABLA);
            db.SetParameterValue(dbCommand, "pvcCODPKTABLA", entSIC_DETAFILESERVER.CODPKTABLA);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_DETAFILESERVER(reader, BE.SIC_DETAFILESERVER.Query.Recuperar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (04/10/2018)
        //Utilizado por	: BusinessLogic.SIC_DETAFILESERVER.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_DETAFILESERVER, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_DETAFILESERVER.PRC_INSERTAR");
            db.AddInParameter(dbCommand, "pvcTXTNOMTABLA", DbType.String, entSIC_DETAFILESERVER.TXTNOMTABLA);
            db.AddInParameter(dbCommand, "pvcCODPKTABLA", DbType.String, entSIC_DETAFILESERVER.CODPKTABLA);
            db.AddInParameter(dbCommand, "pvcTXTPKTABLANOM", DbType.String, entSIC_DETAFILESERVER.TXTPKTABLANOM);
            db.AddInParameter(dbCommand, "pvcTXTEXTENSION", DbType.String, entSIC_DETAFILESERVER.TXTEXTENSION);
            db.AddInParameter(dbCommand, "pvcTXTRUTA", DbType.String, entSIC_DETAFILESERVER.TXTRUTA);
            db.AddInParameter(dbCommand, "pvcFLGPRINCIPAL", DbType.String, entSIC_DETAFILESERVER.FLGPRINCIPAL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DETAFILESERVER.CODUSUARIO);
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
        //Creado por	: Pedro Peña Salazar (21/11/2018)
        //Utilizado por	: BusinessLogic.SIC_DETAFILESERVER.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_DETAFILESERVER
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_DETAFILESERVER entSIC_DETAFILESERVER)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_GEST_DETAFILESERVER.PRC_MODIFICAR";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODCORRELFS", DbType.String, entSIC_DETAFILESERVER.CODCORRELFS);
            db.AddInParameter(dbCommand, "pvcTXTNOMTABLA", DbType.String, entSIC_DETAFILESERVER.TXTNOMTABLA);
            db.AddInParameter(dbCommand, "pvcCODPKTABLA", DbType.String, entSIC_DETAFILESERVER.CODPKTABLA);
            db.AddInParameter(dbCommand, "pvcTXTPKTABLANOM", DbType.String, entSIC_DETAFILESERVER.TXTPKTABLANOM);
            db.AddInParameter(dbCommand, "pvcTXTEXTENSION", DbType.String, entSIC_DETAFILESERVER.TXTEXTENSION);
            db.AddInParameter(dbCommand, "pvcTXTRUTA", DbType.String, entSIC_DETAFILESERVER.TXTRUTA);
            db.AddInParameter(dbCommand, "pvcFLGPRINCIPAL", DbType.String, entSIC_DETAFILESERVER.FLGPRINCIPAL);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_DETAFILESERVER.CODUSUARIO);
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
