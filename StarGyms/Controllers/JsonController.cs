using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarGyms.Models;

namespace StarGyms.Controllers
{
    public class JsonController : Controller
    {
        public JsonResult ClienteAutoComplete(string buscar, int? items)
        {
            JsonModel js = new JsonModel();
            return Json(js.jBuscarCliente(buscar, items), JsonRequestBehavior.AllowGet);
        }
    }
}