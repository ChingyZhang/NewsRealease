using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsRealease.BLL.Infrastructure;
using NewsRealease.DAL.DAO;
using NewsRealease.DAL.DB;
using NewsRealease.DAL.MODEL;

namespace NewsRealease.BLL.Service
{
    public class UserService:IUserService
    {
        UserDAO UserDAO = new UserDAO();

        public DAL.MODEL.ArgsHelper AddUser(DAL.DB.Users user)
        {
            return UserDAO.AddUser(user);            
        }

        public DAL.MODEL.ArgsHelper RemoveUser(DAL.DB.Users user)
        {
            return UserDAO.RemoveUser(user);
        }

        public DAL.MODEL.ArgsHelper ModifyUser(DAL.DB.Users user)
        {
            return UserDAO.ModifyUser(user);
        }

        public List<DAL.DB.Users> GetAllUsers()
        {
            return UserDAO.GetAllUsers();
        }


        public Users UserLogin(Users user)
        {
            return UserDAO.UserLogin(user);
        }

        public ArgsHelper ResetPsw(Users user)
        {
            return UserDAO.ResetPsw(user);
        }
    }
}
