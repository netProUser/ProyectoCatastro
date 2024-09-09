using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_UNIDADDIRECCONINTERIOR
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADDIRECCONINTERIOR.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADDIRECCONINTERIOR().Grabar(entSIC_UNIDADDIRECCONINTERIOR);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADDIRECCONINTERIOR.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADDIRECCONINTERIOR().Actualizar(entSIC_UNIDADDIRECCONINTERIOR);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADDIRECCONINTERIOR.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_UNIDADDIRECCONINTERIOR Recuperar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_UNIDADDIRECCONINTERIOR lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_UNIDADDIRECCONINTERIOR().Recuperar(entSIC_UNIDADDIRECCONINTERIOR);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_UNIDADDIRECCONINTERIOR.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_UNIDADDIRECCONINTERIOR
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_UNIDADDIRECCONINTERIOR)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_UNIDADDIRECCONINTERIOR().Eliminar(entSIC_UNIDADDIRECCONINTERIOR);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public ICollection<BE.SIC_UNIDADDIRECCONINTERIOR> Listar(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_VIA)
        {
            List<BE.SIC_UNIDADDIRECCONINTERIOR> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADDIRECCONINTERIOR> entQuery = new DA.SIC_UNIDADDIRECCONINTERIOR().Listar(entSIC_VIA);
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

        public ICollection<BE.SIC_UNIDADDIRECCONINTERIOR> CargarDireccionHistoricaUnidad(BE.SIC_UNIDADDIRECCONINTERIOR entSIC_VIA)
        {
            List<BE.SIC_UNIDADDIRECCONINTERIOR> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_UNIDADDIRECCONINTERIOR> entQuery = new DA.SIC_UNIDADDIRECCONINTERIOR().CargarDireccionHistoricaUnidad(entSIC_VIA);
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
    }
}
