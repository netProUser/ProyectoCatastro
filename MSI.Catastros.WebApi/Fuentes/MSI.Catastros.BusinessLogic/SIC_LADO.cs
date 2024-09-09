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
    public class SIC_LADO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_LADO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LADO
        /// </summary>
        public ICollection<BE.SIC_LADO> Buscar(BE.SIC_LADO entSIC_LADO)
        {
            List<BE.SIC_LADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LADO> entQuery = new DA.SIC_LADO().Buscar(entSIC_LADO);
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
        //Utilizado por	: WebApi.SIC_LADO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_LADO
        /// </summary>
        public BE.SIC_LADO Recuperar(BE.SIC_LADO entSIC_LADO)
        {
            BE.SIC_LADO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LADO().Recuperar(entSIC_LADO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (23/04/2018)
        //Utilizado por	: WebApi.SIC_LADO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_LADO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_LADO entSIC_LADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_LADO().Grabar(entSIC_LADO);
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
        //Utilizado por	: WebApi.SIC_LADO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_LADO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_LADO entSIC_LADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LADO().Actualizar(entSIC_LADO);
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
        //Utilizado por	: WebApi.SIC_LADO.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_LADO
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_LADO entSIC_LADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LADO().Eliminar(entSIC_LADO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: WebApi.SIC_LADO.Linderos
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LADO
        /// </summary>
        public ICollection<BE.SIC_LADO> Vias(BE.SIC_LADO entSIC_LADO)
        {
            List<BE.SIC_LADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LADO> entQuery = new DA.SIC_LADO().Listar("1");
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
        //Creado por	: Jaime Díaz Espinoza (21/06/2018)
        //Utilizado por	: WebApi.SIC_LADO.Linderos
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_LADO
        /// </summary>
        public ICollection<BE.SIC_LADO> Linderos(BE.SIC_LADO entSIC_LADO)
        {
            List<BE.SIC_LADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LADO> entQuery = new DA.SIC_LADO().Listar("2");
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
