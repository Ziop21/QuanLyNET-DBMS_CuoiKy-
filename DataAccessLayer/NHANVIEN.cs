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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.QUANLYCONGVIECs = new HashSet<QUANLYCONGVIEC>();
        }
    
        public string MaNV { get; set; }
        public string MaLuong { get; set; }
        public string MaCV { get; set; }
        public string MaTK { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SDT { get; set; }
        public string TrinhDoVH { get; set; }
        public string TrinhDoHV { get; set; }
        public int SoNamKN { get; set; }
    
        public virtual BANGLUONG BANGLUONG { get; set; }
        public virtual CONGVIEC CONGVIEC { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUANLYCONGVIEC> QUANLYCONGVIECs { get; set; }
    }
}
