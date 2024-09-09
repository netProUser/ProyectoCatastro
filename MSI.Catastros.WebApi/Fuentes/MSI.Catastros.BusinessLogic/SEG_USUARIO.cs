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
    public class SEG_USUARIO
    {
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        //Creado por	: Jaime Díaz Espinoza (10/05/2018)
        //Utilizado por	: WebApi.SEG_USUARIO.ValidarAcceso
        //――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――
        /// <summary>
        /// Permite recuperar un registro de la tabla MSICAS.CAS_USUARIOS
        /// </summary>
        public BE.SEG_USUARIO ValidarAcceso(BE.SEG_USUARIO entSEG_USUARIO)
        {
            BE.SEG_USUARIO lisQuery = null;
            try
            {
                lisQuery = new DA.SEG_USUARIO().ValidarAcceso(entSEG_USUARIO);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("2000")) {
                    return null;
                }
                throw e;
            }
            return lisQuery;
        }
        public IEnumerable<BE.SEG_OPCION> CargarOpciones(BE.SEG_USUARIO entSEG_USUARIO)
        {
            List<BE.SEG_OPCION> lisQuery = null;
            try
            {
                IEnumerable<BE.SEG_OPCION> entQuery = new DA.SEG_USUARIO().CargarOpciones(entSEG_USUARIO);
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
        public BE.SEG_USUARIO CambiarContraseña(BE.SEG_USUARIO entSIC_Contraseña)
        {
            BE.SEG_USUARIO entSIC_RETORNO = new BE.SEG_USUARIO();
            try
            {
                entSIC_RETORNO = new DA.SEG_USUARIO().CambiarContraseña(entSIC_Contraseña);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("2000"))
                {
                    return null;
                }
                throw e;
            }
            return entSIC_RETORNO;
        }
    }
}
