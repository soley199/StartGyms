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
    
    public partial class Pago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pago()
        {
            this.RelPagoMovimientoes = new HashSet<RelPagoMovimiento>();
        }
    
        public int IdPago { get; set; }
        public int IdTipoPago { get; set; }
        public int IdCuentaBancaria { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<System.DateTime> FecPagoRegistro { get; set; }
        public Nullable<System.DateTime> FecPagoValor { get; set; }
        public Nullable<decimal> MontoPago { get; set; }
        public Nullable<decimal> MontoPagoAplicado { get; set; }
        public Nullable<decimal> SaldoPago { get; set; }
        public Nullable<bool> Suspenso { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public Nullable<System.DateTime> FecUltimoCambio { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelPagoMovimiento> RelPagoMovimientoes { get; set; }
    }
}
