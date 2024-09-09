using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.BusinessEntities
{
    public partial class SIC_UNIDADCONSTRUCCION
    {
        public enum Query
        {
            None,
            Listar,
            Recuperar,
            ListarHistorico,
        }

        #region Campos aumentados
        public Boolean ESTATICO { get; set; }
        public string TXTMATEESTR { get; set; }
        public string TXTESTACONSE { get; set; }
        #endregion

        public SIC_UNIDADCONSTRUCCION() { }

        public SIC_UNIDADCONSTRUCCION(IDataReader reader, Query query = Query.None)
        {
            switch (query)
            {
                case Query.ListarHistorico:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDCONS = reader.GetSafeString("CODCORRUNIDCONS");
                    NUMORDEN = reader.GetSafeInt32("NUMORDEN");
                    TXTPISO = reader.GetSafeString("TXTPISO");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    CODMATEESTR = reader.GetSafeString("CODMATEESTR");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    CODCATEMURO = reader.GetSafeString("CODCATEMURO");
                    CODCATETECH = reader.GetSafeString("CODCATETECH");
                    CODCATEPISO = reader.GetSafeString("CODCATEPISO");
                    CODCATEPUERVENT = reader.GetSafeString("CODCATEPUERVENT");
                    CODCATEREVE = reader.GetSafeString("CODCATEREVE");
                    CODCATEBANO = reader.GetSafeString("CODCATEBANO");
                    CODCATEINSTELEC = reader.GetSafeString("CODCATEINSTELEC");
                    NUMAREADECL = reader.GetSafeDecimal("NUMAREADECL");
                    NUMAREAVERI = reader.GetSafeDecimal("NUMAREAVERI");




                    break;
                case Query.Listar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDCONS = reader.GetSafeString("CODCORRUNIDCONS");
                    NUMORDEN = reader.GetSafeInt32("NUMORDEN");
                    TXTPISO = reader.GetSafeString("TXTPISO");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    CODMATEESTR = reader.GetSafeString("CODMATEESTR");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    TXTMATEESTR = reader.GetSafeString("TXTMATEESTR");
                    TXTESTACONSE = reader.GetSafeString("TXTESTACONSE");
                    CODCATEMURO = reader.GetSafeString("CODCATEMURO");
                    CODCATETECH = reader.GetSafeString("CODCATETECH");
                    CODCATEPISO = reader.GetSafeString("CODCATEPISO");
                    CODCATEPUERVENT = reader.GetSafeString("CODCATEPUERVENT");
                    CODCATEREVE = reader.GetSafeString("CODCATEREVE");
                    CODCATEBANO = reader.GetSafeString("CODCATEBANO");
                    CODCATEINSTELEC = reader.GetSafeString("CODCATEINSTELEC");
                    NUMAREADECL = reader.GetSafeDecimal("NUMAREADECL");
                    NUMAREAVERI = reader.GetSafeDecimal("NUMAREAVERI");
                    break;
                case Query.Recuperar:
                    CODUNI = reader.GetSafeInt32("CODUNI");
                    CODCORRUNIDCONS = reader.GetSafeString("CODCORRUNIDCONS");
                    NUMORDEN = reader.GetSafeInt32("NUMORDEN");
                    TXTPISO = reader.GetSafeString("TXTPISO");
                    TXTMES = reader.GetSafeString("TXTMES");
                    TXTANO = reader.GetSafeString("TXTANO");
                    CODMATEESTR = reader.GetSafeString("CODMATEESTR");
                    CODESTACONSE = reader.GetSafeString("CODESTACONSE");
                    CODCATEMURO = reader.GetSafeString("CODCATEMURO");
                    CODCATETECH = reader.GetSafeString("CODCATETECH");
                    CODCATEPISO = reader.GetSafeString("CODCATEPISO");
                    CODCATEPUERVENT = reader.GetSafeString("CODCATEPUERVENT");
                    CODCATEREVE = reader.GetSafeString("CODCATEREVE");
                    CODCATEBANO = reader.GetSafeString("CODCATEBANO");
                    CODCATEINSTELEC = reader.GetSafeString("CODCATEINSTELEC");
                    NUMAREADECL = reader.GetSafeDecimal("NUMAREADECL");
                    NUMAREAVERI = reader.GetSafeDecimal("NUMAREAVERI");
                    break;
                default:
                    break;
            }
        }
    }
}
