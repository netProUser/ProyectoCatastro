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
    public class SIC_TEMATICAMANZANA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_TEMATICAMANZANA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public ICollection<BE.SIC_TEMATICAMANZANA> Buscar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            List<BE.SIC_TEMATICAMANZANA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TEMATICAMANZANA> entQuery = new DA.SIC_TEMATICAMANZANA().Buscar(entSIC_TEMATICAMANZANA);
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
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_TEMATICAMANZANA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_TEMATICAMANZANA Recuperar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_TEMATICAMANZANA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TEMATICAMANZANA().Recuperar(entSIC_TEMATICAMANZANA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_TEMATICAMANZANA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_TEMATICAMANZANA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_TEMATICAMANZANA().Grabar(entSIC_TEMATICAMANZANA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_TEMATICAMANZANA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_TEMATICAMANZANA().Actualizar(entSIC_TEMATICAMANZANA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_TEMATICAMANZANA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_TEMATICAMANZANA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_TEMATICAMANZANA entSIC_TEMATICAMANZANA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_TEMATICAMANZANA().Eliminar(entSIC_TEMATICAMANZANA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
    }
}
