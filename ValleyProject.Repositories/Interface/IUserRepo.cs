using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;

namespace ValleyProject.Repositories.Interface
{
    public interface IUserRepo
    {
        Task RegisterUser(UserInfo user);
        Task<UserInfo> GetUserInfo(string username,string password);
    }
}
