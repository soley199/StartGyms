using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StarGyms.Models
{
    public class AccountModel
    {
        [Key]
        [Display(Name="Id Usuario")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Nombre de Usuario Requerido")]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Contraseña Requerida")]
        [Display(Name = "Contraseña")]
        public string UserPass { get; set; }

        public Entities.Usuario Usuario { get; set; }
        private Entities.StartGymDB db { get; set; }

        public AccountModel()
        {
            db = new Entities.StartGymDB();
        }
        
        public bool GetAccount()
        {
            Usuario = db.Usuarios.SingleOrDefault(m => m.UserName == UserName && m.UserPass == UserPass);
            if(Usuario != null)
            {
                return true;
            }
            return false;
        }

        public bool SetAccountPwd()
        {
            return false;
        }
    }
}