//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LSYS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_HAMMADDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_HAMMADDE()
        {
            this.TBL_K_HAMMADELER = new HashSet<TBL_K_HAMMADELER>();
        }
    
        public int HAMMADDE_ID { get; set; }
        public string HAMMADDE_ADI { get; set; }
        public Nullable<int> STOK_ADEDI { get; set; }
        public Nullable<int> STOK_ESIK_DEGERI { get; set; }
        public Nullable<int> TEMIN_SURESI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_K_HAMMADELER> TBL_K_HAMMADELER { get; set; }
    }
}