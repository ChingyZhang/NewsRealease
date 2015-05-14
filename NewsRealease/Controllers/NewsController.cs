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
    public class NewsController : Controller
    {
        //
        // GET: /News/

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
            return View();
        }

        public PartialViewResult AddNewsView()
        {
            List<NewsType> newsTypeList = INewsService.GetNewsType();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var newsType in newsTypeList)
            {
                SelectListItem select = new SelectListItem()
                {
                    Text = newsType.type_name,
                    Value = newsType.type_id.ToString()
                };
                selectList.Add(select);
            }
            ViewData["type"] = new SelectList(selectList, "Value", "Text");

            return PartialView();
        }

        [ValidateInput(false)]  //对提交的字符串不做验证
        public ContentResult AddNews(string news_title, string news_content, string type_id)
        {
            Users user = Session["user"] as Users;
            News news = new News
            {
                user_id = user.user_id,
                news_title = news_title,
                news_content = news_content,
                type_id = Convert.ToInt32(type_id),
                news_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                news_flag = 1
            };
            ArgsHelper helper = INewsService.AddNews(news);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }

        public PartialViewResult ManageNewsView()
        {

            if (Session["user"] == null)
            {
                return null;
            }
            Users user = Session["user"] as Users;
            List<NewsShow> news = INewsService.GetAllNews().Where(x => x.user_id == user.user_id).ToList();
            ViewData["news"] = news;

            return PartialView();
        }

        public PartialViewResult ModifyNewsView(int newsID)
        {
            NewsShow news = INewsService.GetAllNews().FirstOrDefault(x => x.news_id == newsID);
            ViewData["news"] = news;

            List<NewsType> newsTypeList = INewsService.GetNewsType();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var newsType in newsTypeList)
            {
                SelectListItem select = new SelectListItem()
                {
                    Text = newsType.type_name,
                    Value = newsType.type_id.ToString()
                };
                selectList.Add(select);
            }
            ViewData["type"] = new SelectList(selectList, "Value", "Text", news.type_id);

            return PartialView();
        }

        public ContentResult RemoveNews(int newsID)
        {
            News news = new News
            {
                news_id = newsID
            };
            ArgsHelper helper = INewsService.RemoveNews(news);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }

        [ValidateInput(false)]  //对提交的字符串不做验证
        public ContentResult ChgNews(int newsID, string news_title, string news_content, string type_id)
        {
            News news = new News
            {
                news_id = newsID,
                news_title = news_title,
                type_id = Convert.ToInt32(type_id),
                news_content = news_content,
                news_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            ArgsHelper helper = INewsService.ModifyNews(news);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }
    }
}
