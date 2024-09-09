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
    public class SIC_CONTROLCALIDAD
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/05/2018)
        //Utilizado por	: WebApi.SIC_CONTROLCALIDAD.Listar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_CONTROLCALIDAD
        /// </summary>
        public ICollection<BE.SIC_CONTROLCALIDAD> Listar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            List<BE.SIC_CONTROLCALIDAD> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CONTROLCALIDAD> entQuery = new DA.SIC_CONTROLCALIDAD().Listar(entSIC_CONTROLCALIDAD);
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
        //Utilizado por	: WebApi.SIC_CONTROLCALIDAD.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONTROLCALIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CONTROLCALIDAD().Grabar(entSIC_CONTROLCALIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (05/06/2018)
        //Utilizado por	: WebApi.SIC_CONTROLCALIDAD.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CONTROLCALIDAD, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CONTROLCALIDAD().Actualizar(entSIC_CONTROLCALIDAD);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (31/04/2018)
        //Utilizado por	: WebApi.SIC_CONTROLCALIDAD.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_CONTROLCALIDAD
        /// </summary>
        public BE.SIC_RETORNO Eliminar(BE.SIC_CONTROLCALIDAD entSIC_CONTROLCALIDAD)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CONTROLCALIDAD().Eliminar(entSIC_CONTROLCALIDAD);
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
