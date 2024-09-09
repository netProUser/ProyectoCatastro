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
    public class SIC_UNIDAD : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_UNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> Buscar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR", new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDAD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDAD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDAD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_UNIDAD> BuscarBC(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCARBC" : ".PKG_MSISIC_GEST_UNIDAD.PRC_TMP_BUSCARBC";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[12]);
            //DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCARBC", new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarBC));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_UNIDAD> BuscarEstadoLote(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_ESTADO_LOTE", new object[7]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarEstado));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_UNIDAD> BuscarEstadoSimple(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_ESTADO_SIMPLE", new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDAD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDAD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDAD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarEstado));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public IEnumerable<BE.SIC_UNIDAD> BuscarEstado(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_ESTADOS", new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDAD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDAD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDAD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.ListarEstado));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }
        public BE.SIC_UNIDAD BuscarEstadosInt(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = new BE.SIC_UNIDAD();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_ESTADOS_INT");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pinNUMREG", DbType.Int32, entSIC_UNIDAD.PAGINAREGISTROS);
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
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_UNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> BuscarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_TMP", new object[14]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDAD.ORDEN);
            db.SetParameterValue(dbCommand, "pinNUMPAG", entSIC_UNIDAD.PAGINANUMERO);
            db.SetParameterValue(dbCommand, "pinNUMREG", entSIC_UNIDAD.PAGINAREGISTROS);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (28/05/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_UNIDAD
        /// </summary>
        public IEnumerable<BE.SIC_UNIDAD> BuscarPorUbicacion(BE.SIC_LOTEDIRECMUNI entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDAD> lista = new List<BE.SIC_UNIDAD>();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_BUSCAR_XUBICACION", new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODVIA", entSIC_UNIDAD.CODVIA);
            db.SetParameterValue(dbCommand, "pvcNUMCUADRA", entSIC_UNIDAD.NUMCUADRA);
            db.SetParameterValue(dbCommand, "pvcTXTNUMERO", entSIC_UNIDAD.TXTNUMERO);
            db.SetParameterValue(dbCommand, "pvcORDEN", entSIC_UNIDAD.ORDEN);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Listar));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }


        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_INSERTAR" : ".PKG_MSISIC_GEST_UNIDAD.PRC_INSERTAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDAD.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODCLASIFICA", DbType.String, entSIC_UNIDAD.CODCLASIFICA);
            db.AddInParameter(dbCommand, "pvcCODTIPODPTO", DbType.String, entSIC_UNIDAD.CODTIPODPTO);
            db.AddInParameter(dbCommand, "pvcCODCARREG", DbType.String, entSIC_UNIDAD.CODCARREG);
            db.AddInParameter(dbCommand, "pvcTXTCUC", DbType.String, entSIC_UNIDAD.TXTCUC);
            db.AddInParameter(dbCommand, "pvcTXTCODIPREDRENT", DbType.String, entSIC_UNIDAD.TXTCODIPREDRENT);
            db.AddInParameter(dbCommand, "pvcCODINSCCATA", DbType.String, entSIC_UNIDAD.CODINSCCATA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRVERI", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRVERI);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRTOTA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRCOMU", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRCOMU);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSDECLTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSDECLTOTA);
            db.AddInParameter(dbCommand, "pvcNUMAREAOCUP", DbType.Decimal, entSIC_UNIDAD.NUMAREAOCUP);
            db.AddInParameter(dbCommand, "pvcNUMPORCBIENCOMUOFIC", DbType.Decimal, entSIC_UNIDAD.NUMPORCBIENCOMUOFIC);

            db.AddInParameter(dbCommand, "pvcNUMAREATERRDECLA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRDECLA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRSUBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRSUBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRSOBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRSOBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSSUBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSSUBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSSOBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSSOBVAL);

            db.AddInParameter(dbCommand, "pvcCODESTACONST", DbType.String, entSIC_UNIDAD.CODESTACONST);
            db.AddInParameter(dbCommand, "pvcTXTDENOMINACION", DbType.String, entSIC_UNIDAD.TXTDENOMINACION);
            db.AddInParameter(dbCommand, "pvcCODFUENINSCCATA", DbType.String, entSIC_UNIDAD.CODFUENINSCCATA);
            db.AddInParameter(dbCommand, "pvcTXTTRAMITEDOCU", DbType.String, entSIC_UNIDAD.TXTTRAMITEDOCU);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITUD", DbType.String, entSIC_UNIDAD.TXTSOLICITUD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
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
        //Creado por	: Juan Diego Quispe Ipanaque (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO ValidarNuevoUC(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_INSERTAR_TMP_SOL");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO GrabarTempSolUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_INSERTAR_TMP_SOL");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarTempSolUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_VALIDAR_TMP_SOL");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }


        public BE.SIC_RETORNO GrabarTempSolUnidadAcum(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_INSERTAR_TMP_ACUM");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
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
        //Creado por	: Juan Diego Quispe Iapanque (05/10/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.PasarEstaticoTemporal
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite migrar los datos del esquema estatico al temporal
        /// </summary>
        public BE.SIC_RETORNO MigrarEstaticoTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_ESTATEMP.PRC_INSERTAR_ESTA_TEMP_UNIDAD");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
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
        //Creado por	: Juan Diego Quispe Iapanque (05/10/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.PasarEstaticoTemporal
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite migrar los datos del esquema estatico al temporal
        /// </summary>
        public BE.SIC_RETORNO MigrarTemporalEstatico(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_ESTATEMP.PRC_INSERTAR_TEMP_ESTA_UNIDAD");//A
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcFECACT", DbType.DateTime, entSIC_UNIDAD.FECACT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcTXTIPREG", DbType.String, IPLocal);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }


        public BE.SIC_RETORNO EliminarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_ESTATEMP.PRC_ELIMINAR_TEMP_UNIDAD");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
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
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_MODIFICAR" : ".PKG_MSISIC_GEST_UNIDAD.PRC_MODIFICAR_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODEDIFICACION", DbType.String, entSIC_UNIDAD.CODEDIFICACION);
            db.AddInParameter(dbCommand, "pvcCODENTRADA", DbType.String, entSIC_UNIDAD.CODENTRADA);
            db.AddInParameter(dbCommand, "pvcCODPISO", DbType.String, entSIC_UNIDAD.CODPISO);
            db.AddInParameter(dbCommand, "pvcCODUNIDAD", DbType.String, entSIC_UNIDAD.CODUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSOESPE", DbType.String, entSIC_UNIDAD.CODUSOESPE);
            db.AddInParameter(dbCommand, "pvcCODCLASIFICA", DbType.String, entSIC_UNIDAD.CODCLASIFICA);

            db.AddInParameter(dbCommand, "pvcCODTIPODPTO", DbType.String, entSIC_UNIDAD.CODTIPODPTO);

            db.AddInParameter(dbCommand, "pvcCODCARREG", DbType.String, entSIC_UNIDAD.CODCARREG);
            //db.AddInParameter(dbCommand, "pvcTXTCUC", DbType.String, entSIC_UNIDAD.TXTCUC);
            db.AddInParameter(dbCommand, "pvcTXTCODIPREDRENT", DbType.String, entSIC_UNIDAD.TXTCODIPREDRENT);
            db.AddInParameter(dbCommand, "pvcCODINSCCATA", DbType.String, entSIC_UNIDAD.CODINSCCATA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRVERI", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRVERI);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRTOTA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRCOMU", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRCOMU);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSDECLTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSDECLTOTA);
            db.AddInParameter(dbCommand, "pvcNUMAREAOCUP", DbType.Decimal, entSIC_UNIDAD.NUMAREAOCUP);
            db.AddInParameter(dbCommand, "pvcNUMPORCBIENCOMUOFIC", DbType.Decimal, entSIC_UNIDAD.NUMPORCBIENCOMUOFIC);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRDECLA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRDECLA);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRSUBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRSUBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRSOBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRSOBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSSUBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSSUBVAL);
            db.AddInParameter(dbCommand, "pvcNUMAREACONSSOBVAL", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSSOBVAL);
            db.AddInParameter(dbCommand, "pvcCODESTACONST", DbType.String, entSIC_UNIDAD.CODESTACONST);
            db.AddInParameter(dbCommand, "pvcTXTDENOMINACION", DbType.String, entSIC_UNIDAD.TXTDENOMINACION);
            db.AddInParameter(dbCommand, "pvcCODFUENINSCCATA", DbType.String, entSIC_UNIDAD.CODFUENINSCCATA);
            db.AddInParameter(dbCommand, "pvcTXTTRAMITEDOCU", DbType.String, entSIC_UNIDAD.TXTTRAMITEDOCU);
            db.AddInParameter(dbCommand, "pvcTXTSOLICITUD", DbType.String, entSIC_UNIDAD.TXTSOLICITUD);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCU", DbType.String, entSIC_UNIDAD.TXTNOMDOCU);
            db.AddInParameter(dbCommand, "pvcTXTNOMDOCUINT", DbType.String, entSIC_UNIDAD.TXTNOMDOCUINT);
            db.AddInParameter(dbCommand, "pvcNUMPORESTACONT", DbType.String, entSIC_UNIDAD.NUMPORESTACONT);
            db.AddInParameter(dbCommand, "pvcCODTIPOLLENA", DbType.String, entSIC_UNIDAD.CODTIPOLLENA);
            db.AddInParameter(dbCommand, "pvcFECFINSOLICITUD", DbType.DateTime, entSIC_UNIDAD.FECFINSOLICITUD);
            db.AddInParameter(dbCommand, "pvcFLGINDEP", DbType.String, entSIC_UNIDAD.FLGINDEP);
            db.AddInParameter(dbCommand, "pvcFECINSPEC", DbType.DateTime, entSIC_UNIDAD.FECINSPEC);
            db.AddInParameter(dbCommand, "pvcFECACT", DbType.DateTime, entSIC_UNIDAD.FECACT);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
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
        public BE.SIC_RETORNO ActualizarAreas(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_GEST_UNIDAD.PRC_MODIFICAR_AREA";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODBIENCOMUN", DbType.Int32, entSIC_UNIDAD.CODBIENCOMUN);
            db.AddInParameter(dbCommand, "pvcNUMAREAOCUP", DbType.Decimal, entSIC_UNIDAD.NUMAREAOCUP);
            db.AddInParameter(dbCommand, "pvcNUMPORCBIENCOMUOFIC", DbType.Decimal, entSIC_UNIDAD.NUMPORCBIENCOMUOFIC);
            db.AddInParameter(dbCommand, "pvcFLGINDEP", DbType.String, entSIC_UNIDAD.FLGINDEP);            
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
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
        public BE.SIC_RETORNO ActualizarUnical(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_MODIFICAR_UNICALTBIEN");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);                               
            db.AddInParameter(dbCommand, "pvcNUMAREATERRTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRTOTA);          
            db.AddInParameter(dbCommand, "pvcNUMAREACONSDECLTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREACONSDECLTOTA);
            db.AddInParameter(dbCommand, "pvcNUMAREAOCUP", DbType.Decimal, entSIC_UNIDAD.NUMAREAOCUP);
            db.AddInParameter(dbCommand, "pvcNUMPORCBIENCOMUOFIC", DbType.Decimal, entSIC_UNIDAD.NUMPORCBIENCOMUOFIC);  
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
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
        public BE.SIC_RETORNO Recapitular(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ACTUALIZARRECAP");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcNUMAREATERRTOTA", DbType.Decimal, entSIC_UNIDAD.NUMAREATERRTOTA);
            db.AddInParameter(dbCommand, "pvcTIPODERECAP", DbType.String, "");
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.NoMENSAJE = 0;
                entSIC_RETORNO.Ok = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_UNIDAD Recuperar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOS" : ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOS_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_UNIDAD RecuperarxCC(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCC" : ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSCC";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[11]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_UNIDAD RecuperarSolicitud(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOS_SOL", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Solicitud);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_UNIDAD RecuperarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOS_TMP", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.Recuperar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_UNIDAD RecuperarTemporalAreaTerrenoComun(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSAREACOMUN_TMP", new object[5]);
            db.SetParameterValue(dbCommand, "pvcTOTALPAGINAS", entSIC_UNIDAD.TOTALPAGINAS);
            db.SetParameterValue(dbCommand, "pvcNUMPORCBIENCOMUOFIC", entSIC_UNIDAD.NUMPORCBIENCOMUOFIC);
            db.SetParameterValue(dbCommand, "pvcNUMAREATERRCOMU", entSIC_UNIDAD.NUMAREATERRCOMU);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.RecuperarAC);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        
        public BE.SIC_UNIDAD RecuperarPorcentajeCalculado(BE.SIC_UNIDBIENCOMUN entSIC_UNIDBIENCOMUN)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_DATOSPORCENTAJE", new object[4]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDBIENCOMUN.CODUNI);
            db.SetParameterValue(dbCommand, "pvcCODBIENCOMUN", entSIC_UNIDBIENCOMUN.CODBIENCOMUN);
            db.SetParameterValue(dbCommand, "pvcNUMAREAOC", entSIC_UNIDBIENCOMUN.NUMAREAOCUP);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.RecuperarBCPorc);
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
        //Utilizado por	: BusinessLogic.SIC_UNIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ELIMINAR");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
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
        public BE.SIC_RETORNO HabilitarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_HABILITAR_UNIDAD");
            db.AddInParameter(dbCommand, "pvcCODDEPARTAMENTO", DbType.String, entSIC_UNIDAD.CODDEPARTAMENTO);
            db.AddInParameter(dbCommand, "pvcCODPROVINCIA", DbType.String, entSIC_UNIDAD.CODPROVINCIA);
            db.AddInParameter(dbCommand, "pvcCODDISTRITO", DbType.String, entSIC_UNIDAD.CODDISTRITO);
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcESTADOUNIDAD", DbType.String, entSIC_UNIDAD.ESTADOUNIDAD);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
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

        public BE.SIC_RETORNO ActualizarLoteUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ACTUALIZAR_LOTE");
            db.AddInParameter(dbCommand, "pvcCODSECTOR", DbType.String, entSIC_UNIDAD.CODSECTOR);
            db.AddInParameter(dbCommand, "pvcCODMANZANA", DbType.String, entSIC_UNIDAD.CODMANZANA);
            db.AddInParameter(dbCommand, "pvcCODLOTE", DbType.String, entSIC_UNIDAD.CODLOTE);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcESTADO", DbType.String, entSIC_UNIDAD.ESTADO);
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
        public BE.SIC_RETORNO ActualizarUnidad(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ACTUALIZAR_UNIDAD");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.String, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODUSUARIO", DbType.String, entSIC_UNIDAD.CODUSUARIO);
            db.AddInParameter(dbCommand, "pvcESTADO", DbType.String, entSIC_UNIDAD.ESTADO);
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

        public BE.SIC_RETORNO ValidarTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_VAL_TEMPORAL");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            db.AddOutParameter(dbCommand, "pvcMENSAJE", DbType.String, 50);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.MENSAJE = Convert.ToString(db.GetParameterValue(dbCommand, "pvcMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ValidarYaTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_YA_TEMPORAL");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarFlgTemporal(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ACT_FLGTEMPORAL");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddInParameter(dbCommand, "pvcCODANOSOLI", DbType.String, entSIC_UNIDAD.CODANOSOLI);
            db.AddInParameter(dbCommand, "pvcCODNUMESOLI", DbType.String, entSIC_UNIDAD.CODNUMESOLI);
            db.AddInParameter(dbCommand, "pvcCODTIPOSOLI", DbType.String, entSIC_UNIDAD.CODTIPOSOLI);
            db.AddInParameter(dbCommand, "pvcCTIPODOCUMENTO", DbType.String, entSIC_UNIDAD.CTIPODOCUMENTO);
            db.AddInParameter(dbCommand, "pvcFLGTEMP", DbType.String, entSIC_UNIDAD.FLGTEMP);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }

        public BE.SIC_RETORNO ActualizarFlgTemporalNull(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_ACT_FLGTEMPUC");
            db.AddInParameter(dbCommand, "pvcCODUNI", DbType.Int32, entSIC_UNIDAD.CODUNI);
            db.AddOutParameter(dbCommand, "pvcNROMENSAJE", DbType.Int32, 0);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = "0"; // (string)(db.GetParameterValue(dbCommand, "pvcCODCORRUNIDINSP"));
                entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }


        public BE.SIC_UNIDAD ValidacionEliminar(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + ".PKG_MSISIC_GEST_UNIDAD.PRC_VAL_ANULACION", new object[12]);
            db.SetParameterValue(dbCommand, "pvcCODDEPARTAMENTO", entSIC_UNIDAD.CODDEPARTAMENTO);
            db.SetParameterValue(dbCommand, "pvcCODPROVINCIA", entSIC_UNIDAD.CODPROVINCIA);
            db.SetParameterValue(dbCommand, "pvcCODDISTRITO", entSIC_UNIDAD.CODDISTRITO);
            db.SetParameterValue(dbCommand, "pvcCODSECTOR", entSIC_UNIDAD.CODSECTOR);
            db.SetParameterValue(dbCommand, "pvcCODMANZANA", entSIC_UNIDAD.CODMANZANA);
            db.SetParameterValue(dbCommand, "pvcCODLOTE", entSIC_UNIDAD.CODLOTE);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACION", entSIC_UNIDAD.CODEDIFICACION);
            db.SetParameterValue(dbCommand, "pvcCODENTRADA", entSIC_UNIDAD.CODENTRADA);
            db.SetParameterValue(dbCommand, "pvcCODPISO", entSIC_UNIDAD.CODPISO);
            db.SetParameterValue(dbCommand, "pvcCODUNIDAD", entSIC_UNIDAD.CODUNIDAD);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.BComun);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public IEnumerable<BE.SIC_UNIDADINSPECCION> ListarUnidadInspeccion(BE.SIC_UNIDADINSPECCION entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDADINSPECCION> lista = new List<BE.SIC_UNIDADINSPECCION>();

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_LISTAR_INSPECCION" : ".PKG_MSISIC_GEST_UNIDAD.PRC_LISTAR_INSPECCION_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADINSPECCION(reader, BE.SIC_UNIDADINSPECCION.Query.ListarUnidad));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public IEnumerable<BE.SIC_UNIDADINSPECCION> ListarUnidadCartasInformes(BE.SIC_UNIDADINSPECCION entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDADINSPECCION> lista = new List<BE.SIC_UNIDADINSPECCION>();

            Database db = DatabaseFactory.CreateDatabase();
            
            string NombreProcedure = (entSIC_UNIDAD.ESTATICO == true) ? ".PKG_MSISIC_GEST_UNIDAD.PRC_LISTAR_INFORCART" : ".PKG_MSISIC_GEST_UNIDAD.PRC_LISTAR_INFORCART_TMP";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[5]);
            db.SetParameterValue(dbCommand, "pvcCODANOSOLI", entSIC_UNIDAD.CODANOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODNUMESOLI", entSIC_UNIDAD.CODNUMESOLI);
            db.SetParameterValue(dbCommand, "pvcCODTIPOSOLI", entSIC_UNIDAD.CODTIPOSOLI);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);

            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                        lista.Add(new BE.SIC_UNIDADINSPECCION(reader, BE.SIC_UNIDADINSPECCION.Query.ListarCartaInforme));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            return lista;
        }

        public BE.SIC_UNIDAD RecuperarFoto(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MSIACU.PKGACU_FOTO.PS_FOTOPRINCIPAL_MSISIC", new object[2]);
            db.SetParameterValue(dbCommand, "pvcCODLOTECATASTRAL", entSIC_UNIDAD.CODLOTECATASTRAL);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.RecuperarFoto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }
        
        public BE.SIC_UNIDAD RecuperarFotoEdificacion(BE.SIC_UNIDAD entSIC_UNIDAD)
        {
            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MSIACU.PKGACU_FOTO.PS_FOTOPRINCIPALEDI", new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODLOTECATASTRAL", entSIC_UNIDAD.CODLOTECATASTRAL);
            db.SetParameterValue(dbCommand, "pvcCODEDIFICACIONCATASTRAL", entSIC_UNIDAD.CODEDIFICACIONCATASTRAL);
            
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.RecuperarFoto);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        public BE.SIC_UNIDAD RecuperarHistoricoUnidadCatastralEST(BE.SIC_UNIDAD entSIC_UNIDAD)
        {

            BE.SIC_UNIDAD lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            string NombreProcedure = ".PKG_MSISIC_HST_UNIDAD.PRC_DATOSUNIDADINDIVIDUAL";
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaCatastro + NombreProcedure, new object[3]);
            db.SetParameterValue(dbCommand, "pvcCODUNI", entSIC_UNIDAD.CODUNI);
            db.SetParameterValue(dbCommand, "pvcNUMVERSION", entSIC_UNIDAD.NVERSION);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.SIC_UNIDAD(reader, BE.SIC_UNIDAD.Query.RecuperarHistorico);
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
