using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlycafe.Models;

namespace Quanlycafe.Controllers
{
    public class SanphamController : Controller
    {
        QLbanhang db = new QLbanhang();

        // GET: Sanpham
        public ActionResult coffeepartial()
        {
            var ip = db.Sanpham.Where(n=>n.Mahang==2).ToList();
           return PartialView(ip);
        }
        public ActionResult trapartial()
        {
            var ss = db.Sanpham.Where(n => n.Mahang == 1).ToList();
            return PartialView(ss);
        }
        public ActionResult banhpartial()
        {
            var mi = db.Sanpham.Where(n => n.Mahang == 3).ToList();
            return PartialView(mi);
        }       
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanpham.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }


    }

}