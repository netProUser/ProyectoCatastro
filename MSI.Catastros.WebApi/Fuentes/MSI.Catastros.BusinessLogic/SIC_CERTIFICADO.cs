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
    public class SIC_CERTIFICADO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (08/07/2018)
        //Utilizado por	: WebApi.SIC_CERTIFICADO.Buscar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFICADO
        /// </summary>
        public ICollection<BE.SIC_CERTIFICADO> Buscar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            List<BE.SIC_CERTIFICADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFICADO> entQuery = new DA.SIC_CERTIFICADO().Buscar(entSIC_CERTIFICADO);
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
        public ICollection<BE.SIC_CERTIFICADO> BuscarCertificados(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            List<BE.SIC_CERTIFICADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFICADO> entQuery = new DA.SIC_CERTIFICADO().BuscarCertificados(entSIC_CERTIFICADO);
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

        public BE.SIC_CERTIFICADO RecuperarUrbanizacion(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_CERTIFICADO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CERTIFICADO().RecuperarUrbanizacion(entSIC_CERTIFICADO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Pedro Peña Salazar (07/08/2018)
        //Utilizado por	: WebApi.SIC_CERTIFICADO.Grabar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite grabar un registro de la tabla SIC_CERTIFICADO, retorna numero de ERROR o ID generado
        /// </summary>
        public BE.SIC_RETORNO Grabar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFICADO().Grabar(entSIC_CERTIFICADO);
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
        //Utilizado por	: WebApi.SIC_CERTIFICADO.Actualizar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite actualizar un registro de la tabla SIC_CERTIFICADO
        /// </summary>
        public BE.SIC_RETORNO Actualizar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFICADO().Actualizar(entSIC_CERTIFICADO);
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
        //Utilizado por	: WebApi.SIC_CERTIFICADO.Recuperar
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla SIC_CERTIFICADO
        /// </summary>
        public BE.SIC_CERTIFICADO Recuperar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_CERTIFICADO lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_CERTIFICADO().Recuperar(entSIC_CERTIFICADO);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }

        public BE.SIC_RETORNO Eliminar(BE.SIC_CERTIFICADO entSIC_CERTIFICADO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_CERTIFICADO().Eliminar(entSIC_CERTIFICADO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public ICollection<BE.SIC_CERTIFICADO> CargarGrillaCertificados(BE.SIC_CERTIFICADO entSIC_SOLICITUD)
        {
            List<BE.SIC_CERTIFICADO> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_CERTIFICADO> entQuery = new DA.SIC_CERTIFICADO().CargarGrillaCertificados(entSIC_SOLICITUD);
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
