//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class KICHCO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KICHCO()
        {
            this.SANPHAMs = new HashSet<SANPHAM>();
        }
    
        public int MAKICHCO { get; set; }
        public int MADOITUONG { get; set; }
        public decimal KICHCO1 { get; set; }
    
        public virtual DOITUONG DOITUONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
