using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;

namespace MSI.Catastros.Web.Funcionalidad.StatusInspeccion
{
    public class StatusInspeccionesHandler
    {
        public List<Inspecciones> ListadoStatusInspecciones(Int16 entTipoBusqueda, string entNroSolicitud, DateTime? FechaInicio, DateTime? FechaFin)
        {
            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ListarStatusInspecciones(entTipoBusqueda, entNroSolicitud, FechaInicio, FechaFin);

            var lisDataQuery = new List<Inspecciones>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new Inspecciones
                {
                    NroInspeccion = item.CODNROINSPEC,
                    NroSolicitud = item.CODNUMESOLI,
                    FechaInspeccion = item.FECINSPE.Value == null ? "" : item.FECINSPE.Value.ToShortDateString(),
                    HoraInspeccion = item.TXTHORAINSP,
                    Inspectores = item.TXTINSPECTORES,
                    Observacion = item.TXTOBSERVACION,
                    EstadoInspeccion = item.TXTESTADOINSPEC,
                    CodCatastral = item.TXTCODCATASTRAL,
                    Responsable= item.TXTINSRESPONSABLE,
                    Ubicacion = item.TXTUBICACION,
                    //Titular = item.TXTTITULAR.Substring(0,item.TXTTITULAR.Length-5),
                    //Titular = item.TXTTITULAR.Length <= 5 ? item.TXTTITULAR : item.TXTTITULAR.Substring(0, item.TXTTITULAR.Length - 5), //PVASQUEZ 20/01/20 INCIDENCIA 1.4 INFORME 585-2019
                    Titular =  item.TXTTITULAR,
                    Representante = item.TXTREPRESENTANTE,
                    TipoLlenado = item.CODTIPOLLENA,
                    MumeroSolicitud = item.TXTNUMSOLI,
                    Programado = item.TXTPROGRAMADO,
                    txtFechacitacion = item.TXTFECCITACION
                });
            }
            return lisDataQuery;
        }
        public List<Inspecciones> ConsultaStatusInspecciones(string draw, string start, string length, int pageSize, int skip, DataTableAjaxPostModel model, Inspecciones FiltrarStatusInspeccion, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (model.search != null) ? model.search.value : null;


            BE.SIC_PROGINSPEC entConsultaInspeccion = new BE.SIC_PROGINSPEC(){
            CODTIPOBUSQUEDA          = FiltrarStatusInspeccion.txtTipoBusqueda ,
            TXTNUMSOLI               = FiltrarStatusInspeccion.NroSolicitud ,
            TXTFECHAINSPECCIONINICIO = FiltrarStatusInspeccion.txtFechaInspeccionInicio,
            TXTFECHAINSPECCIONFIN    = FiltrarStatusInspeccion.txtFechaInspeccionFin,
            TXTCODCATASTRAL          = FiltrarStatusInspeccion.CodCatastral 
            };

            IEnumerable<BE.SIC_PROGINSPEC> lisQuery = new BL.SIC_PROGINSPEC().ConsultaStatusInspecciones(entConsultaInspeccion);
            recordsTotal = lisQuery.Count();
            var data = lisQuery.Skip(skip).Take(pageSize).ToList();

            var lisDataQuery = new List<Inspecciones>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new Inspecciones
                {
                    NroInspeccion = item.CODNROINSPEC,
                    NroSolicitud = item.CODNUMESOLI,
                    FechaInspeccion = item.FECINSPE.Value == null ? "" : item.FECINSPE.Value.ToShortDateString(),
                    HoraInspeccion = item.TXTHORAINSP,
                    Inspectores = item.TXTINSPECTORES,
                    Responsable = item.TXTINSRESPONSABLE,
                    CodCatastral = item.TXTCODCATASTRAL,
                    Observacion = item.TXTOBSERVACION,
                    EstadoInspeccion = item.TXTESTADOINSPEC,

                });
            }
            return lisDataQuery;

            
            


        }
    }
}