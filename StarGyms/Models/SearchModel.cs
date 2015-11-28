using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StarGyms.Models
{
    public class SearchModel
    {
        [Display(Name = "Buscar Por...")]
        public string Buscar { get; set; }
        public CustomPeopleModel Persona { get; set; }
        public string AutoCompleteJson { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public object Model { get; set; }
        public string UrlAutoComplete { get; set; }
    }
}