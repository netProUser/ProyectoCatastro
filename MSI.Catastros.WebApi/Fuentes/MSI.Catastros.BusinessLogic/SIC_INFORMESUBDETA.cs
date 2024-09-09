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
    public class SIC_INFORMESUBDETA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public ICollection<BE.SIC_INFORMESUBDETA> Buscar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            List<BE.SIC_INFORMESUBDETA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_INFORMESUBDETA> entQuery = new DA.SIC_INFORMESUBDETA().Buscar(entSIC_INFORMESUBDETA);
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
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_INFORMESUBDETA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMESUBDETA().Grabar(entSIC_INFORMESUBDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMESUBDETA().Actualizar(entSIC_INFORMESUBDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_INFORMESUBDETA Recuperar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_INFORMESUBDETA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_INFORMESUBDETA().Recuperar(entSIC_INFORMESUBDETA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña  Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMESUBDETA().Eliminar(entSIC_INFORMESUBDETA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña  Salazar (20/08/2018)
        //Utilizado por	: WebApi.SIC_INFORMESUBDETA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_INFORMESUBDETA
        /// </summary>
        public BE.SIC_RETORNO EliminarDetalle(BE.SIC_INFORMESUBDETA entSIC_INFORMESUBDETA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_INFORMESUBDETA().EliminarDetalle(entSIC_INFORMESUBDETA);
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
