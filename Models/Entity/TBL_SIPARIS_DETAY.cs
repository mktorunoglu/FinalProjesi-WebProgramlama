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
    
    public partial class TBL_SIPARIS_DETAY
    {
        public int SIPARIS_DETAY_ID { get; set; }
        public Nullable<int> SIPARIS_ID { get; set; }
        public Nullable<int> URUN_ID { get; set; }
        public Nullable<int> URUN_ADET { get; set; }
        public Nullable<int> ALIS_FIYAT { get; set; }
        public Nullable<int> TUTAR { get; set; }
        public Nullable<int> TEMIN_SURESI { get; set; }
        public Nullable<int> FIRMA_ID { get; set; }
    
        public virtual TBL_FIRMA TBL_FIRMA { get; set; }
        public virtual TBL_SIPARIS TBL_SIPARIS { get; set; }
        public virtual TBL_URUN TBL_URUN { get; set; }
    }
}
