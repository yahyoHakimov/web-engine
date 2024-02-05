using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class SqlCommandApiRepository : IUserInfoApiRepository
    {
        private readonly DataContext _context;

        public SqlCommandApiRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateUser(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException();
            }

            await _context.Users.AddAsync(userInfo);
        }

        public void DeleteUser(UserInfo user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<UserInfo>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserInfo> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(command => command.Id == id);


        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }


       public async Task EditUser(UserInfo userInfo)
        {
            ///
        }
    }
}
