//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class THUCDON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUCDON()
        {
            this.GOIMONs = new HashSet<GOIMON>();
        }
    
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public float TienNguyenLieu { get; set; }
        public float GiaTien { get; set; }
        public int DaBan { get; set; }
        public int ConLai { get; set; }
        public string anh { get; set; }
        public string PhanLoai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOIMON> GOIMONs { get; set; }
    }
}
