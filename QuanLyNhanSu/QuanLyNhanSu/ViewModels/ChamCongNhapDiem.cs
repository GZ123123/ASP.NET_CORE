using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.ViewModels
{
    public class ChamCongNhapDiem
    {
        public ChamCong ChamCong {get;set;}
        public IEnumerable<NhanVien> NhanVien {get;set;}
    }
}