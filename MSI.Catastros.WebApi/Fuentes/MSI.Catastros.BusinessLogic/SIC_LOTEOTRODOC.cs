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
    public class SIC_LOTEOTRODOC
    {
        public BE.SIC_RETORNO EliminarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDEROVIADET)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().EliminarOtrosDocumentos(entSIC_LOTELINDEROVIADET);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_LOTEOTRODOC DescargarOtrosDocumento(BE.SIC_LOTEOTRODOC entSIC_LOTERRPP)
        {
            BE.SIC_LOTEOTRODOC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEOTRODOC().DescargarOtrosDocumento(entSIC_LOTERRPP);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_LOTEOTRODOC> ListarTipoOtrosDocumentos()
        {
            List<BE.SIC_LOTEOTRODOC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEOTRODOC> entQuery = new DA.SIC_LOTEOTRODOC().ListarTipoOtrosDocumentos();
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
        public BE.SIC_RETORNO GrabarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().GrabarOtrosDocumentos(entSIC_LOTELINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().ActualizarOtrosDocumentos(entSIC_LOTELINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarPDFOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_LOTELINDERO)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().ActualizarPDFOtrosDocumentos(entSIC_LOTELINDERO);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_LOTEOTRODOC BuscarCantidadRegistros(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_LOTEOTRODOC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEOTRODOC().BuscarCantidadRegistros(entSIC_EDIFICACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public ICollection<BE.SIC_LOTEOTRODOC> BuscarOtrosDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            List<BE.SIC_LOTEOTRODOC> lisQuery = null;
            try
            {
                IEnumerable<BE.SIC_LOTEOTRODOC> entQuery = new DA.SIC_LOTEOTRODOC().BuscarOtrosDocumentos(entSIC_EDIFICACION);
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
        public BE.SIC_LOTEOTRODOC RecuperarOtroDocId(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_LOTEOTRODOC lisQuery = null;
            try
            {
                lisQuery = new DA.SIC_LOTEOTRODOC().RecuperarOtroDocId(entSIC_EDIFICACION);
            }
            catch (Exception e)
            {
                throw e;
            }
            return lisQuery;
        }
        public BE.SIC_RETORNO GrabarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = null;
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().GrabarTipoOtroDocumentos(entSIC_EDIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO ActualizarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().ActualizarTipoOtroDocumentos(entSIC_EDIFICACION);
                new EX.ThrowError((int)entSIC_RETORNO.NoMENSAJE);
            }
            catch (Exception e)
            {
                throw e;
            }
            return entSIC_RETORNO;
        }
        public BE.SIC_RETORNO EliminarTipoOtroDocumentos(BE.SIC_LOTEOTRODOC entSIC_EDIFICACION)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            try
            {
                entSIC_RETORNO = new DA.SIC_LOTEOTRODOC().EliminarTipoOtroDocumentos(entSIC_EDIFICACION);
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
