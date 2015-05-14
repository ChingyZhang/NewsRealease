using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsRealease.BLL.Infrastructure;
using NewsRealease.BLL.Service;
using NewsRealease.DAL.DB;
using NewsRealease.DAL.MODEL;

namespace NewsRealease.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        INewsService INewsService { get; set; }


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (INewsService == null)
            {
                INewsService = new NewsService();
            }
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            List<NewsShow> news = INewsService.GetAllNews();
            ViewData["news"] = news;
            return View();
        }

        /// <summary>
        /// 获取指定条数的指定类型的新闻
        /// </summary>
        /// <param name="typeID">新闻类型</param>
        /// <param name="maximumLength">新闻列表截取的长度</param>
        /// <returns></returns>
        private List<NewsShow> GetPartivalNews(int typeID, int maximumLength)
        {
            List<NewsShow> allNews = INewsService.GetAllNews();
            List<NewsShow> news = allNews.Where(x => x.type_id == typeID).ToList();
            if (news.Count() > maximumLength)
            {
                news.RemoveRange(maximumLength, news.Count() - maximumLength);
            }
            return news;
        }

        public PartialViewResult IntrernalNewsPartialView()
        {
            List<NewsShow> internalNews = this.GetPartivalNews(1, 6);
            ViewData["news"] = internalNews;
            return PartialView();
        }

        public PartialViewResult InternationalNewsView()
        {
            List<NewsShow> internationalNews = this.GetPartivalNews(2, 6);            
            ViewData["news"] = internationalNews;
            return PartialView();
        }

        public PartialViewResult CampusNewsView()
        {
            List<NewsShow> campusNews = this.GetPartivalNews(3, 6);
            ViewData["news"] = campusNews;
            return PartialView();
        }

        public PartialViewResult AllNewsView(int typeID)
        {
            List<NewsShow> allNews = INewsService.GetAllNews();
            List<NewsShow> partivalNews = allNews.Where(x => x.type_id == typeID).ToList();
            ViewData["news"] = partivalNews;
            return PartialView();
        }

        public ViewResult NewsDetailView(int newsID)
        {
            NewsShow news = INewsService.GetAllNews().FirstOrDefault(x => x.news_id == newsID);
            ViewData["news"] = news;
            return View();
        }

    }
}
