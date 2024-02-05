using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class SqlLogInfoApiRepository : ILogInfosApiRepository
    {
        private readonly DataContext _context;

        public SqlLogInfoApiRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateLogInfo(LogInfo logInfo)
        {
            if (logInfo == null) 
                throw new ArgumentNullException();

            await _context.Logs.AddAsync(logInfo);
        }

        public void DeleteLogInfo(LogInfo logInfo)
        {
            if (logInfo == null)
                throw new ArgumentNullException();

            _context.Logs.Remove(logInfo);
        }

        public async Task<IEnumerable<LogInfo>> GetAll()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<LogInfo> GetById(int id)
        {
            return await _context.Logs.FirstOrDefaultAsync(logs => logs.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task EditLogInfo(LogInfo logInfo)
        {
            ////
        }

    }
}
