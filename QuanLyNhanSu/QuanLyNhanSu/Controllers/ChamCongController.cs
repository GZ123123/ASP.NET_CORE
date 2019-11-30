using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.ViewModels;

namespace QuanLyNhanSu.Controllers
{
    public class ChamCongController : Controller
    {
        private MyDbContext context;
        public ChamCongController(MyDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View(
                new ChamCongIndex()
                { 
                    ChamCong = context.ChamCong.ToList(),
                    NhanVien = context.NhanVien.ToList()
                }
            );
        }

        public IActionResult MonthsIndex()
        {
            return View(
                new ChamCongIndex()
                { 
                    ChamCong = context.ChamCong.ToList(),
                    NhanVien = context.NhanVien.ToList()
                }
            );
        }

        public IActionResult NhapDiem()
        {
            return View(
                new ChamCongNhapDiem()
                {
                    ChamCong = new ChamCong(),
                    NhanVien = context.NhanVien.OrderBy(nv => nv.TenNV).ToList()
                }
            );
        }

        [HttpPost]
        public IActionResult NhapDiem(ChamCongNhapDiem vm)
        {
            if (ModelState.IsValid)
            {
                context.ChamCong.Add(vm.ChamCong);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {   
                return View(
                    new ChamCongNhapDiem()
                    {
                        ChamCong = vm.ChamCong,
                        NhanVien = context.NhanVien.OrderBy(nv => nv.TenNV).ToList()
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult SuaDiem(int id)
        {
            ChamCong edit = context.ChamCong.Where(c => c.Id == id).FirstOrDefault();
            if (edit != null)
            {
                return View(
                    new ChamCongSuaDiem()
                    {
                        ChamCong = edit,
                        TenNhanVien = context.NhanVien.Where(nv => nv.MaNV == edit.MaNV).FirstOrDefault().TenNV
                    }
                );
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SuaDiem(ChamCongSuaDiem vm)
        {
            if (ModelState.IsValid)
            {
                ChamCong up = context.ChamCong.Where(c => c.Id == vm.ChamCong.Id).FirstOrDefault();
                up.DiemNhanVien = vm.ChamCong.DiemNhanVien;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(
                    new ChamCongSuaDiem()
                    {
                        ChamCong = vm.ChamCong,
                        TenNhanVien = context.NhanVien.Where(nv => nv.MaNV == vm.ChamCong.MaNV).FirstOrDefault().TenNV
                    }
                );
            }
        }

        [HttpGet]
        public IActionResult XoaChamCong(int id)
        {
            ChamCong delete = context.ChamCong.Where(c => c.Id == id).FirstOrDefault();
            if (delete != null)
            {
                context.ChamCong.Remove(delete);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
