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
    public class SIC_CONSULTAGEN : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: AA (24/09/2018)
        //Utilizado por	: ?
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos del modulo Consulta General
        /// </summary>
        public IEnumerable<BE.SIC_CONSULTAGEN> Buscar(BE.SIC_CONSULTAGEN entSIC_CONSULTAGEN)
        {
            List<BE.SIC_CONSULTAGEN> lista = new List<BE.SIC_CONSULTAGEN>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSCONSULTAGEN", new object[20]);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_CONSULTAGEN.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_CONSULTAGEN.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_CONSULTAGEN.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_CONSULTAGEN.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_CONSULTAGEN.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_CONSULTAGEN.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_CONSULTAGEN.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_CONSULTAGEN.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODCONTRIBUYENTE", entSIC_CONSULTAGEN.CODCONTRIBUYENTE);
            db.SetParameterValue(dbCommand, "pvcTXTDOCIDENTIDAD", entSIC_CONSULTAGEN.TXTDOCIDENTIDAD);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_CONSULTAGEN.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODHU", entSIC_CONSULTAGEN.CODHU);
            db.SetParameterValue(dbCommand, "pvcCODUSOPRED", entSIC_CONSULTAGEN.CODUSOPRED);
            db.SetParameterValue(dbCommand, "pvcCODCLAS", entSIC_CONSULTAGEN.CODCLAS);
            db.SetParameterValue(dbCommand, "pvcCODESTACONS", entSIC_CONSULTAGEN.CODESTACONS);
            db.SetParameterValue(dbCommand, "pvcNIVEL", entSIC_CONSULTAGEN.NIVEL);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_CONSULTAGEN.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_CONSULTAGEN.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_CONSULTAGEN.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONSULTAGEN(reader, BE.SIC_CONSULTAGEN.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_CONSULTAGEN> BuscarSimple(BE.SIC_CONSULTAGEN entSIC_CONSULTAGEN)
        {
            List<BE.SIC_CONSULTAGEN> lista = new List<BE.SIC_CONSULTAGEN>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSCONSULTAGEN_SMP", new object[17]);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_CONSULTAGEN.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_CONSULTAGEN.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_CONSULTAGEN.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_CONSULTAGEN.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_CONSULTAGEN.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_CONSULTAGEN.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_CONSULTAGEN.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_CONSULTAGEN.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODCONTRIBUYENTE", entSIC_CONSULTAGEN.CODCONTRIBUYENTE);
            db.SetParameterValue(dbCommand, "pvcTXTDOCIDENTIDAD", entSIC_CONSULTAGEN.TXTDOCIDENTIDAD);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_CONSULTAGEN.CODVIA);
            db.SetParameterValue(dbCommand, "pvcCODHU", entSIC_CONSULTAGEN.CODHU);
            db.SetParameterValue(dbCommand, "pvcCODUSOPRED", entSIC_CONSULTAGEN.CODUSOPRED);
            db.SetParameterValue(dbCommand, "pvcCODCLAS", entSIC_CONSULTAGEN.CODCLAS);
            db.SetParameterValue(dbCommand, "pvcCODESTACONS", entSIC_CONSULTAGEN.CODESTACONS);
            db.SetParameterValue(dbCommand, "pvcNIVEL", entSIC_CONSULTAGEN.NIVEL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_CONSULTAGEN(reader, BE.SIC_CONSULTAGEN.Query.ListarSimple));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_CONSULTAGEN BuscarInt(BE.SIC_CONSULTAGEN entSIC_CONSULTAGEN)
        {
            BE.SIC_CONSULTAGEN lista = new BE.SIC_CONSULTAGEN();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_REP_CONSULTAGEN.PRC_DATOSCONSULTAGEN_INT");
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_CONSULTAGEN.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_CONSULTAGEN.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_CONSULTAGEN.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_CONSULTAGEN.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_CONSULTAGEN.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_CONSULTAGEN.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_CONSULTAGEN.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_CONSULTAGEN.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODCONTRIBUYENTE", DbType.String, entSIC_CONSULTAGEN.CODCONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcTXTDOCIDENTIDAD", DbType.String, entSIC_CONSULTAGEN.TXTDOCIDENTIDAD);
            db.AddInParameter(dbCommand, "pvcCODVIA", DbType.String, entSIC_CONSULTAGEN.CODVIA);
            db.AddInParameter(dbCommand, "pvcCODHU", DbType.String, entSIC_CONSULTAGEN.CODHU);
            db.AddInParameter(dbCommand, "pvcCODUSOPRED", DbType.String, entSIC_CONSULTAGEN.CODUSOPRED);
            db.AddInParameter(dbCommand, "pvcCODCLAS", DbType.String, entSIC_CONSULTAGEN.CODCLAS);
            db.AddInParameter(dbCommand, "pvcCODESTACONS", DbType.String, entSIC_CONSULTAGEN.CODESTACONS);
            db.AddInParameter(dbCommand, "pvcNIVEL", DbType.String, entSIC_CONSULTAGEN.NIVEL);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_CONSULTAGEN.PAGINAREGISTROS);
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

        
    }
}
