using NewsRealease.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsRealease.DAL.DB;
using NewsRealease.DAL.MODEL;
using NewsRealease.DAL.DAO;

namespace NewsRealease.BLL.Service
{
    public class NewsService:INewsService
    {

        NewsDAO NewsDAO = new NewsDAO();        

        public DAL.MODEL.ArgsHelper AddNews(DAL.DB.News news)
        {
            return NewsDAO.AddNews(news);
        }

        public List<DAL.MODEL.NewsShow> GetAllNews()
        {
            return NewsDAO.GetAllNews();
        }

        public DAL.MODEL.ArgsHelper ModifyNews(DAL.DB.News news)
        {
            return NewsDAO.ModifyNews(news);
        }

        public DAL.MODEL.ArgsHelper RemoveNews(DAL.DB.News news)
        {
            return NewsDAO.RemoveNews(news);
        }

        /// <summary>
        /// 获取所有新闻的类型
        /// </summary>
        /// <returns>
        /// 国际新闻  1
        /// 国内新闻  2
        /// 校内新闻  3
        /// </returns>
        public List<NewsType> GetNewsType()
        {
            return NewsDAO.GetNewsType();
        }
    }
}
