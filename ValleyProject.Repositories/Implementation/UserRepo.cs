using DataAccessLayer.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.Repositories.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        public UserRepo() 
        {

        }

        public UserRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string username, string password)
        {
            var user = await _context.UserInfos
                .FirstOrDefaultAsync(u => u.UserName.ToLower()==username.ToLower() && u.Password == password);
            return user;
        }

        public async Task RegisterUser(UserInfo user)
        {
            if(!IsExits(user.UserName))
            {

            }
                await _context.UserInfos.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public bool IsExits(string username)
        {
            return _context.UserInfos.
                Any(u => u.UserName.ToLower()== username.ToLower());
        }
    }
}
