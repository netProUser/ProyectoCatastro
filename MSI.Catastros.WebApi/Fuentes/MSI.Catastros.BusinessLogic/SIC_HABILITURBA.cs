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
    public class SIC_HABILITURBA
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_HABILITURBA.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_HABILITURBA
        /// </summary>
        public ICollection<BE.SIC_HABILITURBA> Buscar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            List<BE.SIC_HABILITURBA> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_HABILITURBA> entQuery = new DA.SIC_HABILITURBA().Buscar(entSIC_HABILITURBA);
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
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_HABILITURBA.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_HABILITURBA Recuperar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_HABILITURBA lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_HABILITURBA().Recuperar(entSIC_HABILITURBA);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_HABILITURBA.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_HABILITURBA, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_HABILITURBA().Grabar(entSIC_HABILITURBA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_HABILITURBA.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_HABILITURBA().Actualizar(entSIC_HABILITURBA);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_HABILITURBA.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_HABILITURBA
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_HABILITURBA entSIC_HABILITURBA)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_HABILITURBA().Eliminar(entSIC_HABILITURBA);
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
