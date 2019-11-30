using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string MaNV { get; set; }

        // Khóa ngoại cho mã phòng ban
        public string MaPB { get; set; }
        public PhongBan PhongBan { get; set; }

        public string TenNV { get; set; }
        public int Luong { get; set; }
    }
}
