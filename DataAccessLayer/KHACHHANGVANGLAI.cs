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
    
    public partial class KHACHHANGVANGLAI
    {
        public int ID { get; set; }
        public string MaKH { get; set; }
    
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
