using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Controllers
{
    public class NhanSuController : Controller
    {
        private MyDbContext _context;
        public NhanSuController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.NhanVien.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }
    }
}