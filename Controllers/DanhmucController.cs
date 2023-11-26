using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlycafe.Models;

namespace Quanlycafe.Controllers
{
    public class DanhmucController : Controller
    {
        QLbanhang db = new QLbanhang();
        // GET: Danhmuc
        public ActionResult DanhmucPartial()
        {
            var danhmuc = db.Loaihang.ToList();
            return PartialView(danhmuc);
        }
    }
}