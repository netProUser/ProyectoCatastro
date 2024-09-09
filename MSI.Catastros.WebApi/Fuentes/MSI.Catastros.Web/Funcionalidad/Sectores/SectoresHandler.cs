using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL = MSI.Catastros.BusinessLogic;
using BE = MSI.Catastros.BusinessEntities;
using MSI.Catastros.Web.Funcionalidad.Distritos;
using MSI.Catastros.Web.Funcionalidad.Paginacion;
using MSI.Catastros.Utiles;

namespace MSI.Catastros.Web.Funcionalidad.Sectores
{
    public class SectoresHandler
    {

        public List<SectorViewModel> ListarGrid(DataTableAjaxPostModel model, out int totalResul, FiltrarSectoresViewModel FiltroSectores)
        {
            var length = (model.length == 0) ? 1 : model.length;
            var skip = model.start;
            string ordenar = "CODSECTOR";
            var listQuery = BuscarDB(length, skip, ordenar, out totalResul, FiltroSectores);            
            var resultado = new List<SectorViewModel>(listQuery.Count);
            foreach (var s in listQuery)
            {
                resultado.Add(new SectorViewModel { CodigoSector = s.CODSECTOR, NombreSector = s.TXTSECTOR, CodigoDistritos = s.CODDISTRITO });
            }
            return (resultado == null) ? new List<SectorViewModel>() : resultado;
        }
        public ICollection<BE.SIC_SECTOR> BuscarDB(int length, int skip, string sortBy, out int totalResul, FiltrarSectoresViewModel FiltroSectores)
        {
            BE.SIC_SECTOR entQuery = new BE.SIC_SECTOR();
            entQuery.PAGINANUMERO = 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTSECTOR = FiltroSectores.NombreSector;
            entQuery.CODDEPARTAMENTO = Convert.ToInt16(EnumUbigeoSI.Departamento).ToString().PadLeft(2, '0');
            entQuery.CODPROVINCIA = Convert.ToInt16(EnumUbigeoSI.Provincia).ToString().PadLeft(2, '0');
            entQuery.CODDISTRITO = Convert.ToInt16(EnumUbigeoSI.Distrito).ToString().PadLeft(2, '0');
            entQuery = new BL.SIC_SECTOR().BuscarInt(entQuery);

            entQuery.PAGINANUMERO = (skip / length == 0) ? 1 : (skip / length) + 1;
            entQuery.PAGINAREGISTROS = length;
            entQuery.TXTSECTOR = FiltroSectores.NombreSector;
            var srcQuery = new BL.SIC_SECTOR().Buscar(entQuery);
            totalResul = entQuery.TOTALREGISTROS ?? default(int);
            return srcQuery;
        }

        public List<SectorViewModel> RecargarGrid(
                string draw,
                string start,
                string length,
                int pageSize,
                int skip,
                DataTableAjaxPostModel FilterHabil,
                FiltrarSectoresViewModel Sectores, out int recordsTotal)
        {
            recordsTotal = 0;
            var searchBy = (FilterHabil.search != null) ? FilterHabil.search.value : null;
            #region Obtener datos
            BE.SIC_SECTOR entQuery = new BE.SIC_SECTOR()
            {
                TXTSECTOR = Sectores.NombreSector,
                CODDISTRITO = Sectores.CodigoDistrito
            };

            var srcQuery = new BL.SIC_SECTOR().Listar(entQuery);
            #endregion

            recordsTotal = srcQuery.Count();
            var data = srcQuery.Skip(skip).Take(pageSize).ToList();
            var lisDataQuery = new List<SectorViewModel>();
            foreach (var item in data)
            {
                lisDataQuery.Add(new SectorViewModel
                {
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    CodigoDistritos = item.CODDISTRITO,
                });
            }
            return lisDataQuery;
        }
        public List<SectorViewModel> ListarSectores(FiltrarSectoresViewModel FiltrarSectores)
        {
            #region Obtener datos

            BE.SIC_SECTOR entQuery = new BE.SIC_SECTOR();
            entQuery.TXTSECTOR = FiltrarSectores.NombreSector;
            entQuery.CODDISTRITO = FiltrarSectores.CodigoDistrito;
            IEnumerable<BE.SIC_SECTOR> lisQuery = new BL.SIC_SECTOR().Listar(entQuery);
            List<DistritoViewModel> lisDistritos = new DistritosHandler().ListarDistritos("");
            #endregion

            #region Asignar al ViewModel
            var lisDataQuery = new List<SectorViewModel>();
            foreach (var item in lisQuery)
            {
                lisDataQuery.Add(new SectorViewModel
                {
                    CodigoSector = item.CODSECTOR,
                    NombreSector = item.TXTSECTOR,
                    CodigoDistritos = item.CODDISTRITO,
                    //NombreTipoHabilitacion = item.TXTHABILITAURBA,
                    Distritos = lisDistritos

                });
            }
            #endregion
            return lisDataQuery;
        }
        public RegistroSectorViewModel BuscarSectores(string id)
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

        public Nullable<bool> ProcesarSectores(RegistroSectorViewModel Sectores)
        {
            #region Asignar a la Entidad
            BE.SIC_SECTOR entQuery = new BE.SIC_SECTOR()
            {
                CODSECTOR = Sectores.CodigoSector,
                TXTSECTOR = Sectores.NombreSector,
                CODDEPARTAMENTO = "15",
                CODPROVINCIA = "01",
                CODDISTRITO = Sectores.CodigoDistrito,
                CODUSUARIO = VariablesWeb.IdUsuarioIntento,
            };
            #endregion

            #region Grabar, Actualizar, Eliminar
            BE.SIC_RETORNO entSIC_RETORNO;
            switch (Sectores.Estado)
            {
                case 1: entSIC_RETORNO = new BL.SIC_SECTOR().Grabar(entQuery); break;
                case 2: entSIC_RETORNO = new BL.SIC_SECTOR().Actualizar(entQuery); break;
                default: entSIC_RETORNO = new BL.SIC_SECTOR().Eliminar(entQuery); break;
            }
            #endregion
            return entSIC_RETORNO.Ok;

        }
    }
}