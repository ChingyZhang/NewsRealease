using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsRealease.BLL.Infrastructure;
using NewsRealease.BLL.Service;
using NewsRealease.DAL.DB;

namespace NewsRealease.Controllers
{
    public class BackController : Controller
    {
        //
        // GET: /Back/
        IUserService IUserService { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (IUserService == null)
            {
                IUserService = new UserService();
            }
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Right()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ViewResult LoginView()
        {
            return View();
        }

        public ActionResult Login(string useraccount, string password)
        {
            Users user = new DAL.DB.Users()
            {
                user_loginName = useraccount,
                user_psw = password
            };
            Users dbuser = IUserService.UserLogin(user);
            if (dbuser == null)
            {                
                return Content("用户名或密码错误");
            }
            else
            {
                Session["user"] = dbuser;
                return Content("True");
            }
        }

    }
}
