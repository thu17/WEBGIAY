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
    
    public partial class CTDH
    {
        public int MADH { get; set; }
        public int MASP { get; set; }
        public int MAMERCHANT { get; set; }
        public int SOLUONG { get; set; }
        public Nullable<double> THANHTIEN { get; set; }
        public Nullable<int> TINHTRANG { get; set; }
        public int MAKICHCO { get; set; }
        public Nullable<double> GIAGIAM { get; set; }
    
        public virtual DONHANG DONHANG { get; set; }
        public virtual KICHCO KICHCO { get; set; }
        public virtual MERCHANT MERCHANT { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
