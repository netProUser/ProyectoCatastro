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
    public class SIC_TIPOHABURB
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: WebApi.SIC_TIPOHABURB.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_TIPOHABURB
        /// </summary>
        public ICollection<BE.SIC_TIPOHABURB> Buscar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            List<BE.SIC_TIPOHABURB> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_TIPOHABURB> entQuery = new DA.SIC_TIPOHABURB().Buscar(entSIC_TIPOHABURB);
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
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: WebApi.SIC_TIPOHABURB.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_TIPOHABURB Recuperar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_TIPOHABURB lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_TIPOHABURB().Recuperar(entSIC_TIPOHABURB);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: WebApi.SIC_TIPOHABURB.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_TIPOHABURB, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOHABURB().Grabar(entSIC_TIPOHABURB);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: WebApi.SIC_TIPOHABURB.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOHABURB().Actualizar(entSIC_TIPOHABURB);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (21/04/2018)
        //Utilizado por	: WebApi.SIC_TIPOHABURB.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_TIPOHABURB
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_TIPOHABURB entSIC_TIPOHABURB)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_TIPOHABURB().Eliminar(entSIC_TIPOHABURB);
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
