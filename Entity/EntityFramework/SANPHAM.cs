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
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.ANHCHITIETs = new HashSet<ANHCHITIET>();
            this.CTDHs = new HashSet<CTDH>();
            this.CUNGSANPHAMs = new HashSet<CUNGSANPHAM>();
            this.LICHSUDANGTINs = new HashSet<LICHSUDANGTIN>();
            this.RATINGs = new HashSet<RATING>();
        }
    
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public Nullable<System.DateTime> NGAYDANG { get; set; }
        public int MAMERCHANT { get; set; }
        public int MATHUONGHIEU { get; set; }
        public int MADOITUONG { get; set; }
        public int MALOAI { get; set; }
        public Nullable<int> TINHTRANG { get; set; }
        public double GIA { get; set; }
        public Nullable<double> GIAGIAM { get; set; }
        public string MOTA { get; set; }
        public string MAUSAC { get; set; }
        public string ANH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANHCHITIET> ANHCHITIETs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUNGSANPHAM> CUNGSANPHAMs { get; set; }
        public virtual DOITUONG DOITUONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUDANGTIN> LICHSUDANGTINs { get; set; }
        public virtual MERCHANT MERCHANT { get; set; }
        public virtual PHANLOAI PHANLOAI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATING> RATINGs { get; set; }
        public virtual THUONGHIEU THUONGHIEU { get; set; }
    }
}
