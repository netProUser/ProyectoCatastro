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
    public class SIC_URBANIZACION
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_URBANIZACION.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_URBANIZACION
        /// </summary>
        public ICollection<BE.SIC_URBANIZACION> Buscar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            List<BE.SIC_URBANIZACION> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_URBANIZACION> entQuery = new DA.SIC_URBANIZACION().Buscar(entSIC_URBANIZACION);
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
        //Utilizado por	: WebApi.SIC_URBANIZACION.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_URBANIZACION
        /// </summary>
        public BE.SIC_URBANIZACION Recuperar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            BE.SIC_URBANIZACION lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_URBANIZACION().Recuperar(entSIC_URBANIZACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_URBANIZACION.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_URBANIZACION, retorna numero de ERROR o ID generado
        /// </summary>
        public int Grabar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            try
            {
                intResultado = new DA.SIC_URBANIZACION().Grabar(entSIC_URBANIZACION);
                new EX.ThrowError(intResultado);
            }
            catch (Exception e)
            {
                throw e;
            }
            return intResultado;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_URBANIZACION.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_URBANIZACION
        /// </summary>
        public int Actualizar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            try
            {
                intResultado = new DA.SIC_URBANIZACION().Actualizar(entSIC_URBANIZACION);
                new EX.ThrowError(intResultado);
            }
            catch (Exception e)
            {
                throw e;
            }
            return intResultado;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (18/04/2018)
        //Utilizado por	: WebApi.SIC_URBANIZACION.Eliminar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite eliminar el registro de la tabla SIC_URBANIZACION
        /// </summary>
        public int Eliminar(BE.SIC_URBANIZACION entSIC_URBANIZACION)
        {
            int intResultado = 0;
            try
            {
                intResultado = new DA.SIC_URBANIZACION().Eliminar(entSIC_URBANIZACION);
                new EX.ThrowError(intResultado);
            }
            catch (Exception e)
            {
                throw e;
            }
            return intResultado;
        }
    }
}
