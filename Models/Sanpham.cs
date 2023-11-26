namespace Quanlycafe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
            Anhbia = "~/Images/files/avt2.jpg";
        }

        [Key]
        
        public int Masp { get; set; }

        [StringLength(50)]
        public string Tensp { get; set; }

        public decimal? Giatien { get; set; }

        public int? Soluong { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(50)]
        public string Anhbia { get; set; }

        public int? Mahang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiethoadon> Chitiethoadon { get; set; }

        public virtual Loaihang Loaihang { get; set; }
    }
}
