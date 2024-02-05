using WebApplication4.Models;

namespace WebApplication4.Data
{
    public interface ILogInfosApiRepository
    {
        Task<IEnumerable<LogInfo>> GetAll();

        Task<LogInfo> GetById(int id);

        Task CreateLogInfo(LogInfo logInfo);


        void DeleteLogInfo(LogInfo logInfo);

        public Task<bool> SaveChangesAsync();

        Task EditLogInfo(LogInfo logInfo);  
    }
}
