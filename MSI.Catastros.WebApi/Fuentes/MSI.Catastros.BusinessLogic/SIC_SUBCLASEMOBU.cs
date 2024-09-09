using System;
using System.Collections.Generic;
using System.Linq;


using BE = MSI.Catastros.BusinessEntities;
using DA = MSI.Catastros.DataAccess;
using HP = MSI.Catastros.Helpers;
using EX = MSI.Catastros.Exceptions;

namespace MSI.Catastros.BusinessLogic
{
    public class SIC_SUBCLASEMOBU
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_SUBCLASEMOBU.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_SUBCLASEMOBU, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SUBCLASEMOBU().Grabar(entSIC_SUBCLASEMOBU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_SUBCLASEMOBU.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SUBCLASEMOBU
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SUBCLASEMOBU().Actualizar(entSIC_SUBCLASEMOBU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_SUBCLASEMOBU.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_SUBCLASEMOBU
        /// </summary>
        public BE.SIC_SUBCLASEMOBU Recuperar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_SUBCLASEMOBU lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_SUBCLASEMOBU().Recuperar(entSIC_SUBCLASEMOBU);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_SUBCLASEMOBU.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_SUBCLASEMOBU
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_SUBCLASEMOBU().Eliminar(entSIC_SUBCLASEMOBU);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Eistein Dolores Tarazona (05/07/2018)
        //Utilizado por	: WebApi.SIC_SUBCLASEMOBU.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_SUBCLASEMOBU
        /// </summary>
        public ICollection<BE.SIC_SUBCLASEMOBU> Listar(BE.SIC_SUBCLASEMOBU entSIC_SUBCLASEMOBU)
        {
            List<BE.SIC_SUBCLASEMOBU> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_SUBCLASEMOBU> entQuery = new DA.SIC_SUBCLASEMOBU().Listar(entSIC_SUBCLASEMOBU);
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
