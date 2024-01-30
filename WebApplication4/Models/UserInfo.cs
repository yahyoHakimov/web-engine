namespace WebApplication4.Models
{
    public class UserInfo
    {
        public string Ip { get; set; }
        public string Name { get; set; } = null!;
        public LogInfo LogInfos { get; set; }
    }
}
