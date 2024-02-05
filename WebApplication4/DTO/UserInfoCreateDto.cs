using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.DTO
{
    public class UserInfoCreateDto
    {
        
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; } = null!;

        public List<LogInfo> UserInfo { get; set; }

    }
}
