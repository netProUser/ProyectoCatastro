using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace MSI.Catastros.DataAccess
{
    public class PGD_TRAMITE_INT : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (05/06/2018)
        //Utilizado por	: BusinessLogic.PGD_TRAMITE_INT.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla PGD_TRAMITE_INT, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            entSIC_RETORNO.Ok = false;
            entSIC_RETORNO.NoMENSAJE = 0;
            try
            {
                using (var con = new OracleConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = EsquemaTramite + ".PKGSITDAC_DERIVADOCINTERNO.MANT_DOCINTERNO";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPO",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPODESTINO",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VFECHA",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VFECHA
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VUSUARIO",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VUSUARIO,
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VID",
                            Direction = ParameterDirection.InputOutput,
                            OracleType = OracleType.VarChar,
                            Value = entPGD_TRAMITE_INT.VID
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPO_DOCUMENTO",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VTIPO_DOCUMENTO
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VOBSERVACION",
                            Direction = ParameterDirection.Input,
                            Value = "  " + entPGD_TRAMITE_INT.VOBSERVACION
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VUSUARIO_AREA",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VUSUARIO_AREA
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCODIGO_CONTRIBUYENTE",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCONTRIBUYENTE",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VBODY",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VDIRECCION",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VPAGINAS",
                            Direction = ParameterDirection.Input,
                            //Value = entPGD_TRAMITE_INT.VPAGINAS
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VREQRPTA",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VREQRPTA
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VNDIASRPTA",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        var dt = DateTime.Today.Date.ToShortDateString();
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VFECLIMRPTA",
                            Direction = ParameterDirection.Input,
                            OracleType = System.Data.OracleClient.OracleType.DateTime,
                            DbType = System.Data.DbType.Date,
                            Value = System.DBNull.Value
                            //Value = DateTime.Now
                        });

                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VNRODOC",
                            Direction = ParameterDirection.InputOutput,
                            OracleType = OracleType.VarChar,
                            DbType = System.Data.DbType.String,
                            Size = 32767,
                            Value = null
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCOD_ACTIVIDAD",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_INT.VCOD_ACTIVIDAD
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCOD_ACCION",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VNUMFOLEXP",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VDATNOTIF",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VOBSDIR",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VAREAINTERNA",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });

                        cmd.ExecuteNonQuery();
                        entSIC_RETORNO.Ok = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            #region prueba1
            /*Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaTramite + ".PGD_TRAMITE.MANT_TRAMITE2");
            db.AddInParameter(dbCommand, "VTIPO", DbType.Int32, 0);
            db.AddInParameter(dbCommand, "VTIPODESTINO", DbType.Int32, 0);
            db.AddInParameter(dbCommand, "VFECHA", DbType.String, entPGD_TRAMITE_INT.VFECHA);
            db.AddInParameter(dbCommand, "VID", DbType.String, entPGD_TRAMITE_INT.VID);
            db.AddOutParameter(dbCommand, "VID", DbType.String, 10); // ==>
            db.AddInParameter(dbCommand, "VTIPO_DOCUMENTO", DbType.String, entPGD_TRAMITE_INT.VTIPO_DOCUMENTO);
            db.AddInParameter(dbCommand, "VOBSERVACION", DbType.String, entPGD_TRAMITE_INT.VOBSERVACION);
            db.AddInParameter(dbCommand, "VUSUARIO_AREA", DbType.String, entPGD_TRAMITE_INT.VUSUARIO_AREA);
            db.AddInParameter(dbCommand, "VCODIGO_CONTRIBUYENTE", DbType.String, "");
            db.AddInParameter(dbCommand, "VCONTRIBUYENTE", DbType.String, entPGD_TRAMITE_INT.VCONTRIBUYENTE);
            db.AddInParameter(dbCommand, "VBODY", DbType.String, entPGD_TRAMITE_INT.VBODY);
            db.AddInParameter(dbCommand, "VDIRECCION", DbType.String, "");
            db.AddInParameter(dbCommand, "VPAGINAS", DbType.Int32, entPGD_TRAMITE_INT.VPAGINAS);
            db.AddInParameter(dbCommand, "VREQRPTA", DbType.Int32, entPGD_TRAMITE_INT.VREQRPTA);
            db.AddInParameter(dbCommand, "VNDIASRPTA", DbType.Int32, 0);
            db.AddInParameter(dbCommand, "VFECLIMRPTA ", DbType.Date, entPGD_TRAMITE_INT.VFECLIMRPTA);
            db.AddInParameter(dbCommand, "VNRODOC", DbType.String, entPGD_TRAMITE_INT.VNRODOC); // ==>
            db.AddOutParameter(dbCommand, "VNRODOC", DbType.String, 10); // ==>
            db.AddInParameter(dbCommand, "VCOD_ACTIVIDAD", DbType.String, entPGD_TRAMITE_INT.VCOD_ACTIVIDAD);
            db.AddInParameter(dbCommand, "VCOD_ACCION", DbType.String, "");
            db.AddInParameter(dbCommand, "VNUMFOLEXP", DbType.Int32, entPGD_TRAMITE_INT.VNUMFOLEXP);
            db.AddInParameter(dbCommand, "VDATNOTIF", DbType.String, "");
            db.AddInParameter(dbCommand, "VOBSDIR", DbType.String, "");
            db.AddInParameter(dbCommand, "VAREAINTERNA", DbType.String, "");
            try
            {
                db.ExecuteNonQuery(dbCommand);
                //entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcCODSECTOR"));
                //entSIC_RETORNO.NoMENSAJE = Convert.ToInt32(db.GetParameterValue(dbCommand, "pvcNROMENSAJE"));
                entSIC_RETORNO.Ok = true; // ((int)entSIC_RETORNO.NoMENSAJE == 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }*/
            #endregion

            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (13/06/2018)
        //Utilizado por	: BusinessLogic.PGD_TRAMITE_INT.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla PGD_TRAMITE_INT
        /// </summary>
        public BE.PGD_TRAMITE_INT Consulta(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.PGD_TRAMITE_INT lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaTramite + ".PKGSITDAC_CONSDOCUMENTO.PRC_CONSULTA_DOCUMENTO_INT", new object[3]);
            db.SetParameterValue(dbCommand, "pvcTIPODOC", entPGD_TRAMITE_INT.VTIPO_DOCUMENTO);
            db.SetParameterValue(dbCommand, "pvcNUMEDOC", entPGD_TRAMITE_INT.VNRODOC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.PGD_TRAMITE_INT(reader, BE.PGD_TRAMITE_INT.Query.Consultar);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lista;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (16/11/2018)
        //Utilizado por	: BusinessLogic.PGD_TRAMITE_INT.ObtenerDocInterno
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla PGD_TRAMITE_INT
        /// </summary>
        public BE.SIC_RETORNO ObtenerDocInterno(BE.PGD_TRAMITE_INT entPGD_TRAMITE_INT)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaTramite + ".PKGSITDAC_CONSDOCUMENTO.PRC_OBTENER_NRODOCINTERNO");
            db.AddInParameter(dbCommand, "pvcTIPO_DOCUMENTO", DbType.String, entPGD_TRAMITE_INT.VTIPO_DOCUMENTO);
            db.AddInParameter(dbCommand, "pnbFOLIOS", DbType.String, entPGD_TRAMITE_INT.NUMFOLIO);
            db.AddInParameter(dbCommand, "pvcASUNTO", DbType.String, entPGD_TRAMITE_INT.TXTASUNTO);
            db.AddInParameter(dbCommand, "pvcUSUARIO", DbType.String, entPGD_TRAMITE_INT.VUSUARIO);
            db.AddInParameter(dbCommand, "pvcAREAGENERADOC", DbType.String, @ConfigurationManager.AppSettings["CODAREA"]);
            db.AddInParameter(dbCommand, "pvcDIRIGIDO", DbType.String, entPGD_TRAMITE_INT.VCONTRIBUYENTE);
            db.AddInParameter(dbCommand, "pvcCODACCION", DbType.String, null);
            db.AddOutParameter(dbCommand, "pvcNRODOC", DbType.String, 20);
            try
            {
                db.ExecuteNonQuery(dbCommand);
                entSIC_RETORNO.CODIGO = (string)(db.GetParameterValue(dbCommand, "pvcNRODOC"));
                entSIC_RETORNO.Ok = (true);
                entSIC_RETORNO.NoMENSAJE = 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return entSIC_RETORNO;
        }
    }
}
