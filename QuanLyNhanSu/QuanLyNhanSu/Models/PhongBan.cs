using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuanLyNhanSu.Models
{
    public class PhongBan
    {
        public int Id {get;set;}
        public string MaPB { get; set; }
        public string TenPB { get; set; }

        public ICollection<NhanVien> NhanVien { get; set; }
        public ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
