//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLGO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CTDONDATHANGs = new HashSet<CTDONDATHANG>();
            this.CTHOADONs = new HashSet<CTHOADON>();
            this.CTNHAPKHOes = new HashSet<CTNHAPKHO>();
        }
    
        public string IDSP { get; set; }
        public int SLKho { get; set; }
        public int SLQuay { get; set; }
        public decimal GiaBan { get; set; }
        public string HinhanhSP { get; set; }
        public string IDLSP { get; set; }
        public string IDDVT { get; set; }
        public string TenSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONDATHANG> CTDONDATHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADON> CTHOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNHAPKHO> CTNHAPKHOes { get; set; }
        public virtual DONVITINH DONVITINH { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
    }
}
