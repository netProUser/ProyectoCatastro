using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Web.Funcionalidad.Lotes;
using MSI.Catastros.Utiles;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MSI.Catastros.Web.Funcionalidad.MantInformes
{
    public class MantInformesHandler
    {
        public Nullable<bool> GrabarNuevoMantCarta(InformesConfigViewModel Informe)
        {
            BE.SIC_CARTACONFI entQuery = new BE.SIC_CARTACONFI()
            {
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
            };
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CARTACONFI().Grabar(entQuery);
            return entSIC_RETORNO.Ok;
        }
        public Nullable<bool> GrabarMantCarta(InformesConfigViewModel Informe)
        {
            BE.SIC_CARTACONFI entQuery = new BE.SIC_CARTACONFI()
            {
                CODCARTA = Informe.FiltrarCodigoCarta,
                CODTIPOINFOR = Informe.FiltrarCodigoTipoInforme,
            };
            BE.SIC_CARTACONFI srcQuery = new BL.SIC_CARTACONFI().Recuperar(entQuery);
            srcQuery.CODOOFICINA = Informe.CodigoOficina;
            srcQuery.TXTTITULOGENERAL = Informe.TituloGeneral;
            srcQuery.TXTCONFSUBTITULO1 = Informe.ConfSubtitulo1; srcQuery.TXTCONFSUBTITULO2 = Informe.ConfSubtitulo2;
            srcQuery.TXTCONFSUBTITULO3 = Informe.ConfSubtitulo3;
            srcQuery.TXTCONFSUBTITULO4 = Informe.ConfSubtitulo4;
            srcQuery.TXTCONFSUBTITULO5 = Informe.ConfSubtitulo5; srcQuery.TXTCONFSUBTITULO6 = Informe.ConfSubtitulo6;
            srcQuery.TXTCONFSUBTITULO7 = Informe.ConfSubtitulo7;
            srcQuery.TXTCONFPARRAFO1 = Informe.ConfParrafo1; srcQuery.TXTCONFPARRAFO2 = Informe.ConfParrafo2; srcQuery.TXTCONFPARRAFO3 = Informe.ConfParrafo3;
            srcQuery.TXTCONFPARRAFO4 = Informe.ConfParrafo4; srcQuery.TXTCONFPARRAFO5 = Informe.ConfParrafo5; srcQuery.TXTCONFPARRAFO6 = Informe.ConfParrafo6;
            srcQuery.TXTCONFPARRAFO7 = Informe.ConfParrafo7; srcQuery.TXTCONFPARRAFO8 = Informe.ConfParrafo8; srcQuery.TXTCONFPARRAFO9 = Informe.ConfParrafo9;
            srcQuery.TXTCONFPARRAFO10 = Informe.ConfParrafo10;

            srcQuery.TXTCONFFIRMA1 = Informe.ConfFirma1; srcQuery.TXTCONFFIRMA2 = Informe.ConfFirma2; srcQuery.TXTCONFFIRMA3 = Informe.ConfFirma3;
            srcQuery.TXTCONFFIRMA4 = Informe.ConfFirma4; srcQuery.TXTCONFFIRMA5 = Informe.ConfFirma5;

            srcQuery.TXTCONFPIEPAGINA = Informe.ConfPiePagina;
            srcQuery.TXTANIO = Informe.NombreAnio;
            BE.SIC_RETORNO entSIC_RETORNO = new BL.SIC_CARTACONFI().Actualizar(srcQuery);
            return entSIC_RETORNO.Ok;
        }
        public InformesConfigViewModel RecuperarMantCarta(InformesConfigViewModel FiltrarInformes, out bool resul)
        {
            BE.SIC_CARTACONFI entQuery = new BE.SIC_CARTACONFI()
            {
                CODTIPOINFOR = FiltrarInformes.FiltrarCodigoTipoInforme,
                CODCARTA = FiltrarInformes.FiltrarCodigoCarta
            };
            BE.SIC_CARTACONFI srcQuery = new BL.SIC_CARTACONFI().Recuperar(entQuery);
            InformesConfigViewModel lisDataQuery = new InformesConfigViewModel();
            if (srcQuery != null)
            {
            lisDataQuery.TituloGeneral = srcQuery.TXTTITULOGENERAL;
            lisDataQuery.CodigoOficina = srcQuery.CODOOFICINA;
            lisDataQuery.ConfSubtitulo1 = srcQuery.TXTCONFSUBTITULO1; lisDataQuery.ConfSubtitulo2 = srcQuery.TXTCONFSUBTITULO2;
            lisDataQuery.ConfSubtitulo3 = srcQuery.TXTCONFSUBTITULO3; lisDataQuery.ConfSubtitulo4 = srcQuery.TXTCONFSUBTITULO4;
            lisDataQuery.ConfSubtitulo5 = srcQuery.TXTCONFSUBTITULO5; lisDataQuery.ConfSubtitulo6 = srcQuery.TXTCONFSUBTITULO6;
            lisDataQuery.ConfSubtitulo7 = srcQuery.TXTCONFSUBTITULO7;
            lisDataQuery.ConfParrafo1 = srcQuery.TXTCONFPARRAFO1; lisDataQuery.ConfParrafo2 = srcQuery.TXTCONFPARRAFO2;
            lisDataQuery.ConfParrafo3 = srcQuery.TXTCONFPARRAFO3; lisDataQuery.ConfParrafo4 = srcQuery.TXTCONFPARRAFO4;
            lisDataQuery.ConfParrafo5 = srcQuery.TXTCONFPARRAFO5; lisDataQuery.ConfParrafo6 = srcQuery.TXTCONFPARRAFO6;
            lisDataQuery.ConfParrafo7 = srcQuery.TXTCONFPARRAFO7; lisDataQuery.ConfParrafo8 = srcQuery.TXTCONFPARRAFO8;
            lisDataQuery.ConfParrafo9 = srcQuery.TXTCONFPARRAFO9; lisDataQuery.ConfParrafo10 = srcQuery.TXTCONFPARRAFO10;
            lisDataQuery.ConfFirma1 = srcQuery.TXTCONFFIRMA1; lisDataQuery.ConfFirma2 = srcQuery.TXTCONFFIRMA2;
            lisDataQuery.ConfFirma3 = srcQuery.TXTCONFFIRMA3; lisDataQuery.ConfFirma4 = srcQuery.TXTCONFFIRMA4;
            lisDataQuery.ConfFirma5 = srcQuery.TXTCONFFIRMA5;
            lisDataQuery.ConfPiePagina = srcQuery.TXTCONFPIEPAGINA;
            lisDataQuery.NombreAnio = srcQuery.TXTANIO;
            resul = true;
            } else {
                resul = false;
            }
            return lisDataQuery;
        }
        public List<SelectListItem> ListarCodigoCartas(InformesConfigViewModel CartasConfig)
        {
            BE.SIC_CARTACONFI entQuery = new BE.SIC_CARTACONFI() { CODTIPOINFOR = CartasConfig.FiltrarCodigoTipoInforme};
            IEnumerable<BE.SIC_CARTACONFI> lisQuery = new BL.SIC_CARTACONFI().Buscar(entQuery);
            var lisDataQuery = new List<SelectListItem>();
            foreach (var item in lisQuery) { lisDataQuery.Add(new SelectListItem { Value = item.CODCARTA, Text = item.CODCARTA }); }
            return lisDataQuery;
        }

        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}