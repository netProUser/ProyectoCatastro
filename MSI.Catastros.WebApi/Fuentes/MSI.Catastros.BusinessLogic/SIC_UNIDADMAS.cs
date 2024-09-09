using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;
using System.Data;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_UNIDADMAS
    {
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADMAS entSIC_UNIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADMAS().Grabar(entSIC_UNIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public ICollection<BE.SIC_UNIDADMAS> Buscar(BE.SIC_UNIDADMAS entSIC_UNIDAD)
        {
            List<BE.SIC_UNIDADMAS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADMAS> entQuery = new DA.SIC_UNIDADMAS().Buscar(entSIC_UNIDAD);
                if (entQuery != null)
                {
                    lisQuery = entQuery.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public DataTable Excel(BE.SIC_UNIDADMAS entSIC_UNIDADMAS)
        {
            return new DA.SIC_UNIDADMAS().Excel(entSIC_UNIDADMAS);

        }
    }
}
