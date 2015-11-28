using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarGyms.Models;

namespace StarGyms.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult CatGeneral()
        {
            CatalogModel m = new CatalogModel();
            m.CatalogosTitulo = CatalogModel.CatGeneralTitle(false);
            m.Catalogos = CatalogModel.CatGeneral(0);
            return View(m);
        }
    }
}