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
    public class SIC_PARAMETROS
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.AnchoVia
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> AnchoVia()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(108);
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
        //Creado por	: Pedro Peña Salazar (10/09/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoPersona
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoPersona()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(134);
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
        public ICollection<BE.SIC_PARAMETROS> TipoAlturaVia()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(138);
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
        //Creado por	: Pedro Peña Salazar (25/09/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoManzanaUrbana
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoManzanaUrbana()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(137);
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
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.ClasificacionVia
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> ClasificacionVia()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(107);
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
        //Creado por	: Jaime Díaz Espinoza (25/04/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoDeVia
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDeVia()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(21);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoSolicitud
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoSolicitud()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(109);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoRequerimiento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoRequerimiento()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(112);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoInspeccionExterior
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoInspeccionFicha()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(113);
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
        //Creado por	: Jaime Díaz Espinoza (14/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoSiNo
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoSiNo()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(110);
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
        //Creado por	: Jaime Díaz Espinoza (14/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoSiNo
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDocumentoIdentidad()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(27);
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
        //Creado por	: Jaime Díaz Espinoza (14/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoLote
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoLote()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(116);
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
        //Creado por	: Pedro Peña Salazar (04/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoError
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_ERRORCALIDA
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoError(String tipoerror)
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().TipoError(tipoerror);
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
        //Creado por	: Pedro Peña (21/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoDiferenciador
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDiferenciador()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(133);
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
        //Creado por	: Jaime Díaz Espinoza (17/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoErrorDigitacion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoErrorDigitacion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(114);
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
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoAccion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoAccion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().TipoAccion();
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
        //Creado por	: Jaime Díaz Espinoza (24/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoActividad
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoActividad()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().TipoActividad();
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
        //Creado por	: Jaime Díaz Espinoza (30/05/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoDocumento
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSIRENTAS.CD_TIPODOC
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDocumento()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().TipoDocumento();
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
        //Creado por	: Pedro Peña Salazar (23/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.DescripcionRetiro
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSISIC.SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> DescripcionRetiro()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(130);
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
        //Creado por	: Pedro Peña Salazar (23/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.AsignacionRetiro
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSISIC.SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> AsignacionRetiro()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(126);
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
        //Creado por	: Pedro Peña Salazar (21/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoDocumentoInt
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla MSIRENTAS.CD_DOC_OFTIPO
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDocumentoInt()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().TipoDocumentoInt();
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
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.EstadoDeConstruccion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> EstadoDeConstruccion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(117);
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
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.InscripcionCatastral
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> FuentesInscripcionCatastral()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(118);
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
        //Creado por	: Jaime Díaz Espinoza (20/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.EstadoDeInterior
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> EstadoDeInterior()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(119);
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
        //Utilizado por	: WebApi.SIC_PARAMETROS.EstadoDeConservacion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> EstadoDeConservacion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(11);
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
        //Utilizado por	: WebApi.SIC_PARAMETROS.MaterialEstructural
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> MaterialEstructural()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(14);
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
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoClasificacionPredio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoClasificacionPredio()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(8);
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
        //Creado por	: Juan Quispe Ipanaque (07/08/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoDepartamentoPredio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDepartamentoPredio()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(132);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoComponente
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoComponente()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(120);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.FuenteColindante
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> FuenteColindante()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(124);
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
        //Creado por	: Jaime Díaz Espinoza (22/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoColindante
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoColindante()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(121);
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
        //Creado por	: Pedro Peña Salazar (25/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoEdificacion
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoEdificacion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(3);
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
        //Creado por	: Jaime Díaz Espinoza (25/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.UnidadMedida
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> UnidadMedida()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(5);
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
        //Creado por	: Jaime Díaz Espinoza (25/06/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.OtrasInstalaciones
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> OtrasInstalaciones()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(123);
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
        //Creado por	: Juan Quispe Ipanaque (06/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.EstadoInterior
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> EstadoInterior()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(119);
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
        //Creado por	: Juan Quispe Ipanaque (06/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoInterior
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoInterior()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(4);
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
        //Creado por	: Juan Quispe Ipanaque (16/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoAnuncio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoAnuncio()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(125);
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
        //Creado por	: Juan Quispe Ipanaque (16/07/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoAnuncio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoDireccion()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(126);
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
        //Creado por	: Juan Quispe Ipanaque (29/10/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoAnuncio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> CondicionPropiertario()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(34);
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
        //Creado por	: Juan Quispe Ipanaque (29/10/2018)
        //Utilizado por	: WebApi.SIC_PARAMETROS.TipoAnuncio
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite listar los datos de la tabla SIC_PARAMETROS
        /// </summary>
        public ICollection<BE.SIC_PARAMETROS> TipoPropiertario()
        {
            List<BE.SIC_PARAMETROS> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_PARAMETROS> entQuery = new DA.SIC_PARAMETROS().Listar(126);
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
