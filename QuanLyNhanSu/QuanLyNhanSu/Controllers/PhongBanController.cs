using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Controllers
{
    public class PhongBanController : Controller
    {
        private MyDbContext _context;
        public PhongBanController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.PhongBan.ToList());
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