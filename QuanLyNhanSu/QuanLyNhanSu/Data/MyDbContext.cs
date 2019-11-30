using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanSu.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options){ }
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<ChamCong> ChamCong { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
    }
}
