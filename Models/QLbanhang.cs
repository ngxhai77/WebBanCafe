using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quanlycafe.Models
{
    public partial class QLbanhang : DbContext
    {
        public QLbanhang()
            : base("name=QLbanhang")
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Donhang> Donhang { get; set; }
        public virtual DbSet<Loaihang> Loaihang { get; set; }
        public virtual DbSet<Nguoidung> Nguoidung { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Chitiethoadon>()
                .Property(e => e.Thanhtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donhang>()
                .Property(e => e.Tongtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donhang>()
                .HasMany(e => e.Chitiethoadon)
                .WithRequired(e => e.Donhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loaihang>()
                .Property(e => e.Tenhang)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Anhdaidien)
                .IsFixedLength();

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giatien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Chitiethoadon)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);
        }
    }
}
