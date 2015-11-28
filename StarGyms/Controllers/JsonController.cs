using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarGyms.Models;

namespace StarGyms.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            SearchModel m = new SearchModel
            {
                Action = "Search",
                Controller = "People",
                Model = PeopleModel.GetCustomSearchPeople(string.Empty, 20),
                Persona = new CustomPeopleModel()
            };
            return View(m);
        }

        [HttpPost]
        public ActionResult Search(SearchModel m)
        {
            IEnumerable<CustomPeopleModel> r = PeopleModel.GetCustomSearchPeople(m.Buscar.Trim());
            if (r != null && r.Count() == 1)
            {
                return PartialView("_PeopleEdit", new PeopleModel{ IdPersona = r.First().IdPersona, Persona = r.First()});
            }
            else if (r != null && r.Count() > 1)
            {
                return PartialView("_PeopleList", r);
            }
            return PartialView("_PeopleList", new List<CustomPeopleModel>());
        }

        public ActionResult Add()
        {
            return View( new PeopleModel());
        }

        public ActionResult Edit(int id)
        {
            PeopleModel m = new PeopleModel{ IdPersona = id };
            if (id != 0)
            {
                m.GetCustomSinglePeople();
            }
            return PartialView("_PeopleEdit",m);
        }

        [HttpPost]
        public ActionResult Save(CustomPeopleModel m)
        {
            if(ModelState.IsValid)
            {
                PeopleModel.SaveNew(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View("_PeopleEdit", m);
            }
        }
    }
}