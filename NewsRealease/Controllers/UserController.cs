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
    public class UserController : Controller
    {
        //
        // GET: /User/

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

        public PartialViewResult AddUserView()
        {
            return PartialView();
        }

        [HttpPost]
        public ContentResult AddUser(string user_loginName, string user_psw, string user_realname)
        {
            Users user = new Users
            {
                user_loginName = user_loginName,
                user_psw = user_psw,
                user_realName = user_realname,
                user_flag = 1
            };
            ArgsHelper helper = IUserService.AddUser(user);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }

        public PartialViewResult ManageUserView()
        {
            List<Users> users = IUserService.GetAllUsers();
            ViewData["users"] = users;
            return PartialView();
        }

        public ContentResult RemoveUser(int user_id)
        {
            Users user = new Users
            {
                user_id = user_id
            };
            ArgsHelper helper = IUserService.RemoveUser(user);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }

        public PartialViewResult ModifyUserView(int user_id)
        {
            Users user = IUserService.GetAllUsers().FirstOrDefault(x => x.user_id == user_id);
            ViewData["user"] = user;
            return PartialView();
        }

        public ContentResult ChgUser(string user_id, string user_loginName, string user_psw, string user_realname)
        {
            Users user = new Users
            {
                user_id = Convert.ToInt32(user_id),
                user_loginName = user_loginName,
                user_psw = user_psw,
                user_realName = user_realname,
            };
            ArgsHelper helper = IUserService.ModifyUser(user);
            if (helper.Flag == true)
            {
                return Content("True");
            }
            else
            {
                return Content(helper.Msg);
            }
        }

        public PartialViewResult ResetPswView()
        {
            return PartialView();
        }

        public ContentResult ResetPsw(string oldPsw, string psw)
        {
            Users user = Session["user"] as Users;
            if (psw==null||psw=="")
            {
                return Content("密码不可为空");
            }
            if (user.user_psw==oldPsw)
            {
                user.user_psw = psw;
            }            
            ArgsHelper helper = IUserService.ResetPsw(user);
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
