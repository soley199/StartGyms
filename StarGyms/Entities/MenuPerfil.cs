//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarGyms.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuPerfil
    {
        public int IdMenuRol { get; set; }
        public Nullable<int> IdMenu { get; set; }
        public Nullable<int> IdPerfil { get; set; }
    
        public virtual CAT_Perfil CAT_Perfil { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
