using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace BookingStoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db = new NewsContext();
        [HttpGet]
        public ActionResult Index()
        {
            var news = db.News.ToList();
            news.Reverse();
            ViewBag.News = news;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Index(Novelty news)
        {
                news.Date = DateTime.Now;
                // add news in db
                db.News.Add(news);
                // save all changes in db
                db.SaveChanges();
                var view_news = db.News.ToList();
                view_news.Reverse();
                ViewBag.News = view_news;
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
}