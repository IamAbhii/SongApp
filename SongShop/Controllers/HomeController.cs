using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SongShop.Controllers
{
    public class HomeController : Controller
    {

        SongShopEntities2 db = new SongShopEntities2();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult AllSongOfuser(int id)
        {
            var result = db.Database.SqlQuery<SongOfUser>("Exec SongOfUser @Id", new SqlParameter("Id", id)).ToList();
            Logger.Info("User is getting Songs");
            return View(result);
        }

        public ActionResult SongSold(int id)
        {
            var result = db.Database.SqlQuery<SoldSong>("Exec SongSold @Id", new SqlParameter("Id", id)).ToList();
            Logger.Info("User is getting list of Sold song");
            return View(result);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
    public class SongOfUser
    {
        public string UserName { get; set; }
        public string SongName { get; set; }
    }

    public class SoldSong
    {
        public string SongName { get; set; }
        public string UserName { get; set; }
    }
}