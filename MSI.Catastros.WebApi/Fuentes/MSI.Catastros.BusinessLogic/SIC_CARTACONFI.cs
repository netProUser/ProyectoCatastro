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
    public class SIC_CARTACONFI
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/07/2018)
        //Utilizado por	: WebApi.SIC_CARTACONFI.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CARTACONFI
        /// </summary>
        public ICollection<BE.SIC_CARTACONFI> Buscar(BE.SIC_CARTACONFI entSIC_CARTACONFI)
        {
            List<BE.SIC_CARTACONFI> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CARTACONFI> entQuery = new DA.SIC_CARTACONFI().Buscar(entSIC_CARTACONFI);
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
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_CARTACONFI.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CARTACONFI, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CARTACONFI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CARTACONFI().Grabar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_CARTACONFI.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_SOLISEGUI
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CARTACONFI entSIC_SOLISEGUI)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CARTACONFI().Actualizar(entSIC_SOLISEGUI);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_CARTACONFI.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CARTACONFI
        /// </summary>
        public BE.SIC_CARTACONFI Recuperar(BE.SIC_CARTACONFI entSIC_SOLISEGUI)
        {
            BE.SIC_CARTACONFI lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CARTACONFI().Recuperar(entSIC_SOLISEGUI);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        
    }
}
