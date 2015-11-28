using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StarGyms.Models
{
    public class CustomPeopleModel
    {
        // Información del registro
        [Required]
        [Display(Name = "Estatus")]
        public int IdEstatus { get; set; }
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime? FechaAlta { get; set; }

        // Información base de la Persona
        [Display(Name="Id Persona")]
        public int IdPersona { get; set; }
        [Required]
        [Display(Name = "Nombre(s) / Razón Social")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApePaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApeMaterno { get; set; }
        [Display(Name = "Tipo de Persona")]
        public int IdTipoPersona { get; set; }
        [Display(Name = "Tipo de Persona")]
        public string TipoPersona { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }
        [Display(Name = "Conocio por")]
        public int IdConocio { get; set; }
        [Display(Name = "Objetivo")]
        public int IdObjetivo { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
                
        // Información Extra de la Persona
        [Display(Name = "RFC")]
        public string RFC { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNac { get; set; }
        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }
        [Display(Name = "MultiClub")]
        public int? Multiclub { get; set; }

        // Domicilio de la Persona
        
    }

    public class PeopleModel
    {
        [Display(Name = "Id Persona")]
        public int IdPersona { get; set; }
        public CustomPeopleModel Persona { get; set; }
        public IEnumerable<Entities.PersonaDireccion> PersonaDirecciones { get; set; }
        public IEnumerable<Entities.PersonaPaquete> PersonaPaquetes { get; set; }
        //private Entities.StartGymDB db = new Entities.StartGymDB();

        public PeopleModel()
        {
            Persona = new CustomPeopleModel();
        }

        public static IEnumerable<CustomPeopleModel> GetCustomSearchPeople(string query, int top = 20)
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            int IdPersonaSearch = 0;
            if (string.IsNullOrEmpty(query))
            {
                return db.Personas
                    .OrderByDescending(m => m.FechaAlta)
                    .Take(top)
                    .Select(m => new CustomPeopleModel { 
                        IdPersona = m.IdPersona, 
                        Nombre = string.Concat(m.NombrePersona, " ", m.ApellidoPaterno, " ", m.ApellidoMaterno), 
                        FechaAlta = m.FechaAlta,
                        TipoPersona = db.CatalogoGens.FirstOrDefault(n => n.IdCatalogo == 8 && n.Id == m.IdTipoPersona).Descripcion,
                        IdEstatus = m.IdEstatusPersona,
                        Estatus = db.CatalogoGens.FirstOrDefault(n => n.IdCatalogo == 2 && n.Id == m.IdEstatusPersona).Descripcion
                    }).AsEnumerable();
            }
            else
            {
                if(int.TryParse(query, out IdPersonaSearch))
                {
                    IList<CustomPeopleModel> l = new List<CustomPeopleModel>();
                    l.Add(GetCustomSinglePeople(IdPersonaSearch));
                    return l;
                }
                else
                {
                    return db.Personas
                    .Where(m => string.Concat(m.NombrePersona, " ", m.ApellidoPaterno, " ", m.ApellidoMaterno).Contains(query) || m.RFC.Contains(query))
                    .OrderByDescending(m => m.FechaAlta)
                    .Take(top)
                    .Select(m => new CustomPeopleModel
                    {
                        IdPersona = m.IdPersona,
                        Nombre = string.Concat(m.NombrePersona, " ", m.ApellidoPaterno, " ", m.ApellidoMaterno),
                        FechaAlta = m.FechaAlta,
                        TipoPersona = db.CatalogoGens.FirstOrDefault(n => n.IdCatalogo == 8 && n.Id == m.IdTipoPersona).Descripcion,
                        IdEstatus = m.IdEstatusPersona,
                        Estatus = db.CatalogoGens.FirstOrDefault(n => n.IdCatalogo == 2 && n.Id == m.IdEstatusPersona).Descripcion
                    }).AsEnumerable();
                }
            }
        }

        public static CustomPeopleModel GetCustomSinglePeople(int IdPersona)
        {
            Entities.StartGymDB db = new Entities.StartGymDB();
            return db.Personas
                .Where(m => m.IdPersona == IdPersona)
                .Select(m => new CustomPeopleModel
                {
                    IdPersona = m.IdPersona,
                    Nombre = m.NombrePersona,
                    ApePaterno = m.ApellidoPaterno,
                    ApeMaterno = m.ApellidoMaterno,
                    IdTipoPersona = m.IdTipoPersona ?? 1,
                    IdGenero = m.IdGenero ?? 0,
                    IdConocio = m.IdConocio,
                    IdObjetivo = m.IdObjetivo,
                    Multiclub = m.Multiclub,
                    FechaAlta = m.FechaAlta,
                    FechaNac = m.FechaNac,
                    IdEstatus = m.IdEstatusPersona,
                    Telefono = string.Empty,
                    Email = m.Email,
                    IdSucursal = m.IdSucursal ?? 1,
                    RFC = m.RFC
                }).FirstOrDefault();
        }

        public bool GetCustomSinglePeople()
        {
            Persona = GetCustomSinglePeople(IdPersona);
            if (Persona != null)
            {
                //PersonaDirecciones = db.PersonaDireccions.Where(m => m.IdPersona == IdPersona).AsEnumerable();
                //PersonaPaquetes = db.PersonaPaquetes.Where(m => m.IdPersona == IdPersona).AsEnumerable();
                return true;
            }
            return false;
        }

        public static bool SaveNew(CustomPeopleModel m)
        {
            return false;
        }
    }
}