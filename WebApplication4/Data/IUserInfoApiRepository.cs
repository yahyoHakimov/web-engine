using WebApplication4.Models;

namespace WebApplication4.Data
{
    public interface IUserInfoApiRepository
    {
        Task<IEnumerable<UserInfo>> GetAll();

        Task<UserInfo> GetById(int id);

        Task CreateUser(UserInfo userInfo);

        void DeleteUser(UserInfo user);

        public Task<bool> SaveChangesAsync();

        Task EditUser(UserInfo userInfo);
    }
}
