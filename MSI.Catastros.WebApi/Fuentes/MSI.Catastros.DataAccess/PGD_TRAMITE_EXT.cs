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

namespace MSI.Catastros.DataAccess
{
    public class PGD_TRAMITE_EXT : Base
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (05/06/2018)
        //Utilizado por	: BusinessLogic.PGD_TRAMITE_EXT.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla PGD_TRAMITE_EXT, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.PGD_TRAMITE_EXT entPGD_TRAMITE_EXT)
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
                        cmd.CommandText = EsquemaTramite + ".PGD_TRAMITE.MANT_TRAMITE2";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "vTIPO",
                            Direction = ParameterDirection.InputOutput,
                            Value = entPGD_TRAMITE_EXT.VTIPO
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPODESTINO",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VTIPODESTINO
                        });
                        cmd.Parameters.Add(new OracleParameter 
                        {
                            ParameterName = "VID_REF",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VID_REF
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VREMITE",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VREMITE
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPREM",
                            Direction = ParameterDirection.Input,
                            Value = "1"
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VPERREM",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VPERREM
                        });
                        cmd.Parameters.Add(new OracleParameter 
                        {
                            ParameterName = "VRECIBE",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VRECIBE
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VTIPREC",
                            Direction = ParameterDirection.Input,
                            Value = "1"
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VPERREC",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VPERREC
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VOBSERV",
                            Direction = ParameterDirection.Input,
                            Value = (entPGD_TRAMITE_EXT.VOBSERV != null ) ? entPGD_TRAMITE_EXT.VOBSERV : ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VFECING",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VFECING
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VFOLIOS",
                            Direction = ParameterDirection.Input,
                            Value = entPGD_TRAMITE_EXT.VFOLIOS
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCODACT2",
                            Direction = ParameterDirection.InputOutput,
                            Value = (entPGD_TRAMITE_EXT.VCODACT2 != null) ? entPGD_TRAMITE_EXT.VCODACT2 : ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VCODACC2",
                            Direction = ParameterDirection.InputOutput,
                            Value = (entPGD_TRAMITE_EXT.VCODACC2 != null) ? entPGD_TRAMITE_EXT.VCODACC2 : ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VID_DOCINT",
                            Direction = ParameterDirection.Input,
                            Value = ""
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VSECUENCIA",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VSEPARA",
                            Direction = ParameterDirection.Input,
                            Value = 0
                        });
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "VRESOLVER",
                            Direction = ParameterDirection.Input,
                            Value = 0
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

            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (13/06/2018)
        //Utilizado por	: BusinessLogic.PGD_TRAMITE_EXT.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla PGD_TRAMITE_EXT
        /// </summary>
        public BE.PGD_TRAMITE_EXT Consulta(BE.PGD_TRAMITE_EXT entPGD_TRAMITE_EXT)
        {
            BE.PGD_TRAMITE_EXT lista = null;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand(EsquemaTramite + ".PKGSITDAC_CONSDOCUMENTO.PRC_CONSULTA_DATOS_DOC_EXT", new object[3]);
            db.SetParameterValue(dbCommand, "pvcTIPODOC", entPGD_TRAMITE_EXT.TXTTIPODOC);
            db.SetParameterValue(dbCommand, "pvcNUMEDOC", entPGD_TRAMITE_EXT.TXTNRODOC);
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCommand))
                {
                    if (reader.Read())
                        lista = new BE.PGD_TRAMITE_EXT(reader, BE.PGD_TRAMITE_EXT.Query.Consultar);
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
