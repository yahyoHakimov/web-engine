using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTO
{
    public class UserInfoReadDto : UserInfoCreateDto
    {
        public int Id { get; set; }
    }
}
