using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsRealease.DAL.MODEL;
using NewsRealease.DAL.DB;

namespace NewsRealease.BLL.Infrastructure
{
    public interface IUserService
    {
        ArgsHelper AddUser(Users user);

        ArgsHelper RemoveUser(Users user);

        ArgsHelper ModifyUser(Users user);

        List<Users> GetAllUsers();

        Users UserLogin(Users user);

        ArgsHelper ResetPsw(Users user);
    }
}
