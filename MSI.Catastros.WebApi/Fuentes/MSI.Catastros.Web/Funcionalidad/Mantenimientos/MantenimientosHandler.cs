using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Distritos;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;
using System.Web.Mvc;

namespace MSI.Catastros.Web.Funcionalidad.Mantenimientos
{
    public class MantenimientosHandler
    {

        public List<TablaViewModel> ListarGridUso(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_USOESPE entQuery = new BE.SIC_USOESPE();
            entQuery.PAGINANUMERO = 1;entQuery.PAGINAREGISTROS = length;
            entQuery.TXTUSOESPE = FiltroMantenimiento.FiltrarNombreUso;entQuery.CODUSOESPE = FiltroMantenimiento.FiltrarCodigoUso;
            entQuery = new BL.SIC_USOESPE().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;entQuery.PAGINAREGISTROS = length;
            entQuery.TXTUSOESPE = FiltroMantenimiento.FiltrarNombreUso; entQuery.CODUSOESPE = FiltroMantenimiento.FiltrarCodigoUso;
            var srcQuery = new BL.SIC_USOESPE().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel { CodigoCampo = s.CODUSOESPE, NombreCampo = s.TXTUSOESPE });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        
        public List<TablaViewModel> CargarGridZonificacion(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_ZONIFICACION entQuery = new BE.SIC_ZONIFICACION();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTZONIFICACION = FiltroMantenimiento.FiltrarNombreZonificacion;
            entQuery.TXTABREVIACION = FiltroMantenimiento.FiltrarAbreviaturaZonificacion;
            entQuery = new BL.SIC_ZONIFICACION().BuscarGrillaZonificacion(entQuery);


            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTZONIFICACION = FiltroMantenimiento.FiltrarNombreZonificacion;
            entQuery.TXTABREVIACION = FiltroMantenimiento.FiltrarAbreviaturaZonificacion;
            var srcQuery = new BL.SIC_ZONIFICACION().BuscarDetalleGrilla(entQuery);


            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel {
                    CodigoCampo = s.CODZONIFICACION,
                    NombreCampo = s.TXTZONIFICACION,
                    AbreviaturaCampo = s.TXTABREVIACION,
                    EstadoCampo = s.ESTADO,
                });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        public List<TablaViewModel> ListarGridInscripcion(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_INSCRIPCION entQuery = new BE.SIC_INSCRIPCION();
            entQuery.PAGINANUMERO = 1;entQuery.PAGINAREGISTROS = length;
            entQuery.TXTINSCRIPCION = FiltroMantenimiento.FiltrarNombreInscripcion;entQuery.CODINSCCATA = FiltroMantenimiento.FiltrarCodigoInscripcion;
            entQuery = new BL.SIC_INSCRIPCION().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;entQuery.PAGINAREGISTROS = length;
            entQuery.TXTINSCRIPCION = FiltroMantenimiento.FiltrarNombreInscripcion; entQuery.CODINSCCATA = FiltroMantenimiento.FiltrarCodigoInscripcion;
            var srcQuery = new BL.SIC_INSCRIPCION().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel { CodigoCampo = s.CODINSCCATA, NombreCampo = s.TXTINSCRIPCION, NombreAdicional = s.TXTIPOANT });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }

        public List<TablaViewModel> ListarGridPuerta(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_PUERTA entQuery = new BE.SIC_PUERTA();
            entQuery.PAGINANUMERO = 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOPUER = FiltroMantenimiento.FiltrarCodigoPuerta; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombrePuerta;
            entQuery = new BL.SIC_PUERTA().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOPUER = FiltroMantenimiento.FiltrarCodigoPuerta; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombrePuerta;
            var srcQuery = new BL.SIC_PUERTA().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel { CodigoCampo = s.CODTIPOPUER, NombreCampo = s.TXTDESCRIPCION , NombreAdicional = s.TXTABREVI });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        public List<TablaViewModel> ListarGridTipoInterior(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_TIPOINTERIOR entQuery = new BE.SIC_TIPOINTERIOR();
            entQuery.PAGINANUMERO = 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOINTE = FiltroMantenimiento.FiltrarCodigoTipoInterior; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombreTipoInterior;
            entQuery = new BL.SIC_TIPOINTERIOR().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOINTE = FiltroMantenimiento.FiltrarCodigoTipoInterior; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombreTipoInterior;
            var srcQuery = new BL.SIC_TIPOINTERIOR().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel { CodigoCampo = s.CODTIPOINTE, NombreCampo = s.TXTDESCRIPCION, NombreAdicional = s.TXTABREVANT });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        public List<TablaViewModel> ListarGridEdificacion(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_EDIFICACION entQuery = new BE.SIC_EDIFICACION();
            entQuery.PAGINANUMERO = 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOEDIF = FiltroMantenimiento.FiltrarCodigoEdificacion; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombreEdificacion;
            entQuery = new BL.SIC_EDIFICACION().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1; entQuery.PAGINAREGISTROS = length;
            entQuery.CODTIPOEDIF = FiltroMantenimiento.FiltrarCodigoEdificacion; entQuery.TXTDESCRIPCION = FiltroMantenimiento.FiltrarNombreEdificacion;
            var srcQuery = new BL.SIC_EDIFICACION().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel { CodigoCampo = s.CODTIPOEDIF, NombreCampo = s.TXTDESCRIPCION, NombreAdicional = s.TXTABREVANT });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        
         public List<TablaViewModel> CargarOtrosDocumentos(DataTableAjaxPostModel model, out int totalResul, MantenimientosViewModel FiltroMantenimiento)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;

            BE.SIC_LOTEOTRODOC entQuery = new BE.SIC_LOTEOTRODOC();
        
            entQuery.PAGINANUMERO = 1; 
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDOCUMENTO = FiltroMantenimiento.FiltrarCodigoOtroDocumento;
            entQuery.TXTDOCUMENTO = FiltroMantenimiento.FiltrarNombreOtroDocumento;

            entQuery = new BL.SIC_LOTEOTRODOC().BuscarCantidadRegistros(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.CODDOCUMENTO = FiltroMantenimiento.FiltrarCodigoOtroDocumento;
            entQuery.TXTDOCUMENTO = FiltroMantenimiento.FiltrarNombreOtroDocumento;

            var srcQuery = new BL.SIC_LOTEOTRODOC().BuscarOtrosDocumentos(entQuery);

            totalResul = entQuery.TOTALREGISTROS ?? default(int);

            var resultado = new List<TablaViewModel>(srcQuery.Count);
            foreach (var s in srcQuery)
            {
                resultado.Add(new TablaViewModel {
                    CodigoCampo = s.CODDOCUMENTO,
                    NombreCampo = s.TXTDOCUMENTO//,
                    //NombreAdicional = s.TXTABREVANT
                });
            }
            return (resultado == null) ? new List<TablaViewModel>() : resultado;
        }
        public RegistroSectorViewModel RecuperarUso(string id)
        {
            #region Obtener datos
            BE.SIC_SECTOR entQuery = new BE.SIC_SECTOR();
            entQuery.CODSECTOR = id;
            BE.SIC_SECTOR query = new BL.SIC_SECTOR().Recuperar(entQuery);
            List<DistritoViewModel> lisDistritos = new DistritosHandler().ListarDistritos("");
            #endregion

            #region Asignar al ViewModel
            var dataQuery = new RegistroSectorViewModel();
            dataQuery.CodigoSector = query.CODSECTOR;
            dataQuery.NombreSector = query.TXTSECTOR;
            dataQuery.CodigoDistrito = query.CODDISTRITO;
            dataQuery.Distritos = lisDistritos;
            #endregion
            return dataQuery;
        }
        public List<SelectListItem> CargarUsoClase()
        {
            ICollection<BE.SIC_USOCLAS> listUso = new BL.SIC_USOCLAS().Listar();
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in listUso.ToList())
            {
                lisDataQuery.Add(new SelectListItem() { Text = item.TXTUSOCLAS, Value = item.CODUSOCLAS });
            }
            return lisDataQuery;
        }

        public TablaViewModel Recuperar(string tipo, string id)
        {
            var dataQuery = new TablaViewModel();
            switch (tipo)
            {
                
                case "UsoPredio":
                    BE.SIC_USOESPE entQueryUso = new BE.SIC_USOESPE(); entQueryUso.CODUSOESPE = id;
                    BE.SIC_USOESPE queryUso = new BL.SIC_USOESPE().Recuperar(entQueryUso);
                    var lisDataQuery = CargarUsoClase();
                    dataQuery.CodigoCampo = queryUso.CODUSOESPE;
                    dataQuery.NombreCampo = queryUso.TXTUSOESPE;
                    dataQuery.ListaCampo = lisDataQuery;
                    dataQuery.CodigoAdicional = queryUso.CODUSOCLAS;
                    break;
                case "Inscripcion":
                    BE.SIC_INSCRIPCION entQuery = new BE.SIC_INSCRIPCION(); entQuery.CODINSCCATA = id;
                    BE.SIC_INSCRIPCION query = new BL.SIC_INSCRIPCION().Recuperar(entQuery);
                    dataQuery.CodigoCampo = query.CODINSCCATA;
                    dataQuery.NombreCampo = query.TXTINSCRIPCION;
                    dataQuery.NombreAdicional = query.TXTIPOANT;
                    break;
                case "Puerta":
                    BE.SIC_PUERTA entQueryPuer = new BE.SIC_PUERTA(); entQueryPuer.CODTIPOPUER = id;
                    BE.SIC_PUERTA queryPuer = new BL.SIC_PUERTA().Recuperar(entQueryPuer);
                    dataQuery.CodigoCampo = queryPuer.CODTIPOPUER;
                    dataQuery.NombreCampo = queryPuer.TXTDESCRIPCION;
                    dataQuery.NombreAdicional = queryPuer.TXTABREVI;
                    break;
                case "TipoInterior":
                    BE.SIC_TIPOINTERIOR entQueryTip = new BE.SIC_TIPOINTERIOR(); entQueryTip.CODTIPOINTE = id;
                    BE.SIC_TIPOINTERIOR queryTip = new BL.SIC_TIPOINTERIOR().Recuperar(entQueryTip);
                    dataQuery.CodigoCampo = queryTip.CODTIPOINTE;
                    dataQuery.NombreCampo = queryTip.TXTDESCRIPCION;
                    dataQuery.NombreAdicional = queryTip.TXTABREVANT;
                    break;
                case "Edificacion":
                    BE.SIC_EDIFICACION entQueryEd = new BE.SIC_EDIFICACION(); entQueryEd.CODTIPOEDIF = id;
                    BE.SIC_EDIFICACION queryEd = new BL.SIC_EDIFICACION().Recuperar(entQueryEd);
                    dataQuery.CodigoCampo = queryEd.CODTIPOEDIF;
                    dataQuery.NombreCampo = queryEd.TXTDESCRIPCION;
                    dataQuery.NombreAdicional = queryEd.TXTABREVANT;
                    break;
                case "OtrosDocumentos":
                    BE.SIC_LOTEOTRODOC entQueryOtroDoc = new BE.SIC_LOTEOTRODOC();
                        entQueryOtroDoc.CODDOCUMENTO = id;
                    BE.SIC_LOTEOTRODOC queryOtroDoc = new BL.SIC_LOTEOTRODOC().RecuperarOtroDocId(entQueryOtroDoc);
                    dataQuery.CodigoCampo = queryOtroDoc.CODDOCUMENTO;
                    dataQuery.NombreCampo = queryOtroDoc.TXTDOCUMENTO;
                    break;
                case "Zonificacion":
                    BE.SIC_ZONIFICACION entQueryZonificacion= new BE.SIC_ZONIFICACION();
                    entQueryZonificacion.CODZONIFICACION = id;
                    BE.SIC_ZONIFICACION queryZonificacion = new BL.SIC_ZONIFICACION().Recuperar(entQueryZonificacion);
                    dataQuery.CodigoCampo = queryZonificacion.CODZONIFICACION;
                    dataQuery.NombreCampo = queryZonificacion.TXTZONIFICACION;
                    dataQuery.AbreviaturaCampo = queryZonificacion.TXTABREVIACION;
                    break;
                default:
                    break;
            }
            return dataQuery;
        }

        public Nullable<bool> ProcesarMantenimientos(TablaViewModel Mantenimiento)
        {
            BE.SIC_RETORNO entSIC_RETORNO = new BE.SIC_RETORNO();
            switch (Mantenimiento.TipoMantenimiento)
            {
                case "UsoPredio":
                    BE.SIC_USOESPE entQueryUso = new BE.SIC_USOESPE()
                    {
                        CODUSOESPE = Mantenimiento.CodigoCampo,
                        TXTUSOESPE = Mantenimiento.NombreCampo,
                        CODUSOCLAS = Mantenimiento.CodigoAdicional,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_USOESPE().Grabar(entQueryUso); break;
                        case 2: entSIC_RETORNO = new BL.SIC_USOESPE().Actualizar(entQueryUso); break;
                        default: entSIC_RETORNO = new BL.SIC_USOESPE().Eliminar(entQueryUso); break;
                    }
                    break;
                case "Inscripcion":
                    BE.SIC_INSCRIPCION entQuery = new BE.SIC_INSCRIPCION()
                    {
                        CODINSCCATA = Mantenimiento.CodigoCampo,
                        TXTINSCRIPCION = Mantenimiento.NombreCampo,
                        TXTIPOANT = Mantenimiento.NombreAdicional,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_INSCRIPCION().Grabar(entQuery); break;
                        case 2: entSIC_RETORNO = new BL.SIC_INSCRIPCION().Actualizar(entQuery); break;
                        default: entSIC_RETORNO = new BL.SIC_INSCRIPCION().Eliminar(entQuery); break;
                    }
                    break;
                case "Puerta":
                    BE.SIC_PUERTA entQueryPuer = new BE.SIC_PUERTA()
                    {
                        CODTIPOPUER = Mantenimiento.CodigoCampo,
                        TXTDESCRIPCION = Mantenimiento.NombreCampo,
                        TXTABREVI = Mantenimiento.NombreAdicional,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_PUERTA().Grabar(entQueryPuer); break;
                        case 2: entSIC_RETORNO = new BL.SIC_PUERTA().Actualizar(entQueryPuer); break;
                        default: entSIC_RETORNO = new BL.SIC_PUERTA().Eliminar(entQueryPuer); break;
                    }
                    break;
                case "TipoInterior":
                    BE.SIC_TIPOINTERIOR entQueryTi = new BE.SIC_TIPOINTERIOR()
                    {
                        CODTIPOINTE = Mantenimiento.CodigoCampo,
                        TXTDESCRIPCION = Mantenimiento.NombreCampo,
                        TXTABREVANT = Mantenimiento.NombreAdicional,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_TIPOINTERIOR().Grabar(entQueryTi); break;
                        case 2: entSIC_RETORNO = new BL.SIC_TIPOINTERIOR().Actualizar(entQueryTi); break;
                        default: entSIC_RETORNO = new BL.SIC_TIPOINTERIOR().Eliminar(entQueryTi); break;
                    }
                    break;
                case "Edificacion":
                    BE.SIC_EDIFICACION entQueryEd = new BE.SIC_EDIFICACION()
                    {
                        CODTIPOEDIF = Mantenimiento.CodigoCampo,
                        TXTDESCRIPCION = Mantenimiento.NombreCampo,
                        TXTABREVANT = Mantenimiento.NombreAdicional,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_EDIFICACION().Grabar(entQueryEd); break;
                        case 2: entSIC_RETORNO = new BL.SIC_EDIFICACION().Actualizar(entQueryEd); break;
                        default: entSIC_RETORNO = new BL.SIC_EDIFICACION().Eliminar(entQueryEd); break;
                    }
                    break;
                case "OtrosDocumentos":
                    BE.SIC_LOTEOTRODOC entQueryOtroDoc = new BE.SIC_LOTEOTRODOC()
                    {
                        CODDOCUMENTO = Mantenimiento.CodigoCampo,
                        TXTDOCUMENTO = Mantenimiento.NombreCampo,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().GrabarTipoOtroDocumentos(entQueryOtroDoc); break;
                        case 2: entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().ActualizarTipoOtroDocumentos(entQueryOtroDoc); break;
                        default: entSIC_RETORNO = new BL.SIC_LOTEOTRODOC().EliminarTipoOtroDocumentos(entQueryOtroDoc); break;
                    }
                    break;
                case "Zonificacion":
                    BE.SIC_ZONIFICACION entQueryZoni = new BE.SIC_ZONIFICACION()
                    {
                        CODZONIFICACION = Mantenimiento.CodigoCampo,
                        TXTZONIFICACION = Mantenimiento.NombreCampo,
                        TXTABREVIACION = Mantenimiento.AbreviaturaCampo,
                        CODUSUARIO = VariablesWeb.IdUsuarioIntento,
                    };
                    switch (Mantenimiento.Estado)
                    {
                        case 1: entSIC_RETORNO = new BL.SIC_ZONIFICACION().Grabar(entQueryZoni); break;
                        case 2: entSIC_RETORNO = new BL.SIC_ZONIFICACION().Actualizar(entQueryZoni); break;
                        default: entSIC_RETORNO = new BL.SIC_ZONIFICACION().Eliminar(entQueryZoni); break;
                    }
                    break;
                default: break;
            }
            return entSIC_RETORNO.Ok;

        }
    }
}