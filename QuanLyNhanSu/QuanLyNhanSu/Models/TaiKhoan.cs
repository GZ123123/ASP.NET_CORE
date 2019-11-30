using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuanLyNhanSu.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }


        public string MaPB { get; set; }
        public PhongBan PhongBan { get; set; }
    }
}
