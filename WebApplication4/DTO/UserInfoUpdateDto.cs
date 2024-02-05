using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTO
{
    public class UserInfoUpdateDto
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; } = null!;
    }
}
