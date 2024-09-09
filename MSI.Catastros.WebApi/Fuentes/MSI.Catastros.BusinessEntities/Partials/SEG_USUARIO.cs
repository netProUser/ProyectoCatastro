using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SEG_USUARIO
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string CodigoPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public string NombrePersona { get; set; }
        public string CodigoArea { get; set; }
        public string CodAreaUsuario { get; set; }
        #endregion

        public SEG_USUARIO() { }

        //public SEG_USUARIO(IDataReader reader, Query query = Query.None)
        //{
        //    switch (query)
        //    {
        //        case Query.Listar:
        //            /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
        //            CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
        //            CODDISTRITO = reader.GetSafeString("CODDISTRITO");
        //            CODSECTOR = reader.GetSafeString("CODSECTOR");
        //            TXTSECTOR = reader.GetSafeString("TXTSECTOR");
        //            TXTDISTRITO = reader.GetSafeString("TXTDISTRITO");*/
        //            break;
        //        case Query.Recuperar:
        //            CODUSUARIO = reader.GetSafeString("CODUSUARIO");
        //            CODPERSONA = reader.GetSafeString("CODPERSONA");

        //            //CodigoPerfil = reader["CODIGOPERFIL"].ToString();
        //            //NombrePerfil = reader["NOMBREPERFIL"].ToString();
        //            //NombrePersona = reader["NOMBREPERSONA"].ToString();
        //            break;
        //        default:
        //            break;
        //    }
        //}
        public SEG_USUARIO(DataRow reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    /*CODDEPARTAMENTO = reader.GetSafeString("CODDEPARTAMENTO");
                    CODPROVINCIA = reader.GetSafeString("CODPROVINCIA");
                    CODDISTRITO = reader.GetSafeString("CODDISTRITO");
                    CODSECTOR = reader.GetSafeString("CODSECTOR");
                    TXTSECTOR = reader.GetSafeString("TXTSECTOR");
                    TXTDISTRITO = reader.GetSafeString("TXTDISTRITO");*/
                    break;
                case Query.Recuperar:
                    CODUSUARIO = reader["CODUSUARIO"].ToString();
                    CODPERSONA = reader["CODPERSONA"].ToString();

                    CodigoPerfil = reader["CODIGOPERFIL"].ToString();
                    NombrePerfil = reader["NOMBREPERFIL"].ToString();
                    NombrePersona = reader["NOMBREPERSONA"].ToString();
                    CodAreaUsuario = reader["CODAREAUSUARIO"].ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
