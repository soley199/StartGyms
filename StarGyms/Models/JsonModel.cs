using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;


namespace StarGyms.Models
{
    public class JsonModel
    {
        public object jBuscarCliente(string Buscar, int? items)
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            IEnumerable<CustomPeopleModel> r = PeopleModel.GetCustomSearchPeople(Buscar.Trim());
            if (r != null && r.Count()>0)
            {
                return r.Select(m => new { IdPersona = m.IdPersona, Persona = string.Concat(m.Nombre, " ", m.ApePaterno, " ", m.ApeMaterno, m.RFC.Trim()) }).ToList();
            }
            return null;
        }
    }
}
