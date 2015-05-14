using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsRealease.DAL.DB;
using NewsRealease.DAL.MODEL;

namespace NewsRealease.DAL.DAO
{
    public class UserDAO
    {
        #region 添加用户+AddUser
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ArgsHelper AddUser(Users user)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                var a = db.Users.FirstOrDefault(x => x.user_loginName == user.user_loginName);
                if (a != null)
                {
                    return new ArgsHelper("登录名重复");
                }
                db.Users.Add(user);
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
        }
        #endregion

        #region 删除用户+RemoveUser
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ArgsHelper RemoveUser(Users user)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                Users dbuser = db.Users.FirstOrDefault(x => x.user_id == user.user_id);
                if (dbuser != null)
                {
                    dbuser.user_flag = 0;
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
                    return new ArgsHelper("用户不存在");
                }
            }
        }
        #endregion

        #region 修改用户+ModifyUser
        /// <summary>
        /// 修改用户信息（不包括密码），判断登录账号冲突
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ArgsHelper ModifyUser(Users user)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                Users repeatLoginName = db.Users.FirstOrDefault(x => x.user_loginName == user.user_loginName);
                if (repeatLoginName != null)
                {
                    return new ArgsHelper(false, "登录名已存在");
                }
                Users dbuser = db.Users.FirstOrDefault(x => x.user_id == user.user_id);
                if (dbuser != null)
                {
                    dbuser.user_loginName = user.user_loginName;
                    dbuser.user_psw = user.user_psw;
                    dbuser.user_realName = user.user_realName;
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
                    return new ArgsHelper("用户不存在");
                }

            }
        }
        #endregion

        #region 修改用户密码+ResetPsw
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ArgsHelper ResetPsw(Users user)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                Users dbUser = db.Users.FirstOrDefault(x => x.user_id == user.user_id);
                if (dbUser == null)
                {
                    return new ArgsHelper(false, "不存在该用户");
                }                
                dbUser.user_psw = user.user_psw;
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
        } 
        #endregion

        #region 获取所有用户+GetAllUsers
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUsers()
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                return db.Users.Where(x => x.user_flag == 1).ToList();
            }
        }
        #endregion

        #region 用户登陆+UserLogin
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users UserLogin(Users user)
        {
            using (NewsReleaseEntities db = new NewsReleaseEntities())
            {
                Users dbuser = db.Users.FirstOrDefault(x => x.user_flag == 1 && x.user_loginName == user.user_loginName && x.user_psw == user.user_psw);
                return dbuser;
            }
        }
        #endregion

    }

}
