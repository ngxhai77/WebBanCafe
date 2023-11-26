using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlycafe.Models;
using System.Data.Entity;
namespace Quanlycafe.Areas.Admin.Controllers
{
    public class ThongkesController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Admin/Thongkes
        public ActionResult Index()
        {
            var donhangs = db.Donhang.ToList();
            var dataThongke = (from s in db.Donhang
                      join x in db.Nguoidung on s.MaNguoidung equals x.MaNguoiDung
                      group s by s.MaNguoidung into g
                      select new Thongke
                      {
                          Tennguoidung = g.FirstOrDefault().Nguoidung.Hoten,
                          Tongtien = g.Sum(x => x.Tongtien),
                          Dienthoai = g.FirstOrDefault().Nguoidung.Dienthoai,
                          Soluong = g.Count()
                      });
            var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList();
            return View(dataFinal);
        }
    }
}