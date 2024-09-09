using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SEG_OPCION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
        }

        #region Campos aumentados
        public string Controladora { get; set; }
        public string Accion { get; set; }
        public string Area { get; set; }
        public int OptionSelected { get; set; }
        public string NombreGrupo { get; set; }
        public int PerfilOpcionID { get; set; }

        public string CodigoPerfil { get; set; }    //28/05/18 Pedro Peña Salazar
        public string NombrePerfil { get; set; }
        public string NombrePersona { get; set; }
        #endregion

        public SEG_OPCION()
        {
        }
        //public SEG_OPCION(IDataReader reader, Query query = Query.None)
        //{
        //    switch (query)
        //    {
        //        case Query.Listar:
        //            PK_eIdOpcion = reader.GetSafeString("TITULO");
        //            uNombreOpcion = reader.GetSafeString("TITULO");
        //            uTituloOpcion = reader.GetSafeString("TITULO");
        //            uUrl = reader.GetSafeString("NOMBRE");
        //            uTituloOpcion = reader.GetSafeString("TITULO");
        //            uDireccionOpcion = reader.GetSafeString("NOMBRE");
        //            eIdGrupoOpcion = reader.GetString("CODAGRUPAMIENTO");
        //            eNroOrden = reader.GetInt32("ORDEN");
        //            cEsVisible = reader.GetInt32("VISIBLE") == 1 ? true : false;
        //            CodigoPerfil = reader.GetString("CODIGOPERFIL");
        //            NombrePerfil = reader.GetString("NOMBREPERFIL");
        //            NombrePersona = reader.GetString("NOMBREPERSONA");
        //            Imagen = "";//reader.GetSafeString("TXTDISTRITO");
        //            break;
        //        case Query.Recuperar:
        //            //CODUSUARIO = reader.GetSafeString("CODUSUARIO");
        //            //CODPERSONA = reader.GetSafeString("CODPERSONA");
        //            break;
        //        default:
        //            break;
        //    }
        //}
        public SEG_OPCION(DataRow reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.Listar:
                    PK_eIdOpcion = reader["TITULO"].ToString();
                    uNombreOpcion = reader["TITULO"].ToString();
                    uTituloOpcion = reader["TITULO"].ToString();
                    uUrl = reader["NOMBRE"].ToString();
                    uTituloOpcion = reader["TITULO"].ToString();
                    uDireccionOpcion = reader["NOMBRE"].ToString();
                    eIdGrupoOpcion = reader["CODAGRUPAMIENTO"].ToString();
                    eNroOrden = Convert.ToInt32(reader["ORDEN"].ToString());
                    cEsVisible = reader["VISIBLE"].ToString() == "1" ? true : false;
                    //CodigoPerfil = reader["CODIGOPERFIL"].ToString();
                    //NombrePerfil = reader["NOMBREPERFIL"].ToString();
                    //NombrePersona = reader["NOMBREPERSONA"].ToString();
                    Imagen = "";//reader.GetSafeString("TXTDISTRITO");
                    break;
                case Query.Recuperar:
                    //CODUSUARIO = reader.GetSafeString("CODUSUARIO");
                    //CODPERSONA = reader.GetSafeString("CODPERSONA");
                    break;
                default:
                    break;
            }
        }
    }
}
