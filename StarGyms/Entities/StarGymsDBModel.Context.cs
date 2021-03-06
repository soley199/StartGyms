﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StartGymDB : DbContext
    {
        public StartGymDB()
            : base("name=StartGymDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<CAT_Perfil> CAT_Perfil { get; set; }
        public virtual DbSet<CAT_Producto> CAT_Producto { get; set; }
        public virtual DbSet<Contacto> Contactoes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPerfil> MenuPerfils { get; set; }
        public virtual DbSet<Movimiento> Movimientoes { get; set; }
        public virtual DbSet<Pago> Pagoes { get; set; }
        public virtual DbSet<Paquete> Paquetes { get; set; }
        public virtual DbSet<Parametro> Parametroes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<RelPagoMovimiento> RelPagoMovimientoes { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimientoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<CalendarioPago> CalendarioPagos { get; set; }
        public virtual DbSet<CatalogoGen> CatalogoGens { get; set; }
        public virtual DbSet<Consecutivo> Consecutivoes { get; set; }
        public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }
        public virtual DbSet<PersonaPaquete> PersonaPaquetes { get; set; }
        public virtual DbSet<RelGrupoFamiliar> RelGrupoFamiliars { get; set; }
        public virtual DbSet<RelGrupoPersona> RelGrupoPersonas { get; set; }
        public virtual DbSet<Telefono> Telefonoes { get; set; }
    }
}
