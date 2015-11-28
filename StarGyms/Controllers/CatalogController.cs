using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StarGyms.Models
{
    public class CustomCatalogModel
    {
        [Display(Name = "Catalogo")]
        public int IdCatalogo { get; set; }
        [Display(Name = "Elemento")]
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Seleccionado")]
        public bool Default1 { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
    }

    public class CatalogModel
    {
        public int IdCatalogo { get; set; }
        public IEnumerable<CustomCatalogModel> CatalogosTitulo { get; set; }
        public IEnumerable<CustomCatalogModel> Catalogos { get; set; }

        public static IEnumerable<CustomCatalogModel> CatGeneral(int IdCatalog)
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            if (IdCatalog == 0)
            {
                return db.CatalogoGens.OrderBy(m => m.IdCatalogo).OrderBy(m => m.Id).Select(m => new CustomCatalogModel { IdCatalogo = m.IdCatalogo, Id = m.Id, Descripcion = m.Descripcion, Activo = m.Activo, Default1 = m.Default1 }).AsEnumerable();
            }
            else
            {
                return db.CatalogoGens.Where(m => m.IdCatalogo == IdCatalog && m.Activo == true).OrderBy(m => m.Descripcion).Select(m => new CustomCatalogModel { IdCatalogo = m.IdCatalogo, Id = m.Id, Descripcion = m.Descripcion, Activo = m.Activo, Default1 = m.Default1 }).AsEnumerable();
            }
        }

        public static IEnumerable<CustomCatalogModel> CatGeneralTitle(bool OnlyActive)
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            if (OnlyActive)
            {
                return db.CatalogoGens.Where(m => m.Id == 0 && m.Activo == true).OrderBy(m => m.Descripcion).Select(m => new CustomCatalogModel { IdCatalogo = m.IdCatalogo, Id = m.Id, Descripcion = m.Descripcion, Activo = m.Activo, Default1 = m.Default1 }).AsEnumerable();
            }
            else
            {
                return db.CatalogoGens.Where(m => m.Id == 0).OrderBy(m => m.Descripcion).Select(m => new CustomCatalogModel { IdCatalogo = m.IdCatalogo, Id = m.Id, Descripcion = m.Descripcion, Activo = m.Activo, Default1 = m.Default1 }).AsEnumerable();
            }

        }

        public static IEnumerable<Entities.Sucursale> Sucursales()
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            return db.Sucursales.OrderBy(m => m.Nombre).AsEnumerable();
        }

    }
}