using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class PhongBanController : Controller
    {
        private MyDbContext _context;
        public PhongBanController(MyDbContext context)
        {
            _context = context;
        }
        static List<PhongBan> PhongBans = new List<PhongBan>();
        public IActionResult Index()
        {
            return View(_context.PhongBan.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View( _context.PhongBan.Where(p => p.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Create(PhongBan pb)
        {
            _context.Add(pb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       [HttpPost]
        public IActionResult Edit(int id,PhongBan model)
        {
            var pb = PhongBans.SingleOrDefault(p => p.Id == id);
            if (pb != null)
            {
                pb.TenPB = model.TenPB;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            PhongBan delete = _context.PhongBan.Where(p => p.Id == id).FirstOrDefault();
            _context.PhongBan.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}