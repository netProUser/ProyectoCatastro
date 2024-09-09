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
    public class SIC_LOTEDIRECMUNI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (05/07/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public ICollection<BE.SIC_LOTEDIRECMUNI> Buscar(BE.SIC_LOTEDIRECMUNI entSIC_LOTELINDEROVIADET)
        {
            List<BE.SIC_LOTEDIRECMUNI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEDIRECMUNI> entQuery = new DA.SIC_LOTEDIRECMUNI().Buscar(entSIC_LOTELINDEROVIADET);
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
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LOTEDIRECMUNI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEDIRECMUNI().Grabar(entSIC_LOTEDIRECMUNI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEDIRECMUNI().Actualizar(entSIC_LOTEDIRECMUNI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarMod(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEDIRECMUNI().ActualizarMod(entSIC_LOTEDIRECMUNI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_LOTEDIRECMUNI Recuperar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_LOTEDIRECMUNI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEDIRECMUNI().Recuperar(entSIC_LOTEDIRECMUNI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEDIRECMUNI().Eliminar(entSIC_LOTEDIRECMUNI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (07/06/2018)
        //Utilizado por	: WebApi.SIC_LOTEDIRECMUNI.EliminarVias
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LOTEDIRECMUNI
        /// </summary>
        public BE.SIC_RETORNO EliminarVias(BE.SIC_LOTEDIRECMUNI entSIC_LOTEDIRECMUNI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEDIRECMUNI().EliminarVias(entSIC_LOTEDIRECMUNI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        public ICollection<BE.SIC_LOTEDIRECMUNI> Listar(BE.SIC_LOTEDIRECMUNI entSIC_VIA)
        {
            List<BE.SIC_LOTEDIRECMUNI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEDIRECMUNI> entQuery = new DA.SIC_LOTEDIRECMUNI().Listar(entSIC_VIA);
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

        public ICollection<BE.SIC_LOTEDIRECMUNI> ListarParaUc(BE.SIC_LOTEDIRECMUNI entSIC_VIA)
        {
            List<BE.SIC_LOTEDIRECMUNI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEDIRECMUNI> entQuery = new DA.SIC_LOTEDIRECMUNI().ListarParaUc(entSIC_VIA);
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
