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
    
    public partial class TipoMovimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMovimiento()
        {
            this.Movimientoes = new HashSet<Movimiento>();
        }
    
        public int IdTipoMovimiento { get; set; }
        public string TipoMovimiento1 { get; set; }
        public string ClaveTipoMovimiento { get; set; }
        public Nullable<bool> GeneraIVACapital { get; set; }
        public Nullable<bool> GeneraMora { get; set; }
        public Nullable<bool> Capturable { get; set; }
        public Nullable<bool> EsRenta { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public Nullable<decimal> Orden { get; set; }
        public Nullable<bool> GeneraIVAInteres { get; set; }
        public Nullable<int> IdTipoGeneracionComprobante { get; set; }
        public Nullable<bool> SeparaComprobante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimiento> Movimientoes { get; set; }
    }
}