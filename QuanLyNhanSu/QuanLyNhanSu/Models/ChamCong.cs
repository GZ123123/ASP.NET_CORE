using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class ChamCong
    {
        public int Id { get; set; }
        public DateTime NgayLamViec { get; set; }
        public int DiemNhanVien { get; set; }

        public string MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
