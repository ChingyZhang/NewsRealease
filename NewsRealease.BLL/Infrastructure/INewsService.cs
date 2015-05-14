using NewsRealease.DAL.DB;
using NewsRealease.DAL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsRealease.BLL.Infrastructure
{
    public interface INewsService
    {
        ArgsHelper AddNews(News news);

        List<NewsShow> GetAllNews();

        ArgsHelper ModifyNews(News news);

        ArgsHelper RemoveNews(News news);

        /// <summary>
        /// 获取所有新闻的类型
        /// </summary>
        /// <returns>
        /// 国际新闻  1
        /// 国内新闻  2
        /// 校内新闻  3
        /// </returns>
        List<NewsType> GetNewsType();
    }
}
