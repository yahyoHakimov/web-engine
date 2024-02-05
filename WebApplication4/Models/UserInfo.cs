using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; } = null!;

        //public ICollection<LogInfo> Logs { get; set; }
    }
}
