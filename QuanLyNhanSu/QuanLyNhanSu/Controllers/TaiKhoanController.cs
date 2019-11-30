using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class TaiKhoanController : Controller
    {
        Data.MyDbContext _context;
        public TaiKhoanController(Data.MyDbContext context)
        {
            this._context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Models.TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var allowUser = _context.TaiKhoan.SingleOrDefault(x => x.TenDangNhap.Equals(tk.TenDangNhap) && x.MatKhau.Equals(tk.MatKhau));
                if(allowUser != null) {

                    HttpContext.Session.SetString("Username", allowUser.TenDangNhap);
                    HttpContext.Session.SetString("PhongBan", allowUser.PhongBan.TenPB);

                    return RedirectToAction("Index","Home");
                }
            }
            return View(tk);
        }
        public IActionResult Register()
        {
            //ViewBag.phongBans = _context.PhongBan.ToList();
            ViewBag.phongBans = new List<Models.PhongBan>();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Models.TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var allowUser = _context.TaiKhoan.SingleOrDefault(x => x.TenDangNhap.Equals(tk.TenDangNhap) && x.MatKhau.Equals(tk.MatKhau));

                _context.TaiKhoan.Add(tk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.phongBans = _context.PhongBan.ToList();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Username") == "")
            {
                HttpContext.Session.Remove("Username");
                HttpContext.Session.Remove("PhongBan");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}