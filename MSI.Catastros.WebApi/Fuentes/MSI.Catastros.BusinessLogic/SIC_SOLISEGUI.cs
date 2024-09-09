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
    public class SIC_SOLISEGUI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SOLISEGUI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLISEGUI().Grabar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (23/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SOLISEGUI().Actualizar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (06/06/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Regerror
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Regerror(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLISEGUI().Regerror(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (06/06/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Filtrar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Filtrar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLISEGUI().Filtrar(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI Recuperar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLISEGUI().Recuperar(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public ICollection<BE.SIC_SOLISEGUI> Buscar(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().Buscar(entSIC_SOLISEGUI);
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
        //Creado por	: Jaime Díaz Espinoza (21/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.BuscarInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_SOLISEGUI BuscarInt(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            BE.SIC_SOLISEGUI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SOLISEGUI().BuscarInt(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.NuevoLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public ICollection<BE.SIC_SOLISEGUI> Informe(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().Informe(entSIC_SOLISEGUI);
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
        public ICollection<BE.SIC_SOLISEGUI> Carta(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().Carta(entSIC_SOLISEGUI);
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
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.NuevoLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public ICollection<BE.SIC_SOLISEGUI> NuevoLis(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().NuevoLis(entSIC_SOLISEGUI);
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
        public ICollection<BE.SIC_SOLISEGUI> NuevoSegui(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().NuevoSegui(entSIC_SOLISEGUI);
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
        //Creado por	: Pedro Peña Salazar (01/06/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.InicialLis
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public ICollection<BE.SIC_SOLISEGUI> InicialLis(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().InicialLis(entSIC_SOLISEGUI);
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
        //Creado por	: Jaime Díaz Espinoza (04/06/2018)
        //Utilizado por	: WebApi.SIC_SOLISEGUI.Seguimiento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SOLISEGUI
        /// </summary>
        public ICollection<BE.SIC_SOLISEGUI> Seguimiento(BE.SIC_SOLISEGUI entSIC_SOLISEGUI)
        {
            List<BE.SIC_SOLISEGUI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SOLISEGUI> entQuery = new DA.SIC_SOLISEGUI().Seguimiento(entSIC_SOLISEGUI);
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
