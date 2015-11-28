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
    
    public partial class Movimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movimiento()
        {
            this.RelPagoMovimientoes = new HashSet<RelPagoMovimiento>();
        }
    
        public int IdMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public string Descripcion { get; set; }
        public int NoPago { get; set; }
        public Nullable<System.DateTime> FecMovimiento { get; set; }
        public Nullable<decimal> Capital { get; set; }
        public Nullable<decimal> Interes { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> SaldoCapital { get; set; }
        public Nullable<decimal> SaldoInteres { get; set; }
        public Nullable<decimal> SaldoIVA { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        public Nullable<System.DateTime> FecUltimoCambio { get; set; }
        public Nullable<int> IdProducto { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelPagoMovimiento> RelPagoMovimientoes { get; set; }
    }
}