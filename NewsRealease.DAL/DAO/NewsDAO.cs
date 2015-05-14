using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsRealease.DAL.MODEL;
using NewsRealease.DAL.DB;

namespace NewsRealease.DAL.DAO
{
    public class NewsDAO
    {

        #region 添加文章+AddNews
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public ArgsHelper AddNews(News news)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                db.News.Add(news);
                try
                {
                    db.SaveChanges();
                    return new ArgsHelper(true);
                }
                catch (Exception ex)
                {
                    return new ArgsHelper(false, ex.Message);
                }
            }
        }
        #endregion

        #region 获取所有文章+GetAllNews
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public List<NewsShow> GetAllNews()
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                List<News> news = db.News.Where(x => x.news_flag == 1).ToList();
                List<NewsShow> newsShow = new List<NewsShow>();
                foreach (News item in news)
                {
                    NewsShow show = new NewsShow
                    {
                        news_id = item.news_id,
                        user_id = item.user_id,
                        type_id = item.type_id,
                        author = item.Users.user_realName,
                        news_title = item.news_title,
                        news_content = item.news_content,
                        news_time = item.news_time,
                        news_flag = item.news_flag,
                    };
                    newsShow.Add(show);
                }
                return newsShow;
            }
        }
        #endregion

        #region 删除文章+RemoveUser
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public ArgsHelper RemoveNews(News news)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                News dbuser = db.News.FirstOrDefault(x => x.news_id == news.news_id);
                if (dbuser != null)
                {
                    dbuser.news_flag = 0;
                    try
                    {
                        db.SaveChanges();
                        return new ArgsHelper(true);
                    }
                    catch (Exception ex)
                    {
                        return new ArgsHelper(ex.Message);
                    }
                }
                else
                {
                    return new ArgsHelper("文章不存在");
                }
            }
        }
        #endregion

        #region 修改文章+ModifyUser
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public ArgsHelper ModifyNews(News news)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                News dbNews = db.News.FirstOrDefault(x => x.news_id == news.news_id);
                if (dbNews != null)
                {
                    dbNews.news_title = news.news_title;
                    dbNews.news_content = news.news_content;
                    dbNews.news_time = news.news_time;
                    dbNews.type_id = news.type_id;
                    try
                    {
                        db.SaveChanges();
                        return new ArgsHelper(true);
                    }
                    catch (Exception ex)
                    {
                        return new ArgsHelper(ex.Message);
                    }
                }
                else
                {
                    return new ArgsHelper("文章不存在");
                }

            }
        }
        #endregion

        #region 获取所有新闻的类型,国际新闻  1,国内新闻  2,校内新闻  3+GetTyp
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
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                return db.NewsType.ToList();
            }
        }
        #endregion
    }
}
